// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Xml.Linq;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    internal class LocalRulestackResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected LocalRulestackResource LocalRulestackResource { get; set; }
        protected LocalRulestackResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public LocalRulestackResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestackResource = await ResGroup.GetLocalRulestackResources().GetAsync("dotnetSdkTest-lrs-default");
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string localRulestackResourceName = Recording.GenerateAssetName("dotnetSdkTest-");
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, localRulestackResourceName);
            LocalRulestackResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(LocalRulestackResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{localRulestackResourceName}"));
            Assert.Throws<ArgumentException>(() => LocalRulestackResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(LocalRulestackResource.HasData);
            Assert.NotNull(LocalRulestackResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            LocalRulestackResourcePatch localRulestackResourcePatch = new LocalRulestackResourcePatch();
            localRulestackResourcePatch.Tags.Add("Counter", "1");
            LocalRulestackResource updatedResource = await LocalRulestackResource.UpdateAsync(localRulestackResourcePatch);

            Assert.AreEqual(updatedResource.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulestackResource.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            LocalRulestackResource updatedResource = (await LocalRulestackResource.AddTagAsync("Counter", "2")).Value;

            Assert.AreEqual(updatedResource.Data.Tags["Counter"], "2");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulestackResource.AddTagAsync(null, "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulestackResource.AddTagAsync("Counter", null));
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTag()
        {
            LocalRulestackResource updatedResource = await LocalRulestackResource.AddTagAsync("Counter1", "3");
            IDictionary<string, string> tags = new Dictionary<string, string>() { { "Counter2", "4" }, { "Counter3", "5" } };
            LocalRulestackResource updatedResource2 = (await updatedResource.SetTagsAsync(tags)).Value;
            Assert.AreEqual(updatedResource2.Data.Tags, tags);
            Assert.IsFalse(updatedResource2.Data.Tags.ContainsKey("Counter1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            LocalRulestackResource updatedResource = await LocalRulestackResource.AddTagAsync("Counter1", "3");
            LocalRulestackResource updatedResource2 = await updatedResource.RemoveTagAsync("Counter1");
            Assert.IsFalse(updatedResource2.Data.Tags.ContainsKey("Counter1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            LocalRulestackResourceCollection collection = ResGroup.GetLocalRulestackResources();
            LocalRulestackResource resourceForDeletion = IsAsync ? (await collection.GetAsync("dotnetSdkTest-default-delAsync-lrs")) : (await collection.GetAsync("dotnetSdkTest-default-delSync-lrs"));
            await resourceForDeletion.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await collection.ExistsAsync(resourceForDeletion.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetCertificateObjectLocalRulestackResource()
        {
            CertificateObjectLocalRulestackResource cert = await LocalRulestackResource.GetCertificateObjectLocalRulestackResourceAsync("dotnetSdkTest-cert");
            Assert.NotNull(cert);
            Assert.AreEqual(cert.Data.Name, "dotnetSdkTest-cert");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetFqdnListLocalRulestackResource()
        {
            FqdnListLocalRulestackResource list = await LocalRulestackResource.GetFqdnListLocalRulestackResourceAsync("dotnetSdkTest-fqdnList");
            Assert.NotNull(list);
            Assert.AreEqual(list.Data.Name, "dotnetSdkTest-fqdnList");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLocalRulesResource()
        {
            LocalRulesResourceCollection rulesCollection = LocalRulestackResource.GetLocalRulesResources();
            LocalRulesResource rule = await rulesCollection.GetAsync("1000000");
            Assert.NotNull(rule);
            Assert.AreEqual(rule.Data.RuleName, "cloud-ngfw-default-rule");
        }

        [TestCase]
        [RecordedTest]
        public async Task GetPrefixListResource()
        {
            PrefixListResource list = await LocalRulestackResource.GetPrefixListResourceAsync("dotnetSdkTest-prefixList");
            Assert.NotNull(list);
            Assert.AreEqual(list.Data.Name, "dotnetSdkTest-prefixList");
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackResource resource = await LocalRulestackResource.GetAsync();
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, LocalRulestackResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Commit()
        {
            var rule = (await LocalRulestackResource.GetLocalRulesResourceAsync("1000000")).Value;
            LocalRulesResourceData ruleData = rule.Data;
            ruleData.Description = "Updated description for commit";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            Changelog log = (await LocalRulestackResource.GetChangeLogAsync()).Value;
            Assert.IsTrue(log.Changes.Contains("LocalRule"));
            Assert.IsTrue(log.Changes.Contains("Rulestack"));
            Assert.AreEqual(log.Changes.Count, 2);
            ArmOperation response = await LocalRulestackResource.CommitAsync(WaitUntil.Completed);
            Assert.AreEqual(response.GetRawResponse().Status, 200);
            log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.AreEqual(log.Changes.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetChangeLog()
        {
            LocalRulesResource rule = await LocalRulestackResource.GetLocalRulesResourceAsync("1000000");
            LocalRulesResourceData ruleData = rule.Data;
            ruleData.Description = "Updated description for changeLog";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            Changelog log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.IsTrue(log.Changes.Contains("LocalRule"));
            Assert.IsTrue(log.Changes.Contains("Rulestack"));
            Assert.AreEqual(log.Changes.Count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Revert()
        {
            LocalRulesResource rule = await LocalRulestackResource.GetLocalRulesResourceAsync("1000000");
            LocalRulesResourceData ruleData = rule.Data;
            ruleData.Description = "Updated description for revert";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            Changelog log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.IsTrue(log.Changes.Contains("LocalRule"));
            Assert.IsTrue(log.Changes.Contains("Rulestack"));
            Assert.AreEqual(log.Changes.Count, 2);
            Response response = await LocalRulestackResource.RevertAsync();
            Assert.AreEqual(response.Status, 204);
            log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.AreEqual(log.Changes.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public void GetAppIds()
        {
            AsyncPageable<string> ids = LocalRulestackResource.GetAppIdsAsync();
            Assert.NotNull(ids);
        }

        [TestCase]
        [RecordedTest]
        public void GetCountries()
        {
            AsyncPageable<Country> countries = LocalRulestackResource.GetCountriesAsync();
            Assert.NotNull(countries);
        }

        [TestCase]
        [RecordedTest]
        public void GetFirewalls()
        {
            AsyncPageable<string> firewalls = LocalRulestackResource.GetFirewallsAsync();
            Assert.NotNull(firewalls);
        }

        [TestCase]
        [RecordedTest]
        public void GetPredefinedUrlCategories()
        {
            AsyncPageable<PredefinedUrlCategory> response = LocalRulestackResource.GetPredefinedUrlCategoriesAsync();
            Assert.NotNull(response);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportInfo()
        {
            SupportInfo response = await LocalRulestackResource.GetSupportInfoAsync();
            Assert.NotNull(response);
            Assert.AreEqual("https://live.paloaltonetworks.com?productSku=PAN-CLOUD-NGFW-AZURE-PAYG", response.HelpURL);
        }
    }
}
