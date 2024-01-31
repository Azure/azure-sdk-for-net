// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabric.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ServiceFabric.Tests
{
    public class ServiceFabricManagementTestBase : ManagementRecordedTestBase<ServiceFabricManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "ServiceFabricRG-";

        protected ServiceFabricManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ServiceFabricManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ServiceFabricClusterResource> CreateServiceFabricCluster(ResourceGroupResource resourceGroup, string clusterName)
        {
            ServiceFabricClusterData data = new ServiceFabricClusterData(resourceGroup.Data.Location)
            {
                ManagementEndpoint = new Uri($"https://{clusterName}.{resourceGroup.Data.Location.ToString()}.cloudapp.azure.com:19080/"),
            };
            ClusterNodeTypeDescription clusterNodeTypeDescription = new ClusterNodeTypeDescription("Type812", 19000, 19080, true, 5);
            data.NodeTypes.Add(clusterNodeTypeDescription);
            var cluster = await resourceGroup.GetServiceFabricClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            return cluster.Value;
        }
    }
}
