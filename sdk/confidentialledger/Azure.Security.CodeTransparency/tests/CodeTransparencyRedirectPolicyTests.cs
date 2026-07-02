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
        private static readonly Uri s_endpoint = new Uri("https://myledger.confidential-ledger.azure.com");

        public CodeTransparencyRedirectPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Follows307RedirectToNewLocation()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary-node.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task Follows308RedirectToNewLocation()
        {
            var mockTransport = new MockTransport(
                new MockResponse(308).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary-node.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task PreservesAuthorizationHeaderOnRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
                message.Request.Headers.SetValue("Authorization", "Bearer test-token");
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.IsTrue(mockTransport.Requests[1].Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer test-token", authValue);
        }

        [Test]
        public async Task PreservesHttpMethodOnRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

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
            }, new CodeTransparencyRedirectPolicy(new Uri("https://example.confidential-ledger.azure.com")));

            Assert.AreEqual(statusCode, response.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task StopsAfterMaxRedirects()
        {
            // The policy allows up to 5 redirects; after that it returns the redirect response.
            var mockTransport = new MockTransport(_ =>
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

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
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(307, response.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ThrowsOnHttpsToHttpRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "http://insecure-node.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            // Untrusted redirect must not be followed
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
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/transactions", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task FollowsMultipleRedirectsWithinLimit()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(307).AddHeader("Location", "https://node-2.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(307).AddHeader("Location", "https://primary.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(4, mockTransport.Requests.Count);
            Assert.AreEqual("https://primary.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[3].Uri.ToString());
        }

        [Test]
        public async Task DisposesIntermediateRedirectResponses()
        {
            var redirectResponse = new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger");
            var mockTransport = new MockTransport(
                redirectResponse,
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/ledger"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(redirectResponse.IsDisposed);
        }

        [Test]
        public async Task CachesPrimaryNodeForSubsequentNonGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
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
            Assert.AreEqual("https://primary-node.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task UsesCachedPrimaryOnlyForNonGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
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
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://primary-a.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                new MockResponse(307).AddHeader("Location", "https://primary-b.myledger.confidential-ledger.azure.com/ledger"),
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
                if (request.Uri.ToString() == "https://primary-a.myledger.confidential-ledger.azure.com/ledger")
                {
                    sawPrimaryA = true;
                    break;
                }
            }

            Assert.IsTrue(sawPrimaryA, "Expected at least one request to the previously cached primary node.");
            Assert.AreEqual("https://primary-b.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[4].Uri.ToString());
        }

        [Test]
        public async Task InvalidatesCacheOnServerErrorFromCachedPrimary()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport = new MockTransport(
                // First write: 307 → primary, 200 (cache warmed)
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
                new MockResponse(200),
                // Second write: goes directly to cached primary, gets 503 (invalidates cache)
                new MockResponse(503),
                // Third write: cache was cleared, goes back through load balancer, 307 → primary, 200
                new MockResponse(307).AddHeader("Location", "https://primary-node.myledger.confidential-ledger.azure.com/ledger"),
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
            Assert.AreEqual("https://primary-node.myledger.confidential-ledger.azure.com/ledger", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task DoesNotCacheRedirectTargetForGetRequests()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport = new MockTransport(
                // GET is redirected (e.g., to a backup/historical node)
                new MockResponse(307).AddHeader("Location", "https://backup-node.myledger.confidential-ledger.azure.com/ledger"),
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

        // ==================== Security regression tests ====================

        [Test]
        public async Task ThrowsOnCrossOriginHttpsRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://attacker.example.com/steal"),
                new MockResponse(200));

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                    message.Request.Headers.SetValue("Authorization", "Bearer SECRET");
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            StringAssert.Contains("untrusted target origin", ex.Message);
            StringAssert.Contains("https://attacker.example.com", ex.Message);
            // Path must NOT appear in error message
            Assert.IsFalse(ex.Message.Contains("/steal"));
            // Attacker must never have been contacted
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ThrowsOnSiblingDomainRedirect()
        {
            // test-ledger-primary.confidential-ledger.azure.com is NOT a subdomain of
            // myledger.confidential-ledger.azure.com
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://test-ledger-primary.confidential-ledger.azure.com/app/entries"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ThrowsOnPrefixCollisionRedirect()
        {
            // evilmyledger.confidential-ledger.azure.com must NOT match
            // myledger.confidential-ledger.azure.com (leading-dot boundary check)
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://evilmyledger.confidential-ledger.azure.com/x"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ThrowsOnDifferentPortRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com:8443/app/entries"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task ThrowsOnProtocolRelativeUntrustedRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "//attacker.example.com/app/entries"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task FollowsTrustedSubdomainRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com/app/entries"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                message.Request.Headers.SetValue("Authorization", "Bearer SECRET");
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.IsTrue(mockTransport.Requests[1].Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer SECRET", authValue);
        }

        [Test]
        public async Task FollowsTrustedUppercaseHostRedirect()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://NODE-1.MYLEDGER.CONFIDENTIAL-LEDGER.AZURE.COM/app/entries"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
        }

        [Test]
        public async Task UntrustedRedirectDoesNotPoisonCache()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);

            // First write: 307 to attacker, must throw and not cache.
            var mockTransport1 = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://attacker.example.com/x"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport1, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, policy);
            });

            // Second write should still go to the load balancer URL — cache must be empty.
            var mockTransport2 = new MockTransport(new MockResponse(200));

            await SendRequestAsync(mockTransport2, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/entries", mockTransport2.Requests[0].Uri.ToString());
        }

        [Test]
        public async Task MidChainUntrustedHopThrowsAndDiscardsStagedCache()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);

            // Hop 1: trusted subdomain; Hop 2: attacker — must throw.
            var mockTransport1 = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com/app/entries"),
                new MockResponse(307).AddHeader("Location", "https://attacker.example.com/app/entries"),
                new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport1, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, policy);
            });

            // We sent to original + first trusted redirect, but NOT to attacker
            Assert.AreEqual(2, mockTransport1.Requests.Count);

            // Cache must be cold — staged entry from hop 1 must be discarded.
            var mockTransport2 = new MockTransport(new MockResponse(200));
            await SendRequestAsync(mockTransport2, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/entries", mockTransport2.Requests[0].Uri.ToString());
        }

        [Test]
        public async Task DoesNotCommitCacheWhenMaxRedirectsExhausted()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);

            // 6 trusted 307 responses — MaxRedirects=5 so chain bottoms out on a 307.
            var mockTransport1 = new MockTransport(_ =>
                new MockResponse(307).AddHeader("Location", "https://node.myledger.confidential-ledger.azure.com/x"));

            await SendRequestAsync(mockTransport1, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            // Cache must NOT be committed — chain ended on 3xx.
            var mockTransport2 = new MockTransport(new MockResponse(200));
            await SendRequestAsync(mockTransport2, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/entries", mockTransport2.Requests[0].Uri.ToString());
        }

        [Test]
        public async Task DoesNotCommitCacheWhenChainEndsIn5xx()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);
            var mockTransport1 = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node.myledger.confidential-ledger.azure.com/x"),
                new MockResponse(500));

            await SendRequestAsync(mockTransport1, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            // Cache must NOT be committed because final response was 5xx.
            var mockTransport2 = new MockTransport(new MockResponse(200));
            await SendRequestAsync(mockTransport2, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/entries", mockTransport2.Requests[0].Uri.ToString());
        }

        [Test]
        public async Task CachedNodeReturnsUntrustedRedirect_InvalidatesCache()
        {
            var policy = new CodeTransparencyRedirectPolicy(s_endpoint);

            // Warm the cache legitimately.
            var warmTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com/x"),
                new MockResponse(200));
            await SendRequestAsync(warmTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            // Cached node returns a malicious redirect — must throw.
            var maliciousTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://attacker.example.com/x"));
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(maliciousTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, policy);
            });

            // Cache must be invalidated. Next write goes through the load balancer.
            var followUpTransport = new MockTransport(new MockResponse(200));
            await SendRequestAsync(followUpTransport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, policy);

            Assert.AreEqual("https://myledger.confidential-ledger.azure.com/app/entries", followUpTransport.Requests[0].Uri.ToString());
        }

        [Test]
        public void ConstructorThrowsOnNullEndpoint()
        {
            Assert.Throws<ArgumentNullException>(() => new CodeTransparencyRedirectPolicy(null));
        }

        [Test]
        public void ConstructorThrowsOnRelativeEndpoint()
        {
            Assert.Throws<ArgumentException>(() => new CodeTransparencyRedirectPolicy(new Uri("/relative", UriKind.Relative)));
        }

        [Test]
        public async Task ExceptionMessageContainsOnlyOrigin()
        {
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://attacker.example.com:9443/secret/path?token=abc"),
                new MockResponse(200));

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await SendRequestAsync(mockTransport, message =>
                {
                    message.Request.Method = RequestMethod.Post;
                    message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
                }, new CodeTransparencyRedirectPolicy(s_endpoint));
            });

            StringAssert.Contains("https://attacker.example.com:9443", ex.Message);
            Assert.IsFalse(ex.Message.Contains("/secret/path"), "Path must not appear in error");
            Assert.IsFalse(ex.Message.Contains("token=abc"), "Query must not appear in error");
        }

        [Test]
        public async Task FollowsTrustedExplicitDefaultPort443()
        {
            // Endpoint has no explicit port (default 443); redirect target has explicit :443
            var mockTransport = new MockTransport(
                new MockResponse(307).AddHeader("Location", "https://node-1.myledger.confidential-ledger.azure.com:443/app/entries"),
                new MockResponse(200));

            var response = await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Uri.Reset(new Uri("https://myledger.confidential-ledger.azure.com/app/entries"));
            }, new CodeTransparencyRedirectPolicy(s_endpoint));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, mockTransport.Requests.Count);
        }
    }
}
