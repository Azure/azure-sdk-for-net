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
    internal class CertificateObjectLocalRulestackResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected CertificateObjectLocalRulestackResource CertificateObjectLocalRulestackResource { get; set; }
        protected LocalRulestackResource LocalRulestackResource { get; set; }
        protected CertificateObjectLocalRulestackResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public CertificateObjectLocalRulestackResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestackResource = await ResGroup.GetLocalRulestackResources().GetAsync("dotnetSdkTest-default-2-lrs");
                CertificateObjectLocalRulestackResource = await LocalRulestackResource.GetCertificateObjectLocalRulestackResourceAsync("dotnetSdkTest-cert");
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string name = CertificateObjectLocalRulestackResource.Data.Name;
            ResourceIdentifier localRulestackResourceIdentifier = CertificateObjectLocalRulestackResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, name);
            CertificateObjectLocalRulestackResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(CertificateObjectLocalRulestackResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/certificates/{name}"));
            Assert.Throws<ArgumentException>(() => CertificateObjectLocalRulestackResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.IsTrue(CertificateObjectLocalRulestackResource.HasData);
            Assert.NotNull(CertificateObjectLocalRulestackResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            CertificateObjectLocalRulestackResourceData updatedData = CertificateObjectLocalRulestackResource.Data;
            updatedData.Description = "Updated description for certificates test";
            CertificateObjectLocalRulestackResource updatedResource = (await CertificateObjectLocalRulestackResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.AreEqual(updatedResource.Data.Description, "Updated description for certificates test");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await CertificateObjectLocalRulestackResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            CertificateObjectLocalRulestackResource resource = await LocalRulestackResource.GetCertificateObjectLocalRulestackResourceAsync("dotnetSdkTest-cert");
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, CertificateObjectLocalRulestackResource.Data.Name);
        }
    }
}
