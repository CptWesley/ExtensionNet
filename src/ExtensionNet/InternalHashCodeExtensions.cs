using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionNet
{
    /// <summary>
    /// Static extension class adding methods to objects to retrieve a hashcode calculated using reflection.
    /// </summary>
    public static class InternalHashCodeExtensions
    {
        /// <summary>
        /// Gets the internal hash code of the object using reflection.
        /// </summary>
        /// <param name="that">The object to get the hash code from.</param>
        /// <returns>The internal hash code retrieved using reflection.</returns>
        public static int GetInternalHashCode(this object that)
            => that.GetInternalHashCode(false);

        /// <summary>
        /// Gets the internal hash code of the object using reflection.
        /// </summary>
        /// <param name="that">The object to get the hash code from.</param>
        /// <param name="deep">Whether or not to get the hash code recursively.</param>
        /// <returns>The internal hash code retrieved using reflection.</returns>
        public static int GetInternalHashCode(this object that, bool deep)
            => that.GetInternalHashCode(deep, new HashSet<ReferenceWrapper>());

        private static int GetInternalHashCode(this object that, bool deep, HashSet<ReferenceWrapper> hashes)
        {
            if (that is null)
            {
                return 0;
            }

            Type type = that.GetType();
            if (that is string || type.IsPrimitive)
            {
                return that.GetHashCode();
            }

            ReferenceWrapper thatWrapper = new ReferenceWrapper(that);

            if (hashes.Contains(thatWrapper))
            {
                return thatWrapper.Target.GetType().GetHashCode();
            }

            hashes.Add(thatWrapper);

            int result;
            if (type.IsArray)
            {
                result = GetArrayHash(that as Array, deep, hashes);
            }
            else
            {
                result = GetObjectHash(that, deep, hashes);
            }

            return result;
        }

        private static int GetArrayHash(Array that, bool deep, HashSet<ReferenceWrapper> hashes)
        {
            int result = that.GetType().GetHashCode();

            for (int i = 0; i < that.Length; ++i)
            {
                object current = that.GetValue(i);
                result += (i + 1) * (deep ? current.GetInternalHashCode(deep, hashes) : current.GetHashCode());
            }

            return result;
        }

        private static int GetObjectHash(object that, bool deep, HashSet<ReferenceWrapper> hashes)
        {
            Type type = that.GetType();
            int result = type.GetHashCode();
            int scalar = 1;

            while (type != null)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (FieldInfo field in fields)
                {
                    result += (scalar++) * (deep ? field.GetValue(that).GetInternalHashCode(deep, hashes) : field.GetValue(that).GetHashCode());
                }

                type = type.BaseType;
            }

            return result;
        }
    }
}
