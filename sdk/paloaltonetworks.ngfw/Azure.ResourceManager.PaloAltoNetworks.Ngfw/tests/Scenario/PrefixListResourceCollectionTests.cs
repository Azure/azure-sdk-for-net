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
    public class PrefixListResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected PrefixListResource DefaultResource1 { get; set; }
        protected LocalRulestackResource LocalRulestack { get; set; }
        public PrefixListResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public PrefixListResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestack = (await DefaultResGroup.GetLocalRulestackResources().GetAsync("dotnetSdkTest-default-2-lrs")).Value;
                DefaultResource1 = await LocalRulestack.GetPrefixListResourceAsync("dotnetSdkTest0-prefixList");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = IsAsync ? "list1" : "list2";
            IEnumerable<string> prefixList = new string[] { "1.0.0.0/24" };
            PrefixListResourceData data = new PrefixListResourceData(prefixList);
            var response = await LocalRulestack.GetPrefixListResources().CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            PrefixListResource list = response.Value;
            Assert.IsTrue((name).Equals(list.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetPrefixListResources().CreateOrUpdateAsync(WaitUntil.Completed, "3", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            PrefixListResourceCollection collection = LocalRulestack.GetPrefixListResources();
            PrefixListResource listsResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(listsResource);
            Assert.AreEqual(listsResource.Data.Name, DefaultResource1.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            PrefixListResourceCollection collection = LocalRulestack.GetPrefixListResources();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Name));
            Assert.IsFalse(await collection.ExistsAsync("invalidName"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            PrefixListResourceCollection collection = LocalRulestack.GetPrefixListResources();
            int count = 0;
            await foreach (PrefixListResource lrs in collection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 3);
        }
    }
}
