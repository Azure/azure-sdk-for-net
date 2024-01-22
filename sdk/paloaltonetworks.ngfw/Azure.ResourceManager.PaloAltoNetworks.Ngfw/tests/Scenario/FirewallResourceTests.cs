// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    internal class FirewallResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected PaloAltoNetworksFirewallResource DefaultResource1 { get; set; }
        public FirewallResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public FirewallResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                DefaultResource1 = (await ResGroup.GetPaloAltoNetworksFirewalls().GetAsync("dotnetSdkTest-default-1")).Value;
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string firewallResourceName = Recording.GenerateAssetName("dotnetSdkTest-");
            ResourceIdentifier firewallResourceIdentifier = PaloAltoNetworksFirewallResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, firewallResourceName);
            PaloAltoNetworksFirewallResource.ValidateResourceId(firewallResourceIdentifier);

            Assert.IsTrue(firewallResourceIdentifier.ResourceType.Equals(PaloAltoNetworksFirewallResource.ResourceType));
            Assert.IsTrue(firewallResourceIdentifier.Equals($"{ResGroup.Id}/providers/{PaloAltoNetworksFirewallResource.ResourceType}/{firewallResourceName}"));
            Assert.Throws<ArgumentException>(() => PaloAltoNetworksFirewallResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(DefaultResource1.HasData);
            Assert.NotNull(DefaultResource1.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            PaloAltoNetworksFirewallPatch firewallResourcePatch = new PaloAltoNetworksFirewallPatch();
            firewallResourcePatch.Tags.Add("Counter", "1");
            PaloAltoNetworksFirewallResource updatedResource =  await DefaultResource1.UpdateAsync(firewallResourcePatch);

            Assert.AreEqual(updatedResource.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await DefaultResource1.UpdateAsync( null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            PaloAltoNetworksFirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter", "2");
            string value = "";
            Assert.IsTrue(updatedResource.Data.Tags.TryGetValue("Counter", out value));
            Assert.AreEqual(value, "2");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await DefaultResource1.AddTagAsync(null, "1")).Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await DefaultResource1.AddTagAsync("Counter", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTag()
        {
            PaloAltoNetworksFirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter1", "3");
            IDictionary<string, string> tags = new Dictionary<string, string>() { { "Counter2", "4" }, { "Counter3", "5"} };
            PaloAltoNetworksFirewallResource updatedResource2 = await updatedResource.SetTagsAsync(tags);
            Assert.AreEqual(tags.Count, 2);
            Assert.AreEqual(updatedResource2.Data.Tags, tags);
            string value = "";
            Assert.IsFalse(updatedResource2.Data.Tags.TryGetValue("Counter1", out value));
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            PaloAltoNetworksFirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter1", "3");
            PaloAltoNetworksFirewallResource updatedResource2 = await updatedResource.RemoveTagAsync("Counter1");
            string value = "";
            Assert.IsFalse(updatedResource2.Data.Tags.TryGetValue("Counter1", out value));
        }

        [TestCase]
        [RecordedTest]
        public async Task SaveLogProfile()
        {
            MonitorLogConfiguration monitorConfigurations = new MonitorLogConfiguration(
                new ResourceIdentifier("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics"),
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27",
                "22c8efd2-0d44-436a-8c0f-0a31c8a25a84",
                "",
                "",
                null);
            FirewallLogDestination commonDestination = new FirewallLogDestination(null, null, monitorConfigurations, null);
            FirewallLogSettings logSettings = new FirewallLogSettings(FirewallLogType.Traffic, FirewallLogOption.SameDestination, new FirewallApplicationInsights(null, null, null), commonDestination, null, null, null, null);
            await DefaultResource1.SaveLogProfileAsync(logSettings);
            PaloAltoNetworksFirewallResource updatedResource = await ResGroup.GetPaloAltoNetworksFirewalls().GetAsync("dotnetSdkTest-default-1");
            FirewallLogSettings updatedlogProfile = await updatedResource.GetLogProfileAsync();
            Assert.IsNotNull(updatedlogProfile);
            Assert.AreEqual(updatedlogProfile.CommonDestination.MonitorConfiguration.Id, "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogProfile()
        {
            MonitorLogConfiguration monitorConfigurations = new MonitorLogConfiguration(
                new ResourceIdentifier("/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics"),
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27",
                "22c8efd2-0d44-436a-8c0f-0a31c8a25a84",
                "jLX7mBxd7KV4h3redpprhvLUNhghoEGC7SARTkcf/viX17d0YCgV+AUs2tPvNAZm6bKUVl0K0fUiTryN0SRcXQ==",
                "qtNFUdejZrGVn5hKj/az1tiKMBC/oODFFKoOFQ+Qi4RVwoaM5H+ON4gQyrZJhserFOTdWhnPzP7szPufL1xP7A==",
                null);
            FirewallLogDestination commonDestination = new FirewallLogDestination(null, null, monitorConfigurations, null);
            FirewallLogSettings logSettings = new FirewallLogSettings(FirewallLogType.Traffic, FirewallLogOption.SameDestination, new FirewallApplicationInsights(null, null, null), commonDestination, null, null, null, null);
            await DefaultResource1.SaveLogProfileAsync(logSettings);
            PaloAltoNetworksFirewallResource updatedResource = await ResGroup.GetPaloAltoNetworksFirewalls().GetAsync("dotnetSdkTest-default-1");
            FirewallLogSettings updatedlogProfile = await updatedResource.GetLogProfileAsync();
            Assert.IsNotNull(updatedlogProfile);
            Assert.AreEqual(updatedlogProfile.CommonDestination.MonitorConfiguration.Id, "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGlobalRulestack()
        {
            GlobalRulestackInfo info = (await DefaultResource1.GetGlobalRulestackAsync()).Value;
            Assert.IsNotNull(info);
            Assert.IsEmpty(info.AzureId);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            PaloAltoNetworksFirewallCollection collection = ResGroup.GetPaloAltoNetworksFirewalls();
            PaloAltoNetworksFirewallResource resourceForDeletion = IsAsync ? (await collection.GetAsync("dotnetSdkTest-default-delAsync")) : (await collection.GetAsync("dotnetSdkTest-default-delSync"));
            await resourceForDeletion.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await ResGroup.GetPaloAltoNetworksFirewalls().ExistsAsync(resourceForDeletion.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportInfo()
        {
            FirewallSupportInfo response = await DefaultResource1.GetSupportInfoAsync();
            Assert.NotNull(response);
            Assert.AreEqual("https://live.paloaltonetworks.com?productSku=PAN-CLOUD-NGFW-AZURE-PAYG", response.HelpURL);
        }
    }
}
