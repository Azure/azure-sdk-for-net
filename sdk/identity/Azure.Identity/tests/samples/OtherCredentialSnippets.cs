﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            // Replace the following values with the actual values from the details for your service connection.
            string clientId = "<the value of ClientId for the service connections>";
            string tenantId = "<the value of TenantId for the service connections>";
            string serviceConnectionId = "<the value of service connection Id>";

            // Construct the credential.
            var credential = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN"));

            // Use the credential to authenticate with the Key Vault client.
            var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
            #endregion
        }
    }
}
