// Copyright (c) Microsoft Corporation. All rights reserved.
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

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ServiceFabricManagedClustersManagementTestBase : ManagementRecordedTestBase<ServiceFabricManagedClustersManagementTestEnvironment>
    {
        protected SubscriptionResource DefaultSubscription;
        public static AzureLocation DefaultLocation => AzureLocation.SouthCentralUS;
        protected ArmClient Client { get; private set; }
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
            // Currently our pipeline will run this test project with project reference
            // And we jsut upgraded the version of ManagedServiceIdentities, therefore the related tests will fail
            // Use the version override as a work around because we lack the test resource now.
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(UserAssignedIdentityResource.ResourceType, "2018-11-30");

            Client = GetArmClient(options);
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("testClusterRG-");
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
    }
}
