// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountPartnerTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountPartnerCollection _partnerCollection => _integrationAccount.GetIntegrationAccountPartners();

        public IntegrationAccountPartnerTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountPartnerResource> CreatePartner(string partnerName)
        {
            var content = new IntegrationAccountPartnerContent();
            content.B2BBusinessIdentities.Add(new IntegrationAccountBusinessIdentity("AA", "ZZ"));
            IntegrationAccountPartnerData data = new IntegrationAccountPartnerData(_integrationAccount.Data.Location, IntegrationAccountPartnerType.B2B, content);
            var partner = await _partnerCollection.CreateOrUpdateAsync(WaitUntil.Completed, partnerName, data);
            return partner.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string partnerName = Recording.GenerateAssetName("partner");
            var partner = await CreatePartner(partnerName);
            Assert.That(partner, Is.Not.Null);
            Assert.That(partner.Data.Name, Is.EqualTo(partnerName));
        }

        [RecordedTest]
        public async Task Exist()
        {
            string partnerName = Recording.GenerateAssetName("partner");
            await CreatePartner(partnerName);
            bool flag = await _partnerCollection.ExistsAsync(partnerName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            string partnerName = Recording.GenerateAssetName("partner");
            await CreatePartner(partnerName);
            var partner = await _partnerCollection.GetAsync(partnerName);
            Assert.That(partner, Is.Not.Null);
            Assert.That(partner.Value.Data.Name, Is.EqualTo(partnerName));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string partnerName = Recording.GenerateAssetName("partner");
            await CreatePartner(partnerName);
            var list = await _partnerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string partnerName = Recording.GenerateAssetName("partner");
            var partner = await CreatePartner(partnerName);
            bool flag = await _partnerCollection.ExistsAsync(partnerName);
            Assert.That(flag, Is.True);

            await partner.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerCollection.ExistsAsync(partnerName);
            Assert.That(flag, Is.False);
        }
    }
}
