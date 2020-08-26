// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CosmosDBManagementClientBase : ManagementRecordedTestBase<CosmosDBManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public CosmosDBManagementClient CosmosDBManagementClient { get; set; }

        protected CosmosDBManagementClientBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            CosmosDBManagementClient = GetCosmosDBManagementClient();
        }

        internal CosmosDBManagementClient GetCosmosDBManagementClient()
        {
            return CreateClient<CosmosDBManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new CosmosDBManagementClientOptions()));
        }
    }
}
