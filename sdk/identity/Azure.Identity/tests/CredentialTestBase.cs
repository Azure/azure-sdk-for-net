// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Gee.External.Capstone.M68K;
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
                IsUnsafeSupportLoggingEnabled = isSupportLoggingEnabled
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore($"{credential.GetType().Name} is not an MSAL credential.");
            }
            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreEqual(token, actualToken.Token);
            string expectedPrefix = isSupportLoggingEnabled ? "True" : "False";
            Assert.True(_listener.EventData.Any(d => d.Payload.Any(p => p.ToString().StartsWith($"{expectedPrefix} MSAL"))));
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
            };
            var credential = GetTokenCredential(config);
            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, null), default);

            Assert.AreNotEqual(disable, calledDiscoveryEndpoint);
            Assert.AreEqual(token, actualToken.Token);
        }

        [Test]
        public void VerifyAllowedTenantEnforcementCredentials()
        {
            // Configure the transport
            var token = Guid.NewGuid().ToString();
            string resolvedTenantId = TenantId;
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

            var mockResolver = new Mock<TenantIdResolverBase>() { CallBase = true };
            var config = new CommonCredentialTestConfig()
            {
                Transport = mockTransport,
                TenantId = TenantId,
                RequestContext = new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()),
                AdditionallyAllowedTenants = new List<string> { Guid.NewGuid().ToString() },
                TestTentantIdResolver = mockResolver.Object
            };
            var credential = GetTokenCredential(config);

            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

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
            var idToken = CredentialTestHelpers.CreateMsalIdToken(Guid.NewGuid().ToString(), "userName", TenantId);
            bool calledDiscoveryEndpoint = false;
            bool isPubClient = false;
            bool observedCae = false;
            bool observedNoCae = false;

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
                    if (isPubClient || typeof(TCredOptions) == typeof(AuthorizationCodeCredentialOptions) || typeof(TCredOptions) == typeof(OnBehalfOfCredentialOptions))
                    {
                        response = CredentialTestHelpers.CreateMockMsalTokenResponse(200, token, TenantId, ExpectedUsername, ObjectId);
                    }
                    else
                    {
                        response.SetContent($"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"{token}\" }}");
                    }
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

                return response;
            });

            var config = new CommonCredentialTestConfig()
            {
                Transport = mockTransport,
                TenantId = TenantId,
            };
            var credential = GetTokenCredential(config);
            if (!CredentialTestHelpers.IsMsalCredential(credential))
            {
                Assert.Ignore("EnableCAE tests do not apply to the non-MSAL credentials.");
            }
            isPubClient = CredentialTestHelpers.IsCredentialTypePubClient(credential);

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
            var config = new CommonCredentialTestConfig()
            {
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

        public class CommonCredentialTestConfig : TokenCredentialOptions, ISupportsAdditionallyAllowedTenants, ISupportsDisableInstanceDiscovery
        {
            public bool DisableInstanceDiscovery { get; set; }
            public TokenRequestContext RequestContext { get; set; }
            public string TenantId { get; set; }
            public IList<string> AdditionallyAllowedTenants { get; set; } = new List<string>();
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
