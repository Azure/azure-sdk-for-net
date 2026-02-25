// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class ManagedIdentityCredentialTests : ClientTestBase
    {
        protected string _expectedResourceId = $"/subscriptions/{Guid.NewGuid().ToString()}/locations/MyLocation";

        public ManagedIdentityCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        protected const string ExpectedToken = "mock-msi-access-token";

        /// <summary>
        /// Checks whether the exception or any of its inner exceptions contain the given message.
        /// This is needed because the ConfigurableCredential path wraps exceptions through DAC,
        /// which may bury the original message in inner exceptions.
        /// </summary>
        protected static bool ExceptionChainContains(Exception ex, string message)
        {
            while (ex != null)
            {
                if (ex.Message.Contains(message))
                    return true;
                ex = ex.InnerException;
            }
            return false;
        }

        #region Private Helpers

        private static ManagedIdentityId ResolveManagedIdentityId(string clientId = null, string resourceId = null)
        {
            if (!string.IsNullOrEmpty(clientId))
                return ManagedIdentityId.FromUserAssignedClientId(clientId);
            if (!string.IsNullOrEmpty(resourceId))
                return ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(resourceId));
            return ManagedIdentityId.SystemAssigned;
        }

        private TokenCredential BuildManagedIdentityCredential(
            TokenCredentialOptions options,
            ManagedIdentityId managedIdentityId,
            bool isForceRefreshEnabled = true,
            bool isManagedIdentityPipeline = false,
            bool preserveTransport = true)
        {
            var pipeline = CredentialPipeline.GetInstance(options, isManagedIdentityPipeline);
            return InstrumentClient(new ManagedIdentityCredential(
                new ManagedIdentityClient(
                    new ManagedIdentityClientOptions
                    {
                        Pipeline = pipeline,
                        ManagedIdentityId = managedIdentityId,
                        IsForceRefreshEnabled = isForceRefreshEnabled,
                        PreserveTransport = preserveTransport,
                        Options = options
                    })));
        }

        #endregion

        #region Virtual Factory Methods

        protected virtual TokenCredential CreateCredentialForImds(
            MockTransport transport,
            string clientId = null,
            bool isChained = false,
            bool isForceRefreshEnabled = true,
            Uri authorityHost = null)
        {
            var options = new TokenCredentialOptions { Transport = transport, IsChainedCredential = isChained };
            if (authorityHost != null) options.AuthorityHost = authorityHost;
            return BuildManagedIdentityCredential(options, ResolveManagedIdentityId(clientId), isForceRefreshEnabled);
        }

        protected virtual TokenCredential CreateCredentialForImdsWithResourceId(
            MockTransport transport,
            ResourceIdentifier resourceId,
            bool isChained = false,
            bool isForceRefreshEnabled = true)
        {
            var options = new TokenCredentialOptions { Transport = transport, IsChainedCredential = isChained };
            return BuildManagedIdentityCredential(options, ManagedIdentityId.FromUserAssignedResourceId(resourceId), isForceRefreshEnabled);
        }

        protected virtual TokenCredential CreateBareCredentialWithOptions(TokenCredentialOptions options)
            => InstrumentClient(new ManagedIdentityCredential(options: options));

        protected virtual TokenCredential CreateCredentialForNonImdsSource(
            MockTransport transport,
            string clientId = null,
            string resourceId = null,
            bool isForceRefreshEnabled = true,
            TimeSpan? maxRetryDelay = null)
        {
            var options = new TokenCredentialOptions { Transport = transport };
            if (maxRetryDelay.HasValue) options.Retry.MaxDelay = maxRetryDelay.Value;
            return BuildManagedIdentityCredential(options, ResolveManagedIdentityId(clientId, resourceId), isForceRefreshEnabled, preserveTransport: false);
        }

        protected virtual TokenCredential CreateCredentialForImdsWithRetryOptions(
            MockTransport transport,
            string clientId = null,
            bool isChained = false,
            bool isForceRefreshEnabled = true,
            bool isManagedIdentityPipeline = false,
            TimeSpan? maxRetryDelay = null,
            TimeSpan? retryDelay = null,
            RetryMode? retryMode = null,
            TimeSpan? networkTimeout = null)
        {
            var options = new TokenCredentialOptions { Transport = transport, IsChainedCredential = isChained };
            if (maxRetryDelay.HasValue) options.Retry.MaxDelay = maxRetryDelay.Value;
            if (retryDelay.HasValue) options.Retry.Delay = retryDelay.Value;
            if (retryMode.HasValue) options.Retry.Mode = retryMode.Value;
            if (networkTimeout.HasValue) options.Retry.NetworkTimeout = networkTimeout.Value;
            return BuildManagedIdentityCredential(options, ResolveManagedIdentityId(clientId), isForceRefreshEnabled, isManagedIdentityPipeline);
        }

        protected virtual TokenCredential CreateCredentialWithManagedIdentityId(
            MockTransport transport,
            ManagedIdentityId managedIdentityId,
            bool isForceRefreshEnabled = true)
        {
            var options = new TokenCredentialOptions { Transport = transport };
            return BuildManagedIdentityCredential(options, managedIdentityId, isForceRefreshEnabled);
        }

        protected virtual MockResponse CreateSuccessResponse(string token)
            => CreateMockResponse(200, token);

        internal virtual TokenCredential CreateCredentialWithMockClient(ManagedIdentityClient mockClient)
            => InstrumentClient(new ManagedIdentityCredential(mockClient));

        protected virtual Type GetExpectedExceptionType(bool isChained)
            => isChained ? typeof(CredentialUnavailableException) : typeof(AuthenticationFailedException);

        protected virtual bool IsChainedCredentialSupported => true;

        private void SkipIfChainedNotSupported()
        {
            if (!IsChainedCredentialSupported)
            {
                Assert.Ignore("ConfigurableCredential does not support chained credential scenarios yet. See https://github.com/Azure/azure-sdk-for-net/issues/56233");
            }
        }

        #endregion

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestWithClientIdMock()
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var initialResponse = CreateErrorMockResponse(400, "mock error");
            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(initialResponse, response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));
            Assert.IsTrue(query.Contains($"{Constants.ManagedIdentityClientId}=mock-client-id"));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsSendsProbeOnlyOnFirstRequest()
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            int probeCount = 0;
            var mockTransport = new MockTransport(req =>
            {
                if (!req.Headers.TryGetValue("Metadata", out var _))
                {
                    probeCount++;
                    return CreateErrorMockResponse(400, "mock error");
                }
                else
                {
                    return CreateSuccessResponse(ExpectedToken);
                }
            });
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
            Assert.AreEqual(1, probeCount, "Probe was sent more than once.");
        }

        [NonParallelizable]
        [Test]
        public async Task ImdsWithEmptyClientIdIsIgnoredMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImds(mockTransport);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
        }

        [NonParallelizable]
        [Test]
        [TestCase(null)]
        [TestCase("Auto-Detect")]
        [TestCase("eastus")]
        [TestCase("westus")]
        public async Task VerifyImdsRequestWithClientIdAndRegionalAuthorityNameMockAsync(string regionName)
        {
            using var environment = new TestEnvVar(new() { { "AZURE_REGIONAL_AUTHORITY_NAME", regionName }, { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(req => CreateSuccessResponse(ExpectedToken));
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id");

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(AuthorityHostValues))]
        public async Task VerifyImdsRequestWithClientIdAndNonPubCloudMockAsync(Uri authority)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", authorityHost: authority);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, tenantId: Guid.NewGuid().ToString()), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.IsTrue(query.Contains($"{Constants.ManagedIdentityClientId}=mock-client-id"));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestWithResourceIdMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);

            var credential = CreateCredentialForImdsWithResourceId(mockTransport, new ResourceIdentifier(_expectedResourceId));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.That(Uri.UnescapeDataString(query), Does.Contain($"_res_id={_expectedResourceId}"));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestWithObjectIdMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var expectedObjectId = Guid.NewGuid().ToString();

            var credential = CreateCredentialWithManagedIdentityId(mockTransport, ManagedIdentityId.FromUserAssignedObjectId(expectedObjectId));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            Assert.That(Uri.UnescapeDataString(query), Does.Contain($"object_id={expectedObjectId}"));
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(ResourceAndClientIds))]
        public async Task VerifyServiceFabricRequestWithResourceIdMockAsync(string clientId, bool includeResourceIdentifier)
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", "https://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01" },
                    { "IDENTITY_HEADER", "header" },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null },
                    { "IDENTITY_SERVER_THUMBPRINT", "thumbprint" }
                });

            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Warning);

            var mockTransport = new MockTransport(req =>
            {
                return CreateSuccessResponse(ExpectedToken);
            });

            ManagedIdentityId miId = (clientId, includeResourceIdentifier) switch
            {
                (Item1: null, Item2: true) => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(_expectedResourceId)),
                (Item1: not null, Item2: false) => ManagedIdentityId.FromUserAssignedClientId(clientId),
                _ => ManagedIdentityId.SystemAssigned
            };
            var credential = CreateCredentialWithManagedIdentityId(mockTransport, miId);

            if (clientId != null || includeResourceIdentifier)
            {
                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
                Assert.That(ex.Message, Does.Contain(Constants.MiSeviceFabricNoUserAssignedIdentityMessage));
                return;
            }

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "169.254.169.254");
            Assert.AreEqual(request.Uri.Path, "/metadata/identity/oauth2/token");
            Assert.IsTrue(query.Contains("api-version=2018-02-01"));
            if (includeResourceIdentifier)
            {
                Assert.That(query, Does.Contain($"{Constants.ManagedIdentityResourceId}={_expectedResourceId}"));
            }
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(ResourceAndClientIds))]
        public async Task VerifyArcRequestWithResourceIdMockAsync(string clientId, bool includeResourceIdentifier)
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", "https://identity.constoso.com" },
                    { "IMDS_ENDPOINT", "https://imds.constoso.com" },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });

            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Warning);

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);

            ManagedIdentityId miId = (clientId, includeResourceIdentifier) switch
            {
                (Item1: null, Item2: true) => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(_expectedResourceId)),
                (Item1: not null, Item2: false) => ManagedIdentityId.FromUserAssignedClientId(clientId),
                _ => ManagedIdentityId.SystemAssigned
            };
            var credential = CreateCredentialWithManagedIdentityId(mockTransport, miId);

            if (clientId != null || includeResourceIdentifier)
            {
                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
                Assert.That(ex.Message, Does.Contain(Constants.MiSourceNoUserAssignedIdentityMessage));
                return;
            }

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[0];

            string query = request.Uri.Query;

            Assert.AreEqual(request.Uri.Host, "identity.constoso.com");
            Assert.That(query, Does.Contain($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"), $"Unexpected query: {query}");
            if (includeResourceIdentifier)
            {
                Assert.That(query, Does.Contain($"{Constants.ManagedIdentityResourceId}={_expectedResourceId}"));
            }
        }

        [NonParallelizable]
        [Test]
        public void VerifyImdsRequestFailurePopulatesExceptionMessage()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var expectedMessage = "No MSI found for specified ClientId/ResourceId.";
            var mockTransport = new MockTransport(req => CreateErrorMockResponse(404, expectedMessage));
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id");

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.IsTrue(ExceptionChainContains(ex, expectedMessage));
        }

        [NonParallelizable]
        [Test]
        [TestCase("connecting to 169.254.169.254:80: connecting to 169.254.169.254:80: dial tcp 169.254.169.254:80: connectex: A socket operation was attempted to an unreachable host")]
        [TestCase("connecting to 169.254.169.254:80: connecting to 169.254.169.254:80: dial tcp 169.254.169.254:80: connectex: A socket operation was attempted to an unreachable network")]
        [TestCase("connecting to 169.254.169.254:80: connecting to 169.254.169.254:80: dial tcp 169.254.169.254:80: connectex: A socket operation was attempted to an unreachable foo")]
        [TestCase("<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\"><html>Some html</html>")]
        [TestCase(null)]
        public void VerifyImdsRequestFailureForDockerDesktopThrowsCUE(string error)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var expectedMessage = error;
            var response = CreateInvalidJsonResponse(403, expectedMessage);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            if (expectedMessage != null)
            {
                Assert.That(ExceptionChainContains(ex, expectedMessage));
            }
        }

        [NonParallelizable]
        [Test]
        public void VerifyImdsRequestFailureWithInvalidJsonPopulatesExceptionMessage()
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var expectedMessage = "Response was not in a valid json format.";
            var response = CreateInvalidJsonResponse(502);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ExceptionChainContains(ex, expectedMessage));
        }

        [NonParallelizable]
        [Test]
        [TestCase("""{"error":"invalid_request","error_description":"Identity not found"}""")]
        [TestCase(null)]
        public void VerifyImdsRequestFailureWithValidJsonIdentityNotFoundErrorThrowsCUE(string content)
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateResponse(400, content);
            var mockTransport = new MockTransport(req => response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ExceptionChainContains(ex, ImdsManagedIdentityProbeSource.IdentityUnavailableError));
        }

        [NonParallelizable]
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void VerifyImdsProbeRequestSuccessWithIdentityNotFoundErrorThrowsCUE(bool isChained)
        {
            if (isChained) SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(req =>
            {
                if (!req.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out _))
                {
                    return CreateResponse(400, """{"error":"invalid_request","error_description":"Required metadata header not specified"}""");
                }
                return CreateResponse(400, """{"error":"invalid_request","error_description":"Identity not found"}""");
            });
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: isChained);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChained), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Alternate), default));
            if (isChained)
            {
                Assert.That(ExceptionChainContains(ex, ImdsManagedIdentityProbeSource.IdentityUnavailableError));
            }
        }

        [NonParallelizable]
        [Test]
        [TestCase(502, ImdsManagedIdentityProbeSource.GatewayError)]
        public void VerifyImdsRequestHandlesFailedRequestWithCredentialUnavailableExceptionMockAsync(int responseCode, string expectedMessage)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateErrorMockResponse(responseCode, expectedMessage);
            var mockTransport = new MockTransport(req => response);
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: true);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.That(ExceptionChainContains(ex, expectedMessage));
        }

        [NonParallelizable]
        [Test]
        [TestCase(null)]
        [TestCase("mock-client-id")]
        public async Task VerifyIMDSRequestWithPodIdentityEnvVarMockAsync(string clientId)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", "https://mock.podid.endpoint/" } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(req =>
            {
                return response;
            });
            var credential = CreateCredentialForImds(mockTransport, clientId: clientId);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;

            Assert.IsTrue(request.Uri.ToString().StartsWith("https://mock.podid.endpoint" + ImdsManagedIdentityProbeSource.imddsTokenPath));

            string query = request.Uri.Query;

            Assert.That(query, Does.Contain("api-version=2018-02-01"));
            Assert.That(query, Does.Contain($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            if (clientId != null)
            {
                Assert.That(query, Does.Contain($"{Constants.ManagedIdentityClientId}=mock-client-id"));
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyIMDSRequestWithPodIdentityEnvVarResourceIdMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", "https://mock.podid.endpoint/" } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForImdsWithResourceId(mockTransport, new ResourceIdentifier(_expectedResourceId));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;

            Assert.IsTrue(request.Uri.ToString().StartsWith("https://mock.podid.endpoint" + ImdsManagedIdentityProbeSource.imddsTokenPath));

            string query = request.Uri.Query;

            Assert.That(query, Does.Contain("api-version=2018-02-01"));
            Assert.That(query, Does.Contain($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.That(Uri.UnescapeDataString(query), Does.Contain($"_res_id={_expectedResourceId}"));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyAppService2019RequestMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", "mock-msi-secret" }, { "IDENTITY_ENDPOINT", "https://identity.endpoint/" }, { "IDENTITY_HEADER", "mock-identity-header" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForNonImdsSource(mockTransport);

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, token.Token);

            MockRequest request = mockTransport.Requests[0];
            Assert.IsTrue(request.Uri.ToString().StartsWith(EnvironmentVariables.IdentityEndpoint), $"Unexpected Uri: {request.Uri}");

            string query = request.Uri.Query;
            Assert.IsTrue(query.Contains("api-version=2019-08-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.IsTrue(request.Headers.TryGetValue("X-IDENTITY-HEADER", out string identityHeader));

            Assert.AreEqual(EnvironmentVariables.IdentityHeader, identityHeader);
        }

        [NonParallelizable]
        [Test]
        public async Task AllAppServiceEnvVarsSetSelects2019Api()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", "https://mock.msi.endpoint/" }, { "MSI_SECRET", "mock-msi-secret" }, { "IDENTITY_ENDPOINT", "https://identity.endpoint/" }, { "IDENTITY_HEADER", "mock-identity-header" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForNonImdsSource(mockTransport);

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, token.Token);

            MockRequest request = mockTransport.Requests[0];
            Assert.IsTrue(request.Uri.ToString().StartsWith(EnvironmentVariables.IdentityEndpoint));

            string query = request.Uri.Query;
            Assert.IsTrue(query.Contains("api-version=2019-08-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.IsTrue(request.Headers.TryGetValue("X-IDENTITY-HEADER", out string identityHeader));

            Assert.AreEqual(EnvironmentVariables.IdentityHeader, identityHeader);
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyAppService2019RequestWithClientIdMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", "https://identity.endpoint/" }, { "IDENTITY_HEADER", "mock-identity-header" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForNonImdsSource(mockTransport, clientId: "mock-client-id");

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;
            Assert.IsTrue(request.Uri.ToString().StartsWith(EnvironmentVariables.IdentityEndpoint));

            string query = request.Uri.Query;
            Assert.IsTrue(query.Contains("api-version=2019-08-01"));
            Assert.IsTrue(query.Contains($"{Constants.ManagedIdentityClientId}=mock-client-id"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.IsTrue(request.Headers.TryGetValue("X-IDENTITY-HEADER", out string identityHeader));
            Assert.AreEqual(EnvironmentVariables.IdentityHeader, identityHeader);
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyAppService2019RequestWithResourceIdMock()
        {
            string resourceId = "resourceId";
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", "https://identity.endpoint/" }, { "IDENTITY_HEADER", "mock-identity-header" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);
            var credential = CreateCredentialForNonImdsSource(mockTransport, resourceId: resourceId);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);

            MockRequest request = mockTransport.SingleRequest;
            Assert.IsTrue(request.Uri.ToString().StartsWith(EnvironmentVariables.IdentityEndpoint));

            string query = request.Uri.Query;

            Assert.IsTrue(query.Contains("api-version=2019-08-01"));
            Assert.IsTrue(query.Contains($"resource={ScopeUtilities.ScopesToResource(MockScopes.Default)}"));
            Assert.That(query, Does.Contain($"_res_id={resourceId}"));
            Assert.IsTrue(request.Headers.TryGetValue("X-IDENTITY-HEADER", out string identityHeader));
            Assert.AreEqual(EnvironmentVariables.IdentityHeader, identityHeader);
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyCloudShellMsiRequestMock()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", "https://mock.msi.endpoint/" }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(req =>
            {
                Assert.IsTrue(req.Uri.ToString().StartsWith("https://mock.msi.endpoint/"));
                Assert.IsTrue(req.Content.TryComputeLength(out long contentLen));

                var content = new byte[contentLen];
                MemoryStream contentBuff = new MemoryStream(content);
                req.Content.WriteTo(contentBuff, default);
                string body = Encoding.UTF8.GetString(content);

                Assert.IsTrue(body.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));
                Assert.IsTrue(req.Headers.TryGetValue("Metadata", out string actMetadata));
                Assert.AreEqual("true", actMetadata);
                return response;
            });
            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var credential = CreateBareCredentialWithOptions(options);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(ResourceAndClientIds))]
        public async Task VerifyCloudShellMsiRequestWithClientIdMockAsync(string clientId, bool includeResourceIdentifier)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", "https://mock.msi.endpoint/" }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Warning);

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(req =>
            {
                Assert.IsTrue(req.Uri.ToString().StartsWith("https://mock.msi.endpoint/"), $"Unexpected Uri: {req.Uri}");
                Assert.IsTrue(req.Content.TryComputeLength(out long contentLen));

                var content = new byte[contentLen];
                MemoryStream contentBuff = new MemoryStream(content);
                req.Content.WriteTo(contentBuff, default);
                string body = Encoding.UTF8.GetString(content);

                Assert.IsTrue(body.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));
                if (clientId != null || includeResourceIdentifier)
                {
                    Assert.That(messages, Does.Contain(string.Format(AzureIdentityEventSource.UserAssignedManagedIdentityNotSupportedMessage, "Cloud Shell")));
                }
                Assert.IsTrue(req.Headers.TryGetValue("Metadata", out string actMetadata));
                Assert.AreEqual("true", actMetadata);

                return response;
            });

            ManagedIdentityId miId = (clientId, includeResourceIdentifier) switch
            {
                (Item1: null, Item2: true) => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(_expectedResourceId)),
                (Item1: not null, Item2: false) => ManagedIdentityId.FromUserAssignedClientId(clientId),
                _ => ManagedIdentityId.SystemAssigned
            };
            var credential = CreateCredentialWithManagedIdentityId(mockTransport, miId);

            if (clientId != null || includeResourceIdentifier)
            {
                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
                Assert.That(ex.Message, Does.Contain(Constants.MiSourceNoUserAssignedIdentityMessage));
                return;
            }
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyMsiUnavailableOnIMDSAggregateExcpetion()
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });
            var mockTransport = new MockTransport(req =>
            {
                throw new OperationCanceledException();
            });
            // setting the delay to 1ms and retry mode to fixed to speed up test
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, isChained: true, retryDelay: TimeSpan.FromMilliseconds(1), retryMode: RetryMode.Fixed, networkTimeout: TimeSpan.FromMilliseconds(100));

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.That(ExceptionChainContains(ex, ImdsManagedIdentityProbeSource.AggregateError));

            await Task.CompletedTask;
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyMsiUnavailableOnIMDSRequestFailedExcpetion()
        {
            SkipIfChainedNotSupported();
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(req =>
            {
                throw new TaskCanceledException();
            });
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, isChained: true, isManagedIdentityPipeline: true);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.That(ExceptionChainContains(ex, ImdsManagedIdentityProbeSource.NoResponseError));

            await Task.CompletedTask;
        }

        [NonParallelizable]
        [Test]
        public async Task ThrowsCredentialUnavailableWhenIMDSTimesOut()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(req =>
            {
                throw new MsalServiceException(MsalError.ManagedIdentityRequestFailed, "Retry failed", new RequestFailedException("Operation timed out (169.254.169.254:80"));
            });
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, isManagedIdentityPipeline: true);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.That(ex.Message, Does.Contain(ManagedIdentityClient.MsiUnavailableError));

            await Task.CompletedTask;
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyMsiUnavailableOnIMDSGatewayErrorResponse([Values(502, 504)] int statusCode)
        {
            SkipIfChainedNotSupported();
            using var server = new TestServer(context =>
            {
                context.Response.StatusCode = statusCode;
            });

            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", server.Address.AbsoluteUri } });

            // setting the delay to 1ms and retry mode to fixed to speed up test
            var options = new TokenCredentialOptions() { Retry = { Delay = TimeSpan.FromMilliseconds(0), Mode = RetryMode.Fixed }, IsChainedCredential = true };

            var credential = CreateBareCredentialWithOptions(options);

            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(true), async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.That(ExceptionChainContains(ex, ImdsManagedIdentityProbeSource.GatewayError));

            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientAuthenticateThrows()
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockClient = new MockManagedIdentityClient(CredentialPipeline.GetInstance(null)) { TokenFactory = () => throw new MockClientException("message") };

            var credential = CreateCredentialWithMockClient(mockClient);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            await Task.CompletedTask;
        }

        [Test]
        [NonParallelizable]
        public async Task VerifyClientAuthenticateReturnsInvalidJsonOnSuccess([Values(true, false)] bool isChained)
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });
            var mockTransport = new MockTransport(request => CreateInvalidJsonResponse(200));
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id", isChained: isChained);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            if (isChained && ex.InnerException is System.Text.Json.JsonException)
            {
                // Probe path wraps the parse failure as JsonException
                Assert.IsInstanceOf(typeof(System.Text.Json.JsonException), ex.InnerException);
            }
            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientAuthenticateReturnsInvalidJsonOnFailure([Values(404, 403, 429)] int status)
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });
            var mockTransport = new MockTransport(request => CreateInvalidJsonResponse(status));
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, clientId: "mock-client-id", maxRetryDelay: TimeSpan.Zero);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            await Task.CompletedTask;
        }

        [Test]
        public async Task VerifyClientAuthenticateReturnsErrorResponse()
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });
            var errorMessage = "Some error happened";
            var mockTransport = new MockTransport(request => CreateErrorMockResponse(404, errorMessage));
            var credential = CreateCredentialForImds(mockTransport, clientId: "mock-client-id");

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.IsTrue(ExceptionChainContains(ex, errorMessage));

            await Task.CompletedTask;
        }

        [Test]
        public async Task RetriesOnRetriableStatusCode([Values(404, 410, 500)] int status)
        {
            int tryCount = 0;
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", null },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });
            var errorMessage = "Some error happened";
            var mockTransport = new MockTransport(request =>
            {
                tryCount++;
                return CreateErrorMockResponse(status, errorMessage);
            });
            var credential = CreateCredentialForImdsWithRetryOptions(mockTransport, clientId: "mock-client-id", maxRetryDelay: TimeSpan.Zero, isManagedIdentityPipeline: true);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(errorMessage));
            Assert.That(tryCount, Is.EqualTo(6));

            await Task.CompletedTask;
        }

        [Test]
        public void VerifyImdsRetryDelayStrategyFor410Response()
        {
            // Arrange
            var delayStrategy = new ImdsRetryDelayStrategy();
            var mockResponse410 = new MockResponse(410);
            var mockResponse404 = new MockResponse(404);
            TimeSpan totalDelay410 = TimeSpan.Zero;
            TimeSpan totalDelay404 = TimeSpan.Zero;

            // Act - simulate the 5 retries with both status codes
            for (int retry = 1; retry <= 5; retry++)
            {
                var delay410 = delayStrategy.GetNextDelay(mockResponse410, retry);
                var delay404 = delayStrategy.GetNextDelay(mockResponse404, retry);
                totalDelay410 = totalDelay410.Add(delay410);
                totalDelay404 = totalDelay404.Add(delay404);
            }

            // Assert - 410 should have at least 70 seconds total, 404 should be standard exponential backoff with 5 retries
            Assert.That(totalDelay410.TotalSeconds, Is.GreaterThanOrEqualTo(70),
                "410 responses should have at least 70 seconds total retry duration");
            Assert.That(totalDelay404.TotalSeconds, Is.LessThan(30),
                "404 responses should use standard exponential backoff with 5 retries (~24.8 seconds)");
        }

        [Test]
        [TestCaseSource("ExceptionalEnvironmentConfigs")]
        public async Task VerifyAuthenticationFailedExceptionsAreDeferredToGetToken(Dictionary<string, string> environmentVariables)
        {
            using var environment = new TestEnvVar(environmentVariables);

            var credential = CreateCredentialForImdsWithRetryOptions(new MockTransport(req => CreateErrorMockResponse(500, "error")), isManagedIdentityPipeline: true);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));

            await Task.CompletedTask;
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, Linux = true, OSX = false, Reason = "Test is not supported on MacOS")]
        public void VerifyArcIdentitySourceFilePathValidation_DoesNotEndInDotKey()
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", "https://identity.constoso.com" },
                    { "IMDS_ENDPOINT", "https://imds.constoso.com" },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });

            var mockTransport = new MockTransport(request =>
            {
                var response = new MockResponse(401);
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    response.AddHeader("WWW-Authenticate", "file=c:\\ProgramData\\AzureConnectedMachineAgent\\Tokens\\secret.foo");
                }
                else
                {
                    response.AddHeader("WWW-Authenticate", "file=/var/opt/azcmagent/tokens/secret.foo");
                }
                return response;
            });
            var credential = CreateCredentialForNonImdsSource(mockTransport, maxRetryDelay: TimeSpan.Zero);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain("The file on the file path in the WWW-Authenticate header is not secure"));
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, Linux = true, OSX = false, Reason = "Test is not supported on MacOS")]
        public void VerifyArcIdentitySourceFilePathValidation_FilePathInvalid()
        {
            using var environment = new TestEnvVar(
                new()
                {
                    { "MSI_ENDPOINT", null },
                    { "MSI_SECRET", null },
                    { "IDENTITY_ENDPOINT", "https://identity.constoso.com" },
                    { "IMDS_ENDPOINT", "https://imds.constoso.com" },
                    { "IDENTITY_HEADER", null },
                    { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
                });

            var mockTransport = new MockTransport(request =>
            {
                var response = new MockResponse(401);
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    response.AddHeader("WWW-Authenticate", "file=c:\\ProgramData\\bugus\\AzureConnectedMachineAgent\\Tokens\\secret.key");
                }
                else
                {
                    response.AddHeader("WWW-Authenticate", "file=/var/opt/bogus/azcmagent/tokens/secret.key");
                }
                return response;
            });
            var credential = CreateCredentialForNonImdsSource(mockTransport, maxRetryDelay: TimeSpan.Zero);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain("The file on the file path in the WWW-Authenticate header is not secure"));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyTokenExchangeMsiRequestMock()
        {
            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Informational);

            var tenantId = "mock-tenant-id";
            var clientId = "mock-client-id";
            var authorityHostUrl = "https://mock.authority.com";

            var assertionAudienceBuilder = new RequestUriBuilder();
            assertionAudienceBuilder.Reset(new Uri(authorityHostUrl));
            assertionAudienceBuilder.AppendPath(tenantId);
            assertionAudienceBuilder.AppendPath("/oauth2/v2.0/token", escape: false);
            var assertionAudience = assertionAudienceBuilder.ToString();
            var assertionCertPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            string tokenFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());

#if NET9_0_OR_GREATER
            var assertionCert = X509CertificateLoader.LoadPkcs12FromFile(assertionCertPath, null);
#else
            var assertionCert = new X509Certificate2(assertionCertPath);
#endif

            File.WriteAllText(tokenFilePath, ManagedIdentityCredentialFederatedTokenLiveTests.CreateClientAssertionJWT(clientId, assertionAudience, assertionCert));

            using var environment = new TestEnvVar(new()
            {
                { "MSI_ENDPOINT", null },
                { "MSI_SECRET", null },
                { "IDENTITY_ENDPOINT", null },
                { "IDENTITY_HEADER", null },
                { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null },
                { "AZURE_CLIENT_ID", clientId },
                { "AZURE_TENANT_ID", tenantId },
                { "AZURE_AUTHORITY_HOST", authorityHostUrl },
                { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
            });

            var mockTransport = new MockTransport(req =>
            {
                if (req.Uri.ToString().Contains("mock.authority.com"))
                {
                    return CreateMockResponseWithTokeType(200, ExpectedToken);
                }
                else
                {
                    return CreateMockResponse(200, ExpectedToken);
                }
            });
            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var credential = CreateBareCredentialWithOptions(options);
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(ExpectedToken, actualToken.Token);
            Assert.That(messages, Does.Contain(string.Format(AzureIdentityEventSource.ManagedIdentitySourceAttemptedMessage, "TokenExchangeManagedIdentitySource", true)));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyTokenExchangeMsiRequestMockUsesCache()
        {
            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Informational);

            var tenantId = "mock-tenant-id";
            var clientId = "mock-client-id";
            var authorityHostUrl = "https://mock.authority.com";

            var assertionAudienceBuilder = new RequestUriBuilder();
            assertionAudienceBuilder.Reset(new Uri(authorityHostUrl));
            assertionAudienceBuilder.AppendPath(tenantId);
            assertionAudienceBuilder.AppendPath("/oauth2/v2.0/token", escape: false);
            var assertionAudience = assertionAudienceBuilder.ToString();
            var assertionCertPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            string tokenFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());

#if NET9_0_OR_GREATER
            var assertionCert = X509CertificateLoader.LoadPkcs12FromFile(assertionCertPath, null);
#else
            var assertionCert = new X509Certificate2(assertionCertPath);
#endif

            File.WriteAllText(tokenFilePath, ManagedIdentityCredentialFederatedTokenLiveTests.CreateClientAssertionJWT(clientId, assertionAudience, assertionCert));

            using var environment = new TestEnvVar(new()
            {
                { "MSI_ENDPOINT", null },
                { "MSI_SECRET", null },
                { "IDENTITY_ENDPOINT", null },
                { "IDENTITY_HEADER", null },
                { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null },
                { "AZURE_CLIENT_ID", clientId },
                { "AZURE_TENANT_ID", tenantId },
                { "AZURE_AUTHORITY_HOST", authorityHostUrl },
                { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
            });

            int callCount = 0;
            var mockTransport = new MockTransport(req =>
            {
                callCount++;
                if (req.Uri.ToString().Contains("mock.authority.com"))
                {
                    return CreateMockResponseWithTokeType(200, ExpectedToken + callCount.ToString());
                }
                else
                {
                    return CreateMockResponse(200, ExpectedToken + callCount.ToString());
                }
            });
            var options = new TokenCredentialOptions() { Transport = mockTransport };

            var credential = CreateBareCredentialWithOptions(options);
            // Fetch the token from the authority
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            // This request should be served from cache
            AccessToken secondToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            // This request changes the scope and should come from the authority
            AccessToken thirdToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Alternate), default);

            Assert.AreEqual(actualToken.Token, secondToken.Token);
            Assert.AreNotEqual(actualToken.Token, thirdToken.Token);
            Assert.That(messages, Does.Contain(string.Format(AzureIdentityEventSource.ManagedIdentitySourceAttemptedMessage, "TokenExchangeManagedIdentitySource", true)));
        }

        protected static IEnumerable<TestCaseData> ManagedIdentityIds()
        {
            yield return new TestCaseData([ManagedIdentityId.SystemAssigned, string.Format(AzureIdentityEventSource.ManagedIdentityCredentialSelectedMessage, "DefaultToImds", "SystemAssigned")]);
            yield return new TestCaseData([ManagedIdentityId.FromUserAssignedClientId("mock-client-id"), string.Format(AzureIdentityEventSource.ManagedIdentityCredentialSelectedMessage, "DefaultToImds", "ClientId mock-client-id")]);
            yield return new TestCaseData([ManagedIdentityId.FromUserAssignedObjectId("mock-object-id"), string.Format(AzureIdentityEventSource.ManagedIdentityCredentialSelectedMessage, "DefaultToImds", "ObjectId mock-object-id")]);
            yield return new TestCaseData([ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier("mock-resource-id")), string.Format(AzureIdentityEventSource.ManagedIdentityCredentialSelectedMessage, "DefaultToImds", "ResourceId mock-resource-id")]);
        }

        [NonParallelizable]
        [TestCaseSource(nameof(ManagedIdentityIds))]
        public async Task VerifyManagedIdentityIdIsLogged(ManagedIdentityId managedIdentityId, string expectedMessage)
        {
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var response = CreateSuccessResponse(ExpectedToken);
            var mockTransport = new MockTransport(response);

            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Informational);

            var credential = CreateCredentialWithManagedIdentityId(mockTransport, managedIdentityId);

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(ExpectedToken, actualToken.Token);

            Assert.That(messages, Does.Contain(expectedMessage));
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestWithCAEMock()
        {
            string caeClaims = """{"access_token":{"nbf":{"essential":true, "value":"1724337680"}}}""";
            using var environment = new TestEnvVar(new() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            var mockTransport = new MockTransport(_ => CreateSuccessResponse(Guid.NewGuid().ToString()));
            var credential = CreateCredentialForImdsWithResourceId(mockTransport, new ResourceIdentifier(_expectedResourceId), isForceRefreshEnabled: false);

            AccessToken tokenWithoutCAE1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            AccessToken tokenWithoutCAE2 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            AccessToken tokenWithCAE1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, isCaeEnabled: true, claims: caeClaims), default);
            AccessToken tokenWithoutCAE3 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            // TokenWithoutCAE1 and TokenWithoutCAE2 should be the same since subsequent calls to GetTokenAsync should return the same token if no claims were provided
            Assert.AreEqual(tokenWithoutCAE2.Token, tokenWithoutCAE1.Token);
            // TokenWithCAE1 and TokenWithoutCAE3 should be the same since subsequent calls to GetTokenAsync should return the same token if no claims were provided.
            Assert.AreEqual(tokenWithoutCAE3.Token, tokenWithCAE1.Token);
            // TokenWithCAE1 and TokenWithoutCAE1 should be different since the first token was requested with claims.
            Assert.AreNotEqual(tokenWithCAE1.Token, tokenWithoutCAE1.Token);
        }

        private static IEnumerable<TestCaseData> ResourceAndClientIds()
        {
            yield return new TestCaseData(new object[] { null, false });
            yield return new TestCaseData(new object[] { "mock-client-id", false });
            yield return new TestCaseData(new object[] { null, true });
        }

        private static IEnumerable<TestCaseData> ExceptionalEnvironmentConfigs()
        {
            // AppServiceV2017ManagedIdentitySource should throw
            yield return new TestCaseData(new Dictionary<string, string>() { { "MSI_ENDPOINT", "http::@/bogusuri" }, { "MSI_SECRET", "mocksecret" }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            // CloudShellManagedIdentitySource should throw
            yield return new TestCaseData(new Dictionary<string, string>() { { "MSI_ENDPOINT", "http::@/bogusuri" }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            // AzureArcManagedIdentitySource should throw
            yield return new TestCaseData(new Dictionary<string, string>() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", "http::@/bogusuri" }, { "IMDS_ENDPOINT", "mockvalue" }, { "IDENTITY_HEADER", null }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            // ServiceFabricManagedIdentitySource should throw
            yield return new TestCaseData(new Dictionary<string, string>() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", "http::@/bogusuri" }, { "IDENTITY_HEADER", "mockvalue" }, { "IDENTITY_SERVER_THUMBPRINT", "mockvalue" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null } });

            // ImdsManagedIdentityProbeSource should throw
            yield return new TestCaseData(new Dictionary<string, string>() { { "MSI_ENDPOINT", null }, { "MSI_SECRET", null }, { "IDENTITY_ENDPOINT", null }, { "IDENTITY_HEADER", null }, { "IDENTITY_SERVER_THUMBPRINT", "null" }, { "AZURE_POD_IDENTITY_AUTHORITY_HOST", "http::@/bogusuri" } });
        }

        public static IEnumerable<object[]> AuthorityHostValues()
        {
            // params
            // az thrown Exception message, expected message, expected  exception
            yield return new object[] { AzureAuthorityHosts.AzureChina };
            yield return new object[] { AzureAuthorityHosts.AzureGovernment };
            yield return new object[] { AzureAuthorityHosts.AzurePublicCloud };
        }

        protected MockResponse CreateMockResponse(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            response.SetContent($"{{ \"access_token\": \"{token}\", \"expires_on\": \"{DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds()}\", \"token_type\": \"Bearer\" }}");
            return response;
        }

        private MockResponse CreateMockResponseWithTokeType(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            response.SetContent($$"""{"token_type": "Bearer","expires_in": 9999,"ext_expires_in": 9999, "refresh_in": 9999,"access_token": "{{token}}" }""");
            return response;
        }

        protected MockResponse CreateErrorMockResponse(int responseCode, string message)
        {
            var response = new MockResponse(responseCode);
            response.SetContent($"{{\"statusCode\":{responseCode},\"message\":\"{message}\",\"correlationId\":\"f3c9aec0-7fa2-4184-ad0f-0c68ce5fc748\"}}");
            return response;
        }

        protected static MockResponse CreateInvalidJsonResponse(int status, string message = "invalid json")
        {
            var response = new MockResponse(status);
            if (message != null)
            {
                response.SetContent(message);
            }
            return response;
        }

        protected static MockResponse CreateResponse(int status, string message)
        {
            var response = new MockResponse(status);
            if (message != null)
            {
                response.SetContent(message);
            }
            return response;
        }
    }
}
