// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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
            Assert.That(cEndpointName, Is.EqualTo(cEndpoint.Data.Name));
            Assert.That(cEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageBlobContainer"));

            StorageMoverEndpointResource cEndpoint2 = (await cEndpoint.GetAsync()).Value;
            Assert.That(cEndpointName, Is.EqualTo(cEndpoint2.Data.Name));
            Assert.That(cEndpoint2.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageBlobContainer"));

            cEndpoint = (await endpoints.GetAsync(cEndpointName)).Value;
            Assert.That(cEndpointName, Is.EqualTo(cEndpoint.Data.Name));
            Assert.That(cEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageBlobContainer"));

            // Create and get a NFS endpoint
            NfsMountEndpointProperties nfsMountEndpointProperties = new NfsMountEndpointProperties("10.0.0.1", "/");
            data = new StorageMoverEndpointData(nfsMountEndpointProperties);
            data.Properties.Description = "New NFS endpoint";
            StorageMoverEndpointResource nfsEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, nfsEndpointName, data)).Value;
            Assert.That(nfsEndpointName, Is.EqualTo(nfsEndpoint.Data.Name));
            Assert.That(nfsEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("NfsMount"));
            Assert.That(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Export, Is.EqualTo("/"));
            Assert.That(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Host, Is.EqualTo("10.0.0.1"));

            nfsEndpoint = (await endpoints.GetAsync(nfsEndpointName)).Value;
            Assert.That(nfsEndpointName, Is.EqualTo(nfsEndpoint.Data.Name));
            Assert.That(nfsEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("NfsMount"));
            Assert.That(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Export, Is.EqualTo("/"));
            Assert.That(((NfsMountEndpointProperties)nfsEndpoint.Data.Properties).Host, Is.EqualTo("10.0.0.1"));

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
            Assert.That(smbEndpointName, Is.EqualTo(smbEndpoint.Data.Name));
            Assert.That(smbEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("SmbMount"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, Is.EqualTo("https://examples-azureKeyVault.vault.azure.net/secrets/examples-username"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, Is.EqualTo("https://examples-azureKeyVault.vault.azure.net/secrets/examples-password"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, Is.EqualTo("10.0.0.1"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, Is.EqualTo("testshare"));

            smbEndpoint = (await endpoints.GetAsync(smbEndpointName)).Value;
            Assert.That(smbEndpointName, Is.EqualTo(smbEndpoint.Data.Name));
            Assert.That(smbEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("SmbMount"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, Is.EqualTo("https://examples-azureKeyVault.vault.azure.net/secrets/examples-username"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, Is.EqualTo("https://examples-azureKeyVault.vault.azure.net/secrets/examples-password"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, Is.EqualTo("10.0.0.1"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, Is.EqualTo("testshare"));

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
            Assert.That(smbEndpointName, Is.EqualTo(smbEndpoint.Data.Name));
            Assert.That(smbEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("SmbMount"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.PasswordUriString, Is.EqualTo(""));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Credentials.UsernameUriString, Is.EqualTo(""));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).Host, Is.EqualTo("10.0.0.1"));
            Assert.That(((SmbMountEndpointProperties)smbEndpoint.Data.Properties).ShareName, Is.EqualTo("testshare"));

            await smbEndpoint.DeleteAsync(WaitUntil.Completed);

            // Create and get a file share endpoint
            AzureStorageSmbFileShareEndpointProperties fileShareEndpointProperties = new AzureStorageSmbFileShareEndpointProperties(new Core.ResourceIdentifier(accountResourceId), "testfileshare");
            data = new StorageMoverEndpointData(fileShareEndpointProperties);
            data.Properties.Description = "new file share endpoint";
            StorageMoverEndpointResource fsEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, fsEndpointName, data)).Value;
            Assert.That(fsEndpointName, Is.EqualTo(fsEndpoint.Data.Name));
            Assert.That(fsEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageSmbFileShare"));
            Assert.That(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).FileShareName, Is.EqualTo("testfileshare"));
            Assert.That(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).Description, Is.EqualTo("new file share endpoint"));

            fsEndpoint = (await endpoints.GetAsync(fsEndpointName)).Value;
            Assert.That(fsEndpointName, Is.EqualTo(fsEndpoint.Data.Name));
            Assert.That(fsEndpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageSmbFileShare"));
            Assert.That(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).FileShareName, Is.EqualTo("testfileshare"));
            Assert.That(((AzureStorageSmbFileShareEndpointProperties)fsEndpoint.Data.Properties).Description, Is.EqualTo("new file share endpoint"));

            int counter = 0;
            await foreach (StorageMoverEndpointResource _ in endpoints.GetAllAsync())
            {
                counter++;
            }
            Assert.That(counter, Is.GreaterThan(1));

            Assert.That((bool)await endpoints.ExistsAsync(cEndpointName), Is.True);
            Assert.That((bool)await endpoints.ExistsAsync(cEndpointName + "111"), Is.False);
            Assert.That((bool)await endpoints.ExistsAsync(smbEndpointName), Is.False);
        }
    }
}
