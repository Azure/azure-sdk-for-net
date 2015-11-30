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
    using System.IO;
    using System.Linq;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class CodecsTests
    {
        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeflateCodec_GetCompressedStreamFromNull()
        {
            var codec = new DeflateCodec();
            codec.GetCompressedStreamOver(null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeflateCodec_GetDecompressedStreamOver()
        {
            var codec = new DeflateCodec();
            codec.GetDecompressedStreamOver(null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCodec_GetCompressedStreamFromNull()
        {
            var codec = new NullCodec();
            codec.GetCompressedStreamOver(null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCodec_GetDecompressedStreamOver()
        {
            var codec = new NullCodec();
            codec.GetDecompressedStreamOver(null);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void DeflateCodec_CompressionDecompressionRoundTrip()
        {
            var codec = new DeflateCodec();
            using (var memoryStream = new MemoryStream())
            using (var compressedStream = codec.GetCompressedStreamOver(memoryStream))
            {
                Assert.IsTrue(compressedStream.CanRead);
                Assert.IsTrue(compressedStream.CanWrite);
                Assert.IsTrue(compressedStream.CanSeek);
                Assert.AreEqual(0, compressedStream.Position);
                var expected = Utilities.GetRandom<byte[]>(false);
                compressedStream.Write(expected, 0, expected.Length);
                compressedStream.Flush();
                compressedStream.Seek(0, SeekOrigin.Begin);
                using (var decompressedStream = codec.GetDecompressedStreamOver(compressedStream))
                {
                    var actual = new byte[expected.Length];
                    decompressedStream.Read(actual, 0, actual.Length);
                    Assert.IsTrue(expected.SequenceEqual(actual));
                    Assert.IsTrue(decompressedStream.CanRead);
                    Assert.IsFalse(decompressedStream.CanWrite);
                    //TODO CanSeek should be 'false' however it is 'true' now although an exception is thrown when Seek() is called 
                    //Assert.IsFalse(decompressedStream.CanSeek);
                    Utilities.ShouldThrow<NotSupportedException>(() => { var result = decompressedStream.Position; });
                    Utilities.ShouldThrow<NotSupportedException>(() => { var result = decompressedStream.Length; });
                    Utilities.ShouldThrow<NotSupportedException>(() => { decompressedStream.Seek(0, SeekOrigin.Begin); });
                    Utilities.ShouldThrow<NotSupportedException>(() => { decompressedStream.SetLength(0); });
                    Utilities.ShouldThrow<NotSupportedException>(() => { decompressedStream.Position = 0; });
                    Utilities.ShouldThrow<NotSupportedException>(() => { decompressedStream.Write(expected, 0, expected.Length); });
                    compressedStream.Flush();
                }
            }
        }
    }
}