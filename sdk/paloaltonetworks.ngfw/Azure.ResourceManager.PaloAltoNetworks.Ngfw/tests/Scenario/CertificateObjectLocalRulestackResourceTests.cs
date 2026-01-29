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
        protected LocalRulestackCertificateObjectResource CertificateObjectLocalRulestackResource { get; set; }
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
                LocalRulestackResource = await ResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs");
                CertificateObjectLocalRulestackResource = await LocalRulestackResource.GetLocalRulestackCertificateObjectAsync("dotnetSdkTest-cert");
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Due to issue: https://github.com/Azure/azure-sdk-for-net/issues/53815")]
        public void CreateResourceIdentifier()
        {
            string name = CertificateObjectLocalRulestackResource.Data.Name;
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackCertificateObjectResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, name);
            LocalRulestackCertificateObjectResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.IsTrue(localRulestackResourceIdentifier.ResourceType.Equals(LocalRulestackCertificateObjectResource.ResourceType));
            Assert.IsTrue(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/certificates/{name}"));
            Assert.Throws<ArgumentException>(() => LocalRulestackCertificateObjectResource.ValidateResourceId(ResGroup.Data.Id));
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
            LocalRulestackCertificateObjectData updatedData = CertificateObjectLocalRulestackResource.Data;
            updatedData.Description = "Updated description for certificates test";
            LocalRulestackCertificateObjectResource updatedResource = (await CertificateObjectLocalRulestackResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.AreEqual(updatedResource.Data.Description, "Updated description for certificates test");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await CertificateObjectLocalRulestackResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackCertificateObjectResource resource = await LocalRulestackResource.GetLocalRulestackCertificateObjectAsync("dotnetSdkTest-cert");
            Assert.NotNull(resource);
            Assert.AreEqual(resource.Data.Name, CertificateObjectLocalRulestackResource.Data.Name);
        }
    }
}
