// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Server.Kestrel;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountPoolCollectionTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;
        private BatchAccountResource _generatedBatchAccount;

        public BatchAccountPoolCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            _batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);

            var subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroupResource = await subscription.GetResourceGroupAsync(TestEnvironment.BatchResourceGroup);
            _generatedBatchAccount = await resourceGroupResource.GetBatchAccountAsync(TestEnvironment.BatchAccountName);
        }

        [TestCase]
        public async Task PoolCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var name2 = Recording.GenerateAssetName("Pool-");
            var name3 = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountPoolResource pool1 = lro.Value;
            Assert.AreEqual(name, pool1.Data.Name);
            //2.Get
            BatchAccountPoolResource pool2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertPoolData(pool1.Data, pool2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        public async Task PoolPublicAddressTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var name2 = Recording.GenerateAssetName("Pool-");
            var name3 = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();

            PoolEndpointConfiguration batchPoolEndpointConfiguration =  new PoolEndpointConfiguration(new List<BatchInboundNatPool>());
            batchPoolEndpointConfiguration.InboundNatPools.Add(new BatchInboundNatPool("ruleName", BatchInboundEndpointProtocol.Tcp, 3389, 15000, 15100));

            input.NetworkConfiguration = new BatchNetworkConfiguration()
            {
                EndpointConfiguration = batchPoolEndpointConfiguration,
                PublicIPAddressConfiguration = new BatchPublicIPAddressConfiguration()
            };

            input.NetworkConfiguration.PublicIPAddressConfiguration.IPFamilies.Add(BatchIPFamily.IPv4);
            input.NetworkConfiguration.PublicIPAddressConfiguration.IPFamilies.Add(BatchIPFamily.IPv6);
            input.NetworkConfiguration.PublicIPAddressConfiguration.IPTags.Add(
                new BatchIPTag()
                {
                    IPTagType = "tagType1",
                    Tag = "tag1"
                }
                );

            input.TaskSchedulingPolicy = new BatchTaskSchedulingPolicy(BatchNodeFillType.Pack)
            {
                JobDefaultOrder = BatchJobDefaultOrder.CreationTime,
            };
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountPoolData batchNodeRemoteLoginSettings = lro.Value.Data;
            Assert.NotNull(batchNodeRemoteLoginSettings);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.EndpointConfiguration);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.EndpointConfiguration.InboundNatPools);
            Assert.AreEqual(3389,batchNodeRemoteLoginSettings.NetworkConfiguration.EndpointConfiguration.InboundNatPools[0].BackendPort);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPFamilies);
            Assert.AreEqual(BatchIPFamily.IPv4, batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPFamilies[0]);
            Assert.AreEqual(BatchIPFamily.IPv6, batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPFamilies[1]);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPTags);
            Assert.NotNull(batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPTags[0]);
            Assert.AreEqual("tagType1", batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPTags[0].IPTagType);
            Assert.AreEqual("tag1", batchNodeRemoteLoginSettings.NetworkConfiguration.PublicIPAddressConfiguration.IPTags[0].Tag);
            Assert.NotNull(batchNodeRemoteLoginSettings.TaskSchedulingPolicy);
            Assert.AreEqual(BatchJobDefaultOrder.CreationTime, batchNodeRemoteLoginSettings.TaskSchedulingPolicy.JobDefaultOrder);
        }

        [TestCase]
        public async Task PoolCreatedOsDiskSecurityProfile()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var name2 = Recording.GenerateAssetName("Pool-");
            var name3 = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();

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
                   Enabled = true,
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
                },
            };

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountPoolData batchPool = lro.Value.Data;
            Assert.NotNull(batchPool);
            Assert.NotNull(batchPool.DeploymentConfiguration);
            Assert.NotNull(batchPool.DeploymentConfiguration.VmConfiguration);
            Assert.NotNull(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile);
            Assert.AreEqual(BatchSecurityType.ConfidentialVm, batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.SecurityType);
            Assert.AreEqual(false, batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.EncryptionAtHost);
            Assert.NotNull(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.UefiSettings);
            Assert.AreEqual(true, batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.UefiSettings.IsVTpmEnabled);
            Assert.NotNull(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings);
            Assert.AreEqual(true, batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings.Enabled);
            Assert.NotNull(batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings.Imds);
            Assert.AreEqual(BatchHostEndpointSettingsModeType.Audit, batchPool.DeploymentConfiguration.VmConfiguration.SecurityProfile.ProxyAgentSettings.Imds.Mode);
        }

        [TestCase]
        public async Task CustomerManagedKeyTest()
        {
            //1.Get
            var collection = _generatedBatchAccount.GetBatchAccountPools();
            var name = Recording.GenerateAssetName("Pool-");
            var name2 = Recording.GenerateAssetName("Pool-");
            var name3 = Recording.GenerateAssetName("Pool-");
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var cmkKeyUri = TestEnvironment.CmkKeyvalutKeyUriWithVersion;
            var cmkSecretUri = TestEnvironment.BatchUserSubAccountURI;
            var userIdentity = TestEnvironment.UserAssignedIdentity;

            input.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            {
                UserAssignedIdentities =
                {
                    [new ResourceIdentifier(userIdentity)] = new UserAssignedIdentity(),
                },
            };

            input.DeploymentConfiguration.VmConfiguration.DiskEncryptionConfiguration = new BatchDiskEncryptionConfiguration
            {
                Targets = { BatchDiskEncryptionTarget.OSDisk },
                CustomerManagedKey = new BatchDiskCustomerManagedKey
                {
                    KeyUri = new Uri(cmkKeyUri),
                    RotationToLatestKeyVersionEnabled = true,
                    IdentityReferenceResourceId = new ResourceIdentifier(userIdentity),
                },
            };

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
                },
            };

            input.DeploymentConfiguration.VmConfiguration.DataDisks.Add(
                new BatchVmDataDisk(0, 1024)
                {
                    ManagedDisk = new ManagedDisk
                    {
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
            Assert.AreEqual(input.DeploymentConfiguration.VmConfiguration.DiskEncryptionConfiguration.CustomerManagedKey.KeyUri, new Uri(cmkKeyUri));
            Assert.AreEqual(input.DeploymentConfiguration.VmConfiguration.DiskEncryptionConfiguration.CustomerManagedKey.RotationToLatestKeyVersionEnabled, true);
            Assert.AreEqual(input.DeploymentConfiguration.VmConfiguration.DiskEncryptionConfiguration.CustomerManagedKey.IdentityReferenceResourceId, new ResourceIdentifier(userIdentity));
        }
    }
}
