using System;
using System.IO;
using System.Numerics;
using Xunit;

using static AssertNet.Assertions;

namespace ExtensionNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="StreamExtensions"/> class.
    /// </summary>
    public sealed class StreamExtensionsTests : IDisposable
    {
        private readonly Stream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamExtensionsTests"/> class.
        /// </summary>
        public StreamExtensionsTests()
            => stream = new MemoryStream();

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadCharTest()
        {
            char[] values = new char[] { 'b', 'c' };
            stream.Write('a');
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadChar()).IsEqualTo('a');
            AssertThat(stream.ReadChar(2)).ContainsExactly('b', 'c');
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadStringTest()
        {
            stream.Write("hello world");
            stream.Position = 0;
            AssertThat(stream.ReadString()).IsEqualTo("h");
            AssertThat(stream.ReadString(4)).IsEqualTo("ello");
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt8Test()
        {
            byte[] values = new byte[] { 33, 34 };
            stream.Write((byte)32);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt8()).IsEqualTo(32);
            AssertThat(stream.ReadUInt8(2)).ContainsExactly(33, 34);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt8Test()
        {
            sbyte[] values = new sbyte[] { 23, -6 };
            stream.Write((sbyte)33);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt8()).IsEqualTo(33);
            AssertThat(stream.ReadInt8(2)).ContainsExactly(23, -6);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt16Test()
        {
            ushort[] values = new ushort[] { 70, 81 };
            stream.Write((ushort)69);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt16()).IsEqualTo(69);
            AssertThat(stream.ReadUInt16(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt16Test()
        {
            short[] values = new short[] { 432, -56 };
            stream.Write((short)-9);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt16()).IsEqualTo(-9);
            AssertThat(stream.ReadInt16(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt32Test()
        {
            uint[] values = new uint[] { 70, 81 };
            stream.Write(69u);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt32()).IsEqualTo(69);
            AssertThat(stream.ReadUInt32(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt32Test()
        {
            int[] values = new int[] { 432, -56 };
            stream.Write(-9);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt32()).IsEqualTo(-9);
            AssertThat(stream.ReadInt32(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt64Test()
        {
            ulong[] values = new ulong[] { 70, 81 };
            stream.Write(69UL);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt64()).IsEqualTo(69);
            AssertThat(stream.ReadUInt64(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt64Test()
        {
            long[] values = new long[] { 432, -56 };
            stream.Write(-9L);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt64()).IsEqualTo(-9);
            AssertThat(stream.ReadInt64(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadBigIntegerTest()
        {
            BigInteger[] values = new BigInteger[] { 432, 56 };
            stream.Write(new BigInteger(9), 64);
            stream.Write(values, 64);
            stream.Position = 0;
            AssertThat(stream.ReadBigInteger(64)).IsEqualTo(new BigInteger(9));
            AssertThat(stream.ReadBigInteger(64, 2)).ContainsExactly(new BigInteger(432), new BigInteger(56));
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadFloat32Test()
        {
            float[] values = new float[] { 432f, -56f, 1.5f };
            stream.Write(-9f);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadFloat32()).IsEqualTo(-9);
            AssertThat(stream.ReadFloat32(3)).ContainsExactly(432, -56, 1.5f);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadFloat64Test()
        {
            double[] values = new double[] { 432d, -56d, 1.5d };
            stream.Write(-9d);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadFloat64()).IsEqualTo(-9);
            AssertThat(stream.ReadFloat64(3)).ContainsExactly(432, -56, 1.5f);
        }

        /// <summary>
        /// Checks that endianness matters.
        /// </summary>
        [Fact]
        public void EndiannessTest()
        {
            long value = 43562456343564356;
            stream.Write(value, Endianness.BigEndian);
            stream.Position = 0;
            AssertThat(stream.ReadInt64(Endianness.LittleEndian)).IsNotEqualTo(value);
            stream.Position = 0;
            AssertThat(stream.ReadInt64(Endianness.BigEndian)).IsEqualTo(value);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
            => stream.Dispose();
    }
}
