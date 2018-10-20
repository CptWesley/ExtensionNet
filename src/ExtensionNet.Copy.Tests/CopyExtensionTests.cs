using Xunit;
using static AssertNet.Xunit.Assertions;

namespace ExtensionNet.Copy.Tests
{
    /// <summary>
    /// Test class for the <see cref="CopyExtension"/> class.
    /// </summary>
    public static class CopyExtensionTests
    {
        /// <summary>
        /// Checks that we can create a copy of a string.
        /// </summary>
        [Fact]
        public static void StringTest()
        {
            string str = "hello world";
            AssertThat(str.Copy()).IsEqualTo(str);
        }
    }
}
