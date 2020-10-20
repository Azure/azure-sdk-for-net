// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
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
        public DnsManagementClient DnsManagementClient { get; set; }
        protected string location;
        protected string resourceGroup;
        protected DnsManagementClientBase(bool isAsync) : base(isAsync)
        {

        }
        protected override async Task OnOneTimeSetupAsync()
        {
            location = "West US";
            this.resourceGroup = Recording.GenerateAssetName("Default-Dns-");
            await Helper.TryRegisterResourceGroupAsync(ResourcesManagementClient.ResourceGroups, this.location, this.resourceGroup);
        }

        protected override void InitializeClients()
        {
            ResourcesManagementClient = this.GetResourceManagementClient();
            DnsManagementClient = this.GetManagementClient<DnsManagementClient>(new DnsManagementClientOptions());
        }

    }
}
