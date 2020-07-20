using System;
using System.IO;
using System.Numerics;

namespace ExtensionNet
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
        public static ushort ReadUInt16(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(2).ToUInt16(endianness);

        /// <summary>
        /// Reads an unsigned short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ushort ReadUInt16(this Stream stream)
            => stream.ReadUInt16(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple unsigned shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned shorts.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned shorts read from stream.</returns>
        public static ushort[] ReadUInt16(this Stream stream, int count, Endianness endianness)
        {
            ushort[] result = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt16(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple unsigned shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned shorts.</param>
        /// <returns>An array of unsigned shorts read from stream.</returns>
        public static ushort[] ReadUInt16(this Stream stream, int count)
            => stream.ReadUInt16(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads an signed short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static short ReadInt16(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(2).ToInt16(endianness);

        /// <summary>
        /// Reads an signed short from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static short ReadInt16(this Stream stream)
            => stream.ReadInt16(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple signed shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed shorts.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed shorts read from stream.</returns>
        public static short[] ReadInt16(this Stream stream, int count, Endianness endianness)
        {
            short[] result = new short[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt16(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple signed shorts from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed shorts.</param>
        /// <returns>An array of signed shorts read from stream.</returns>
        public static short[] ReadInt16(this Stream stream, int count)
            => stream.ReadInt16(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads an unsigned integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static uint ReadUInt32(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(4).ToUInt32(endianness);

        /// <summary>
        /// Reads an unsigned integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static uint ReadUInt32(this Stream stream)
            => stream.ReadUInt32(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple unsigned integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned integers.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned integers read from stream.</returns>
        public static uint[] ReadUInt32(this Stream stream, int count, Endianness endianness)
        {
            uint[] result = new uint[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt32(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple unsigned integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned integers.</param>
        /// <returns>An array of unsigned integers read from stream.</returns>
        public static uint[] ReadUInt32(this Stream stream, int count)
            => stream.ReadUInt32(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads an signed integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static int ReadInt32(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(4).ToInt32(endianness);

        /// <summary>
        /// Reads an signed integer from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static int ReadInt32(this Stream stream)
            => stream.ReadInt32(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple signed integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed integers.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed integers read from stream.</returns>
        public static int[] ReadInt32(this Stream stream, int count, Endianness endianness)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt32(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple signed integers from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed integers.</param>
        /// <returns>An array of signed integers read from stream.</returns>
        public static int[] ReadInt32(this Stream stream, int count)
            => stream.ReadInt32(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads an unsigned long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ulong ReadUInt64(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(8).ToUInt64(endianness);

        /// <summary>
        /// Reads an unsigned long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First unsigned short on the stream.</returns>
        public static ulong ReadUInt64(this Stream stream)
            => stream.ReadUInt64(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple unsigned longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned longs.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of unsigned longs read from stream.</returns>
        public static ulong[] ReadUInt64(this Stream stream, int count, Endianness endianness)
        {
            ulong[] result = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadUInt64(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple unsigned longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of unsigned longs.</param>
        /// <returns>An array of unsigned longs read from stream.</returns>
        public static ulong[] ReadUInt64(this Stream stream, int count)
            => stream.ReadUInt64(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads an signed long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First signed short on the stream.</returns>
        public static long ReadInt64(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(8).ToInt64(endianness);

        /// <summary>
        /// Reads an signed long from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First signed short on the stream.</returns>
        public static long ReadInt64(this Stream stream)
            => stream.ReadInt64(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple signed longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed longs.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of signed longs read from stream.</returns>
        public static long[] ReadInt64(this Stream stream, int count, Endianness endianness)
        {
            long[] result = new long[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadInt64(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple signed longs from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of signed longs.</param>
        /// <returns>An array of signed longs read from stream.</returns>
        public static long[] ReadInt64(this Stream stream, int count)
            => stream.ReadInt64(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads a big integer from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="size">The size of the big integer in number of bytes.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>A big integer read from stream.</returns>
        public static BigInteger ReadBigInteger(this Stream stream, int size, Endianness endianness)
            => new BigInteger(stream.ReadUInt8(size).SetEndianness(endianness));

        /// <summary>
        /// Reads a big integer from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="size">The size of the big integer in number of bytes.</param>
        /// <returns>A big integer read from stream.</returns>
        public static BigInteger ReadBigInteger(this Stream stream, int size)
            => stream.ReadBigInteger(size, ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple big integers from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="size">The size of the big integers in number of bytes.</param>
        /// <param name="count">The number of big integers to read.</param>
        /// <param name="endianness">The endianness.</param>
        /// <returns>A big integer read from stream.</returns>
        public static BigInteger[] ReadBigInteger(this Stream stream, int size, int count, Endianness endianness)
        {
            BigInteger[] result = new BigInteger[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadBigInteger(size, endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple big integers from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="size">The size of the big integers in number of bytes.</param>
        /// <param name="count">The number of big integers to read.</param>
        /// <returns>A big integer read from stream.</returns>
        public static BigInteger[] ReadBigInteger(this Stream stream, int size, int count)
            => stream.ReadBigInteger(size, count, ByteConverter.Endianness);

        /// <summary>
        /// Reads a float from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First float on the stream.</returns>
        public static float ReadFloat32(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(4).ToFloat32(endianness);

        /// <summary>
        /// Reads a float from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First float on the stream.</returns>
        public static float ReadFloat32(this Stream stream)
            => stream.ReadFloat32(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple floats from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of floats.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of floats read from stream.</returns>
        public static float[] ReadFloat32(this Stream stream, int count, Endianness endianness)
        {
            float[] result = new float[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadFloat32(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple floats from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of floats.</param>
        /// <returns>An array of floats read from stream.</returns>
        public static float[] ReadFloat32(this Stream stream, int count)
            => stream.ReadFloat32(count, ByteConverter.Endianness);

        /// <summary>
        /// Reads a double from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>First double on the stream.</returns>
        public static double ReadFloat64(this Stream stream, Endianness endianness)
            => stream.ReadUInt8(8).ToFloat64(endianness);

        /// <summary>
        /// Reads a double from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First double on the stream.</returns>
        public static double ReadFloat64(this Stream stream)
            => stream.ReadFloat64(ByteConverter.Endianness);

        /// <summary>
        /// Reads multiple doubles from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of doubles.</param>
        /// <param name="endianness">Determines whether to interpret the values as big endian or little endian.</param>
        /// <returns>An array of doubles read from stream.</returns>
        public static double[] ReadFloat64(this Stream stream, int count, Endianness endianness)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = stream.ReadFloat64(endianness);
            }

            return result;
        }

        /// <summary>
        /// Reads multiple doubles from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="count">The amount of doubles.</param>
        /// <returns>An array of doubles read from stream.</returns>
        public static double[] ReadFloat64(this Stream stream, int count)
            => stream.ReadFloat64(count, ByteConverter.Endianness);

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
        public static void Write(this Stream stream, ushort value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes unsigned short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned short to write to the stream.</param>
        public static void Write(this Stream stream, ushort value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes unsigned shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned shorts to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ushort[] values, Endianness endianness)
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
        /// Writes unsigned shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned shorts to write to the stream.</param>
        public static void Write(this Stream stream, ushort[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed short to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes signed short to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed short to write to the stream.</param>
        public static void Write(this Stream stream, short value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed shorts to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, short[] values, Endianness endianness)
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
        /// Writes signed shorts to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed shorts to write to the stream.</param>
        public static void Write(this Stream stream, short[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes unsigned integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned integer to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes unsigned integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned integer to write to the stream.</param>
        public static void Write(this Stream stream, uint value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes unsigned integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned integers to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, uint[] values, Endianness endianness)
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
        /// Writes unsigned integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned integers to write to the stream.</param>
        public static void Write(this Stream stream, uint[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed integer to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes signed integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed integer to write to the stream.</param>
        public static void Write(this Stream stream, int value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed integers to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, int[] values, Endianness endianness)
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
        /// Writes signed integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed integers to write to the stream.</param>
        public static void Write(this Stream stream, int[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes unsigned long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes unsigned long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Unsigned long to write to the stream.</param>
        public static void Write(this Stream stream, ulong value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes unsigned longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, ulong[] values, Endianness endianness)
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
        /// Writes unsigned longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Unsigned longs to write to the stream.</param>
        public static void Write(this Stream stream, ulong[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes signed long to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        public static void Write(this Stream stream, long value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes signed longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, long[] values, Endianness endianness)
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

        /// <summary>
        /// Writes signed longs to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        public static void Write(this Stream stream, long[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes a big integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Big integer to write to the stream.</param>
        /// <param name="size">The number of bytes the big integer should take.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, BigInteger value, int size, Endianness endianness)
            => stream.Write(value.GetBytes(size, endianness));

        /// <summary>
        /// Writes a big integer to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Big integer to write to the stream.</param>
        /// <param name="size">The number of bytes the big integer should take.</param>
        public static void Write(this Stream stream, BigInteger value, int size)
            => stream.Write(value, size, ByteConverter.Endianness);

        /// <summary>
        /// Writes multiple big integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Big integers to write to the stream.</param>
        /// <param name="size">The number of bytes a big integer should take.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, BigInteger[] values, int size, Endianness endianness)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (BigInteger value in values)
            {
                stream.Write(value, size, endianness);
            }
        }

        /// <summary>
        /// Writes multiple big integers to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Big integers to write to the stream.</param>
        /// <param name="size">The number of bytes a big integer should take.</param>
        public static void Write(this Stream stream, BigInteger[] values, int size)
            => stream.Write(values, size, ByteConverter.Endianness);

        /// <summary>
        /// Writes float to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, float value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes float to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        public static void Write(this Stream stream, float value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes float to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, float[] values, Endianness endianness)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (float value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes float to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        public static void Write(this Stream stream, float[] values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Writes double to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, double value, Endianness endianness)
            => stream.Write(value.GetBytes(endianness));

        /// <summary>
        /// Writes double to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed long to write to the stream.</param>
        public static void Write(this Stream stream, double value)
            => stream.Write(value, ByteConverter.Endianness);

        /// <summary>
        /// Writes doubles to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        /// <param name="endianness">Decides whether to write the value as big endian or little endian.</param>
        public static void Write(this Stream stream, double[] values, Endianness endianness)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (double value in values)
            {
                stream.Write(value, endianness);
            }
        }

        /// <summary>
        /// Writes doubles to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed longs to write to the stream.</param>
        public static void Write(this Stream stream, double[] values)
            => stream.Write(values, ByteConverter.Endianness);
    }
}
