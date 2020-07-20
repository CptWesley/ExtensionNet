using System;
using Xunit;
using static AssertNet.Assertions;

namespace ExtensionNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="InternallyEqualsExtensions"/> class.
    /// </summary>
    public static class InternallyEqualsExtensionsTests
    {
        /// <summary>
        /// Checks that we can correctly find the equalness of integers.
        /// </summary>
        [Fact]
        public static void IntegerTrueTest()
        {
            int val = 42;
            AssertThat(val.InternallyEquals(42)).IsTrue();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of integers.
        /// </summary>
        [Fact]
        public static void IntegerFalseTest()
        {
            int val = 42;
            AssertThat(val.InternallyEquals(43)).IsFalse();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of strings.
        /// </summary>
        [Fact]
        public static void StringTrueTest()
        {
            string val = "Hello world!";
            AssertThat(val.InternallyEquals("Hello world!")).IsTrue();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of strings.
        /// </summary>
        [Fact]
        public static void StringFalseTest()
        {
            string val = "Hello world!";
            AssertThat(val.InternallyEquals("Hello!")).IsFalse();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of nulls.
        /// </summary>
        [Fact]
        public static void NullTrueTest()
        {
            object val = null;
            AssertThat(val.InternallyEquals(null)).IsTrue();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of nulls.
        /// </summary>
        [Fact]
        public static void NullFalseTest()
        {
            object val = null;
            AssertThat(val.InternallyEquals("Hello!")).IsFalse();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of arrays.
        /// </summary>
        [Fact]
        public static void ArrayTrueTest()
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 1, 2, 3 };
            AssertThat(a.InternallyEquals(b)).IsTrue();
        }

        /// <summary>
        /// Checks that we can correctly find the equalness of arrays.
        /// </summary>
        [Fact]
        public static void ArrayFalseTest()
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 1, 2, 4 };
            AssertThat(a.InternallyEquals(b)).IsFalse();
        }

        /// <summary>
        /// Checks that the function works for more complex objects.
        /// </summary>
        [Fact]
        public static void ComplexTest()
        {
            Random a = new Random();
            Random b = a.Copy(true);

            AssertThat(a.InternallyEquals(b, true)).IsTrue();
            b.Next();
            AssertThat(a.InternallyEquals(b, true)).IsFalse();
        }

        /// <summary>
        /// Checks that inheritance works correctly.
        /// </summary>
        [Fact]
        public static void InheritanceTest()
        {
            DummyClasses.SonClass a = new DummyClasses.SonClass
            {
                PublicValue = 42,
            };
            a.SetPrivateValue(1337);
            a.SonValue = 50;
            DummyClasses.SonClass b = a.Copy(true);
            AssertThat(a.InternallyEquals(b, false)).IsTrue();
            AssertThat(a.InternallyEquals(b, true)).IsTrue();
            a.SetPrivateValue(22);
            AssertThat(a.InternallyEquals(b, false)).IsFalse();
            AssertThat(a.InternallyEquals(b, true)).IsFalse();
        }

        /// <summary>
        /// Checks that circular references are handled correctly in shallow comparisons.
        /// </summary>
        [Fact]
        public static void CircularShallowTest()
        {
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            a.Reference = b;
            b.Reference = a;
            DummyClasses.CircularClass c = a.Copy(false);
            AssertThat(a.InternallyEquals(c, false)).IsTrue();
        }

        /// <summary>
        /// Checks that circular references are handled correctly in deep comparisons.
        /// </summary>
        [Fact]
        public static void CircularDeepTest()
        {
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            a.Reference = b;
            b.Reference = a;
            DummyClasses.CircularClass c = a.Copy(false);
            AssertThat(a.InternallyEquals(c, true)).IsTrue();
        }

        /// <summary>
        /// Checks that we can correctly determine deep and shallow equality.
        /// </summary>
        [Fact]
        public static void DeepShallowTest()
        {
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            DummyClasses.CircularClass c = new DummyClasses.CircularClass();
            DummyClasses.CircularClass d = new DummyClasses.CircularClass();

            a.Reference = b;
            c.Reference = b;
            AssertThat(a.InternallyEquals(c, false)).IsTrue();
            c.Reference = d;
            AssertThat(a.InternallyEquals(c, false)).IsFalse();
            AssertThat(a.InternallyEquals(c, true)).IsTrue();
        }

        /// <summary>
        /// Checks that we don't go into an infinite loop if we use this function to override equals.
        /// </summary>
        [Fact]
        public static void EqualsOverrideTest()
        {
            DummyClasses.OverriddenClass a = new DummyClasses.OverriddenClass();
            AssertThat(a).IsEqualTo(a);
        }
    }
}
