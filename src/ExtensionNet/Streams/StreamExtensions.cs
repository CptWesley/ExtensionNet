using System;
using System.IO;

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
            => (char)stream.ReadByte();

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
            => (byte)stream.ReadByte();

        /// <summary>
        /// Reads multiple bytes from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of bytes.</param>
        /// <returns>An array of bytes read from stream.</returns>
        public static byte[] ReadUInt8(this Stream stream, int count)
        {
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
            => (sbyte)stream.ReadByte();

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
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ushort ReadUInt16(this Stream stream, bool bigEndian = false)
            => BitConverter.ToUInt16(stream.ReadUInt8(2).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple unsigned shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned shorts.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned shorts read from stream.</returns>
        public static ushort[] ReadUInt16(this Stream stream, int count, bool bigEndian = false)
        {
            ushort[] result = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt16(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static short ReadInt16(this Stream stream, bool bigEndian = false)
            => BitConverter.ToInt16(stream.ReadUInt8(2).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple signed shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed shorts.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed shorts read from stream.</returns>
        public static short[] ReadInt16(this Stream stream, int count, bool bigEndian = false)
        {
            short[] result = new short[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt16(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static uint ReadUInt32(this Stream stream, bool bigEndian = false)
            => BitConverter.ToUInt32(stream.ReadUInt8(4).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple unsigned integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned integers.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned integers read from stream.</returns>
        public static uint[] ReadUInt32(this Stream stream, int count, bool bigEndian = false)
        {
            uint[] result = new uint[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt32(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static int ReadInt32(this Stream stream, bool bigEndian = false)
            => BitConverter.ToInt32(stream.ReadUInt8(4).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple signed integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed integers.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed integers read from stream.</returns>
        public static int[] ReadInt32(this Stream stream, int count, bool bigEndian = false)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt32(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ulong ReadUInt64(this Stream stream, bool bigEndian = false)
            => BitConverter.ToUInt64(stream.ReadUInt8(8).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple unsigned longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned longs.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned longs read from stream.</returns>
        public static ulong[] ReadUInt64(this Stream stream, int count, bool bigEndian = false)
        {
            ulong[] result = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt64(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Reads an signed long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static long ReadInt64(this Stream stream, bool bigEndian = false)
            => BitConverter.ToInt64(stream.ReadUInt8(8).SetEndianness(bigEndian), 0);

        /// <summary>
        /// Reads multiple signed longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed longs.</param>
        /// <param name="bigEndian">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed longs read from stream.</returns>
        public static long[] ReadInt64(this Stream stream, int count, bool bigEndian = false)
        {
            long[] result = new long[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt64(bigEndian);
            }

            return result;
        }

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">String to write to stream.</param>
        public static void Write(this Stream stream, string value)
            => stream.Write(value.ToCharArray());

        /// <summary>
        /// Writes chars to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Chars to write to the stream.</param>
        public static void Write(this Stream stream, params char[] values)
        {
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
            => stream.Write(values, 0, values.Length);

        /// <summary>
        /// Writes signed bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed bytes to write to the stream.</param>
        public static void Write(this Stream stream, params sbyte[] values)
        {
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
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ushort value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes unsigned shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned shorts to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ushort[] values, bool bigEndian = false)
        {
            foreach (ushort value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        /// <summary>
        /// Writes signed short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed short to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes signed shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed shorts to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short[] values, bool bigEndian = false)
        {
            foreach (short value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        /// <summary>
        /// Writes unsigned integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned integer to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes unsigned integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned integers to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint[] values, bool bigEndian = false)
        {
            foreach (uint value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        /// <summary>
        /// Writes signed integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed integer to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes signed integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed integers to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int[] values, bool bigEndian = false)
        {
            foreach (int value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        /// <summary>
        /// Writes unsigned long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned long to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes unsigned longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned longs to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong[] values, bool bigEndian = false)
        {
            foreach (ulong value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        /// <summary>
        /// Writes signed long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long value, bool bigEndian = false)
            => stream.Write(BitConverter.GetBytes(value).SetEndianness(bigEndian));

        /// <summary>
        /// Writes signed longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        /// <param name="bigEndian">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long[] values, bool bigEndian = false)
        {
            foreach (long value in values)
            {
                stream.Write(value, bigEndian);
            }
        }

        private static byte[] SetEndianness(this byte[] bytes, bool bigEndian)
        {
            if ((BitConverter.IsLittleEndian && bigEndian) || (!BitConverter.IsLittleEndian && !bigEndian))
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }
    }
}
