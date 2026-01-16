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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidateVerifiedPartner(list.First(item => item.Data.Name == _existPartnerName));
        }

        private void ValidateVerifiedPartner(VerifiedPartnerResource verifiedPartner)
        {
            Assert.That(verifiedPartner, Is.Not.Null);
            Assert.That(verifiedPartner.Data.PartnerRegistrationImmutableId, Is.Not.Null);
            Assert.That(verifiedPartner.Data.Name, Is.EqualTo(_existPartnerName));
            Assert.That(verifiedPartner.Data.PartnerDisplayName, Is.EqualTo(_existPartnerName));
            Assert.That(verifiedPartner.Data.OrganizationName, Is.EqualTo("Auth0, Inc."));
            Assert.That(verifiedPartner.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(verifiedPartner.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/verifiedPartners"));
        }
    }
}
