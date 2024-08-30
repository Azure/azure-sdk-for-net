// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
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
        public void UserAssignedManagedIdentityWithClientId()
        {
            string userAssignedClientId = "";

            #region Snippet:UserAssignedManagedIdentityWithClientId

            // When deployed to an Azure host, DefaultAzureCredential will authenticate the specified user-assigned managed identity.

            //@@string userAssignedClientId = "<your managed identity client ID>";
            var credential = new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ManagedIdentityClientId = userAssignedClientId
                });

            var blobClient = new BlobClient(
                new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
                credential);

            #endregion
        }

        [Test]
        public void UserAssignedManagedIdentityWithResourceId()
        {
            #region Snippet:UserAssignedManagedIdentityWithResourceId
            string userAssignedResourceId = "<your managed identity resource ID>";
            var credential = new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ManagedIdentityResourceId = new ResourceIdentifier(userAssignedResourceId)
                });

            var blobClient = new BlobClient(
                new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
                credential);
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
            #region Snippet:AuthenticatingWithManagedIdentityCredentialUserAssigned
            string userAssignedClientId = "some client ID";
            var options = new ManagedIdentityCredentialOptions(ManagedIdentityId.FromUserAssignedClientId(userAssignedClientId));

            var credential = new ManagedIdentityCredential(options);
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }

        [Test]
        public void AuthenticatingWithManagedIdentityCredentialUserAssignedResourceId()
        {
            #region Snippet:AuthenticatingWithManagedIdentityCredentialUserAssignedResourceId
            ResourceIdentifier userAssignedResourceId = new ResourceIdentifier("/subscriptions/<some subscriptionID>/resourcegroups/<some resource group>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<some mi name>");
            var options = new ManagedIdentityCredentialOptions(ManagedIdentityId.FromUserAssignedResourceId(userAssignedResourceId));

            var credential = new ManagedIdentityCredential(options);
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }

        [Test]
        public void AuthenticatingWithManagedIdentityCredentialUserAssignedObjectId()
        {
            #region Snippet:AuthenticatingWithManagedIdentityCredentialUserAssignedObjectId
            string userAssignedObjectId = "some object ID";
            var options = new ManagedIdentityCredentialOptions(ManagedIdentityId.FromUserAssignedObjectId(userAssignedObjectId));

            var credential = new ManagedIdentityCredential(options);
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }

        [Test]
        public void AuthenticatingWithManagedIdentityCredentialSystemAssigned()
        {
            #region Snippet:AuthenticatingWithManagedIdentityCredentialSystemAssigned

            var credential = new ManagedIdentityCredential(new ManagedIdentityCredentialOptions(ManagedIdentityId.SystemAssigned));
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }
    }
}
