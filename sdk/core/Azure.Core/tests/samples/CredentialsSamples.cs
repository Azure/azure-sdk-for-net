// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;
using System;

namespace Azure.Core.Tests.Samples
{
    public class CredentialsSamples
    {
        [Test]
        [Ignore("Sample only")]
        public void AuthenticateWithDefaultCredential()
        {
            #region Snippet:AzureCoreDefaultCredential
            // No Azure.Identity package reference required for Azure.Core 1.53+
            var credential = new DefaultAzureCredential();
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
            #endregion
        }
    }
}
