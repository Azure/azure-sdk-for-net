// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Samples
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
        public async Task ConnectionStringAsync()
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
            BlobServiceClient service = new BlobServiceClient(connectionString);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();
        }

        /// <summary>
        /// Anonymously access a public blob.
        ///
        /// You can enable anonymous, public read access to a container and its
        /// blobs in Azure Blob storage.  By doing so, you can grant read-only
        /// access to these resources without sharing your account key, and
        /// without requiring a shared access signature (SAS).
        ///
        /// Public read access is best for scenarios where you want certain
        /// blobs to always be available for anonymous read access.  For more
        /// fine-grained control, you can create a shared access signature.
        /// </summary>
        [Test]
        public async Task AnonymousAuthAsync()
        {
            BlobContainerClient container = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            try
            {
                // Create a blob that can be accessed publicly
                await container.CreateAsync(PublicAccessType.Blob);
                BlobClient blob = container.GetBlobClient(Randomize("sample-blob"));
                await blob.UploadAsync(BinaryData.FromString("Blob Content"));

                // Anonymously access a blob given its URI
                Uri endpoint = blob.Uri;
                BlobClient anonymous = new BlobClient(endpoint);

                // Make a service request to verify we've successfully authenticated
                await anonymous.GetPropertiesAsync();
            }
            finally
            {
                await container.DeleteAsync();
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
        public async Task SharedKeyAuthAsync()
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
            BlobServiceClient service = new BlobServiceClient(serviceUri, credential);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();
        }

        /// <summary>
        /// Use a shared access signature to access a Storage Account.
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
        public async Task SharedAccessSignatureAuthAsync()
        {
            // Create a service level SAS that only allows reading from service
            // level APIs
            AccountSasBuilder sas = new AccountSasBuilder
            {
                // Allow access to blobs
                Services = AccountSasServices.Blobs,

                // Allow access to the service level APIs
                ResourceTypes = AccountSasResourceTypes.Service,

                // Access expires in 1 hour!
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };
            // Allow read access
            sas.SetPermissions(AccountSasPermissions.Read);

            // Create a SharedKeyCredential that we can use to sign the SAS token
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

            // Create a client that can authenticate with the SAS URI
            BlobServiceClient service = new BlobServiceClient(sasUri.Uri);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();

            // Try to create a new container (which is beyond our
            // delegated permission)
            RequestFailedException ex =
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.CreateBlobContainerAsync(Randomize("sample-container")));
            Assert.AreEqual(403, ex.Status);
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
        public async Task ActiveDirectoryAuthAsync()
        {
            // Create a token credential that can use our Azure Active
            // Directory application to authenticate with Azure Storage
            TokenCredential credential = new DefaultAzureCredential();

            // Create a client that can authenticate using our token credential
            BlobServiceClient service = new BlobServiceClient(ActiveDirectoryBlobUri, credential);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();
        }
    }
}
