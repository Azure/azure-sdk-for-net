// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.TestFramework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class AppConfigurationClientBase : ManagementRecordedTestBase<AppConfigurationManagementTestEnvironment>
    {
        public AppConfigurationManagementClient AppConfigurationManagementClient { get; set; }
        public ArmClient ArmClient { get; set; }
        public ConfigurationStoresOperations ConfigurationStoresOperations { get; set; }
        public PrivateEndpointConnectionsOperations PrivateEndpointConnectionsOperations { get; set; }
        public ResourceGroupCollection ResourceGroupCollection { get; set; }
        public VirtualNetworkCollection VirtualNetworkCollection { get; set; }
        public PrivateEndpointCollection PrivateEndpointCollection { get; set; }
        public PrivateLinkResourcesOperations PrivateLinkResourcesOperations { get; set; }
        public Operations Operations { get; set; }
        public string AzureLocation { get; set; }
        public string KeyUuId { get; set; }
        public string LabelUuId { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string TestContentType { get; set; }
        public string TestValue { get; set; }
        public string ResourceGroupPrefix { get; set; }
        protected AppConfigurationClientBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected AppConfigurationClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected async Task Initialize()
        {
            AzureLocation = "eastus";
            KeyUuId = "test_key_a6af8952-54a6-11e9-b600-2816a84d0309";
            LabelUuId = "1d7b2b28-549e-11e9-b51c-2816a84d0309";
            Key = "PYTHON_UNIT_" + KeyUuId;
            Label = "test_label1_" + LabelUuId;
            TestContentType = "test content type";
            TestValue = "test value";
            ResourceGroupPrefix = "Default-AppConfiguration-";
            AppConfigurationManagementClient = GetAppConfigurationManagementClient();
            ConfigurationStoresOperations = AppConfigurationManagementClient.ConfigurationStores;
            PrivateEndpointConnectionsOperations = AppConfigurationManagementClient.PrivateEndpointConnections;
            PrivateLinkResourcesOperations = AppConfigurationManagementClient.PrivateLinkResources;
            Operations = AppConfigurationManagementClient.Operations;
            ArmClient = GetArmClient(); // TODO: use base.GetArmClient when switching to new mgmt test framework
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection = sub.GetResourceGroups();
        }

        internal AppConfigurationManagementClient GetAppConfigurationManagementClient()
        {
            return CreateClient<AppConfigurationManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new AppConfigurationManagementClientOptions()));
        }
        internal ArmClient GetArmClient()
        {
            var options = InstrumentClientOptions(new ArmClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ArmClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }
    }
}
