using System;
using System.Numerics;
using Xunit;

using static AssertNet.Assertions;

namespace ExtensionNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="ByteConverter"/> class.
    /// </summary>
    public static class ByteConverterTests
    {
        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void ShortToBytesTest()
        {
            AssertThat(((short)19).GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 19 });
            AssertThat(((short)44).GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 0 });
            AssertThat(((short)-32).GetBytes().ToInt16()).IsEqualTo(-32);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void UnsignedShortToBytesTest()
        {
            AssertThat(((ushort)45).GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 45 });
            AssertThat(((ushort)34).GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 34, 0 });
            AssertThat(((ushort)32).GetBytes().ToUInt16()).IsEqualTo(32);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void IntToBytesTest()
        {
            AssertThat(513.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 2, 1 });
            AssertThat(300.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0 });
            AssertThat(-32.GetBytes().ToInt32()).IsEqualTo(-32);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void UnsignedIntToBytesTest()
        {
            AssertThat(513u.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 2, 1 });
            AssertThat(300u.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0 });
            AssertThat(32u.GetBytes().ToUInt32()).IsEqualTo(32u);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void LongToBytesTest()
        {
            AssertThat(513L.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 0, 0, 0, 0, 2, 1 });
            AssertThat(300L.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0, 0, 0, 0, 0 });
            AssertThat(-32L.GetBytes().ToInt64()).IsEqualTo(-32L);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void UnsignedLongToBytesTest()
        {
            AssertThat(513UL.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 0, 0, 0, 0, 2, 1 });
            AssertThat(300UL.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0, 0, 0, 0, 0 });
            AssertThat(32UL.GetBytes().ToUInt64()).IsEqualTo(32UL);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void FloatToBytesTest()
        {
            AssertThat(513f.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 68, 0, 64, 0 });
            AssertThat(513f.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 0, 64, 0, 68 });
            AssertThat(1.5f.GetBytes().ToFloat32()).IsEqualTo(1.5f);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void DoubleToBytesTest()
        {
            AssertThat(513d.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 64, 128, 8, 0, 0, 0, 0, 0 });
            AssertThat(513d.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 0, 0, 0, 0, 0, 8, 128, 64 });
            AssertThat(1.5d.GetBytes().ToFloat64()).IsEqualTo(1.5d);
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void BigIntegerTest()
        {
            BigInteger value = new BigInteger(int.MaxValue) * new BigInteger(int.MaxValue);
            AssertThat(value.GetBytes(Endianness.BigEndian).ToBigInteger(Endianness.BigEndian)).IsEqualTo(value);
            AssertThat(value.GetBytes(Endianness.LittleEndian).ToBigInteger(Endianness.LittleEndian)).IsEqualTo(value);
            AssertThat(value.GetBytes().ToBigInteger()).IsEqualTo(value);
            AssertThat(value.GetBytes(2048, Endianness.BigEndian).ToBigInteger(Endianness.BigEndian)).IsEqualTo(value);
            AssertThat(value.GetBytes(2048, Endianness.LittleEndian).ToBigInteger(Endianness.LittleEndian)).IsEqualTo(value);
            AssertThat(value.GetBytes(2048).ToBigInteger()).IsEqualTo(value);

            AssertThat(() => value.GetBytes(-1)).ThrowsExactlyException<ArgumentException>();
            AssertThat(() => new BigInteger(-1).GetBytes(2048)).ThrowsExactlyException<ArgumentException>();
        }
    }
}
