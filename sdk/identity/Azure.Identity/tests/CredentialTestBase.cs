// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public abstract class CredentialTestBase<TCredOptions> : ClientTestBase where TCredOptions : TokenCredentialOptions
    {
        protected const string Scope = "https://vault.azure.net/.default";
        protected const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        protected const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        protected const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        protected const string ObjectId = "22730c7e-c3c8-431b-94cf-5676152d9338";
        protected const string ExpectedUsername = "mockuser@mockdomain.com";
        protected const string UserrealmResponse = "{\"ver\": \"1.0\", \"account_type\": \"Managed\", \"domain_name\": \"constoso.com\", \"cloud_instance_name\": \"microsoftonline.com\", \"cloud_audience_urn\": \"urn:federation:MicrosoftOnline\"}";
        protected string expectedToken;
        protected string expectedUserAssertion = Guid.NewGuid().ToString();
        protected string expectedTenantId;
        protected string expectedReplyUri;
        protected string authCode;
        protected const string ReplyUrl = "https://myredirect/";
        protected string clientSecret = Guid.NewGuid().ToString();
        protected DateTimeOffset expiresOn;
        internal MockMsalConfidentialClient mockConfidentialMsalClient;
        internal MockMsalPublicClient mockPublicMsalClient;
        protected TokenCredentialOptions options;
        protected AuthenticationResult result;
        protected string expectedCode;
        protected DeviceCodeResult deviceCodeResult;

        public CredentialTestBase(bool isAsync) : base(isAsync)
        {
        }

        public abstract TokenCredential GetTokenCredential(TokenCredentialOptions options);
        public abstract TokenCredential GetTokenCredential(CommonCredentialTestConfig config);

        [Test]
        public async Task IsAccountIdentifierLoggingEnabled([Values(true, false)] bool isOptionSet)
        {
            var options = new TokenCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = isOptionSet } };
            TestSetup(options);
            expectedTenantId = TenantId;
            using var _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Verbose);
            var credential = GetTokenCredential(options);
            var context = new TokenRequestContext(new[] { Scope }, tenantId: TenantId);
            await credential.GetTokenAsync(context, default);

            var loggedEvents = _listener.EventsById(AzureIdentityEventSource.AuthenticatedAccountDetailsEvent);
            if (isOptionSet)
            {
                CollectionAssert.IsNotEmpty(loggedEvents);
            }
            else
            {
                CollectionAssert.IsEmpty(loggedEvents);
            }
        }

        [Test]
        public async Task RespectsIsSupportLoggingEnabled([Values(true, false)] bool isSupportLoggingEnabled)
        {
            using var _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Verbose);

            var token = Guid.NewGuid().ToString();
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                IsUnsafeSupportLoggingEnabled = isSupportLoggingEnabled
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore($"{credential.GetType().Name} is not an MSAL credential.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreEqual(token, actualToken.Token);
            string expectedPrefix = isSupportLoggingEnabled ? "True" : "False";
            Assert.True(_listener.EventData.Any(d => d.Payload.Any(p => p.ToString().StartsWith($"{expectedPrefix} MSAL"))));
        }

        [Test]
        [TestCase(EventLevel.Informational)]
        [TestCase(EventLevel.Verbose)]
        public async Task ListenerEventLevelControlsMsalLogLevel(EventLevel eventLevel)
        {
            using var _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, eventLevel);

            var token = Guid.NewGuid().ToString();
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                IsUnsafeSupportLoggingEnabled = true
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore($"{credential.GetType().Name} is not an MSAL credential.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreEqual(token, actualToken.Token);

            Assert.True(_listener.EventData.Any(d => d.Level == EventLevel.Informational && d.EventName == "LogMsalInformational"));

            switch (eventLevel)
            {
                case EventLevel.Informational:
                    Assert.False(_listener.EventData.Any(d => d.Level == EventLevel.Verbose && d.EventName == "LogMsalVerbose"));
                    break;
                case EventLevel.Verbose:
                    Assert.True(_listener.EventData.Any(d => d.Level == EventLevel.Verbose && d.EventName == "LogMsalVerbose"));
                    break;
                default:
                    Assert.Fail("Unexpected event level");
                    break;
            }
        }

        [Test]
        [NonParallelizable]
        public async Task DisableInstanceMetadataDiscovery([Values(true, false)] bool disable)
        {
            // Skip test if the credential does not support disabling instance discovery
            if (!typeof(ISupportsDisableInstanceDiscovery).IsAssignableFrom(typeof(TCredOptions)))
            {
                Assert.Ignore($"{typeof(TCredOptions).Name} does not implement {nameof(ISupportsDisableInstanceDiscovery)}");
            }

            // Clear instance discovery cache
            StaticCachesUtilities.ClearStaticMetadataProviderCache();

            var token = Guid.NewGuid().ToString();
            // Configure the transport
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token
            };
            transportConfig.RequestValidator = req => transportConfig.CalledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                DisableInstanceDiscovery = disable,
                Transport = mockTransport,
                TenantId = TenantId,
            };
            var credential = GetTokenCredential(config);
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreNotEqual(disable, transportConfig.CalledDiscoveryEndpoint);
            Assert.AreEqual(token, actualToken.Token);
        }

        [Test]
        public void VerifyAllowedTenantEnforcementCredentials()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            string resolvedTenantId = TenantId;
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var mockResolver = new Mock<TenantIdResolverBase>() { CallBase = true };
            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                RequestContext = new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()),
                AdditionallyAllowedTenants = new List<string> { Guid.NewGuid().ToString() },
                TestTentantIdResolver = mockResolver.Object
            };
            var credential = GetTokenCredential(config);

            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

            // Assert that Resolver is called and that the resolved tenant is the expected tenant
            mockResolver.Setup(r => r.Resolve(It.IsAny<string>(), It.IsAny<TokenRequestContext>(), It.IsAny<string[]>())).Callback<string, TokenRequestContext, IList<string>>((tenantId, context, additionalTenants) =>
            {
                Assert.AreEqual(config.TenantId, tenantId);
                Assert.AreEqual(config.RequestContext.TenantId, context.TenantId);
                Assert.AreEqual(config.AdditionallyAllowedTenants, additionalTenants);
            }).Returns(resolvedTenantId);
        }

        [Test]
        public async Task EnableCae()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            bool observedCae = false;
            bool observedNoCae = false;
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token,
                RequestValidator = req =>
                {
                    if (req.Content != null)
                    {
                        var stream = new MemoryStream();
                        req.Content.WriteTo(stream, default);
                        var content = new BinaryData(stream.ToArray()).ToString();
                        var queryString = Uri.UnescapeDataString(content)
                            .Split('&')
                            .Select(q => q.Split('='))
                            .ToDictionary(kvp => kvp[0], kvp => kvp[1]);
                        bool containsClaims = queryString.TryGetValue("claims", out var claimsJson);
                        bool enableCae = req.ClientRequestId == "enableCae";
                        if (enableCae)
                        {
                            observedCae = true;
                        }
                        else
                        {
                            observedNoCae = true;
                        }
                        Assert.AreEqual(enableCae, containsClaims);
                        if (containsClaims)
                        {
                            var claims = System.Text.Json.JsonSerializer.Deserialize<Claims>(claimsJson);
                            CollectionAssert.Contains(claims.access_token.xms_cc.values, "CP1");
                        }
                    }
                }
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("EnableCAE tests do not apply to the non-MSAL credentials.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

            // First call with EnableCae = false
            using (HttpPipeline.CreateClientRequestIdScope("disableCae"))
            {
                AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, isCaeEnabled: false), default);
                Assert.AreEqual(token, actualToken.Token);
            }
            // First call with EnableCae = true
            using (HttpPipeline.CreateClientRequestIdScope("enableCae"))
            {
                AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, isCaeEnabled: true), default);
                Assert.AreEqual(token, actualToken.Token);
            }
            // Second call with EnableCae = false
            using (HttpPipeline.CreateClientRequestIdScope("disableCae"))
            {
                AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, isCaeEnabled: false), default);
                Assert.AreEqual(token, actualToken.Token);
            }
            // Second call with EnableCae = true
            using (HttpPipeline.CreateClientRequestIdScope("enableCae"))
            {
                AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, isCaeEnabled: true), default);
                Assert.AreEqual(token, actualToken.Token);
            }
            Assert.True(observedCae);
            Assert.True(observedNoCae);
        }

        [Test]
        public async Task ClaimsSetCorrectlyOnRequest()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            const string Claims = "myClaims";
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token,
                RequestValidator = req =>
                {
                    if (req.Content != null)
                    {
                        var stream = new MemoryStream();
                        req.Content.WriteTo(stream, default);
                        var content = new BinaryData(stream.ToArray()).ToString();
                        var queryString = Uri.UnescapeDataString(content)
                            .Split('&')
                            .Select(q => q.Split('='))
                            .ToDictionary(kvp => kvp[0], kvp => kvp[1]);
                        bool containsClaims = queryString.TryGetValue("claims", out var claimsJson);

                        if (req.ClientRequestId == "NoClaims")
                        {
                            Assert.False(containsClaims, "(NoClaims) Claims should not be present. Claims=" + claimsJson);
                        }
                        if (req.ClientRequestId == "WithClaims")
                        {
                            Assert.True(containsClaims, "(WithClaims) Claims should be present");
                            Assert.AreEqual(Claims, claimsJson, "(WithClaims) Claims should match");
                        }
                    }
                }
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                RedirectUri = new Uri("http://localhost:8400/")
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("EnableCAE tests do not apply to the non-MSAL credentials.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

            using (HttpPipeline.CreateClientRequestIdScope("NoClaims"))
            {
                // First call to populate the account record for confidential client creds
                await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
                var actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Alternate), default);
                Assert.AreEqual(token, actualToken.Token);
            }
            using (HttpPipeline.CreateClientRequestIdScope("WithClaims"))
            {
                var actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Alternate2, claims: Claims), default);
                Assert.AreEqual(token, actualToken.Token);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task TokenContainsRefreshOn()
        {
            // Skip test if the credential does not support disabling instance discovery
            if (!typeof(ISupportsDisableInstanceDiscovery).IsAssignableFrom(typeof(TCredOptions)))
            {
                // Assert.Ignore($"{typeof(TCredOptions).Name} does not implement {nameof(ISupportsDisableInstanceDiscovery)}");
            }

            // Clear instance discovery cache
            StaticCachesUtilities.ClearStaticMetadataProviderCache();

            var token = Guid.NewGuid().ToString();
            // Configure the transport
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token
            };
            transportConfig.RequestValidator = req => transportConfig.CalledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("EnableCAE tests do not apply to the non-MSAL credentials.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreEqual(token, actualToken.Token);
            Assert.IsNotNull(actualToken.RefreshOn);
        }

        [Test]
        public async Task CachingOptionsAreRespected()
        {
            // Skip test if the credential does not support caching options
            if (!typeof(ISupportsTokenCachePersistenceOptions).IsAssignableFrom(typeof(TCredOptions)))
            {
                Assert.Ignore($"{typeof(TCredOptions).Name} does not implement {nameof(ISupportsTokenCachePersistenceOptions)}");
            }

            TransportConfig transportConfig = new()
            {
                TokenFactory = req => Guid.NewGuid().ToString()
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);
            var cache = new MemoryTokenCache();

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                TokenCachePersistenceOptions = cache,
                AuthenticationRecord = new AuthenticationRecord(ExpectedUsername, "login.windows.net", $"{ObjectId}.{TenantId}", TenantId, ClientId),
            };

            // Handle credentials that need to be initialized with a cache
            if (typeof(TCredOptions) == typeof(InteractiveBrowserCredentialOptions) || typeof(TCredOptions) == typeof(SharedTokenCacheCredentialOptions))
            {
                cache.Data = CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, TenantId, "token", "refreshToken");
            }

            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore($"{credential.GetType().Name} is not an MSAL credential.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

            // Fetch a token to populate the cache
            AccessToken actualToken1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            // Create a new credential sharing the same cache
            var credential2 = GetTokenCredential(config);
            AccessToken actualToken2 = await credential2.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreEqual(actualToken1.Token, actualToken2.Token);
        }

        [Test]
        public async Task AuthorityHostConfigSupportsdStS()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token,
                RequestValidator = req =>
                {
                    if (req.Uri.Path.EndsWith("/token"))
                    {
                        Assert.AreEqual("usnorth-passive-dsts.dsts.core.windows.net", req.Uri.Host);
                        Assert.AreEqual($"/dstsv2/{TenantId}/oauth2/v2.0/token", req.Uri.Path);
                    }
                }
            };
            var factory = MockTokenTransportFactory(transportConfig);
            var mockTransport = new MockTransport(factory);

            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                Transport = mockTransport,
                TenantId = TenantId,
                AuthorityHost = new("https://usnorth-passive-dsts.dsts.core.windows.net/dstsv2"),
                RedirectUri = new Uri("http://localhost:8400/")
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("AuthorityHostConfigSupportsdStS tests do not apply to the non-MSAL credentials.");
            }
            transportConfig.IsPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

            // First call to populate the account record for confidential client creds
            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            var actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Alternate), default);
            Assert.AreEqual(token, actualToken.Token);
        }

        public class MemoryTokenCache : UnsafeTokenCacheOptions
        {
            public ReadOnlyMemory<byte> Data { get; set; } = new ReadOnlyMemory<byte>();
            public int CacheReadCount;
            public int CacheUpdatedCount;

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync()
            {
                CacheReadCount++;
                Console.WriteLine("     *********  RefreshCacheAsync");
                return Task.FromResult(Data);
            }

            protected internal override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
            {
                CacheUpdatedCount++;
                Data = tokenCacheUpdatedArgs.UnsafeCacheData;
                // convert the Data byte array to a string
                var str = Encoding.UTF8.GetString(Data.Span.ToArray());
                Console.WriteLine(str);
                return Task.CompletedTask;
            }
        }

        [Test]
        public async Task TokenRequestContextClaimsPassedToMSAL()
        {
            var caeClaim = new CaeClaim();
            InitMockAuthenticationResult();
            bool claimsIsVerified = false;
            var msalPub = new MockMsalPublicClient(null, null, null, null, options)
            {
                SilentAuthFactory = (_, claims, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                },
                ExtendedSilentAuthFactory = (_, claims, _, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                },
                InteractiveAuthFactory = (_, claims, _, _, _, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                },
                DeviceCodeAuthFactory = (_, claims, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                },
                UserPassAuthFactory = (_, claims, _, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                },
                Accounts = new List<IAccount> { new MockAccount(ExpectedUsername, TenantId) }
            };
            var msalConf = new MockMsalConfidentialClient(null, null, null, null, null, options)
                .WithAuthCodeFactory((_, _, _, _, claims, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                })
                .WithClientFactory((_, _, claims, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return result;
                })
                .WithOnBehalfOfFactory((_, _, _, claims, _, _, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return new ValueTask<AuthenticationResult>(result);
                })
                .WithSilentFactory((_, _, _, _, claims, _) =>
                {
                    Assert.AreEqual(caeClaim.ToString(), claims, "Claims passed to msal should match");
                    claimsIsVerified = true;
                    return new ValueTask<AuthenticationResult>(result);
                });

            var token = Guid.NewGuid().ToString();
            TransportConfig transportConfig = new()
            {
                TokenFactory = req => token,
            };
            var config = new CommonCredentialTestConfig()
            {
                TransportConfig = transportConfig,
                TenantId = TenantId,
                MockPublicMsalClient = msalPub,
                MockConfidentialMsalClient = msalConf,
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("TokenRequestContextClaimsPassedToMSAL tests do not apply to the non-MSAL credentials.");
            }
            var context = new TokenRequestContext(new[] { Scope }, claims: caeClaim.ToString());
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var actualToken = await credential.GetTokenAsync(context, CancellationToken.None);

            Assert.AreEqual(expectedToken, actualToken.Token, "Token should match");
            Assert.True(claimsIsVerified);
        }

        public class TransportConfig
        {
            public bool CalledDiscoveryEndpoint { get; set; }
            public bool IsPubClient { get; set; }
            public Action<MockRequest> RequestValidator { get; set; }
            public Func<MockRequest, string> TokenFactory { get; set; }
            public Action<MockRequest, MockResponse> ResponseHandler { get; set; }
        }

        public static Func<MockRequest, MockResponse> MockTokenTransportFactory(TransportConfig transportConfig)
        {
            return req =>
            {
                MockResponse response = new(200);
                if (req.Uri.Path.EndsWith("/devicecode"))
                {
                    response = CredentialTestHelpers.CreateMockMsalDeviceCodeResponse();
                }
                else if (req.Uri.Path.Contains("/userrealm/"))
                {
                    response.SetContent(UserrealmResponse);
                }
                else if (req.Uri.Path.Contains("/common/discovery/instance"))
                {
                    transportConfig.CalledDiscoveryEndpoint = true;
                    response.SetContent(CredentialTestHelpers.CreateMockInstanceDiscoveryResponse());
                }
                else if (req.Uri.Path.EndsWith("/token"))
                {
                    if (transportConfig.IsPubClient || typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions) || typeof(TCredOptions) == typeof(OnBehalfOfCredentialOptions))
                    {
                        response = CredentialTestHelpers.CreateMockMsalTokenResponse(200, transportConfig.TokenFactory?.Invoke(req) ?? Guid.NewGuid().ToString(), TenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($$"""{"token_type": "Bearer","expires_in": 9999,"ext_expires_in": 9999, "refresh_in": 9999,"access_token": "{{transportConfig.TokenFactory?.Invoke(req) ?? Guid.NewGuid().ToString()}}" }""");
                    }
                }
                else if (transportConfig.ResponseHandler != null)
                {
                    transportConfig.ResponseHandler(req, response);
                }

                if (transportConfig.RequestValidator != null)
                {
                    transportConfig.RequestValidator(req);
                }
                return response;
            };
        }

        public class AllowedTenantsTestParameters
        {
            public string TenantId { get; set; }
            public List<string> AdditionallyAllowedTenants { get; set; }
            public TokenRequestContext TokenRequestContext { get; set; }

            public string ToDebugString()
            {
                return $"TenantId:{TenantId ?? "null"}, AddlTenants:[{string.Join(",", AdditionallyAllowedTenants)}], RequestedTenantId:{TokenRequestContext.TenantId ?? "null"}";
            }

            // This is required for NUnit to display the test cases correctly in dotnet test output
            public override string ToString()
            {
                return ToDebugString();
            }
        }

        public static readonly char[] NegativeTestCharacters = new char[] { '|', '&', ';', '\'', '"', '!', '@', '$', '%', '^', '*', '(', ')', '=', '[', ']', '{', '}', '<', '>', '?' };

        public static IEnumerable<AllowedTenantsTestParameters> GetAllowedTenantsTestCases()
        {
            string tenant = Guid.NewGuid().ToString();
            string addlTenantA = Guid.NewGuid().ToString();
            string addlTenantB = Guid.NewGuid().ToString();

            List<string> tenantValues = new List<string>() { tenant, null };

            List<List<string>> additionalAllowedTenantsValues = new List<List<string>>()
            {
                new List<string>(),
                new List<string> { addlTenantA, addlTenantB },
                new List<string> { "*" },
                new List<string> { addlTenantA, "*", addlTenantB }
            };

            List<TokenRequestContext> tokenRequestContextValues = new List<TokenRequestContext>()
            {
                new TokenRequestContext(MockScopes.Default),
                new TokenRequestContext(MockScopes.Default, tenantId: tenant),
                new TokenRequestContext(MockScopes.Default, tenantId: addlTenantA),
                new TokenRequestContext(MockScopes.Default, tenantId: addlTenantB),
                new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()),
            };

            foreach (var mainTenant in tenantValues)
            {
                foreach (var additoinallyAllowedTenants in additionalAllowedTenantsValues)
                {
                    foreach (var tokenRequestContext in tokenRequestContextValues)
                    {
                        yield return new AllowedTenantsTestParameters { TenantId = mainTenant, AdditionallyAllowedTenants = additoinallyAllowedTenants, TokenRequestContext = tokenRequestContext };
                    }
                }
            }
        }

        public void TestSetup(TokenCredentialOptions options = null)
        {
            expectedTenantId = null;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            options = options ?? new TokenCredentialOptions();
            InitMockAuthenticationResult();

            mockConfidentialMsalClient = new MockMsalConfidentialClient(null, null, null, null, null, options)
                .WithSilentFactory(
                    (_, _, _tenantId, _replyUri, _, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithAuthCodeFactory(
                    (_a, _b, _tenantId, _replyUri, _c, _d) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return result;
                    })
                .WithOnBehalfOfFactory(
                    (_, _, userAssertion, _, _, _, _) =>
                    {
                        Assert.AreEqual(expectedUserAssertion, userAssertion.Assertion);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithClientFactory(
                    (_, _tenantId, _, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        return result;
                    });

            expectedCode = Guid.NewGuid().ToString();
            mockPublicMsalClient = new MockMsalPublicClient(null, null, null, null, options);
            deviceCodeResult = MockMsalPublicClient.GetDeviceCodeResult(deviceCode: expectedCode);
            mockPublicMsalClient.DeviceCodeResult = deviceCodeResult;
            var publicResult = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
            mockPublicMsalClient.DeviceCodeAuthFactory = (_, _, _, _, _) =>
            {
                // Assert.AreEqual(tenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.InteractiveAuthFactory = (_, _, _, _, tenant, _, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.SilentAuthFactory = (_, _, _, tenant, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.ExtendedSilentAuthFactory = (_, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.UserPassAuthFactory = (_, _, _, _, tenant, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.RefreshTokenFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
        }

        private void InitMockAuthenticationResult()
        {
            expectedToken = TokenGenerator.GenerateToken(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.UtcNow.AddHours(1));
            expectedUserAssertion = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
        }

        protected async Task<string> ReadMockRequestContent(MockRequest request)
        {
            if (request.Content == null)
            {
                return null;
            }

            using var memoryStream = new MemoryStream();
            request.Content.WriteTo(memoryStream, CancellationToken.None);
            memoryStream.Position = 0;
            using (var streamReader = new StreamReader(memoryStream))
            {
                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public static Action<object> GetExceptionAction(Exception exceptionToThrow)
        {
            return (p) => throw exceptionToThrow;
        }

        public class CommonCredentialTestConfig : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsDisableInstanceDiscovery
        {
            public bool DisableInstanceDiscovery { get; set; }
            public TokenRequestContext RequestContext { get; set; }
            public string TenantId { get; set; }
            public IList<string> AdditionallyAllowedTenants { get; set; } = new List<string>();
            public Uri RedirectUri { get; set; }
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
            public AuthenticationRecord AuthenticationRecord { get; set; }
            public TransportConfig TransportConfig { get; set; }
            internal TenantIdResolverBase TestTentantIdResolver { get; set; }
            internal MockMsalConfidentialClient MockConfidentialMsalClient { get; set; }
            internal MockMsalPublicClient MockPublicMsalClient { get; set; }
        }

        public class Claims
        {
            public Wrapper access_token { get; set; }
            public class Wrapper
            {
                public XmsCc xms_cc { get; set; }
            }

            public class XmsCc
            {
                public string[] values { get; set; }
            }
        }

        public class CaeClaim
        {
            public AccessTokenPart access_token { get; set; }

            public CaeClaim(bool isEssential = true, string value = "1701724716")
            {
                access_token = new AccessTokenPart { nbf = new Nbf { essential = isEssential, value = value } };
            }
            public override string ToString()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
        }

        public class AccessTokenPart
        {
            public Nbf nbf { get; set; }
        }

        public class Nbf
        {
            public bool essential { get; set; }
            public string value { get; set; }
        }
    }
}
