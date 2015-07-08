// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "This should be fixed when we can bring in disposable object. [tgs]")]
    [TestClass]
    public class EncodeDecodeTests
    {
        protected MemoryStream Stream;
        protected IEncoder Encoder;
        protected IDecoder Decoder;
        private Random random;

        [TestInitialize]
        public void TestSetup()
        {
            const int Seed = 13;
            this.Stream = new MemoryStream();
            this.Encoder = this.CreateEncoder(this.Stream);
            this.Decoder = this.CreateDecoder(this.Stream);
            this.random = new Random(Seed);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            this.Stream.Dispose();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_ZeroInt()
        {
            const int Expected = 0;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeInt();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_PositiveInt()
        {
            const int Expected = 105;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeInt();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_NegativeInt()
        {
            const int Expected = -106;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeInt();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_MaxInt()
        {
            const int Expected = int.MaxValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeInt();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_MinInt()
        {
            const int Expected = int.MinValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeInt();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void Decode_InvalidInt()
        {
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            //causes corruption
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0x1);
            this.Stream.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var result = this.Decoder.DecodeInt();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_ZeroLong()
        {
            const long Expected = 0;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeLong();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_PositiveLong()
        {
            const long Expected = 105;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeLong();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_NegativeLong()
        {
            const long Expected = -106;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeLong();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_MaxLong()
        {
            const long Expected = long.MaxValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeLong();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_MinLong()
        {
            const long Expected = long.MinValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeLong();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void Decode_InvalidLong()
        {
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0xFF);
            //causes corruption
            this.Stream.WriteByte(0xFF);
            this.Stream.WriteByte(0x1);
            this.Stream.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var result = this.Decoder.DecodeLong();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void Decode_InvalidLongWithEmptyStream()
        {
            this.Stream.Position = 0;
            this.Decoder.DecodeLong();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_BooleanTrue()
        {
            const bool Expected = true;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeBool();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_BooleanFalse()
        {
            const bool Expected = false;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeBool();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_EmptyByteArray()
        {
            var expected = new byte[] { };
            this.Encoder.Encode(expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeByteArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_NotEmptyByteArray()
        {
            var expected = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            this.Encoder.Encode(expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeByteArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_FloatMax()
        {
            const float Expected = float.MaxValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeFloat();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_FloatMin()
        {
            const float Expected = float.MinValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeFloat();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_DoubleMax()
        {
            const double Expected = double.MaxValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeDouble();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_DoubleMin()
        {
            const double Expected = double.MinValue;
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeDouble();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_EmptyString()
        {
            const string Expected = "";
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeString();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_NotEmptyString()
        {
            const string Expected = "Test string";
            this.Encoder.Encode(Expected);
            this.Encoder.Flush();

            this.Stream.Seek(0, SeekOrigin.Begin);
            var actual = this.Decoder.DecodeString();

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_HundredThousandRandomInts()
        {
            const int NumberOfTests = 100000;
            const int Seed = 13;
            var random = new Random(Seed);

            for (var i = 0; i < NumberOfTests; ++i)
            {
                this.Stream.SetLength(0);

                var expected = random.Next(int.MinValue, int.MaxValue);
                this.Encoder.Encode(expected);
                this.Encoder.Flush();

                this.Stream.Seek(0, SeekOrigin.Begin);
                var actual = this.Decoder.DecodeInt();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_HundredThousandRandomLongs()
        {
            const int NumberOfTests = 100000;
            const int Seed = 13;
            var random = new Random(Seed);

            var buffer = new byte[8];
            for (var i = 0; i < NumberOfTests; ++i)
            {
                random.NextBytes(buffer);
                var expected = BitConverter.ToInt64(buffer, 0);

                this.Stream.SetLength(0);
                this.Encoder.Encode(expected);
                this.Encoder.Flush();

                this.Stream.Seek(0, SeekOrigin.Begin);
                var actual = this.Decoder.DecodeLong();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_DifferentInts()
        {
            var values = new[]
                         {
                             new byte[] { 0, 0, 0, 1 },
                             new byte[] { 0, 0, 1, 0 },
                             new byte[] { 0, 1, 0, 0 },
                             new byte[] { 1, 0, 0, 0 }
                         };

            foreach (var value in values)
            {
                this.Stream.SetLength(0);

                var expected = BitConverter.ToInt32(value, 0);
                this.Encoder.Encode(expected);
                this.Encoder.Flush();

                this.Stream.Seek(0, SeekOrigin.Begin);

                var actual = this.Decoder.DecodeInt();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_DifferentLongs()
        {
            var values = new[]
                         {
                             new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 },
                             new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 },
                             new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 },
                             new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 },
                             new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 },
                             new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 },
                             new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 },
                             new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }
                         };

            foreach (var value in values)
            {
                this.Stream.SetLength(0);

                var expected = BitConverter.ToInt64(value, 0);
                this.Encoder.Encode(expected);
                this.Encoder.Flush();

                this.Stream.Seek(0, SeekOrigin.Begin);

                var actual = this.Decoder.DecodeLong();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_NotEmptyStream()
        {
            var expected = Utilities.GetRandom<byte[]>(false);

            using (var memoryStream = new MemoryStream(expected))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                this.Encoder.Encode(memoryStream);
            }

            this.Stream.Seek(0, SeekOrigin.Begin);

            var actual = this.Decoder.DecodeByteArray();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_Double()
        {
            var valueToSkip = this.random.NextDouble();
            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipDouble());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_Float()
        {
            var valueToSkip = (float)this.random.NextDouble();
            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipFloat());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_Bool()
        {
            var valueToSkip = this.random.Next(0, 100) % 2 == 1;
            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipBool());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_Int()
        {
            var valueToSkip = this.random.Next();
            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipInt());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_Long()
        {
            long valueToSkip = this.random.Next();
            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipLong());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_ByteArray()
        {
            var valueToSkip = new byte[128];
            this.random.NextBytes(valueToSkip);

            this.CheckSkipping(
                e => e.Encode(valueToSkip),
                d => d.SkipByteArray());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Skip_String()
        {
            this.CheckSkipping(
                e => e.Encode("test string" + this.random.Next(0, 100)),
                d => d.SkipString());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encoder_NullByteArray()
        {
            this.Encoder.Encode((byte[])null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encode_NullStream()
        {
            this.Encoder.Encode((Stream)null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encode_NullFixed()
        {
            this.Encoder.EncodeFixed(null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Decode_FixedWithNegativeSize()
        {
            this.Decoder.DecodeFixed(-1);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void Skip_FixedWithNegativeSize()
        {
            this.Decoder.SkipFixed(-1);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encode_NullString()
        {
            this.Encoder.Encode((string)null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void Decode_NotGivingPartialDataFromStream()
        {
            var expected = Utilities.GetRandom<byte[]>(false);

            using (var chunked = new ChunkedStream(this.Stream, 3))
            {
                var encoder = this.CreateEncoder(chunked);
                encoder.Encode(expected);
                encoder.Flush();

                chunked.Seek(0, SeekOrigin.Begin);

                var decoder = this.CreateDecoder(chunked);
                var actual = decoder.DecodeByteArray();

                Assert.IsTrue(expected.SequenceEqual(actual));
            }
        }

        #region Helper methods
        internal virtual IEncoder CreateEncoder(Stream stream)
        {
            return new BinaryEncoder(stream);
        }

        internal virtual IDecoder CreateDecoder(Stream stream)
        {
            return new BinaryDecoder(stream);
        }

        private void CheckSkipping(Action<IEncoder> encode, Action<IDecoder> skip)
        {
            var startGuard = this.random.Next();
            var endGuard = this.random.Next();

            this.Encoder.Encode(startGuard);
            encode(this.Encoder);
            this.Encoder.Encode(endGuard);
            this.Encoder.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(startGuard, this.Decoder.DecodeInt());
            skip(this.Decoder);
            Assert.AreEqual(endGuard, this.Decoder.DecodeInt());
        }

        private class ChunkedStream : Stream
        {
            private readonly Stream stream;
            private readonly int chunkSize;

            public ChunkedStream(Stream stream, int chunkSize)
            {
                this.stream = stream;
                this.chunkSize = chunkSize;
            }

            public override bool CanRead
            {
                get { return this.stream.CanRead; }
            }

            public override bool CanSeek
            {
                get { return this.stream.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return this.stream.CanWrite; }
            }

            public override void Flush()
            {
                this.stream.Flush();
            }

            public override long Length
            {
                get { return this.stream.Length; }
            }

            public override long Position
            {
                get { return this.stream.Position; }
                set { this.stream.Position = value; }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int bytesToRead = Math.Min(count, this.chunkSize);
                return this.stream.Read(buffer, offset, bytesToRead);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return this.stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                this.stream.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                this.stream.Write(buffer, offset, count);
            }

            protected override void Dispose(bool disposed)
            {
                base.Dispose(disposed);
                if (disposed)
                {
                    this.stream.Dispose();
                }
            }
        }
        #endregion
    }
}
