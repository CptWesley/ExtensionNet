﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ExtensionNet
{
    /// <summary>
    /// Extension class for the <see cref="Stream"/> class.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// The default buffer size.
        /// </summary>
        public const int DefaultBufferSize = 4096;

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
            => stream.ReadString(Encoding.Default);

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <returns>First char on the stream.</returns>
        public static string ReadString(this Stream stream, Encoding encoding)
        {
            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            List<byte> bytes = new List<byte>();

            byte b;
            while ((b = stream.ReadUInt8()) != 0)
            {
                bytes.Add(b);
            }

            return encoding.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Reads a string from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The amount of chars.</param>
        /// <returns>A string read from stream.</returns>
        public static string ReadString(this Stream stream, int size)
            => stream.ReadString(size, Encoding.Default);

        /// <summary>
        /// Reads a string from stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="size">The amount of chars.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <returns>A string read from stream.</returns>
        public static string ReadString(this Stream stream, int size, Encoding encoding)
        {
            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            return encoding.GetString(stream.ReadUInt8(size));
        }

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
            => stream.Write(value, Encoding.Default);

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">String to write to stream.</param>
        /// <param name="nullTerminated">Indicates whether the string is null terminated.</param>
        public static void Write(this Stream stream, string value, bool nullTerminated)
            => stream.Write(value, Encoding.Default, nullTerminated);

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">String to write to stream.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <param name="nullTerminated">Indicates whether the string is null terminated.</param>
        public static void Write(this Stream stream, string value, Encoding encoding, bool nullTerminated)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            stream.Write(encoding.GetBytes(value));

            if (nullTerminated)
            {
                stream.Write('\0');
            }
        }

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">String to write to stream.</param>
        /// <param name="encoding">The encoding of the string.</param>
        public static void Write(this Stream stream, string value, Encoding encoding)
            => stream.Write(value, encoding, true);

        /// <summary>
        /// Writes a char to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Char to write to the stream.</param>
        public static void Write(this Stream stream, char value)
            => stream.Write((byte)value);

        /// <summary>
        /// Writes chars to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Chars to write to the stream.</param>
        public static void Write(this Stream stream, IEnumerable<char> values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (char value in values)
            {
                stream.Write(value);
            }
        }

        /// <summary>
        /// Writes a byte to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Byte to write to the stream.</param>
        public static void Write(this Stream stream, byte value)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            stream.WriteByte((byte)value);
        }

        /// <summary>
        /// Writes bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Bytes to write to the stream.</param>
        public static void Write(this Stream stream, byte[] values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            stream.Write(values, 0, values.Length);
        }

        /// <summary>
        /// Writes bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Bytes to write to the stream.</param>
        public static void Write(this Stream stream, IEnumerable<byte> values)
            => stream.Write(values.ToArray());

        /// <summary>
        /// Writes a signed byte to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">Signed byte to write to the stream.</param>
        public static void Write(this Stream stream, sbyte value)
            => stream.Write((byte)value);

        /// <summary>
        /// Writes signed bytes to the stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="values">Signed bytes to write to the stream.</param>
        public static void Write(this Stream stream, IEnumerable<sbyte> values)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (sbyte value in values)
            {
                stream.Write(value);
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
        public static void Write(this Stream stream, IEnumerable<ushort> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<ushort> values)
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
        public static void Write(this Stream stream, IEnumerable<short> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<short> values)
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
        public static void Write(this Stream stream, IEnumerable<uint> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<uint> values)
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
        public static void Write(this Stream stream, IEnumerable<int> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<int> values)
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
        public static void Write(this Stream stream, IEnumerable<ulong> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<ulong> values)
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
        public static void Write(this Stream stream, IEnumerable<long> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<long> values)
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
        public static void Write(this Stream stream, IEnumerable<BigInteger> values, int size, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<BigInteger> values, int size)
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
        public static void Write(this Stream stream, IEnumerable<float> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<float> values)
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
        public static void Write(this Stream stream, IEnumerable<double> values, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

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
        public static void Write(this Stream stream, IEnumerable<double> values)
            => stream.Write(values, ByteConverter.Endianness);

        /// <summary>
        /// Reads the remaining bytes of the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The remaining bytes of the stream.</returns>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Reads the remaining bytes of the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>The remaining bytes of the stream.</returns>
        public static Task<byte[]> ReadAllBytesAsync(this Stream stream)
            => stream.ReadAllBytesAsync(CancellationToken.None);

        /// <summary>
        /// Reads the remaining bytes of the stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The remaining bytes of the stream.</returns>
        public static async Task<byte[]> ReadAllBytesAsync(this Stream stream, CancellationToken ct)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using (MemoryStream ms = new MemoryStream())
            {
                Task ctTask = ct.Task();
                Task finished = await Task.WhenAny(ctTask, stream.CopyToAsync(ms)).ConfigureAwait(false);
                if (finished == ctTask)
                {
                    ct.ThrowIfCancellationRequested();
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Converts a byte array to a stream.
        /// </summary>
        /// <param name="bytes">The bytes contained in the stream.</param>
        /// <returns>The newly created stream.</returns>
        public static Stream ToStream(this byte[] bytes)
            => new MemoryStream(bytes);

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize">The buffer size. Must be positive integer.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static byte[] Read(this Stream stream, int bufferSize)
        {
            if (bufferSize <= 0)
            {
                throw new ArgumentException("Buffer size must be positive.", nameof(bufferSize));
            }

            List<byte> bytes = new List<byte>();
            byte[] buffer = new byte[bufferSize];
            int read = 0;
            while (stream.CanRead && (read != 0 || bytes.Count == 0))
            {
                read = stream.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < read; i++)
                {
                    bytes.Add(buffer[i]);
                }
            }

            return bytes.ToArray();
        }

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static byte[] Read(this Stream stream)
            => stream.Read(DefaultBufferSize);

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize">The buffer size. Must be positive integer.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static async Task<byte[]> ReadAsync(this Stream stream, int bufferSize, CancellationToken ct)
        {
            if (bufferSize <= 0)
            {
                throw new ArgumentException("Buffer size must be positive.", nameof(bufferSize));
            }

            List<byte> bytes = new List<byte>();
            byte[] buffer = new byte[bufferSize];
            int read = 0;
            while (stream.CanRead && (read != 0 || bytes.Count == 0))
            {
                read = await stream.ReadAsync(buffer, 0, buffer.Length, ct).ConfigureAwait(false);

                for (int i = 0; i < read; i++)
                {
                    bytes.Add(buffer[i]);
                }
            }

            return bytes.ToArray();
        }

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static Task<byte[]> ReadAsync(this Stream stream, CancellationToken ct)
            => stream.ReadAsync(DefaultBufferSize, ct);

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize">The size of the buffer to be used.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static Task<byte[]> ReadAsync(this Stream stream, int bufferSize)
            => stream.ReadAsync(bufferSize, CancellationToken.None);

        /// <summary>
        /// Reads the currently available bytes from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The bytes currently available from the stream.</returns>
        public static Task<byte[]> ReadAsync(this Stream stream)
            => stream.ReadAsync(DefaultBufferSize);

        /// <summary>
        /// Writes the object in JSON format to the stream as a null-terminated string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="obj">The object.</param>
        public static void WriteJson(this Stream stream, object obj)
            => stream.Write(JsonSerializer.Serialize(obj));

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns>The parsed object.</returns>
        public static object? ReadJson(this Stream stream, Type type)
            => JsonSerializer.Deserialize(stream.ReadString(), type);

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>The parsed object.</returns>
        public static T ReadJson<T>(this Stream stream)
            => (T)stream.ReadJson(typeof(T))!;

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>First char on the stream.</returns>
        public static Task<string> ReadStringAsync(this Stream stream, CancellationToken ct)
            => stream.ReadStringAsync(Encoding.Default, ct);

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>First char on the stream.</returns>
        public static async Task<string> ReadStringAsync(this Stream stream, Encoding encoding, CancellationToken ct)
        {
            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            List<byte> bytes = new List<byte>();

            await Task.Run(
                () =>
                {
                    byte b;
                    while ((b = stream.ReadUInt8()) != 0)
                    {
                        bytes.Add(b);
                    }
                },
                ct).ConfigureAwait(false);

            return encoding.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>First char on the stream.</returns>
        public static Task<string> ReadStringAsync(this Stream stream)
            => stream.ReadStringAsync(CancellationToken.None);

        /// <summary>
        /// Reads a single char from the stream.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="encoding">The encoding of the string.</param>
        /// <returns>First char on the stream.</returns>
        public static Task<string> ReadStringAsync(this Stream stream, Encoding encoding)
            => stream.ReadStringAsync(encoding, CancellationToken.None);

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="type">The type of the object.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The parsed object.</returns>
        public static async Task<object?> ReadJsonAsync(this Stream stream, Type type, CancellationToken ct)
            => JsonSerializer.Deserialize(await stream.ReadStringAsync(ct).ConfigureAwait(false), type);

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>The parsed object.</returns>
        public static async Task<T> ReadJsonAsync<T>(this Stream stream, CancellationToken ct)
        {
            object? obj = await stream.ReadJsonAsync(typeof(T), ct).ConfigureAwait(false);
            return (T)obj!;
        }

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns>The parsed object.</returns>
        public static Task<object?> ReadJsonAsync(this Stream stream, Type type)
            => stream.ReadJsonAsync(type, CancellationToken.None);

        /// <summary>
        /// Reads an object in null-terminated JSON format from the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>The parsed object.</returns>
        public static Task<T> ReadJsonAsync<T>(this Stream stream)
            => stream.ReadJsonAsync<T>(CancellationToken.None);
    }
}
