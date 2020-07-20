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
            char[] values = new char[] { 'a', 'b', 'c' };
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
            byte[] values = new byte[] { 32, 33, 34 };
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
            sbyte[] values = new sbyte[] { 33, 23, -6 };
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
            ushort[] values = new ushort[] { 69, 70, 81 };
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
            short[] values = new short[] { -9, 432, -56 };
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
            uint[] values = new uint[] { 69, 70, 81 };
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
            int[] values = new int[] { -9, 432, -56 };
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
            ulong[] values = new ulong[] { 69, 70, 81 };
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
            long[] values = new long[] { -9, 432, -56 };
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
            BigInteger[] values = new BigInteger[] { 9, 432, 56 };
            stream.Write(values, 64);
            stream.Position = 0;
            AssertThat(stream.ReadBigInteger(64)).IsEqualTo(new BigInteger(9));
            AssertThat(stream.ReadBigInteger(64, 2)).ContainsExactly(new BigInteger(432), new BigInteger(56));
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
