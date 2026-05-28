// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Moq;

namespace Azure.Core.Tests
{
    public class ResponseTests
    {
        [Test]
        public void ValueIsAccessible()
        {
            var response = Response.FromValue(new TestPayload("test_name"), response: null);
            TestPayload value = response.Value;

            Assert.IsNotNull(value);
            Assert.AreEqual("test_name", value.Name);
        }

        [Test]
        public void ValueObtainedFromCast()
        {
            var response = Response.FromValue(new TestPayload("test_name"), response: null);
            TestPayload value = response;

            Assert.IsNotNull(value);
            Assert.AreEqual("test_name", value.Name);
        }

        [Test]
        public void ImplicitCastFromResponseTToNullFails()
        {
            Response<string> response = null;
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                string s = response;
            });
            StringAssert.StartsWith("The implicit cast from Response<System.String> to System.String failed because the Response<System.String> was null.", exception.Message);
        }

        [Test]
        public void ToStringsFormatsStatusAndValue()
        {
            var response = Response.FromValue(new TestPayload("test_name"), response: new MockResponse(200));

            Assert.AreEqual("Status: 200, Value: Name: test_name", response.ToString());
        }

        [Test]
        public void ToStringsFormatsStatusAndResponsePhrase()
        {
            var response = new MockResponse(200, "Phrase");

            Assert.AreEqual("Status: 200, ReasonPhrase: Phrase", response.ToString());
        }

        [Test]
        public void ValueThrowsIfUnspecified()
        {
            var response = new NoBodyResponse<TestPayload>(new MockResponse(304));
            bool throws = false;
            try
            {
                TestPayload value = response.Value;
            }
            catch
            {
                throws = true;
            }

            Assert.True(throws);
        }

        [Test]
        public void ValueThrowsFromCastIfUnspecified()
        {
            var response = new NoBodyResponse<TestPayload>(new MockResponse(304));

            bool throws = false;
            try
            {
                TestPayload value = response;
            }
            catch
            {
                throws = true;
            }

            Assert.True(throws);
        }

        [Test]
        public void ToStringsFormatsStatusAndMessageForNoBodyResponse()
        {
            var response = new NoBodyResponse<TestPayload>(new MockResponse(200));

            Assert.AreEqual("Status: 200, Service returned no content", response.ToString());
        }

        [Test]
        public void ContentPropertyGetsContent()
        {
            var response = new MockResponse(200);
            Assert.AreEqual(0, response.Content.ToArray().Length);

            var responseWithBody = new MockResponse(200);
            responseWithBody.SetContent("body content");
            Assert.AreEqual("body content", responseWithBody.Content.ToString());

            // Ensure that the BinaryData is formed over the used portion of the memory stream, not the entire buffer.
            MemoryStream ms = new MemoryStream(50);
            var responseWithEmptyBody = new MockResponse(200);
            responseWithEmptyBody.ContentStream = ms;
            Assert.AreEqual(0, response.Content.ToArray().Length);

            // Ensure that even if the stream has been read and the cursor is sitting at the end of stream, the
            // `Content` property still contains the entire response.
            var responseWithBodyFullyRead = new MockResponse(200);
            responseWithBodyFullyRead.SetContent("body content");
            responseWithBodyFullyRead.ContentStream.Seek(0, SeekOrigin.End);
            Assert.AreEqual("body content", responseWithBody.Content.ToString());
        }

        [Test]
        public void ContentPropertyThrowsForNonMemoryStream()
        {
            var response = new MockResponse(200);
            response.ContentStream = new ThrowingStream();

            Assert.Throws<InvalidOperationException>(() => { BinaryData d = response.Content; });
        }

        [Test]
        public void ContentPropertyWorksForMemoryStreamsWithPrivateBuffers()
        {
            var response = new MockResponse(200);
            var responseBody = new byte[100];
            response.ContentStream = new MemoryStream(responseBody, 0, responseBody.Length, writable: false, publiclyVisible: false);

            Assert.DoesNotThrow(() => { BinaryData d = response.Content; });
            CollectionAssert.AreEqual(responseBody, response.Content.ToArray());
        }

        [Test]
        public void CanMockIsError()
        {
            var response = new MockResponse(500);

            Assert.IsFalse(response.IsError);

            response.SetIsError(true);

            Assert.IsTrue(response.IsError);
        }

        [Test]
        public void CanMoqIsError()
        {
            var response = new Mock<Response>();

            Assert.IsFalse(response.Object.IsError);

            response.SetupGet(x => x.IsError).Returns(true);

            Assert.IsTrue(response.Object.IsError);
        }

        internal class TestPayload
        {
            public string Name { get; }

            public TestPayload(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return $"Name: {Name}";
            }
        }

        internal class ThrowingStream : Stream
        {
            public override bool CanRead => throw new System.NotImplementedException();

            public override bool CanSeek => throw new System.NotImplementedException();

            public override bool CanWrite => throw new System.NotImplementedException();

            public override long Length => throw new System.NotImplementedException();

            public override long Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public override void Flush()
            {
                throw new System.NotImplementedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new System.NotImplementedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new System.NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
