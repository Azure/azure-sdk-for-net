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
    using System.Runtime.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class BufferedEncodeDecodeTests : EncodeDecodeTests
    {
        internal override IEncoder CreateEncoder(Stream stream)
        {
            return new BufferedBinaryEncoder(stream);
        }

        internal override IDecoder CreateDecoder(Stream stream)
        {
            return new BufferedBinaryDecoder(stream);
        }

        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Constructor should throw.")]
        [TestMethod]
        [TestCategory("CheckIn")]
        public void EncodeDecode_CreateWithNullStream()
        {
            Utilities.ShouldThrow<ArgumentNullException>(() => new BinaryEncoder(null));
            Utilities.ShouldThrow<ArgumentNullException>(() => new BinaryDecoder(null));
            Utilities.ShouldThrow<ArgumentNullException>(() => new BufferedBinaryEncoder(null));
            Utilities.ShouldThrow<ArgumentNullException>(() => new BufferedBinaryDecoder(null));
        }

        #region Decode tests
        [TestMethod]
        [TestCategory("CheckIn")]
        public void BufferedDecode_InvalidInt_UnexpectedStreamEnd()
        {
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeInt());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void BufferedDecode_InvalidLong_UnexpectedStreamEnd()
        {
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).DecodeLong());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidString_UnexpectedStreamEnd()
        {
            var randomString = Utilities.GetRandom<string>(false);
            this.Encoder.Encode(randomString);
            this.Encoder.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[this.Stream.Length - 1];
            this.Stream.Read(buffer, 0, buffer.Length);
            using (var memoryStream = new MemoryStream(buffer))
            {
                var decoder = new BufferedBinaryDecoder(memoryStream);
                decoder.DecodeString();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidBool_UnexpectedStreamEnd()
        {
            this.Decoder.DecodeBool();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidDouble_UnexpectedStreamEnd()
        {
            var numberOfBytes = Utilities.GetRandom<int>(false) % 8;
            for (int i = 0; i < numberOfBytes; i++)
            {
                this.Stream.WriteByte(0xFF);
            }
            this.Stream.Seek(0, SeekOrigin.Begin);
            this.Decoder.DecodeDouble();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidFloat_UnexpectedStreamEnd()
        {
            var numberOfBytes = Utilities.GetRandom<int>(false) % 4;
            for (int i = 0; i < numberOfBytes; i++)
            {
                this.Stream.WriteByte(0xFF);
            }
            this.Stream.Seek(0, SeekOrigin.Begin);
            this.Decoder.DecodeFloat();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidFixed_UnexpectedStreamEnd()
        {
            var randomByteArray = Utilities.GetRandom<byte[]>(false);
            this.Stream.Write(randomByteArray, 0, randomByteArray.Length - 1);
            this.Decoder.DecodeFixed(randomByteArray.Length);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedDecode_InvalidByteArray_UnexpectedStreamEnd()
        {
            var randomByteArray = Utilities.GetRandom<byte[]>(false);
            this.Encoder.Encode(randomByteArray);
            this.Encoder.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[this.Stream.Length - 1];
            this.Stream.Read(buffer, 0, buffer.Length);
            using (var memoryStream = new MemoryStream(buffer))
            {
                var decoder = new BufferedBinaryDecoder(memoryStream);
                decoder.DecodeByteArray();
            }
        }
        #endregion

        #region Skip tests
        [TestMethod]
        [TestCategory("CheckIn")]
        public void BufferedSkip_InvalidInt_UnexpectedStreamEnd()
        {
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipInt());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipInt());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void BufferedSkip_InvalidLong_UnexpectedStreamEnd()
        {
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());

            this.Stream.WriteByte(0xFF);
            this.Stream.Seek(0, SeekOrigin.Begin);
            Utilities.ShouldThrow<SerializationException>(() => new BufferedBinaryDecoder(this.Stream).SkipLong());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidString_UnexpectedStreamEnd()
        {
            var randomString = Utilities.GetRandom<string>(false);
            this.Encoder.Encode(randomString);
            this.Encoder.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[this.Stream.Length - 1];
            this.Stream.Read(buffer, 0, buffer.Length);
            using (var memoryStream = new MemoryStream(buffer))
            {
                var decoder = new BufferedBinaryDecoder(memoryStream);
                decoder.SkipString();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidBool_UnexpectedStreamEnd()
        {
            this.Decoder.SkipBool();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidDouble_UnexpectedStreamEnd()
        {
            var numberOfBytes = Utilities.GetRandom<int>(false) % 8;
            for (int i = 0; i < numberOfBytes; i++)
            {
                this.Stream.WriteByte(0xFF);
            }
            this.Stream.Seek(0, SeekOrigin.Begin);
            this.Decoder.SkipDouble();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidFloat_UnexpectedStreamEnd()
        {
            var numberOfBytes = Utilities.GetRandom<int>(false) % 4;
            for (int i = 0; i < numberOfBytes; i++)
            {
                this.Stream.WriteByte(0xFF);
            }
            this.Stream.Seek(0, SeekOrigin.Begin);
            this.Decoder.SkipFloat();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidFixed_UnexpectedStreamEnd()
        {
            var randomByteArray = Utilities.GetRandom<byte[]>(false);
            this.Stream.Write(randomByteArray, 0, randomByteArray.Length - 1);
            this.Decoder.SkipFixed(randomByteArray.Length);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void BufferedSkip_InvalidByteArray_UnexpectedStreamEnd()
        {
            var randomByteArray = Utilities.GetRandom<byte[]>(false);
            this.Encoder.Encode(randomByteArray);
            this.Encoder.Flush();
            this.Stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[this.Stream.Length - 1];
            this.Stream.Read(buffer, 0, buffer.Length);
            using (var memoryStream = new MemoryStream(buffer))
            {
                var decoder = new BufferedBinaryDecoder(memoryStream);
                decoder.SkipByteArray();
            }
        }

        #endregion //Skip tests
    }
}
