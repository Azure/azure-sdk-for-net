// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
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
        protected string expectedUserAssertion;
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

            // Configure the transport
            var token = Guid.NewGuid().ToString();
            var idToken = CredentialTestHelpers.CreateMsalIdToken(Guid.NewGuid().ToString(), "userName", TenantId);
            bool calledDiscoveryEndpoint = false;
            bool isPubClient = false;
            var mockTransport = new MockTransport(req =>
            {
                calledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");

                MockResponse response = new(200);
                if (req.Uri.Path.EndsWith("/devicecode"))
                {
                    response = CredentialTestHelpers.CreateMockMsalDeviceCodeResponse();
                }
                else if (req.Uri.Path.Contains("/userrealm/"))
                {
                    response.SetContent(UserrealmResponse);
                }
                else
                {
                    if (isPubClient || typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions))
                    {
                        response = CredentialTestHelpers.CreateMockMsalTokenResponse(200, token, TenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
                    }
                }

                return response;
            });

            var config = new CommonCredentialTestConfig()
            {
                DisableInstanceDiscovery = disable,
                Transport = mockTransport,
                TenantId = TenantId,
                ResolvedTenantId = TenantId,
            };
            // Configure mock cache to return a token for the expected user
            byte[] mockBytes = null;
            var tokenCacheOptions = new MockTokenCache(
                () => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes),
                args => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes));
            config.TokenCachePersistenceOptions = tokenCacheOptions;
            var credential = GetTokenCredential(config);
            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            mockBytes = isPubClient switch
            {
                false => CredentialTestHelpers.GetMockCacheBytesAccessTokenOnly(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token"),
                _ => CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token", "refreshToken")
            };

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreNotEqual(disable, calledDiscoveryEndpoint);
            Assert.AreEqual(token, actualToken.Token);
        }

        [TestCaseSource(nameof(GetAllowedTenantsTestCases))]
        public async Task VerifyAllowedTenantEnforcementCredentials(AllowedTenantsTestParameters parameters)
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            string resolvedTenantId = parameters.TokenRequestContext.TenantId ?? parameters.TenantId ?? TenantId;
            var idToken = CredentialTestHelpers.CreateMsalIdToken(Guid.NewGuid().ToString(), "userName", resolvedTenantId);
            bool calledDiscoveryEndpoint = false;
            bool isPubClient = false;
            var mockTransport = new MockTransport(req =>
            {
                calledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");

                MockResponse response = new(200);
                if (req.Uri.Path.EndsWith("/devicecode"))
                {
                    response = CredentialTestHelpers.CreateMockMsalDeviceCodeResponse();
                }
                else if (req.Uri.Path.Contains("/userrealm/"))
                {
                    response.SetContent(UserrealmResponse);
                }
                else
                {
                    if (isPubClient || typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions))
                    {
                        response = CredentialTestHelpers.CreateMockMsalTokenResponse(200, token, resolvedTenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
                    }
                }

                return response;
            });

            var config = new CommonCredentialTestConfig()
            {
                Transport = mockTransport,
                TenantId = parameters.TenantId,
                ResolvedTenantId = resolvedTenantId,
                RequestContext = parameters.TokenRequestContext,
                AdditionallyAllowedTenants = parameters.AdditionallyAllowedTenants
            };
            // Configure mock cache to return a token for the expected user
            byte[] mockBytes = null;
            var tokenCacheOptions = new MockTokenCache(
                () => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes),
                args => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes));
            config.TokenCachePersistenceOptions = tokenCacheOptions;
            var credential = GetTokenCredential(config);

            if (credential is SharedTokenCacheCredential)
            {
                Assert.Ignore("Tenant Enforcement tests do not apply to the SharedTokenCacheCredential.");
            }

            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            mockBytes = isPubClient switch
            {
                false => CredentialTestHelpers.GetMockCacheBytesAccessTokenOnly(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token"),
                _ => CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token", "refreshToken")
            };
            await AssertAllowedTenantIdsEnforcedAsync(parameters, credential);
        }

        [Test]
        public async Task VerifyClearAccountCacheClearsCache()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            var idToken = CredentialTestHelpers.CreateMsalIdToken(Guid.NewGuid().ToString(), "userName", TenantId);
            bool calledDiscoveryEndpoint = false;
            bool isPubClient = false;
            var mockTransport = new MockTransport(req =>
            {
                calledDiscoveryEndpoint |= req.Uri.Path.Contains("discovery/instance");

                MockResponse response = new(200);
                if (req.Uri.Path.EndsWith("/devicecode"))
                {
                    response = CredentialTestHelpers.CreateMockMsalDeviceCodeResponse();
                }
                else if (req.Uri.Path.Contains("/userrealm/"))
                {
                    response.SetContent(UserrealmResponse);
                }
                else
                {
                    if (isPubClient || typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions))
                    {
                        response = CredentialTestHelpers.CreateMockMsalTokenResponse(200, token, TenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
                    }
                }

                return response;
            });

            var config = new CommonCredentialTestConfig()
            {
                Transport = mockTransport,
                TenantId = TenantId,
                ResolvedTenantId = TenantId,
                RequestContext = new TokenRequestContext(MockScopes.Default),
                AdditionallyAllowedTenants = null,
                DisableInstanceDiscovery = false
            };
            // Configure mock cache to return a token for the expected user
            bool calledRemoveUser = false;
            bool cacheAccessed = false;
            config.ResolvedTenantId = config.RequestContext.TenantId ?? config.TenantId ?? TenantId;
            byte[] mockBytes = null;
            var tokenCacheOptions = new MockTokenCache(
                () => Task.FromResult<ReadOnlyMemory<byte>>(mockBytes),
                args =>
                {
                    cacheAccessed = true;
                    int accessTokenCount = 0;
                    using var json = JsonDocument.Parse(args.UnsafeCacheData);
                    var accessTokenElement = json.RootElement.GetProperty("AccessToken");
                    foreach (var prop in accessTokenElement.EnumerateObject())
                    {
                        Console.WriteLine(prop.Name);
                        accessTokenCount++;
                    }

                    if (calledRemoveUser)
                    {
                        Assert.AreEqual(0, accessTokenCount, "The cache should be empty after calling RemoveUser");
                    }
                    else
                    {
                        Assert.GreaterOrEqual(accessTokenCount, 0, "The cache should contain at least one access token");
                    }
                    return Task.FromResult<ReadOnlyMemory<byte>>(mockBytes);
                });
            config.TokenCachePersistenceOptions = tokenCacheOptions;
            TokenCredential credential = GetTokenCredential(config);
            if (credential is ISupportsClearAccountCache clearCacheCredential)
            {
                isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
                mockBytes = isPubClient switch
                {
                    false => CredentialTestHelpers.GetMockCacheBytesAccessTokenOnly(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token"),
                    _ => CredentialTestHelpers.GetMockCacheBytes(ObjectId, ExpectedUsername, ClientId, config.ResolvedTenantId, "token", "refreshToken")
                };
                await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default).ConfigureAwait(false);
                calledRemoveUser = true;
                await clearCacheCredential.ClearAccountCacheAsync();
                Assert.IsTrue(cacheAccessed, "The cache should have been accessed.");
            }
            else
            {
                Assert.Ignore("ClearAccountCacheAsync is not supported by this credential.");
            }
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

        public static async Task AssertAllowedTenantIdsEnforcedAsync(AllowedTenantsTestParameters parameters, TokenCredential credential)
        {
            bool expAllowed = parameters.TenantId == null
                || parameters.TokenRequestContext.TenantId == null
                || parameters.TenantId == parameters.TokenRequestContext.TenantId
                || parameters.AdditionallyAllowedTenants.Contains(parameters.TokenRequestContext.TenantId)
                || parameters.AdditionallyAllowedTenants.Contains("*");

            if (expAllowed)
            {
                var accessToken = await credential.GetTokenAsync(parameters.TokenRequestContext, default);

                Assert.IsNotNull(accessToken.Token);
            }
            else
            {
                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => { await credential.GetTokenAsync(parameters.TokenRequestContext, default); });

                StringAssert.Contains($"The current credential is not configured to acquire tokens for tenant {parameters.TokenRequestContext.TenantId}", ex.Message);
            }
        }

        public void TestSetup(TokenCredentialOptions options = null)
        {
            expectedTenantId = null;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            options = options ?? new TokenCredentialOptions();
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

            mockConfidentialMsalClient = new MockMsalConfidentialClient(null, null, null, null, null, options)
                .WithSilentFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithAuthCodeFactory(
                    (_, _tenantId, _replyUri, _) =>
                    {
                        Assert.AreEqual(expectedTenantId, _tenantId);
                        Assert.AreEqual(expectedReplyUri, _replyUri);
                        return result;
                    })
                .WithOnBehalfOfFactory(
                    (_, _, userAssertion, _, _) =>
                    {
                        Assert.AreEqual(expectedUserAssertion, userAssertion.Assertion);
                        return new ValueTask<AuthenticationResult>(result);
                    })
                .WithClientFactory(
                    (_, _tenantId) =>
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
            mockPublicMsalClient.SilentAuthFactory = (_, tId) =>
            {
                Assert.AreEqual(expectedTenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.DeviceCodeAuthFactory = (_, _) =>
            {
                // Assert.AreEqual(tenantId, tId);
                return publicResult;
            };
            mockPublicMsalClient.InteractiveAuthFactory = (_, _, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.SilentAuthFactory = (_, tenant) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.ExtendedSilentAuthFactory = (_, _, _, tenant, _, _) =>
            {
                Assert.AreEqual(expectedTenantId, tenant, "TenantId passed to msal should match");
                return result;
            };
            mockPublicMsalClient.UserPassAuthFactory = (_, tenant) =>
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

        public class CommonCredentialTestConfig : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsDisableInstanceDiscovery
        {
            public bool DisableInstanceDiscovery { get; set; }
            public TokenRequestContext RequestContext { get; set; }
            public string TenantId { get; set; }
            public IList<string> AdditionallyAllowedTenants { get; set; } = new List<string>();
            public string ResolvedTenantId { get; set; }
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
