// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Network.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class NetworkManagementClientLiveTestBase : ManagementRecordedTestBase<NetworkManagementTestEnvironment>
    {
        public string ResourceGroupPrefix { get; }
        public string ResourceLocation { get; }
        public string ResourceDataLocation { get; }
        public string SubscriptionId { get; set; }
        public string Location { get; set; }
        public string NotificationHubsResourceGroupName { get; set; }
        public string NotificationHubsResourceId { get; set; }
        public string NotificationHubsConnectionString { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }

        protected NetworkManagementClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            ResourceGroupPrefix = "rg-sdk-test-net-";
            ResourceLocation = "global";
            ResourceDataLocation = "UnitedStates";
            SubscriptionId = "";
            Location = "";
            Sanitizer = new NetworkManagementRecordedTestSanitizer();
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            Location = TestEnvironment.Location;
            NotificationHubsResourceGroupName = TestEnvironment.NotificationHubsResourceGroupName;
            NotificationHubsResourceId = TestEnvironment.NotificationHubsResourceId;
            NotificationHubsConnectionString = TestEnvironment.NotificationHubsConnectionString;

            ResourcesManagementClient = GetResourceManagementClient();
        }

        internal NetworkManagementClient GetCommunicationManagementClient()
        {
            return InstrumentClient(new NetworkManagementClient(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new NetworkManagementClientOptions())));
        }
    }
}
