// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
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
            HttpPipelineMessage message = new HttpPipelineMessage(requestMock.Object, new ResponseClassifier());
            message.Dispose();
            requestMock.Verify(r=>r.Dispose(), Times.Once);
        }

        [Test]
        public void DisposingMessageDisposesTheRequestAndResponse()
        {
            var requestMock = new Mock<Request>();
            var responseMock = new Mock<Response>();
            HttpPipelineMessage message = new HttpPipelineMessage(requestMock.Object, new ResponseClassifier());
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

            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.PreserveResponseContent();
            Stream stream2 = message.PreserveResponseContent();

            Assert.AreSame(mockStream.Object, stream);
            Assert.AreSame(stream2, stream);
        }

        [Test]
        public void PreserveReturnsNullWhenContentIsNull()
        {
            var response = new MockResponse(200);
            response.ContentStream = null;

            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.PreserveResponseContent();

            Assert.AreSame(null, stream);
        }

        [Test]
        public void PreserveSetsResponseContentToThrowingStream()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(200);
            response.ContentStream = mockStream.Object;

            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier());
            message.Response = response;

            Stream stream = message.PreserveResponseContent();

            Assert.AreSame(mockStream.Object, stream);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => response.ContentStream.Read(Array.Empty<byte>(), 0, 0));
            Assert.AreEqual("This operation returns Stream as part of the model type. It should be used instead of the response content stream.", exception.Message);
        }
    }
}
