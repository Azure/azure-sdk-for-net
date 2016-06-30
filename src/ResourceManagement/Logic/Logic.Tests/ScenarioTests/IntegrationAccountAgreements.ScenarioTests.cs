// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Scenario tests for the integration accounts agreement.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountAgreementScenarioTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountAgreementScenarioTests";

        /// <summary>
        /// Tests the create and delete operations of the integration account agreement.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountAgreement()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var agreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName, integrationAccountName));

                Assert.Equal(agreement.Name, integrationAccountAgreementName);

                client.IntegrationAccountAgreements.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountAgreementName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and update operations of the integration account agreement.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountAgreement()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var agreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName, integrationAccountName,
                        AgreementType.AS2));

                var updateAgreement = CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName,
                    integrationAccountName);

                var updatedAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountAgreementName, updateAgreement);

                Assert.Equal(updatedAgreement.Name, integrationAccountAgreementName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account agreement.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountAgreement()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var partner = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName, integrationAccountName,
                        AgreementType.Edifact));

                Assert.Equal(partner.Name, integrationAccountAgreementName);

                var getPartner = client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountAgreementName);

                Assert.Equal(partner.Name, getPartner.Name);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and list operations of the integration account agreement.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountAgreements()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {

                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);

                var integrationAccountAgreementName1 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var integrationAccountAgreementName2 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var integrationAccountAgreementName3 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                client.IntegrationAccountAgreements.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName1,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName1, integrationAccountName,
                        AgreementType.AS2));

                client.IntegrationAccountAgreements.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName2,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName2, integrationAccountName,
                        AgreementType.Edifact));

                client.IntegrationAccountAgreements.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName3,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName3, integrationAccountName));

                var agreements = client.IntegrationAccountAgreements.List(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.True(agreements.Count() == 3);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account agreement with integration account. 
        /// Agreement must be deleted with the integration account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountAgreementOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var agreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountAgreementName,
                    CreateIntegrationAccountAgreementInstance(integrationAccountAgreementName, integrationAccountName));

                Assert.Equal(agreement.Name, integrationAccountAgreementName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountAgreements.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountAgreementName));
            }
        }

        /// <summary>
        /// Tests the create operations of the integration account agreement using file input.
        /// </summary>
        [Fact]
        public void CreateIntegrationAccountAgreementUsingFile()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);

                var integrationAs2AccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var integrationX12AccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);
                var integrationEdifactAccountAgreementName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountAgreementPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, CreateIntegrationAccountInstance(integrationAccountName));

                var as2Agreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAs2AccountAgreementName,
                    CreateIntegrationAccountAgreementInstanceFromFile(integrationAs2AccountAgreementName,
                        integrationAccountName, AgreementType.AS2));

                var edifactAgreement = client.IntegrationAccountAgreements.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationEdifactAccountAgreementName,
                    CreateIntegrationAccountAgreementInstanceFromFile(integrationEdifactAccountAgreementName,
                        integrationAccountName, AgreementType.Edifact));

                var x12Agreement = client.IntegrationAccountAgreements.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationX12AccountAgreementName,
                    CreateIntegrationAccountAgreementInstanceFromFile(integrationX12AccountAgreementName,
                        integrationAccountName, AgreementType.X12));

                Assert.Equal(as2Agreement.Name, integrationAs2AccountAgreementName);
                Assert.Equal(edifactAgreement.Name, integrationEdifactAccountAgreementName);
                Assert.Equal(x12Agreement.Name, integrationX12AccountAgreementName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        #region Private        

        /// <summary>
        /// Creates an Integration account agreement
        /// </summary>
        /// <param name="integrationAccountAgreementName">Name of the integration account agreement</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Agreement instance</returns>
        private IntegrationAccountAgreement CreateIntegrationAccountAgreementInstance(
            string integrationAccountAgreementName,
            string integrationAccountName,
            AgreementType agreementType = AgreementType.X12)
        {
            AgreementContent agreementContent = null;
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("IntegrationAccountAgreement", integrationAccountAgreementName);

            switch (agreementType)
            {
                case AgreementType.AS2:
                    agreementContent = AS2AgreementContent;
                    break;
                case AgreementType.Edifact:
                    agreementContent = EDIFACTAgreementContent;
                    break;
                case AgreementType.X12:
                    agreementContent = X12AgreementContent;
                    break;
            }

            var agreement = new IntegrationAccountAgreement
            {
                Location = Constants.DefaultLocation,
                Name = integrationAccountAgreementName,
                Tags = tags,
                Metadata = integrationAccountAgreementName,
                AgreementType = agreementType,
                GuestIdentity = new BusinessIdentity {Qualifier = "AA", Value = "AA"},
                HostIdentity = new BusinessIdentity {Qualifier = "ZZ", Value = "ZZ"},
                GuestPartner = "GuestPartner",
                HostPartner = "HostPartner",
                Content = agreementContent
            };

            return agreement;
        }

        /// <summary>
        /// Creates an Integration account agreement from file source
        /// </summary>
        /// <param name="integrationAccountAgreementName">Name of the integration account agreement</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Agreement instance</returns>
        private IntegrationAccountAgreement CreateIntegrationAccountAgreementInstanceFromFile(
            string integrationAccountAgreementName,
            string integrationAccountName,
            AgreementType agreementType = AgreementType.X12)
        {
            AgreementContent agreementContent = null;
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("IntegrationAccountAgreement", integrationAccountAgreementName);

            switch (agreementType)
            {
                case AgreementType.AS2:
                    agreementContent =
                        JsonConvert.DeserializeObject<AgreementContent>(
                            File.ReadAllText(@"TestData/IntegrationAccountAS2AgreementContent.json"));
                    break;
                case AgreementType.Edifact:
                    agreementContent =
                        JsonConvert.DeserializeObject<AgreementContent>(
                            File.ReadAllText(@"TestData/IntegrationAccountEDIFACTAgreementContent.json"));
                    break;
                case AgreementType.X12:
                    agreementContent =
                        JsonConvert.DeserializeObject<AgreementContent>(
                            File.ReadAllText(@"TestData/IntegrationAccountX12AgreementContent.json"));
                    break;
            }

            var agreement = new IntegrationAccountAgreement
            {
                Location = Constants.DefaultLocation,
                Name = integrationAccountAgreementName,
                Tags = tags,
                Metadata = integrationAccountAgreementName,
                AgreementType = agreementType,
                GuestIdentity = new BusinessIdentity {Qualifier = "AA", Value = "AA"},
                HostIdentity = new BusinessIdentity {Qualifier = "ZZ", Value = "ZZ"},
                GuestPartner = "GuestPartner",
                HostPartner = "HostPartner",
                Content = agreementContent
            };

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
                                    ValidateEDITypes = true,
                                    ValidateXSDTypes = false,
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
                                    ValidateEDITypes = true,
                                    ValidateXSDTypes = false,
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
                                    ReceiverReverseRoutingAddress = "0",
                                    RecipientReferencePasswordQualifier = "ZZ",
                                    RecipientReferencePasswordValue = "AA",
                                    SenderInternalIdentification = "AA",
                                    SenderInternalSubIdentification = "AA",
                                    SenderReverseRoutingAddress = "ZZ"
                                },
                                MessageFilter = new EdifactMessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                FramingSettings = new EdifactFramingSettings
                                {
                                    ComponentSeparator = 0,
                                    DataElementSeparator = 0,
                                    SegmentTerminator = 0,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.CR,
                                    CharacterSet = EdifactCharacterSet.KECA,
                                    CharacterEncoding = "0",
                                    DecimalPointIndicator = EdifactDecimalIndicator.Comma,
                                    ProtocolVersion = 0,
                                    ReleaseIndicator = 0,
                                    RepetitionSeparator = 0,
                                    ServiceCodeListDirectoryVersion = "0"
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
                                    ValidateEDITypes = true,
                                    ValidateXSDTypes = true
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
                                    ReceiverReverseRoutingAddress = "0",
                                    RecipientReferencePasswordQualifier = "ZZ",
                                    RecipientReferencePasswordValue = "AA",
                                    SenderInternalIdentification = "AA",
                                    SenderInternalSubIdentification = "AA",
                                    SenderReverseRoutingAddress = "XX"
                                },
                                MessageFilter = new EdifactMessageFilter
                                {
                                    MessageFilterType = MessageFilterType.Exclude
                                },
                                FramingSettings = new EdifactFramingSettings
                                {
                                    ComponentSeparator = 0,
                                    DataElementSeparator = 0,
                                    SegmentTerminator = 0,
                                    SegmentTerminatorSuffix = SegmentTerminatorSuffix.CR,
                                    CharacterSet = EdifactCharacterSet.KECA,
                                    CharacterEncoding = "0",
                                    DecimalPointIndicator = EdifactDecimalIndicator.Comma,
                                    ProtocolVersion = 0,
                                    ReleaseIndicator = 0,
                                    RepetitionSeparator = 0,
                                    ServiceCodeListDirectoryVersion = "0"
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
                                    ValidateEDITypes = true,
                                    ValidateXSDTypes = true
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
                                    MicHashingAlgorithm = HashingAlgorithm.None,
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
                                    MicHashingAlgorithm = HashingAlgorithm.None,
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