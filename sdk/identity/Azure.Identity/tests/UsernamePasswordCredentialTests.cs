// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class UsernamePasswordCredentialTests : ClientTestBase
    {
        public UsernamePasswordCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task VerifyMsalClientExceptionAsync()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { UserPassAuthFactory = (_) => { throw new MockClientException(expInnerExMessage); } };

            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();

            var credential = InstrumentClient(new UsernamePasswordCredential(username, password, clientId, tenantId, default, default, mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }
    }
}
