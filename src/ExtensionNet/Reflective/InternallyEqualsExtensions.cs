﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionNet.Reflective
{
    /// <summary>
    /// Static extension class which adds an internal equals method to every object.
    /// </summary>
    public static class InternallyEqualsExtensions
    {
        /// <summary>
        /// Checks if an object is internally equal in a shallow manner.
        /// </summary>
        /// <param name="that">The object to check for.</param>
        /// <param name="other">The object to check with.</param>
        /// <returns>True if internally equal, false otherwise.</returns>
        public static bool InternallyEquals(this object that, object other)
            => InternallyEquals(that, other, false);

        /// <summary>
        /// Checks if an object is internally equal in a shallow or deep manner.
        /// </summary>
        /// <param name="that">The object to check for.</param>
        /// <param name="other">The object to check with.</param>
        /// <param name="deep">Determines whether or not the comparison is recursive.</param>
        /// <returns>True if internally equal, false otherwise.</returns>
        public static bool InternallyEquals(this object that, object other, bool deep)
            => that.InternallyEquals(other, deep, new Dictionary<object, HashSet<object>>());

        private static bool InternallyEquals(this object that, object other, bool deep, Dictionary<object, HashSet<object>> comparisons)
        {
            if (that == null)
            {
                return that == other;
            }

            Type type = that.GetType();

            if (that is string || type.IsPrimitive)
            {
                return that.Equals(other);
            }

            if (type != other.GetType())
            {
                return false;
            }

            // Just assume that something is equal if we've started comparing it before. Might be a false assumption.
            if (comparisons.TryGetValue(that, out var set) && set.Contains(other))
            {
                return true;
            }

            comparisons.AddComparison(that, other);

            if (type.IsArray)
            {
                return ArrayEquals(that as Array, other as Array, deep, comparisons);
            }

            return ObjectEquals(that, other, deep, comparisons);
        }

        private static bool ArrayEquals(Array that, Array other, bool deep, Dictionary<object, HashSet<object>> comparisons)
        {
            if (that.Length != other.Length)
            {
                return false;
            }

            for (int i = 0; i < that.Length; ++i)
            {
                object thatCur = that.GetValue(i);
                object otherCur = other.GetValue(i);
                if (thatCur == null && otherCur == null)
                {
                    continue;
                }

                if (!(deep ? thatCur.InternallyEquals(otherCur, deep, comparisons) : thatCur.Equals(otherCur)))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ObjectEquals(object that, object other, bool deep, Dictionary<object, HashSet<object>> comparisons)
        {
            Type type = that.GetType();
            while (type != null)
            {
                if (!EqualsForType(that, other, type, deep, comparisons))
                {
                    return false;
                }

                type = type.BaseType;
            }

            return true;
        }

        private static bool EqualsForType(object that, object other, Type type, bool deep, Dictionary<object, HashSet<object>> comparisons)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (FieldInfo field in fields)
            {
                object thatValue = field.GetValue(that);
                object otherValue = field.GetValue(other);

                if (!(deep ? thatValue.InternallyEquals(otherValue, deep, comparisons) : thatValue.Equals(otherValue)))
                {
                    return false;
                }
            }

            return true;
        }

        private static void AddComparison(this Dictionary<object, HashSet<object>> comparisons, object that, object other)
        {
            if (!comparisons.ContainsKey(that))
            {
                comparisons[that] = new HashSet<object>();
            }

            comparisons[that].Add(other);
        }
    }
}
