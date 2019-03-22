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
                new object[] { HttpMessageContent.Create(new byte[10]), 10 },
                new object[] { HttpMessageContent.Create(new byte[10], 5, 5), 5 },
                new object[] { HttpMessageContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { HttpMessageContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { HttpMessageContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
            };

        [TestCaseSource(nameof(ContentWithLength))]
        public async Task ContentLengthIsSetForArrayContent(HttpMessageContent content, int expectedLength)
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                request => {
                    contentLength = request.Content.Headers.ContentLength.Value;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var message = transport.CreateMessage(null, CancellationToken.None);
            message.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            message.SetContent(content);
            await transport.ProcessAsync(message);

            Assert.AreEqual(expectedLength, contentLength);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultContentLength()
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                request => {
                    contentLength = request.Content.Headers.ContentLength.Value;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var message = transport.CreateMessage(null, CancellationToken.None);
            message.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            message.SetContent(HttpMessageContent.Create(new byte[10]));
            message.AddHeader("Content-Length", "50");

            await transport.ProcessAsync(message);

            Assert.AreEqual(50, contentLength);
        }

        [Test]
        public async Task HostHeaderSetFromUri()
        {
            string host = null;
            Uri uri = null;
            var mockHandler = new MockHttpClientHandler(
                request => {
                    uri = request.RequestUri;
                    host = request.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var message = transport.CreateMessage(null, CancellationToken.None);
            message.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));

            await transport.ProcessAsync(message);

            // HttpClientHandler would correctly set Host header from Uri when it's not set explicitly
            Assert.AreEqual("http://example.com:340/", uri.ToString());
            Assert.Null(host);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultHost()
        {
            string host = null;
            var mockHandler = new MockHttpClientHandler(
                request => {
                    host = request.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var message = transport.CreateMessage(null, CancellationToken.None);
            message.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            message.AddHeader("Host", "example.org");

            await transport.ProcessAsync(message);

            Assert.AreEqual("example.org", host);
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
