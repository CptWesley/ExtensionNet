using System;
using System.Text;
using ExtensionNet.Reflective;
using Xunit;

using static AssertNet.Assertions;

namespace ExtensionNet.Tests.Reflective
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
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            a.Reference = b;
            b.Reference = a;
            DummyClasses.CircularClass ac = a.Copy(true);
            AssertThat(ac.Reference.Reference).IsSameAs(ac);
        }

        /// <summary>
        /// Checks that inheritance works correctly.
        /// </summary>
        [Fact]
        public static void InheritanceTest()
        {
            DummyClasses.SonClass son = new DummyClasses.SonClass();
            son.PublicValue = 42;
            son.SetPrivateValue(1337);
            son.SonValue = 50;
            DummyClasses.SonClass copy = son.Copy(true);
            AssertThat(copy.SonValue).IsEqualTo(50);
            AssertThat(copy.PublicValue).IsEqualTo(42);
            AssertThat(copy.GetPrivateValue()).IsEqualTo(1337);
        }

        /// <summary>
        /// Checks that we can do a shallow copy of structs correctly.
        /// </summary>
        [Fact]
        public static void ShallowStructTest()
        {
            Random rnd = new Random();
            DummyClasses.SomeStruct a = new DummyClasses.SomeStruct()
            {
                Value = 42,
                Random = rnd
            };

            DummyClasses.SomeStruct b = a.Copy(false);
            AssertThat(b).IsSameAs(a);
            AssertThat(b.Value).IsEqualTo(a.Value);
            AssertThat(b.Random).IsSameAs(a.Random);
        }

        /// <summary>
        /// Checks that we can do a deep copy of structs correctly.
        /// </summary>
        [Fact]
        public static void DeepStructTest()
        {
            Random rnd = new Random();
            DummyClasses.SomeStruct a = new DummyClasses.SomeStruct()
            {
                Value = 42,
                Random = rnd
            };

            DummyClasses.SomeStruct b = a.Copy(true);
            AssertThat(b).IsNotSameAs(a);
            AssertThat(b.Value).IsEqualTo(a.Value);
            AssertThat(b.Random).IsNotSameAs(a.Random);
            AssertThat(b.Random.Next()).IsEqualTo(a.Random.Next());
        }
    }
}
