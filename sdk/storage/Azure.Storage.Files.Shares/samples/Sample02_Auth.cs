// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Samples
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
            ShareServiceClient service = new ShareServiceClient(connectionString);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();
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
            Uri serviceUri = StorageAccountFileUri;

            // Create a SharedKeyCredential that we can use to authenticate
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);

            // Create a client that can authenticate with a SharedKeyCredential
            ShareServiceClient service = new ShareServiceClient(serviceUri, credential);

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
                // Allow access to files
                Services = AccountSasServices.Files,

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
            UriBuilder sasUri = new UriBuilder(StorageAccountFileUri);
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();

            // Create a client that can authenticate with the SAS URI
            ShareServiceClient service = new ShareServiceClient(sasUri.Uri);

            // Make a service request to verify we've successfully authenticated
            await service.GetPropertiesAsync();

            // Try to create a new container (which is beyond our
            // delegated permission)
            RequestFailedException ex =
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.CreateShareAsync(Randomize("sample-share")));
            Assert.AreEqual(403, ex.Status);
        }

        /// <summary>
        /// Use a TokenCredential to access a Storage Account.
        ///
        /// TokenCredential represents credentials used to acquire
        /// OAuth 2.0 access tokens for authenticating requests to Azure services.
        /// </summary>
        [Test]
        public async Task TokenCredentialAuthAsync()
        {
            #region Snippet:ShareFile_TokenCredential
            // Create a TokenCredential that we can use to authenticate
            TokenCredential credential = new DefaultAzureCredential();

            // Create a client that can authenticate with a TokenCredential
            ShareServiceClient shareServiceClient = new ShareServiceClient(
                StorageAccountFileUri,
                credential);
            #endregion

            // Make a service request to verify we've successfully authenticated
            await shareServiceClient.GetPropertiesAsync();
        }
    }
}
