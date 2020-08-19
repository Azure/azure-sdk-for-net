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
            var client = new SecretClient(new Uri("https://myvault.azure.vaults.net/"), new DefaultAzureCredential());
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
            // when deployed to an azure host the default azure credential will authenticate the specified user assigned managed identity
            var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });

            var blobClient = new BlobClient(new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"), credential);
            #endregion
        }

        [Test]
        public void CustomChainedTokenCredential()
        {
            #region Snippet:CustomChainedTokenCredential
            // authenticate using managed identity if it is available otherwise use the Azure CLI to auth
            var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());

            var eventHubProducerClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);
            #endregion
        }
    }
}
