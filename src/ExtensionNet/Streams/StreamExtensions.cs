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
        /// <returns>First unsigned short on the stream.</returns>
        public static ushort ReadUInt16(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(2);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        /// Reads multiple unsigned shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned shorts.</param>
        /// <returns>An array of unsigned shorts read from stream.</returns>
        public static ushort[] ReadUInt16(this Stream stream, int count)
        {
            ushort[] result = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt16();
            }

            return result;
        }

        /// <summary>
        /// Reads an signed short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static short ReadInt16(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(2);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Reads multiple signed shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed shorts.</param>
        /// <returns>An array of signed shorts read from stream.</returns>
        public static short[] ReadInt16(this Stream stream, int count)
        {
            short[] result = new short[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt16();
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static uint ReadUInt32(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Reads multiple unsigned integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned integers.</param>
        /// <returns>An array of unsigned integers read from stream.</returns>
        public static uint[] ReadUInt32(this Stream stream, int count)
        {
            uint[] result = new uint[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt32();
            }

            return result;
        }

        /// <summary>
        /// Reads an signed integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static int ReadInt32(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(4);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Reads multiple signed integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed integers.</param>
        /// <returns>An array of signed integers read from stream.</returns>
        public static int[] ReadInt32(this Stream stream, int count)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt32();
            }

            return result;
        }

        /// <summary>
        /// Reads an unsigned long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ulong ReadUInt64(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(8);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        /// Reads multiple unsigned longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned longs.</param>
        /// <returns>An array of unsigned longs read from stream.</returns>
        public static ulong[] ReadUInt64(this Stream stream, int count)
        {
            ulong[] result = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt64();
            }

            return result;
        }

        /// <summary>
        /// Reads an signed long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static long ReadInt64(this Stream stream)
        {
            byte[] bytes = stream.ReadUInt8(8);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        /// Reads multiple signed longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed longs.</param>
        /// <returns>An array of signed longs read from stream.</returns>
        public static long[] ReadInt64(this Stream stream, int count)
        {
            long[] result = new long[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt64();
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
        /// Writes unsigned shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned shorts to write to the stream.</param>
        public static void Write(this Stream stream, ushort[] values)
        {
            foreach (ushort value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }

        /// <summary>
        /// Writes signed shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed shorts to write to the stream.</param>
        public static void Write(this Stream stream, short[] values)
        {
            foreach (short value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }

        /// <summary>
        /// Writes unsigned integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned integers to write to the stream.</param>
        public static void Write(this Stream stream, uint[] values)
        {
            foreach (uint value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }

        /// <summary>
        /// Writes signed integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed integers to write to the stream.</param>
        public static void Write(this Stream stream, int[] values)
        {
            foreach (int value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }

        /// <summary>
        /// Writes unsigned longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned longs to write to the stream.</param>
        public static void Write(this Stream stream, ulong[] values)
        {
            foreach (ulong value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }

        /// <summary>
        /// Writes signed longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        public static void Write(this Stream stream, long[] values)
        {
            foreach (long value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }

                stream.Write(bytes);
            }
        }
    }
}
