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
        protected LocalRulestackFqdnResource LocalRulestackFqdnListResource { get; set; }
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
                LocalRulestackResource = await ResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs");
                LocalRulestackFqdnListResource = await LocalRulestackResource.GetLocalRulestackFqdnAsync("dotnetSdkTest-fqdnList");
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Due to issue: https://github.com/Azure/azure-sdk-for-net/issues/53815")]
        public void CreateResourceIdentifier()
        {
            string name = LocalRulestackFqdnListResource.Data.Name;
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackFqdnResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, name);
            LocalRulestackFqdnResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(LocalRulestackFqdnResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/fqdnlists/{name}"));
            Assert.Throws<ArgumentException>(() => LocalRulestackFqdnResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(LocalRulestackFqdnListResource.HasData);
            Assert.NotNull(LocalRulestackFqdnListResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            LocalRulestackFqdnData updatedData = LocalRulestackFqdnListResource.Data;
            updatedData.Description = "Updated description for fqdn list test";
            LocalRulestackFqdnResource updatedResource = (await LocalRulestackFqdnListResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.AreEqual(updatedResource.Data.Description, "Updated description for fqdn list test");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulestackFqdnListResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackFqdnResource resource = await LocalRulestackResource.GetLocalRulestackFqdnAsync("dotnetSdkTest-fqdnList");
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, LocalRulestackFqdnListResource.Data.Name);
        }
    }
}
