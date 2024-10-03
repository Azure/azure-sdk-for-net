namespace Azure.Provisioning.EventGrid
{
    public partial class AdvancedFilter : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AdvancedFilter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
    }
    public enum AlternativeAuthenticationNameSource
    {
        ClientCertificateSubject = 0,
        ClientCertificateDns = 1,
        ClientCertificateUri = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ClientCertificateIp")]
        ClientCertificateIP = 3,
        ClientCertificateEmail = 4,
    }
    public partial class AzureADPartnerClientAuthentication : Azure.Provisioning.EventGrid.PartnerClientAuthentication
    {
        public AzureADPartnerClientAuthentication() { }
        public Azure.Provisioning.BicepValue<System.Uri> AzureActiveDirectoryApplicationIdOrUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryTenantId { get { throw null; } set { } }
    }
    public partial class AzureFunctionEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public AzureFunctionEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxEventsPerBatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class BoolEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public BoolEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<bool> Value { get { throw null; } set { } }
    }
    public partial class BoolEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public BoolEqualsFilter() { }
        public Azure.Provisioning.BicepValue<bool> Value { get { throw null; } set { } }
    }
    public partial class CaCertificate : Azure.Provisioning.Primitives.Resource
    {
        public CaCertificate(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CaCertificateProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.CaCertificate FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum CaCertificateProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
    }
    public partial class ClientAuthenticationSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ClientAuthenticationSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.AlternativeAuthenticationNameSource> AlternativeAuthenticationNameSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomJwtAuthenticationSettings> CustomJwtAuthentication { get { throw null; } set { } }
    }
    public partial class ClientCertificateAuthentication : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ClientCertificateAuthentication() { }
        public Azure.Provisioning.BicepList<string> AllowedThumbprints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientCertificateValidationScheme> ValidationScheme { get { throw null; } set { } }
    }
    public enum ClientCertificateValidationScheme
    {
        SubjectMatchesAuthenticationName = 0,
        DnsMatchesAuthenticationName = 1,
        UriMatchesAuthenticationName = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpMatchesAuthenticationName")]
        IPMatchesAuthenticationName = 3,
        EmailMatchesAuthenticationName = 4,
        ThumbprintMatch = 5,
    }
    public enum ClientGroupProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
    }
    public partial class CustomDomainConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CustomDomainConfiguration() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExpectedTxtRecordName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExpectedTxtRecordValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomDomainIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomDomainValidationState> ValidationState { get { throw null; } set { } }
    }
    public partial class CustomDomainIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CustomDomainIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomDomainIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum CustomDomainIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public enum CustomDomainValidationState
    {
        Pending = 0,
        Approved = 1,
        ErrorRetrievingDnsRecord = 2,
    }
    public partial class CustomJwtAuthenticationManagedIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CustomJwtAuthenticationManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomJwtAuthenticationManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum CustomJwtAuthenticationManagedIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public partial class CustomJwtAuthenticationSettings : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CustomJwtAuthenticationSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.IssuerCertificateInfo> IssuerCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenIssuer { get { throw null; } set { } }
    }
    public enum DataResidencyBoundary
    {
        WithinGeopair = 0,
        WithinRegion = 1,
    }
    public partial class DeadLetterDestination : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DeadLetterDestination() { }
    }
    public partial class DeadLetterWithResourceIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DeadLetterWithResourceIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionIdentity> Identity { get { throw null; } set { } }
    }
    public partial class DeliveryAttributeMapping : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DeliveryAttributeMapping() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class DeliveryConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DeliveryConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryMode> DeliveryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PushInfo> Push { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.QueueInfo> Queue { get { throw null; } set { } }
    }
    public enum DeliveryMode
    {
        Queue = 0,
        Push = 1,
    }
    public enum DeliverySchema
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CloudEventSchemaV1_0")]
        CloudEventSchemaV10 = 0,
    }
    public partial class DeliveryWithResourceIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DeliveryWithResourceIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionIdentity> Identity { get { throw null; } set { } }
    }
    public partial class DomainEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public DomainEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.DomainEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class DomainTopic : Azure.Provisioning.Primitives.Resource
    {
        public DomainTopic(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DomainTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.DomainTopic FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class DomainTopicEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public DomainTopicEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DomainTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.DomainTopicEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum DomainTopicProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class DynamicDeliveryAttributeMapping : Azure.Provisioning.EventGrid.DeliveryAttributeMapping
    {
        public DynamicDeliveryAttributeMapping() { }
        public Azure.Provisioning.BicepValue<string> SourceField { get { throw null; } set { } }
    }
    public partial class DynamicRoutingEnrichment : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DynamicRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public enum EventDefinitionKind
    {
        Inline = 0,
    }
    public enum EventDeliverySchema
    {
        CloudEventSchemaV1_0 = 0,
        EventGridSchema = 1,
        CustomInputSchema = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridBuiltInRole : System.IEquatable<Azure.Provisioning.EventGrid.EventGridBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.EventGrid.EventGridBuiltInRole EventGridContributor { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridBuiltInRole EventGridDataSender { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridBuiltInRole EventGridEventSubscriptionContributor { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridBuiltInRole EventGridEventSubscriptionReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.EventGrid.EventGridBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.EventGrid.EventGridBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.EventGrid.EventGridBuiltInRole left, Azure.Provisioning.EventGrid.EventGridBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.EventGrid.EventGridBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.EventGrid.EventGridBuiltInRole left, Azure.Provisioning.EventGrid.EventGridBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridDomain : Azure.Provisioning.Primitives.Resource
    {
        public EventGridDomain(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DataResidencyBoundary> DataResidencyBoundary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo> EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchemaMapping> InputSchemaMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridDomainProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSku> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.EventGridDomain FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventGridDomainPrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public EventGridDomainPrivateEndpointConnection(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum EventGridDomainProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class EventGridFilter : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridFilter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
    }
    public partial class EventGridInboundIPRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridInboundIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridIPActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
    }
    public enum EventGridInputSchema
    {
        CloudEventSchemaV1_0 = 0,
        EventGridSchema = 1,
        CustomEventSchema = 2,
    }
    public partial class EventGridInputSchemaMapping : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridInputSchemaMapping() { }
    }
    public enum EventGridIPActionType
    {
        Allow = 0,
    }
    public partial class EventGridJsonInputSchemaMapping : Azure.Provisioning.EventGrid.EventGridInputSchemaMapping
    {
        public EventGridJsonInputSchemaMapping() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.JsonFieldWithDefault> DataVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventTimeSourceField { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.JsonFieldWithDefault> EventType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IdSourceField { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.JsonFieldWithDefault> Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicSourceField { get { throw null; } set { } }
    }
    public partial class EventGridNamespace : Azure.Provisioning.Primitives.Resource
    {
        public EventGridNamespace(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.NamespaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.NamespaceSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicsConfiguration> TopicsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicSpacesConfiguration> TopicSpacesConfiguration { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.EventGridNamespace FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventGridNamespaceClientGroup : Azure.Provisioning.Primitives.Resource
    {
        public EventGridNamespaceClientGroup(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientGroupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridNamespaceClientGroup FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum EventGridNamespaceClientProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
    }
    public partial class EventGridNamespaceClientResource : Azure.Provisioning.Primitives.Resource
    {
        public EventGridNamespaceClientResource(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Attributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthenticationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientCertificateAuthentication> ClientCertificateAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridNamespaceClientProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridNamespaceClientState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridNamespaceClientResource FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum EventGridNamespaceClientState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class EventGridNamespacePermissionBinding : Azure.Provisioning.Primitives.Resource
    {
        public EventGridNamespacePermissionBinding(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ClientGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PermissionType> Permission { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PermissionBindingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TopicSpaceName { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.EventGridNamespacePermissionBinding FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventGridPartnerContent : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridPartnerContent() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AuthorizationExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public EventGridPartnerNamespacePrivateEndpointConnection(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridPartnerNamespacePrivateEndpointConnection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventGridPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridPrivateEndpointConnectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class EventGridPrivateEndpointConnectionState : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventGridPrivateEndpointConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointPersistedConnectionStatus> Status { get { throw null; } set { } }
    }
    public enum EventGridPrivateEndpointPersistedConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum EventGridPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum EventGridResourceProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum EventGridSku
    {
        Basic = 0,
        Premium = 1,
    }
    public enum EventGridSkuName
    {
        Standard = 0,
    }
    public partial class EventGridTopic : Azure.Provisioning.Primitives.Resource
    {
        public EventGridTopic(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DataResidencyBoundary> DataResidencyBoundary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo> EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ExtendedAzureLocation> ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchemaMapping> InputSchemaMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSku> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.EventGridTopic FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventGridTopicPrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public EventGridTopicPrivateEndpointConnection(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventGridTopicPrivateEndpointConnection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum EventGridTopicProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class EventHubEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public EventHubEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public enum EventInputSchema
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CloudEventSchemaV1_0")]
        CloudEventSchemaV10 = 0,
    }
    public partial class EventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public EventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.EventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class EventSubscriptionDestination : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventSubscriptionDestination() { }
    }
    public partial class EventSubscriptionFilter : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventSubscriptionFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.AdvancedFilter> AdvancedFilters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedEventTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAdvancedFilteringOnArraysEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSubjectCaseSensitive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectBeginsWith { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectEndsWith { get { throw null; } set { } }
    }
    public partial class EventSubscriptionIdentity : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventSubscriptionIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum EventSubscriptionIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public enum EventSubscriptionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        AwaitingManualAction = 6,
    }
    public partial class EventSubscriptionRetryPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public EventSubscriptionRetryPolicy() { }
        public Azure.Provisioning.BicepValue<int> EventTimeToLiveInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryAttempts { get { throw null; } set { } }
    }
    public partial class FiltersConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public FiltersConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridFilter> Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedEventTypes { get { throw null; } set { } }
    }
    public partial class HybridConnectionEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public HybridConnectionEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class InlineEventProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public InlineEventProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> DataSchemaUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DocumentationUri { get { throw null; } set { } }
    }
    public partial class IsNotNullAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public IsNotNullAdvancedFilter() { }
    }
    public partial class IsNotNullFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public IsNotNullFilter() { }
    }
    public partial class IsNullOrUndefinedAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public IsNullOrUndefinedAdvancedFilter() { }
    }
    public partial class IsNullOrUndefinedFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public IsNullOrUndefinedFilter() { }
    }
    public partial class IssuerCertificateInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public IssuerCertificateInfo() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomJwtAuthenticationManagedIdentity> Identity { get { throw null; } set { } }
    }
    public partial class JsonFieldWithDefault : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public JsonFieldWithDefault() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceField { get { throw null; } set { } }
    }
    public partial class MonitorAlertEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public MonitorAlertEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.MonitorAlertSeverity> Severity { get { throw null; } set { } }
    }
    public enum MonitorAlertSeverity
    {
        Sev0 = 0,
        Sev1 = 1,
        Sev2 = 2,
        Sev3 = 3,
        Sev4 = 4,
    }
    public enum NamespaceProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
        DeleteFailed = 7,
        CreateFailed = 8,
        UpdatedFailed = 9,
    }
    public partial class NamespaceSku : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public NamespaceSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSkuName> Name { get { throw null; } set { } }
    }
    public partial class NamespaceTopic : Azure.Provisioning.Primitives.Resource
    {
        public NamespaceTopic(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> EventRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.NamespaceTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PublisherType> PublisherType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.NamespaceTopic FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class NamespaceTopicEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public NamespaceTopicEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryConfiguration> DeliveryConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.FiltersConfiguration> FiltersConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.NamespaceTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.SubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.NamespaceTopicEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class NamespaceTopicEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public NamespaceTopicEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public enum NamespaceTopicProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
        DeleteFailed = 7,
        CreateFailed = 8,
        UpdatedFailed = 9,
    }
    public partial class NumberGreaterThanAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberGreaterThanAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberGreaterThanFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberGreaterThanFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberGreaterThanOrEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberGreaterThanOrEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberGreaterThanOrEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberGreaterThanOrEqualsFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
    }
    public partial class NumberInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberInFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
    }
    public partial class NumberInRangeAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberInRangeAdvancedFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
    }
    public partial class NumberInRangeFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberInRangeFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
    }
    public partial class NumberLessThanAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberLessThanAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberLessThanFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberLessThanFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberLessThanOrEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberLessThanOrEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberLessThanOrEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberLessThanOrEqualsFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
    }
    public partial class NumberNotInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberNotInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
    }
    public partial class NumberNotInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberNotInFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
    }
    public partial class NumberNotInRangeAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberNotInRangeAdvancedFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
    }
    public partial class NumberNotInRangeFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberNotInRangeFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
    }
    public partial class PartnerAuthorization : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PartnerAuthorization() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPartnerContent> AuthorizedPartnersList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
    }
    public partial class PartnerClientAuthentication : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PartnerClientAuthentication() { }
    }
    public partial class PartnerConfiguration : Azure.Provisioning.Primitives.Resource
    {
        public PartnerConfiguration(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerAuthorization> PartnerAuthorization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerConfigurationProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.PartnerConfiguration FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum PartnerConfigurationProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class PartnerDestination : Azure.Provisioning.Primitives.Resource
    {
        public PartnerDestination(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerDestinationActivationState> ActivationState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointBaseUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointServiceContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpirationTimeIfNotActivatedUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageForActivation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerDestinationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.PartnerDestination FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum PartnerDestinationActivationState
    {
        NeverActivated = 0,
        Activated = 1,
    }
    public partial class PartnerDestinationInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PartnerDestinationInfo() { }
        public Azure.Provisioning.BicepValue<string> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointServiceContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.ResourceMoveChangeHistory> ResourceMoveChangeHistory { get { throw null; } set { } }
    }
    public enum PartnerDestinationProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        IdleDueToMirroredChannelResourceDeletion = 6,
    }
    public partial class PartnerEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public PartnerEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } set { } }
    }
    public partial class PartnerNamespace : Azure.Provisioning.Primitives.Resource
    {
        public PartnerNamespace(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PartnerRegistrationFullyQualifiedId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicRoutingMode> PartnerTopicRoutingMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerNamespaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.PartnerNamespace FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class PartnerNamespaceChannel : Azure.Provisioning.Primitives.Resource
    {
        public PartnerNamespaceChannel(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerNamespaceChannelType> ChannelType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MessageForActivation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerDestinationInfo> PartnerDestinationInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicInfo> PartnerTopicInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerNamespaceChannelProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicReadinessState> ReadinessState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.EventGrid.PartnerNamespaceChannel FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum PartnerNamespaceChannelProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        IdleDueToMirroredPartnerTopicDeletion = 6,
        IdleDueToMirroredPartnerDestinationDeletion = 7,
    }
    public enum PartnerNamespaceChannelType
    {
        PartnerTopic = 0,
        PartnerDestination = 1,
    }
    public enum PartnerNamespaceProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class PartnerRegistration : Azure.Provisioning.Primitives.Resource
    {
        public PartnerRegistration(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerRegistrationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.PartnerRegistration FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum PartnerRegistrationProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class PartnerTopic : Azure.Provisioning.Primitives.Resource
    {
        public PartnerTopic(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicActivationState> ActivationState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo> EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageForActivation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerTopicFriendlyDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.PartnerTopic FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum PartnerTopicActivationState
    {
        NeverActivated = 0,
        Activated = 1,
        Deactivated = 2,
    }
    public partial class PartnerTopicEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public PartnerTopicEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.PartnerTopicEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class PartnerTopicEventTypeInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PartnerTopicEventTypeInfo() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.EventGrid.InlineEventProperties> InlineEventTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDefinitionKind> Kind { get { throw null; } set { } }
    }
    public partial class PartnerTopicInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PartnerTopicInfo() { }
        public Azure.Provisioning.BicepValue<System.Guid> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo> EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
    }
    public enum PartnerTopicProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        IdleDueToMirroredChannelResourceDeletion = 6,
    }
    public enum PartnerTopicReadinessState
    {
        NeverActivated = 0,
        Activated = 1,
    }
    public enum PartnerTopicRoutingMode
    {
        SourceEventAttribute = 0,
        ChannelNameHeader = 1,
    }
    public enum PermissionBindingProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
    }
    public enum PermissionType
    {
        Publisher = 0,
        Subscriber = 1,
    }
    public enum PublisherType
    {
        Custom = 0,
    }
    public partial class PushInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PushInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
    }
    public partial class QueueInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public QueueInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EventTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReceiveLockDurationInSeconds { get { throw null; } set { } }
    }
    public enum ResourceKind
    {
        Azure = 0,
        AzureArc = 1,
    }
    public partial class ResourceMoveChangeHistory : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceMoveChangeHistory() { }
        public Azure.Provisioning.BicepValue<string> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedTimeUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
    }
    public partial class RoutingEnrichments : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoutingEnrichments() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DynamicRoutingEnrichment> Dynamic { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.StaticRoutingEnrichment> Static { get { throw null; } set { } }
    }
    public partial class RoutingIdentityInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public RoutingIdentityInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.RoutingIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
    }
    public enum RoutingIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
    }
    public partial class ServiceBusQueueEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public ServiceBusQueueEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class ServiceBusTopicEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public ServiceBusTopicEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class StaticDeliveryAttributeMapping : Azure.Provisioning.EventGrid.DeliveryAttributeMapping
    {
        public StaticDeliveryAttributeMapping() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public partial class StaticRoutingEnrichment : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public StaticRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
    }
    public partial class StaticStringRoutingEnrichment : Azure.Provisioning.EventGrid.StaticRoutingEnrichment
    {
        public StaticStringRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public partial class StorageBlobDeadLetterDestination : Azure.Provisioning.EventGrid.DeadLetterDestination
    {
        public StorageBlobDeadLetterDestination() { }
        public Azure.Provisioning.BicepValue<string> BlobContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class StorageQueueEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public StorageQueueEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<long> QueueMessageTimeToLiveInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueueName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
    }
    public partial class StringBeginsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringBeginsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringBeginsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringBeginsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringContainsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringContainsAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringContainsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringContainsFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringEndsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringEndsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringEndsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringEndsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringInFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotBeginsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotBeginsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotBeginsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotBeginsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotContainsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotContainsAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotContainsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotContainsFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotEndsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotEndsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotEndsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotEndsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public partial class StringNotInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotInFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
    }
    public enum SubscriptionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        AwaitingManualAction = 6,
        Deleted = 7,
        DeleteFailed = 8,
        CreateFailed = 9,
        UpdatedFailed = 10,
    }
    public partial class SystemTopic : Azure.Provisioning.Primitives.Resource
    {
        public SystemTopic(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicType { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.SystemTopic FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class SystemTopicEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public SystemTopicEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.SystemTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.SystemTopicEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum TlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        One0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        One1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        One2 = 2,
    }
    public partial class TopicEventSubscription : Azure.Provisioning.Primitives.Resource
    {
        public TopicEventSubscription(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterDestination> DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity> DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity> DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionDestination> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionFilter> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy> RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        public static Azure.Provisioning.EventGrid.TopicEventSubscription FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2024_06_01_preview;
        }
    }
    public partial class TopicsConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public TopicsConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.CustomDomainConfiguration> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } }
    }
    public partial class TopicSpace : Azure.Provisioning.Primitives.Resource
    {
        public TopicSpace(string resourceName, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicSpaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TopicTemplates { get { throw null; } set { } }
        public static Azure.Provisioning.EventGrid.TopicSpace FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_preview;
        }
    }
    public enum TopicSpaceProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
        Deleted = 6,
    }
    public partial class TopicSpacesConfiguration : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public TopicSpacesConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientAuthenticationSettings> ClientAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.CustomDomainConfiguration> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MaximumClientSessionsPerAuthenticationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumSessionExpiryInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RouteTopicResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.RoutingEnrichments> RoutingEnrichments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.RoutingIdentityInfo> RoutingIdentityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicSpacesConfigurationState> State { get { throw null; } set { } }
    }
    public enum TopicSpacesConfigurationState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class WebHookEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public WebHookEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<System.Guid> AzureActiveDirectoryTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> BaseEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxEventsPerBatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UriOrAzureActiveDirectoryApplicationId { get { throw null; } set { } }
    }
    public partial class WebhookPartnerDestinationInfo : Azure.Provisioning.EventGrid.PartnerDestinationInfo
    {
        public WebhookPartnerDestinationInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerClientAuthentication> ClientAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointBaseUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } set { } }
    }
}
