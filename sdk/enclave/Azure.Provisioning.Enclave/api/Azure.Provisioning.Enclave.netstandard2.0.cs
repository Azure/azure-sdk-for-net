namespace Azure.Provisioning.Enclave
{
    public partial class ApprovalRequestMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApprovalRequestMetadata() { }
        public Azure.Provisioning.BicepValue<string> ApprovalCallbackPayload { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveApprovalStatus> ApprovalStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApprovalSettingConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApprovalSettingConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveApprovalPolicy> ApprovalPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumApproversRequired { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApproverActionPerformed
    {
        Approved = 0,
        Rejected = 1,
    }
    public enum CommunityPropertiesPolicyOverride
    {
        Enclave = 0,
        None = 1,
    }
    public partial class EnclaveAddressSpaces : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnclaveAddressSpaces() { }
        public Azure.Provisioning.BicepValue<string> EnclaveAddressSpace { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedAddressSpace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnclaveConnectionState
    {
        PendingApproval = 0,
        PendingUpdate = 1,
        Approved = 2,
        Active = 3,
        Failed = 4,
        Connected = 5,
        Disconnected = 6,
    }
    public partial class EnclaveDefaultSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnclaveDefaultSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveDiagnosticDestination> DiagnosticDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultResourceId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> LogAnalyticsResourceIdCollection { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EnclaveEndpointDestinationRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnclaveEndpointDestinationRule() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Ports { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.EnclaveEndpointProtocol> Protocols { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnclaveEndpointProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ANY")]
        Any = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ESP")]
        Esp = 4,
        AH = 5,
    }
    public partial class EnclaveVirtualNetwork : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnclaveVirtualNetwork() { }
        public Azure.Provisioning.BicepValue<bool> AllowSubnetCommunication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomCidrRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetworkName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetworkSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveSubnetConfiguration> SubnetConfigurations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclave : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclave(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclave FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveApproval : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveApproval(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveApprovalProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveApproval FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public enum VirtualEnclaveApprovalPolicy
    {
        Required = 0,
        NotRequired = 1,
    }
    public partial class VirtualEnclaveApprovalProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveApprovalProperties() { }
        public Azure.Provisioning.BicepList<string> ApprovedByEntraIds { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveApprover> Approvers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ApproversApprovedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GrandparentResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MandatoryApproversApprovedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinimumApproversRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ParentResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Enclave.ApprovalRequestMetadata RequestMetadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StateChangedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveApprovalSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveApprovalSettings() { }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveApprovalStatus
    {
        Approved = 0,
        Rejected = 1,
        Pending = 2,
        Deleted = 3,
        Expired = 4,
    }
    public partial class VirtualEnclaveApprover : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveApprover() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.ApproverActionPerformed> ActionPerformed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApproverEntraId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MandatoryApprovalGroupMembershipIds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveBaseApprovalSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveBaseApprovalSettings() { }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration CommunityEndpointUpdate { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration CommunityMaintenanceMode { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration EnclaveCreation { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveCommunity : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveCommunity(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveCommunityProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveCommunity FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveCommunityEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveCommunityEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveCommunity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveCommunityEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveCommunityEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveCommunityEndpointDestinationRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveCommunityEndpointDestinationRule() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveCommunityEndpointDestinationType> DestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Ports { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveCommunityEndpointProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TransitHubResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveCommunityEndpointDestinationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="FQDN")]
        Fqdn = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FQDNTag")]
        FqdnTag = 1,
        IPAddress = 2,
        PrivateNetwork = 3,
        ServiceTag = 4,
    }
    public partial class VirtualEnclaveCommunityEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveCommunityEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveCommunityEndpointDestinationRule> RuleCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveUpdateMode> UpdateMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveCommunityEndpointProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ANY")]
        Any = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ESP")]
        Esp = 4,
        AH = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTPS")]
        Https = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 7,
    }
    public partial class VirtualEnclaveCommunityProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveCommunityProperties() { }
        public Azure.Provisioning.BicepValue<string> AddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AddressSpaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveDedicatedHub> DedicatedHubList { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveFirewallSku> FirewallSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveBaseApprovalSettings GranularApprovalSettings { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedResourceGroupName { get { throw null; } }
        public Azure.Provisioning.Enclave.VirtualEnclaveMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.CommunityPropertiesPolicyOverride> PolicyOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CommunityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DestinationEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.EnclaveConnectionState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveUpdateMode> UpdateMode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveDedicatedHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveDedicatedHub(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveCommunity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveDedicatedHubProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveDedicatedHub FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveDedicatedHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveDedicatedHubProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveDesignation> Designation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallPolicyResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VHubResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveDesignation
    {
        Pooled = 0,
        Reserved = 1,
    }
    public enum VirtualEnclaveDiagnosticDestination
    {
        CommunityOnly = 0,
        EnclaveOnly = 1,
        Both = 2,
    }
    public partial class VirtualEnclaveEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclave Parent { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveUpdateMode> UpdateMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveFirewallSku
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public partial class VirtualEnclaveGovernedService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveGovernedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveGovernedServiceItemEnforcement> Enforcement { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Initiatives { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveGovernedServiceItemOption> Option { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveGovernedServiceItemPolicyAction> PolicyAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveGovernedServiceIdentifier> ServiceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveGovernedServiceIdentifier
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AKS")]
        Aks = 0,
        AppService = 1,
        AzureFirewalls = 2,
        ContainerRegistry = 3,
        CosmosDB = 4,
        DataConnectors = 5,
        Insights = 6,
        KeyVault = 7,
        Logic = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MicrosoftSQL")]
        MicrosoftSql = 9,
        Monitoring = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PostgreSQL")]
        PostgreSql = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PrivateDNSZones")]
        PrivateDnsZones = 12,
        ServiceBus = 13,
        Storage = 14,
    }
    public enum VirtualEnclaveGovernedServiceItemEnforcement
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum VirtualEnclaveGovernedServiceItemOption
    {
        Allow = 0,
        Deny = 1,
        ExceptionOnly = 2,
        NotApplicable = 3,
    }
    public enum VirtualEnclaveGovernedServiceItemPolicyAction
    {
        AuditOnly = 0,
        Enforce = 1,
        None = 2,
    }
    public partial class VirtualEnclaveMaintenanceModeConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveMaintenanceModeConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveMaintenanceModeJustification> Justification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveMaintenanceModeConfigurationMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclavePrincipal> Principals { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveMaintenanceModeConfigurationMode
    {
        On = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CanNotDelete")]
        CannotDelete = 1,
        Off = 2,
        General = 3,
        Advanced = 4,
    }
    public enum VirtualEnclaveMaintenanceModeJustification
    {
        Networking = 0,
        Governance = 1,
        Off = 2,
    }
    public partial class VirtualEnclaveManagedOnBehalfOfBroker : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveManagedOnBehalfOfBroker() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveMandatoryApprover : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveMandatoryApprover() { }
        public Azure.Provisioning.BicepValue<string> ApproverEntraId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveMonitoringDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveMonitoringDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveMonitoringDestinationType> DestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DiagnosticSettingsName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveMonitoringDestinationType
    {
        CommunityWorkspace = 0,
        EnclaveWorkspace = 1,
        CustomWorkspace = 2,
    }
    public partial class VirtualEnclaveMonitoringSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveMonitoringSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveMonitoringDestination> DiagnosticDestinations { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveMonitoringDestination FlowLogDestination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclavePrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclavePrincipal() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclavePrincipalType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclavePrincipalType
    {
        User = 0,
        Group = 1,
        ServicePrincipal = 2,
    }
    public partial class VirtualEnclaveProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveProperties() { }
        public Azure.Provisioning.Enclave.VirtualEnclaveApprovalSettings ApprovalSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CommunityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DedicatedHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.EnclaveAddressSpaces EnclaveAddressSpaces { get { throw null; } }
        public Azure.Provisioning.Enclave.EnclaveDefaultSettings EnclaveDefaultSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBastionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedResourceGroupName { get { throw null; } }
        public Azure.Provisioning.Enclave.VirtualEnclaveMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveRbacInheritanceMode> RbacInheritance { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveResourceVisibilityMode> WorkloadResourceVisibility { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Accepted = 3,
        Creating = 4,
        Deleting = 5,
        NotSpecified = 6,
        Running = 7,
        Updating = 8,
    }
    public enum VirtualEnclaveRbacInheritanceMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum VirtualEnclaveResourceVisibilityMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class VirtualEnclaveRoleAssignmentItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveRoleAssignmentItem() { }
        public Azure.Provisioning.BicepValue<string> Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclavePrincipal> Principals { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleDefinitionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveSecurityProvider
    {
        None = 0,
        AzureFirewall = 1,
    }
    public partial class VirtualEnclaveSubnetConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveSubnetConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NetworkPrefixSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkSecurityGroupResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubnetDelegation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveTransitHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveTransitHub(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveCommunity Parent { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveTransitHubProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveTransitHub FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveTransitHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveTransitHubProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveSecurityProvider> SecurityProvider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveTransitHubState> State { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveTransitHubState
    {
        PendingApproval = 0,
        Approved = 1,
        PendingUpdate = 2,
        Active = 3,
        Failed = 4,
    }
    public partial class VirtualEnclaveTransitOptionContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveTransitOptionContent() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ScaleUnits { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEnclaveTransitOptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveTransitOptionProperties() { }
        public Azure.Provisioning.Enclave.VirtualEnclaveTransitOptionContent Params { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveTransitOptionType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualEnclaveTransitOptionType
    {
        ExpressRoute = 0,
        Gateway = 1,
        Peering = 2,
    }
    public enum VirtualEnclaveUpdateMode
    {
        Automatic = 0,
        Manual = 1,
    }
    public partial class VirtualEnclaveWorkload : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEnclaveWorkload(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclave Parent { get { throw null; } set { } }
        public Azure.Provisioning.Enclave.VirtualEnclaveWorkloadProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Enclave.VirtualEnclaveWorkload FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_05_01_PREVIEW;
            public static readonly string V2025_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class VirtualEnclaveWorkloadProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualEnclaveWorkloadProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Enclave.VirtualEnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Enclave.VirtualEnclaveProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ResourceGroupCollection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
