// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class CredentialTestBase : ClientTestBase
    {
        protected const string Scope = "https://vault.azure.net/.default";
        protected const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        protected const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        protected const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        protected const string expectedUsername = "mockuser@mockdomain.com";
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
        { }

        public void TestSetup()
        {
            expectedTenantId = null;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            options = new TokenCredentialOptions();
            expectedToken = Guid.NewGuid().ToString();
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

            mockConfidentialMsalClient = new MockMsalConfidentialClient()
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
            mockPublicMsalClient = new MockMsalPublicClient();
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
    }
}
