// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.ResourceManager.WebPubSub.Tests.Helpers
{
    [RunFrequency(RunTestFrequency.Manually)]
    public class WebPubHubServiceClientTestBase : ManagementRecordedTestBase<WebPubSubManagementTestEnvironment>
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";
        public WebPubHubServiceClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public bool IsTestTenant = false;
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);
        public Dictionary<string, string> Tags { get; internal set; }

        public ArmClient ArmClient { get; set; }

        public Resources.Subscription Subscription
        {
            get
            {
                return ArmClient.GetDefaultSubscription();
            }
        }

        public Resources.ResourceGroup ResourceGroup
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public Resources.ResourceGroup GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().Get(name).Value;
        }

        protected void Initialize()
        {
            ArmClient = GetArmClient();
        }

        protected async Task<ResourceGroup> CreateResourceGroup(string name)
        {
            return (await Subscription.GetResourceGroups().CreateOrUpdateAsync(name, new ResourceGroupData(TestEnvironment.Location))).Value;
        }

        protected async Task<ResourceGroup> CreateResourceGroup(string name, string location)
        {
            return (await Subscription.GetResourceGroups().CreateOrUpdateAsync(name, new ResourceGroupData(location))).Value;
        }

        protected async Task<WebPubSub> CreateDefaultWebPubSub(string webPubSubName, Location location, ResourceGroup resourceGroup)
        {
            // Create WebPubSub ConfigData
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>()
            {
                new LiveTraceCategory("category-01", "true"),
            };

            AclAction aclAction = new AclAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>() { new WebPubSubRequestType("RESTAPI") };
            NetworkAcl publicNetwork = new NetworkAcl(allow, deny);
            IList<PrivateEndpointAcl> privateEndpoints = new List<PrivateEndpointAcl>();

            List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
            {
                new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
            };

            WebPubSubData data = new WebPubSubData(Location.WestUS2)
            {
                Sku = new WebPubSubSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                NetworkAcls = new WebPubSubNetworkAcls(aclAction, publicNetwork, privateEndpoints),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory),
            };

            // Create WebPubSub
            var webPubSub = await (await resourceGroup.GetWebPubSubs().CreateOrUpdateAsync(webPubSubName, data)).WaitForCompletionAsync();

            return webPubSub.Value;
        }
    }
}
