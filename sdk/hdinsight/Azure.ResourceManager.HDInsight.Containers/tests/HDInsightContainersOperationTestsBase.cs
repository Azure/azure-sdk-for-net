// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests
{
    [ClientTestFixture]
    public abstract class HDInsightContainersOperationTestsBase : ManagementRecordedTestBase<HDInsightContainersManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        private const string ObjectIdKey = "ObjectId";
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);

        public string Location { get; set; }
        public string ObjectId { get; set; }
        public SubscriptionResource Subscription { get; private set; }
        public string ResourceGroupName { get; internal set; }
        public Guid TenantIdGuid { get; internal set; }

        public HDInsightClusterPoolCollection ClusterPoolCollection { get; set; }
        public HDInsightClusterCollection ClusterCollection { get; set; }
        public ResourceGroupResource ResourceGroup { get; set; }

        protected HDInsightContainersOperationTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected HDInsightContainersOperationTestsBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected async Task Initialize()
        {
            Location = "west europe";
            ArmClientOptions options = new ArmClientOptions()
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = true
                }
            };
            Client = GetArmClient(options);
            Subscription = await Client.GetDefaultSubscriptionAsync();
            if (Mode == RecordedTestMode.Playback)
            {
                this.ObjectId = Recording.GetVariable(ObjectIdKey, string.Empty);
            }
            else if (Mode == RecordedTestMode.Record)
            {
                //var spClient = new RbacManagementClient(TestEnvironment.TenantId, TestEnvironment.Credential).ServicePrincipals;
                //var servicePrincipals = spClient.List($"appId eq '{TestEnvironment.ClientId}'").ToImmutableList();
                //this.ObjectId = servicePrincipals.ObjectId;
                //Recording.GetVariable(ObjectIdKey, this.ObjectId);
                this.ObjectId = TestEnvironment.ClientId;
                Recording.GetVariable(ObjectIdKey, this.ObjectId);
            }

            ResourceGroupName = Recording.GenerateAssetName("hdiaks-testrg-");
            var resourceGroupCollection = Subscription.GetResourceGroups();
            var resourceGroupResponse = await resourceGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceGroupName, new ResourceGroupData(new AzureLocation(Location))).ConfigureAwait(false);
            ResourceGroup = resourceGroupResponse.Value;
            //TenantIdGuid = new Guid(TestEnvironment.TenantId);
        }
    }
}
