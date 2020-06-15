// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Management.Compute;
using Azure.Management.Resources;
using Azure.Management.Storage;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    [RunFrequency(RunTestFrequency.Manually)]
    public class NetworkTestsManagementClientBase : ManagementRecordedTestBase<NetworkManagementTestEnvironment>
    {
        public bool IsTestTenant = false;
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);
        public Dictionary<string, string> Tags { get; internal set; }

        public ResourcesManagementClient ResourceManagementClient { get; set; }
        public StorageManagementClient StorageManagementClient { get; set; }
        public ComputeManagementClient ComputeManagementClient { get; set; }
        public NetworkManagementClient NetworkManagementClient { get; set; }

        public NetworkInterfacesOperations NetworkInterfacesOperations { get; set; }
        public ProvidersOperations ProvidersOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public ServiceOperations ServiceOperations { get; set; }
        public PrivateLinkServicesOperations PrivateLinkServicesOperations { get; set; }
        protected NetworkTestsManagementClientBase(bool isAsync) : base(isAsync)
        {
        }

        protected void Initialize()
        {
            ResourceManagementClient = GetResourceManagementClient();
            StorageManagementClient = GetStorageManagementClient();
            ComputeManagementClient = GetComputeManagementClient();
            NetworkManagementClient = GetNetworkManagementClient();

            NetworkInterfacesOperations = NetworkManagementClient.NetworkInterfaces;
            ProvidersOperations = ResourceManagementClient.Providers;
            ResourceGroupsOperations = ResourceManagementClient.ResourceGroups;
            ResourcesOperations = ResourceManagementClient.Resources;
            ServiceOperations = NetworkManagementClient.Service;
            PrivateLinkServicesOperations = NetworkManagementClient.PrivateLinkServices;
        }

        private StorageManagementClient GetStorageManagementClient()
        {
            return InstrumentClient(new StorageManagementClient(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 Recording.InstrumentClientOptions(new StorageManagementClientOptions())));
        }

        private ComputeManagementClient GetComputeManagementClient()
        {
            return InstrumentClient(new ComputeManagementClient(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 Recording.InstrumentClientOptions(new ComputeManagementClientOptions())));
        }

        private NetworkManagementClient GetNetworkManagementClient()
        {
            return InstrumentClient(new NetworkManagementClient(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 Recording.InstrumentClientOptions(new NetworkManagementClientOptions())));
        }
    }
}
