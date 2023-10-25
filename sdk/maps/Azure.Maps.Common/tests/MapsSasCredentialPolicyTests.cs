// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Maps;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Tests
{
    public class MapsSasCredentialPolicyTests
    {
        [Test]
        public void MapsSasCredentialPolicyTest()
        {
            // Exception case
            Assert.Throws<ArgumentNullException>(() => new MapsSasCredentialPolicy(null));

            // Normal case
            var credentialPolicy = new MapsSasCredentialPolicy(new AzureSasCredential("Sas Token"));

            Assert.NotNull(credentialPolicy);
        }
    }
}
