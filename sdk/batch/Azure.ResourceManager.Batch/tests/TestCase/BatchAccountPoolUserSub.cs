// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountPoolUserSub : BatchManagementTestBase
    {
        private BatchAccountResource userSub;

        public BatchAccountPoolUserSub(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            CreateCommonClient();
            var subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroupResource = await subscription.GetResourceGroupAsync(TestEnvironment.BatchResourceGroup);
            userSub = await resourceGroupResource.GetBatchAccountAsync(TestEnvironment.BatchUserSubAccountName);
        }

        [TestCase]
        public async Task CustomerManagedKeyTest()
        {
            Assert.IsNotNull(userSub);

            //1.Get
            var collection = userSub.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var DiskEncryptionSetId = TestEnvironment.DiskEncryptionSetId;

            input.DeploymentConfiguration.VmConfiguration.ImageReference.Publisher = "MicrosoftWindowsServer";
            input.DeploymentConfiguration.VmConfiguration.ImageReference.Offer = "WindowsServer";
            input.DeploymentConfiguration.VmConfiguration.ImageReference.Sku = "2022-datacenter-g2";
            input.DeploymentConfiguration.VmConfiguration.ImageReference.Version = "latest";
            input.DeploymentConfiguration.VmConfiguration.NodeAgentSkuId = "batch.node.windows amd64";

            input.DeploymentConfiguration.VmConfiguration.SecurityProfile = new BatchSecurityProfile()
            {
                SecurityType = BatchSecurityType.ConfidentialVm,

                EncryptionAtHost = false,
                UefiSettings = new BatchUefiSettings
                {
                    IsSecureBootEnabled = true,
                    IsVTpmEnabled = true,
                },
                ProxyAgentSettings = new BatchProxyAgentSettings
                {
                    Imds = new BatchHostEndpointSettings
                    {
                        Mode = BatchHostEndpointSettingsModeType.Audit,
                    },
                    Enabled = false,
                },
            };
            input.DeploymentConfiguration.VmConfiguration.OSDisk = new BatchOSDisk()
            {
                Caching = BatchDiskCachingType.ReadWrite,
                ManagedDisk = new ManagedDisk
                {
                    SecurityProfile = new VmDiskSecurityProfile
                    {
                        SecurityEncryptionType = BatchSecurityEncryptionType.VmGuestStateOnly
                    },
                    DiskEncryptionSetId = new ResourceIdentifier(DiskEncryptionSetId),
                },
            };

            input.DeploymentConfiguration.VmConfiguration.DataDisks.Add(
                new BatchVmDataDisk(0, 1024)
                {
                    ManagedDisk = new ManagedDisk
                    {
                        DiskEncryptionSetId = new ResourceIdentifier(DiskEncryptionSetId),
                        StorageAccountType = BatchStorageAccountType.StandardLrs,
                    },
                }
            );

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);

            BatchAccountPoolData batchPool = lro.Value.Data;
            Assert.NotNull(batchPool);
            await lro.Value.DeleteAsync(WaitUntil.Completed);

            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.SecurityType, BatchSecurityType.ConfidentialVm);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.EncryptionAtHost, false);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.UefiSettings.IsSecureBootEnabled, true);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.UefiSettings.IsVTpmEnabled, true);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings.Enabled, false);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings.Imds.Mode, BatchHostEndpointSettingsModeType.Audit);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.OSDisk.Caching, BatchDiskCachingType.ReadWrite);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.OSDisk.ManagedDisk.SecurityProfile.SecurityEncryptionType, BatchSecurityEncryptionType.VmGuestStateOnly);
            Assert.AreEqual(batchPool.DeploymentConfiguration.VmConfiguration.OSDisk.ManagedDisk.DiskEncryptionSet.Id.ToString(), DiskEncryptionSetId);
        }
    }
}
