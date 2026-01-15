// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.Core;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    public class FqdnListLocalRulestackResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected LocalRulestackFqdnResource DefaultResource1 { get; set; }
        protected LocalRulestackResource LocalRulestack { get; set; }
        public FqdnListLocalRulestackResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public FqdnListLocalRulestackResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestack = (await DefaultResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs")).Value;
                DefaultResource1 = await LocalRulestack.GetLocalRulestackFqdnAsync("dotnetSdkTest-fqdnList");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = IsAsync ? "list1" : "list2";
            IEnumerable<string> fqdnList = new string[] { "www.google.com" };
            LocalRulestackFqdnData data = new LocalRulestackFqdnData(fqdnList);
            var response = await LocalRulestack.GetLocalRulestackFqdns().CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            LocalRulestackFqdnResource list = response.Value;
            Assert.That((name).Equals(list.Data.Name), Is.True);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetLocalRulestackFqdns().CreateOrUpdateAsync(WaitUntil.Completed, "3", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackFqdnCollection collection = LocalRulestack.GetLocalRulestackFqdns();
            LocalRulestackFqdnResource listsResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(listsResource);
            Assert.That(DefaultResource1.Data.Name, Is.EqualTo(listsResource.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            LocalRulestackFqdnCollection collection = LocalRulestack.GetLocalRulestackFqdns();
            Assert.That((bool)await collection.ExistsAsync(DefaultResource1.Data.Name), Is.True);
            Assert.That((bool)await collection.ExistsAsync("invalidName"), Is.False);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            LocalRulestackFqdnCollection collection = LocalRulestack.GetLocalRulestackFqdns();
            int count = 0;
            await foreach (LocalRulestackFqdnResource lrs in collection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(3));
        }
    }
}
