// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    /// <summary>
    /// Demonstrate various authorization and authentication mechanisms.
    ///
    /// For more information, see
    /// https://docs.microsoft.com/en-us/azure/storage/common/storage-auth
    /// </summary>
    public class Sample02_Auth : SampleTest
    {
        /// <summary>
        /// Use a connection string to connect to a Storage account.
        ///
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime using Shared Key authorization.
        /// </summary>
        [Test]
        public void ConnectionStringAuth()
        {
            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = ConnectionString;

            // Create a client that can authenticate with a connection string
            BlobChangeFeedClient service = new BlobChangeFeedClient(connectionString);

            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Make a service request to verify we've successfully authenticated
            foreach (BlobChangeFeedEvent changeFeedEvent in service.GetChanges())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// Use a shared key to access a Storage Account.
        ///
        /// Shared Key authorization relies on your account access keys and
        /// other parameters to produce an encrypted signature string that is
        /// passed on the request in the Authorization header.
        /// </summary>
        [Test]
        public void SharedKeyAuth()
        {
            // Get a Storage account name, shared key, and endpoint Uri.
            //
            // You can obtain both from the Azure Portal by clicking Access
            // Keys under Settings in the Portal Storage account blade.
            //
            // You can also get access to your account keys from the Azure CLI
            // with:
            //
            //     az storage account keys list --account-name <account_name> --resource-group <resource_group>
            //
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a connection string
            BlobChangeFeedClient service = new BlobChangeFeedClient(serviceUri, credential);

            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Make a service request to verify we've successfully authenticated
            foreach (BlobChangeFeedEvent changeFeedEvent in service.GetChanges())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// Use a shared access signature to acces a Storage Account.
        ///
        /// A shared access signature (SAS) is a URI that grants restricted
        /// access rights to Azure Storage resources. You can provide a shared
        /// access signature to clients who should not be trusted with your
        /// storage account key but to whom you wish to delegate access to
        /// certain storage account resources. By distributing a shared access
        /// signature URI to these clients, you can grant them access to a
        /// resource for a specified period of time, with a specified set of
        /// permissions.
        /// </summary>
        [Test]
        public void SharedAccessSignatureAuth()
        {
            // Create a blob level SAS that allows reading change events from blob
            // level APIs
            AccountSasBuilder sas = new AccountSasBuilder
            {
                // Allow access to blobs
                Services = AccountSasServices.Blobs,

                // Allow access to the service level APIs
                ResourceTypes = AccountSasResourceTypes.All,

                // Access expires in 1 hour!
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };
            // Allow all access
            sas.SetPermissions(AccountSasPermissions.All);

            // Create a SharedKeyCredential that we can use to sign the SAS token
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

            // Create a client that can authenticate with the SAS URI
            BlobChangeFeedClient service = new BlobChangeFeedClient(sasUri.Uri);

            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Make a service request to verify we've successfully authenticated
            foreach (BlobChangeFeedEvent changeFeedEvent in service.GetChanges())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// Use an Active Directory token to access a Storage account.
        ///
        /// Azure Storage provides integration with Azure Active Directory
        /// (Azure AD) for identity-based authentication of requests to the
        /// Blob and Queue services. With Azure AD, you can use role-based
        /// access control (RBAC) to grant access to your Azure Storage
        /// resources to users, groups, or applications. You can grant
        /// permissions that are scoped to the level of an individual
        /// container or queue.
        ///
        /// To learn more about Azure AD integration in Azure Storage, see
        /// https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad
        /// </summary>
        [Test]
        public void ActiveDirectoryAuth()
        {
            // Create a token credential that can use our Azure Active
            // Directory application to authenticate with Azure Storage
            TokenCredential credential = new DefaultAzureCredential();

            // Create a client that can authenticate using our token credential
            BlobChangeFeedClient service = new BlobChangeFeedClient(ActiveDirectoryBlobUri, credential);

            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Make a service request to verify we've successfully authenticated
            foreach (BlobChangeFeedEvent changeFeedEvent in service.GetChanges())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }
    }
}
