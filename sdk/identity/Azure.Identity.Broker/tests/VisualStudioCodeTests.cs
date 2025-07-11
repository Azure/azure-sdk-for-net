// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class VisualStudioCodeTests
    {
        [Test]
        public void CanGetTokenFromBroker()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var cred = new VisualStudioCodeCredential();
#pragma warning restore CS0618 // Type or member is obsolete
            var token = cred.GetToken(new TokenRequestContext(["https://management.azure.com/.default"]), default);
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token.Token);
        }
    }
}
