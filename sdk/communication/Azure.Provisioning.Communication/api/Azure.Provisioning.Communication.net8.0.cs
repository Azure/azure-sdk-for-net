namespace Azure.Provisioning.Communication
{
    public partial class CommunicationDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommunicationDomain(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainManagement> DomainManagement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FromSenderDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MailFromSenderDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.EmailService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.UserEngagementTracking> UserEngagementTracking { get { throw null; } set { } }
        public Azure.Provisioning.Communication.DomainPropertiesVerificationRecords VerificationRecords { get { throw null; } }
        public Azure.Provisioning.Communication.DomainPropertiesVerificationStates VerificationStates { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.CommunicationDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_31;
            public static readonly string V2023_04_01;
            public static readonly string V2025_09_01;
        }
    }
    public enum CommunicationPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class CommunicationService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommunicationService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ImmutableResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LinkedDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NotificationHubId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.CommunicationServicesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.CommunicationPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.CommunicationService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.Communication.CommunicationServiceKeys GetKeys() { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_20;
            public static readonly string V2023_03_31;
            public static readonly string V2023_04_01;
            public static readonly string V2025_09_01;
        }
    }
    public partial class CommunicationServiceKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommunicationServiceKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CommunicationServiceProvisioningState
    {
        Unknown = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Running = 4,
        Creating = 5,
        Updating = 6,
        Deleting = 7,
        Moving = 8,
    }
    public enum CommunicationServicesProvisioningState
    {
        Unknown = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Running = 4,
        Creating = 5,
        Updating = 6,
        Deleting = 7,
        Moving = 8,
    }
    public partial class CommunicationSmtpUsername : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommunicationSmtpUsername(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> EntraApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.CommunicationService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.CommunicationSmtpUsername FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public enum DomainManagement
    {
        AzureManaged = 0,
        CustomerManaged = 1,
        CustomerManagedInExchangeOnline = 2,
    }
    public partial class DomainPropertiesVerificationRecords : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainPropertiesVerificationRecords() { }
        public Azure.Provisioning.Communication.VerificationDnsRecord Dkim { get { throw null; } }
        public Azure.Provisioning.Communication.VerificationDnsRecord Dkim2 { get { throw null; } }
        public Azure.Provisioning.Communication.VerificationDnsRecord Dmarc { get { throw null; } }
        public Azure.Provisioning.Communication.VerificationDnsRecord Domain { get { throw null; } }
        public Azure.Provisioning.Communication.VerificationDnsRecord Spf { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DomainPropertiesVerificationStates : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainPropertiesVerificationStates() { }
        public Azure.Provisioning.Communication.DomainVerificationStatusRecord Dkim { get { throw null; } }
        public Azure.Provisioning.Communication.DomainVerificationStatusRecord Dkim2 { get { throw null; } }
        public Azure.Provisioning.Communication.DomainVerificationStatusRecord Dmarc { get { throw null; } }
        public Azure.Provisioning.Communication.DomainVerificationStatusRecord Domain { get { throw null; } }
        public Azure.Provisioning.Communication.DomainVerificationStatusRecord Spf { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DomainProvisioningState
    {
        Unknown = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Running = 4,
        Creating = 5,
        Updating = 6,
        Deleting = 7,
        Moving = 8,
    }
    public enum DomainRecordVerificationStatus
    {
        NotStarted = 0,
        VerificationRequested = 1,
        VerificationInProgress = 2,
        VerificationFailed = 3,
        Verified = 4,
        CancellationRequested = 5,
    }
    public partial class DomainVerificationStatusRecord : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainVerificationStatusRecord() { }
        public Azure.Provisioning.BicepValue<string> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainRecordVerificationStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EmailService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EmailService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.EmailServicesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.EmailService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_31;
            public static readonly string V2023_04_01;
            public static readonly string V2025_09_01;
        }
    }
    public enum EmailServicesProvisioningState
    {
        Unknown = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Running = 4,
        Creating = 5,
        Updating = 6,
        Deleting = 7,
        Moving = 8,
    }
    public partial class EmailSuppressionList : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EmailSuppressionList(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ListName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.CommunicationDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.EmailSuppressionList FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class EmailSuppressionListAddress : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EmailSuppressionListAddress(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModified { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.Communication.EmailSuppressionList? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.EmailSuppressionListAddress FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class SenderUsername : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SenderUsername(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.CommunicationDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.CommunicationServiceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Communication.SenderUsername FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_31;
            public static readonly string V2023_04_01;
            public static readonly string V2025_09_01;
        }
    }
    public enum UserEngagementTracking
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class VerificationDnsRecord : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VerificationDnsRecord() { }
        public Azure.Provisioning.BicepValue<string> DnsRecordType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TimeToLiveInSeconds { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
