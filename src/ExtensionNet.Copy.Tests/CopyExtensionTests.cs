﻿using System;
using System.Text;
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
    }
}
