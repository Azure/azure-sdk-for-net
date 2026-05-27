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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/transactions", mockTransport.Requests[1].Uri.ToString());
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
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
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy());

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(redirectResponse.IsDisposed);
        }

        [Test]
        public async Task CachesPrimaryNodeForSubsequentNonGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy();
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            Assert.AreEqual(3, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary-node.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task UsesCachedPrimaryOnlyForNonGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy();
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Get;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            Assert.AreEqual(3, mockTransport.Requests.Count);
            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task RefreshesCachedPrimaryWhenRedirectTargetChanges()
        {
            var policy = new CodeTransparencyRedirectPolicy();
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-a.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                new MockResponse(307).AddHeader("Location", "https://primary-b.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            Assert.AreEqual(5, mockTransport.Requests.Count);
            bool sawPrimaryA = false;
            foreach (MockRequest request in mockTransport.Requests)
            {
                if (request.Uri.ToString() == "https://primary-a.confidential-ledger.azure.com/ledger")
                {
                    sawPrimaryA = true;
                    break;
                }
            }

            Assert.IsTrue(sawPrimaryA, "Expected at least one request to the previously cached primary node.");
            Assert.AreEqual("https://primary-b.confidential-ledger.azure.com/ledger", mockTransport.Requests[4].Uri.ToString());
        }

        [Test]
        public async Task InvalidatesCacheOnServerErrorFromCachedPrimary()
        {
            var policy = new CodeTransparencyRedirectPolicy();
            var mockTransport = new MockTransport(
                // First write: 307 → primary, 200 (cache warmed)
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                // Second write: goes directly to cached primary, gets 503 (invalidates cache)
                new MockResponse(503),
                // Third write: cache was cleared, goes back through load balancer, 307 → primary, 200
                new MockResponse(307).AddHeader("Location", "https://primary-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            // Write #1: LB → 307 → primary = 2 requests
            // Write #2: cached primary → 503 = 1 request
            // Write #3: cache invalidated, back through LB → 307 → primary = 2 requests
            // Total = 5 proves the cache was cleared after the 503.
            // (If cache were still active, write #3 would go directly to primary = 4 total.)
            Assert.AreEqual(5, mockTransport.Requests.Count);
            // Write #2 was sent directly to cached primary
            Assert.AreEqual("https://primary-node.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task DoesNotCacheRedirectTargetForGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy();
            var mockTransport = new MockTransport(
                // GET is redirected (e.g., to a backup/historical node)
                new MockResponse(307).AddHeader("Location", "https://backup-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                // Subsequent POST should NOT go to backup-node
                new MockResponse(200));

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Get;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, policy);

            Assert.AreEqual(3, mockTransport.Requests.Count);
            // POST should go to the common URL (cache not populated from GET redirect)
            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }
    }
}
