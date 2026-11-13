// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    /// <summary>
    /// Tests for BrokerCredential when the Azure.Identity.Broker package is available.
    /// In this project, the broker is enabled, so BrokerCredential goes through the
    /// MSAL/broker authentication flow. GetToken may succeed on machines with an active
    /// broker account, so exception-asserting tests use a non-existent tenant to force failure.
    /// </summary>
    internal class BrokerCredentialTests
    {
        private static readonly string s_invalidTenantId = "00000000-0000-0000-0000-000000000000";
        private static readonly TokenRequestContext s_requestContext = new(new[] { "https://management.azure.com/.default" });

        #region Virtual Factory Methods
        protected virtual TokenCredential CreateCredential(string tenantId = null, bool addTenantIdHint = false)
        {
            var options = new DevelopmentBrokerOptions();
            if (tenantId != null)
            {
                options.TenantId = tenantId;
            }
            if (addTenantIdHint)
            {
                options.AdditionallyAllowedTenants.Add("*");
            }
            return new BrokerCredential(options);
        }

        protected virtual TokenCredential CreateBareCredential()
            => new BrokerCredential(new DevelopmentBrokerOptions());

        protected virtual void CreateCredentialForTenantValidation(string tenantId)
            => new BrokerCredential(new DevelopmentBrokerOptions { TenantId = tenantId });

        protected virtual Type GetExpectedExceptionType(bool isChained)
            => typeof(CredentialUnavailableException);
        #endregion

        [Test]
        public void GetToken_WithInvalidTenant_ThrowsCredentialUnavailableException()
        {
            var credential = CreateCredential(tenantId: s_invalidTenantId);
            var ex = Assert.Throws<CredentialUnavailableException>(() =>
                credential.GetToken(s_requestContext, default));
            Assert.That(ex.Message, Does.Contain("BrokerCredential"));
        }

        [Test]
        public async Task GetTokenAsync_WithInvalidTenant_ThrowsCredentialUnavailableException()
        {
            var credential = CreateCredential(tenantId: s_invalidTenantId);
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () =>
                await credential.GetTokenAsync(s_requestContext, default));
            Assert.That(ex.Message, Does.Contain("BrokerCredential"));
        }

        [Test]
        public void GetToken_ExceptionType_MatchesExpected([Values(true, false)] bool isChained)
        {
            var credential = CreateCredential(tenantId: s_invalidTenantId);
            var expectedType = GetExpectedExceptionType(isChained);
            Assert.Throws(expectedType, () =>
                credential.GetToken(s_requestContext, default));
        }

        [Test]
        public void CanCreateCredential()
        {
            var credential = CreateBareCredential();
            Assert.IsNotNull(credential);
        }

        [Test]
        public void CanCreateCredentialWithTenantId()
        {
            var credential = CreateCredential(tenantId: Guid.NewGuid().ToString());
            Assert.IsNotNull(credential);
        }

        [Test]
        public void CanCreateCredentialWithAdditionalTenants()
        {
            var credential = CreateCredential(addTenantIdHint: true);
            Assert.IsNotNull(credential);
        }

        [Test]
        public void BrokerIsEnabled()
        {
            // Verify the broker package is available in this test project
            bool success = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            Assert.IsTrue(success, "Broker package should be available in this test project");
            Assert.IsNotNull(options);
        }
    }
}
