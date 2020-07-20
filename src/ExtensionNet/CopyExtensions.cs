using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace ExtensionNet
{
    /// <summary>
    /// Static extension class which adds a copy method to every object.
    /// </summary>
    public static class CopyExtensions
    {
        /// <summary>
        /// Creates a shallow copy of the object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="that">The object of which to create a shallow copy.</param>
        /// <returns>A shallow copy of the object.</returns>
        public static T Copy<T>(this T that) => that.Copy(false);

        /// <summary>
        /// Creates a copy of the object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="that">The object of which to create a copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <returns>A copy of the object.</returns>
        public static T Copy<T>(this T that, bool deep)
            => Copy(that, deep, new Dictionary<object, object>());

        /// <summary>
        /// Creates a copy of the object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="that">The object of which to create a copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <param name="copies">Map containing a link between objects and their copies.</param>
        /// <returns>A copy of the object.</returns>
        private static T Copy<T>(this T that, bool deep, Dictionary<object, object> copies)
        {
            if (that == null || that is string || that.GetType().IsPrimitive)
            {
                return that;
            }

            if (copies.TryGetValue(that, out var copy))
            {
                return (T)copy;
            }

            if (that.GetType().IsArray)
            {
                return (T)CopyArray(that as Array, deep, copies);
            }

            return (T)CopyObject(that, deep, copies);
        }

        /// <summary>
        /// Creates a copy of an object which is not an array or a value type.
        /// </summary>
        /// <param name="that">The object to copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <param name="copies">Map containing a link between objects and their copies.</param>
        /// <returns>A copy of the object.</returns>
        private static object CopyObject(object that, bool deep, Dictionary<object, object> copies)
        {
            Type type = that.GetType();
            object copy = FormatterServices.GetUninitializedObject(type);
            copies.Add(that, copy);

            Type curType = type;
            while (curType != null)
            {
                SetTypeFields(that, copy, curType, deep, copies);
                curType = curType.BaseType;
            }

            return copy;
        }

        /// <summary>
        /// Sets the fields on the copy of a specific type.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="copy">The copy.</param>
        /// <param name="type">The type.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <param name="copies">Map containing a link between objects and their copies.</param>
        private static void SetTypeFields(object source, object copy, Type type, bool deep, Dictionary<object, object> copies)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (FieldInfo field in fields)
            {
                object value = deep ? field.GetValue(source).Copy(true, copies) : field.GetValue(source);
                field.SetValue(copy, value);
            }
        }

        /// <summary>
        /// Creates a copy of an array.
        /// </summary>
        /// <param name="that">The array to copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <param name="copies">Map containing a link between objects and their copies.</param>
        /// <returns>A copy of the object.</returns>
        private static object CopyArray(Array that, bool deep, Dictionary<object, object> copies)
        {
            Array copy = Array.CreateInstance(that.GetType().GetElementType(), that.Length);
            copies.Add(that, copy);

            for (int i = 0; i < that.Length; ++i)
            {
                object value = deep ? that.GetValue(i).Copy(true, copies) : that.GetValue(i);
                copy.SetValue(value, i);
            }

            return copy;
        }
    }
}
