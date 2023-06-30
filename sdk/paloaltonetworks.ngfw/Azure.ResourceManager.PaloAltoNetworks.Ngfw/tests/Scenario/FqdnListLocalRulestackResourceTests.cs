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
    internal class FqdnListLocalRulestackResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected FqdnListLocalRulestackResource FqdnListLocalRulestackResource { get; set; }
        protected LocalRulestackResource LocalRulestackResource { get; set; }
        protected FqdnListLocalRulestackResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public FqdnListLocalRulestackResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestackResource = await ResGroup.GetLocalRulestackResources().GetAsync("dotnetSdkTest-default-2-lrs");
                FqdnListLocalRulestackResource = await LocalRulestackResource.GetFqdnListLocalRulestackResourceAsync("dotnetSdkTest-fqdnList");
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string name = FqdnListLocalRulestackResource.Data.Name;
            ResourceIdentifier localRulestackResourceIdentifier = FqdnListLocalRulestackResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, name);
            FqdnListLocalRulestackResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(FqdnListLocalRulestackResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/fqdnlists/{name}"));
            Assert.Throws<ArgumentException>(() => FqdnListLocalRulestackResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(FqdnListLocalRulestackResource.HasData);
            Assert.NotNull(FqdnListLocalRulestackResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            FqdnListLocalRulestackResourceData updatedData = FqdnListLocalRulestackResource.Data;
            updatedData.Description = "Updated description for fqdn list test";
            FqdnListLocalRulestackResource updatedResource = (await FqdnListLocalRulestackResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.AreEqual(updatedResource.Data.Description, "Updated description for fqdn list test");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await FqdnListLocalRulestackResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            FqdnListLocalRulestackResource resource = await LocalRulestackResource.GetFqdnListLocalRulestackResourceAsync("dotnetSdkTest-fqdnList");
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, FqdnListLocalRulestackResource.Data.Name);
        }
    }
}
