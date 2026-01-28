// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RedirectPolicyTests : SyncAsyncPolicyTestBase
    {
        public RedirectPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCaseSource(nameof(RedirectStatusCodes))]
        [NonParallelizable]
        public async Task UsesLocationResponseHeaderAsNewRequestUri(int code)
        {
            using var testListener = new TestEventListener();
            testListener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            var fistResponse = new MockResponse(code).AddHeader("Location", "https://new.host/");
            var mockTransport = new MockTransport(
                fistResponse,
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, RedirectPolicy.Shared);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            Assert.That(mockTransport.Requests[1].Uri.ToString(), Is.EqualTo("https://new.host/"));
            Assert.That(fistResponse.IsDisposed, Is.True);

            var e = testListener.SingleEventById(20);

            Assert.That(e.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(e.EventName, Is.EqualTo("RequestRedirect"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(mockTransport.Requests[0].ClientRequestId));
            Assert.That(e.GetProperty<string>("from"), Is.EqualTo("https://example.com/"));
            Assert.That(e.GetProperty<string>("to"), Is.EqualTo("https://new.host/"));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(code));
        }

        [TestCaseSource(nameof(RedirectStatusCodes))]
        public async Task UsesRelativeLocationResponseHeaderAsNewRequestUri(int code)
        {
            var fistResponse = new MockResponse(code).AddHeader("Location", "/uploads/");
            var mockTransport = new MockTransport(
                fistResponse,
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, RedirectPolicy.Shared);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            Assert.That(mockTransport.Requests[1].Uri.ToString(), Is.EqualTo("https://example.com/uploads/"));
        }

        [TestCaseSource(nameof(RedirectStatusCodesOldMethodsNewMethods))]
        public async Task ChangesMethodWhenRequired(int code, string oldMethod, string newMethod)
        {
            var mockTransport = new MockTransport(
                new MockResponse(code).AddHeader("Location", "https://new.host/"),
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("http://example.com/"));
                message.Request.Method = new RequestMethod(oldMethod);
            }, RedirectPolicy.Shared);

            Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            Assert.That(mockTransport.Requests[1].Uri.ToString(), Is.EqualTo("https://new.host/"));
            Assert.That(mockTransport.Requests[1].Method.ToString(), Is.EqualTo(newMethod));
        }

        [Test]
        [NonParallelizable]
        public async Task ReturnsOnMaxRedirects()
        {
            using var testListener = new TestEventListener();
            testListener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            var mockTransport = new MockTransport(_ =>
                new MockResponse(300).AddHeader("Location", "https://new.host/"));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, RedirectPolicy.Shared);

            Assert.That(response.Status, Is.EqualTo(300));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(51));
            Assert.That(mockTransport.Requests[1].Uri.ToString(), Is.EqualTo("https://new.host/"));

            var e = testListener.SingleEventById(22);

            Assert.That(e.Level, Is.EqualTo(EventLevel.Warning));
            Assert.That(e.EventName, Is.EqualTo("RequestRedirectCountExceeded"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(mockTransport.Requests[0].ClientRequestId));
            Assert.That(e.GetProperty<string>("from"), Is.EqualTo("https://new.host/"));
            Assert.That(e.GetProperty<string>("to"), Is.EqualTo("https://new.host/"));
        }

        [Test]
        [NonParallelizable]
        public async Task BlocksUnsafeRedirect()
        {
            using var testListener = new TestEventListener();
            testListener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            var mockTransport = new MockTransport(_ =>
                new MockResponse(300).AddHeader("Location", "http://new.host/"));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, RedirectPolicy.Shared);

            Assert.That(response.Status, Is.EqualTo(300));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(1));

            var e = testListener.SingleEventById(21);

            Assert.That(e.Level, Is.EqualTo(EventLevel.Warning));
            Assert.That(e.EventName, Is.EqualTo("RequestRedirectBlocked"));
            Assert.That(e.GetProperty<string>("requestId"), Is.EqualTo(mockTransport.Requests[0].ClientRequestId));
            Assert.That(e.GetProperty<string>("from"), Is.EqualTo("https://example.com/"));
            Assert.That(e.GetProperty<string>("to"), Is.EqualTo("http://new.host/"));
        }

        [Test]
        public async Task RemovesAuthHeader()
        {
            var mockTransport = new MockTransport(
                new MockResponse(300)
                    .AddHeader("Location", "https://new.host/")
                    .AddHeader("Authorization", "secret value"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, RedirectPolicy.Shared);

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            Assert.That(mockTransport.Requests[1].Headers.Contains("Authorization"), Is.False);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RespectsCtorParameter(bool isClientRedirectEnabled)
        {
            var mockTransport = new MockTransport(
                new MockResponse(300)
                    .AddHeader("Location", "https://new.host/"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                message.Request.Uri.Reset(new Uri("https://example.com/"));
            }, new RedirectPolicy(isClientRedirectEnabled));

            if (isClientRedirectEnabled)
            {
                Assert.That(response.Status, Is.EqualTo(200));
                Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            }
            else
            {
                Assert.That(response.Status, Is.EqualTo(300));
                Assert.That(mockTransport.Requests.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public async Task SetAllowAutoRedirectTakesPrecedenceWhenSet(
            [Values(true, false)] bool isClientRedirectEnabled,
            [Values(true, false, null)] bool? setAllowAutoRedirect)
        {
            var mockTransport = new MockTransport(
                new MockResponse(300)
                    .AddHeader("Location", "https://new.host/"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, messageAction: message =>
            {
                message.Request.Uri.Reset(new Uri("https://example.com/"));
                if (setAllowAutoRedirect.HasValue)
                {
                    RedirectPolicy.SetAllowAutoRedirect(message, setAllowAutoRedirect.Value);
                }
            }, new RedirectPolicy(isClientRedirectEnabled));

            if (setAllowAutoRedirect ?? false || (!setAllowAutoRedirect.HasValue && isClientRedirectEnabled))
            {
                Assert.That(response.Status, Is.EqualTo(200));
                Assert.That(mockTransport.Requests.Count, Is.EqualTo(2));
            }
            else
            {
                Assert.That(response.Status, Is.EqualTo(300));
                Assert.That(mockTransport.Requests.Count, Is.EqualTo(1));
            }
        }

        public static readonly object[][] RedirectStatusCodes = {
            new object[] { 300 },
            new object[] { 301 },
            new object[] { 302 },
            new object[] { 303 },
            new object[] { 307 },
            new object[] { 308 }
        };

        public static readonly object[][] RedirectStatusCodesOldMethodsNewMethods = {
            new object[] { 300, "GET", "GET" },
            new object[] { 300, "POST", "GET" },
            new object[] { 300, "HEAD", "HEAD" },

            new object[] { 301, "GET", "GET" },
            new object[] { 301, "POST", "GET" },
            new object[] { 301, "HEAD", "HEAD" },

            new object[] { 302, "GET", "GET" },
            new object[] { 302, "POST", "GET" },
            new object[] { 302, "HEAD", "HEAD" },

            new object[] { 303, "GET", "GET" },
            new object[] { 303, "POST", "GET" },
            new object[] { 303, "HEAD", "HEAD" },

            new object[] { 307, "GET", "GET" },
            new object[] { 307, "POST", "POST" },
            new object[] { 307, "HEAD", "HEAD" },

            new object[] { 308, "GET", "GET" },
            new object[] { 308, "POST", "POST" },
            new object[] { 308, "HEAD", "HEAD" },
        };
    }
}
