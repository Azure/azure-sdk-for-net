// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal class BrokerCredentialTests
    {
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
        public void GetToken_ThrowsCredentialUnavailableException()
        {
            var credential = CreateBareCredential();
            var ex = Assert.Throws<CredentialUnavailableException>(() =>
                credential.GetToken(s_requestContext, default));
            Assert.That(ex.Message, Does.Contain("Azure.Identity.Broker"));
        }

        [Test]
        public async Task GetTokenAsync_ThrowsCredentialUnavailableException()
        {
            var credential = CreateBareCredential();
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () =>
                await credential.GetTokenAsync(s_requestContext, default));
            Assert.That(ex.Message, Does.Contain("Azure.Identity.Broker"));
        }

        [Test]
        public void GetToken_WithTenantId_ThrowsCredentialUnavailableException()
        {
            var credential = CreateCredential(tenantId: Guid.NewGuid().ToString());
            Assert.Throws<CredentialUnavailableException>(() =>
                credential.GetToken(s_requestContext, default));
        }

        [Test]
        public void GetToken_ExceptionType_MatchesExpected([Values(true, false)] bool isChained)
        {
            var credential = CreateBareCredential();
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
    }
}
