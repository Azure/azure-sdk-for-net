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
            // Replace the following values with the actual values for the service connection.
            string clientId = "<service_connection_client_id>";
            string tenantId = "<service_connection_tenant_id>";
            string serviceConnectionId = "<service_connection_id>";

            // Construct the credential.
            var credential = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId);

            // Use the credential to authenticate with the Key Vault client.
            var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
            #endregion
        }
    }
}
