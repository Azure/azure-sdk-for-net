// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using NUnit.Framework;

namespace Azure.Configuration.Tests
{
    public class HttpClientTransportTests
    {
        public static object[] ContentWithLength =>
            new object[]
            {
                new object[] { HttpPipelineRequestContent.Create(new byte[10]), 10 },
                new object[] { HttpPipelineRequestContent.Create(new byte[10], 5, 5), 5 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
            };

        [TestCaseSource(nameof(ContentWithLength))]
        public async Task ContentLengthIsSetForArrayContent(HttpPipelineRequestContent content, int expectedLength)
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => contentLength = httpRequestMessage.Content.Headers.ContentLength.Value
                );

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            request.SetContent(content);

            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
            }

            Assert.AreEqual(expectedLength, contentLength);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultContentLength()
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => contentLength = httpRequestMessage.Content.Headers.ContentLength.Value);

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            request.SetContent(HttpPipelineRequestContent.Create(new byte[10]));
            request.AddHeader("Content-Length", "50");

            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
            }

            Assert.AreEqual(50, contentLength);
        }

        [Test]
        public async Task HostHeaderSetFromUri()
        {
            string host = null;
            Uri uri = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    uri = httpRequestMessage.RequestUri;
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));

            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
            }

            // HttpClientHandler would correctly set Host header from Uri when it's not set explicitly
            Assert.AreEqual("http://example.com:340/", uri.ToString());
            Assert.Null(host);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultHost()
        {
            string host = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));
            request.AddHeader("Host", "example.org");

            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
            }
            Assert.AreEqual("example.org", host);
        }

        [Test]
        public async Task RequestAndResponseHasCorrelationId()
        {

        }

        private class MockHttpClientHandler : HttpMessageHandler
        {
            private readonly Action<HttpRequestMessage> _onSend;

            public MockHttpClientHandler(Action<HttpRequestMessage> onSend)
            {
                _onSend = onSend;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                _onSend(request);
                return Task.FromResult(new HttpResponseMessage((HttpStatusCode)200));
            }
        }
    }
}
