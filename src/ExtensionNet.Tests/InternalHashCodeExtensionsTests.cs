﻿using System;
using Xunit;
using static AssertNet.Assertions;

namespace ExtensionNet.Tests
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
        public static void NullTest()
        {
            AssertThat(((object)null).GetInternalHashCode(true)).IsEqualTo(0);
        }

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

        /// <summary>
        /// Checks that deep hashcodes are correct.
        /// </summary>
        [Fact]
        public static void CircularDeepTest()
        {
            DummyClasses.CircularClass a = new DummyClasses.CircularClass();
            DummyClasses.CircularClass b = new DummyClasses.CircularClass();
            a.Reference = b;
            b.Reference = a;

            DummyClasses.CircularClass c = a.Copy(true);

            AssertThat(a.GetInternalHashCode(true)).IsEqualTo(c.GetInternalHashCode(true));
            c.Reference = a;
            AssertThat(a.GetInternalHashCode(true)).IsNotEqualTo(c.GetInternalHashCode(true));

            a.Reference = null;
            c.Reference = null;
            AssertThat(a.GetInternalHashCode(true)).IsEqualTo(c.GetInternalHashCode(true));
        }

        /// <summary>
        /// Checks that we don't go into an infinite loop if we use this function to override hashcode functions.
        /// </summary>
        [Fact]
        public static void GetHashCodeOverrideTest()
        {
            DummyClasses.OverriddenClass a = new DummyClasses.OverriddenClass();
            AssertThat(a).HasSameHashCodeAs(a);
        }
    }
}
