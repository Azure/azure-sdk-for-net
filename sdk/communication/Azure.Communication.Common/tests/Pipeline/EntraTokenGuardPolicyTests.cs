// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.Communication.Pipeline
{
    [TestFixture]
    public class EntraTokenGuardPolicyTests
    {
        private HttpMessage _httpMessage = null!;
        private CustomRequest _httpRequest = null!;
        private Mock<HttpPipelinePolicy> _httpPipelinePolicyMock = null!;
        private string _authHeader = "Bearer Token";

        [SetUp]
        public void SetUp()
        {
            _httpRequest = new CustomRequest(_authHeader);
            _httpMessage = new HttpMessage(_httpRequest, new ResponseClassifier());
            _httpPipelinePolicyMock = new Mock<HttpPipelinePolicy>();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProcessAsync_WithNoToken_CallsProcessNextAsync(bool async)
        {
            // Arrange
            var policy = new EntraTokenGuardPolicy();
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            _httpPipelinePolicyMock.Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Returns(new ValueTask(Task.CompletedTask));
            _httpPipelinePolicyMock.Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Verifiable();
            _httpMessage.Response = new MockResponse(200);

            // Act & Assert
            if (async)
            {
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.ProcessAsync(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Once);
            }
            else
            {
                policy.Process(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.Process(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Once);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Process_WithDifferentToken_CallsProcessNext(bool async)
        {
            // Arrange
            var policy = new EntraTokenGuardPolicy();
            var pipeline = new Mock<HttpPipelinePolicy>();
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            _httpPipelinePolicyMock.Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Returns(new ValueTask(Task.CompletedTask));
            _httpPipelinePolicyMock.Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Verifiable();
            _httpMessage.Response = new MockResponse(200);
            // Act & Assert
            if (async)
            {
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpRequest.UpdateAuthHeader("Bearer Token2");
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.ProcessAsync(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Exactly(2));
            }
            else
            {
                policy.Process(_httpMessage, pipelines);
                _httpRequest.UpdateAuthHeader("Bearer Token2");
                policy.Process(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.Process(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Exactly(2));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProcessAsync_WithSameToken_DoesNotCallProcessNextAsync(bool async)
        {
            // Arrange
            var policy = new EntraTokenGuardPolicy();
            var pipeline = new Mock<HttpPipelinePolicy>();
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            var successfullResponse = new MockResponse(200);
            _httpMessage.Response = successfullResponse;
            _httpPipelinePolicyMock
                .Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()))
                .Returns(new ValueTask(Task.CompletedTask));
            _httpPipelinePolicyMock
                .Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()))
                .Verifiable();
            // Act & Assert
            if (async)
            {
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpRequest.UpdateAuthHeader(_authHeader);
                _httpPipelinePolicyMock
                .Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()))
                .Callback(() => _httpMessage.Response = new MockResponse(400))
                .Returns(new ValueTask(Task.CompletedTask));

                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.ProcessAsync(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Once);
            }
            else
            {
                policy.Process(_httpMessage, pipelines);
                _httpRequest.UpdateAuthHeader(_authHeader);
                _httpPipelinePolicyMock
                .Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()))
                .Callback(() => _httpMessage.Response = new MockResponse(400))
                .Verifiable();

                policy.Process(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.Process(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Once);
            }
            Assert.AreEqual(successfullResponse, _httpMessage.Response);
        }

        private class CustomRequest: MockRequest
        {
            public CustomRequest(string authHeader)
            {
                ClientRequestId = Guid.NewGuid().ToString();
                SetHeader("Authorization", authHeader);
            }

            public void UpdateAuthHeader(string value)
            {
                SetHeader("Authorization", value);
            }
        }
    }
}
