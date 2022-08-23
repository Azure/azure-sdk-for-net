// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountAgreementTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountAgreementCollection _AgreementCollection => _integrationAccount.GetIntegrationAccountAgreements();

        public IntegrationAccountAgreementTests(bool isAsync) : base(isAsync)
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

        private static IntegrationAccountAgreementContent GetAS2Content()
        {
            AS2MessageConnectionSettings messageConnectionSettings = new AS2MessageConnectionSettings(true, true, true, true);
            AS2AcknowledgementConnectionSettings acknowledgementConnectionSettings = new AS2AcknowledgementConnectionSettings(true, true, true, true);
            AS2MdnSettings mdnSettings = new AS2MdnSettings(true, true, true, true, true, AS2HashingAlgorithm.Sha1)
            {
                ReceiptDeliveryUri = new Uri("http://tempuri.org"),
                DispositionNotificationTo = "http://tempuri.org",
                MdnText = "Sample",
            };
            AS2SecuritySettings securitySettings = new AS2SecuritySettings(false, true, true, true, true, true, true);
            AS2ValidationSettings validationSettings = new AS2ValidationSettings(true, false, false, true, true, 100, true, true, AS2EncryptionAlgorithm.Aes128);
            AS2EnvelopeSettings envelopeSettings = new AS2EnvelopeSettings(ContentType.TextPlain, true, "Test", true, true);
            AS2ErrorSettings errorSettings = new AS2ErrorSettings(true, true);
            AS2ProtocolSettings protocolSettings = new AS2ProtocolSettings(messageConnectionSettings, acknowledgementConnectionSettings, mdnSettings, securitySettings, validationSettings, envelopeSettings, errorSettings);

            AS2OneWayAgreement receiveAgreement = new AS2OneWayAgreement(
                new IntegrationAccountBusinessIdentity("AA", "aa"),
                new IntegrationAccountBusinessIdentity("ZZ", "zz"),
                protocolSettings);
            AS2OneWayAgreement sendAgreement = new AS2OneWayAgreement(
                new IntegrationAccountBusinessIdentity("AA", "aa"),
                new IntegrationAccountBusinessIdentity("ZZ", "zz"),
                protocolSettings);

            IntegrationAccountAgreementContent content = new IntegrationAccountAgreementContent()
            {
                AS2 = new AS2AgreementContent(receiveAgreement, sendAgreement)
            };
            return content;
        }

        private async Task<IntegrationAccountAgreementResource> Create_Agreement_AS2(string agreementName)
        {
            IntegrationAccountAgreementType type = IntegrationAccountAgreementType.AS2;
            string hostPartner = "HostPartner";
            string guestPartner = "GuestPartner";
            var hostIdentity = new IntegrationAccountBusinessIdentity("ZZ", "zz");
            var guestIdentity = new IntegrationAccountBusinessIdentity("AA", "aa");
            IntegrationAccountAgreementContent content = GetAS2Content();
            IntegrationAccountAgreementData data = new IntegrationAccountAgreementData(_integrationAccount.Data.Location, type, hostPartner, guestPartner, hostIdentity, guestIdentity, content)
            {
            };
            var agreement = await _AgreementCollection.CreateOrUpdateAsync(WaitUntil.Completed, agreementName, data);
            return agreement.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await Create_Agreement_AS2(agreementName);
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await Create_Agreement_AS2(agreementName);
            bool flag = await _AgreementCollection.ExistsAsync(agreementName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await Create_Agreement_AS2(agreementName);
            var agreement = await _AgreementCollection.GetAsync(agreementName);
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await Create_Agreement_AS2(agreementName);
            var list = await _AgreementCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await Create_Agreement_AS2(agreementName);
            bool flag = await _AgreementCollection.ExistsAsync(agreementName);
            Assert.IsTrue(flag);

            await agreement.DeleteAsync(WaitUntil.Completed);
            flag = await _AgreementCollection.ExistsAsync(agreementName);
            Assert.IsFalse(flag);
        }
    }
}
