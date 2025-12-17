namespace Azure.Provisioning.Search
{
    public partial class SearchAadAuthDataPlaneAuthOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchAadAuthDataPlaneAuthOptions() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchAadAuthFailureMode> AadAuthFailureMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ApiKeyOnly { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SearchAadAuthFailureMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http403")]
        Http403 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="http401WithBearerChallenge")]
        Http401WithBearerChallenge = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchBuiltInRole : System.IEquatable<Azure.Provisioning.Search.SearchBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Search.SearchBuiltInRole SearchIndexDataContributor { get { throw null; } }
        public static Azure.Provisioning.Search.SearchBuiltInRole SearchIndexDataReader { get { throw null; } }
        public static Azure.Provisioning.Search.SearchBuiltInRole SearchServiceContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.Search.SearchBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Search.SearchBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Search.SearchBuiltInRole left, Azure.Provisioning.Search.SearchBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Search.SearchBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Search.SearchBuiltInRole left, Azure.Provisioning.Search.SearchBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SearchBypass
    {
        None = 0,
        AzurePortal = 1,
        AzureServices = 2,
    }
    public enum SearchDisabledDataExfiltrationOption
    {
        All = 0,
    }
    public enum SearchEncryptionComplianceStatus
    {
        Compliant = 0,
        NonCompliant = 1,
    }
    public partial class SearchEncryptionWithCmk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchEncryptionWithCmk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchEncryptionComplianceStatus> EncryptionComplianceStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchEncryptionWithCmkEnforcement> Enforcement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SearchEncryptionWithCmkEnforcement
    {
        Unspecified = 0,
        Disabled = 1,
        Enabled = 2,
    }
    public partial class SearchManagementRequestOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchManagementRequestOptions() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientRequestId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SearchPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SearchPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Search.SearchService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Search.SearchServicePrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Search.SearchPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2014_07_31_Preview;
            public static readonly string V2015_02_28;
            public static readonly string V2015_08_19;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2019_10_01_Preview;
            public static readonly string V2020_03_13;
            public static readonly string V2020_08_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2020_08_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_04_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_06_06_Preview;
            public static readonly string V2022_09_01;
            public static readonly string V2023_11_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_03_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_06_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2025_02_01_Preview;
        }
    }
    public partial class SearchPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchPrivateEndpointConnectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Search.SearchServicePrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SearchPrivateLinkServiceConnectionProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
        Canceled = 5,
    }
    public enum SearchSemanticSearch
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="free")]
        Free = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 2,
    }
    public partial class SearchService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SearchService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Search.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServiceComputeType> ComputeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Search.SearchDisabledDataExfiltrationOption> DisabledDataExfiltrationOptions { get { throw null; } set { } }
        public Azure.Provisioning.Search.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServiceHostingMode> HostingMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Search.SearchServiceIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUpgradeAvailable { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Search.SearchServiceNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PartitionCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServiceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServicePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServiceSkuName> SearchSkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchSemanticSearch> SemanticSearch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ServiceUpgradeOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Search.SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServiceStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StatusDetails { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Search.SearchBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Search.SearchBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Search.SearchService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2014_07_31_Preview;
            public static readonly string V2015_02_28;
            public static readonly string V2015_08_19;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2019_10_01_Preview;
            public static readonly string V2020_03_13;
            public static readonly string V2020_08_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2020_08_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_04_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_06_06_Preview;
            public static readonly string V2022_09_01;
            public static readonly string V2023_11_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_03_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_06_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2025_02_01_Preview;
        }
    }
    public enum SearchServiceComputeType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="confidential")]
        Confidential = 1,
    }
    public enum SearchServiceHostingMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="highDensity")]
        HighDensity = 1,
    }
    public partial class SearchServiceIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchServiceIPRule() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SearchServiceNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchServiceNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchBypass> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Search.SearchServiceIPRule> IPRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SearchServicePrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchServicePrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.Search.SearchServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchPrivateLinkServiceConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SearchServicePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SearchServicePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SearchServicePrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SearchServicePrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum SearchServiceProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
    }
    public enum SearchServicePublicNetworkAccess
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum SearchServiceSharedPrivateLinkResourceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
    }
    public enum SearchServiceSharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum SearchServiceSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="free")]
        Free = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="basic")]
        Basic = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard2")]
        Standard2 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard3")]
        Standard3 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="storage_optimized_l1")]
        StorageOptimizedL1 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="storage_optimized_l2")]
        StorageOptimizedL2 = 6,
    }
    public enum SearchServiceStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="running")]
        Running = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="provisioning")]
        Provisioning = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleting")]
        Deleting = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="degraded")]
        Degraded = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="error")]
        Error = 5,
    }
    public partial class SharedSearchServicePrivateLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SharedSearchServicePrivateLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Search.SearchService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Search.SharedSearchServicePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Search.SharedSearchServicePrivateLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2014_07_31_Preview;
            public static readonly string V2015_02_28;
            public static readonly string V2015_08_19;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2019_10_01_Preview;
            public static readonly string V2020_03_13;
            public static readonly string V2020_08_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2020_08_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_04_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2021_06_06_Preview;
            public static readonly string V2022_09_01;
            public static readonly string V2023_11_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_03_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2024_06_01_Preview;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2025_02_01_Preview;
        }
    }
    public partial class SharedSearchServicePrivateLinkResourceData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharedSearchServicePrivateLinkResourceData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Search.SharedSearchServicePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharedSearchServicePrivateLinkResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharedSearchServicePrivateLinkResourceProperties() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SharedSearchServicePrivateLinkResourceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> ResourceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Search.SharedSearchServicePrivateLinkResourceStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharedSearchServicePrivateLinkResourceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
    }
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
}
