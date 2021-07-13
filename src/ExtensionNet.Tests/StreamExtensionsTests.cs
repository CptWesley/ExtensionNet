using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

using static AssertNet.Assertions;

namespace ExtensionNet.Tests
{
    /// <summary>
    /// Test class for the <see cref="StreamExtensions"/> class.
    /// </summary>
    public sealed class StreamExtensionsTests : IDisposable
    {
        private readonly Stream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamExtensionsTests"/> class.
        /// </summary>
        public StreamExtensionsTests()
            => stream = new MemoryStream();

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadCharTest()
        {
            char[] values = new char[] { 'b', 'c' };
            stream.Write('a');
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadChar()).IsEqualTo('a');
            AssertThat(stream.ReadChar(2)).ContainsExactly('b', 'c');
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadStringTest()
        {
            stream.Write("hello world");
            stream.Position = 0;
            AssertThat(stream.ReadString(4)).IsEqualTo("hell");
            AssertThat(stream.ReadString()).IsEqualTo("o world");
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt8Test()
        {
            byte[] values = new byte[] { 33, 34 };
            stream.Write((byte)32);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt8()).IsEqualTo(32);
            AssertThat(stream.ReadUInt8(2)).ContainsExactly(33, 34);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt8Test()
        {
            sbyte[] values = new sbyte[] { 23, -6 };
            stream.Write((sbyte)33);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt8()).IsEqualTo(33);
            AssertThat(stream.ReadInt8(2)).ContainsExactly(23, -6);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt16Test()
        {
            ushort[] values = new ushort[] { 70, 81 };
            stream.Write((ushort)69);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt16()).IsEqualTo(69);
            AssertThat(stream.ReadUInt16(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt16Test()
        {
            short[] values = new short[] { 432, -56 };
            stream.Write((short)-9);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt16()).IsEqualTo(-9);
            AssertThat(stream.ReadInt16(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt32Test()
        {
            uint[] values = new uint[] { 70, 81 };
            stream.Write(69u);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt32()).IsEqualTo(69);
            AssertThat(stream.ReadUInt32(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt32Test()
        {
            int[] values = new int[] { 432, -56 };
            stream.Write(-9);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt32()).IsEqualTo(-9);
            AssertThat(stream.ReadInt32(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadUInt64Test()
        {
            ulong[] values = new ulong[] { 70, 81 };
            stream.Write(69UL);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadUInt64()).IsEqualTo(69);
            AssertThat(stream.ReadUInt64(2)).ContainsExactly(70, 81);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadInt64Test()
        {
            long[] values = new long[] { 432, -56 };
            stream.Write(-9L);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadInt64()).IsEqualTo(-9);
            AssertThat(stream.ReadInt64(2)).ContainsExactly(432, -56);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadBigIntegerTest()
        {
            BigInteger[] values = new BigInteger[] { 432, 56 };
            stream.Write(new BigInteger(9), 64);
            stream.Write(values, 64);
            stream.Position = 0;
            AssertThat(stream.ReadBigInteger(64)).IsEqualTo(new BigInteger(9));
            AssertThat(stream.ReadBigInteger(64, 2)).ContainsExactly(new BigInteger(432), new BigInteger(56));
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadFloat32Test()
        {
            float[] values = new float[] { 432f, -56f, 1.5f };
            stream.Write(-9f);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadFloat32()).IsEqualTo(-9);
            AssertThat(stream.ReadFloat32(3)).ContainsExactly(432, -56, 1.5f);
        }

        /// <summary>
        /// Checks that the method returns the right value.
        /// </summary>
        [Fact]
        public void ReadFloat64Test()
        {
            double[] values = new double[] { 432d, -56d, 1.5d };
            stream.Write(-9d);
            stream.Write(values);
            stream.Position = 0;
            AssertThat(stream.ReadFloat64()).IsEqualTo(-9);
            AssertThat(stream.ReadFloat64(3)).ContainsExactly(432, -56, 1.5f);
        }

        /// <summary>
        /// Checks that endianness matters.
        /// </summary>
        [Fact]
        public void EndiannessTest()
        {
            long value = 43562456343564356;
            stream.Write(value, Endianness.BigEndian);
            stream.Position = 0;
            AssertThat(stream.ReadInt64(Endianness.LittleEndian)).IsNotEqualTo(value);
            stream.Position = 0;
            AssertThat(stream.ReadInt64(Endianness.BigEndian)).IsEqualTo(value);
        }

        /// <summary>
        /// Checks that all exceptions are correctly thrown.
        /// </summary>
        [Fact]
        public void NullExceptionTest()
        {
            AssertThat(() => StreamExtensions.Write(stream, (byte[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((sbyte[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((ushort[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((short[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((char[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((uint[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((int[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((long[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((ulong[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write(null, 64)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((float[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((double[])null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write((string)null)).ThrowsExactlyException<ArgumentNullException>();

            AssertThat(() => stream.ReadString(null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.ReadString(64, null)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream.Write(string.Empty, null)).ThrowsExactlyException<ArgumentNullException>();

            Stream stream2 = null;
            AssertThat(() => StreamExtensions.Write(stream2, new byte[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new sbyte[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new ushort[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new short[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new char[] { 'a' })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new uint[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new int[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new long[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new ulong[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new BigInteger[] { new BigInteger(0) }, 64)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new float[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new double[] { 0 })).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(string.Empty)).ThrowsExactlyException<ArgumentNullException>();

            AssertThat(() => stream2.Write((byte)0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write((sbyte)0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write((ushort)0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write((short)0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write((char)0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0u)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0L)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0UL)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(new BigInteger(0), 64)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0f)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.Write(0d)).ThrowsExactlyException<ArgumentNullException>();

            AssertThat(() => stream2.ReadUInt8()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadInt8()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadUInt16()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadInt16()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadUInt32()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadInt32()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadUInt64()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadInt64()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadFloat32()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadFloat64()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadBigInteger(64)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadChar()).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadString(64)).ThrowsExactlyException<ArgumentNullException>();
            AssertThat(() => stream2.ReadString()).ThrowsExactlyException<ArgumentNullException>();
        }

        /// <summary>
        /// Checks that converting things to streams works correctly.
        /// </summary>
        [Fact]
        public void ToStreamTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.ReadAllBytes()).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array asynchronously works correctly.
        /// </summary>
        [Fact]
        public void ReadAllBytesAsyncTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.ReadAllBytesAsync().Result).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array asynchronously works correctly.
        /// </summary>
        [Fact]
        public void ReadAllBytesAsyncCancelledTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            AssertThat(() => stream.ReadAllBytesAsync(cts.Token).Wait()).ThrowsExactlyException<AggregateException>().WithInnerException<TaskCanceledException>();
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array works correctly when the buffer is bigger.
        /// </summary>
        [Fact]
        public void ReadFullTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.Read()).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array works correctly when the buffer is smaller.
        /// </summary>
        [Fact]
        public void ReadPartialTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.Read(2)).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array works correctly when the buffer is bigger.
        /// </summary>
        [Fact]
        public void ReadAsyncFullTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.ReadAsync().Result).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array works correctly when the buffer is smaller.
        /// </summary>
        [Fact]
        public void ReadAsyncPartialTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            AssertThat(stream.ReadAsync(2).Result).ContainsExactly(values.Skip(1));
        }

        /// <summary>
        /// Checks that reading an entire stream to a byte array asynchronously works correctly.
        /// </summary>
        [Fact]
        public void ReadAsyncCancelledTest()
        {
            byte[] values = new byte[] { 43, 24, 255, 0, 2 };
            using Stream stream = values.ToStream();
            AssertThat(stream.ReadUInt8()).IsEqualTo(43);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            AssertThat(() => stream.ReadAsync(cts.Token).Wait()).ThrowsExactlyException<AggregateException>().WithInnerException<TaskCanceledException>();
        }

        /// <summary>
        /// Checks that we return from reading when the stream isn't open yet.
        /// </summary>
        [Fact]
        public void IntermediateRead()
        {
            byte[] s1 = new byte[] { 1, 2, 3 };
            byte[] s2 = new byte[] { 4, 5, 6 };
            stream.Write(s1);
            stream.Flush();
            stream.Position = 0;
            AssertThat(stream.Read()).ContainsExactly(s1);
            stream.Write(s2);
            stream.Flush();
            stream.Position = 3;
            AssertThat(stream.Read()).ContainsExactly(s2);
            stream.Close();
            AssertThat(stream.Read()).IsEmpty();
        }

        /// <summary>
        /// Checks that strings are by default null-terminated.
        /// </summary>
        [Fact]
        public void NullTerminatedStrings()
        {
            string s1 = "Hello ";
            string s2 = "World!";
            stream.Write(s1);
            stream.Write(s2);
            stream.Position = 0;
            AssertThat(stream.ReadString()).IsEqualTo(s1);
            AssertThat(stream.ReadString()).IsEqualTo(s2);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
            => stream.Dispose();
    }
}
