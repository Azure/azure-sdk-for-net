﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class AppConfigurationClientBase : ManagementRecordedTestBase<AppConfigurationManagementTestEnvironment>
    {
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);
        public AppConfigurationManagementClient AppConfigurationManagementClient { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ConfigurationStoresOperations ConfigurationStoresOperations { get; set; }
        public PrivateEndpointConnectionsOperations PrivateEndpointConnectionsOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
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

        protected void Initialize()
        {
            AzureLocation = "eastus";
            KeyUuId = "test_key_a6af8952-54a6-11e9-b600-2816a84d0309";
            LabelUuId = "1d7b2b28-549e-11e9-b51c-2816a84d0309";
            Key = "PYTHON_UNIT_" + KeyUuId;
            Label = "test_label1_" + LabelUuId;
            TestContentType = "test content type";
            TestValue = "test value";
            ResourceGroupPrefix = "Default-EventHub-";
            AppConfigurationManagementClient = GetAppConfigurationManagementClient();
            ConfigurationStoresOperations = AppConfigurationManagementClient.ConfigurationStores;
            PrivateEndpointConnectionsOperations = AppConfigurationManagementClient.PrivateEndpointConnections;
            PrivateLinkResourcesOperations = AppConfigurationManagementClient.PrivateLinkResources;
            Operations = AppConfigurationManagementClient.Operations;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
        }

        internal AppConfigurationManagementClient GetAppConfigurationManagementClient()
        {
            return CreateClient<AppConfigurationManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new AppConfigurationManagementClientOptions()));
        }
    }
}
