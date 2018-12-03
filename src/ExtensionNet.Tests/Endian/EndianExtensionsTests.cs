using ExtensionNet.Endian;
using Xunit;

using static AssertNet.Xunit.Assertions;

namespace ExtensionNet.Tests.Endian
{
    /// <summary>
    /// Test class for the <see cref="EndianExtensions"/> class.
    /// </summary>
    public static class EndianExtensionsTests
    {
        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void Int16ChangeEndiannessTest()
            => AssertThat(((short)-234).ChangeEndianness()).IsEqualTo(5887);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void UInt16ChangeEndiannessTest()
            => AssertThat(((ushort)67).ChangeEndianness()).IsEqualTo(17152);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void Int32ChangeEndiannessTest()
            => AssertThat(((int)-78).ChangeEndianness()).IsEqualTo(-1291845633);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void UInt32ChangeEndiannessTest()
            => AssertThat(((uint)34).ChangeEndianness()).IsEqualTo(570425344);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void Int64ChangeEndiannessTest()
            => AssertThat(((long)128).ChangeEndianness()).IsEqualTo((long)1 << 63);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void UInt64ChangeEndiannessTest()
            => AssertThat(((ulong)128).ChangeEndianness()).IsEqualTo((ulong)1 << 63);
    }
}
