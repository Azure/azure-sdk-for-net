// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Samples
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
        /// Anonymously access a public DataLake File.
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
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            // Get a reference to a service Client
            DataLakeServiceClient service = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem"
            DataLakeFileSystemClient filesystem = service.GetFileSystemClient(Randomize("sample-filesystem"));
            try
            {
                // Create a file that can be accessed publicly
                await filesystem.CreateAsync(new DataLakeFileSystemCreateOptions
                {
                    PublicAccessType = PublicAccessType.FileSystem
                });
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));
                await file.CreateAsync();

                // Append data to the file
                string fileContent = "File Content";
                await file.AppendAsync(new MemoryStream(Encoding.UTF8.GetBytes(fileContent)), 0);
                await file.FlushAsync(fileContent.Length);

                // Anonymously access a blob given its URI
                Uri endpoint = file.Uri;
                DataLakeFileClient anonymous = new DataLakeFileClient(endpoint);

                // Make a service request to verify we've successfully authenticated
                await anonymous.GetPropertiesAsync();
            }
            finally
            {
                await filesystem.DeleteAsync();
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

            // Make StorageSharedKeyCredential to pass to the serviceClient
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            // Get a reference to a service Client
            DataLakeServiceClient service = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Make a service request to verify we've successfully authenticated
            await service.CreateFileSystemAsync("sample-filesystem-sharedkey");
            await service.DeleteFileSystemAsync("sample-filesystem-sharedkey");
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
        public async Task SharedAccessSignatureAuthAsync()
        {
            // Create a service level SAS that only allows reading from service
            // level APIs
            AccountSasBuilder sas = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All,
                StartsOn = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            // Allow read access
            sas.SetPermissions(AccountSasPermissions.List);

            // Create a SharedKeyCredential that we can use to sign the SAS token
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(StorageAccountBlobUri);
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

            // Create a client that can authenticate with the SAS URI
            DataLakeServiceClient service = new DataLakeServiceClient(sasUri.Uri);

            // Make a service request to verify we've successfully authenticated
            await service.GetFileSystemsAsync().FirstAsync();

            // Try to create a new container (which is beyond our
            // delegated permission)
            RequestFailedException ex =
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.CreateFileSystemAsync(Randomize("sample-filesystem")));
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
            DataLakeServiceClient service = new DataLakeServiceClient(ActiveDirectoryBlobUri, credential);

            // Make a service request to verify we've successfully authenticated
            await service.CreateFileSystemAsync("sample-filesystem-aad");
            await service.DeleteFileSystemAsync("sample-filesystem-aad");
        }
    }
}
