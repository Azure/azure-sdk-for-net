// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineMessageTest
    {
        [Test]
        public void DisposeNoopsForNullResponse()
        {
            var requestMock = new Mock<Request>();
            HttpMessage message = new HttpMessage(requestMock.Object, new ResponseClassifier());
            message.Dispose();
            requestMock.Verify(r=>r.Dispose(), Times.Once);
        }

        [Test]
        public void DisposingMessageDisposesTheRequestAndResponse()
        {
            var requestMock = new Mock<Request>();
            var responseMock = new Mock<Response>();
            HttpMessage message = new HttpMessage(requestMock.Object, new ResponseClassifier());
            message.Response = responseMock.Object;
            message.Dispose();
            requestMock.Verify(r=>r.Dispose(), Times.Once);
            responseMock.Verify(r=>r.Dispose(), Times.Once);
        }

        [Test]
        public void PreserveReturnsResponseStream()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(200);
            response.ContentStream = mockStream.Object;

            HttpMessage message = new HttpMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.ExtractResponseContent();
            Stream stream2 = message.ExtractResponseContent();

            Assert.AreSame(mockStream.Object, stream);
            Assert.AreSame(stream2, stream);
        }

        [Test]
        public void PreserveReturnsNullWhenContentIsNull()
        {
            var response = new MockResponse(200);
            response.ContentStream = null;

            HttpMessage message = new HttpMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.ExtractResponseContent();

            Assert.AreSame(null, stream);
        }

        [Test]
        public void PreserveSetsResponseContentToThrowingStream()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(200);
            response.ContentStream = mockStream.Object;

            HttpMessage message = new HttpMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.ExtractResponseContent();

            Assert.AreSame(mockStream.Object, stream);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => response.ContentStream.Read(Array.Empty<byte>(), 0, 0));
            Assert.AreEqual("The operation has called ExtractResponseContent and will provide the stream as part of its response type.", exception.Message);
        }
    }
}
