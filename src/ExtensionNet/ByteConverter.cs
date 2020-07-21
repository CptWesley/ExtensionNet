using System;
using System.Numerics;

namespace ExtensionNet
{
    /// <summary>
    /// Provides similar behaviour to the <see cref="BitConverter"/> class, but with better Endianness support.
    /// </summary>
    public static class ByteConverter
    {
        /// <summary>
        /// The endianness of the current system.
        /// </summary>
        public static readonly Endianness Endianness = BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian;

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this short value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this short value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ushort value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ushort value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this int value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this int value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this uint value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this uint value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this long value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this long value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ulong value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this ulong value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this float value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this float value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this double value, Endianness endianness)
            => BitConverter.GetBytes(value).SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this double value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this BigInteger value, Endianness endianness)
            => value.ToByteArray().SetEndianness(endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this BigInteger value)
            => value.GetBytes(Endianness);

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="size">The number of bytes used to represent the big integer.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this BigInteger value, int size, Endianness endianness)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Writing and reading negative values such as the given '{value}' is currently not supported.", nameof(value));
            }

            byte[] bytes = value.ToByteArray();
            int filler = size - bytes.Length;

            if (filler < 0)
            {
                throw new ArgumentException($"The given size ({size}) can't be smaller than the number of bytes required to represent the value ({bytes.Length}).", nameof(size));
            }

            byte[] result = new byte[bytes.Length + filler];

            if (endianness == Endianness.LittleEndian)
            {
                Array.Copy(bytes, 0, result, 0, bytes.Length);
            }
            else
            {
                Array.Reverse(bytes);
                Array.Copy(bytes, 0, result, filler, bytes.Length);
            }

            return result;
        }

        /// <summary>
        /// Gets the bytes of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="size">The number of bytes used to represent the big integer.</param>
        /// <returns>The bytes representing the value.</returns>
        public static byte[] GetBytes(this BigInteger value, int size)
            => value.GetBytes(size, Endianness);

        /// <summary>
        /// Converts the bytes to a signed short.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The signed short represented by the bytes.</returns>
        public static short ToInt16(this byte[] bytes, Endianness endianness)
            => BitConverter.ToInt16(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to a signed short.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The signed short represented by the bytes.</returns>
        public static short ToInt16(this byte[] bytes)
            => bytes.ToInt16(Endianness);

        /// <summary>
        /// Converts the bytes to an unsigned short.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The unsigned short represented by the bytes.</returns>
        public static ushort ToUInt16(this byte[] bytes, Endianness endianness)
            => BitConverter.ToUInt16(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to an unsigned short.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The unsigned short represented by the bytes.</returns>
        public static ushort ToUInt16(this byte[] bytes)
            => bytes.ToUInt16(Endianness);

        /// <summary>
        /// Converts the bytes to a signed int.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The signed int represented by the bytes.</returns>
        public static int ToInt32(this byte[] bytes, Endianness endianness)
            => BitConverter.ToInt32(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to a signed int.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The signed int represented by the bytes.</returns>
        public static int ToInt32(this byte[] bytes)
            => bytes.ToInt32(Endianness);

        /// <summary>
        /// Converts the bytes to an unsigned int.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The unsigned int represented by the bytes.</returns>
        public static uint ToUInt32(this byte[] bytes, Endianness endianness)
            => BitConverter.ToUInt32(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to an unsigned int.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The unsigned int represented by the bytes.</returns>
        public static uint ToUInt32(this byte[] bytes)
            => bytes.ToUInt32(Endianness);

        /// <summary>
        /// Converts the bytes to a signed long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The signed long represented by the bytes.</returns>
        public static long ToInt64(this byte[] bytes, Endianness endianness)
            => BitConverter.ToInt64(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to a signed long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The signed long represented by the bytes.</returns>
        public static long ToInt64(this byte[] bytes)
            => bytes.ToInt64(Endianness);

        /// <summary>
        /// Converts the bytes to an unsigned long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The unsigned long represented by the bytes.</returns>
        public static ulong ToUInt64(this byte[] bytes, Endianness endianness)
            => BitConverter.ToUInt64(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to an unsigned long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The unsigned long represented by the bytes.</returns>
        public static ulong ToUInt64(this byte[] bytes)
            => bytes.ToUInt64(Endianness);

        /// <summary>
        /// Converts the bytes to a float.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The float represented by the bytes.</returns>
        public static float ToFloat32(this byte[] bytes, Endianness endianness)
            => BitConverter.ToSingle(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to a float.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The float represented by the bytes.</returns>
        public static float ToFloat32(this byte[] bytes)
            => bytes.ToFloat32(Endianness);

        /// <summary>
        /// Converts the bytes to a double.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The double represented by the bytes.</returns>
        public static double ToFloat64(this byte[] bytes, Endianness endianness)
            => BitConverter.ToDouble(bytes.SetEndianness(endianness), 0);

        /// <summary>
        /// Converts the bytes to a double.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The double represented by the bytes.</returns>
        public static double ToFloat64(this byte[] bytes)
            => bytes.ToFloat64(Endianness);

        /// <summary>
        /// Converts the bytes to a big integer.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>The big integer represented by the bytes.</returns>
        public static BigInteger ToBigInteger(this byte[] bytes, Endianness endianness)
            => new BigInteger(bytes.SetEndianness(endianness));

        /// <summary>
        /// Converts the bytes to a big integer.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The big integer represented by the bytes.</returns>
        public static BigInteger ToBigInteger(this byte[] bytes)
            => bytes.ToBigInteger(Endianness);
    }
}
