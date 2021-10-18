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
        public string ResourceGroupPrefix { get; private set; }
        public string ResourceLocation { get; private set; }
        public string ResourceDataLocation { get; private set; }
        public string SubscriptionId { get; set; }
        public string Location { get; set; }
        public string NotificationHubsResourceGroupName { get; set; }
        public string NotificationHubsResourceId { get; set; }
        public string NotificationHubsConnectionString { get; set; }
        public ArmClient ArmClient { get; set; }

        protected CommunicationManagementClientLiveTestBase(bool isAsync)
            : base(isAsync)
        {
            Init();
        }

        private void Init()
        {
            ResourceGroupPrefix = "rg-sdk-test-net-";
            ResourceLocation = "global";
            ResourceDataLocation = "UnitedStates";
            SubscriptionId = "";
            Location = "";
            Sanitizer = new CommunicationManagementRecordedTestSanitizer();
        }

        protected CommunicationManagementClientLiveTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            Init();
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            Location = TestEnvironment.Location;
            NotificationHubsResourceGroupName = TestEnvironment.NotificationHubsResourceGroupName;
            NotificationHubsResourceId = TestEnvironment.NotificationHubsResourceId;
            NotificationHubsConnectionString = TestEnvironment.NotificationHubsConnectionString;

            ArmClient = GetArmClient();
        }
    }
}
