// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Azure.Management.Dns.Tests;

namespace Azure.ResourceManager.Dns.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class DnsManagementClientBase : ManagementRecordTestBase<DnsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public ProvidersOperations ResourceProvidersOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public RecordSetsOperations RecordSetsOperations { get; set; }
        public DnsManagementClient DnsManagementClient { get; set; }
        public ZonesOperations ZonesOperations { get; set; }

        protected string location;
        protected string resourceGroup;
        protected DnsManagementClientBase(bool isAsync) : base(isAsync)
        {

        }
        protected override async Task OnOneTimeSetupAsync()
        {
            location = "West US";
            InitializeClients();
            this.resourceGroup = Recording.GenerateAssetName("Default-Dns-");
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, this.location, this.resourceGroup);
        }

        protected override void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = this.GetResourceManagementClient();
            ResourcesOperations = ResourcesManagementClient.Resources;
            ResourceProvidersOperations = ResourcesManagementClient.Providers;
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            DnsManagementClient = this.GetManagementClient<DnsManagementClient>(new DnsManagementClientOptions(), TestEnvironment.SubscriptionId);
            RecordSetsOperations = DnsManagementClient.RecordSets;
            ZonesOperations = DnsManagementClient.Zones;
        }

    }
}