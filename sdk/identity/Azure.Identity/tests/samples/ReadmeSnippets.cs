// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Producer;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Identity.Samples
{
    public class ReadmeSnippets
    {
        [Test]
        public void AuthenticatingWithDefaultAzureCredential()
        {
            #region Snippet:AuthenticatingWithDefaultAzureCredential

            // Create a secret client using the DefaultAzureCredential
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), new DefaultAzureCredential());

            #endregion
        }

        [Test]
        public void EnableInteractiveAuthentication()
        {
            #region Snippet:EnableInteractiveAuthentication

            // the includeInteractiveCredentials constructor parameter can be used to enable interactive authentication
            var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

            var eventHubClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);

            #endregion
        }

        [Test]
        public void UserAssignedManagedIdentity()
        {
            string userAssignedClientId = "";

            #region Snippet:UserAssignedManagedIdentity

            // When deployed to an azure host, the default azure credential will authenticate the specified user assigned managed identity.

            //@@string userAssignedClientId = "<your managed identity client Id>";
            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });

            var blobClient = new BlobClient(new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"), credential);

            #endregion
        }

        [Test]
        public void CustomChainedTokenCredential()
        {
            #region Snippet:CustomChainedTokenCredential

            // Authenticate using managed identity if it is available; otherwise use the Azure CLI to authenticate.

            var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());

            var eventHubProducerClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);

            #endregion
        }

        [Test]
        public void AuthenticatingWithAuthorityHost()
        {
            #region Snippet:AuthenticatingWithAuthorityHost

            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { AuthorityHost = AzureAuthorityHosts.AzureGovernment });

            #endregion
        }

        [Test]
        public void AuthenticatingWithManagedIdentityCredentialUserAssigned()
        {
            string userAssignedClientId = "";

            #region Snippet:AuthenticatingWithManagedIdentityCredentialUserAssigned

            var credential = new ManagedIdentityCredential(clientId: userAssignedClientId);
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }

        [Test]
        public void AuthenticatingWithManagedIdentityCredentialSystemAssigned()
        {
            #region Snippet:AuthenticatingWithManagedIdentityCredentialSystemAssigned

            var credential = new ManagedIdentityCredential();
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }
    }
}
