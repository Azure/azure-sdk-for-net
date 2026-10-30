namespace Azure.Provisioning.Support
{
    public enum AdvancedDiagnosticConsent
    {
        Yes = 0,
        No = 1,
    }
    public partial class ChatTranscriptDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ChatTranscriptDetail() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Support.ChatTranscriptMessageProperties> Messages { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.ChatTranscriptDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public partial class ChatTranscriptMessageProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ChatTranscriptMessageProperties() { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.SupportTicketCommunicationDirection> CommunicationDirection { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Sender { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TranscriptContentType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileWorkspaceDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FileWorkspaceDetail(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.FileWorkspaceDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public enum IsTemporaryTicket
    {
        Yes = 0,
        No = 1,
    }
    public enum PreferredContactMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="email")]
        Email = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="phone")]
        Phone = 1,
    }
    public partial class ProblemClassification : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ProblemClassification() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Support.SupportAzureService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Support.SecondaryConsentEnabled> SecondaryConsentEnabledInfo { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.ProblemClassification FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public partial class QuotaTicketDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaTicketDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Support.SupportQuotaChangeContent> QuotaChangeRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuotaChangeRequestSubType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuotaChangeRequestVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecondaryConsent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecondaryConsent() { }
        public Azure.Provisioning.BicepValue<string> SecondaryConsentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.UserConsent> UserConsent { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecondaryConsentEnabled : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecondaryConsentEnabled() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConsentEnabledType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SupportAzureService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SupportAzureService() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> ArmResourceTypes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.SupportAzureService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public partial class SupportContactProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SupportContactProfile() { }
        public Azure.Provisioning.BicepList<string> AdditionalEmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.PreferredContactMethod> PreferredContactMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreferredSupportLanguage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreferredTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryEmailAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SupportDirectConnectEscalation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SupportDirectConnectEscalation() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Support.SupportSeverityLevel> AllowedSeverities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.SupportEscalationStatus> AzureEEStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReasonForEscalation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SupportEscalationStatus
    {
        EscalationAvailable = 0,
        EscalationInitiated = 1,
        EscalationProcessed = 2,
        EscalationUnsupported = 3,
        EscalationUnavailable = 4,
    }
    public partial class SupportFileDetail : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SupportFileDetail(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ChunkSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FileSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfChunks { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.SupportFileDetail FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public partial class SupportQuotaChangeContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SupportQuotaChangeContent() { }
        public Azure.Provisioning.BicepValue<string> Payload { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SupportServiceLevelAgreement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SupportServiceLevelAgreement() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SlaInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SupportSeverityLevel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="minimal")]
        Minimal = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="moderate")]
        Moderate = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="critical")]
        Critical = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="highestcriticalimpact")]
        Highestcriticalimpact = 3,
    }
    public partial class SupportTicket : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SupportTicket(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.AdvancedDiagnosticConsent> AdvancedDiagnosticConsent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommunityForumPost { get { throw null; } set { } }
        public Azure.Provisioning.Support.SupportContactProfile ContactDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Support.SupportDirectConnectEscalation DirectConnectEscalation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnrollmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileWorkspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.IsTemporaryTicket> IsTemporaryTicket { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProblemClassificationDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProblemClassificationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProblemScopingQuestions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProblemStartsOn { get { throw null; } set { } }
        public Azure.Provisioning.Support.QuotaTicketDetails QuotaTicketDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Require24X7Response { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Support.SecondaryConsent> SecondaryConsent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceId { get { throw null; } set { } }
        public Azure.Provisioning.Support.SupportServiceLevelAgreement ServiceLevelAgreement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.SupportSeverityLevel> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SupportEngineerEmailAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SupportPlanDisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SupportPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SupportPlanType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SupportTicketId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TechnicalTicketDetailsResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.SupportTicket FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public partial class SupportTicketCommunication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SupportTicketCommunication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.SupportTicketCommunicationDirection> CommunicationDirection { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Support.SupportTicketCommunicationType> CommunicationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sender { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Support.SupportTicketCommunication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_06_01_PREVIEW;
        }
    }
    public enum SupportTicketCommunicationDirection
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="inbound")]
        Inbound = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="outbound")]
        Outbound = 1,
    }
    public enum SupportTicketCommunicationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="web")]
        Web = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="phone")]
        Phone = 1,
    }
    public enum UserConsent
    {
        Yes = 0,
        No = 1,
    }
}
