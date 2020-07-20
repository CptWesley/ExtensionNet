using System;
using System.IO;
using ExtensionNet.Types;

namespace ExtensionNet.Streams
{
    /// <summary>
    /// Extension class for the <see cref="Stream"/> class.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First char on the stream.</returns>
        public static char ReadChar(this Stream stream)
            => (char)stream.ReadUInt8();

        /// <summary>
        /// Reads multiple chars from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of chars.</param>
        /// <returns>An array of chars read from stream.</returns>
        public static char[] ReadChar(this Stream stream, int count)
        {
            char[] result = new char[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadChar();
            }

            return result;
        }

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First char on the stream.</returns>
        public static string ReadString(this Stream stream)
            => stream.ReadString(1);

        /// <summary>
        /// Reads a string from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of chars.</param>
        /// <returns>A string read from stream.</returns>
        public static string ReadString(this Stream stream, int count)
            => new string(stream.ReadChar(count));

        /// <summary>
        /// Reads a single byte from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First byte on the stream.</returns>
        public static byte ReadUInt8(this Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            return (byte)stream.ReadByte();
        }

        /// <summary>
        /// Reads multiple bytes from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of bytes.</param>
        /// <returns>An array of bytes read from stream.</returns>
        public static byte[] ReadUInt8(this Stream stream, int count)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            byte[] bytes = new byte[count];
            stream.Read(bytes, 0, count);
            return bytes;
        }

        /// <summary>
        /// Reads a single signed byte from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed byte on the stream.</returns>
        public static sbyte ReadInt8(this Stream stream)
            => (sbyte)stream.ReadUInt8();

        /// <summary>
        /// Reads multiple signed bytes from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed bytes.</param>
        /// <returns>An array of signed bytes read from stream.</returns>
        public static sbyte[] ReadInt8(this Stream stream, int count)
        {
            sbyte[] result = new sbyte[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt8();
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ushort ReadUInt16(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToUInt16(stream.ReadUInt8(2).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple unsigned shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned shorts.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned shorts read from stream.</returns>
        public static ushort[] ReadUInt16(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            ushort[] result = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt16(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static short ReadInt16(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToInt16(stream.ReadUInt8(2).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple signed shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed shorts.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed shorts read from stream.</returns>
        public static short[] ReadInt16(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            short[] result = new short[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt16(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static uint ReadUInt32(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToUInt32(stream.ReadUInt8(4).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple unsigned integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned integers.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned integers read from stream.</returns>
        public static uint[] ReadUInt32(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            uint[] result = new uint[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt32(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static int ReadInt32(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToInt32(stream.ReadUInt8(4).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple signed integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed integers.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed integers read from stream.</returns>
        public static int[] ReadInt32(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt32(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ulong ReadUInt64(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToUInt64(stream.ReadUInt8(8).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple unsigned longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned longs.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned longs read from stream.</returns>
        public static ulong[] ReadUInt64(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            ulong[] result = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt64(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static long ReadInt64(this Stream stream, Endianness endianness = Endianness.Current)
            => BitConverter.ToInt64(stream.ReadUInt8(8).SetEndianness(endianness), 0);

        /// <summary>
        /// Reads multiple signed longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed longs.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed longs read from stream.</returns>
        public static long[] ReadInt64(this Stream stream, int count, Endianness endianness = Endianness.Current)
        {
            long[] result = new long[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt64(endianness);
            }

            return result;
        }

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">String to write to stream.</param>
        public static void Write(this Stream stream, string value)
            => stream.Write(value?.ToCharArray());

        /// <summary>
        /// Writes chars to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Chars to write to the stream.</param>
        public static void Write(this Stream stream, params char[] values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            foreach (char value in values)
            {
                stream.WriteByte((byte)value);
            }
        }

        /// <summary>
        /// Writes bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Bytes to write to the stream.</param>
        public static void Write(this Stream stream, params byte[] values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            stream.Write(values, 0, values.Length);
        }

        /// <summary>
        /// Writes signed bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed bytes to write to the stream.</param>
        public static void Write(this Stream stream, params sbyte[] values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            foreach (sbyte value in values)
            {
                stream.WriteByte((byte)value);
            }
        }

        /// <summary>
        /// Writes unsigned short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned short to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ushort value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes unsigned shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned shorts to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ushort[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (ushort value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes signed short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed short to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes signed shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed shorts to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (short value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes unsigned integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned integer to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes unsigned integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned integers to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (uint value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes signed integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed integer to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes signed integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed integers to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (int value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes unsigned long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes unsigned longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (ulong value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes signed long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long value, Endianness endianness = Endianness.Current)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(endianness));

        /// <summary>
        /// Writes signed longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long[] values, Endianness endianness = Endianness.Current)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (long value in values)
            {
                stream.Write(value, endianness);
            }
        }

        private static byte[] SetEndianness(this byte[] bytes, Endianness endianness)
        {
            if ((BitConverter.IsLittleEndian && endianness == Endianness.BigEndian) || (!BitConverter.IsLittleEndian && endianness == Endianness.LittleEndian))
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }
    }
}
