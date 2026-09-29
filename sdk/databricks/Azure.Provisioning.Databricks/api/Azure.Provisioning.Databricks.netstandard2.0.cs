namespace Azure.Provisioning.Databricks
{
    public partial class DatabricksAccessConnector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabricksAccessConnector(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksAccessConnectorProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Databricks.DatabricksAccessConnector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class DatabricksAccessConnectorProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksAccessConnectorProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ReferredBy { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksAutomaticClusterUpdateValue
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DatabricksComplianceSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksComplianceSecurityProfile() { }
        public Azure.Provisioning.BicepList<string> ComplianceStandards { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksComplianceSecurityProfileValue> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksComplianceSecurityProfileValue
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DatabricksComputeMode
    {
        Serverless = 0,
        Hybrid = 1,
    }
    public partial class DatabricksCreatedBy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksCreatedBy() { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> Oid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Puid { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksCustomParameterType
    {
        Bool = 0,
        Object = 1,
        String = 2,
    }
    public partial class DatabricksDefaultCatalogProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksDefaultCatalogProperties() { }
        public Azure.Provisioning.BicepValue<string> InitialName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksInitialCatalogType> InitialType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksDefaultStorageFirewall
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DatabricksEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksEncryption() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksEncryptionEntities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksEncryptionEntities() { }
        public Azure.Provisioning.Databricks.DatabricksManagedDiskEncryption ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksEncryptionV2 ManagedServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksEncryptionKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Keyvault")]
        MicrosoftKeyvault = 0,
    }
    public partial class DatabricksEncryptionV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksEncryptionV2() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksEncryptionV2KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksEncryptionV2KeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksEncryptionV2KeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksEnhancedSecurityCompliance : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksEnhancedSecurityCompliance() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksAutomaticClusterUpdateValue> AutomaticClusterUpdateValue { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksComplianceSecurityProfile ComplianceSecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksEnhancedSecurityMonitoringValue> EnhancedSecurityMonitoringValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksEnhancedSecurityMonitoringValue
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DatabricksGroupIdInformationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksGroupIdInformationProperties() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public enum DatabricksInitialCatalogType
    {
        HiveMetastore = 0,
        UnityCatalog = 1,
    }
    public enum DatabricksKeySource
    {
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Keyvault")]
        MicrosoftKeyvault = 1,
    }
    public partial class DatabricksManagedDiskEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksManagedDiskEncryption() { }
        public Azure.Provisioning.BicepValue<bool> IsRotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksManagedDiskEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksManagedDiskEncryptionKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksManagedDiskEncryptionKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksManagedIdentityConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksManagedIdentityConfiguration() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabricksPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Databricks.DatabricksPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class DatabricksPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Databricks.DatabricksPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Failed = 4,
    }
    public partial class DatabricksPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DatabricksPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksGroupIdInformationProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Databricks.DatabricksPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class DatabricksPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabricksPrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum DatabricksProvisioningState
    {
        Accepted = 0,
        Running = 1,
        Ready = 2,
        Creating = 3,
        Created = 4,
        Deleting = 5,
        Deleted = 6,
        Canceled = 7,
        Failed = 8,
        Succeeded = 9,
        Updating = 10,
    }
    public enum DatabricksPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DatabricksRequiredNsgRules
    {
        AllRules = 0,
        NoAzureDatabricksRules = 1,
        NoAzureServiceRules = 2,
    }
    public partial class DatabricksSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksVirtualNetworkPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabricksVirtualNetworkPeering(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowForwardedTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowGatewayTransit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVirtualNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DatabricksAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DatabricksVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksVirtualNetworkPeeringState> PeeringState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksVirtualNetworkPeeringProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RemoteAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseRemoteGateways { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Databricks.DatabricksVirtualNetworkPeering FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public enum DatabricksVirtualNetworkPeeringProvisioningState
    {
        Succeeded = 0,
        Updating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum DatabricksVirtualNetworkPeeringState
    {
        Initiated = 0,
        Connected = 1,
        Disconnected = 2,
    }
    public partial class DatabricksWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabricksWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Databricks.DatabricksWorkspaceAccessConnectorInfo AccessConnector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Databricks.DatabricksWorkspaceProviderAuthorization> Authorizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksComputeMode> ComputeMode { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksCreatedBy CreatedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.Databricks.DatabricksDefaultCatalogProperties DefaultCatalog { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksDefaultStorageFirewall> DefaultStorageFirewall { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } }
        public Azure.Provisioning.Databricks.DatabricksEncryptionEntities EncryptionEntities { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksEnhancedSecurityCompliance EnhancedSecurityCompliance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsUcEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksManagedIdentityConfiguration ManagedDiskIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomProperties Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Databricks.DatabricksPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksRequiredNsgRules> RequiredNsgRules { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksManagedIdentityConfiguration StorageAccountIdentity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UiDefinitionUri { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksCreatedBy UpdatedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Databricks.DatabricksWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class DatabricksWorkspaceAccessConnectorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksWorkspaceAccessConnectorInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksWorkspaceProviderAuthorization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabricksWorkspaceProviderAuthorization() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> RoleDefinitionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceCustomBooleanParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceCustomBooleanParameterValue() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksCustomParameterType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceCustomObjectParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceCustomObjectParameterValue() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksCustomParameterType> Type { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceCustomProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceCustomProperties() { }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue AmlWorkspaceId { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue CustomPrivateSubnetName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue CustomPublicSubnetName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue CustomVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceNoPublicIPBooleanParameterValue EnableNoPublicIP { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceEncryptionParameterValue Encryption { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue LoadBalancerBackendPoolName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue LoadBalancerId { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue NatGatewayName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomBooleanParameterValue PrepareEncryption { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue PublicIPName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomBooleanParameterValue RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomObjectParameterValue ResourceTags { get { throw null; } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue StorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue StorageAccountSkuName { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.WorkspaceCustomStringParameterValue VnetAddressPrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceCustomStringParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceCustomStringParameterValue() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksCustomParameterType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceEncryptionParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceEncryptionParameterValue() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksCustomParameterType> Type { get { throw null; } set { } }
        public Azure.Provisioning.Databricks.DatabricksEncryption Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceNoPublicIPBooleanParameterValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceNoPublicIPBooleanParameterValue() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Databricks.DatabricksCustomParameterType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
