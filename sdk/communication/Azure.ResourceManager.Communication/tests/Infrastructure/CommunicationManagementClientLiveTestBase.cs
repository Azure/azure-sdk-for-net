// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CommunicationManagementClientLiveTestBase : ManagementRecordedTestBase<CommunicationManagementTestEnvironment>
    {
        public string ResourceGroupPrefix { get; }
        public string ResourceLocation { get; }
        public string ResourceDataLocation { get; }
        public string SubscriptionId { get; set; }
        public string Location { get; set; }
        public string NotificationHubsResourceGroupName { get; set; }
        public string NotificationHubsResourceId { get; set; }
        public string NotificationHubsConnectionString { get; set; }
        public ArmClient ResourcesManagementClient { get; set; }

        protected CommunicationManagementClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            ResourceGroupPrefix = "rg-sdk-test-net-";
            ResourceLocation = "global";
            ResourceDataLocation = "UnitedStates";
            SubscriptionId = "";
            Location = "";
            //Sanitizer = new CommunicationManagementRecordedTestSanitizer();
        }

        protected void InitializeClients()
        {
            SubscriptionId = "f3d94233-a9aa-4241-ac82-2dfb63ce637a";
            Location = "westus";
            NotificationHubsResourceGroupName = "rg-sdk-test-comm-link-notif-hub";
            NotificationHubsResourceId = "/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourcegroups/rg-sdk-test-comm-link-notif-hub/providers/Microsoft.NotificationHubs/namespaces/notif-hub-namespace-test/notificationHubs/notif-hub-test-comm-link";
            NotificationHubsConnectionString = "Sanitized";
            //SubscriptionId = TestEnvironment.SubscriptionId;
            //Location = TestEnvironment.Location;
            //NotificationHubsResourceGroupName = TestEnvironment.NotificationHubsResourceGroupName;
            //NotificationHubsResourceId = TestEnvironment.NotificationHubsResourceId;
            //NotificationHubsConnectionString = TestEnvironment.NotificationHubsConnectionString;

            ResourcesManagementClient = GetResourceManagementClient();
        }

        internal CommunicationManagementClient GetCommunicationManagementClient()
        {
            return InstrumentClient(new CommunicationManagementClient(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new CommunicationManagementClientOptions())));
        }
    }
}
