// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DevelopmentBrokerOptionsTests
    {
        [Test]
        public void TryCreateDevelopmentBrokerOptionsFailsWithoutBrokerReference()
        {
            bool success = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            Assert.That(success, Is.False, "Should not have been able to create DevelopmentBrokerOptions.");
            Assert.That(options, Is.Null, "DevelopmentBrokerOptions is not null.");
        }
    }
}
