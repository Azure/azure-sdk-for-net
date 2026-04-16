// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DevelopmentBrokerOptionsTests
    {
        [Test]
        [Ignore("Broker is now available via TestFramework dependency. See https://github.com/Azure/azure-sdk-for-net/issues/58160")]
        public void TryCreateDevelopmentBrokerOptionsFailsWithoutBrokerReference()
        {
            bool success = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            Assert.IsFalse(success, "Should not have been able to create DevelopmentBrokerOptions.");
            Assert.IsNull(options, "DevelopmentBrokerOptions is not null.");
        }
    }
}
