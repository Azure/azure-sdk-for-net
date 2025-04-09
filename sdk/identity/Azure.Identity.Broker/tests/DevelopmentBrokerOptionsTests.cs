// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DevelopmentBrokerOptionsTests
    {
        [Test]
        public void TryCreateDevelopmentBrokerOptions()
        {
            bool success = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            Assert.IsTrue(success, "Failed to create DevelopmentBrokerOptions.");
            Assert.IsNotNull(options, "DevelopmentBrokerOptions is null.");
        }

        [Test]
        public void TryCreateDevelopmentBrokerOptionsFromCredentialFactory()
        {
            var factory = new DefaultAzureCredentialFactory(new DefaultAzureCredentialOptions());
            DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            var cred = factory.CreateBrokerAuthenticationCredential(options);
            try
            {
                cred.GetToken(new TokenRequestContext(new[] { "https://management.azure.com/.default" }), default);
            }
            catch (CredentialUnavailableException)
            {
                // This is expected, as the broker is not available in the test environment.
            }
        }
    }
}
