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
        protected CertificateObjectLocalRulestackResource DefaultResource1 { get; set; }
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
                LocalRulestack = (await DefaultResGroup.GetLocalRulestackResources().GetAsync("dotnetSdkTest-default-2-lrs")).Value;
                DefaultResource1 = await LocalRulestack.GetCertificateObjectLocalRulestackResourceAsync("dotnetSdkTest-cert");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = IsAsync ? "cert1" : "cert2";
            var response = await LocalRulestack.GetCertificateObjectLocalRulestackResources().CreateOrUpdateAsync(WaitUntil.Completed, name, new CertificateObjectLocalRulestackResourceData(BooleanEnum.True));
            CertificateObjectLocalRulestackResource cert = response.Value;
            Assert.IsTrue((name).Equals(cert.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetCertificateObjectLocalRulestackResources().CreateOrUpdateAsync(WaitUntil.Completed, "cert10", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            CertificateObjectLocalRulestackResourceCollection collection = LocalRulestack.GetCertificateObjectLocalRulestackResources();
            CertificateObjectLocalRulestackResource listsResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(listsResource);
            Assert.AreEqual(listsResource.Data.Name, DefaultResource1.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            CertificateObjectLocalRulestackResourceCollection collection = LocalRulestack.GetCertificateObjectLocalRulestackResources();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Name));
            Assert.IsFalse(await collection.ExistsAsync("invalidName"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            CertificateObjectLocalRulestackResourceCollection collection = LocalRulestack.GetCertificateObjectLocalRulestackResources();
            int count = 0;
            await foreach (CertificateObjectLocalRulestackResource lrs in collection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 3);
        }
    }
}
