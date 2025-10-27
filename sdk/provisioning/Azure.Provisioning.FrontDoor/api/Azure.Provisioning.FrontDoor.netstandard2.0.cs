namespace Azure.Provisioning.FrontDoor
{
    public enum BackendEnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class BackendPoolsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendPoolsSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.EnforceCertificateNameCheckEnabledState> EnforceCertificateNameCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SendRecvTimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackendPrivateEndpointStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class CustomHttpsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomHttpsConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorCertificateSource> CertificateSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorEndpointConnectionCertificateType> CertificateType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorRequiredMinimumTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorTlsProtocolType> ProtocolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomRuleEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum DynamicCompressionEnabled
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum EnforceCertificateNameCheckEnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ForwardingConfiguration : Azure.Provisioning.FrontDoor.RouteConfiguration
    {
        public ForwardingConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendPoolId { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomForwardingPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorForwardingProtocol> ForwardingProtocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorBackend : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorBackend() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BackendHostHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.BackendEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.BackendPrivateEndpointStatus> PrivateEndpointStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkApprovalMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorBackendPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorBackendPool() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorBackend> Backends { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HealthProbeSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadBalancingSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorCacheConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorCacheConfiguration() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> CacheDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.DynamicCompressionEnabled> DynamicCompression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorQuery> QueryParameterStripDirective { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontDoorCertificateSource
    {
        AzureKeyVault = 0,
        FrontDoor = 1,
    }
    public enum FrontDoorEnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum FrontDoorEndpointConnectionCertificateType
    {
        Dedicated = 0,
    }
    public partial class FrontDoorExperiment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorExperiment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorExperimentState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorExperimentEndpointProperties ExperimentEndpointA { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorExperimentEndpointProperties ExperimentEndpointB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorNetworkExperimentProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.NetworkExperimentResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ScriptFileUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.FrontDoor.FrontDoorExperiment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_11_01;
        }
    }
    public partial class FrontDoorExperimentEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorExperimentEndpointProperties() { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontDoorExperimentState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum FrontDoorForwardingProtocol
    {
        HttpOnly = 0,
        HttpsOnly = 1,
        MatchRequest = 2,
    }
    public enum FrontDoorHealthProbeMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 1,
    }
    public partial class FrontDoorHealthProbeSettingsData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorHealthProbeSettingsData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.HealthProbeEnabled> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorHealthProbeMethod> HealthProbeMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorLoadBalancingSettingsData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorLoadBalancingSettingsData() { }
        public Azure.Provisioning.BicepValue<int> AdditionalLatencyMilliseconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SampleSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SuccessfulSamplesRequired { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorNetworkExperimentProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorNetworkExperimentProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorExperimentState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.NetworkExperimentResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.FrontDoor.FrontDoorNetworkExperimentProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_11_01;
        }
    }
    public enum FrontDoorProtocol
    {
        Http = 0,
        Https = 1,
    }
    public enum FrontDoorQuery
    {
        StripNone = 0,
        StripAll = 1,
        StripOnly = 2,
        StripAllExcept = 3,
    }
    public enum FrontDoorRedirectProtocol
    {
        HttpOnly = 0,
        HttpsOnly = 1,
        MatchRequest = 2,
    }
    public enum FrontDoorRedirectType
    {
        Moved = 0,
        Found = 1,
        TemporaryRedirect = 2,
        PermanentRedirect = 3,
    }
    public enum FrontDoorRequiredMinimumTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 1,
    }
    public partial class FrontDoorResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorBackendPool> BackendPools { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.BackendPoolsSettings BackendPoolsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Cname { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ExtendedProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FrontdoorId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontendEndpointData> FrontendEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorHealthProbeSettingsData> HealthProbeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorLoadBalancingSettingsData> LoadBalancingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RoutingRuleData> RoutingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorRulesEngine> RulesEngines { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.FrontDoor.FrontDoorResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_07_01;
            public static readonly string V2021_06_01;
            public static readonly string V2025_10_01;
        }
    }
    public enum FrontDoorResourceState
    {
        Creating = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
        Deleting = 5,
        Migrating = 6,
        Migrated = 7,
    }
    public partial class FrontDoorRulesEngine : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRulesEngine(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorResource? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RulesEngineRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.FrontDoor.FrontDoorRulesEngine FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_05_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_07_01;
            public static readonly string V2021_06_01;
            public static readonly string V2025_10_01;
        }
    }
    public enum FrontDoorSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Classic_AzureFrontDoor")]
        ClassicAzureFrontDoor = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_AzureFrontDoor")]
        StandardAzureFrontDoor = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_AzureFrontDoor")]
        PremiumAzureFrontDoor = 2,
    }
    public enum FrontDoorTlsProtocolType
    {
        ServerNameIndication = 0,
    }
    public partial class FrontDoorWebApplicationFirewallPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorWebApplicationFirewallPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> FrontendEndpointLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleSet> ManagedRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicySettings PolicySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicyResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> RoutingRuleLinks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.WebApplicationCustomRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> SecurityPolicyLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2019_03_01;
            public static readonly string V2019_10_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_11_01;
            public static readonly string V2022_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class FrontDoorWebApplicationFirewallPolicyGroupByVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorWebApplicationFirewallPolicyGroupByVariable() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicyGroupByVariableName> VariableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontDoorWebApplicationFirewallPolicyGroupByVariableName
    {
        SocketAddr = 0,
        GeoLocation = 1,
        None = 2,
    }
    public enum FrontDoorWebApplicationFirewallPolicyMode
    {
        Prevention = 0,
        Detection = 1,
    }
    public enum FrontDoorWebApplicationFirewallPolicyResourceState
    {
        Creating = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
        Deleting = 5,
    }
    public partial class FrontDoorWebApplicationFirewallPolicySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorWebApplicationFirewallPolicySettings() { }
        public Azure.Provisioning.BicepValue<int> CaptchaExpirationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomBlockResponseBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CustomBlockResponseStatusCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.PolicyEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> JavascriptChallengeExpirationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicyMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RedirectUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.PolicyRequestBodyCheck> RequestBodyCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.WebApplicationFirewallScrubbingRules> ScrubbingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.WebApplicationFirewallScrubbingState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontendEndpointCustomHttpsProvisioningState
    {
        Enabling = 0,
        Enabled = 1,
        Disabling = 2,
        Disabled = 3,
        Failed = 4,
    }
    public enum FrontendEndpointCustomHttpsProvisioningSubstate
    {
        SubmittingDomainControlValidationRequest = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PendingDomainControlValidationREquestApproval")]
        PendingDomainControlValidationRequestApproval = 1,
        DomainControlValidationRequestApproved = 2,
        DomainControlValidationRequestRejected = 3,
        DomainControlValidationRequestTimedOut = 4,
        IssuingCertificate = 5,
        DeployingCertificate = 6,
        CertificateDeployed = 7,
        DeletingCertificate = 8,
        CertificateDeleted = 9,
    }
    public partial class FrontendEndpointData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontendEndpointData() { }
        public Azure.Provisioning.FrontDoor.CustomHttpsConfiguration CustomHttpsConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontendEndpointCustomHttpsProvisioningState> CustomHttpsProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontendEndpointCustomHttpsProvisioningSubstate> CustomHttpsProvisioningSubstate { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.SessionAffinityEnabledState> SessionAffinityEnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SessionAffinityTtlInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HealthProbeEnabled
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ManagedRuleEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ManagedRuleExclusion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleExclusion() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ManagedRuleExclusionMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ManagedRuleExclusionSelectorMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedRuleExclusionMatchVariable
    {
        RequestHeaderNames = 0,
        RequestCookieNames = 1,
        QueryStringArgNames = 2,
        RequestBodyPostArgNames = 3,
        RequestBodyJsonArgNames = 4,
    }
    public enum ManagedRuleExclusionSelectorMatchOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        Contains = 1,
        StartsWith = 2,
        EndsWith = 3,
        EqualsAny = 4,
    }
    public partial class ManagedRuleGroupOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleGroupOverride() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleOverride> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RuleMatchActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ManagedRuleEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.ManagedRuleGroupOverride> RuleGroupOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ManagedRuleSetActionType> RuleSetAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedRuleSetActionType
    {
        Block = 0,
        Log = 1,
        Redirect = 2,
    }
    public enum MatchProcessingBehavior
    {
        Continue = 0,
        Stop = 1,
    }
    public enum NetworkExperimentResourceState
    {
        Creating = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
        Deleting = 5,
    }
    public enum PolicyEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum PolicyRequestBodyCheck
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class RedirectConfiguration : Azure.Provisioning.FrontDoor.RouteConfiguration
    {
        public RedirectConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CustomFragment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomHost { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomQueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorRedirectProtocol> RedirectProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorRedirectType> RedirectType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingRuleData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingRuleData() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorProtocol> AcceptedProtocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RoutingRuleEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> FrontendEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PatternsToMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.FrontDoorResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.FrontDoor.RouteConfiguration RouteConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RulesEngineId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoutingRuleEnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum RuleMatchActionType
    {
        Allow = 0,
        Block = 1,
        Log = 2,
        Redirect = 3,
        AnomalyScoring = 4,
        JSChallenge = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CAPTCHA")]
        Captcha = 6,
    }
    public partial class RulesEngineAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RulesEngineAction() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RulesEngineHeaderAction> RequestHeaderActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RulesEngineHeaderAction> ResponseHeaderActions { get { throw null; } set { } }
        public Azure.Provisioning.FrontDoor.RouteConfiguration RouteConfigurationOverride { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RulesEngineHeaderAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RulesEngineHeaderAction() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RulesEngineHeaderActionType> HeaderActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RulesEngineHeaderActionType
    {
        Append = 0,
        Delete = 1,
        Overwrite = 2,
    }
    public partial class RulesEngineMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RulesEngineMatchCondition() { }
        public Azure.Provisioning.BicepValue<bool> IsNegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RulesEngineMatchValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RulesEngineMatchVariable> RulesEngineMatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RulesEngineOperator> RulesEngineOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RulesEngineMatchTransform> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RulesEngineMatchTransform
    {
        Lowercase = 0,
        Uppercase = 1,
        Trim = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UrlDecode")]
        UriDecode = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UrlEncode")]
        UriEncode = 4,
        RemoveNulls = 5,
    }
    public enum RulesEngineMatchVariable
    {
        IsMobile = 0,
        RemoteAddr = 1,
        RequestMethod = 2,
        QueryString = 3,
        PostArgs = 4,
        RequestUri = 5,
        RequestPath = 6,
        RequestFilename = 7,
        RequestFilenameExtension = 8,
        RequestHeader = 9,
        RequestBody = 10,
        RequestScheme = 11,
    }
    public enum RulesEngineOperator
    {
        Any = 0,
        IPMatch = 1,
        GeoMatch = 2,
        Equal = 3,
        Contains = 4,
        LessThan = 5,
        GreaterThan = 6,
        LessThanOrEqual = 7,
        GreaterThanOrEqual = 8,
        BeginsWith = 9,
        EndsWith = 10,
    }
    public partial class RulesEngineRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RulesEngineRule() { }
        public Azure.Provisioning.FrontDoor.RulesEngineAction Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.RulesEngineMatchCondition> MatchConditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.MatchProcessingBehavior> MatchProcessingBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScrubbingRuleEntryMatchOperator
    {
        EqualsAny = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 1,
    }
    public enum ScrubbingRuleEntryMatchVariable
    {
        RequestIPAddress = 0,
        RequestUri = 1,
        QueryStringArgNames = 2,
        RequestHeaderNames = 3,
        RequestCookieNames = 4,
        RequestBodyPostArgNames = 5,
        RequestBodyJsonArgNames = 6,
    }
    public enum ScrubbingRuleEntryState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum SessionAffinityEnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class WebApplicationCustomRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebApplicationCustomRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.RuleMatchActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.CustomRuleEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.FrontDoorWebApplicationFirewallPolicyGroupByVariable> GroupBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.WebApplicationRuleMatchCondition> MatchConditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RateLimitDurationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RateLimitThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.WebApplicationRuleType> RuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebApplicationFirewallScrubbingRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebApplicationFirewallScrubbingRules() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ScrubbingRuleEntryMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ScrubbingRuleEntryMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.ScrubbingRuleEntryState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationFirewallScrubbingState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class WebApplicationRuleMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebApplicationRuleMatchCondition() { }
        public Azure.Provisioning.BicepValue<bool> IsNegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.WebApplicationRuleMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.FrontDoor.WebApplicationRuleMatchOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.FrontDoor.WebApplicationRuleMatchTransformType> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationRuleMatchOperator
    {
        Any = 0,
        IPMatch = 1,
        GeoMatch = 2,
        Equal = 3,
        Contains = 4,
        LessThan = 5,
        GreaterThan = 6,
        LessThanOrEqual = 7,
        GreaterThanOrEqual = 8,
        BeginsWith = 9,
        EndsWith = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RegEx")]
        RegEX = 11,
    }
    public enum WebApplicationRuleMatchTransformType
    {
        Lowercase = 0,
        Uppercase = 1,
        Trim = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UrlDecode")]
        UriDecode = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UrlEncode")]
        UriEncode = 4,
        RemoveNulls = 5,
    }
    public enum WebApplicationRuleMatchVariable
    {
        RemoteAddr = 0,
        RequestMethod = 1,
        QueryString = 2,
        PostArgs = 3,
        RequestUri = 4,
        RequestHeader = 5,
        RequestBody = 6,
        Cookies = 7,
        SocketAddr = 8,
    }
    public enum WebApplicationRuleType
    {
        MatchRule = 0,
        RateLimitRule = 1,
    }
}
