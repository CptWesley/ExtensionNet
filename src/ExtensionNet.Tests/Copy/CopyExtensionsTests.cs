using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ExtensionNet.Copy;
using Xunit;

using static AssertNet.Xunit.Assertions;

namespace ExtensionNet.Tests.Copy
{
    /// <summary>
    /// Test class for the <see cref="CopyExtensions"/> class.
    /// </summary>
    public static class CopyExtensionsTests
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

        /// <summary>
        /// Checks that we can create a copy of an integer.
        /// </summary>
        [Fact]
        public static void IntegerTest()
        {
            int num = 42;
            AssertThat(num.Copy()).IsEqualTo(num);
        }

        /// <summary>
        /// Checks that we can create a shallow copy of an array.
        /// </summary>
        [Fact]
        public static void ArrayShallowTest()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder[] arr = new[] { sb };
            AssertThat(arr.Copy(false)[0]).IsNotNull().IsSameAs(sb);
        }

        /// <summary>
        /// Checks that we can create a deep copy of an array.
        /// </summary>
        [Fact]
        public static void ArrayDeepTest()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder[] arr = new[] { sb };
            AssertThat(arr.Copy(true)[0]).IsNotSameAs(sb);
        }

        /// <summary>
        /// Checks that we can create a deep copy of a complex object.
        /// </summary>
        [Fact]
        public static void ComplexClassTest()
        {
            Random rnd1 = new Random();
            Random rnd2 = rnd1.Copy(true);
            AssertThat(rnd1.Next()).IsEqualTo(rnd2.Next());
        }

        /// <summary>
        /// Checks that circular references get handled correctly.
        /// </summary>
        [Fact]
        public static void CircularReferenceTest()
        {
            CircularClass a = new CircularClass();
            CircularClass b = new CircularClass();
            a.Reference = b;
            b.Reference = a;
            CircularClass ac = a.Copy(true);
            AssertThat(ac.Reference.Reference).IsSameAs(ac);
        }

        /// <summary>
        /// Checks that inheritance works correctly.
        /// </summary>
        [Fact]
        public static void InheritanceTest()
        {
            SonClass son = new SonClass();
            son.PublicValue = 42;
            son.SetPrivateValue(1337);
            son.SonValue = 50;
            SonClass copy = son.Copy(true);
            AssertThat(copy.SonValue).IsEqualTo(50);
            AssertThat(copy.PublicValue).IsEqualTo(42);
            AssertThat(copy.GetPrivateValue()).IsEqualTo(1337);
        }

        /// <summary>
        /// Class containing circular reference for testing purposes.
        /// </summary>
        protected class CircularClass
        {
            /// <summary>
            /// Gets or sets the reference.
            /// </summary>
            /// <value>
            /// The reference.
            /// </value>
            public CircularClass Reference { get; set; }
        }

        /// <summary>
        /// Class allowing inheritance.
        /// </summary>
        protected class FatherClass
        {
            /// <summary>
            /// Gets or sets the public value.
            /// </summary>
            [SuppressMessage("Design", "CA1051", Justification = "Needed for testing.")]
            [SuppressMessage("MaintainabilityRules", "SA1401", Justification = "Needed for testing.")]
            public int PublicValue;

            /// <summary>
            /// Gets or sets the private value.
            /// </summary>
            private int privateValue;

            /// <summary>
            /// Sets the private value.
            /// </summary>
            /// <param name="value">The value.</param>
            public void SetPrivateValue(int value)
                => privateValue = value;

            /// <summary>
            /// Gets the private value.
            /// </summary>
            /// <returns>The private value.</returns>
            [SuppressMessage("Design", "CA1024", Justification = "Needed for testing.")]
            public int GetPrivateValue()
                => privateValue;
        }

        /// <summary>
        /// Class inheriting from something else.
        /// </summary>
        protected class SonClass : FatherClass
        {
            /// <summary>
            /// Gets or sets the son value.
            /// </summary>
            public int SonValue { get; set; }
        }
    }
}
