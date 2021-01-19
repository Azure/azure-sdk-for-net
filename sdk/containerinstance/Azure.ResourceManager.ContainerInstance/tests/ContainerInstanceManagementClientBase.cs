// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    [ClientTestFixture]
    [NonParallelizable]
    public abstract class ContainerInstanceManagementClientBase: ManagementRecordedTestBase<ContainerInstanceManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public ProvidersOperations ResourceProvidersOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public ContainerInstanceManagementClient ContainerInstanceManagementClient { get; set; }
        public ContainerGroupsOperations ContainerGroupsOperations { get; set; }
        public Operations Operations { get; set; }
        public LocationOperations LocationOperations { get; set; }
        public ContainersOperations ContainersOperations { get; set; }

        protected ContainerInstanceManagementClientBase(bool isAsync)
           : base(isAsync)
        {
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourcesOperations = ResourcesManagementClient.Resources;
            ResourceProvidersOperations = ResourcesManagementClient.Providers;
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;

            ContainerInstanceManagementClient = GetContainerInstanceManagementClient();
            ContainerGroupsOperations = ContainerInstanceManagementClient.ContainerGroups;
            Operations = ContainerInstanceManagementClient.Operations;
            LocationOperations = ContainerInstanceManagementClient.Location;
            ContainersOperations = ContainerInstanceManagementClient.Containers;
        }

        internal ContainerInstanceManagementClient GetContainerInstanceManagementClient()
        {
            return CreateClient<ContainerInstanceManagementClient>(SubscriptionId, TestEnvironment.Credential,
                InstrumentClientOptions(new ContainerInstanceManagementClientOptions()));
        }
        public async Task<string> GetLocationAsync()
        {
            return await GetFirstUsableLocationAsync(ResourceProvidersOperations, "Microsoft.ContainerInstance", "containerGroups");
        }
    }
}
