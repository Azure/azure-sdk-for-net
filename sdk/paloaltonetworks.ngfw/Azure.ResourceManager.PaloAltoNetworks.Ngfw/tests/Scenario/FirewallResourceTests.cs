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
        protected FirewallResource DefaultResource1 { get; set; }
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
                DefaultResource1 = (await ResGroup.GetFirewallResources().GetAsync("dotnetSdkTest-default-1")).Value;
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string firewallResourceName = Recording.GenerateAssetName("dotnetSdkTest-");
            ResourceIdentifier firewallResourceIdentifier = FirewallResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, firewallResourceName);
            FirewallResource.ValidateResourceId(firewallResourceIdentifier);

            Assert.IsTrue(firewallResourceIdentifier.ResourceType.Equals(FirewallResource.ResourceType));
            Assert.IsTrue(firewallResourceIdentifier.Equals($"{ResGroup.Id}/providers/{FirewallResource.ResourceType}/{firewallResourceName}"));
            Assert.Throws<ArgumentException>(() => FirewallResource.ValidateResourceId(ResGroup.Data.Id));
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
            FirewallResourcePatch firewallResourcePatch = new FirewallResourcePatch();
            firewallResourcePatch.Tags.Add("Counter", "1");
            FirewallResource updatedResource =  await DefaultResource1.UpdateAsync(firewallResourcePatch);

            Assert.AreEqual(updatedResource.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await DefaultResource1.UpdateAsync( null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            FirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter", "2");
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
            FirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter1", "3");
            IDictionary<string, string> tags = new Dictionary<string, string>() { { "Counter2", "4" }, { "Counter3", "5"} };
            FirewallResource updatedResource2 = await updatedResource.SetTagsAsync(tags);
            Assert.AreEqual(tags.Count, 2);
            Assert.AreEqual(updatedResource2.Data.Tags, tags);
            string value = "";
            Assert.IsFalse(updatedResource2.Data.Tags.TryGetValue("Counter1", out value));
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            FirewallResource updatedResource = await DefaultResource1.AddTagAsync("Counter1", "3");
            FirewallResource updatedResource2 = await updatedResource.RemoveTagAsync("Counter1");
            string value = "";
            Assert.IsFalse(updatedResource2.Data.Tags.TryGetValue("Counter1", out value));
        }

        [TestCase]
        [RecordedTest]
        public async Task SaveLogProfile()
        {
            MonitorLog monitorConfigurations = new MonitorLog(
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics",
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27",
                "22c8efd2-0d44-436a-8c0f-0a31c8a25a84",
                "jLX7mBxd7KV4h3redpprhvLUNhghoEGC7SARTkcf/viX17d0YCgV+AUs2tPvNAZm6bKUVl0K0fUiTryN0SRcXQ==",
                "qtNFUdejZrGVn5hKj/az1tiKMBC/oODFFKoOFQ+Qi4RVwoaM5H+ON4gQyrZJhserFOTdWhnPzP7szPufL1xP7A=="
                );
            LogDestination commonDestination = new LogDestination(null, null, monitorConfigurations);
            LogSettings logSettings = new LogSettings(LogType.Traffic, LogOption.SameDestination, new ApplicationInsights(null, null), commonDestination, null, null, null);
            await DefaultResource1.SaveLogProfileAsync(logSettings);
            FirewallResource updatedResource = await ResGroup.GetFirewallResources().GetAsync("dotnetSdkTest-default-1");
            LogSettings updatedlogProfile = await updatedResource.GetLogProfileAsync();
            Assert.IsNotNull(updatedlogProfile);
            Assert.AreEqual(updatedlogProfile.CommonDestination.MonitorConfigurations.Id, "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLogProfile()
        {
            MonitorLog monitorConfigurations = new MonitorLog(
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics",
                "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27",
                "22c8efd2-0d44-436a-8c0f-0a31c8a25a84",
                "jLX7mBxd7KV4h3redpprhvLUNhghoEGC7SARTkcf/viX17d0YCgV+AUs2tPvNAZm6bKUVl0K0fUiTryN0SRcXQ==",
                "qtNFUdejZrGVn5hKj/az1tiKMBC/oODFFKoOFQ+Qi4RVwoaM5H+ON4gQyrZJhserFOTdWhnPzP7szPufL1xP7A=="
                );
            LogDestination commonDestination = new LogDestination(null, null, monitorConfigurations);
            LogSettings logSettings = new LogSettings(LogType.Traffic, LogOption.SameDestination, new ApplicationInsights(null, null), commonDestination, null, null, null);
            await DefaultResource1.SaveLogProfileAsync(logSettings);
            FirewallResource updatedResource = await ResGroup.GetFirewallResources().GetAsync("dotnetSdkTest-default-1");
            LogSettings updatedlogProfile = await updatedResource.GetLogProfileAsync();
            Assert.IsNotNull(updatedlogProfile);
            Assert.AreEqual(updatedlogProfile.CommonDestination.MonitorConfigurations.Id, "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/dotnetSdkTest-infra-rg/providers/Microsoft.OperationalInsights/workspaces/dotnetSdkTest-logAnalytics");
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
            FirewallResourceCollection collection = ResGroup.GetFirewallResources();
            FirewallResource resourceForDeletion = IsAsync ? (await collection.GetAsync("dotnetSdkTest-default-delAsync")) : (await collection.GetAsync("dotnetSdkTest-default-delSync"));
            await resourceForDeletion.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await ResGroup.GetFirewallResources().ExistsAsync(resourceForDeletion.Data.Name));
        }
    }
}
