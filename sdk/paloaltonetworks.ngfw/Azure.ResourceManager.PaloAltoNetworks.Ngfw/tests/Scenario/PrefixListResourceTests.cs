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
    internal class PrefixListResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected LocalRulestackPrefixResource PrefixListResource { get; set; }
        protected LocalRulestackResource LocalRulestackResource { get; set; }
        protected PrefixListResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public PrefixListResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestackResource = await ResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs");
                PrefixListResource = await LocalRulestackResource.GetLocalRulestackPrefixAsync("dotnetSdkTest0-prefixList");
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Due to issue: https://github.com/Azure/azure-sdk-for-net/issues/53815")]
        public void CreateResourceIdentifier()
        {
            string name = PrefixListResource.Data.Name;
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackPrefixResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, name);
            LocalRulestackPrefixResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(LocalRulestackPrefixResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/prefixlists/{name}"));
            Assert.Throws<ArgumentException>(() => LocalRulestackPrefixResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(PrefixListResource.HasData);
            Assert.NotNull(PrefixListResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            LocalRulestackPrefixData updatedData = PrefixListResource.Data;
            updatedData.Description = "Updated description for prefix list test";
            LocalRulestackPrefixResource updatedResource = (await PrefixListResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.AreEqual(updatedResource.Data.Description, "Updated description for prefix list test");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await PrefixListResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackPrefixResource resource = await LocalRulestackResource.GetLocalRulestackPrefixAsync("dotnetSdkTest0-prefixList");
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, PrefixListResource.Data.Name);
        }
    }
}
