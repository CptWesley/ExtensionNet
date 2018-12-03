using System;

namespace ExtensionNet.Endian
{
    /// <summary>
    /// Class containing extension methods relating to endianness of numbers.
    /// </summary>
    public static class EndianExtensions
    {
        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static short ChangeEndianness(this short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static ushort ChangeEndianness(this ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static int ChangeEndianness(this int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static uint ChangeEndianness(this uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static long ChangeEndianness(this long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        /// Changes the endianness of the value.
        /// </summary>
        /// <param name="value">The value to change the endianness of.</param>
        /// <returns>The value with endianness changed.</returns>
        public static ulong ChangeEndianness(this ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}
