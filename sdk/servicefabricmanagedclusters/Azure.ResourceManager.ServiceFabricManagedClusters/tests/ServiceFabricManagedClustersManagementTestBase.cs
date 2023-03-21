// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ServiceFabricManagedClustersManagementTestBase : ManagementRecordedTestBase<ServiceFabricManagedClustersManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "ServiceFabricManagedClustersRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

        protected ServiceFabricManagedClustersManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ServiceFabricManagedClustersManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ServiceFabricManagedClusterResource> CreateServiceFabricManagedCluster(ResourceGroupResource resourceGroup, string clusterName)
        {
            string dnsName = Recording.GenerateAssetName("sfmcnetsdk");
            var data = new ServiceFabricManagedClusterData(DefaultLocation)
            {
                Sku = new ServiceFabricManagedClustersSku("Standard"),
                DnsName = dnsName,
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080,
                ClusterUpgradeMode = ManagedClusterUpgradeMode.Automatic,
                HasZoneResiliency = false,
                AdminUserName = "vmadmin",
                AdminPassword = "Password123!@#",
                Clients =
                {
                    new ManagedClusterClientCertificate(true)
                    {
                        Thumbprint = BinaryData.FromString("\"123BDACDCDFB2C7B250192C6078E47D1E1DB119B\""),
                    }
                }
            };
            var clusterLro = await resourceGroup.GetServiceFabricManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            return clusterLro.Value;
        }

        protected async Task<ServiceFabricManagedNodeTypeResource> CreateServiceFabricManagedNodeType(ServiceFabricManagedClusterResource cluster, string nodeTypeName, bool isPrimaryNode)
        {
            var data = new ServiceFabricManagedNodeTypeData()
            {
                ApplicationPorts = new EndpointRangeDescription(20000, 30000),
                DataDiskLetter = "S",
                DataDiskSizeInGB = 256,
                DataDiskType = ServiceFabricManagedDataDiskType.StandardSsdLrs,
                EphemeralPorts = new EndpointRangeDescription(49152, 65534),
                IsPrimary = isPrimaryNode,
                VmImageOffer = "WindowsServer",
                VmImagePublisher = "MicrosoftWindowsServer",
                VmImageSku = "2019-Datacenter",
                VmImageVersion = "latest",
                VmInstanceCount = 6,
                VmSize = "Standard_D2_v2"
            };
            var noteTypeLro = await cluster.GetServiceFabricManagedNodeTypes().CreateOrUpdateAsync(WaitUntil.Completed, nodeTypeName, data);
            return noteTypeLro.Value;
        }

        protected async Task<ServiceFabricManagedApplicationTypeResource> CreateSFMAppType(ServiceFabricManagedClusterResource cluster, string appTypeName)
        {
            var data = new ServiceFabricManagedApplicationTypeData(DefaultLocation)
            {
            };
            var appType = await cluster.GetServiceFabricManagedApplicationTypes().CreateOrUpdateAsync(WaitUntil.Completed, appTypeName, data);
            return appType.Value;
        }
    }
}
