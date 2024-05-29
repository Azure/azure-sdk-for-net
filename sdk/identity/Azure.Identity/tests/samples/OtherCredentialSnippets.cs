// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Identity.Tests.samples
{
    public class OtherCredentialSnippets
    {
        public void AzurePipelinesCredential_Example()
        {
            #region Snippet:AzurePipelinesCredential_Example
            // Replace the following value with the actual values for the System.AccessToken.
            string systemAccessToken = "<the value of System.AccessToken>";

            // Construct the credential.
            var credential = new AzurePipelinesCredential(systemAccessToken);

            // Use the credential to authenticate with the Key Vault client.
            var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
            #endregion
        }
    }
}
