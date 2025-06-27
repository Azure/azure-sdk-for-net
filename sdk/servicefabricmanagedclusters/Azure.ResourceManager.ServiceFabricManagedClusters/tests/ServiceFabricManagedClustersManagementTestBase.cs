﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ManagedServiceIdentities;
using System.Collections.Generic;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ServiceFabricManagedClustersManagementTestBase : ManagementRecordedTestBase<ServiceFabricManagedClustersManagementTestEnvironment>
    {
        protected SubscriptionResource DefaultSubscription;
        public static AzureLocation DefaultLocation => AzureLocation.SouthCentralUS;
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "testClusterRG-";

        protected ServiceFabricManagedClustersManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            Console.WriteLine($"test mode is: {mode}");
        }

        protected ServiceFabricManagedClustersManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            Console.WriteLine("Executing SfmcTestBase constructor");
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(UserAssignedIdentityResource.ResourceType, "2024-11-01-preview");

            Client = GetArmClient(options);
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        public async Task<ResourceGroupResource> CreateResourceGroupWithTag()
        {
            string resourceGroupName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return operation.Value;
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
            string dnsName = Recording.GenerateAssetName("netsdk");
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
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));
            var clusterLro = await resourceGroup.GetServiceFabricManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            return clusterLro.Value;
        }

        protected async Task<ServiceFabricManagedClusterResource> CreateServiceFabricManagedClusterZoneResilient(ResourceGroupResource resourceGroup, string clusterName)
        {
            string dnsName = Recording.GenerateAssetName("netsdk");
            var data = new ServiceFabricManagedClusterData(DefaultLocation)
            {
                Sku = new ServiceFabricManagedClustersSku("Standard"),
                DnsName = dnsName,
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080,
                ClusterUpgradeMode = ManagedClusterUpgradeMode.Automatic,
                HasZoneResiliency = true,
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
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));
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
                VmImageSku = "2022-Datacenter",
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
