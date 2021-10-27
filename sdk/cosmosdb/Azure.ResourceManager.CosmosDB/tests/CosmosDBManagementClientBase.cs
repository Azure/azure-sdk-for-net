// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CosmosDBManagementClientBase : ManagementRecordedTestBase<CosmosDBManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ResourcesManagementClient { get; set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public CosmosDBManagementClient CosmosDBManagementClient { get; set; }

        protected CosmosDBManagementClientBase(bool isAsync)
            : base(isAsync)
        {
            Sanitizer = new CosmosDBManagementRecordedTestSanitizer();
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.DefaultSubscription.GetResourceGroups();
            CosmosDBManagementClient = GetCosmosDBManagementClient();
        }

        internal CosmosDBManagementClient GetCosmosDBManagementClient()
        {
            return CreateClient<CosmosDBManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new CosmosDBManagementClientOptions()));
        }

        protected void initNewRecord()
        {
            ResourceGroupsOperations = ResourcesManagementClient.DefaultSubscription.GetResourceGroups();
            CosmosDBManagementClient = GetCosmosDBManagementClient();
        }
    }
}
