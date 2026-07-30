// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture]
    public class GitHubActionsTokenCredentialTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("not-a-url")]
        public void GetTokenValidatesRequestUrl(string requestUrl)
        {
            var credential = new GitHubActionsTokenCredential(
                options: new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = requestUrl,
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var exception = Assert.Throws<CredentialUnavailableException>(() => credential.GetToken(new TokenRequestContext(["scope"]), CancellationToken.None));

            Assert.That(exception.Message, Does.Contain(GitHubActionsTokenCredentialOptions.ActionsRequestUrlKey));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetTokenValidatesRequestToken(string requestToken)
        {
            var credential = new GitHubActionsTokenCredential(
                options: new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = requestToken,
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var exception = Assert.Throws<CredentialUnavailableException>(() => credential.GetToken(new TokenRequestContext(["scope"]), CancellationToken.None));

            Assert.That(exception.Message, Does.Contain(GitHubActionsTokenCredentialOptions.ActionsRequestTokenKey));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetTokenValidatesAudience(string audience)
        {
            var credential = new GitHubActionsTokenCredential(
                options: new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = audience,
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var exception = Assert.Throws<ArgumentException>(() => credential.GetToken(new TokenRequestContext(["scope"]), CancellationToken.None));

            Assert.That(exception.ParamName, Is.EqualTo("IdTokenAudience"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetTokenValidatesTenantId(string tenantId)
        {
            var credential = new GitHubActionsTokenCredential(
                options: new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = tenantId,
                    ClientId = "client-id"
                });

            var exception = Assert.Throws<ArgumentException>(() => credential.GetToken(new TokenRequestContext(["scope"]), CancellationToken.None));

            Assert.That(exception.ParamName, Is.EqualTo("TenantId"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public async Task GetTokenAsyncValidatesClientId(string clientId)
        {
            var credential = new GitHubActionsTokenCredential(
                options: new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = "tenant-id",
                    ClientId = clientId
                });

            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await credential.GetTokenAsync(new TokenRequestContext(["scope"]), CancellationToken.None));

            Assert.That(exception.ParamName, Is.EqualTo("ClientId"));
        }

        [Test]
        public async Task GetIdTokenEncodesAudienceAndSetsAuthorizationHeader()
        {
            var response = new MockResponse(200).WithJson("{\"value\":\"oidc-token\"}");
            var transport = new MockTransport(response);
            var credential = CreateCredential(
                transport,
                new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://Azure Token/Exchange+value",
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var token = await InvokeGetIdTokenAsync(credential, CancellationToken.None);

            Assert.That(token, Is.EqualTo("oidc-token"));
            Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.SingleRequest.Uri.ToUri().AbsoluteUri, Is.EqualTo("https://token.actions.githubusercontent.com/?existing=1&audience=api%3A%2F%2FAzure%20Token%2FExchange%2Bvalue"));
            Assert.That(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Is.EqualTo("Bearer request-token"));
        }

        [Test]
        public void GetIdTokenThrowsWhenOidcEndpointReturnsNonSuccess()
        {
            var transport = new MockTransport(_ => new MockResponse(500));
            var credential = CreateCredential(
                transport,
                new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var exception = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await InvokeGetIdTokenAsync(credential, CancellationToken.None));

            Assert.That(exception.Message, Does.Contain("status code '500'"));
        }

        [Test]
        public void GetIdTokenThrowsWhenValueIsMissingFromResponse()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson("{\"unexpected\":\"payload\"}"));
            var credential = CreateCredential(
                transport,
                new GitHubActionsTokenCredentialOptions
                {
                    RequestToken = "request-token",
                    RequestUrl = "https://token.actions.githubusercontent.com?existing=1",
                    IdTokenAudience = "api://AzureADTokenExchange",
                    TenantId = "tenant-id",
                    ClientId = "client-id"
                });

            var exception = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await InvokeGetIdTokenAsync(credential, CancellationToken.None));

            Assert.That(exception.Message, Does.Contain("OIDC token not found in response."));
        }

        private static GitHubActionsTokenCredential CreateCredential(MockTransport transport, GitHubActionsTokenCredentialOptions options)
        {
            options.Transport = transport;
            var pipeline = CredentialPipeline.GetInstance(options);
            return new GitHubActionsTokenCredential(pipeline, options);
        }

        private static async Task<string> InvokeGetIdTokenAsync(GitHubActionsTokenCredential credential, CancellationToken cancellationToken)
        {
            var method = typeof(GitHubActionsTokenCredential).GetMethod("GetIdToken", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(method, Is.Not.Null);

            var task = (Task<string>)method.Invoke(credential, [cancellationToken]);
            return await task.ConfigureAwait(false);
        }
    }
}
