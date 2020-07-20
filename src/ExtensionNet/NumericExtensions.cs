using System;

namespace ExtensionNet
{
    /// <summary>
    /// Provides extension methods for numeric values.
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this short value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ushort value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this int value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this uint value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this long value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ulong value, Endianness endianness = Endianness.Current)
            => BitConverter.GetBytes(value).SetEndianness(endianness);
    }
}
