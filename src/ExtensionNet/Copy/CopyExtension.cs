using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ExtensionNet.Copy
{
    /// <summary>
    /// Static extension class which adds a copy method to every object.
    /// </summary>
    public static class CopyExtension
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
        {
            if (that == null || that is string || that.GetType().IsValueType)
            {
                return that;
            }

            if (that.GetType().IsArray)
            {
                return (T)CopyArray(that as Array, deep);
            }

            return (T)CopyObject(that, deep);
        }

        /// <summary>
        /// Creates a copy of an object which is not an array or a value type.
        /// </summary>
        /// <param name="that">The object to copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <returns>A copy of the object.</returns>
        private static object CopyObject(object that, bool deep)
        {
            Type type = that.GetType();
            object copy = FormatterServices.GetUninitializedObject(type);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                object value = deep ? field.GetValue(that).Copy(true) : field.GetValue(that);
                field.SetValue(copy, value);
            }

            return copy;
        }

        /// <summary>
        /// Creates a copy of an array.
        /// </summary>
        /// <param name="that">The array to copy.</param>
        /// <param name="deep">Specifies whether or not the copy should be a deep copy.</param>
        /// <returns>A copy of the object.</returns>
        private static object CopyArray(Array that, bool deep)
        {
            Array copy = Array.CreateInstance(that.GetType().GetElementType(), that.Length);

            for (int i = 0; i < that.Length; ++i)
            {
                object value = deep ? that.GetValue(i).Copy(true) : that.GetValue(i);
                copy.SetValue(value, i);
            }

            return copy;
        }
    }
}
