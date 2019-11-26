// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    [Collection("IntegrationAccountAgreementsScenarioTests")]
    public class IntegrationAccountAgreementsScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountAgreements_CreateAs2_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                this.ValidateAgreement(agreement, createdAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_CreateEdifact_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.Edifact);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                this.ValidateAgreement(agreement, createdAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_CreateX12_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.X12);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                this.ValidateAgreement(agreement, createdAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_CreateWithEnvelopeOverride_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.X12);
                agreement.Content.X12.ReceiveAgreement.ProtocolSettings.EnvelopeOverrides = new List<X12EnvelopeOverride>
                {
                    new X12EnvelopeOverride
                    {
                        HeaderVersion = "1",
                        MessageId = "100",
                        ProtocolVersion = "1",
                        ReceiverApplicationId = "93494",
                        ResponsibleAgencyCode = "X",
                        SenderApplicationId = "89459",
                        TargetNamespace = "http://tempuri.org",
                        FunctionalIdentifierCode = "x",
                        DateFormat = X12DateFormat.CCYYMMDD,
                        TimeFormat = X12TimeFormat.HHMM
                    }
                };
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                var retrievedAgreement = client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName);

                this.ValidateAgreement(agreement, retrievedAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                var retrievedAgreement = client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName);

                this.ValidateAgreement(agreement, retrievedAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName1 = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement1 = this.CreateIntegrationAccountAgreement(agreementName1, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName1,
                    agreement1);

                var agreementName2 = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement2 = this.CreateIntegrationAccountAgreement(agreementName2, AgreementType.Edifact);
                var createdAgreement2 = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName2,
                    agreement2);

                var agreementName3 = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement3 = this.CreateIntegrationAccountAgreement(agreementName3, AgreementType.X12);
                var createdAgreement3 = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName3,
                    agreement3);

                var agreements = client.IntegrationAccountAgreements.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, agreements.Count());
                this.ValidateAgreement(agreement1, agreements.Single(x => x.AgreementType == agreement1.AgreementType));
                this.ValidateAgreement(agreement2, agreements.Single(x => x.AgreementType == agreement2.AgreementType));
                this.ValidateAgreement(agreement3, agreements.Single(x => x.AgreementType == agreement3.AgreementType));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                var newAgreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);

                var updatedAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    newAgreement);

                this.ValidateAgreement(newAgreement, updatedAgreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, integrationAccountName, agreementName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, integrationAccountName, agreementName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, integrationAccountName, agreementName));
            }
        }

        [Fact]
        public void IntegrationAccountAgreements_ListContentCallbackUrl_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var agreementName = TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var agreement = this.CreateIntegrationAccountAgreement(agreementName, AgreementType.AS2);
                var createdAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    agreement);

                var contentCallbackUrl = client.IntegrationAccountAgreements.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    agreementName,
                    new GetCallbackUrlParameters
                    {
                        KeyType = "Primary"
                    });

                Assert.Equal("GET", contentCallbackUrl.Method);
                Assert.Contains(agreementName, contentCallbackUrl.Value);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        #region Private

        private void ValidateAgreement(IntegrationAccountAgreement expected, IntegrationAccountAgreement actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.AgreementType, actual.AgreementType);
            Assert.Equal(expected.HostPartner, actual.HostPartner);
            Assert.Equal(expected.GuestPartner, actual.GuestPartner);
            Assert.Equal(expected.HostIdentity.Qualifier, actual.HostIdentity.Qualifier);
            Assert.Equal(expected.HostIdentity.Value, actual.HostIdentity.Value);
            Assert.Equal(expected.GuestIdentity.Qualifier, actual.GuestIdentity.Qualifier);
            Assert.Equal(expected.GuestIdentity.Value, actual.GuestIdentity.Value);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);

            switch (expected.AgreementType)
            {
                case AgreementType.AS2:
                    Assert.Equal(expected.Content.AS2, expected.Content.AS2);
                    break;
                case AgreementType.Edifact:
                    Assert.Equal(expected.Content.Edifact, expected.Content.Edifact);
                    break;
                case AgreementType.X12:
                    Assert.Equal(expected.Content.X12, expected.Content.X12);
                    break;
            }
        }

        private IntegrationAccountAgreement CreateIntegrationAccountAgreement(string agreementName, AgreementType agreementType)
        {
            var hostPartner = "HostPartner";
            var guestPartner = "GuestPartner";
            var hostIdentity = new BusinessIdentity { Qualifier = "ZZ", Value = "ZZ" };
            var guestIdentity = new BusinessIdentity { Qualifier = "AA", Value = "AA" };

            AgreementContent agreementContent = null;
            switch (agreementType)
            {
                case AgreementType.AS2:
                    agreementContent = this.AS2AgreementContent;
                    break;
                case AgreementType.Edifact:
                    agreementContent = this.EDIFACTAgreementContent;
                    break;
                case AgreementType.X12:
                    agreementContent = this.X12AgreementContent;
                    break;
            }

            var agreement = new IntegrationAccountAgreement(agreementType,
                hostPartner,
                guestPartner,
                hostIdentity,
                guestIdentity,
                agreementContent,
                name: agreementName);

            return agreement;
        }

        /// <summary>
        /// Gets the X12 agreement content.
        /// </summary>
        private AgreementContent X12AgreementContent
        {
            get
            {
                var content = new AgreementContent
                {
                    X12 = new X12AgreementContent
                    {
                        ReceiveAgreement = new X12OneWayAgreement
                        {
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            },
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            },
                            ProtocolSettings = new X12ProtocolSettings
                            {
                                AcknowledgementSettings = new X12AcknowledgementSettings
                                {
                                    NeedTechnicalAcknowledgement = false,
                                    BatchTechnicalAcknowledgements = true,
                                    NeedFunctionalAcknowledgement = false,
                                    BatchFunctionalAcknowledgements = true,
                                    NeedLoopForValidMessages = false,
                                    SendSynchronousAcknowledgement = true,
                                    AcknowledgementControlNumberLowerBound = 1,
                                    AcknowledgementControlNumberUpperBound = 999999999,
                                    RolloverAcknowledgementControlNumber = true,
                                    NeedImplementationAcknowledgement = false,
                                    BatchImplementationAcknowledgements = false
                                },
                                EnvelopeSettings = new X12EnvelopeSettings
                                {
                                    ControlStandardsId = 'U',
                                    UseControlStandardsIdAsRepetitionCharacter = false,
                                    SenderApplicationId = "BTS-SENDER",
                                    ReceiverApplicationId = "RECEIVE-APP",
                                    ControlVersionNumber = "00401",
                                    InterchangeControlNumberLowerBound = 1,
                                    InterchangeControlNumberUpperBound = 999999999,
                                    RolloverInterchangeControlNumber = true,
                                    EnableDefaultGroupHeaders = true,
                                    FunctionalGroupId = null,
                                    GroupControlNumberLowerBound = 1,
                                    GroupControlNumberUpperBound = 999999999,
                                    RolloverGroupControlNumber = true,
                                    GroupHeaderAgencyCode = "T",
                                    GroupHeaderVersion = "00401",
                                    TransactionSetControlNumberLowerBound = 1,
                                    TransactionSetControlNumberUpperBound = 999999999,
                                    RolloverTransactionSetControlNumber = true,
                                    TransactionSetControlNumberPrefix = null,
                                    TransactionSetControlNumberSuffix = null,
                                    OverwriteExistingTransactionSetControlNumber = true,
                                    GroupHeaderDateFormat = X12DateFormat.CCYYMMDD,
                                    GroupHeaderTimeFormat = X12TimeFormat.HHMM,
                                    UsageIndicator = UsageIndicator.Test
                                },
                                SecuritySettings = new X12SecuritySettings
                                {
                                    AuthorizationQualifier = "00",
                                    AuthorizationValue = null,
                                    SecurityQualifier = "00",
                                    PasswordValue = null
                                },
                                FramingSettings = new X12FramingSettings
                                {
                                    DataElementSeparator = '*',
                                    ComponentSeparator = ':',
                                    ReplaceSeparatorsInPayload = false,
                                    ReplaceCharacter = '$',
                                    SegmentTerminator = '~',
                                    CharacterSet = X12CharacterSet.UTF8,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.None
                                },
                                ValidationSettings = new X12ValidationSettings
                                {
                                    ValidateCharacterSet = true,
                                    CheckDuplicateInterchangeControlNumber = false,
                                    InterchangeControlNumberValidityDays = 30,
                                    CheckDuplicateGroupControlNumber = false,
                                    CheckDuplicateTransactionSetControlNumber = false,
                                    ValidateEdiTypes = true,
                                    ValidateXsdTypes = false,
                                    AllowLeadingAndTrailingSpacesAndZeroes = false,
                                    TrimLeadingAndTrailingSpacesAndZeroes = false,
                                    TrailingSeparatorPolicy = TrailingSeparatorPolicy.NotAllowed
                                },
                                MessageFilter = new X12MessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                ProcessingSettings = new X12ProcessingSettings
                                {
                                    ConvertImpliedDecimal = true,
                                    CreateEmptyXmlTagsForTrailingSeparators = true,
                                    MaskSecurityInfo = true,
                                    PreserveInterchange = true,
                                    SuspendInterchangeOnError = true,
                                    UseDotAsDecimalSeparator = true
                                },
                                SchemaReferences = new X12SchemaReference[0]
                            }
                        },
                        SendAgreement = new X12OneWayAgreement
                        {
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            },
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            },
                            ProtocolSettings = new X12ProtocolSettings
                            {
                                AcknowledgementSettings = new X12AcknowledgementSettings
                                {
                                    NeedTechnicalAcknowledgement = false,
                                    BatchTechnicalAcknowledgements = true,
                                    NeedFunctionalAcknowledgement = false,
                                    BatchFunctionalAcknowledgements = true,
                                    NeedLoopForValidMessages = false,
                                    SendSynchronousAcknowledgement = true,
                                    AcknowledgementControlNumberLowerBound = 1,
                                    AcknowledgementControlNumberUpperBound = 999999999,
                                    RolloverAcknowledgementControlNumber = true,
                                    NeedImplementationAcknowledgement = false,
                                    BatchImplementationAcknowledgements = false
                                },
                                EnvelopeSettings = new X12EnvelopeSettings
                                {
                                    ControlStandardsId = 100,
                                    ControlVersionNumber = "0.0",
                                    EnableDefaultGroupHeaders = true,
                                    FunctionalGroupId = "1",
                                    GroupControlNumberLowerBound = 1,
                                    GroupControlNumberUpperBound = 999999999,
                                    GroupHeaderAgencyCode = "T",
                                    GroupHeaderDateFormat = X12DateFormat.CCYYMMDD,
                                    GroupHeaderTimeFormat = X12TimeFormat.HHMM,
                                    GroupHeaderVersion = "0.0",
                                    InterchangeControlNumberLowerBound = 1,
                                    InterchangeControlNumberUpperBound = 999999999,
                                    OverwriteExistingTransactionSetControlNumber = true,
                                    ReceiverApplicationId = "100",
                                    RolloverGroupControlNumber = true,
                                    RolloverInterchangeControlNumber = true,
                                    RolloverTransactionSetControlNumber = true,
                                    SenderApplicationId = "100",
                                    TransactionSetControlNumberLowerBound = 1,
                                    TransactionSetControlNumberPrefix = "",
                                    TransactionSetControlNumberSuffix = "",
                                    TransactionSetControlNumberUpperBound = 999999999,
                                    UsageIndicator = UsageIndicator.Information,
                                    UseControlStandardsIdAsRepetitionCharacter = true
                                },
                                SecuritySettings = new X12SecuritySettings
                                {
                                    AuthorizationQualifier = "00",
                                    AuthorizationValue = null,
                                    SecurityQualifier = "00",
                                    PasswordValue = null
                                },
                                FramingSettings = new X12FramingSettings
                                {
                                    DataElementSeparator = '*',
                                    ComponentSeparator = ':',
                                    ReplaceSeparatorsInPayload = false,
                                    ReplaceCharacter = '$',
                                    SegmentTerminator = '~',
                                    CharacterSet = X12CharacterSet.UTF8,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.None
                                },
                                ValidationSettings = new X12ValidationSettings
                                {
                                    ValidateCharacterSet = true,
                                    CheckDuplicateInterchangeControlNumber = false,
                                    InterchangeControlNumberValidityDays = 30,
                                    CheckDuplicateGroupControlNumber = false,
                                    CheckDuplicateTransactionSetControlNumber = false,
                                    ValidateEdiTypes = true,
                                    ValidateXsdTypes = false,
                                    AllowLeadingAndTrailingSpacesAndZeroes = false,
                                    TrimLeadingAndTrailingSpacesAndZeroes = false,
                                    TrailingSeparatorPolicy = TrailingSeparatorPolicy.NotAllowed
                                },
                                MessageFilter = new X12MessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                ProcessingSettings = new X12ProcessingSettings
                                {
                                    ConvertImpliedDecimal = true,
                                    CreateEmptyXmlTagsForTrailingSeparators = true,
                                    MaskSecurityInfo = true,
                                    PreserveInterchange = true,
                                    SuspendInterchangeOnError = true,
                                    UseDotAsDecimalSeparator = true
                                },
                                SchemaReferences = new X12SchemaReference[0]
                            }
                        }
                    }
                };

                return content;
            }
        }

        /// <summary>
        /// Gets the EDIFACT agreement content.
        /// </summary>
        private AgreementContent EDIFACTAgreementContent
        {
            get
            {
                var content = new AgreementContent
                {
                    Edifact = new EdifactAgreementContent
                    {
                        ReceiveAgreement = new EdifactOneWayAgreement
                        {
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            },
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            },
                            ProtocolSettings = new EdifactProtocolSettings
                            {
                                AcknowledgementSettings = new EdifactAcknowledgementSettings
                                {
                                    AcknowledgementControlNumberLowerBound = 1,
                                    AcknowledgementControlNumberPrefix = "",
                                    AcknowledgementControlNumberSuffix = "",
                                    AcknowledgementControlNumberUpperBound = 99999999,
                                    BatchFunctionalAcknowledgements = true,
                                    BatchTechnicalAcknowledgements = true,
                                    NeedFunctionalAcknowledgement = false,
                                    NeedLoopForValidMessages = false,
                                    NeedTechnicalAcknowledgement = true,
                                    RolloverAcknowledgementControlNumber = true,
                                    SendSynchronousAcknowledgement = true
                                },
                                EnvelopeSettings = new EdifactEnvelopeSettings
                                {
                                    ApplicationReferenceId = "0",
                                    EnableDefaultGroupHeaders = true,
                                    FunctionalGroupId = "0",
                                    GroupControlNumberLowerBound = 1,
                                    GroupControlNumberUpperBound = 99999999,
                                    InterchangeControlNumberLowerBound = 1,
                                    InterchangeControlNumberUpperBound = 99999999,
                                    OverwriteExistingTransactionSetControlNumber = true,
                                    RolloverGroupControlNumber = true,
                                    RolloverInterchangeControlNumber = true,
                                    RolloverTransactionSetControlNumber = true,
                                    TransactionSetControlNumberLowerBound = 1,
                                    TransactionSetControlNumberPrefix = "",
                                    TransactionSetControlNumberSuffix = "",
                                    TransactionSetControlNumberUpperBound = 99999999,
                                    ApplyDelimiterStringAdvice = true,
                                    CommunicationAgreementId = "0",
                                    CreateGroupingSegments = true,
                                    GroupApplicationPassword = "0",
                                    GroupApplicationReceiverId = "0",
                                    GroupApplicationReceiverQualifier = "ZZZ",
                                    GroupApplicationSenderId = "AAA",
                                    GroupApplicationSenderQualifier = "ZZZ",
                                    GroupAssociationAssignedCode = "0",
                                    GroupControlNumberPrefix = "CU",
                                    GroupControlNumberSuffix = "NUM",
                                    GroupControllingAgencyCode = "0",
                                    GroupMessageRelease = "0.0",
                                    GroupMessageVersion = "0.0",
                                    InterchangeControlNumberPrefix = "CU",
                                    InterchangeControlNumberSuffix = "NUM",
                                    IsTestInterchange = true,
                                    ProcessingPriorityCode = "0",
                                    ReceiverInternalIdentification = "0",
                                    ReceiverInternalSubIdentification = "0",
                                    RecipientReferencePasswordQualifier = "ZZ",
                                    RecipientReferencePasswordValue = "AA",
                                    SenderInternalIdentification = "AA",
                                    SenderInternalSubIdentification = "AA"
                                },
                                MessageFilter = new EdifactMessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                FramingSettings = new EdifactFramingSettings
                                {
                                    DataElementSeparator = 53,
                                    ComponentSeparator = 58,
                                    SegmentTerminator = 39,
                                    CharacterSet = EdifactCharacterSet.UNOC,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.None,
                                    ProtocolVersion = 4,
                                    DecimalPointIndicator = EdifactDecimalIndicator.Comma,
                                    ReleaseIndicator = 63,
                                    CharacterEncoding = "UTF",
                                    RepetitionSeparator = 42
                                },
                                ProcessingSettings = new EdifactProcessingSettings
                                {
                                    CreateEmptyXmlTagsForTrailingSeparators = true,
                                    MaskSecurityInfo = true,
                                    PreserveInterchange = true,
                                    SuspendInterchangeOnError = true,
                                    UseDotAsDecimalSeparator = true
                                },
                                ValidationSettings = new EdifactValidationSettings
                                {
                                    AllowLeadingAndTrailingSpacesAndZeroes = true,
                                    ValidateCharacterSet = true,
                                    CheckDuplicateGroupControlNumber = true,
                                    CheckDuplicateInterchangeControlNumber = true,
                                    CheckDuplicateTransactionSetControlNumber = true,
                                    InterchangeControlNumberValidityDays = 30,
                                    TrailingSeparatorPolicy = TrailingSeparatorPolicy.Optional,
                                    TrimLeadingAndTrailingSpacesAndZeroes = true,
                                    ValidateEdiTypes = true,
                                    ValidateXsdTypes = true
                                },
                                SchemaReferences = new EdifactSchemaReference[0]

                            }

                        },
                        SendAgreement = new EdifactOneWayAgreement
                        {
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            },
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            },
                            ProtocolSettings = new EdifactProtocolSettings
                            {
                                AcknowledgementSettings = new EdifactAcknowledgementSettings
                                {
                                    AcknowledgementControlNumberLowerBound = 1,
                                    AcknowledgementControlNumberPrefix = "CN",
                                    AcknowledgementControlNumberSuffix = "NUM",
                                    AcknowledgementControlNumberUpperBound = 999999999,
                                    BatchFunctionalAcknowledgements = true,
                                    BatchTechnicalAcknowledgements = true,
                                    NeedFunctionalAcknowledgement = true,
                                    NeedLoopForValidMessages = true,
                                    NeedTechnicalAcknowledgement = true,
                                    RolloverAcknowledgementControlNumber = true,
                                    SendSynchronousAcknowledgement = true
                                },
                                EnvelopeSettings = new EdifactEnvelopeSettings
                                {
                                    ApplicationReferenceId = "0",
                                    EnableDefaultGroupHeaders = true,
                                    FunctionalGroupId = "0",
                                    GroupControlNumberLowerBound = 1,
                                    GroupControlNumberUpperBound = 999999999,
                                    InterchangeControlNumberLowerBound = 1,
                                    InterchangeControlNumberUpperBound = 999999999,
                                    OverwriteExistingTransactionSetControlNumber = true,
                                    RolloverGroupControlNumber = true,
                                    RolloverInterchangeControlNumber = true,
                                    RolloverTransactionSetControlNumber = true,
                                    TransactionSetControlNumberLowerBound = 1,
                                    TransactionSetControlNumberPrefix = "",
                                    TransactionSetControlNumberSuffix = "",
                                    TransactionSetControlNumberUpperBound = 999999999,
                                    ApplyDelimiterStringAdvice = true,
                                    CommunicationAgreementId = "0",
                                    CreateGroupingSegments = true,
                                    GroupApplicationPassword = "0",
                                    GroupApplicationReceiverId = "0",
                                    GroupApplicationReceiverQualifier = "ZZ",
                                    GroupApplicationSenderId = "AA",
                                    GroupApplicationSenderQualifier = "ZZ",
                                    GroupAssociationAssignedCode = "0",
                                    GroupControlNumberPrefix = "",
                                    GroupControlNumberSuffix = "",
                                    GroupControllingAgencyCode = "0",
                                    GroupMessageRelease = "0.0",
                                    GroupMessageVersion = "0.0",
                                    InterchangeControlNumberPrefix = "CU",
                                    InterchangeControlNumberSuffix = "NUM",
                                    IsTestInterchange = true,
                                    ProcessingPriorityCode = "0",
                                    ReceiverInternalIdentification = "0",
                                    ReceiverInternalSubIdentification = "0",
                                    RecipientReferencePasswordQualifier = "ZZ",
                                    RecipientReferencePasswordValue = "AA",
                                    SenderInternalIdentification = "AA",
                                    SenderInternalSubIdentification = "AA"
                                },
                                MessageFilter = new EdifactMessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                FramingSettings = new EdifactFramingSettings
                                {
                                    DataElementSeparator = 53,
                                    ComponentSeparator = 58,
                                    SegmentTerminator = 39,
                                    CharacterSet = EdifactCharacterSet.UNOC,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.None,
                                    ProtocolVersion = 4,
                                    DecimalPointIndicator = EdifactDecimalIndicator.Comma,
                                    ReleaseIndicator = 63,
                                    CharacterEncoding = "UTF",
                                    RepetitionSeparator = 42
                                },
                                ProcessingSettings = new EdifactProcessingSettings
                                {
                                    CreateEmptyXmlTagsForTrailingSeparators = true,
                                    MaskSecurityInfo = true,
                                    PreserveInterchange = true,
                                    SuspendInterchangeOnError = true,
                                    UseDotAsDecimalSeparator = true
                                },
                                ValidationSettings = new EdifactValidationSettings
                                {
                                    AllowLeadingAndTrailingSpacesAndZeroes = true,
                                    ValidateCharacterSet = true,
                                    CheckDuplicateGroupControlNumber = true,
                                    CheckDuplicateInterchangeControlNumber = true,
                                    CheckDuplicateTransactionSetControlNumber = true,
                                    InterchangeControlNumberValidityDays = 30,
                                    TrailingSeparatorPolicy = TrailingSeparatorPolicy.Optional,
                                    TrimLeadingAndTrailingSpacesAndZeroes = true,
                                    ValidateEdiTypes = true,
                                    ValidateXsdTypes = true
                                },
                                SchemaReferences = new EdifactSchemaReference[0]

                            }
                        }
                    }
                };
                return content;
            }
        }

        /// <summary>
        /// Gets the AS2 agreement content.
        /// </summary>
        private AgreementContent AS2AgreementContent
        {
            get
            {
                var content = new AgreementContent
                {
                    AS2 = new AS2AgreementContent
                    {
                        ReceiveAgreement = new AS2OneWayAgreement
                        {
                            ProtocolSettings = new AS2ProtocolSettings
                            {
                                AcknowledgementConnectionSettings = new AS2AcknowledgementConnectionSettings
                                {
                                    IgnoreCertificateNameMismatch = true,
                                    KeepHttpConnectionAlive = true,
                                    SupportHttpStatusCodeContinue = true,
                                    UnfoldHttpHeaders = true,
                                },
                                EnvelopeSettings = new AS2EnvelopeSettings
                                {
                                    AutogenerateFileName = true,
                                    FileNameTemplate = "Test",
                                    MessageContentType = "text/plain",
                                    SuspendMessageOnFileNameGenerationError = true,
                                    TransmitFileNameInMimeHeader = true,
                                },
                                ErrorSettings = new AS2ErrorSettings
                                {
                                    ResendIfMdnNotReceived = true,
                                    SuspendDuplicateMessage = true
                                },
                                MdnSettings = new AS2MdnSettings
                                {
                                    DispositionNotificationTo = "http://tempuri.org",
                                    MdnText = "Sample",
                                    MicHashingAlgorithm = HashingAlgorithm.MD5,
                                    NeedMdn = true,
                                    ReceiptDeliveryUrl = "http://tempuri.org",
                                    SendInboundMdnToMessageBox = true,
                                    SendMdnAsynchronously = true,
                                    SignMdn = true,
                                    SignOutboundMdnIfOptional = true
                                },
                                MessageConnectionSettings = new AS2MessageConnectionSettings
                                {
                                    IgnoreCertificateNameMismatch = true,
                                    KeepHttpConnectionAlive = true,
                                    SupportHttpStatusCodeContinue = true,
                                    UnfoldHttpHeaders = true
                                },
                                SecuritySettings = new AS2SecuritySettings
                                {
                                    EnableNrrForInboundDecodedMessages = true,
                                    EnableNrrForInboundEncodedMessages = true,
                                    EnableNrrForInboundMdn = true,
                                    EnableNrrForOutboundDecodedMessages = true,
                                    EnableNrrForOutboundEncodedMessages = true,
                                    EnableNrrForOutboundMdn = true,

                                    OverrideGroupSigningCertificate = false

                                },
                                ValidationSettings = new AS2ValidationSettings
                                {
                                    CheckCertificateRevocationListOnReceive = true,
                                    CheckCertificateRevocationListOnSend = true,
                                    CheckDuplicateMessage = true,
                                    CompressMessage = true,
                                    EncryptMessage = false,
                                    EncryptionAlgorithm = EncryptionAlgorithm.AES128,
                                    InterchangeDuplicatesValidityDays = 100,
                                    OverrideMessageProperties = true,
                                    SignMessage = false
                                }
                            },
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            },
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            }
                        },
                        SendAgreement = new AS2OneWayAgreement
                        {
                            ProtocolSettings = new AS2ProtocolSettings
                            {
                                AcknowledgementConnectionSettings = new AS2AcknowledgementConnectionSettings
                                {
                                    IgnoreCertificateNameMismatch = true,
                                    KeepHttpConnectionAlive = true,
                                    SupportHttpStatusCodeContinue = true,
                                    UnfoldHttpHeaders = true,
                                },
                                EnvelopeSettings = new AS2EnvelopeSettings
                                {
                                    AutogenerateFileName = true,
                                    FileNameTemplate = "Test",
                                    MessageContentType = "text/plain",
                                    SuspendMessageOnFileNameGenerationError = true,
                                    TransmitFileNameInMimeHeader = true,
                                },
                                ErrorSettings = new AS2ErrorSettings
                                {
                                    ResendIfMdnNotReceived = true,
                                    SuspendDuplicateMessage = true
                                },
                                MdnSettings = new AS2MdnSettings
                                {
                                    DispositionNotificationTo = "http://tempuri.org",
                                    MdnText = "Sample",
                                    MicHashingAlgorithm = HashingAlgorithm.MD5,
                                    NeedMdn = true,
                                    ReceiptDeliveryUrl = "http://tempuri.org",
                                    SendInboundMdnToMessageBox = true,
                                    SendMdnAsynchronously = true,
                                    SignMdn = true,
                                    SignOutboundMdnIfOptional = true
                                },
                                MessageConnectionSettings = new AS2MessageConnectionSettings
                                {
                                    IgnoreCertificateNameMismatch = true,
                                    KeepHttpConnectionAlive = true,
                                    SupportHttpStatusCodeContinue = true,
                                    UnfoldHttpHeaders = true
                                },
                                SecuritySettings = new AS2SecuritySettings
                                {
                                    EnableNrrForInboundDecodedMessages = true,
                                    EnableNrrForInboundEncodedMessages = true,
                                    EnableNrrForInboundMdn = true,
                                    EnableNrrForOutboundDecodedMessages = true,
                                    EnableNrrForOutboundEncodedMessages = true,
                                    EnableNrrForOutboundMdn = true,

                                    OverrideGroupSigningCertificate = false

                                },
                                ValidationSettings = new AS2ValidationSettings
                                {
                                    CheckCertificateRevocationListOnReceive = true,
                                    CheckCertificateRevocationListOnSend = true,
                                    CheckDuplicateMessage = true,
                                    CompressMessage = true,
                                    EncryptMessage = false,
                                    EncryptionAlgorithm = EncryptionAlgorithm.AES128,
                                    InterchangeDuplicatesValidityDays = 100,
                                    OverrideMessageProperties = true,
                                    SignMessage = false
                                }
                            },
                            ReceiverBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "AA"
                            },
                            SenderBusinessIdentity = new BusinessIdentity
                            {
                                Qualifier = "ZZ",
                                Value = "ZZ"
                            }
                        }
                    }
                };
                return content;
            }
        }

        #endregion Private
    }
}
