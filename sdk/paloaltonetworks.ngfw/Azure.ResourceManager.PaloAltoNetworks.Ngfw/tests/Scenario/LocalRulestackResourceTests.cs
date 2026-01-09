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
                LocalRulestackResource = await ResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-lrs-default");
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Due to issue: https://github.com/Azure/azure-sdk-for-net/issues/53815")]
        public void CreateResourceIdentifier()
        {
            string localRulestackResourceName = Recording.GenerateAssetName("dotnetSdkTest-");
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, localRulestackResourceName);
            LocalRulestackResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.Multiple(() =>
            {
                Assert.That(localRulestackResourceIdentifier.ResourceType, Is.EqualTo(LocalRulestackResource.ResourceType));
                Assert.That(localRulestackResourceIdentifier, Is.EqualTo($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{localRulestackResourceName}"));
            });
            Assert.Throws<ArgumentException>(() => LocalRulestackResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.Multiple(() =>
            {
                Assert.That(LocalRulestackResource.HasData, Is.True);
                Assert.That(LocalRulestackResource.Data, Is.Not.Null);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            LocalRulestackPatch localRulestackPatch = new LocalRulestackPatch();
            localRulestackPatch.Tags.Add("Counter", "1");
            LocalRulestackResource updatedResource = await LocalRulestackResource.UpdateAsync(localRulestackPatch);

            Assert.That(updatedResource.Data.Tags["Counter"], Is.EqualTo("1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulestackResource.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            LocalRulestackResource updatedResource = (await LocalRulestackResource.AddTagAsync("Counter", "2")).Value;

            Assert.That(updatedResource.Data.Tags["Counter"], Is.EqualTo("2"));
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
            Assert.Multiple(() =>
            {
                Assert.That(tags, Is.EqualTo(updatedResource2.Data.Tags));
                Assert.That(updatedResource2.Data.Tags.ContainsKey("Counter1"), Is.False);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            LocalRulestackResource updatedResource = await LocalRulestackResource.AddTagAsync("Counter1", "3");
            LocalRulestackResource updatedResource2 = await updatedResource.RemoveTagAsync("Counter1");
            Assert.That(updatedResource2.Data.Tags.ContainsKey("Counter1"), Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            LocalRulestackCollection collection = ResGroup.GetLocalRulestacks();
            LocalRulestackResource resourceForDeletion = IsAsync ? (await collection.GetAsync("dotnetSdkTest-default-delAsync-lrs")) : (await collection.GetAsync("dotnetSdkTest-default-delSync-lrs"));
            await resourceForDeletion.DeleteAsync(WaitUntil.Completed);

            Assert.That((bool)await collection.ExistsAsync(resourceForDeletion.Data.Name), Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetCertificateObjectLocalRulestackResource()
        {
            LocalRulestackCertificateObjectResource cert = await LocalRulestackResource.GetLocalRulestackCertificateObjectAsync("dotnetSdkTest-cert");
            Assert.That(cert, Is.Not.Null);
            Assert.That(cert.Data.Name, Is.EqualTo("dotnetSdkTest-cert"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetFqdnListLocalRulestackResource()
        {
            LocalRulestackFqdnResource list = await LocalRulestackResource.GetLocalRulestackFqdnAsync("dotnetSdkTest-fqdnList");
            Assert.That(list, Is.Not.Null);
            Assert.That(list.Data.Name, Is.EqualTo("dotnetSdkTest-fqdnList"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetLocalRulesResource()
        {
            LocalRulestackRuleCollection rulesCollection = LocalRulestackResource.GetLocalRulestackRules();
            LocalRulestackRuleResource rule = await rulesCollection.GetAsync("1000000");
            Assert.That(rule, Is.Not.Null);
            Assert.That(rule.Data.RuleName, Is.EqualTo("cloud-ngfw-default-rule"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetPrefixListResource()
        {
            LocalRulestackPrefixResource list = await LocalRulestackResource.GetLocalRulestackPrefixAsync("dotnetSdkTest-prefixList");
            Assert.That(list, Is.Not.Null);
            Assert.That(list.Data.Name, Is.EqualTo("dotnetSdkTest-prefixList"));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackResource resource = await LocalRulestackResource.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(resource, Is.Not.Null);
                Assert.That(LocalRulestackResource.Data.Name, Is.EqualTo(resource.Data.Name));
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Commit()
        {
            var rule = (await LocalRulestackResource.GetLocalRulestackRuleAsync("1000000")).Value;
            LocalRulestackRuleData ruleData = rule.Data;
            string suffix = IsAsync ? "async" : "sync";
            ruleData.Description = $"Updated description for commit: {suffix}";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            RulestackChangelog log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.That(log.Changes, Does.Contain("LocalRule"));
            Assert.That(log.Changes, Does.Contain("Rulestack"));
            ArmOperation response = await LocalRulestackResource.CommitAsync(WaitUntil.Completed);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.That(log.Changes.Count, Is.EqualTo(0));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetChangeLog()
        {
            LocalRulestackRuleResource rule = await LocalRulestackResource.GetLocalRulestackRuleAsync("1000000");
            LocalRulestackRuleData ruleData = rule.Data;
            string suffix = IsAsync ? "async" : "sync";
            ruleData.Description = $"Updated description for changeLog: {suffix}";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            RulestackChangelog log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.That(log.Changes, Does.Contain("LocalRule"));
            Assert.That(log.Changes, Does.Contain("Rulestack"));
        }

        [TestCase]
        [RecordedTest]
        public async Task Revert()
        {
            LocalRulestackRuleResource rule = await LocalRulestackResource.GetLocalRulestackRuleAsync("1000000");
            LocalRulestackRuleData ruleData = rule.Data;
            string suffix = IsAsync ? "async" : "sync";
            ruleData.Description = $"Updated description for revert: {suffix}";
            await rule.UpdateAsync(WaitUntil.Completed, ruleData);
            RulestackChangelog log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.That(log.Changes, Does.Contain("LocalRule"));
            Assert.That(log.Changes, Does.Contain("Rulestack"));
            Response response = await LocalRulestackResource.RevertAsync();
            Assert.That(response.Status, Is.EqualTo(204));
            log = await LocalRulestackResource.GetChangeLogAsync();
            Assert.That(log.Changes.Count, Is.EqualTo(0));
        }

        [TestCase]
        [RecordedTest]
        public void GetAppIds()
        {
            AsyncPageable<string> ids = LocalRulestackResource.GetAppIdsAsync();
            Assert.That(ids, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public void GetCountries()
        {
            AsyncPageable<RulestackCountry> countries = LocalRulestackResource.GetCountriesAsync();
            Assert.That(countries, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public void GetFirewalls()
        {
            AsyncPageable<string> firewalls = LocalRulestackResource.GetFirewallsAsync();
            Assert.That(firewalls, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public void GetPredefinedUrlCategories()
        {
            AsyncPageable<PredefinedUrlCategory> response = LocalRulestackResource.GetPredefinedUrlCategoriesAsync();
            Assert.That(response, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportInfo()
        {
            FirewallSupportInfo response = await LocalRulestackResource.GetSupportInfoAsync();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.HelpURL, Is.EqualTo("https://live.paloaltonetworks.com?productSku=PAN-CLOUD-NGFW-AZURE-PAYG"));
        }
    }
}
