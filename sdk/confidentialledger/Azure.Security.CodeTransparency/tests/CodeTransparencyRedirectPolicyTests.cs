// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyRedirectPolicyTests : SyncAsyncPolicyTestBase
    {
        public CodeTransparencyRedirectPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Follows307RedirectToNewLocation()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary-node.confidential-ledger.azure.com/ledger", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task Follows308RedirectToNewLocation()
        {
            var mockTransport = new MockTransport(
                new MockResponse(308).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary-node.confidential-ledger.azure.com/ledger", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task PreservesAuthorizationHeaderOnRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
                message.Request.Headers.SetValue("Authorization", "Bearer test-token");
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.IsTrue(mockTransport.Requests[1].Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer test-token", authValue);
        }

        [Test]
        public async Task PreservesHttpMethodOnRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual(RequestMethod.Post, mockTransport.Requests[1].Method);
        }

        [Test]
        public async Task DoesNotFollowNonRedirectStatusCodes([Values(200, 201, 400, 404, 500, 301, 302, 303)] int statusCode)
        {
            var mockTransport = new MockTransport(
                new MockResponse(statusCode).AddHeader("Location", "https://other.host/"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://example.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(statusCode, response.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task StopsAfterMaxRedirects()
        {
            // The policy allows up to 5 redirects; after that it returns the redirect response.
            var mockTransport = new MockTransport(_ =>
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(307, response.Status);
            // 1 original + 5 redirects = 6 total requests
            Assert.AreEqual(6, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ReturnsRedirectResponseWhenNoLocationHeader()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307), // No Location header
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(307, response.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task BlocksHttpsToHttpRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "http://insecure-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            // Should NOT follow the redirect (HTTPS → HTTP downgrade)
            Assert.AreEqual(307, response.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task FollowsRelativeLocationHeader()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "/app/transactions"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://secondary-node.confidential-ledger.azure.com/app/transactions", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task FollowsMultipleRedirectsWithinLimit()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.confidential-ledger.azure.com/ledger"),
                new MockResponse(307).AddHeader("Location", "https://node-2.confidential-ledger.azure.com/ledger"),
                new MockResponse(307).AddHeader("Location", "https://primary.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(4, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary.confidential-ledger.azure.com/ledger", mockTransport.Requests[3].Uri.ToString());
        }

        [Test]
        public async Task DisposesIntermediateRedirectResponses()
        {
            var redirectResponse = new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger");
            var mockTransport = new MockTransport(
                redirectResponse,
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://secondary-node.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(redirectResponse.IsDisposed);
        }
    }
}
