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
        protected const string TokenResponseTemplate = "{{\"identity\":{{\"id\":\"8:acs:52a5e676-39a3-4f45-a8ed-5a162dbbd7eb_cdc5aeea-15c5-4db6-b079-fcadd2505dc2_cab309e5-a2e7-4ac8-b04e-5fadc3aa90fa\"}},\n" +
                        "\"accessToken\":{{\"token\":\"{0}\",\n" +
                        "\"expiresOn\":\"{1}\"}}}}";
        protected string TokenResponse = string.Format(TokenResponseTemplate, "token", "2034-10-04T10:21:29.4729393+00:00");

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
        public async Task Process_WithInvalidAcsToken_CallsProcessNext(bool async)
        {
            // Arrange
            var policy = new EntraTokenGuardPolicy();
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            _httpPipelinePolicyMock.Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Returns(new ValueTask(Task.CompletedTask));
            _httpPipelinePolicyMock.Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Verifiable();
            var expired = DateTimeOffset.UtcNow.AddMinutes(-1);
            var expiredAcsTokenResponse = string.Format(TokenResponseTemplate, "token", expired);
            _httpMessage.Response = new MockResponse(200).SetContent(expiredAcsTokenResponse);
            // Act & Assert
            if (async)
            {
                await policy.ProcessAsync(_httpMessage, pipelines);
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.ProcessAsync(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Exactly(2));
            }
            else
            {
                policy.Process(_httpMessage, pipelines);
                policy.Process(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.Process(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Exactly(2));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Process_PrevExchangeCallFailed_CallsProcessNext(bool async)
        {
            // Arrange
            var policy = new EntraTokenGuardPolicy();
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            _httpPipelinePolicyMock.Setup(m => m.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Returns(new ValueTask(Task.CompletedTask));
            _httpPipelinePolicyMock.Setup(m => m.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>())).Verifiable();
            _httpMessage.Response = new MockResponse(400);
            // Act & Assert
            if (async)
            {
                await policy.ProcessAsync(_httpMessage, pipelines);
                await policy.ProcessAsync(_httpMessage, pipelines);
                _httpPipelinePolicyMock.Verify(p => p.ProcessAsync(_httpMessage, It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()), Times.Exactly(2));
            }
            else
            {
                policy.Process(_httpMessage, pipelines);
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
            var pipelines = new ReadOnlyMemory<HttpPipelinePolicy>(new HttpPipelinePolicy[] { _httpPipelinePolicyMock.Object });
            var successfullResponse = new MockResponse(200).SetContent(TokenResponse);
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
