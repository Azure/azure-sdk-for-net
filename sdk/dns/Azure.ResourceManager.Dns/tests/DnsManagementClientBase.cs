// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Dns.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class DnsManagementClientBase : ManagementRecordedTestBase<DnsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        public ProvidersOperations ResourceProvidersOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public RecordSetsOperations RecordSetsOperations { get; set; }
        public DnsManagementClient DnsManagementClient { get; set; }
        public ZonesOperations ZonesOperations { get; set; }
        protected DnsManagementClientBase(bool isAsync) : base(isAsync)
        {
        }
        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = this.GetResourceManagementClient();
            ResourcesOperations = ResourcesManagementClient.Resources;
            ResourceProvidersOperations = ResourcesManagementClient.Providers;
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            DnsManagementClient = this.GetDnsManagementClient();
            RecordSetsOperations = DnsManagementClient.RecordSets;
            ZonesOperations = DnsManagementClient.Zones;
        }
        protected void initNewRecord()
        {
            ResourcesManagementClient = this.GetResourceManagementClient();
            ResourcesOperations = ResourcesManagementClient.Resources;
            ResourceProvidersOperations = ResourcesManagementClient.Providers;
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            DnsManagementClient = this.GetDnsManagementClient();
            RecordSetsOperations = DnsManagementClient.RecordSets;
            ZonesOperations = DnsManagementClient.Zones;
        }

        internal DnsManagementClient GetDnsManagementClient()
        {
            return CreateClient<DnsManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential, InstrumentClientOptions(new DnsManagementClientOptions()));
        }
    }
}
