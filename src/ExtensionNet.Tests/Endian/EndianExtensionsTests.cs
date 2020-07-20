using ExtensionNet.Endian;
using Xunit;

using static AssertNet.Assertions;

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
            => AssertThat((-78).ChangeEndianness()).IsEqualTo(-1291845633);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void UInt32ChangeEndiannessTest()
            => AssertThat(34U.ChangeEndianness()).IsEqualTo(570425344);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void Int64ChangeEndiannessTest()
            => AssertThat(128L.ChangeEndianness()).IsEqualTo(1L << 63);

        /// <summary>
        /// Checks that we can correctly invert the endianness of the value.
        /// </summary>
        [Fact]
        public static void UInt64ChangeEndiannessTest()
            => AssertThat(128UL.ChangeEndianness()).IsEqualTo(1UL << 63);
    }
}
