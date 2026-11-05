// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    [NonParallelizable]
    public class ServiceBusTestEnvironmentTests
    {
        [Test]
        public void ExplicitDeveloperCredentialUsesDefaultAzureCredentialSelection()
        {
            string previous = Environment.GetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "AzureCliCredential");
                Assert.That(new DeveloperEnvironment().CreateCredential(), Is.TypeOf<DefaultAzureCredential>());
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", previous);
            }
        }

        [Test]
        public void InvalidDeveloperCredentialSelectionIsRejected()
        {
            string previous = Environment.GetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "InvalidCredential");
                Assert.Throws<InvalidOperationException>(() => new DeveloperEnvironment().CreateCredential());
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", previous);
            }
        }

        private class DeveloperEnvironment : ServiceBusTestEnvironment
        {
            public TokenCredential CreateCredential() => CreateDeveloperCredential();
        }
    }
}
