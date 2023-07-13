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
        protected LocalRulestackFqdnListResource DefaultResource1 { get; set; }
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
                DefaultResource1 = await LocalRulestack.GetLocalRulestackFqdnListAsync("dotnetSdkTest-fqdnList");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = IsAsync ? "list1" : "list2";
            IEnumerable<string> fqdnList = new string[] { "www.google.com" };
            LocalRulestackFqdnListData data = new LocalRulestackFqdnListData(fqdnList);
            var response = await LocalRulestack.GetLocalRulestackFqdnLists().CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            LocalRulestackFqdnListResource list = response.Value;
            Assert.IsTrue((name).Equals(list.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetLocalRulestackFqdnLists().CreateOrUpdateAsync(WaitUntil.Completed, "3", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackFqdnListCollection collection = LocalRulestack.GetLocalRulestackFqdnLists();
            LocalRulestackFqdnListResource listsResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(listsResource);
            Assert.AreEqual(listsResource.Data.Name, DefaultResource1.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            LocalRulestackFqdnListCollection collection = LocalRulestack.GetLocalRulestackFqdnLists();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Name));
            Assert.IsFalse(await collection.ExistsAsync("invalidName"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            LocalRulestackFqdnListCollection collection = LocalRulestack.GetLocalRulestackFqdnLists();
            int count = 0;
            await foreach (LocalRulestackFqdnListResource lrs in collection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 3);
        }
    }
}
