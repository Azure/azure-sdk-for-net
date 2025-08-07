// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Identity.Samples
{
    public class ReadmeSnippets
    {
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
            var credential = new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzureGovernment
                });
            #endregion
        }
    }
}
