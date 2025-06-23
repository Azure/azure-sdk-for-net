namespace Azure.Provisioning.EventGrid
{
    public partial class AdvancedFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdvancedFilter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum AlternativeAuthenticationNameSource
    {
        ClientCertificateSubject = 0,
        ClientCertificateDns = 1,
        ClientCertificateUri = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ClientCertificateIp")]
        ClientCertificateIP = 3,
        ClientCertificateEmail = 4,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AzureADPartnerClientAuthentication : Azure.Provisioning.EventGrid.PartnerClientAuthentication
    {
        public AzureADPartnerClientAuthentication() { }
        public Azure.Provisioning.BicepValue<System.Uri> AzureActiveDirectoryApplicationIdOrUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryTenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFunctionEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public AzureFunctionEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxEventsPerBatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BoolEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public BoolEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<bool> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BoolEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public BoolEqualsFilter() { }
        public Azure.Provisioning.BicepValue<bool> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CaCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CaCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CaCertificateProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.CaCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ClientAuthenticationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClientAuthenticationSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.AlternativeAuthenticationNameSource> AlternativeAuthenticationNameSources { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.CustomJwtAuthenticationSettings CustomJwtAuthentication { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClientCertificateAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClientCertificateAuthentication() { }
        public Azure.Provisioning.BicepList<string> AllowedThumbprints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientCertificateValidationScheme> ValidationScheme { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class CustomDomainConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDomainConfiguration() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExpectedTxtRecordName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExpectedTxtRecordValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.CustomDomainIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomDomainValidationState> ValidationState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomDomainIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDomainIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomDomainIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomJwtAuthenticationManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomJwtAuthenticationManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.CustomJwtAuthenticationManagedIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum CustomJwtAuthenticationManagedIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomJwtAuthenticationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomJwtAuthenticationSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.IssuerCertificateInfo> IssuerCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenIssuer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataResidencyBoundary
    {
        WithinGeopair = 0,
        WithinRegion = 1,
    }
    public partial class DeadLetterDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeadLetterDestination() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeadLetterWithResourceIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeadLetterWithResourceIdentity() { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionIdentity Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryAttributeMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryAttributeMapping() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliveryMode> DeliveryMode { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PushInfo Push { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.QueueInfo Queue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class DeliveryWithResourceIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryWithResourceIdentity() { }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionIdentity Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DomainEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DomainEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.DomainEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class DomainTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DomainTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DomainTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.DomainTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class DomainTopicEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DomainTopicEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DomainTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.DomainTopicEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicRoutingEnrichment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DynamicRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class EventGridDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridDomain(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DataResidencyBoundary> DataResidencyBoundary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } }
        public Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridDomainProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSku> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventGridDomainPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridDomainPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
    public partial class EventGridFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridFilter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventGridInboundIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridInboundIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridIPActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPMask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventGridInputSchema
    {
        CloudEventSchemaV1_0 = 0,
        EventGridSchema = 1,
        CustomEventSchema = 2,
    }
    public partial class EventGridInputSchemaMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridInputSchemaMapping() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventGridIPActionType
    {
        Allow = 0,
    }
    public partial class EventGridJsonInputSchemaMapping : Azure.Provisioning.EventGrid.EventGridInputSchemaMapping
    {
        public EventGridJsonInputSchemaMapping() { }
        public Azure.Provisioning.EventGrid.JsonFieldWithDefault DataVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventTimeSourceField { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.JsonFieldWithDefault EventType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IdSourceField { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.JsonFieldWithDefault Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicSourceField { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventGridNamespace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridNamespace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.NamespaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.NamespaceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.TopicsConfiguration TopicsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.TopicSpacesConfiguration TopicSpacesConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridNamespace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventGridNamespaceClientGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridNamespaceClientGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ClientGroupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridNamespaceClientGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
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
    public partial class EventGridNamespaceClientResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridNamespaceClientResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Attributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthenticationName { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.ClientCertificateAuthentication ClientCertificateAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridNamespaceClientProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridNamespaceClientState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridNamespaceClientResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
        }
    }
    public enum EventGridNamespaceClientState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class EventGridNamespacePermissionBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridNamespacePermissionBinding(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ClientGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PermissionType> Permission { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PermissionBindingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TopicSpaceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridNamespacePermissionBinding FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventGridPartnerContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridPartnerContent() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AuthorizationExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridPartnerNamespacePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridPartnerNamespacePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventGridPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridPrivateEndpointConnectionData() { }
        public Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventGridPrivateEndpointConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridPrivateEndpointConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPrivateEndpointPersistedConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum EventGridSku
    {
        Basic = 0,
        Premium = 1,
    }
    public enum EventGridSkuName
    {
        Standard = 0,
    }
    public partial class EventGridTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DataResidencyBoundary> DataResidencyBoundary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } }
        public Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridInboundIPRule> InboundIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.ResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TlsVersion> MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSku> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventGridTopicPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventGridTopicPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventGridTopicPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
        protected override void DefineProvisionableProperties() { }
    }
    public enum EventInputSchema
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CloudEventSchemaV1_0")]
        CloudEventSchemaV10 = 0,
    }
    public partial class EventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.EventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
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
            public static readonly string V2025_02_15;
        }
    }
    public partial class EventSubscriptionDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventSubscriptionDestination() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventSubscriptionFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventSubscriptionFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.AdvancedFilter> AdvancedFilters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedEventTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAdvancedFilteringOnArraysEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSubjectCaseSensitive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectBeginsWith { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectEndsWith { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventSubscriptionIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventSubscriptionIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class EventSubscriptionRetryPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventSubscriptionRetryPolicy() { }
        public Azure.Provisioning.BicepValue<int> EventTimeToLiveInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryAttempts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FiltersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FiltersConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridFilter> Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedEventTypes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HybridConnectionEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public HybridConnectionEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InlineEventProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InlineEventProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> DataSchemaUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DocumentationUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IsNotNullAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public IsNotNullAdvancedFilter() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IsNotNullFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public IsNotNullFilter() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IsNullOrUndefinedAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public IsNullOrUndefinedAdvancedFilter() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IsNullOrUndefinedFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public IsNullOrUndefinedFilter() { }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class IssuerCertificateInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IssuerCertificateInfo() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.CustomJwtAuthenticationManagedIdentity Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonFieldWithDefault : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JsonFieldWithDefault() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceField { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorAlertEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public MonitorAlertEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.MonitorAlertSeverity> Severity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class NamespaceSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NamespaceSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NamespaceTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NamespaceTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> EventRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventInputSchema> InputSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.NamespaceTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PublisherType> PublisherType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.NamespaceTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
        }
    }
    public partial class NamespaceTopicEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NamespaceTopicEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeliveryConfiguration DeliveryConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.DeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.FiltersConfiguration FiltersConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.NamespaceTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.SubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.NamespaceTopicEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
        }
    }
    public partial class NamespaceTopicEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public NamespaceTopicEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberGreaterThanFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberGreaterThanFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberGreaterThanOrEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberGreaterThanOrEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberGreaterThanOrEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberGreaterThanOrEqualsFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberInFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberInRangeAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberInRangeAdvancedFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberInRangeFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberInRangeFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberLessThanAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberLessThanAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberLessThanFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberLessThanFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberLessThanOrEqualsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberLessThanOrEqualsAdvancedFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberLessThanOrEqualsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberLessThanOrEqualsFilter() { }
        public Azure.Provisioning.BicepValue<double> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberNotInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberNotInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberNotInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberNotInFilter() { }
        public Azure.Provisioning.BicepList<double> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberNotInRangeAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public NumberNotInRangeAdvancedFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NumberNotInRangeFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public NumberNotInRangeFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<double>> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartnerAuthorization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerAuthorization() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPartnerContent> AuthorizedPartnersList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartnerClientAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerClientAuthentication() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartnerConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.EventGrid.PartnerAuthorization PartnerAuthorization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerConfigurationProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartnerDestination : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerDestination(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerDestination FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum PartnerDestinationActivationState
    {
        NeverActivated = 0,
        Activated = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartnerDestinationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerDestinationInfo() { }
        public Azure.Provisioning.BicepValue<string> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointServiceContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.ResourceMoveChangeHistory> ResourceMoveChangeHistory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PartnerEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public PartnerEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartnerNamespace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerNamespace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerNamespace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class PartnerNamespaceChannel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerNamespaceChannel(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerNamespaceChannelType> ChannelType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MessageForActivation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerNamespace? Parent { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.EventGrid.PartnerDestinationInfo PartnerDestinationInfo { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerTopicInfo PartnerTopicInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerNamespaceChannelProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicReadinessState> ReadinessState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerNamespaceChannel FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        IdleDueToMirroredPartnerDestinationDeletion = 7,
    }
    public enum PartnerNamespaceChannelType
    {
        PartnerTopic = 0,
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    public partial class PartnerRegistration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerRegistration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerRegistrationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerRegistration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
    public partial class PartnerTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicActivationState> ActivationState { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageForActivation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerTopicFriendlyDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.PartnerTopicProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public enum PartnerTopicActivationState
    {
        NeverActivated = 0,
        Activated = 1,
        Deactivated = 2,
    }
    public partial class PartnerTopicEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PartnerTopicEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.PartnerTopicEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class PartnerTopicEventTypeInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerTopicEventTypeInfo() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.EventGrid.InlineEventProperties> InlineEventTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDefinitionKind> Kind { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartnerTopicInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerTopicInfo() { }
        public Azure.Provisioning.BicepValue<System.Guid> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class PushInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PushInfo() { }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueueInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueueInfo() { }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EventTimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxDeliveryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReceiveLockDurationInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ResourceKind
    {
        Azure = 0,
        AzureArc = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ResourceMoveChangeHistory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceMoveChangeHistory() { }
        public Azure.Provisioning.BicepValue<string> AzureSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ChangedTimeUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingEnrichments : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingEnrichments() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DynamicRoutingEnrichment> Dynamic { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.StaticRoutingEnrichment> Static { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingIdentityInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingIdentityInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.RoutingIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceBusTopicEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public ServiceBusTopicEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticDeliveryAttributeMapping : Azure.Provisioning.EventGrid.DeliveryAttributeMapping
    {
        public StaticDeliveryAttributeMapping() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticRoutingEnrichment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticStringRoutingEnrichment : Azure.Provisioning.EventGrid.StaticRoutingEnrichment
    {
        public StaticStringRoutingEnrichment() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageBlobDeadLetterDestination : Azure.Provisioning.EventGrid.DeadLetterDestination
    {
        public StorageBlobDeadLetterDestination() { }
        public Azure.Provisioning.BicepValue<string> BlobContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageQueueEventSubscriptionDestination : Azure.Provisioning.EventGrid.EventSubscriptionDestination
    {
        public StorageQueueEventSubscriptionDestination() { }
        public Azure.Provisioning.BicepValue<long> QueueMessageTimeToLiveInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueueName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringBeginsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringBeginsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringBeginsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringBeginsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringContainsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringContainsAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringContainsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringContainsFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringEndsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringEndsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringEndsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringEndsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringInFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotBeginsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotBeginsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotBeginsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotBeginsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotContainsAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotContainsAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotContainsFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotContainsFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotEndsWithAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotEndsWithAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotEndsWithFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotEndsWithFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotInAdvancedFilter : Azure.Provisioning.EventGrid.AdvancedFilter
    {
        public StringNotInAdvancedFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StringNotInFilter : Azure.Provisioning.EventGrid.EventGridFilter
    {
        public StringNotInFilter() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class SystemTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SystemTopic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> MetricResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventGridResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.SystemTopic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class SystemTopicEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SystemTopicEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.SystemTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.SystemTopicEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
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
    public partial class TopicEventSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TopicEventSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.EventGrid.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventDeliverySchema> EventDeliverySchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridTopic? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.EventSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.EventGrid.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Topic { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.TopicEventSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_06_01;
            public static readonly string V2020_06_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_06_15;
            public static readonly string V2025_02_15;
        }
    }
    public partial class TopicsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TopicsConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.CustomDomainConfiguration> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TopicSpace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TopicSpace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.EventGridNamespace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicSpaceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TopicTemplates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.EventGrid.TopicSpace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_15;
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
    public partial class TopicSpacesConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TopicSpacesConfiguration() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.EventGrid.ClientAuthenticationSettings ClientAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.CustomDomainConfiguration> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MaximumClientSessionsPerAuthenticationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumSessionExpiryInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RouteTopicResourceId { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.RoutingEnrichments RoutingEnrichments { get { throw null; } set { } }
        public Azure.Provisioning.EventGrid.RoutingIdentityInfo RoutingIdentityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.EventGrid.TopicSpacesConfigurationState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class WebhookPartnerDestinationInfo : Azure.Provisioning.EventGrid.PartnerDestinationInfo
    {
        public WebhookPartnerDestinationInfo() { }
        public Azure.Provisioning.EventGrid.PartnerClientAuthentication ClientAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointBaseUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
