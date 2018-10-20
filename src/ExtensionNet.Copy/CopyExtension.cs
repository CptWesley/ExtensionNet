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
            if (that is string)
            {
                return that;
            }

            T copy = (T)FormatterServices.GetUninitializedObject(typeof(T));
            return copy;
        }
    }
}
