// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    internal class VerifiedPartnerTests : EventGridManagementTestBase
    {
        private VerifiedPartnerCollection _verifiedPartnerCollection;
        private const string _existPartnerName = "Auth0";
        public VerifiedPartnerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            _verifiedPartnerCollection = tenant.GetVerifiedPartners();
        }
        [Test]
        public async Task Exists()
        {
            bool flag = await _verifiedPartnerCollection.ExistsAsync(_existPartnerName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var verifiedPartner = await _verifiedPartnerCollection.GetAsync(_existPartnerName);
            ValidateVerifiedPartner(verifiedPartner);
        }
        [Test]
        public async Task GetAll()
        {
            var list = await _verifiedPartnerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateVerifiedPartner(list.First(item => item.Data.Name == _existPartnerName));
        }

        private void ValidateVerifiedPartner(VerifiedPartnerResource verifiedPartner)
        {
            Assert.IsNotNull(verifiedPartner);
            Assert.IsNotNull(verifiedPartner.Data.PartnerRegistrationImmutableId);
            Assert.AreEqual(_existPartnerName, verifiedPartner.Data.Name);
            Assert.AreEqual(_existPartnerName, verifiedPartner.Data.PartnerDisplayName);
            Assert.AreEqual("Auth0, Inc.", verifiedPartner.Data.OrganizationName);
            Assert.AreEqual("Succeeded", verifiedPartner.Data.ProvisioningState.ToString());
            Assert.AreEqual("Microsoft.EventGrid/verifiedPartners", verifiedPartner.Data.ResourceType.ToString());
        }
    }
}
