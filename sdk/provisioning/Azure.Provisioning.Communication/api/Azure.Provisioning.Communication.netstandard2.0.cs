namespace Azure.Provisioning.Communication
{
    public partial class CommunicationDomain : Azure.Provisioning.Primitives.Resource
    {
        public CommunicationDomain(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainManagement> DomainManagement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FromSenderDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MailFromSenderDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.EmailService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.UserEngagementTracking> UserEngagementTracking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainPropertiesVerificationRecords> VerificationRecords { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainPropertiesVerificationStates> VerificationStates { get { throw null; } }
        public static Azure.Provisioning.Communication.CommunicationDomain FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CommunicationService : Azure.Provisioning.Primitives.Resource
    {
        public CommunicationService(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ImmutableResourceId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> LinkedDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NotificationHubId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.CommunicationServicesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        public static Azure.Provisioning.Communication.CommunicationService FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.Communication.CommunicationServiceKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
    }
    public partial class CommunicationServiceKeys : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CommunicationServiceKeys() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> PrimaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.Communication.CommunicationServiceKeys FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
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
    public enum DomainManagement
    {
        AzureManaged = 0,
        CustomerManaged = 1,
        CustomerManagedInExchangeOnline = 2,
    }
    public partial class DomainPropertiesVerificationRecords : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DomainPropertiesVerificationRecords() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.VerificationDnsRecord> Dkim { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.VerificationDnsRecord> Dkim2 { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.VerificationDnsRecord> Dmarc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.VerificationDnsRecord> Domain { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.VerificationDnsRecord> Spf { get { throw null; } }
    }
    public partial class DomainPropertiesVerificationStates : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DomainPropertiesVerificationStates() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainVerificationStatusRecord> Dkim { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainVerificationStatusRecord> Dkim2 { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainVerificationStatusRecord> Dmarc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainVerificationStatusRecord> Domain { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainVerificationStatusRecord> Spf { get { throw null; } }
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
    public partial class DomainVerificationStatusRecord : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DomainVerificationStatusRecord() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.DomainRecordVerificationStatus> Status { get { throw null; } }
    }
    public partial class EmailService : Azure.Provisioning.Primitives.Resource
    {
        public EmailService(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.EmailServicesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.Communication.EmailService FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
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
    public partial class SenderUsername : Azure.Provisioning.Primitives.Resource
    {
        public SenderUsername(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DataLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Communication.CommunicationDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Communication.CommunicationServiceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public static Azure.Provisioning.Communication.SenderUsername FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum UserEngagementTracking
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class VerificationDnsRecord : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public VerificationDnsRecord() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DnsRecordType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TimeToLiveInSeconds { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
    }
}
