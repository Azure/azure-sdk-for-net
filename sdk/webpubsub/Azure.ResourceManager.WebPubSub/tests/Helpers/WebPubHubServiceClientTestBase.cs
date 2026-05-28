// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WebPubSub.Tests.Helpers
{
    public class WebPubHubServiceClientTestBase : ManagementRecordedTestBase<WebPubSubManagementTestEnvironment>
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";
        public WebPubHubServiceClientTestBase(bool isAsync) : base(isAsync)
        {
            IgnoreTestInLiveMode();
            IgnoreNetworkDependencyVersions();
        }
        public WebPubHubServiceClientTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreTestInLiveMode();
            IgnoreNetworkDependencyVersions();
        }

        public ArmClient ArmClient { get; set; }
        protected AzureLocation DefaultLocation = AzureLocation.WestUS2;
        public SubscriptionResource Subscription
        {
            get
            {
                return ArmClient.GetDefaultSubscription();
            }
        }

        public Resources.ResourceGroupResource ResourceGroupResource
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public Resources.ResourceGroupResource GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().Get(name).Value;
        }

        protected void Initialize()
        {
            ArmClient = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string name)
        {
            return (await Subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, name, new ResourceGroupData(TestEnvironment.Location))).Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string name, string location)
        {
            return (await Subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, name, new ResourceGroupData(location))).Value;
        }

        protected async Task<WebPubSubResource> CreateDefaultWebPubSub(string webPubSubName, AzureLocation location, ResourceGroupResource resourceGroup)
        {
            // Create WebPubSub ConfigData
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>()
            {
                new LiveTraceCategory()
                {
                    Name = "category-01",
                    IsEnabled = true,
                },
            };

            AclAction aclAction = new AclAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>() { new WebPubSubRequestType("RESTAPI") };
            PublicNetworkAcls publicNetwork = new PublicNetworkAcls(allow, deny, null);
            IList<PrivateEndpointAcl> privateEndpoints = new List<PrivateEndpointAcl>();

            List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
            {
                new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
            };

            WebPubSubData data = new WebPubSubData(AzureLocation.WestUS2)
            {
                Sku = new BillingInfoSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                NetworkAcls = new WebPubSubNetworkAcls(aclAction, publicNetwork, privateEndpoints, null),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory, null),
            };

            // Create WebPubSub
            var webPubSub = await (await resourceGroup.GetWebPubSubs().CreateOrUpdateAsync(WaitUntil.Completed, webPubSubName, data)).WaitForCompletionAsync();

            return webPubSub.Value;
        }

        private void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }
    }
}
