namespace Azure.Provisioning.CognitiveServices
{
    public partial class AbusePenalty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AbusePenalty() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.AbusePenaltyAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Expiration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RateLimitPercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AbusePenaltyAction
    {
        Throttle = 0,
        Block = 1,
    }
    public partial class AIFoundryNetworkInjection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AIFoundryNetworkInjection() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.AIFoundryNetworkInjectionScenarioType> Scenario { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseMicrosoftManagedNetwork { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AIFoundryNetworkInjectionScenarioType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="agent")]
        Agent = 1,
    }
    public partial class ApplicationAuthorizationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationAuthorizationPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationTrafficRoutingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationTrafficRoutingPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesTrafficRoutingProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesTrafficRoutingRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CapabilityHostKind
    {
        Agents = 0,
    }
    public enum CapabilityHostProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class ChannelsBuiltInAuthorizationPolicy : Azure.Provisioning.CognitiveServices.ApplicationAuthorizationPolicy
    {
        public ChannelsBuiltInAuthorizationPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAccount(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public Azure.Provisioning.CognitiveServices.ServiceAccountApiKeys GetKeys() { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesAccountDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAccountDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesAccountDeploymentModel : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentModel() { }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAccountDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentProperties() { }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Capabilities { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.DeploymentCapacitySettings CapacitySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CurrentCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesDeploymentState> DeploymentState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicThrottlingEnabled { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentDeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RaiPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> RateLimits { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesDeploymentRouting Routing { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesDeploymentServiceTier> ServiceTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SpilloverDeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.DeploymentModelVersionUpgradeOption> VersionUpgradeOption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAccountDeploymentProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Disabled = 6,
        Canceled = 7,
    }
    public partial class CognitiveServicesAccountDeploymentScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountDeploymentScaleSettings() { }
        public Azure.Provisioning.BicepValue<int> ActiveCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentScaleType> ScaleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAccountDeploymentScaleType
    {
        Standard = 0,
        Manual = 1,
    }
    public partial class CognitiveServicesAccountProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAccountProperties() { }
        public Azure.Provisioning.CognitiveServices.AbusePenalty AbusePenalty { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.AIFoundryNetworkInjection> AIFoundryNetworkInjections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedFqdnList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowProjectManagement { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.UserOwnedAmlWorkspace AmlWorkspace { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AssociatedProjects { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuCapability> Capabilities { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CommitmentPlanAssociation> CommitmentPlanAssociations { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CustomSubDomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultProject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDynamicThrottling { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Endpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMigrated { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsStoredCompletionsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesMultiRegionSettings Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MigrationToken { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ServiceAccountQuotaLimit QuotaLimit { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.RaiMonitorConfig RaiMonitorConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Restore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSkuChangeInfo SkuChangeInfo { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountUserOwnedStorage> UserOwnedStorage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAgentApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAgentApplication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesProject Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAgenticApplicationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAgentApplication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesAgentDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesAgentDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAgentApplication Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesAgentDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAgentDeploymentProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesVersionedAgentReference> Agents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesAgentProtocolVersion> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeploymentState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAgentDeploymentProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum CognitiveServicesAgentDeploymentState
    {
        Starting = 0,
        Running = 1,
        Stopping = 2,
        Stopped = 3,
        Failed = 4,
        Deleting = 5,
        Deleted = 6,
        Updating = 7,
    }
    public partial class CognitiveServicesAgenticApplicationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAgenticApplicationProperties() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAssignedIdentity AgentIdentityBlueprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesAgentReferenceProperties> Agents { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ApplicationAuthorizationPolicy AuthorizationPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BaseUri { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAssignedIdentity DefaultInstanceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAgenticApplicationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.ApplicationTrafficRoutingPolicy TrafficRoutingPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesAgenticApplicationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum CognitiveServicesAgentProtocol
    {
        Agent = 0,
        A2A = 1,
        Responses = 2,
    }
    public partial class CognitiveServicesAgentProtocolVersion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAgentProtocolVersion() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesAgentProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAgentReferenceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAgentReferenceProperties() { }
        public Azure.Provisioning.BicepValue<string> AgentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesIdentityKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesIdentityProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesIdentityManagementType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesBuiltInRole : System.IEquatable<Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIDeveloper { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIEnterpriseNetworkConnectionApprover { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole AzureAIInferenceDeploymentOperator { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionDeployment { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionLabeler { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesCustomVisionTrainer { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesDataReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesFaceRecognizer { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesMetricsAdvisorAdministrator { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesOpenAIContributor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesOpenAIUser { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesQnAMakerEditor { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesQnAMakerReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesUsagesReader { get { throw null; } }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole CognitiveServicesUser { get { throw null; } }
        public bool Equals(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public static string GetBuiltInRoleName(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole value) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole left, Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole left, Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesCapabilityHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesCapabilityHost(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesCapabilityHostProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesCapabilityHost FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesCapabilityHostProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesCapabilityHostProperties() { }
        public Azure.Provisioning.BicepList<string> AiServicesConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CapabilityHostKind> CapabilityHostKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomerSubnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePublicHostingEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CapabilityHostProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> StorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ThreadStorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VectorStoreConnections { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesCommitmentPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesCommitmentPlan(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum CognitiveServicesConnectionCategory
    {
        PythonFeed = 0,
        ContainerRegistry = 1,
        Git = 2,
        S3 = 3,
        Snowflake = 4,
        AzureKeyVault = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureSqlDb")]
        AzureSqlDB = 6,
        AzureSynapseAnalytics = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureMySqlDb")]
        AzureMySqlDB = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzurePostgresDb")]
        AzurePostgresDB = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ADLSGen2")]
        AdlsGen2 = 10,
        AzureContainerAppEnvironment = 11,
        Redis = 12,
        ApiKey = 13,
        AzureOpenAI = 14,
        AIServices = 15,
        CognitiveSearch = 16,
        CognitiveService = 17,
        CustomKeys = 18,
        AzureBlob = 19,
        AzureStorageAccount = 20,
        AzureOneLake = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CosmosDb")]
        CosmosDB = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CosmosDbMongoDbApi")]
        CosmosDBMongoDBApi = 23,
        AzureDataExplorer = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureMariaDb")]
        AzureMariaDB = 25,
        AzureDatabricksDeltaLake = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureSqlMi")]
        AzureSqlMI = 27,
        AzureTableStorage = 28,
        AmazonRdsForOracle = 29,
        AmazonRdsForSqlServer = 30,
        AmazonRedshift = 31,
        Db2 = 32,
        Drill = 33,
        GoogleBigQuery = 34,
        Greenplum = 35,
        Hbase = 36,
        Hive = 37,
        Impala = 38,
        Informix = 39,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MariaDb")]
        MariaDB = 40,
        MicrosoftAccess = 41,
        MySql = 42,
        Netezza = 43,
        Oracle = 44,
        Phoenix = 45,
        PostgreSql = 46,
        Presto = 47,
        SapOpenHub = 48,
        SapBw = 49,
        SapHana = 50,
        SapTable = 51,
        Spark = 52,
        SqlServer = 53,
        Sybase = 54,
        Teradata = 55,
        Vertica = 56,
        Pinecone = 57,
        Databricks = 58,
        Cassandra = 59,
        Couchbase = 60,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MongoDbV2")]
        MongoDBV2 = 61,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MongoDbAtlas")]
        MongoDBAtlas = 62,
        AmazonS3Compatible = 63,
        FileServer = 64,
        FtpServer = 65,
        GoogleCloudStorage = 66,
        Hdfs = 67,
        OracleCloudStorage = 68,
        Sftp = 69,
        GenericHttp = 70,
        ODataRest = 71,
        Odbc = 72,
        GenericRest = 73,
        RemoteTool = 74,
        AmazonMws = 75,
        Concur = 76,
        Dynamics = 77,
        DynamicsAx = 78,
        DynamicsCrm = 79,
        GoogleAdWords = 80,
        Hubspot = 81,
        Jira = 82,
        Magento = 83,
        Marketo = 84,
        Office365 = 85,
        Eloqua = 86,
        Responsys = 87,
        OracleServiceCloud = 88,
        PayPal = 89,
        QuickBooks = 90,
        Salesforce = 91,
        SalesforceServiceCloud = 92,
        SalesforceMarketingCloud = 93,
        SapCloudForCustomer = 94,
        SapEcc = 95,
        ServiceNow = 96,
        SharePointOnlineList = 97,
        Shopify = 98,
        Square = 99,
        WebTable = 100,
        Xero = 101,
        Zoho = 102,
        GenericContainerRegistry = 103,
        Elasticsearch = 104,
        AppInsights = 105,
        AppConfig = 106,
        OpenAI = 107,
        Serp = 108,
        BingLLMSearch = 109,
        Serverless = 110,
        ManagedOnlineEndpoint = 111,
        ApiManagement = 112,
        ModelGateway = 113,
        GroundingWithBingSearch = 114,
        GroundingWithCustomSearch = 115,
        Sharepoint = 116,
        MicrosoftFabric = 117,
        PowerPlatformEnvironment = 118,
        RemoteA2A = 119,
    }
    public enum CognitiveServicesConnectionGroup
    {
        Azure = 0,
        AzureAI = 1,
        Database = 2,
        NoSQL = 3,
        File = 4,
        GenericProtocol = 5,
        ServicesAndApps = 6,
    }
    public partial class CognitiveServicesConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesConnectionCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreatedByWorkspaceArmId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesConnectionGroup> Group { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSharedToAll { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ManagedPERequirement> PeRequirement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ManagedPEStatus> PeStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SharedUserList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseWorkspaceManagedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesDeletedAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesDeletedAccount(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccountProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.CognitiveServices.CognitiveServicesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesDeletedAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesDeploymentRouting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesDeploymentRouting() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesRoutingMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesAccountDeploymentModel> Models { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesDeploymentServiceTier
    {
        Default = 0,
        Priority = 1,
    }
    public enum CognitiveServicesDeploymentState
    {
        Running = 0,
        Paused = 1,
    }
    public partial class CognitiveServicesEncryptionScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesEncryptionScope(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesEncryptionScopeProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesEncryptionScope FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesEncryptionScopeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesEncryptionScopeProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.EncryptionScopeProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.EncryptionScopeState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesFirewallSku
    {
        Standard = 0,
        Basic = 1,
    }
    public partial class CognitiveServicesFqdnOutboundRule : Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasicProperties
    {
        public CognitiveServicesFqdnOutboundRule() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesHostedAgentDeployment : Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeploymentProperties
    {
        public CognitiveServicesHostedAgentDeployment() { }
        public Azure.Provisioning.BicepValue<int> MaxReplicas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinReplicas { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesIdentityKind
    {
        AgentBlueprint = 0,
        AgentInstance = 1,
        AgenticUser = 2,
        Managed = 3,
        None = 4,
    }
    public enum CognitiveServicesIdentityManagementType
    {
        System = 0,
        User = 1,
        None = 2,
    }
    public enum CognitiveServicesIdentityProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
        Deleting = 5,
    }
    public partial class CognitiveServicesIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesIPRule() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesIsolationMode
    {
        Disabled = 0,
        AllowInternetOutbound = 1,
        AllowOnlyApprovedOutbound = 2,
    }
    public partial class CognitiveServicesKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesManagedAgentDeployment : Azure.Provisioning.CognitiveServices.CognitiveServicesAgentDeploymentProperties
    {
        public CognitiveServicesManagedAgentDeployment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesManagedNetworkConfigurationExtended : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesManagedNetworkConfigurationExtended() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesIsolationMode> ChangeableIsolationModes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FirewallPublicIpAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesFirewallSku> FirewallSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesIsolationMode> IsolationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkKind> ManagedNetworkKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkStatus> ManagedNetworkStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetworkId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasicProperties> OutboundRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesManagedNetworkKind
    {
        V1 = 0,
        V2 = 1,
    }
    public enum CognitiveServicesManagedNetworkProvisioningState
    {
        Deferred = 0,
        Updating = 1,
        Succeeded = 2,
        Failed = 3,
        Deleting = 4,
        Deleted = 5,
    }
    public partial class CognitiveServicesManagedNetworkSettings : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesManagedNetworkSettings(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkSettingsProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkSettings FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesManagedNetworkSettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesManagedNetworkSettingsProperties() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkConfigurationExtended ManagedNetwork { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesManagedNetworkStatus
    {
        Inactive = 0,
        Active = 1,
    }
    public partial class CognitiveServicesMultiRegionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesMultiRegionSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesRegionSetting> Regions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesRoutingMethod> RoutingMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesNetworkRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class CognitiveServicesNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.TrustedServicesByPassSelection> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkRuleAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesNetworkSecurityPerimeter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesNetworkSecurityPerimeter() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PerimeterGuid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesOutboundRuleBasic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesOutboundRuleBasic(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesManagedNetworkSettings Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasicProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasic FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesOutboundRuleBasicProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesOutboundRuleBasicProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceTagOutboundRuleCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorInformation { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ParentRuleNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceTagOutboundRuleStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum CognitiveServicesPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public partial class CognitiveServicesPrivateEndpointOutboundRule : Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasicProperties
    {
        public CognitiveServicesPrivateEndpointOutboundRule() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointOutboundRuleDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesPrivateEndpointOutboundRuleDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesPrivateEndpointOutboundRuleDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubresourceTarget { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class CognitiveServicesPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesProject : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesProject(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesProjectProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesProject FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesProjectCapabilityHost
    {
        public CognitiveServicesProjectCapabilityHost() { }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
        }
    }
    public partial class CognitiveServicesProjectConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesProjectConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesProject Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesProjectConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesProjectProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesProjectProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Endpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesProjectScopedCapabilityHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesProjectScopedCapabilityHost(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesProject Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesProjectScopedCapabilityHostProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesProjectScopedCapabilityHost FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesProjectScopedCapabilityHostProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesProjectScopedCapabilityHostProperties() { }
        public Azure.Provisioning.BicepList<string> AiServicesConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CapabilityHostProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> StorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ThreadStorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VectorStoreConnections { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesQuotaTier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CognitiveServicesQuotaTier(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesQuotaTierProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CognitiveServicesQuotaTier FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CognitiveServicesQuotaTierProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesQuotaTierProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AssignmentOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentTierName { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.QuotaTierUpgradeEligibilityInfo TierUpgradeEligibilityInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesTierUpgradePolicy> TierUpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesRegionSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesRegionSetting() { }
        public Azure.Provisioning.BicepValue<string> Customsubdomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesRoutingMethod
    {
        Priority = 0,
        Weighted = 1,
        Performance = 2,
    }
    public enum CognitiveServicesRoutingMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="cost")]
        Cost = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="balanced")]
        Balanced = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="quality")]
        Quality = 2,
    }
    public partial class CognitiveServicesSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CognitiveServicesSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesSkuCapability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSkuCapability() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesSkuChangeInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesSkuChangeInfo() { }
        public Azure.Provisioning.BicepValue<float> CountOfDowngrades { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> CountOfUpgradesAfterDowngrades { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastChangedOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CognitiveServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
        Enterprise = 4,
    }
    public enum CognitiveServicesTierUpgradePolicy
    {
        OnceUpgradeIsAvailable = 0,
        NoAutoUpgrade = 1,
    }
    public enum CognitiveServicesTrafficRoutingProtocol
    {
        FixedRatio = 0,
    }
    public partial class CognitiveServicesTrafficRoutingRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesTrafficRoutingRule() { }
        public Azure.Provisioning.BicepValue<string> DeploymentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrafficPercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesVersionedAgentReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesVersionedAgentReference() { }
        public Azure.Provisioning.BicepValue<string> AgentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CognitiveServicesVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CognitiveServicesVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPeriod() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CommitmentQuota Quota { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommitmentPlan(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlan FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CommitmentPlanAccountAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CommitmentPlanAccountAssociation(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesCommitmentPlan Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.CommitmentPlanAccountAssociation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class CommitmentPlanAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPlanAssociation() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CommitmentPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommitmentPlanLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommitmentPlanProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentPlanProperties() { }
        public Azure.Provisioning.BicepValue<bool> AutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> CommitmentPlanGuid { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Current { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountHostingModel> HostingModel { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Last { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.CommitmentPeriod Next { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisioningIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.CommitmentPlanProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CommitmentPlanProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Canceled = 6,
    }
    public partial class CommitmentQuota : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommitmentQuota() { }
        public Azure.Provisioning.BicepValue<long> Quantity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomBlocklistConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomBlocklistConfig() { }
        public Azure.Provisioning.BicepValue<string> BlocklistName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlocking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefenderForAISetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DefenderForAISetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.DefenderForAISettingState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.DefenderForAISetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum DefenderForAISettingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DeploymentCapacitySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentCapacitySettings() { }
        public Azure.Provisioning.BicepValue<int> DesignatedCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DeploymentModelVersionUpgradeOption
    {
        OnceNewDefaultVersionAvailable = 0,
        OnceCurrentVersionExpired = 1,
        NoAutoUpgrade = 2,
    }
    public enum EncryptionScopeProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Canceled = 6,
    }
    public enum EncryptionScopeState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ManagedPERequirement
    {
        Required = 0,
        NotRequired = 1,
        NotApplicable = 2,
    }
    public enum ManagedPEStatus
    {
        Inactive = 0,
        Active = 1,
        NotApplicable = 2,
    }
    public partial class NetworkSecurityPerimeterAccessRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterAccessRule() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterAccessRuleProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterAccessRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterAccessRuleProperties() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.NspAccessRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FullyQualifiedDomainNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterAccessRulePropertiesSubscriptionsItem> Subscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterAccessRulePropertiesSubscriptionsItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterAccessRulePropertiesSubscriptionsItem() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class NetworkSecurityPerimeterConfigurationAssociationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterConfigurationAssociationInfo() { }
        public Azure.Provisioning.BicepValue<string> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesNetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterProfileInfo Profile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterProvisioningIssue> ProvisioningIssues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterConfigurationAssociationInfo ResourceAssociation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterProfileInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterProfileInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterAccessRule> AccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> AccessRulesVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiagnosticSettingsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledLogCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterProvisioningIssue() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterProvisioningIssueProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssueProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterProvisioningIssueProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IssueType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.NetworkSecurityPerimeterAccessRule> SuggestedAccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NspAccessRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public partial class OrganizationSharedBuiltInAuthorizationPolicy : Azure.Provisioning.CognitiveServices.ApplicationAuthorizationPolicy
    {
        public OrganizationSharedBuiltInAuthorizationPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QuotaTierUpgradeAvailabilityStatus
    {
        Available = 0,
        NotAvailable = 1,
    }
    public partial class QuotaTierUpgradeEligibilityInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QuotaTierUpgradeEligibilityInfo() { }
        public Azure.Provisioning.BicepValue<string> NextTierName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpgradeApplicableOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.QuotaTierUpgradeAvailabilityStatus> UpgradeAvailabilityStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpgradeUnavailabilityReason { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RaiActionType
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="BLOCKING")]
        Blocking = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ANNOTATING")]
        Annotating = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HITL")]
        Hitl = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RETRY")]
        Retry = 4,
    }
    public partial class RaiBlocklist : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiBlocklist(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RaiBlocklistDescription { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiBlocklist FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiBlocklistItem : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiBlocklistItem(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiBlocklist Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiBlocklistItemProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiBlocklistItem FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiBlocklistItemProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiBlocklistItemProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsRegex { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Pattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiContentFilter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiContentFilter(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiContentFilterProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiContentFilter FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiContentFilterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiContentFilterProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsMultiLevelFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiExternalSafetyProviderSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiExternalSafetyProviderSchema(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiExternalSafetyProviderSchemaProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiExternalSafetyProviderSchema FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiExternalSafetyProviderSchemaProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiExternalSafetyProviderSchemaProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiMonitorConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiMonitorConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AdxStorageResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_04_18;
            public static readonly string V2021_04_30;
            public static readonly string V2021_10_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_06_01;
            public static readonly string V2025_09_01;
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiPolicyContentFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiPolicyContentFilter() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlocking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentLevel> SeverityThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RaiPolicyContentLevel
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public enum RaiPolicyContentSource
    {
        Prompt = 0,
        Completion = 1,
        PreToolCall = 2,
        PostToolCall = 3,
        PreRun = 4,
        PostRun = 5,
    }
    public enum RaiPolicyMode
    {
        Default = 0,
        Deferred = 1,
        Blocking = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Asynchronous_filter")]
        AsynchronousFilter = 3,
    }
    public partial class RaiPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiPolicyProperties() { }
        public Azure.Provisioning.BicepValue<string> BasePolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.RaiPolicyContentFilter> ContentFilters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.CustomBlocklistConfig> CustomBlocklists { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyType> PolicyType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.RaiSafetyProviderSourceConfig> SafetyProviders { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RaiPolicyType
    {
        UserManaged = 0,
        SystemManaged = 1,
    }
    public partial class RaiSafetyProviderSourceConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiSafetyProviderSourceConfig() { }
        public Azure.Provisioning.BicepValue<bool> IsBlocking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SafetyProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.RaiPolicyContentSource> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiToolLabel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiToolLabel(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiToolLabelProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiToolLabel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiToolLabelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiToolLabelProperties() { }
        public Azure.Provisioning.BicepDictionary<string> AccountScopeLabelValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.RaiToolLabelPropertiesProjectScopesItem> ProjectScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ToolConnectionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiToolLabelPropertiesProjectScopesItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiToolLabelPropertiesProjectScopesItem() { }
        public Azure.Provisioning.BicepDictionary<string> LabelValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Project { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RaiTopic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RaiTopic(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiTopicProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.RaiTopic FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RaiTopicProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RaiTopicProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailedReason { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SampleBlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopicName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoleBasedBuiltInAuthorizationPolicy : Azure.Provisioning.CognitiveServices.ApplicationAuthorizationPolicy
    {
        public RoleBasedBuiltInAuthorizationPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountApiKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountApiKeys() { }
        public Azure.Provisioning.BicepValue<string> Key1 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key2 { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountApiProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountApiProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> AadClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> AadTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStatistics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> QnaAzureSearchEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QnaAzureSearchEndpointKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QnaRuntimeEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SuperUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebsiteName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountCallRateLimit : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountCallRateLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAccountEncryptionKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.CognitiveServices")]
        MicrosoftCognitiveServices = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 1,
    }
    public partial class ServiceAccountEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.CognitiveServicesKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceAccountHostingModel
    {
        Web = 0,
        ConnectedContainer = 1,
        DisconnectedContainer = 2,
        ProvisionedWeb = 3,
    }
    public enum ServiceAccountProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Deleting = 2,
        Moving = 3,
        Failed = 4,
        Succeeded = 5,
        Canceled = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ResolvingDNS")]
        ResolvingDns = 7,
    }
    public enum ServiceAccountPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ServiceAccountQuotaLimit : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountQuotaLimit() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountThrottlingMatchPattern : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountThrottlingMatchPattern() { }
        public Azure.Provisioning.BicepValue<string> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountThrottlingRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountThrottlingRule() { }
        public Azure.Provisioning.BicepValue<float> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicThrottlingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CognitiveServices.ServiceAccountThrottlingMatchPattern> MatchPatterns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RenewalPeriod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAccountUserOwnedStorage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountUserOwnedStorage() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceTagOutboundRule : Azure.Provisioning.CognitiveServices.CognitiveServicesOutboundRuleBasicProperties
    {
        public ServiceTagOutboundRule() { }
        public Azure.Provisioning.CognitiveServices.ServiceTagOutboundRuleDestination Destination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceTagOutboundRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public enum ServiceTagOutboundRuleCategory
    {
        Required = 0,
        Recommended = 1,
        UserDefined = 2,
        Dependency = 3,
    }
    public partial class ServiceTagOutboundRuleDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceTagOutboundRuleDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CognitiveServices.ServiceTagOutboundRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceTag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceTagOutboundRuleStatus
    {
        Inactive = 0,
        Active = 1,
        Provisioning = 2,
        Deleting = 3,
        Failed = 4,
    }
    public partial class SubscriptionRaiPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionRaiPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CognitiveServices.RaiPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CognitiveServices.SubscriptionRaiPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum TrustedServicesByPassSelection
    {
        None = 0,
        AzureServices = 1,
    }
    public partial class UserOwnedAmlWorkspace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserOwnedAmlWorkspace() { }
        public Azure.Provisioning.BicepValue<System.Guid> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
