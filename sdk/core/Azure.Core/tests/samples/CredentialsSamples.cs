// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;
using System;

namespace Azure.Core.Samples
{
    public class CredentialsSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void AuthenticateWithDefaultCredential()
        {
            #region Snippet:AzureCoreDefaultCredential
            // No Azure.Identity package reference required for client libraries that depend on Azure.Core 1.53.0+
            var credential = new DefaultAzureCredential();
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
            #endregion
        }
    }
}
