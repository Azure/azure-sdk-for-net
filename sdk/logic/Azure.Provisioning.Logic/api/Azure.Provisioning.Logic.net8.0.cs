namespace Azure.Provisioning.Logic
{
    public partial class AS2AcknowledgementConnectionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2AcknowledgementConnectionSettings() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> KeepHttpConnectionAlive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UnfoldHttpHeaders { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2AgreementContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2AgreementContent() { }
        public Azure.Provisioning.Logic.AS2OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2OneWayAgreement SendAgreement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AS2EncryptionAlgorithm
    {
        NotSpecified = 0,
        None = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DES3")]
        Des3 = 2,
        RC2 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES128")]
        Aes128 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES192")]
        Aes192 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES256")]
        Aes256 = 6,
    }
    public partial class AS2EnvelopeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2EnvelopeSettings() { }
        public Azure.Provisioning.BicepValue<bool> AutoGenerateFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNameTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ContentType> MessageContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuspendMessageOnFileNameGenerationError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TransmitFileNameInMimeHeader { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2ErrorSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2ErrorSettings() { }
        public Azure.Provisioning.BicepValue<bool> ResendIfMdnNotReceived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuspendDuplicateMessage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AS2HashingAlgorithm
    {
        NotSpecified = 0,
        None = 1,
        MD5 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA1")]
        Sha1 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2256")]
        Sha2256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2384")]
        Sha2384 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2512")]
        Sha2512 = 6,
    }
    public partial class AS2MdnSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2MdnSettings() { }
        public Azure.Provisioning.BicepValue<string> DispositionNotificationTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MdnText { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.AS2HashingAlgorithm> MicHashingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedMdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ReceiptDeliveryUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendInboundMdnToMessageBox { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendMdnAsynchronously { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SignMdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SignOutboundMdnIfOptional { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2MessageConnectionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2MessageConnectionSettings() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> KeepHttpConnectionAlive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UnfoldHttpHeaders { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2OneWayAgreement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2OneWayAgreement() { }
        public Azure.Provisioning.Logic.AS2ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2ProtocolSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2ProtocolSettings() { }
        public Azure.Provisioning.Logic.AS2AcknowledgementConnectionSettings AcknowledgementConnectionSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2ErrorSettings ErrorSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2MdnSettings MdnSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2MessageConnectionSettings MessageConnectionSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2SecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.AS2ValidationSettings ValidationSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AS2SecuritySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2SecuritySettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForInboundDecodedMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForInboundEncodedMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForInboundMdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForOutboundDecodedMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForOutboundEncodedMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNrrForOutboundMdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionCertificateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OverrideGroupSigningCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha2AlgorithmFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SigningCertificateName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AS2SigningAlgorithm
    {
        NotSpecified = 0,
        Default = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA1")]
        Sha1 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2256")]
        Sha2256 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2384")]
        Sha2384 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA2512")]
        Sha2512 = 5,
    }
    public partial class AS2ValidationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AS2ValidationSettings() { }
        public Azure.Provisioning.BicepValue<bool> CheckCertificateRevocationListOnReceive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckCertificateRevocationListOnSend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CompressMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.AS2EncryptionAlgorithm> EncryptionAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EncryptMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InterchangeDuplicatesValidityDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OverrideMessageProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.AS2SigningAlgorithm> SigningAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SignMessage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactAcknowledgementSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactAcknowledgementSettings() { }
        public Azure.Provisioning.BicepValue<int> AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedLoopForValidMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendSynchronousAcknowledgement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactAgreementContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactAgreementContent() { }
        public Azure.Provisioning.Logic.EdifactOneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactOneWayAgreement SendAgreement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EdifactCharacterSet
    {
        NotSpecified = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOB")]
        Unob = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOA")]
        Unoa = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOC")]
        Unoc = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOD")]
        Unod = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOE")]
        Unoe = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOF")]
        Unof = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOG")]
        Unog = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOH")]
        Unoh = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOI")]
        Unoi = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOJ")]
        Unoj = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOK")]
        Unok = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOX")]
        Unox = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UNOY")]
        Unoy = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="KECA")]
        Keca = 14,
    }
    public enum EdifactDecimalIndicator
    {
        NotSpecified = 0,
        Comma = 1,
        Decimal = 2,
    }
    public partial class EdifactDelimiterOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactDelimiterOverride() { }
        public Azure.Provisioning.BicepValue<int> ComponentSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DataElementSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.EdifactDecimalIndicator> DecimalPointIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageAssociationAssignedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageRelease { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReleaseIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RepetitionSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SegmentTerminator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.SegmentTerminatorSuffix> SegmentTerminatorSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactEnvelopeOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactEnvelopeOverride() { }
        public Azure.Provisioning.BicepValue<string> ApplicationPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssociationAssignedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ControllingAgencyCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionalGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupHeaderMessageRelease { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupHeaderMessageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageAssociationAssignedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageRelease { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverApplicationQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactEnvelopeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactEnvelopeSettings() { }
        public Azure.Provisioning.BicepValue<string> ApplicationReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ApplyDelimiterStringAdvice { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommunicationAgreementId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CreateGroupingSegments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDefaultGroupHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionalGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupApplicationPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupApplicationReceiverId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupApplicationReceiverQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupApplicationSenderId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupApplicationSenderQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupAssociationAssignedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupControllingAgencyCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> GroupControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> GroupControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupMessageRelease { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupMessageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InterchangeControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InterchangeControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTestInterchange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProcessingPriorityCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverInternalIdentification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverInternalSubIdentification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverReverseRoutingAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecipientReferencePasswordQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecipientReferencePasswordValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverGroupControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverInterchangeControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderInternalIdentification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderInternalSubIdentification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderReverseRoutingAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TransactionSetControlNumberUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactFramingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactFramingSettings() { }
        public Azure.Provisioning.BicepValue<string> CharacterEncoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.EdifactCharacterSet> CharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ComponentSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DataElementSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.EdifactDecimalIndicator> DecimalPointIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ProtocolVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReleaseIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RepetitionSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SegmentTerminator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.SegmentTerminatorSuffix> SegmentTerminatorSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceCodeListDirectoryVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactMessageIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactMessageIdentifier() { }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactOneWayAgreement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactOneWayAgreement() { }
        public Azure.Provisioning.Logic.EdifactProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactProcessingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactProcessingSettings() { }
        public Azure.Provisioning.BicepValue<bool> CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MaskSecurityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreserveInterchange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuspendInterchangeOnError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseDotAsDecimalSeparator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactProtocolSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactProtocolSettings() { }
        public Azure.Provisioning.Logic.EdifactAcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.EdifactDelimiterOverride> EdifactDelimiterOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.EdifactEnvelopeOverride> EnvelopeOverrides { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactEnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactFramingSettings FramingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.EdifactMessageIdentifier> MessageFilterList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.MessageFilterType> MessageFilterType { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.EdifactSchemaReference> SchemaReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.EdifactValidationOverride> ValidationOverrides { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactValidationSettings ValidationSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactSchemaReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactSchemaReference() { }
        public Azure.Provisioning.BicepValue<string> AssociationAssignedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageRelease { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationQualifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactValidationOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactValidationOverride() { }
        public Azure.Provisioning.BicepValue<bool> AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnforceCharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.TrailingSeparatorPolicy> TrailingSeparatorPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateEdiTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateXsdTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EdifactValidationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EdifactValidationSettings() { }
        public Azure.Provisioning.BicepValue<bool> AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.TrailingSeparatorPolicy> TrailingSeparatorPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateCharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateEdiTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateXsdTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowAccessControlConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowAccessControlConfiguration() { }
        public Azure.Provisioning.Logic.FlowAccessControlConfigurationPolicy Actions { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowAccessControlConfigurationPolicy Contents { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowAccessControlConfigurationPolicy Triggers { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowAccessControlConfigurationPolicy WorkflowManagement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowAccessControlConfigurationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowAccessControlConfigurationPolicy() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Logic.OpenAuthenticationAccessPolicy> AccessPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.FlowAccessControlIPAddressRange> AllowedCallerIPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowAccessControlIPAddressRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowAccessControlIPAddressRange() { }
        public Azure.Provisioning.BicepValue<string> AddressRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowEndpointIPAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowEndpointIPAddress() { }
        public Azure.Provisioning.BicepValue<string> CidrAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowEndpoints() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.FlowEndpointIPAddress> AccessEndpointIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.FlowEndpointIPAddress> OutgoingIPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowEndpointsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowEndpointsConfiguration() { }
        public Azure.Provisioning.Logic.FlowEndpoints Connector { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowEndpoints Workflow { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccount(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Logic.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationAccountSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccount FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationAccountAgreement : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountAgreement(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationAccountAgreementType> AgreementType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.Logic.IntegrationAccountAgreementContent Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity GuestIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GuestPartner { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity HostIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountAgreement FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationAccountAgreementContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountAgreementContent() { }
        public Azure.Provisioning.Logic.AS2AgreementContent AS2 { get { throw null; } set { } }
        public Azure.Provisioning.Logic.EdifactAgreementContent Edifact { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12AgreementContent X12 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationAccountAgreementType
    {
        NotSpecified = 0,
        AS2 = 1,
        X12 = 2,
        Edifact = 3,
    }
    public partial class IntegrationAccountAssemblyDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountAssemblyDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountAssemblyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountAssemblyDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationAccountAssemblyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountAssemblyProperties() { }
        public Azure.Provisioning.BicepValue<string> AssemblyCulture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssemblyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssemblyPublicKeyToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssemblyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicContentLink ContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ContentType> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountBatchConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountBatchConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBatchConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountBatchConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationAccountBatchConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountBatchConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<string> BatchGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBatchReleaseCriteria ReleaseCriteria { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountBatchReleaseCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountBatchReleaseCriteria() { }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MessageCount { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicWorkflowTriggerRecurrence Recurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountBusinessIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountBusinessIdentity() { }
        public Azure.Provisioning.BicepValue<string> Qualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Logic.IntegrationAccountKeyVaultKeyReference Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PublicCertificate { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationAccountKeyVaultKeyReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationAccountKeyVaultKeyReference() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountKeyVaultNameReference : Azure.Provisioning.Logic.LogicResourceReference
    {
        public IntegrationAccountKeyVaultNameReference() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationAccountMap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountMap(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ContentType> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationAccountMapType> MapType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParametersSchemaRef { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountMap FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum IntegrationAccountMapType
    {
        NotSpecified = 0,
        Xslt = 1,
        Xslt20 = 2,
        Xslt30 = 3,
        Liquid = 4,
    }
    public partial class IntegrationAccountPartner : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountPartner(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity> B2BBusinessIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationAccountPartnerType> PartnerType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountPartner FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum IntegrationAccountPartnerType
    {
        NotSpecified = 0,
        B2B = 1,
    }
    public partial class IntegrationAccountSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountSchema(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ContentType> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DocumentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationAccountSchemaType> SchemaType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountSchema FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum IntegrationAccountSchemaType
    {
        NotSpecified = 0,
        Xml = 1,
    }
    public partial class IntegrationAccountSession : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationAccountSession(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationAccountSession FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum IntegrationAccountSkuName
    {
        NotSpecified = 0,
        Free = 1,
        Basic = 2,
        Standard = 3,
    }
    public partial class IntegrationServiceEnvironmenEncryptionKeyReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationServiceEnvironmenEncryptionKeyReference() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicResourceReference KeyVault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationServiceEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationServiceEnvironment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationServiceEnvironmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationServiceEnvironmentSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationServiceEnvironment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum IntegrationServiceEnvironmentAccessEndpointType
    {
        NotSpecified = 0,
        External = 1,
        Internal = 2,
    }
    public partial class IntegrationServiceEnvironmentManagedApi : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationServiceEnvironmentManagedApi(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Logic.LogicApiResourceDefinitions ApiDefinitions { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ApiDefinitionUri { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicApiTier> Category { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> ConnectionParameters { get { throw null; } }
        public Azure.Provisioning.Logic.LogicContentLink DeploymentParametersContentLinkDefinition { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicApiResourceGeneralInformation GeneralInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Logic.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicApiResourceMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesName { get { throw null; } }
        public Azure.Provisioning.Logic.IntegrationServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicApiResourcePolicies Policies { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Uri> RuntimeUris { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.IntegrationServiceEnvironmentManagedApi FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public partial class IntegrationServiceEnvironmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationServiceEnvironmentProperties() { }
        public Azure.Provisioning.Logic.IntegrationServiceEnvironmenEncryptionKeyReference EncryptionKeyReference { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IntegrationServiceEnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationServiceNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationServiceEnvironmentSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationServiceEnvironmentSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationServiceEnvironmentSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationServiceEnvironmentSkuName
    {
        NotSpecified = 0,
        Premium = 1,
        Developer = 2,
    }
    public partial class IntegrationServiceNetworkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationServiceNetworkConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.IntegrationServiceEnvironmentAccessEndpointType> EndpointType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.LogicResourceReference> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualNetworkAddressSpace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiDeploymentParameterMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiDeploymentParameterMetadata() { }
        public Azure.Provisioning.BicepValue<string> ApiDeploymentParameterMetadataType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicApiDeploymentParameterVisibility> Visibility { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiDeploymentParameterMetadataSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiDeploymentParameterMetadataSet() { }
        public Azure.Provisioning.Logic.LogicApiDeploymentParameterMetadata PackageContentLink { get { throw null; } }
        public Azure.Provisioning.Logic.LogicApiDeploymentParameterMetadata RedisCacheConnectionString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicApiDeploymentParameterVisibility
    {
        NotSpecified = 0,
        Default = 1,
        Internal = 2,
    }
    public partial class LogicApiReference : Azure.Provisioning.Logic.LogicResourceReference
    {
        public LogicApiReference() { }
        public Azure.Provisioning.BicepValue<string> BrandColor { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicApiTier> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> IconUri { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Swagger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiResourceDefinitions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiResourceDefinitions() { }
        public Azure.Provisioning.BicepValue<System.Uri> ModifiedSwaggerUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> OriginalSwaggerUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiResourceGeneralInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiResourceGeneralInformation() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IconUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReleaseTag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> TermsOfUseUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicApiTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiResourceMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiResourceMetadata() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicApiType> ApiType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BrandColor { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionType { get { throw null; } }
        public Azure.Provisioning.Logic.LogicApiDeploymentParameterMetadataSet DeploymentParameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HideKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWsdlImportMethod> WsdlImportMethod { get { throw null; } }
        public Azure.Provisioning.Logic.LogicWsdlService WsdlService { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicApiResourcePolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicApiResourcePolicies() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContentLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicApiTier
    {
        NotSpecified = 0,
        Enterprise = 1,
        Standard = 2,
        Premium = 3,
    }
    public enum LogicApiType
    {
        NotSpecified = 0,
        Rest = 1,
        Soap = 2,
    }
    public partial class LogicContentHash : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicContentHash() { }
        public Azure.Provisioning.BicepValue<string> Algorithm { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicContentLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicContentLink() { }
        public Azure.Provisioning.Logic.LogicContentHash ContentHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> ContentSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicResourceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicResourceReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicSkuName> Name { get { throw null; } }
        public Azure.Provisioning.Logic.LogicResourceReference Plan { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicSkuName
    {
        NotSpecified = 0,
        Free = 1,
        Shared = 2,
        Basic = 3,
        Standard = 4,
        Premium = 5,
    }
    public partial class LogicWorkflow : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogicWorkflow(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Logic.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccessEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Definition { get { throw null; } set { } }
        public Azure.Provisioning.Logic.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicResourceReference IntegrationAccount { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Logic.LogicWorkflowParameterInfo> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Logic.LogicSku Sku { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Logic.LogicWorkflow FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_05_01;
        }
    }
    public enum LogicWorkflowDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class LogicWorkflowOutputParameterInfo : Azure.Provisioning.Logic.LogicWorkflowParameterInfo
    {
        public LogicWorkflowOutputParameterInfo() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Error { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicWorkflowParameterInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicWorkflowParameterInfo() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowParameterType> ParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicWorkflowParameterType
    {
        NotSpecified = 0,
        String = 1,
        SecureString = 2,
        Int = 3,
        Float = 4,
        Bool = 5,
        Array = 6,
        Object = 7,
        SecureObject = 8,
    }
    public enum LogicWorkflowProvisioningState
    {
        NotSpecified = 0,
        Accepted = 1,
        Running = 2,
        Ready = 3,
        Creating = 4,
        Created = 5,
        Deleting = 6,
        Deleted = 7,
        Canceled = 8,
        Failed = 9,
        Succeeded = 10,
        Moving = 11,
        Updating = 12,
        Registering = 13,
        Registered = 14,
        Unregistering = 15,
        Unregistered = 16,
        Completed = 17,
        Renewing = 18,
        Pending = 19,
        Waiting = 20,
        InProgress = 21,
    }
    public enum LogicWorkflowRecurrenceFrequency
    {
        NotSpecified = 0,
        Second = 1,
        Minute = 2,
        Hour = 3,
        Day = 4,
        Week = 5,
        Month = 6,
        Year = 7,
    }
    public partial class LogicWorkflowRecurrenceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicWorkflowRecurrenceSchedule() { }
        public Azure.Provisioning.BicepList<int> Hours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Minutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> MonthDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.LogicWorkflowRecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.LogicWorkflowDayOfWeek> WeekDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicWorkflowRecurrenceScheduleOccurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicWorkflowRecurrenceScheduleOccurrence() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowDayOfWeek> Day { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Occurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicWorkflowReference : Azure.Provisioning.Logic.LogicResourceReference
    {
        public LogicWorkflowReference() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicWorkflowState
    {
        NotSpecified = 0,
        Completed = 1,
        Enabled = 2,
        Disabled = 3,
        Deleted = 4,
        Suspended = 5,
    }
    public partial class LogicWorkflowTriggerRecurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicWorkflowTriggerRecurrence() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.LogicWorkflowRecurrenceFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.Logic.LogicWorkflowRecurrenceSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogicWorkflowTriggerReference : Azure.Provisioning.Logic.LogicResourceReference
    {
        public LogicWorkflowTriggerReference() { }
        public Azure.Provisioning.BicepValue<string> FlowName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TriggerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogicWsdlImportMethod
    {
        NotSpecified = 0,
        SoapToRest = 1,
        SoapPassThrough = 2,
    }
    public partial class LogicWsdlService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogicWsdlService() { }
        public Azure.Provisioning.BicepList<string> EndpointQualifiedNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QualifiedName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MessageFilterType
    {
        NotSpecified = 0,
        Include = 1,
        Exclude = 2,
    }
    public partial class OpenAuthenticationAccessPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenAuthenticationAccessPolicy() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.OpenAuthenticationPolicyClaim> Claims { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.OpenAuthenticationProviderType> ProviderType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OpenAuthenticationPolicyClaim : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenAuthenticationPolicyClaim() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OpenAuthenticationProviderType
    {
        AAD = 0,
    }
    public enum SegmentTerminatorSuffix
    {
        None = 0,
        NotSpecified = 1,
        CR = 2,
        LF = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CRLF")]
        Crlf = 4,
    }
    public enum TrailingSeparatorPolicy
    {
        NotSpecified = 0,
        NotAllowed = 1,
        Optional = 2,
        Mandatory = 3,
    }
    public enum UsageIndicator
    {
        NotSpecified = 0,
        Test = 1,
        Information = 2,
        Production = 3,
    }
    public partial class X12AcknowledgementSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12AcknowledgementSettings() { }
        public Azure.Provisioning.BicepValue<int> AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BatchImplementationAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionalAcknowledgementVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImplementationAcknowledgementVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedImplementationAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedLoopForValidMessages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendSynchronousAcknowledgement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12AgreementContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12AgreementContent() { }
        public Azure.Provisioning.Logic.X12OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12OneWayAgreement SendAgreement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum X12CharacterSet
    {
        NotSpecified = 0,
        Basic = 1,
        Extended = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UTF8")]
        Utf8 = 3,
    }
    public enum X12DateFormat
    {
        NotSpecified = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CCYYMMDD")]
        Ccyymmdd = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="YYMMDD")]
        Yymmdd = 2,
    }
    public partial class X12DelimiterOverrides : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12DelimiterOverrides() { }
        public Azure.Provisioning.BicepValue<int> ComponentSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DataElementSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtocolVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplaceCharacter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SegmentTerminator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.SegmentTerminatorSuffix> SegmentTerminatorSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12EnvelopeOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12EnvelopeOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.X12DateFormat> DateFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionalIdentifierCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtocolVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResponsibleAgencyCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.X12TimeFormat> TimeFormat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12EnvelopeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12EnvelopeSettings() { }
        public Azure.Provisioning.BicepValue<int> ControlStandardsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ControlVersionNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDefaultGroupHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionalGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> GroupControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> GroupControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupHeaderAgencyCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.X12DateFormat> GroupHeaderDateFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.X12TimeFormat> GroupHeaderTimeFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupHeaderVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReceiverApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverGroupControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverInterchangeControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TransactionSetControlNumberUpperBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.UsageIndicator> UsageIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseControlStandardsIdAsRepetitionCharacter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12FramingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12FramingSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.X12CharacterSet> CharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ComponentSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DataElementSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplaceCharacter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SegmentTerminator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.SegmentTerminatorSuffix> SegmentTerminatorSuffix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12MessageIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12MessageIdentifier() { }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12OneWayAgreement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12OneWayAgreement() { }
        public Azure.Provisioning.Logic.X12ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.Provisioning.Logic.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12ProcessingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12ProcessingSettings() { }
        public Azure.Provisioning.BicepValue<bool> ConvertImpliedDecimal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MaskSecurityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreserveInterchange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuspendInterchangeOnError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseDotAsDecimalSeparator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12ProtocolSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12ProtocolSettings() { }
        public Azure.Provisioning.Logic.X12AcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.X12EnvelopeOverride> EnvelopeOverrides { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12FramingSettings FramingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.X12MessageIdentifier> MessageFilterList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.MessageFilterType> MessageFilterType { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12ProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.X12SchemaReference> SchemaReferences { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12SecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.X12ValidationOverride> ValidationOverrides { get { throw null; } set { } }
        public Azure.Provisioning.Logic.X12ValidationSettings ValidationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Logic.X12DelimiterOverrides> X12DelimiterOverrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12SchemaReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12SchemaReference() { }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SenderApplicationId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12SecuritySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12SecuritySettings() { }
        public Azure.Provisioning.BicepValue<string> AuthorizationQualifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecurityQualifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum X12TimeFormat
    {
        NotSpecified = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HHMM")]
        Hhmm = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HHMMSS")]
        Hhmmss = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HHMMSSdd")]
        HhmmsSdd = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HHMMSSd")]
        HhmmsSd = 4,
    }
    public partial class X12ValidationOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12ValidationOverride() { }
        public Azure.Provisioning.BicepValue<bool> AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.TrailingSeparatorPolicy> TrailingSeparatorPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateCharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateEdiTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateXsdTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class X12ValidationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X12ValidationSettings() { }
        public Azure.Provisioning.BicepValue<bool> AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Logic.TrailingSeparatorPolicy> TrailingSeparatorPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateCharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateEdiTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateXsdTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
