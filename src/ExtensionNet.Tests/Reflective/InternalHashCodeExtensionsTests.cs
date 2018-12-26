using System;
using ExtensionNet.Reflective;
using Xunit;
using static AssertNet.Xunit.Assertions;

namespace ExtensionNet.Tests.Reflective
{
    /// <summary>
    /// Test class for the <see cref="InternalHashCodeExtensionsTests"/> class.
    /// </summary>
    public static class InternalHashCodeExtensionsTests
    {
        /// <summary>
        /// Checks that integers return the right hashcode.
        /// </summary>
        [Fact]
        public static void IntegerTest()
        {
            AssertThat(42.GetInternalHashCode(true)).IsEqualTo(42.GetInternalHashCode(true));
            AssertThat(42.GetInternalHashCode(true)).IsNotEqualTo(44.GetInternalHashCode(true));
        }

        /// <summary>
        /// Checks that strings return the right hashcode.
        /// </summary>
        [Fact]
        public static void StringTest()
        {
            AssertThat("Hello".GetInternalHashCode(true)).IsEqualTo("Hello".GetInternalHashCode(true));
            AssertThat("Hello".GetInternalHashCode(true)).IsNotEqualTo("Bye".GetInternalHashCode(true));
        }

        /// <summary>
        /// Checks that a more complex class returns the right hashcode.
        /// </summary>
        [Fact]
        public static void ComplexTest()
        {
            Random a = new Random();
            Random b = a.Copy(true);

            AssertThat(a.GetInternalHashCode(true)).IsEqualTo(b.GetInternalHashCode(true));
        }

        /// <summary>
        /// Checks that shallow hashcodes are correct.
        /// </summary>
        [Fact]
        public static void CircularShallowTest()
        {
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            a.Reference = b;
            b.Reference = a;

            DummyClasses.CircularClass c = a.Copy(false);

            AssertThat(a.GetInternalHashCode(false)).IsEqualTo(c.GetInternalHashCode(false));
            c.Reference = a;
            AssertThat(a.GetInternalHashCode(false)).IsNotEqualTo(c.GetInternalHashCode(false));
        }
    }
}
