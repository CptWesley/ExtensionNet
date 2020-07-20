using Xunit;

using static AssertNet.Assertions;

namespace ExtensionNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="NumericExtensions"/> class.
    /// </summary>
    public static class NumericExtensionsTests
    {
        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void ShortToBytesTest()
        {
            AssertThat(((short)19).GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 19 });
            AssertThat(((short)44).GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 0 });
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void UShortToBytesTest()
        {
            AssertThat(((ushort)45).GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 45 });
            AssertThat(((ushort)34).GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 34, 0 });
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void IntToBytesTest()
        {
            AssertThat(513.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 2, 1 });
            AssertThat(300.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0 });
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void UIntToBytesTest()
        {
            AssertThat(513u.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 2, 1 });
            AssertThat(300u.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0 });
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void LongToBytesTest()
        {
            AssertThat(513L.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 0, 0, 0, 0, 2, 1 });
            AssertThat(300L.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0, 0, 0, 0, 0 });
        }

        /// <summary>
        /// Checks that the ToBytes method functions correctly.
        /// </summary>
        [Fact]
        public static void ULongToBytesTest()
        {
            AssertThat(513UL.GetBytes(Endianness.BigEndian)).ContainsExactly(new byte[] { 0, 0, 0, 0, 0, 0, 2, 1 });
            AssertThat(300UL.GetBytes(Endianness.LittleEndian)).ContainsExactly(new byte[] { 44, 1, 0, 0, 0, 0, 0, 0 });
        }
    }
}
