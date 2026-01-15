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
    public class CertificateObjectLocalRulestackResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected LocalRulestackCertificateObjectResource DefaultResource1 { get; set; }
        protected LocalRulestackResource LocalRulestack { get; set; }
        public CertificateObjectLocalRulestackResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public CertificateObjectLocalRulestackResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestack = (await DefaultResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs")).Value;
                DefaultResource1 = await LocalRulestack.GetLocalRulestackCertificateObjectAsync("dotnetSdkTest-cert");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = IsAsync ? "cert1" : "cert2";
            var response = await LocalRulestack.GetLocalRulestackCertificateObjects().CreateOrUpdateAsync(WaitUntil.Completed, name, new LocalRulestackCertificateObjectData(FirewallBooleanType.True));
            LocalRulestackCertificateObjectResource cert = response.Value;
            Assert.That((name).Equals(cert.Data.Name), Is.True);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetLocalRulestackCertificateObjects().CreateOrUpdateAsync(WaitUntil.Completed, "cert10", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackCertificateObjectCollection collection = LocalRulestack.GetLocalRulestackCertificateObjects();
            LocalRulestackCertificateObjectResource listsResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(listsResource);
            Assert.That(DefaultResource1.Data.Name, Is.EqualTo(listsResource.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            LocalRulestackCertificateObjectCollection collection = LocalRulestack.GetLocalRulestackCertificateObjects();
            Assert.That((bool)await collection.ExistsAsync(DefaultResource1.Data.Name), Is.True);
            Assert.That((bool)await collection.ExistsAsync("invalidName"), Is.False);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            LocalRulestackCertificateObjectCollection collection = LocalRulestack.GetLocalRulestackCertificateObjects();
            int count = 0;
            await foreach (LocalRulestackCertificateObjectResource lrs in collection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(3));
        }
    }
}
