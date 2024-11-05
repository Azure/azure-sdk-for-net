// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using System.Threading;
using Azure.Messaging.EventHubs.Producer;

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

        public void FederatedOboWithManagedIdentityCredential_Example()
        {
            #region Snippet:FederatedOboWithManagedIdentityCredential_Example
            // Replace the following values with the actual values for your tenant and client ids.
            string tenantId = "<tenant_id>";
            string clientId = "<client_id>";

            // Replace the following value with the actual user assertion.
            string userAssertion = "<user_assertion>";

            Func<CancellationToken, Task<string>> getManagedIdentityAssertion = async (cancellationToken) =>
            {
                // Create a new instance of the ManagedIdentityCredential.
                var miCred = new ManagedIdentityCredential();

                // Get the token from the ManagedIdentityCredential using the token exchange scope.
                var result = await miCred.GetTokenAsync(new TokenRequestContext(new[] { "api://AzureADTokenExchange" }), cancellationToken: cancellationToken);

                // Return the token.
                return result.Token;
            };

            // Construct the credential.
            var credential = new OnBehalfOfCredential(tenantId, clientId, getManagedIdentityAssertion, userAssertion);

            // Use the credential to authenticate with the Key Vault client.
            var client = new SecretClient(new Uri("https://keyvault-name.vault.azure.net/"), credential);
            #endregion
        }

        public void CustomChainedTokenCredential()
        {
            #region Snippet:CustomChainedTokenCredential

            // Authenticate using managed identity if it is available; otherwise use the Azure CLI to authenticate.

            var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());

            var eventHubProducerClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);

            #endregion
        }
    }
}
