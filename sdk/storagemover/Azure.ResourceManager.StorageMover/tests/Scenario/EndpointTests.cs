// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class EndpointTests : StorageMoverManagementTestBase
    {
        public EndpointTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetDeleteTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string cEndpointName = Recording.GenerateAssetName("conendpoint-");
            string nfsEndpointName = Recording.GenerateAssetName("nfsendpoint-");
            string smbEndpointName = Recording.GenerateAssetName("smbendpoint-");
            string fsEndpointName = Recording.GenerateAssetName("fsendpoint-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            // Create and get a container endpoint
            AzureStorageBlobContainerEndpointProperties containerEndpointProperties =
                new AzureStorageBlobContainerEndpointProperties(accountResourceId, ContainerName);
            StorageMoverEndpointData data = new StorageMoverEndpointData(containerEndpointProperties);
            data.Properties.Description = "New container endpoint";
            StorageMoverEndpointResource cEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, cEndpointName, data)).Value;
            Assert.AreEqual(cEndpoint.Data.Name, cEndpointName);
            Assert.AreEqual("AzureStorageBlobContainer", cEndpoint.Data.Properties.EndpointType.ToString());

            StorageMoverEndpointResource cEndpoint2 = (await cEndpoint.GetAsync()).Value;
            Assert.AreEqual(cEndpoint2.Data.Name, cEndpointName);
            Assert.AreEqual(cEndpoint2.Data.Properties.EndpointType.ToString(), "AzureStorageBlobContainer");

            cEndpoint = (await endpoints.GetAsync(cEndpointName)).Value;
            Assert.AreEqual(cEndpoint.Data.Name, cEndpointName);
            Assert.AreEqual("AzureStorageBlobContainer", cEndpoint.Data.Properties.EndpointType.ToString());

            // Create and get a NFS endpoint
            NfsMountEndpointProperties nfsMountEndpointProperties = new NfsMountEndpointProperties("10.0.0.1", "/");
            data = new StorageMoverEndpointData(nfsMountEndpointProperties);
            data.Properties.Description = "New NFS endpoint";
            StorageMoverEndpointResource nfsEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, nfsEndpointName, data)).Value;
            Assert.AreEqual(nfsEndpoint.Data.Name, nfsEndpointName);
            Assert.AreEqual("NfsMount", nfsEndpoint.Data.Properties.EndpointType.ToString());
            Assert.AreEqual(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Export, "/");
            Assert.AreEqual(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Host, "10.0.0.1");

            nfsEndpoint = (await endpoints.GetAsync(nfsEndpointName)).Value;
            Assert.AreEqual(nfsEndpoint.Data.Name, nfsEndpointName);
            Assert.AreEqual("NfsMount", nfsEndpoint.Data.Properties.EndpointType.ToString());
            Assert.AreEqual(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Export, "/");
            Assert.AreEqual(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Host, "10.0.0.1");

            // Create, get, update and delete a SMB endpoint
            SmbMountEndpointProperties smbMountEndpointProperties = new SmbMountEndpointProperties("10.0.0.1", "testshare");
            AzureKeyVaultSmbCredentials credentials = new AzureKeyVaultSmbCredentials
            {
                UsernameUriString = "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username",
                PasswordUriString = "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password",
            };
            data = new StorageMoverEndpointData(smbMountEndpointProperties);
            smbMountEndpointProperties.Credentials = credentials;
            data.Properties.Description = "New Smb mount endpoint";
            StorageMoverEndpointResource smbEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, smbEndpointName, data)).Value;
            Assert.AreEqual(smbEndpoint.Data.Name, smbEndpointName);
            Assert.AreEqual(smbEndpoint.Data.Properties.EndpointType.ToString(), "SmbMount");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, "10.0.0.1");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, "testshare");

            smbEndpoint = (await endpoints.GetAsync(smbEndpointName)).Value;
            Assert.AreEqual(smbEndpoint.Data.Name, smbEndpointName);
            Assert.AreEqual(smbEndpoint.Data.Properties.EndpointType.ToString(), "SmbMount");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, "10.0.0.1");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, "testshare");

            credentials.UsernameUriString = "";
            credentials.PasswordUriString = "";
            SmbMountEndpointUpdateProperties updateProperties = new SmbMountEndpointUpdateProperties
            {
                Credentials = credentials,
                Description = "Update endpoint",
            };
            StorageMoverEndpointPatch patch = new StorageMoverEndpointPatch
            {
                Properties = updateProperties,
            };
            patch.Properties = updateProperties;
            smbEndpoint = (await smbEndpoint.UpdateAsync(patch)).Value;
            Assert.AreEqual(smbEndpoint.Data.Name, smbEndpointName);
            Assert.AreEqual(smbEndpoint.Data.Properties.EndpointType.ToString(), "SmbMount");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, "");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, "");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, "10.0.0.1");
            Assert.AreEqual(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, "testshare");

            await smbEndpoint.DeleteAsync(WaitUntil.Completed);

            // Create and get a file share endpoint
            AzureStorageSmbFileShareEndpointProperties fileShareEndpointProperties = new AzureStorageSmbFileShareEndpointProperties(new Core.ResourceIdentifier(accountResourceId), "testfileshare");
            data = new StorageMoverEndpointData(fileShareEndpointProperties);
            data.Properties.Description = "new file share endpoint";
            StorageMoverEndpointResource fsEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, fsEndpointName, data)).Value;
            Assert.AreEqual(fsEndpoint.Data.Name, fsEndpointName);
            Assert.AreEqual(fsEndpoint.Data.Properties.EndpointType.ToString(), "AzureStorageSmbFileShare");
            Assert.AreEqual(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).FileShareName, "testfileshare");
            Assert.AreEqual(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).Description, "new file share endpoint");

            fsEndpoint = (await endpoints.GetAsync(fsEndpointName)).Value;
            Assert.AreEqual(fsEndpoint.Data.Name, fsEndpointName);
            Assert.AreEqual(fsEndpoint.Data.Properties.EndpointType.ToString(), "AzureStorageSmbFileShare");
            Assert.AreEqual(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).FileShareName, "testfileshare");
            Assert.AreEqual(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).Description, "new file share endpoint");

            int counter = 0;
            await foreach (StorageMoverEndpointResource _ in endpoints.GetAllAsync())
            {
                counter++;
            }
            Assert.Greater(counter, 1);

            Assert.IsTrue(await endpoints.ExistsAsync(cEndpointName));
            Assert.IsFalse(await endpoints.ExistsAsync(cEndpointName + "111"));
            Assert.IsFalse(await endpoints.ExistsAsync(smbEndpointName));
        }

        [Test]
        [RecordedTest]
        public async Task MultiCloudConnectorEndpointCreateGetDeleteTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string endpointName = Recording.GenerateAssetName("mcc-");

            // Create Azure Multi-Cloud Connector endpoint
            AzureMultiCloudConnectorEndpointProperties mccProperties =
                new AzureMultiCloudConnectorEndpointProperties(new ResourceIdentifier(MultiCloudConnectorId), new ResourceIdentifier(AwsS3BucketId));
            mccProperties.Description = "Test multi-cloud connector endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(mccProperties);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            Assert.AreEqual("AzureMultiCloudConnector", endpoint.Data.Properties.EndpointType.ToString());

            // Get and verify properties
            endpoint = (await endpoints.GetAsync(endpointName)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            AzureMultiCloudConnectorEndpointProperties retrievedProps = (AzureMultiCloudConnectorEndpointProperties)endpoint.Data.Properties;
            Assert.AreEqual("Test multi-cloud connector endpoint", retrievedProps.Description);
            Assert.IsNotNull(retrievedProps.MultiCloudConnectorId);
            Assert.IsNotNull(retrievedProps.AwsS3BucketId);

            // Delete endpoint
            await endpoint.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await endpoints.ExistsAsync(endpointName));
        }

        [Test]
        [RecordedTest]
        [Ignore("S3WithHmac endpoint requires live S3 resources that are not yet available for recording")]
        public async Task S3WithHmacEndpointCreateGetDeleteTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string endpointName = Recording.GenerateAssetName("s3hmac-");

            // Create S3WithHmac endpoint
            S3WithHmacEndpointProperties s3Properties = new S3WithHmacEndpointProperties();
            s3Properties.SourceUri = "https://s3.example.com/bucket";
            s3Properties.SourceType = S3WithHmacSourceType.Minio;
            s3Properties.Description = "Test S3 with HMAC endpoint";
            s3Properties.Credentials = new AzureKeyVaultS3WithHmacCredentials
            {
                AccessKeyUri = "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey",
                SecretKeyUri = "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey",
            };

            StorageMoverEndpointData data = new StorageMoverEndpointData(s3Properties);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            Assert.AreEqual("S3WithHmac", endpoint.Data.Properties.EndpointType.ToString());

            // Get and verify properties
            endpoint = (await endpoints.GetAsync(endpointName)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            S3WithHmacEndpointProperties retrievedProps = (S3WithHmacEndpointProperties)endpoint.Data.Properties;
            Assert.AreEqual("https://s3.example.com/bucket", retrievedProps.SourceUri);
            Assert.AreEqual(S3WithHmacSourceType.Minio, retrievedProps.SourceType);
            Assert.AreEqual("Test S3 with HMAC endpoint", retrievedProps.Description);
            Assert.IsNotNull(retrievedProps.Credentials);
            Assert.AreEqual("https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey", retrievedProps.Credentials.AccessKeyUri);
            Assert.AreEqual("https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey", retrievedProps.Credentials.SecretKeyUri);

            // Delete endpoint
            await endpoint.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await endpoints.ExistsAsync(endpointName));
        }

        #region EndpointKind validation tests - valid kinds

        [Test]
        [RecordedTest]
        public async Task NfsMountEndpointKindSource_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("nfs-src-");

            NfsMountEndpointProperties props = new NfsMountEndpointProperties("10.0.0.1", "/");
            props.EndpointKind = StorageMoverEndpointKind.Source;
            props.Description = "NFS source endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Source, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SmbMountEndpointKindSource_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("smb-src-");

            SmbMountEndpointProperties props = new SmbMountEndpointProperties("10.0.0.1", "testshare");
            props.EndpointKind = StorageMoverEndpointKind.Source;
            props.Description = "SMB source endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Source, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task MultiCloudConnectorEndpointKindSource_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("mcc-src-");

            AzureMultiCloudConnectorEndpointProperties props =
                new AzureMultiCloudConnectorEndpointProperties(new ResourceIdentifier(MultiCloudConnectorId), new ResourceIdentifier(AwsS3BucketId));
            props.EndpointKind = StorageMoverEndpointKind.Source;
            props.Description = "Multi-cloud connector source endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Source, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task BlobContainerEndpointKindSource_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("blob-src-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            AzureStorageBlobContainerEndpointProperties props =
                new AzureStorageBlobContainerEndpointProperties(accountResourceId, ContainerName);
            props.EndpointKind = StorageMoverEndpointKind.Source;
            props.Description = "Blob container source endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Source, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task BlobContainerEndpointKindTarget_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("blob-tgt-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            AzureStorageBlobContainerEndpointProperties props =
                new AzureStorageBlobContainerEndpointProperties(accountResourceId, ContainerName);
            props.EndpointKind = StorageMoverEndpointKind.Target;
            props.Description = "Blob container target endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Target, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SmbFileShareEndpointKindTarget_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("smbfs-tgt-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            AzureStorageSmbFileShareEndpointProperties props =
                new AzureStorageSmbFileShareEndpointProperties(new ResourceIdentifier(accountResourceId), "testfileshare");
            props.EndpointKind = StorageMoverEndpointKind.Target;
            props.Description = "SMB file share target endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Target, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task NfsFileShareEndpointKindTarget_Succeeds()
        {
            StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
            string endpointName = Recording.GenerateAssetName("nfsfs-tgt-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            AzureStorageNfsFileShareEndpointProperties props =
                new AzureStorageNfsFileShareEndpointProperties(new ResourceIdentifier(accountResourceId), "testnfsfileshare");
            props.EndpointKind = StorageMoverEndpointKind.Target;
            props.Description = "NFS file share target endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(props);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(StorageMoverEndpointKind.Target, endpoint.Data.Properties.EndpointKind);

            await endpoint.DeleteAsync(WaitUntil.Completed);
        }

        #endregion

        #region EndpointKind validation tests - invalid kinds

        [Test]
        [RecordedTest]
        public void NfsMountEndpointKindTarget_Fails()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
                string endpointName = Recording.GenerateAssetName("nfs-tgt-");

                NfsMountEndpointProperties props = new NfsMountEndpointProperties("10.0.0.1", "/");
                props.EndpointKind = StorageMoverEndpointKind.Target;

                StorageMoverEndpointData data = new StorageMoverEndpointData(props);
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data);
            });
        }

        [Test]
        [RecordedTest]
        public void SmbMountEndpointKindTarget_Fails()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
                string endpointName = Recording.GenerateAssetName("smb-tgt-");

                SmbMountEndpointProperties props = new SmbMountEndpointProperties("10.0.0.1", "testshare");
                props.EndpointKind = StorageMoverEndpointKind.Target;

                StorageMoverEndpointData data = new StorageMoverEndpointData(props);
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data);
            });
        }

        [Test]
        [RecordedTest]
        public void MultiCloudConnectorEndpointKindTarget_Fails()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
                string endpointName = Recording.GenerateAssetName("mcc-tgt-");

                AzureMultiCloudConnectorEndpointProperties props =
                    new AzureMultiCloudConnectorEndpointProperties(new ResourceIdentifier(MultiCloudConnectorId), new ResourceIdentifier(AwsS3BucketId));
                props.EndpointKind = StorageMoverEndpointKind.Target;

                StorageMoverEndpointData data = new StorageMoverEndpointData(props);
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data);
            });
        }

        [Test]
        [RecordedTest]
        public void SmbFileShareEndpointKindSource_Fails()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
                string endpointName = Recording.GenerateAssetName("smbfs-src-");
                string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                    "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

                AzureStorageSmbFileShareEndpointProperties props =
                    new AzureStorageSmbFileShareEndpointProperties(new ResourceIdentifier(accountResourceId), "testfileshare");
                props.EndpointKind = StorageMoverEndpointKind.Source;

                StorageMoverEndpointData data = new StorageMoverEndpointData(props);
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data);
            });
        }

        [Test]
        [RecordedTest]
        public void NfsFileShareEndpointKindSource_Fails()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                StorageMoverEndpointCollection endpoints = await GetEndpointCollectionAsync();
                string endpointName = Recording.GenerateAssetName("nfsfs-src-");
                string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                    "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

                AzureStorageNfsFileShareEndpointProperties props =
                    new AzureStorageNfsFileShareEndpointProperties(new ResourceIdentifier(accountResourceId), "testnfsfileshare");
                props.EndpointKind = StorageMoverEndpointKind.Source;

                StorageMoverEndpointData data = new StorageMoverEndpointData(props);
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data);
            });
        }

        #endregion

        [Test]
        [RecordedTest]
        public async Task NfsFileShareEndpointCreateGetDeleteTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string endpointName = Recording.GenerateAssetName("nfsfs-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            // Create NFS file share endpoint
            AzureStorageNfsFileShareEndpointProperties nfsFileShareProps =
                new AzureStorageNfsFileShareEndpointProperties(new ResourceIdentifier(accountResourceId), "testnfsfileshare");
            nfsFileShareProps.Description = "Test NFS file share endpoint";

            StorageMoverEndpointData data = new StorageMoverEndpointData(nfsFileShareProps);
            StorageMoverEndpointResource endpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            Assert.AreEqual("AzureStorageNfsFileShare", endpoint.Data.Properties.EndpointType.ToString());

            // Get and verify properties
            endpoint = (await endpoints.GetAsync(endpointName)).Value;
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            AzureStorageNfsFileShareEndpointProperties retrievedProps = (AzureStorageNfsFileShareEndpointProperties)endpoint.Data.Properties;
            Assert.AreEqual("testnfsfileshare", retrievedProps.FileShareName);
            Assert.AreEqual("Test NFS file share endpoint", retrievedProps.Description);
            Assert.IsNotNull(retrievedProps.StorageAccountResourceId);

            // Delete endpoint
            await endpoint.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await endpoints.ExistsAsync(endpointName));
        }

        private async Task<StorageMoverEndpointCollection> GetEndpointCollectionAsync()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            return (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();
        }
    }
}
