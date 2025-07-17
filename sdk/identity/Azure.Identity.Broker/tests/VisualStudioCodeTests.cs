// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class VisualStudioCodeTests
    {
        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public void CanGetTokenFromBroker()
        {
            var cred = new VisualStudioCodeCredential();
            var token = cred.GetToken(new TokenRequestContext(["https://management.azure.com/.default"]), default);
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token.Token);
        }
    }
}
