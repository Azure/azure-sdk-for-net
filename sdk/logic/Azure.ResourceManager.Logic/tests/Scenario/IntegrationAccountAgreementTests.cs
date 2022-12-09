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

        private IntegrationAccountAgreementCollection _agreementCollection => _integrationAccount.GetIntegrationAccountAgreements();

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

        private async Task<IntegrationAccountAgreementResource> CreateAgreement(string agreementName, string AgreementType = "AS2")
        {
            string hostPartner = "HostPartner";
            string guestPartner = "GuestPartner";
            var hostIdentity = new IntegrationAccountBusinessIdentity("ZZ", "zz");
            var guestIdentity = new IntegrationAccountBusinessIdentity("AA", "aa");
            IntegrationAccountAgreementType type = IntegrationAccountAgreementType.AS2;
            IntegrationAccountAgreementContent content = null;
            switch (AgreementType)
            {
                case "AS2":
                    type = IntegrationAccountAgreementType.AS2;
                    content = GetAS2Content();
                    break;
                case "Edifact":
                    type = IntegrationAccountAgreementType.Edifact;
                    content = GetEdifactContent();
                    break;
                case "X12":
                    type = IntegrationAccountAgreementType.X12;
                    content = GetX12Content();
                    break;
                default:
                    break;
            }
            IntegrationAccountAgreementData data = new IntegrationAccountAgreementData(_integrationAccount.Data.Location, type, hostPartner, guestPartner, hostIdentity, guestIdentity, content)
            {
            };
            var agreement = await _agreementCollection.CreateOrUpdateAsync(WaitUntil.Completed, agreementName, data);
            return agreement.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate_AS2()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await CreateAgreement(agreementName);
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Data.Name);
            Assert.AreEqual("AS2", agreement.Data.AgreementType.ToString());
        }

        [RecordedTest]
        public async Task CreateOrUpdate_Edifact()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await CreateAgreement(agreementName, "Edifact");
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Data.Name);
            Assert.AreEqual("Edifact", agreement.Data.AgreementType.ToString());
        }

        [RecordedTest]
        public async Task CreateOrUpdate_X12()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await CreateAgreement(agreementName, "X12");
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Data.Name);
            Assert.AreEqual("X12", agreement.Data.AgreementType.ToString());
        }

        [RecordedTest]
        public async Task Exist()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await CreateAgreement(agreementName);
            bool flag = await _agreementCollection.ExistsAsync(agreementName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await CreateAgreement(agreementName);
            var agreement = await _agreementCollection.GetAsync(agreementName);
            Assert.IsNotNull(agreement);
            Assert.AreEqual(agreementName, agreement.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            await CreateAgreement(agreementName);
            var list = await _agreementCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string agreementName = SessionRecording.GenerateAssetName("agreement");
            var agreement = await CreateAgreement(agreementName);
            bool flag = await _agreementCollection.ExistsAsync(agreementName);
            Assert.IsTrue(flag);

            await agreement.DeleteAsync(WaitUntil.Completed);
            flag = await _agreementCollection.ExistsAsync(agreementName);
            Assert.IsFalse(flag);
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

            IntegrationAccountBusinessIdentity senderBusinessIdentity = new IntegrationAccountBusinessIdentity("AA", "AA");
            IntegrationAccountBusinessIdentity receiverBusinessIdentity = new IntegrationAccountBusinessIdentity("ZZ", "ZZ");
            AS2OneWayAgreement receiveAgreement = new AS2OneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);
            AS2OneWayAgreement sendAgreement = new AS2OneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);

            IntegrationAccountAgreementContent content = new IntegrationAccountAgreementContent()
            {
                AS2 = new AS2AgreementContent(receiveAgreement, sendAgreement)
            };
            return content;
        }

        private static IntegrationAccountAgreementContent GetEdifactContent()
        {
            EdifactValidationSettings validationSettings = new EdifactValidationSettings(true, true, 30, true, true, true, true, true, true, TrailingSeparatorPolicy.Optional);
            EdifactFramingSettings framingSettings = new EdifactFramingSettings(4, 53, 58, 39, 63, 42, EdifactCharacterSet.Unoc, EdifactDecimalIndicator.Comma, SegmentTerminatorSuffix.None);
            EdifactEnvelopeSettings envelopeSettings = new EdifactEnvelopeSettings(true, true, true, 1, 99999999, true, 1, 99999999, true, true, 1, 99999999, true, true);
            EdifactAcknowledgementSettings acknowledgementSettings = new EdifactAcknowledgementSettings(true, true, false, true, false, true, 1, 99999999, true);
            EdifactMessageFilter messageFilter = new EdifactMessageFilter(MessageFilterType.Exclude);
            EdifactProcessingSettings processingSettings = new EdifactProcessingSettings(true, true, true, true, true);
            IEnumerable<EdifactSchemaReference> schemaReferences = new List<EdifactSchemaReference>();
            EdifactProtocolSettings protocolSettings = new EdifactProtocolSettings(validationSettings, framingSettings, envelopeSettings, acknowledgementSettings, messageFilter, processingSettings, schemaReferences);

            IntegrationAccountBusinessIdentity senderBusinessIdentity = new IntegrationAccountBusinessIdentity("AA", "AA");
            IntegrationAccountBusinessIdentity receiverBusinessIdentity = new IntegrationAccountBusinessIdentity("ZZ", "ZZ");
            EdifactOneWayAgreement receiveAgreement = new EdifactOneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);
            EdifactOneWayAgreement sendAgreement = new EdifactOneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);

            IntegrationAccountAgreementContent content = new IntegrationAccountAgreementContent()
            {
                Edifact = new EdifactAgreementContent(receiveAgreement, sendAgreement)
            };
            return content;
        }

        private static IntegrationAccountAgreementContent GetX12Content()
        {
            X12ValidationSettings validationSettings = new X12ValidationSettings(true, false, 30, false, false, true, false, false, false, TrailingSeparatorPolicy.NotAllowed);
            X12FramingSettings framingSettings = new X12FramingSettings(42, 72, false, 44, 39, X12CharacterSet.Utf8, SegmentTerminatorSuffix.None);
            X12EnvelopeSettings envelopeSettings = new X12EnvelopeSettings(85, false, "BTS-SENDER", "RECEIVE-APP", "00401", 1, 99999999, true, true, 1, 99999999, true, "T", "00401", 1, 99999999, true, true, X12DateFormat.Ccyymmdd, X12TimeFormat.Hhmm, UsageIndicator.Test);
            X12AcknowledgementSettings acknowledgementSettings = new X12AcknowledgementSettings(false, true, false, true, false, false, false, true, 1, 99999999, true);
            X12MessageFilter messageFilter = new X12MessageFilter(MessageFilterType.Exclude);
            X12SecuritySettings securitySettings = new X12SecuritySettings("00", "00");
            X12ProcessingSettings processingSettings = new X12ProcessingSettings(true, true, true, true, true, true);
            IEnumerable<X12SchemaReference> schemaReferences = new List<X12SchemaReference>();
            X12ProtocolSettings protocolSettings = new X12ProtocolSettings(validationSettings, framingSettings, envelopeSettings, acknowledgementSettings, messageFilter, securitySettings, processingSettings, schemaReferences);

            IntegrationAccountBusinessIdentity senderBusinessIdentity = new IntegrationAccountBusinessIdentity("AA", "AA");
            IntegrationAccountBusinessIdentity receiverBusinessIdentity = new IntegrationAccountBusinessIdentity("ZZ", "ZZ");
            X12OneWayAgreement receiveAgreement = new X12OneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);
            X12OneWayAgreement sendAgreement = new X12OneWayAgreement(senderBusinessIdentity, receiverBusinessIdentity, protocolSettings);
            IntegrationAccountAgreementContent content = new IntegrationAccountAgreementContent()
            {
                X12 = new X12AgreementContent(receiveAgreement, sendAgreement)
            };
            return content;
        }
    }
}
