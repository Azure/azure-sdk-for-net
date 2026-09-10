namespace Azure.Provisioning.Network
{
    public partial class AadAuthenticationParameters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AadAuthenticationParameters() { }
        public Azure.Provisioning.BicepValue<string> AadAudience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AadIssuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AadTenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AddressPrefixItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AddressPrefixItem() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AddressPrefixType> AddressPrefixType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AddressPrefixType
    {
        IPPrefix = 0,
        ServiceTag = 1,
        NetworkGroup = 2,
    }
    public enum AddressSpaceAggregationOption
    {
        None = 0,
        Manual = 1,
    }
    public partial class AdminRuleGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AdminRuleGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkManagerSecurityGroupItem> AppliesToGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.SecurityAdminConfiguration? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.AdminRuleGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class AdvertisedPublicPrefixProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdvertisedPublicPrefixProperties() { }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Signature { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AdvertisedPublicPrefixPropertiesValidationState> ValidationState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AdvertisedPublicPrefixPropertiesValidationState
    {
        NotConfigured = 0,
        Configuring = 1,
        Configured = 2,
        ValidationNeeded = 3,
        ValidationFailed = 4,
        ManualValidationNeeded = 5,
        AsnValidationFailed = 6,
        CertificateMissingInRoutingRegistry = 7,
        InvalidSignatureEncoding = 8,
        SignatureVerificationFailed = 9,
    }
    public partial class AnalysisRunIntentContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AnalysisRunIntentContent() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DestinationResourceId { get { throw null; } }
        public Azure.Provisioning.Network.NetworkVerifierIPTraffic IPTraffic { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayAutoscaleConfiguration AutoscaleConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddressPool> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendSettings> BackendSettingsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayCustomError> CustomErrorConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySslPolicyName> DefaultPredefinedSslPolicy { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableFips { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHttp2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayEntraJwtValidationConfig> EntraJwtValidationConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ForceFirewallPolicyAssociation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayFrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayFrontendPort> FrontendPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayIPConfiguration> GatewayIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayGlobalConfiguration GlobalConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayHttpListener> HttpListeners { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayListener> Listeners { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayLoadDistributionPolicy> LoadDistributionPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayOperationalState> OperationalState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayPrivateLinkConfiguration> PrivateLinkConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayProbe> Probes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRedirectConfiguration> RedirectConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRequestRoutingRule> RequestRoutingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRewriteRuleSet> RewriteRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRoutingRule> RoutingRules { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewaySku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewaySslCertificate> SslCertificates { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewaySslPolicy SslPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewaySslProfile> SslProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayTrustedClientCertificate> TrustedClientCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayTrustedRootCertificate> TrustedRootCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayUrlPathMap> UrlPathMaps { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayWebApplicationFirewallConfiguration WebApplicationFirewallConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ApplicationGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ApplicationGatewayAuthenticationCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayAuthenticationCertificate() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayAutoscaleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayAutoscaleConfiguration() { }
        public Azure.Provisioning.BicepValue<int> MaxCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCapacity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendAddress() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendAddressPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendAddressPool() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddress> BackendAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> BackendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendHttpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendHttpSettings() { }
        public Azure.Provisioning.BicepValue<string> AffinityCookieName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> AuthenticationCertificates { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayConnectionDraining ConnectionDraining { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayCookieBasedAffinity> CookieBasedAffinity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDedicatedBackendConnectionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidateCertChainAndExpiryEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidateSniEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PickHostNameFromBackendAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ProbeEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProbeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RequestTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SniName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> TrustedRootCertificates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendSettings() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsL4ClientIPPreservationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PickHostNameFromBackendAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProbeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> TrustedRootCertificates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayClientAuthConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayClientAuthConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayClientAuthVerificationMode> VerifyClientAuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> VerifyClientCertIssuerDN { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayClientRevocationOption> VerifyClientRevocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayClientAuthVerificationMode
    {
        Strict = 0,
        Passthrough = 1,
    }
    public enum ApplicationGatewayClientRevocationOption
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OCSP")]
        Ocsp = 1,
    }
    public partial class ApplicationGatewayConnectionDraining : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayConnectionDraining() { }
        public Azure.Provisioning.BicepValue<int> DrainTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayCookieBasedAffinity
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ApplicationGatewayCustomError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayCustomError() { }
        public Azure.Provisioning.BicepValue<System.Uri> CustomErrorPageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayCustomErrorStatusCode> StatusCode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayCustomErrorStatusCode
    {
        HttpStatus499 = 0,
        HttpStatus400 = 1,
        HttpStatus403 = 2,
        HttpStatus404 = 3,
        HttpStatus405 = 4,
        HttpStatus408 = 5,
        HttpStatus500 = 6,
        HttpStatus502 = 7,
        HttpStatus503 = 8,
        HttpStatus504 = 9,
    }
    public partial class ApplicationGatewayEntraJwtValidationConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayEntraJwtValidationConfig() { }
        public Azure.Provisioning.BicepList<string> Audiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayUnAuthorizedRequestAction> UnAuthorizedRequestAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayFirewallDisabledRuleGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayFirewallDisabledRuleGroup() { }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayFirewallExclusion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayFirewallExclusion() { }
        public Azure.Provisioning.BicepValue<string> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SelectorMatchOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayFirewallMode
    {
        Detection = 0,
        Prevention = 1,
    }
    public enum ApplicationGatewayFirewallRateLimitDuration
    {
        OneMin = 0,
        FiveMins = 1,
    }
    public enum ApplicationGatewayFirewallUserSessionVariable
    {
        ClientAddr = 0,
        GeoLocation = 1,
        None = 2,
        ClientAddrXFFHeader = 3,
        GeoLocationXFFHeader = 4,
    }
    public partial class ApplicationGatewayFrontendIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayFrontendIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayFrontendPort : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayFrontendPort() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayGlobalConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayGlobalConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> EnableRequestBuffering { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableResponseBuffering { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayHeaderConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayHeaderConfiguration() { }
        public Azure.Provisioning.BicepValue<string> HeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderValue { get { throw null; } set { } }
        public Azure.Provisioning.Network.HeaderValueMatcher HeaderValueMatcher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayHttpListener : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayHttpListener() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayCustomError> CustomErrorConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendPortId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RequireServerNameIndication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SslCertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SslProfileId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayListener : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayListener() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendPortId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SslCertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SslProfileId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayLoadDistributionAlgorithm
    {
        RoundRobin = 0,
        LeastConnections = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpHash")]
        IPHash = 2,
    }
    public partial class ApplicationGatewayLoadDistributionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayLoadDistributionPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayLoadDistributionAlgorithm> LoadDistributionAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayLoadDistributionTarget> LoadDistributionTargets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayLoadDistributionTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayLoadDistributionTarget() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> WeightPerServer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayOperationalState
    {
        Stopped = 0,
        Starting = 1,
        Running = 2,
        Stopping = 3,
    }
    public partial class ApplicationGatewayPathRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayPathRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendHttpSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadDistributionPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Paths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RedirectConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RewriteRuleSetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationGatewayPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LinkIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateEndpoint PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ApplicationGatewayPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ApplicationGatewayPrivateLinkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayPrivateLinkConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayPrivateLinkIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayPrivateLinkIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayPrivateLinkIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrimary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayProbe : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayProbe() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsProbeProxyProtocolHeaderEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayProbeHealthResponseMatch Match { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PickHostNameFromBackendHttpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PickHostNameFromBackendSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UnhealthyThreshold { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayProbeHealthResponseMatch : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayProbeHealthResponseMatch() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> StatusCodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayProtocol
    {
        Http = 0,
        Https = 1,
        Tcp = 2,
        Tls = 3,
    }
    public partial class ApplicationGatewayRedirectConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRedirectConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludeQueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PathRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayRedirectType> RedirectType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RequestRoutingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetListenerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> TargetUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> UrlPathMaps { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayRedirectType
    {
        Permanent = 0,
        Found = 1,
        SeeOther = 2,
        Temporary = 3,
    }
    public partial class ApplicationGatewayRequestRoutingRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRequestRoutingRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendHttpSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EntraJwtValidationConfigId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HttpListenerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadDistributionPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RedirectConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RewriteRuleSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayRequestRoutingRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UrlPathMapId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayRequestRoutingRuleType
    {
        Basic = 0,
        PathBasedRouting = 1,
    }
    public partial class ApplicationGatewayRewriteRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRewriteRule() { }
        public Azure.Provisioning.Network.ApplicationGatewayRewriteRuleActionSet ActionSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRewriteRuleCondition> Conditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RuleSequence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayRewriteRuleActionSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRewriteRuleActionSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayHeaderConfiguration> RequestHeaderConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayHeaderConfiguration> ResponseHeaderConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.Network.ApplicationGatewayUrlConfiguration UrlConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayRewriteRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRewriteRuleCondition() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreCase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Negate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Pattern { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Variable { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayRewriteRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRewriteRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayRewriteRule> RewriteRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayRoutingRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayRoutingRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ListenerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayRequestRoutingRuleType> RuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewaySku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewaySku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySkuFamily> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewaySkuFamily
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Generation_1")]
        Generation1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Generation_2")]
        Generation2 = 1,
    }
    public enum ApplicationGatewaySkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Small")]
        StandardSmall = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Medium")]
        StandardMedium = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Large")]
        StandardLarge = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WAF_Medium")]
        WAFMedium = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WAF_Large")]
        WAFLarge = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_v2")]
        StandardV2 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WAF_v2")]
        WAFV2 = 6,
        Basic = 7,
    }
    public partial class ApplicationGatewaySslCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewaySslCertificate() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PublicCertData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewaySslCipherSuite
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384")]
        TlsECDiffieHellmanRsaWithAes256CbcSha384 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256")]
        TlsECDiffieHellmanRsaWithAes128CbcSha256 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA")]
        TlsECDiffieHellmanRsaWithAes256CbcSha = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA")]
        TlsECDiffieHellmanRsaWithAes128CbcSha = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_RSA_WITH_AES_256_GCM_SHA384")]
        TlsDHERsaWithAes256GcmSha384 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_RSA_WITH_AES_128_GCM_SHA256")]
        TlsDHERsaWithAes128GcmSha256 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_RSA_WITH_AES_256_CBC_SHA")]
        TlsDHERsaWithAes256CbcSha = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_RSA_WITH_AES_128_CBC_SHA")]
        TlsDHERsaWithAes128CbcSha = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_GCM_SHA384")]
        TlsRsaWithAes256GcmSha384 = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_GCM_SHA256")]
        TlsRsaWithAes128GcmSha256 = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_CBC_SHA256")]
        TlsRsaWithAes256CbcSha256 = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_CBC_SHA256")]
        TlsRsaWithAes128CbcSha256 = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_CBC_SHA")]
        TlsRsaWithAes256CbcSha = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_CBC_SHA")]
        TlsRsaWithAes128CbcSha = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384")]
        TlsECDiffieHellmanECDsaWithAes256GcmSha384 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256")]
        TlsECDiffieHellmanECDsaWithAes128GcmSha256 = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384")]
        TlsECDiffieHellmanECDsaWithAes256CbcSha384 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256")]
        TlsECDiffieHellmanECDsaWithAes128CbcSha256 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA")]
        TlsECDiffieHellmanECDsaWithAes256CbcSha = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA")]
        TlsECDiffieHellmanECDsaWithAes128CbcSha = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_DSS_WITH_AES_256_CBC_SHA256")]
        TlsDheDssWithAes256CbcSha256 = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_DSS_WITH_AES_128_CBC_SHA256")]
        TlsDheDssWithAes128CbcSha256 = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_DSS_WITH_AES_256_CBC_SHA")]
        TlsDheDssWithAes256CbcSha = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_DSS_WITH_AES_128_CBC_SHA")]
        TlsDheDssWithAes128CbcSha = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_3DES_EDE_CBC_SHA")]
        TlsRsaWith3DesEdeCbcSha = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA")]
        TlsDheDssWith3DesEdeCbcSha = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256")]
        TlsECDiffieHellmanRsaWithAes128GcmSha256 = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384")]
        TlsECDiffieHellmanRsaWithAes256GcmSha384 = 27,
    }
    public partial class ApplicationGatewaySslPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewaySslPolicy() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewaySslCipherSuite> CipherSuites { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewaySslProtocol> DisabledSslProtocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySslProtocol> MinProtocolVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySslPolicyName> PolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewaySslPolicyType> PolicyType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewaySslPolicyName
    {
        AppGwSslPolicy20150501 = 0,
        AppGwSslPolicy20170401 = 1,
        AppGwSslPolicy20170401S = 2,
        AppGwSslPolicy20220101 = 3,
        AppGwSslPolicy20220101S = 4,
    }
    public enum ApplicationGatewaySslPolicyType
    {
        Predefined = 0,
        Custom = 1,
        CustomV2 = 2,
    }
    public partial class ApplicationGatewaySslProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewaySslProfile() { }
        public Azure.Provisioning.Network.ApplicationGatewayClientAuthConfiguration ClientAuthConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.ApplicationGatewaySslPolicy SslPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> TrustedClientCertificates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewaySslProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1_0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1_1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1_2")]
        Tls1_2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1_3")]
        TLSv13 = 3,
    }
    public enum ApplicationGatewayTier
    {
        Standard = 0,
        WAF = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_v2")]
        StandardV2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WAF_v2")]
        WAFV2 = 3,
        Basic = 4,
    }
    public partial class ApplicationGatewayTrustedClientCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayTrustedClientCertificate() { }
        public Azure.Provisioning.BicepValue<string> ClientCertIssuerDN { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ValidatedCertData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayTrustedRootCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayTrustedRootCertificate() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationGatewayUnAuthorizedRequestAction
    {
        Deny = 0,
        Allow = 1,
    }
    public partial class ApplicationGatewayUrlConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayUrlConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ModifiedPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedQueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Reroute { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayUrlPathMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayUrlPathMap() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultBackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultBackendHttpSettingsId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultLoadDistributionPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultRedirectConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultRewriteRuleSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayPathRule> PathRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayWebApplicationFirewallConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayWebApplicationFirewallConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayFirewallDisabledRuleGroup> DisabledRuleGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayFirewallExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FileUploadLimitInMb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayFirewallMode> FirewallMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRequestBodySize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRequestBodySizeInKb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequestBodyCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationRule : Azure.Provisioning.Network.FirewallPolicyRule
    {
        public ApplicationRule() { }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FqdnTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyHttpHeaderToInsert> HttpHeadersToInsert { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRuleApplicationProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetFqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetUrls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TerminateTLS { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> WebCategories { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationSecurityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ApplicationSecurityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum AuthorizationUseStatus
    {
        Available = 0,
        InUse = 1,
    }
    public enum AutoLearnPrivateRangesMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class AzureFirewall : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureFirewall(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallApplicationRuleCollectionData> ApplicationRuleCollections { get { throw null; } set { } }
        public Azure.Provisioning.Network.AzureFirewallAutoscaleConfiguration AutoscaleConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FirewallPolicyId { get { throw null; } set { } }
        public Azure.Provisioning.Network.HubIPAddresses HubIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallIPGroups> IPGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Network.AzureFirewallIPConfiguration ManagementIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNatRuleCollectionData> NatRuleCollections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNetworkRuleCollectionData> NetworkRuleCollections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.AzureFirewallSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallThreatIntelMode> ThreatIntelMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.AzureFirewall FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class AzureFirewallApplicationRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallApplicationRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FqdnTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallApplicationRuleProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetFqdns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallApplicationRuleCollectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallApplicationRuleCollectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallRCActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallApplicationRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallApplicationRuleProtocol : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallApplicationRuleProtocol() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallApplicationRuleProtocolType> ProtocolType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFirewallApplicationRuleProtocolType
    {
        Http = 0,
        Https = 1,
        Mssql = 2,
    }
    public partial class AzureFirewallAutoscaleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallAutoscaleConfiguration() { }
        public Azure.Provisioning.BicepValue<int> MaxCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCapacity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallIPGroups : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallIPGroups() { }
        public Azure.Provisioning.BicepValue<string> ChangeNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFirewallNatRCActionType
    {
        Snat = 0,
        Dnat = 1,
    }
    public partial class AzureFirewallNatRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallNatRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNetworkRuleProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedFqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallNatRuleCollectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallNatRuleCollectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallNatRCActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNatRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallNetworkRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationFqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNetworkRuleProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFirewallNetworkRuleCollectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallNetworkRuleCollectionData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallRCActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallNetworkRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFirewallNetworkRuleProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        Any = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 3,
    }
    public partial class AzureFirewallPublicIPAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallPublicIPAddress() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFirewallRCActionType
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class AzureFirewallSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFirewallSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFirewallSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AZFW_VNet")]
        AzfwVnet = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AZFW_Hub")]
        AzfwHub = 1,
    }
    public enum AzureFirewallSkuTier
    {
        Standard = 0,
        Premium = 1,
        Basic = 2,
    }
    public enum AzureFirewallThreatIntelMode
    {
        Alert = 0,
        Deny = 1,
        Off = 2,
    }
    public partial class BackendAddressPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackendAddressPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> BackendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DrainPeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancerBackendAddress> LoadBalancerBackendAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OutboundRuleId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.BackendAddressSyncMode> SyncMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterface> TunnelInterfaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BackendAddressPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum BackendAddressSyncMode
    {
        Automatic = 0,
        Manual = 1,
    }
    public partial class BaseAdminRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BaseAdminRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.AdminRuleGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BaseAdminRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class BastionHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BastionHost(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> DisableCopyPaste { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFileCopy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableIPConnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableKerberos { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateOnlyBastion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSessionRecording { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableShareableLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTunneling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BastionHostIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BastionHostIPRule> NetworkAclsIPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ScaleUnits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.BastionHostSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BastionHost FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class BastionHostIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BastionHostIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BastionHostIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BastionHostIPRule() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BastionHostSkuName
    {
        Basic = 0,
        Standard = 1,
        Developer = 2,
        Premium = 3,
    }
    public partial class BgpConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BgpConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.HubBgpConnectionStatus> ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HubVirtualNetworkConnectionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PeerAsn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeerIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BgpConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class BgpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BgpSettings() { }
        public Azure.Provisioning.BicepValue<long> Asn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BgpPeeringAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfigurationBgpPeeringAddress> BgpPeeringAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PeerWeight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BreakOutCategoryPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BreakOutCategoryPolicies() { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Optimize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CertificateAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CertificateAuthentication() { }
        public Azure.Provisioning.BicepList<string> InboundAuthCertificateChain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InboundAuthCertificateSubjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> OutboundAuthCertificate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CidrAdvertisingGeoCode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GLOBAL")]
        Global = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AFRI")]
        Afri = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="APAC")]
        Apac = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="EURO")]
        Euro = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="LATAM")]
        Latam = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NAM")]
        Nam = 5,
        ME = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OCEANIA")]
        Oceania = 7,
        AQ = 8,
    }
    public enum CircuitConnectionStatus
    {
        Connected = 0,
        Connecting = 1,
        Disconnected = 2,
    }
    public enum CommissionedState
    {
        Provisioning = 0,
        Provisioned = 1,
        Commissioning = 2,
        CommissionedNoInternetAdvertise = 3,
        Commissioned = 4,
        Decommissioning = 5,
        Deprovisioning = 6,
        Deprovisioned = 7,
    }
    public enum ConnectedGroupAddressOverlap
    {
        Allowed = 0,
        Disallowed = 1,
    }
    public enum ConnectedGroupPrivateEndpointsScale
    {
        Standard = 0,
        HighScale = 1,
    }
    public enum ConnectionAuthenticationType
    {
        PSK = 0,
        Certificate = 1,
    }
    public partial class ConnectionMonitor : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ConnectionMonitor(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionMonitorType> ConnectionMonitorType { get { throw null; } }
        public Azure.Provisioning.Network.ConnectionMonitorDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorEndpoint> Endpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MonitoringIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MonitoringStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkWatcher? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.ConnectionMonitorSource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorTestConfiguration> TestConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorTestGroup> TestGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ConnectionMonitor FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ConnectionMonitorDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorDestination() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorEndpoint() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CoverageLevel> CoverageLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionMonitorEndpointType> EndpointType { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectionMonitorEndpointFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocationDetailsRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectionMonitorEndpointScope Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorEndpointFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorEndpointFilter() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionMonitorEndpointFilterType> FilterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorEndpointFilterItem> Items { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorEndpointFilterItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorEndpointFilterItem() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionMonitorEndpointFilterItemType> ItemType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectionMonitorEndpointFilterItemType
    {
        AgentAddress = 0,
    }
    public enum ConnectionMonitorEndpointFilterType
    {
        Include = 0,
    }
    public partial class ConnectionMonitorEndpointScope : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorEndpointScope() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorEndpointScopeItem> Exclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectionMonitorEndpointScopeItem> Include { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorEndpointScopeItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorEndpointScopeItem() { }
        public Azure.Provisioning.BicepValue<string> Address { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectionMonitorEndpointType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureVM")]
        AzureVm = 0,
        AzureVNet = 1,
        AzureSubnet = 2,
        ExternalAddress = 3,
        MMAWorkspaceMachine = 4,
        MMAWorkspaceNetwork = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureArcVM")]
        AzureArcVm = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureVMSS")]
        AzureVmss = 7,
        AzureArcNetwork = 8,
    }
    public partial class ConnectionMonitorHttpConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorHttpConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkHttpConfigurationMethod> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreferHttps { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkWatcherHttpHeader> RequestHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ValidStatusCodeRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorOutput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorOutput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.OutputType> OutputType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorSource() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorSuccessThreshold : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorSuccessThreshold() { }
        public Azure.Provisioning.BicepValue<int> ChecksFailedPercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RoundTripTimeMs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorTcpConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorTcpConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DestinationPortBehavior> DestinationPortBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableTraceRoute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionMonitorTestConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorTestConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> DisableTraceRoute { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectionMonitorHttpConfiguration HttpConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.TestEvalPreferredIPVersion> PreferredIPVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionMonitorTestConfigurationProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectionMonitorSuccessThreshold SuccessThreshold { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectionMonitorTcpConfiguration TcpConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TestFrequencySec { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectionMonitorTestConfigurationProtocol
    {
        Tcp = 0,
        Http = 1,
        Icmp = 2,
    }
    public partial class ConnectionMonitorTestGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionMonitorTestGroup() { }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Disable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Sources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TestConfigurations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectionMonitorType
    {
        MultiEndpoint = 0,
        SingleSourceDestination = 1,
    }
    public partial class ConnectivityConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ConnectivityConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectivityGroupItem> AppliesToGroups { get { throw null; } set { } }
        public Azure.Provisioning.Network.ConnectivityConfigurationPropertiesConnectivityCapabilities ConnectivityCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectivityTopology> ConnectivityTopology { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DeleteExistingPeering> DeleteExistingPeering { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ConnectivityHub> Hubs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GlobalMeshSupportFlag> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ConnectivityConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ConnectivityConfigurationPropertiesConnectivityCapabilities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectivityConfigurationPropertiesConnectivityCapabilities() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectedGroupAddressOverlap> ConnectedGroupAddressOverlap { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectedGroupPrivateEndpointsScale> ConnectedGroupPrivateEndpointsScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PeeringEnforcement> PeeringEnforcement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectivityGroupItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectivityGroupItem() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GroupConnectivity> GroupConnectivity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GlobalMeshSupportFlag> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetworkGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.HubGatewayUsageFlag> UseHubGateway { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectivityHub : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectivityHub() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectivityTopology
    {
        HubAndSpoke = 0,
        Mesh = 1,
    }
    public partial class ContainerNetworkInterface : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerNetworkInterface() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ContainerId { get { throw null; } set { } }
        public Azure.Provisioning.Network.ContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ContainerNetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerNetworkInterfaceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerNetworkInterfaceConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ContainerNetworkInterfaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfigurationProfile> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerNetworkInterfaceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerNetworkInterfaceIPConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ContainerNetworkInterfaceIpConfigurationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CoverageLevel
    {
        Default = 0,
        Low = 1,
        BelowAverage = 2,
        Average = 3,
        AboveAverage = 4,
        Full = 5,
    }
    public partial class CrossTenantScopes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CrossTenantScopes() { }
        public Azure.Provisioning.BicepList<string> ManagementGroups { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Subscriptions { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomDnsConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDnsConfigProperties() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomIPPrefix : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CustomIPPrefix(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Asn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ChildCustomIPPrefixList { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Cidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CommissionedState> CommissionedState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> ExpressRouteAdvertise { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailedReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CidrAdvertisingGeoCode> Geo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NoInternetAdvertise { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ParentCustomIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CustomIPPrefixType> PrefixType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixes { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SignedMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.CustomIPPrefix FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum CustomIPPrefixType
    {
        Singular = 0,
        Parent = 1,
        Child = 2,
    }
    public partial class DdosCustomPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DdosCustomPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.DdosDetectionRule> DetectionRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> FrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.DdosCustomPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum DdosCustomPolicyProtocol
    {
        Tcp = 0,
        Udp = 1,
        Syn = 2,
    }
    public enum DdosCustomPolicyTriggerSensitivityOverride
    {
        Relaxed = 0,
        Low = 1,
        Default = 2,
        High = 3,
    }
    public enum DdosDetectionMode
    {
        TrafficThreshold = 0,
    }
    public partial class DdosDetectionRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DdosDetectionRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DdosDetectionMode> DetectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.TrafficDetectionRule TrafficDetectionRule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DdosProtectionPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DdosProtectionPlan(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualNetworks { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.DdosProtectionPlan FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class DdosSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DdosSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DdosProtectionPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DdosSettingsProtectionMode> ProtectionMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DdosSettingsProtectionCoverage
    {
        Basic = 0,
        Standard = 1,
    }
    public enum DdosSettingsProtectionMode
    {
        VirtualNetworkInherited = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum DdosTrafficType
    {
        Tcp = 0,
        Udp = 1,
        TcpSyn = 2,
    }
    public enum DeleteExistingPeering
    {
        False = 0,
        True = 1,
    }
    public enum DestinationPortBehavior
    {
        None = 0,
        ListenIfAvailable = 1,
    }
    public partial class DeviceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeviceProperties() { }
        public Azure.Provisioning.BicepValue<string> DeviceModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeviceVendor { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LinkSpeedInMbps { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DHGroup
    {
        None = 0,
        DHGroup1 = 1,
        DHGroup2 = 2,
        DHGroup14 = 3,
        DHGroup2048 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECP256")]
        Ecp256 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECP384")]
        Ecp384 = 6,
        DHGroup24 = 7,
    }
    public enum DisableBgpRoutePropagation
    {
        False = 0,
        True = 1,
    }
    public partial class DnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsSettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireProxyForNetworkRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Servers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DscpConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DscpConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> AssociatedNetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosIPRange> DestinationIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosPortRange> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Markings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProtocolType> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QosCollectionId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.DscpQosDefinition> QosDefinitionCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosIPRange> SourceIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosPortRange> SourcePortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.DscpConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class DscpQosDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DscpQosDefinition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosIPRange> DestinationIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosPortRange> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Markings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProtocolType> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosIPRange> SourceIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.QosPortRange> SourcePortRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExceptionEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExceptionEntry() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExclusionManagedRuleSet> ExceptionManagedRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExceptionEntryMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExceptionEntrySelectorMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExceptionEntryValueMatchOperator> ValueMatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExceptionEntryMatchVariable
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="RequestURI")]
        RequestUri = 0,
        RemoteAddr = 1,
        RequestHeader = 2,
    }
    public enum ExceptionEntrySelectorMatchOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        Contains = 1,
        StartsWith = 2,
        EndsWith = 3,
    }
    public enum ExceptionEntryValueMatchOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        Contains = 1,
        StartsWith = 2,
        EndsWith = 3,
        IPMatch = 4,
    }
    public partial class ExclusionManagedRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExclusionManagedRule() { }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExclusionManagedRuleGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExclusionManagedRuleGroup() { }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExclusionManagedRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExclusionManagedRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExclusionManagedRuleSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExclusionManagedRuleGroup> RuleGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExpressRouteCircuit : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCircuit(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowClassicOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCircuitAuthorization> Authorizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> BandwidthInGbps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CircuitProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDirectPortRateLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRoutePortId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GatewayManagerETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> GlobalReachEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCircuitPeering> Peerings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceProviderNotes { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuitServiceProviderProperties ServiceProviderProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ServiceProviderProvisioningState> ServiceProviderProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuitSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> STag { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCircuit FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteCircuitAuthorization : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCircuitAuthorization(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AuthorizationUseStatus> AuthorizationUseStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ConnectionResourceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuit? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCircuitAuthorization FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteCircuitConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCircuitConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CircuitConnectionStatus> CircuitConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteCircuitPeeringId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Network.IPv6CircuitConnectionConfig IPv6CircuitConnectionConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuitPeering? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PeerExpressRouteCircuitPeeringId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCircuitConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteCircuitPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCircuitPeering(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AzureASN { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCircuitConnection> Connections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteConnectionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GatewayManagerETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Network.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.Network.ExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuit? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PeerASN { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PeerExpressRouteCircuitConnectionData> PeeredConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePeeringType> PeeringType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryAzurePort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RouteFilterId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryAzurePort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePeeringState> State { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCircuitStats Stats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VlanId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCircuitPeering FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
    {
        NotConfigured = 0,
        Configuring = 1,
        Configured = 2,
        ValidationNeeded = 3,
    }
    public partial class ExpressRouteCircuitPeeringConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteCircuitPeeringConfig() { }
        public Azure.Provisioning.BicepList<string> AdvertisedCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AdvertisedPublicPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState> AdvertisedPublicPrefixesState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AdvertisedPublicPrefixProperties> AdvertisedPublicPrefixInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CustomerASN { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LegacyMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoutingRegistryName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExpressRouteCircuitPeeringState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ExpressRouteCircuitServiceProviderProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteCircuitServiceProviderProperties() { }
        public Azure.Provisioning.BicepValue<int> BandwidthInMbps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeeringLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceProviderName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExpressRouteCircuitSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteCircuitSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteCircuitSkuFamily> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteCircuitSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExpressRouteCircuitSkuFamily
    {
        UnlimitedData = 0,
        MeteredData = 1,
    }
    public enum ExpressRouteCircuitSkuTier
    {
        Standard = 0,
        Premium = 1,
        Basic = 2,
        Local = 3,
    }
    public partial class ExpressRouteCircuitStats : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteCircuitStats() { }
        public Azure.Provisioning.BicepValue<long> PrimarybytesIn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PrimarybytesOut { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SecondarybytesIn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SecondarybytesOut { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExpressRouteConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableInternetSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateLinkFastPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteCircuitPeeringId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ExpressRouteGatewayBypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.RoutingConfiguration RoutingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RoutingWeight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteCrossConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCrossConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> BandwidthInMbps { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteCircuitId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeeringLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCrossConnectionPeering> Peerings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryAzurePort { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryAzurePort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceProviderNotes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ServiceProviderProvisioningState> ServiceProviderProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> STag { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCrossConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteCrossConnectionPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteCrossConnectionPeering(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AzureASN { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GatewayManagerETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Network.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.Network.ExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteCrossConnection? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PeerASN { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePeeringType> PeeringType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryAzurePort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryAzurePort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePeeringState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VlanId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteCrossConnectionPeering FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRouteGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRouteGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowNonVirtualWanTraffic { get { throw null; } set { } }
        public Azure.Provisioning.Network.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds AutoScaleBounds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteConnection> ExpressRouteConnectionList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRouteGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ExpressRouteGatewayAdminState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds() { }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Min { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExpressRouteGatewayResiliencyModel
    {
        SingleHomed = 0,
        MultiHomed = 1,
    }
    public enum ExpressRouteLinkAdminState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ExpressRouteLinkConnectorType
    {
        LC = 0,
        SC = 1,
    }
    public partial class ExpressRouteLinkData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteLinkData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteLinkAdminState> AdminState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ColoLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteLinkConnectorType> ConnectorType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InterfaceName { get { throw null; } }
        public Azure.Provisioning.Network.ExpressRouteLinkMacSecConfig MacSecConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PatchPanelId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RackId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RouterName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExpressRouteLinkMacSecCipher
    {
        GcmAes256 = 0,
        GcmAes128 = 1,
        GcmAesXpn128 = 2,
        GcmAesXpn256 = 3,
    }
    public partial class ExpressRouteLinkMacSecConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpressRouteLinkMacSecConfig() { }
        public Azure.Provisioning.BicepValue<string> CakSecretIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteLinkMacSecCipher> Cipher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CknSecretIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteLinkMacSecSciState> SciState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExpressRouteLinkMacSecSciState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ExpressRoutePeeringState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ExpressRoutePeeringType
    {
        AzurePublicPeering = 0,
        AzurePrivatePeering = 1,
        MicrosoftPeering = 2,
    }
    public partial class ExpressRoutePort : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRoutePort(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AllocationDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> BandwidthInGbps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePortsBillingType> BillingType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Circuits { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePortsEncapsulation> Encapsulation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EtherType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteLinkData> Links { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mtu { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeeringLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> ProvisionedBandwidthInGbps { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRoutePort FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ExpressRoutePortAuthorization : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExpressRoutePortAuthorization(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRoutePortAuthorizationUseStatus> AuthorizationUseStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> CircuitResourceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ExpressRoutePortAuthorization FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ExpressRoutePortAuthorizationUseStatus
    {
        Available = 0,
        InUse = 1,
    }
    public enum ExpressRoutePortsBillingType
    {
        MeteredData = 0,
        UnlimitedData = 1,
    }
    public enum ExpressRoutePortsEncapsulation
    {
        Dot1Q = 0,
        QinQ = 1,
    }
    public partial class FirewallPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FirewallPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowSqlRedirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BasePolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ChildPolicies { get { throw null; } }
        public Azure.Provisioning.Network.DnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Network.FirewallPolicyExplicitProxy ExplicitProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Firewalls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyInsights Insights { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyIntrusionDetection IntrusionDetection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RuleCollectionGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicySkuTier> SkuTier { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicySnat Snat { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallThreatIntelMode> ThreatIntelMode { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyCertificateAuthority TransportSecurityCertificateAuthority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class FirewallPolicyCertificateAuthority : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyCertificateAuthority() { }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyDraft : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FirewallPolicyDraft(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowSqlRedirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BasePolicyId { get { throw null; } set { } }
        public Azure.Provisioning.Network.DnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyExplicitProxy ExplicitProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Network.FirewallPolicyInsights Insights { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyIntrusionDetection IntrusionDetection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicy? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicySnat Snat { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallThreatIntelMode> ThreatIntelMode { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FirewallPolicyDraft FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class FirewallPolicyExplicitProxy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyExplicitProxy() { }
        public Azure.Provisioning.BicepValue<bool> EnableExplicitProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePacFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PacFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacFilePort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyFilterRuleCollectionActionType
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class FirewallPolicyFilterRuleCollectionInfo : Azure.Provisioning.Network.FirewallPolicyRuleCollectionInfo
    {
        public FirewallPolicyFilterRuleCollectionInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyFilterRuleCollectionActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyHttpHeaderToInsert : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyHttpHeaderToInsert() { }
        public Azure.Provisioning.BicepValue<string> HeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyInsights : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyInsights() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyLogAnalyticsResources LogAnalyticsResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetection() { }
        public Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionStateType> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionProfileType> Profile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetectionBypassTrafficSpecifications : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionBypassTrafficSpecifications() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetectionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> BypassTrafficSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrivateRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionSignatureSpecification> SignatureOverrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyIntrusionDetectionProfileType
    {
        Basic = 0,
        Standard = 1,
        Advanced = 2,
        Off = 3,
        Emerging = 4,
        Core = 5,
        Extended = 6,
    }
    public enum FirewallPolicyIntrusionDetectionProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ANY")]
        Any = 3,
    }
    public partial class FirewallPolicyIntrusionDetectionSignatureSpecification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionSignatureSpecification() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionStateType> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyIntrusionDetectionStateType
    {
        Off = 0,
        Alert = 1,
        Deny = 2,
    }
    public partial class FirewallPolicyLogAnalyticsResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyLogAnalyticsResources() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultWorkspaceIdId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyLogAnalyticsWorkspace> Workspaces { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyLogAnalyticsWorkspace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyLogAnalyticsWorkspace() { }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceIdId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyNatRuleCollectionActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DNAT")]
        Dnat = 0,
    }
    public partial class FirewallPolicyNatRuleCollectionInfo : Azure.Provisioning.Network.FirewallPolicyRuleCollectionInfo
    {
        public FirewallPolicyNatRuleCollectionInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyNatRuleCollectionActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyRule() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyRuleApplicationProtocol : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyRuleApplicationProtocol() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyRuleApplicationProtocolType> ProtocolType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyRuleApplicationProtocolType
    {
        Http = 0,
        Https = 1,
    }
    public partial class FirewallPolicyRuleCollectionGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FirewallPolicyRuleCollectionGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicy? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRuleCollectionInfo> RuleCollections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FirewallPolicyRuleCollectionGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class FirewallPolicyRuleCollectionGroupDraft : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FirewallPolicyRuleCollectionGroupDraft(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyRuleCollectionGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRuleCollectionInfo> RuleCollections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FirewallPolicyRuleCollectionGroupDraft FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class FirewallPolicyRuleCollectionInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyRuleCollectionInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyRuleNetworkProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        Any = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 3,
    }
    public enum FirewallPolicySkuTier
    {
        Standard = 0,
        Premium = 1,
        Basic = 2,
    }
    public partial class FirewallPolicySnat : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicySnat() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AutoLearnPrivateRangesMode> AutoLearnPrivateRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrivateRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyThreatIntelWhitelist : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyThreatIntelWhitelist() { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowLog : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FlowLog(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnabledFilteringCriteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Network.FlowLogProperties Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkWatcher? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecordTypes { get { throw null; } set { } }
        public Azure.Provisioning.Network.RetentionPolicyParameters RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TargetResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FlowLog FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum FlowLogFormatType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 0,
    }
    public partial class FlowLogProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowLogProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FlowLogFormatType> FormatType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontendIPConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontendIPConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FrontendIPConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class GatewayCustomBgpIPAddressIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GatewayCustomBgpIPAddressIPConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CustomBgpIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPConfigurationId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GatewayLoadBalancerTunnelInterface : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GatewayLoadBalancerTunnelInterface() { }
        public Azure.Provisioning.BicepValue<int> Identifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterfaceType> InterfaceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GatewayLoadBalancerTunnelProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GatewayLoadBalancerTunnelInterfaceType
    {
        None = 0,
        Internal = 1,
        External = 2,
    }
    public enum GatewayLoadBalancerTunnelProtocol
    {
        None = 0,
        Native = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VXLAN")]
        Vxlan = 2,
    }
    public enum GlobalMeshSupportFlag
    {
        False = 0,
        True = 1,
    }
    public partial class GroupByUserSession : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupByUserSession() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GroupByVariable> GroupByVariables { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GroupByVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupByVariable() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayFirewallUserSessionVariable> VariableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GroupConnectivity
    {
        None = 0,
        DirectlyConnected = 1,
    }
    public partial class HeaderValueMatcher : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HeaderValueMatcher() { }
        public Azure.Provisioning.BicepValue<bool> IgnoreCase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Negate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Pattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HubBgpConnectionStatus
    {
        Unknown = 0,
        Connecting = 1,
        Connected = 2,
        NotConnected = 3,
    }
    public enum HubGatewayUsageFlag
    {
        False = 0,
        True = 1,
    }
    public partial class HubIPAddresses : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HubIPAddresses() { }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.HubPublicIPAddresses PublicIPs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubIPConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HubIPConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.HubIPConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class HubPublicIPAddresses : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HubPublicIPAddresses() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AzureFirewallPublicIPAddress> Addresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HubRoute() { }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHop { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubRouteTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HubRouteTable(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AssociatedConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PropagatingConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.HubRoute> Routes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.HubRouteTable FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum HubRoutingPreference
    {
        ExpressRoute = 0,
        VpnGateway = 1,
        ASPath = 2,
    }
    public partial class HubVirtualNetworkConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HubVirtualNetworkConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowHubToRemoteVnetTransit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowRemoteVnetToUseHubVnetGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableInternetSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.Network.RoutingConfiguration RoutingConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.HubVirtualNetworkConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum IkeEncryption
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DES")]
        Des = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DES3")]
        Des3 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES128")]
        Aes128 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES192")]
        Aes192 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES256")]
        Aes256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES256")]
        GcmAes256 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES128")]
        GcmAes128 = 6,
    }
    public enum IkeIntegrity
    {
        MD5 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA1")]
        Sha1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA256")]
        Sha256 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA384")]
        Sha384 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES256")]
        GcmAes256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES128")]
        GcmAes128 = 5,
    }
    public partial class InboundNatRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InboundNatRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfiguration BackendIPConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.InboundNatRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class InboundSecurityRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InboundSecurityRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVirtualAppliance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundSecurityRules> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.InboundSecurityRuleType> RuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.InboundSecurityRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class InboundSecurityRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InboundSecurityRules() { }
        public Azure.Provisioning.BicepList<string> AppliesOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DestinationPortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.InboundSecurityRulesProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceAddressPrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InboundSecurityRulesProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
    }
    public enum InboundSecurityRuleType
    {
        AutoExpire = 0,
        Permanent = 1,
    }
    public enum IPAddressDeleteOption
    {
        Delete = 0,
        Detach = 1,
    }
    public partial class IPAllocation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IPAllocation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> AllocationTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationType> IPAllocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IpamAllocationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PrefixLength { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrefixType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.IPAllocation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum IpamIPType
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class IpamPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IpamPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.IpamPoolProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.IpamPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class IpamPoolPrefixAllocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IpamPoolPrefixAllocation() { }
        public Azure.Provisioning.BicepList<string> AllocatedAddressPrefixes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfIPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IpamPoolProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IpamPoolProperties() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IpamIPType> IPAddressType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ParentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IPGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IPGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> FirewallPolicies { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Firewalls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.IPGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum IPsecEncryption
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DES")]
        Des = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DES3")]
        Des3 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES128")]
        Aes128 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES192")]
        Aes192 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AES256")]
        Aes256 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES128")]
        GcmAes128 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES192")]
        GcmAes192 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES256")]
        GcmAes256 = 8,
    }
    public enum IPsecIntegrity
    {
        MD5 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA1")]
        Sha1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA256")]
        Sha256 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA384")]
        Sha384 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES256")]
        GcmAes256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCMAES128")]
        GcmAes128 = 5,
    }
    public partial class IPsecPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IPsecPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DHGroup> DhGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IkeEncryption> IkeEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IkeIntegrity> IkeIntegrity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IPsecEncryption> IPsecEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IPsecIntegrity> IPsecIntegrity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PfsGroup> PfsGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SaDataSizeKilobytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SaLifeTimeSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IPv6CircuitConnectionConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IPv6CircuitConnectionConfig() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CircuitConnectionStatus> CircuitConnectionStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IPv6ExpressRouteCircuitPeeringConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IPv6ExpressRouteCircuitPeeringConfig() { }
        public Azure.Provisioning.Network.ExpressRouteCircuitPeeringConfig MicrosoftPeeringConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RouteFilterId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryPeerAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteCircuitPeeringState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadBalancer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LoadBalancer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BackendAddressPool> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancerInboundNatPool> InboundNatPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundNatRule> InboundNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancingRule> LoadBalancingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.OutboundRule> OutboundRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ProbeResource> Probes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerScope> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancerSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.LoadBalancer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class LoadBalancerBackendAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerBackendAddress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerBackendAddressAdminState> AdminState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NatRulePortMapping> InboundNatRulesPortMapping { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadBalancerFrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkInterfaceIPConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerBackendAddressAdminState
    {
        Drain = 0,
        None = 1,
        Up = 2,
        Down = 3,
    }
    public partial class LoadBalancerInboundNatPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerInboundNatPool() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancerInboundNatPoolProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadBalancerInboundNatPoolProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerInboundNatPoolProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerOutboundRuleProtocol
    {
        Tcp = 0,
        Udp = 1,
        All = 2,
    }
    public enum LoadBalancerScope
    {
        Public = 0,
        Private = 1,
    }
    public partial class LoadBalancerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerSkuName
    {
        Basic = 0,
        Standard = 1,
        Gateway = 2,
    }
    public enum LoadBalancerSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class LoadBalancingRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LoadBalancingRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancingRuleProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.LoadBalancingRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class LoadBalancingRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancingRuleProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableOutboundSnat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableConnectionTracking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadDistribution> LoadDistribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProbeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancingTransportProtocol
    {
        Udp = 0,
        Tcp = 1,
        All = 2,
        Quic = 3,
    }
    public enum LoadDistribution
    {
        Default = 0,
        SourceIP = 1,
        SourceIPProtocol = 2,
    }
    public partial class LocalNetworkGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LocalNetworkGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.BgpSettings BgpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GatewayIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.LocalNetworkGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ManagedRuleEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ManagedRuleGroupOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleGroupOverride() { }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ManagedRuleOverride> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RuleMatchActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ManagedRuleSensitivityType> Sensitivity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ManagedRuleEnabledState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRulesDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRulesDefinition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExceptionEntry> Exceptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.OwaspCrsExclusionEntry> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ManagedRuleSet> ManagedRuleSets { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedRuleSensitivityType
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    }
    public partial class ManagedRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ManagedRuleSetRuleGroup> ComputedDisabledRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ManagedRuleGroupOverride> RuleGroupOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleSetRuleGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleSetRuleGroup() { }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Rules { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementGroupNetworkManagerConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagementGroupNetworkManagerConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScopeConnectionState> ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkManagerId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ManagementGroupNetworkManagerConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class MatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.MatchVariable> MatchVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegationConditon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.WebApplicationFirewallTransform> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MatchVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MatchVariable() { }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallMatchVariable> VariableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NatGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NatGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddressesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NatGatewaySkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NatGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum NatGatewaySkuName
    {
        Standard = 0,
        StandardV2 = 1,
    }
    public partial class NatRule : Azure.Provisioning.Network.FirewallPolicyRule
    {
        public NatRule() { }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRuleNetworkProtocol> IPProtocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedFqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TranslatedPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NatRulePortMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NatRulePortMapping() { }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InboundNatRuleName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class NetworkAdminRule : Azure.Provisioning.Network.BaseAdminRule
    {
        public NetworkAdminRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Sources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkConfigurationDeploymentType
    {
        SecurityAdmin = 0,
        Connectivity = 1,
        SecurityUser = 2,
        Routing = 3,
    }
    public partial class NetworkDefaultAdminRule : Azure.Provisioning.Network.BaseAdminRule
    {
        public NetworkDefaultAdminRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleAccess> Access { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Destinations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleDirection> Direction { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Flag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleProtocol> Protocol { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Sources { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkGroupMemberType> MemberType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkGroupMemberType
    {
        VirtualNetwork = 0,
        Subnet = 1,
    }
    public partial class NetworkGroupStaticMember : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkGroupStaticMember(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkGroupStaticMember FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkHttpConfigurationMethod
    {
        Get = 0,
        Post = 1,
    }
    public enum NetworkIntentPolicyBasedService
    {
        None = 0,
        All = 1,
        AllowRulesOnly = 2,
    }
    public partial class NetworkInterface : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterface(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceAuxiliaryMode> AuxiliaryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceAuxiliarySku> AuxiliarySku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DefaultOutboundConnectivityEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableTcpStateTracking { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceDnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DscpConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableIPForwarding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostedWorkloads { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MacAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceNicType> NicType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } }
        public Azure.Provisioning.Network.PrivateEndpoint PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.Network.PrivateLinkService PrivateLinkService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfiguration> TapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> VnetEncryptionSupported { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterface FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkInterfaceAuxiliaryMode
    {
        None = 0,
        MaxConnections = 1,
        Floating = 2,
        AcceleratedConnections = 3,
    }
    public enum NetworkInterfaceAuxiliarySku
    {
        None = 0,
        A1 = 1,
        A2 = 2,
        A4 = 3,
        A8 = 4,
    }
    public partial class NetworkInterfaceDnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceDnsSettings() { }
        public Azure.Provisioning.BicepList<string> AppliedDnsServers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InternalDnsNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InternalDomainNameSuffix { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InternalFqdn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkInterfaceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterfaceIPConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> ApplicationSecurityGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BackendAddressPool> LoadBalancerBackendAddressPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundNatRule> LoadBalancerInboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterface? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PrivateIPAddressPrefixLength { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties PrivateLinkConnectionProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkTap> VirtualNetworkTaps { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterfaceIPConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties() { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequiredMemberName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkInterfaceMigrationPhase
    {
        None = 0,
        Prepare = 1,
        Commit = 2,
        Abort = 3,
        Committed = 4,
    }
    public enum NetworkInterfaceNicType
    {
        Standard = 0,
        Elastic = 1,
    }
    public partial class NetworkInterfaceTapConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterfaceTapConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterface? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkTap VirtualNetworkTap { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterfaceTapConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkIPAllocationMethod
    {
        Static = 0,
        Dynamic = 1,
    }
    public enum NetworkIPAllocationType
    {
        Undefined = 0,
        Hypernet = 1,
    }
    public partial class NetworkIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkIPConfigurationBgpPeeringAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkIPConfigurationBgpPeeringAddress() { }
        public Azure.Provisioning.BicepList<string> CustomBgpIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DefaultBgpIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TunnelIPAddresses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkIPConfigurationProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkIPConfigurationProfile() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkIPVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class NetworkManager : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManager(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkConfigurationDeploymentType> NetworkManagerScopeAccesses { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManagerPropertiesNetworkManagerScopes NetworkManagerScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManager FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerPropertiesNetworkManagerScopes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkManagerPropertiesNetworkManagerScopes() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.CrossTenantScopes> CrossTenantScopes { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ManagementGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Subscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkManagerRoutingConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerRoutingConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteTableUsageMode> RouteTableUsageMode { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerRoutingConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerRoutingGroupItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkManagerRoutingGroupItem() { }
        public Azure.Provisioning.BicepValue<string> NetworkGroupId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkManagerRoutingRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerRoutingRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Network.RoutingRuleRouteDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.RoutingRuleNextHop NextHop { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManagerRoutingRules? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerRoutingRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerRoutingRules : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerRoutingRules(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkManagerRoutingGroupItem> AppliesTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DisableBgpRoutePropagation> DisableBgpRoutePropagation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManagerRoutingConfiguration? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerRoutingRules FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerSecurityGroupItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkManagerSecurityGroupItem() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkGroupId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkManagerSecurityUserConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerSecurityUserConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerSecurityUserConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerSecurityUserRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerSecurityUserRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManagerSecurityUserRules? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityConfigurationRuleProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.AddressPrefixItem> Sources { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerSecurityUserRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkManagerSecurityUserRules : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkManagerSecurityUserRules(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityUserGroupItem> AppliesToGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManagerSecurityUserConfiguration? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkManagerSecurityUserRules FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateLinkService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateEndpoint PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkPrivateLinkServiceConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkPrivateLinkServiceConnection() { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkServiceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ContainerNetworkInterfaceConfiguration> ContainerNetworkInterfaceConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ContainerNetworkInterface> ContainerNetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkProtocol
    {
        Any = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 3,
    }
    public enum NetworkProvisioningState
    {
        Failed = 0,
        Succeeded = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class NetworkRule : Azure.Provisioning.Network.FirewallPolicyRule
    {
        public NetworkRule() { }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationFqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyRuleNetworkProtocol> IPProtocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRule> DefaultSecurityRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLog> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> FlushConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRule> SecurityRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkSecurityPerimeter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeter(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PerimeterGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeter FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkSecurityPerimeterAccessRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterAccessRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterAccessRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FullyQualifiedDomainNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkSecurityPerimeterBasedAccessRule> NetworkSecurityPerimeters { get { throw null; } }
        public Azure.Provisioning.Network.NetworkSecurityPerimeterProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PhoneNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ServiceTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Subscriptions { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeterAccessRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkSecurityPerimeterAccessRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public partial class NetworkSecurityPerimeterAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterAssociation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterAssociationAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HasProvisioningIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityPerimeter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProfileId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeterAssociation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkSecurityPerimeterAssociationAccessMode
    {
        Learning = 0,
        Enforced = 1,
        Audit = 2,
    }
    public partial class NetworkSecurityPerimeterBasedAccessRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterBasedAccessRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PerimeterGuid { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AutoApprovedRemotePerimeterResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> LocalInboundProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalOutboundProfiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityPerimeter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterLinkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RemoteInboundProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteOutboundProfiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> RemotePerimeterGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RemotePerimeterLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkSecurityPerimeterLinkStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeterLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkSecurityPerimeterLinkProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Accepted = 4,
        Failed = 5,
        WaitForRemoteCompletion = 6,
    }
    public enum NetworkSecurityPerimeterLinkStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class NetworkSecurityPerimeterLoggingConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterLoggingConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> EnabledLogCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityPerimeter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeterLoggingConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkSecurityPerimeterProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccessRulesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DiagnosticSettingsVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityPerimeter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityPerimeterProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum NetworkSecurityPerimeterProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Accepted = 4,
        Failed = 5,
    }
    public partial class NetworkVerifierIPTraffic : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkVerifierIPTraffic() { }
        public Azure.Provisioning.BicepList<string> DestinationIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourcePorts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkVerifierWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkVerifierWorkspace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVerifierWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkVerifierWorkspace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkVerifierWorkspaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkVerifierWorkspaceProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkVirtualAppliance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkVirtualAppliance(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualApplianceAdditionalNicProperties> AdditionalNics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } }
        public Azure.Provisioning.BicepList<string> BootStrapConfigurationBlobs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CloudInitConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CloudInitConfigurationBlobs { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualApplianceDelegationProperties Delegation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundSecurityRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InternetIngressPublicIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualApplianceNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NvaInterfaceConfigurationsProperties> NvaInterfaceConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualApplianceSkuProperties NvaSku { get { throw null; } set { } }
        public Azure.Provisioning.Network.PartnerManagedResourceProperties PartnerManagedResource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SshPublicKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> VirtualApplianceAsn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualApplianceConnections { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualApplianceNicProperties> VirtualApplianceNics { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualApplianceSites { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkVirtualAppliance FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkVirtualApplianceConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkVirtualApplianceConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<long> Asn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> BgpPeerAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.RoutingConfiguration ConnectionRoutingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableInternetSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesName { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVirtualAppliance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TunnelIdentifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkVirtualApplianceConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkWatcher : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkWatcher(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkWatcher FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class NetworkWatcherHttpHeader : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkWatcherHttpHeader() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NicTypeInRequest
    {
        PublicNic = 0,
        PrivateNic = 1,
    }
    public enum NicTypeInResponse
    {
        PublicNic = 0,
        PrivateNic = 1,
        AdditionalNic = 2,
    }
    public partial class NvaInterfaceConfigurationsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NvaInterfaceConfigurationsProperties() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NvaNicType> PropertiesType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NvaNicType
    {
        PrivateNic = 0,
        PublicNic = 1,
        AdditionalPrivateNic = 2,
        AdditionalPublicNic = 3,
    }
    public partial class O365BreakOutCategoryPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public O365BreakOutCategoryPolicies() { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Optimize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OfficeTrafficCategory
    {
        Optimize = 0,
        OptimizeAndAllow = 1,
        All = 2,
        None = 3,
    }
    public partial class OutboundRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OutboundRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AllocatedOutboundPorts { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> FrontendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerOutboundRuleProtocol> Protocol { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.OutboundRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum OutputType
    {
        Workspace = 0,
    }
    public partial class OwaspCrsExclusionEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OwaspCrsExclusionEntry() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExclusionManagedRuleSet> ExclusionManagedRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.OwaspCrsExclusionEntryMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.OwaspCrsExclusionEntrySelectorMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OwaspCrsExclusionEntryMatchVariable
    {
        RequestHeaderNames = 0,
        RequestCookieNames = 1,
        RequestArgNames = 2,
        RequestHeaderKeys = 3,
        RequestHeaderValues = 4,
        RequestCookieKeys = 5,
        RequestCookieValues = 6,
        RequestArgKeys = 7,
        RequestArgValues = 8,
    }
    public enum OwaspCrsExclusionEntrySelectorMatchOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        Contains = 1,
        StartsWith = 2,
        EndsWith = 3,
        EqualsAny = 4,
    }
    public partial class P2SConnectionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public P2SConnectionConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ConfigurationPolicyGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableInternetSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigurationPolicyGroup> PreviousConfigurationPolicyGroupAssociations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.RoutingConfiguration RoutingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace VpnClientAddressPool { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class P2SVpnGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public P2SVpnGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> CustomDnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRoutingPreferenceInternet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.P2SConnectionConfiguration> P2SConnectionConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnClientConnectionHealth VpnClientConnectionHealth { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> VpnGatewayScaleUnit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VpnServerConfigurationId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.P2SVpnGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class PacketCapture : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PacketCapture(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<long> BytesToCapturePerPacket { get { throw null; } set { } }
        public Azure.Provisioning.Network.PacketCaptureSettings CaptureSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PacketCaptureFilter> Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsContinuousCapture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkWatcher? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PacketCaptureMachineScope Scope { get { throw null; } set { } }
        public Azure.Provisioning.Network.PacketCaptureStorageLocation StorageLocation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PacketCaptureTargetType> TargetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeLimitInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TotalBytesPerSession { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PacketCapture FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class PacketCaptureFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PacketCaptureFilter() { }
        public Azure.Provisioning.BicepValue<string> LocalIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PcProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemoteIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemotePort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PacketCaptureMachineScope : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PacketCaptureMachineScope() { }
        public Azure.Provisioning.BicepList<string> Exclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Include { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PacketCaptureSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PacketCaptureSettings() { }
        public Azure.Provisioning.BicepValue<int> FileCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> FileSizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SessionTimeLimitInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PacketCaptureStorageLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PacketCaptureStorageLocation() { }
        public Azure.Provisioning.BicepValue<string> FilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoragePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PacketCaptureTargetType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureVM")]
        AzureVm = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureVMSS")]
        AzureVmss = 1,
    }
    public partial class PartnerManagedResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerManagedResourceProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InternalLoadBalancerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StandardLoadBalancerId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PcProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        Any = 2,
    }
    public partial class PeerExpressRouteCircuitConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PeerExpressRouteCircuitConnectionData() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> AuthResourceGuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.CircuitConnectionStatus> CircuitConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteCircuitPeeringId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PeerExpressRouteCircuitPeeringId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PeeringEnforcement
    {
        Unenforced = 0,
        Enforced = 1,
    }
    public enum PfsGroup
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFS1")]
        Pfs1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFS2")]
        Pfs2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFS2048")]
        Pfs2048 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECP256")]
        Ecp256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECP384")]
        Ecp384 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFS24")]
        Pfs24 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFS14")]
        Pfs14 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PFSMM")]
        Pfs = 8,
    }
    public partial class PolicySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicySettings() { }
        public Azure.Provisioning.BicepValue<int> CaptchaCookieExpirationInMins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomBlockResponseBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CustomBlockResponseStatusCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FileUploadEnforcement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FileUploadLimitInMb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> JsChallengeCookieExpirationInMins { get { throw null; } set { } }
        public Azure.Provisioning.Network.PolicySettingsLogScrubbing LogScrubbing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRequestBodySizeInKb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequestBodyCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequestBodyEnforcement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RequestBodyInspectLimitInKB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallEnabledState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PolicySettingsLogScrubbing : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicySettingsLogScrubbing() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.WebApplicationFirewallScrubbingRules> ScrubbingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallScrubbingState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PolicySignaturesOverridesForIdps : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PolicySignaturesOverridesForIdps(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicy? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Signatures { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PolicySignaturesOverridesForIdps FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum PreferredRoutingGateway
    {
        ExpressRoute = 0,
        VpnGateway = 1,
        None = 2,
    }
    public partial class PrivateDnsZoneConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsZoneConfig() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateDnsZoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RecordSet> RecordSets { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsZoneGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsZoneGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateDnsZoneConfig> PrivateDnsZoneConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PrivateDnsZoneGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class PrivateEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.CustomDnsConfigProperties> CustomDnsConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomNetworkInterfaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpointIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateEndpointIPVersionType> IPVersionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PrivateEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class PrivateEndpointIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointIPConfigurationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> PrivateIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateEndpointIPVersionType
    {
        IPv4 = 0,
        IPv6 = 1,
        DualStack = 2,
    }
    public enum PrivateEndpointVnetPolicy
    {
        Disabled = 0,
        Basic = 1,
    }
    public partial class PrivateLinkService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateLinkService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateLinkServiceAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Alias { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AutoApprovalSubscriptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableProxyProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateLinkServiceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FrontendIPConfiguration> LoadBalancerFrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VisibilitySubscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PrivateLinkService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum PrivateLinkServiceAccessMode
    {
        Default = 0,
        Restricted = 1,
    }
    public partial class PrivateLinkServiceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkServiceIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProbeNoHealthyBackendsBehavior
    {
        AllProbedDown = 0,
        AllProbedUp = 1,
    }
    public enum ProbeProtocol
    {
        Http = 0,
        Tcp = 1,
        Https = 2,
    }
    public partial class ProbeResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ProbeResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProbeNoHealthyBackendsBehavior> NoHealthyBackendsBehavior { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NumberOfProbes { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ProbeThreshold { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProbeProtocol> Protocol { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestPath { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ProbeResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class PropagatedRouteTable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PropagatedRouteTable() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Ids { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PropagatedRouteTableNfv : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PropagatedRouteTableNfv() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProtocolCustomSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProtocolCustomSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProtocolType
    {
        DoNotUse = 0,
        Icmp = 1,
        Tcp = 2,
        Udp = 3,
        Gre = 4,
        Esp = 5,
        Ah = 6,
        Vxlan = 7,
        All = 8,
    }
    public partial class PublicIPAddress : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PublicIPAddress(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.DdosSettings DdosSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IPAddressDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddressDnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkIPConfiguration IPConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddress LinkedPublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NatGateway NatGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress ServicePublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddressSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PublicIPAddress FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class PublicIPAddressDnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPAddressDnsSettings() { }
        public Azure.Provisioning.BicepValue<string> DomainNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressDnsSettingsDomainNameLabelScope> DomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReverseFqdn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPAddressDnsSettingsDomainNameLabelScope
    {
        TenantReuse = 0,
        SubscriptionReuse = 1,
        ResourceGroupReuse = 2,
        NoReuse = 3,
    }
    public enum PublicIPAddressMigrationPhase
    {
        None = 0,
        Prepare = 1,
        Commit = 2,
        Abort = 3,
        Committed = 4,
    }
    public partial class PublicIPAddressSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPAddressSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPAddressSkuName
    {
        Basic = 0,
        Standard = 1,
        StandardV2 = 2,
    }
    public enum PublicIPAddressSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class PublicIPPrefix : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PublicIPPrefix(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPPrefix { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadBalancerFrontendIPConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NatGateway NatGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PrefixLength { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> PublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPPrefixSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PublicIPPrefix FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class PublicIPPrefixSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPPrefixSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPPrefixSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPPrefixSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPPrefixSkuName
    {
        Standard = 0,
        StandardV2 = 1,
    }
    public enum PublicIPPrefixSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class QosIPRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QosIPRange() { }
        public Azure.Provisioning.BicepValue<string> EndIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartIP { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QosPortRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QosPortRange() { }
        public Azure.Provisioning.BicepValue<int> End { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Start { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RadiusServer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RadiusServer() { }
        public Azure.Provisioning.BicepValue<string> RadiusServerAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RadiusServerScore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RadiusServerSecret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReachabilityAnalysisIntent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ReachabilityAnalysisIntent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVerifierWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.ReachabilityAnalysisIntentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ReachabilityAnalysisIntent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ReachabilityAnalysisIntentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReachabilityAnalysisIntentProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DestinationResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVerifierIPTraffic IPTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReachabilityAnalysisRun : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ReachabilityAnalysisRun(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVerifierWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.ReachabilityAnalysisRunProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ReachabilityAnalysisRun FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ReachabilityAnalysisRunProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReachabilityAnalysisRunProperties() { }
        public Azure.Provisioning.BicepValue<string> AnalysisResult { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.Network.AnalysisRunIntentContent IntentContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IntentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecordSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecordSet() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecordSetName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecordType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Ttl { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceNavigationLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceNavigationLink() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Link { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> LinkedResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RetentionPolicyParameters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetentionPolicyParameters() { }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteCriterion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteCriterion() { }
        public Azure.Provisioning.BicepList<string> AsPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Community { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteMapMatchCondition> MatchCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RoutePrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteFilter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteFilter(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCircuitPeering> IPv6Peerings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ExpressRouteCircuitPeering> Peerings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteFilterRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteFilter FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class RouteFilterRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteFilterRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Communities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.RouteFilter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteFilterRuleType> RouteFilterRuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteFilterRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum RouteFilterRuleType
    {
        Community = 0,
    }
    public partial class RouteMap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteMap(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AssociatedInboundConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AssociatedOutboundConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteMapRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteMap FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class RouteMapAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteMapAction() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteMapActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteMapActionParameter> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteMapActionParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteMapActionParameter() { }
        public Azure.Provisioning.BicepList<string> AsPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Community { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RoutePrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RouteMapActionType
    {
        Unknown = 0,
        Remove = 1,
        Add = 2,
        Replace = 3,
        Drop = 4,
    }
    public enum RouteMapMatchCondition
    {
        Unknown = 0,
        Contains = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 2,
        NotContains = 3,
        NotEquals = 4,
    }
    public enum RouteMapNextStepBehavior
    {
        Unknown = 0,
        Continue = 1,
        Terminate = 2,
    }
    public partial class RouteMapRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteMapRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteMapAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteCriterion> MatchCriteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteMapNextStepBehavior> NextStepIfMatched { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RouteNextHopType
    {
        VirtualNetworkGateway = 0,
        VnetLocal = 1,
        Internet = 2,
        VirtualAppliance = 3,
        None = 4,
    }
    public partial class RouteResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasBgpOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteNextHopType> NextHopType { get { throw null; } set { } }
        public Azure.Provisioning.Network.RouteTable? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class RouteTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteTable(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> DisableBgpRoutePropagation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteResource> Routes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteTable FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum RouteTableUsageMode
    {
        ManagedOnly = 0,
        UseExisting = 1,
    }
    public partial class RouteTargetAddressPropertiesFormat : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteTargetAddressPropertiesFormat() { }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AssociatedRouteTableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InboundRouteMapId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OutboundRouteMapId { get { throw null; } set { } }
        public Azure.Provisioning.Network.PropagatedRouteTable PropagatedRouteTables { get { throw null; } set { } }
        public Azure.Provisioning.Network.VnetRoute VnetRoutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingConfigurationNfv : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingConfigurationNfv() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingConfigurationNfvSubResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingConfigurationNfvSubResource() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RoutingIntent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RoutingIntent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RoutingPolicy> RoutingPolicies { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RoutingIntent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class RoutingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingPolicy() { }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHop { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoutingRuleDestinationType
    {
        AddressPrefix = 0,
        ServiceTag = 1,
    }
    public partial class RoutingRuleNextHop : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingRuleNextHop() { }
        public Azure.Provisioning.BicepValue<string> NextHopAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RoutingRuleNextHopType> NextHopType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoutingRuleNextHopType
    {
        Internet = 0,
        NoNextHop = 1,
        VirtualAppliance = 2,
        VirtualNetworkGateway = 3,
        VnetLocal = 4,
    }
    public partial class RoutingRuleRouteDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RoutingRuleRouteDestination() { }
        public Azure.Provisioning.BicepValue<string> DestinationAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RoutingRuleDestinationType> DestinationType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RoutingState
    {
        None = 0,
        Provisioned = 1,
        Provisioning = 2,
        Failed = 3,
    }
    public enum RuleMatchActionType
    {
        AnomalyScoring = 0,
        Allow = 1,
        Block = 2,
        Log = 3,
        JSChallenge = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CAPTCHA")]
        Captcha = 5,
    }
    public partial class ScopeConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScopeConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScopeConnectionState> ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ScopeConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ScopeConnectionState
    {
        Connected = 0,
        Pending = 1,
        Conflict = 2,
        Revoked = 3,
        Rejected = 4,
    }
    public enum ScrubbingRuleEntryMatchOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        EqualsAny = 1,
    }
    public enum ScrubbingRuleEntryMatchVariable
    {
        RequestHeaderNames = 0,
        RequestCookieNames = 1,
        RequestArgNames = 2,
        RequestPostArgNames = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RequestJSONArgNames")]
        RequestJsonArgNames = 4,
        RequestIPAddress = 5,
    }
    public enum ScrubbingRuleEntryState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SecurityAdminConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityAdminConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIntentPolicyBasedService> ApplyOnNetworkIntentPolicyBasedServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AddressSpaceAggregationOption> NetworkGroupAddressSpaceAggregationOption { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkManager? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SecurityAdminConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum SecurityConfigurationRuleAccess
    {
        Allow = 0,
        Deny = 1,
        AlwaysAllow = 2,
    }
    public enum SecurityConfigurationRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public enum SecurityConfigurationRuleProtocol
    {
        Tcp = 0,
        Udp = 1,
        Icmp = 2,
        Esp = 3,
        Any = 4,
        Ah = 5,
    }
    public partial class SecurityPartnerProvider : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityPartnerProvider(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityPartnerProviderConnectionStatus> ConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityProviderName> SecurityProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SecurityPartnerProvider FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum SecurityPartnerProviderConnectionStatus
    {
        Unknown = 0,
        PartiallyConnected = 1,
        Connected = 2,
        NotConnected = 3,
    }
    public enum SecurityProviderName
    {
        ZScaler = 0,
        IBoss = 1,
        Checkpoint = 2,
    }
    public partial class SecurityRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> DestinationApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationPortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> SourceApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourcePortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SecurityRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum SecurityRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public enum SecurityRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public enum SecurityRuleProtocol
    {
        Tcp = 0,
        Udp = 1,
        Icmp = 2,
        Esp = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        Asterisk = 4,
        Ah = 5,
    }
    public partial class SecurityUserGroupItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityUserGroupItem() { }
        public Azure.Provisioning.BicepValue<string> NetworkGroupId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceAssociationLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAssociationLink() { }
        public Azure.Provisioning.BicepValue<bool> AllowDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Link { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> LinkedResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceDelegation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceDelegation() { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceEndpointPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceEndpointPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> ContextualServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicyDefinition> ServiceEndpointPolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ServiceEndpointPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class ServiceEndpointPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceEndpointPolicyDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ServiceEndpointPolicy? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ServiceResources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ServiceEndpointPolicyDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class ServiceEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceEndpointProperties() { }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkIdentifierId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.RouteTargetAddressPropertiesFormat RouteTargetAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.RouteTargetAddressPropertiesFormat RouteTargetAddressV6 { get { throw null; } set { } }
        public Azure.Provisioning.Network.ServiceGatewaySku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetwork VirtualNetwork { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ServiceGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ServiceGatewaySku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceGatewaySku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ServiceGatewaySkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ServiceGatewaySkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceGatewaySkuName
    {
        Standard = 0,
    }
    public enum ServiceGatewaySkuTier
    {
        Regional = 0,
    }
    public enum ServiceProviderProvisioningState
    {
        NotProvisioned = 0,
        Provisioning = 1,
        Provisioned = 2,
        Deprovisioning = 3,
    }
    public enum SharingScope
    {
        Tenant = 0,
        DelegatedServices = 1,
    }
    public partial class StaticCidr : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticCidr(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.IpamPool? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.StaticCidrProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.StaticCidr FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class StaticCidrProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticCidrProperties() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfIPAddressesToAllocate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TotalNumberOfIPAddresses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticRoute() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticRoutesConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticRoutesConfig() { }
        public Azure.Provisioning.BicepValue<bool> PropagateStaticRoutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VnetLocalRouteOverrideCriterion> VnetLocalRouteOverrideCriteria { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubnetResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubnetResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayIPConfiguration> ApplicationGatewayIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DefaultOutboundAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceDelegation> Delegations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IpamPoolPrefixAllocation> IpamPoolPrefixAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfigurationProfile> IPConfigurationProfiles { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NatGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetwork? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpoint> PrivateEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Purpose { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ResourceNavigationLink> ResourceNavigationLinks { get { throw null; } }
        public Azure.Provisioning.Network.RouteTable RouteTable { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceAssociationLink> ServiceAssociationLinks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicy> ServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointProperties> ServiceEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SharingScope> SharingScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SubnetResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class SubscriptionNetworkManagerConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubscriptionNetworkManagerConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScopeConnectionState> ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkManagerId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SubscriptionNetworkManagerConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum TestEvalPreferredIPVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class TrafficAnalyticsConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficAnalyticsConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrafficAnalyticsIntervalInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficDetectionRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficDetectionRule() { }
        public Azure.Provisioning.BicepValue<int> PacketsPerSecond { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DdosTrafficType> TrafficType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficSelectorPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficSelectorPolicy() { }
        public Azure.Provisioning.BicepList<string> LocalAddressRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteAddressRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TunnelConnectionHealth : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TunnelConnectionHealth() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionStatus> ConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> EgressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> IngressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastConnectionEstablishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tunnel { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceAdditionalNicProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceAdditionalNicProperties() { }
        public Azure.Provisioning.BicepValue<bool> HasPublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceDelegationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceDelegationProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceIPConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsPrimary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceNetworkInterfaceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceNetworkInterfaceConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NicTypeInRequest> NicType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualApplianceIPConfiguration> VirtualApplianceNetworkInterfaceIPConfigurations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceNicProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceNicProperties() { }
        public Azure.Provisioning.BicepValue<string> InstanceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NicTypeInResponse> NicType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicIPAddress { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualApplianceSite : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualApplianceSite(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.BreakOutCategoryPolicies O365BreakOutCategories { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkVirtualAppliance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualApplianceSite FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualApplianceSkuProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplianceSkuProperties() { }
        public Azure.Provisioning.BicepValue<string> BundledScaleUnit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketPlaceVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Vendor { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualHub(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowBranchToBranchTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AzureFirewallId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> BgpConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ExpressRouteGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.HubRoutingPreference> HubRoutingPreference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> P2SVpnGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PreferredRoutingGateway> PreferredRoutingGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RouteMaps { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualHubRoute> Routes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RoutingState> RoutingState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecurityPartnerProviderId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecurityProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualHubRouteTableV2> VirtualHubRouteTableV2S { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> VirtualRouterAsn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VirtualRouterAutoScaleMinCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VirtualRouterIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualWanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VpnGatewayId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualHub FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualHubRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualHubRoute() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualHubRouteTableV2 : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualHubRouteTableV2(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AttachedConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualHub? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualHubRouteV2> Routes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualHubRouteTableV2 FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualHubRouteV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualHubRouteV2() { }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NextHops { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetwork : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetwork(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace AddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities BgpCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DdosProtectionPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultPublicNatGatewayId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DhcpOptionsDnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDdosProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableVmProtection { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLog> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FlowTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkPeering> VirtualNetworkPeerings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetwork FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualNetworkAddressSpace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkAddressSpace() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IpamPoolPrefixAllocation> IpamPoolPrefixAllocations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkAppliance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkAppliance(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> BandwidthInGbps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkApplianceIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkAppliance FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualNetworkApplianceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkApplianceIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkBgpCommunities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkBgpCommunities() { }
        public Azure.Provisioning.BicepValue<string> RegionalCommunity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualNetworkCommunity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkEncryptionEnforcement> Enforcement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkEncryptionEnforcement
    {
        DropUnencrypted = 0,
        AllowUnencrypted = 1,
    }
    public partial class VirtualNetworkGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Active { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteGatewayAdminState> AdminState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowRemoteVnetTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVirtualWanTraffic { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkGatewayAutoScaleBounds AutoScaleBounds { get { throw null; } set { } }
        public Azure.Provisioning.Network.BgpSettings BgpSettings { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace CustomRoutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableIPSecReplayProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBgp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBgpRouteTranslationForNat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDnsForwarding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHighBandwidthVpnGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayDefaultSiteId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayType> GatewayType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InboundDnsForwardingEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkGatewayIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkGatewayNatRule> NatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ExpressRouteGatewayResiliencyModel> ResiliencyModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkGatewaySku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkGatewayMigrationStatus VirtualNetworkGatewayMigrationStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkGatewayPolicyGroup> VirtualNetworkGatewayPolicyGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VNetExtendedLocationResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnClientConfiguration VpnClientConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnGatewayGeneration> VpnGatewayGeneration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnType> VpnType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualNetworkGatewayAutoScaleBounds : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayAutoScaleBounds() { }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Min { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkGatewayConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkGatewayConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ConnectionAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorizationKey { get { throw null; } set { } }
        public Azure.Provisioning.Network.CertificateAuthentication CertificateAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionMode> ConnectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionProtocol> ConnectionProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionStatus> ConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionType> ConnectionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DpdTimeoutSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> EgressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EgressNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBgp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateLinkFastPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> ExpressRouteGatewayBypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> IngressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IngressNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPsecPolicy> IPsecPolicies { get { throw null; } set { } }
        public Azure.Provisioning.Network.LocalNetworkGateway LocalNetworkGateway2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PeerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RoutingWeight { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.TrafficSelectorPolicy> TrafficSelectorPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.TunnelConnectionHealth> TunnelConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionTunnelProperties> TunnelProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseLocalAzureIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePolicyBasedTrafficSelectors { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkGateway VirtualNetworkGateway1 { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkGateway VirtualNetworkGateway2 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkGatewayConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum VirtualNetworkGatewayConnectionMode
    {
        Default = 0,
        ResponderOnly = 1,
        InitiatorOnly = 2,
    }
    public enum VirtualNetworkGatewayConnectionProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IKEv2")]
        IkeV2 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IKEv1")]
        IkeV1 = 1,
    }
    public enum VirtualNetworkGatewayConnectionStatus
    {
        Unknown = 0,
        Connecting = 1,
        Connected = 2,
        NotConnected = 3,
    }
    public partial class VirtualNetworkGatewayConnectionTunnelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayConnectionTunnelProperties() { }
        public Azure.Provisioning.BicepValue<string> BgpPeeringAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TunnelIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkGatewayConnectionType
    {
        IPsec = 0,
        Vnet2Vnet = 1,
        ExpressRoute = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VPNClient")]
        VpnClient = 3,
    }
    public partial class VirtualNetworkGatewayIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkGatewayMigrationPhase
    {
        None = 0,
        Prepare = 1,
        PrepareSucceeded = 2,
        Execute = 3,
        ExecuteSucceeded = 4,
        Commit = 5,
        CommitSucceeded = 6,
        AbortSucceeded = 7,
        Abort = 8,
    }
    public enum VirtualNetworkGatewayMigrationState
    {
        None = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public partial class VirtualNetworkGatewayMigrationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayMigrationStatus() { }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayMigrationPhase> Phase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayMigrationState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkGatewayNatRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkGatewayNatRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnNatRuleMapping> ExternalMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnNatRuleMapping> InternalMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnNatRuleMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnNatRuleType> VpnNatRuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkGatewayNatRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualNetworkGatewayPolicyGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayPolicyGroup() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkGatewayPolicyGroupMember> PolicyMembers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VngClientConnectionConfigurations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkGatewayPolicyGroupMember : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewayPolicyGroupMember() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnPolicyMemberAttributeType> AttributeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AttributeValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkGatewaySku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkGatewaySku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewaySkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewaySkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkGatewaySkuName
    {
        Basic = 0,
        HighPerformance = 1,
        Standard = 2,
        UltraPerformance = 3,
        VpnGw1 = 4,
        VpnGw2 = 5,
        VpnGw3 = 6,
        VpnGw4 = 7,
        VpnGw5 = 8,
        VpnGw1AZ = 9,
        VpnGw2AZ = 10,
        VpnGw3AZ = 11,
        VpnGw4AZ = 12,
        VpnGw5AZ = 13,
        ErGw1AZ = 14,
        ErGw2AZ = 15,
        ErGw3AZ = 16,
        ErGwScale = 17,
    }
    public enum VirtualNetworkGatewaySkuTier
    {
        Basic = 0,
        HighPerformance = 1,
        Standard = 2,
        UltraPerformance = 3,
        VpnGw1 = 4,
        VpnGw2 = 5,
        VpnGw3 = 6,
        VpnGw4 = 7,
        VpnGw5 = 8,
        VpnGw1AZ = 9,
        VpnGw2AZ = 10,
        VpnGw3AZ = 11,
        VpnGw4AZ = 12,
        VpnGw5AZ = 13,
        ErGw1AZ = 14,
        ErGw2AZ = 15,
        ErGw3AZ = 16,
        ErGwScale = 17,
    }
    public enum VirtualNetworkGatewayType
    {
        Vpn = 0,
        ExpressRoute = 1,
        LocalGateway = 2,
    }
    public partial class VirtualNetworkPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkPeering(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowForwardedTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowGatewayTransit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVirtualNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AreCompleteVnetsPeered { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoNotVerifyRemoteGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnlyIPv6Peering { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetwork? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringState> PeeringState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringLevel> PeeringSyncLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities RemoteBgpCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption RemoteVirtualNetworkEncryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseRemoteGateways { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkPeering FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public enum VirtualNetworkPeeringLevel
    {
        FullyInSync = 0,
        RemoteNotInSync = 1,
        LocalNotInSync = 2,
        LocalAndRemoteNotInSync = 3,
    }
    public enum VirtualNetworkPeeringState
    {
        Initiated = 0,
        Connected = 1,
        Disconnected = 2,
    }
    public enum VirtualNetworkPrivateEndpointNetworkPolicy
    {
        Enabled = 0,
        Disabled = 1,
        NetworkSecurityGroupEnabled = 2,
        RouteTableEnabled = 3,
    }
    public enum VirtualNetworkPrivateLinkServiceNetworkPolicy
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class VirtualNetworkTap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkTap(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.FrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DestinationPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfiguration> NetworkInterfaceTapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkTap FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualRouter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualRouter(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostedGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostedSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Peerings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> VirtualRouterAsn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VirtualRouterIPs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualRouter FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualRouterPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualRouterPeering(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualRouter? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> PeerAsn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeerIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualRouterPeering FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VirtualWan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualWan(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowBranchToBranchTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVnetToVnetTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableVpnEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.OfficeTrafficCategory> Office365LocalBreakoutCategory { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualHubs { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualWanType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VpnSites { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualWan FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum VnetLocalRouteOverrideCriterion
    {
        Contains = 0,
        Equal = 1,
    }
    public partial class VnetRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VnetRoute() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> BgpConnections { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.StaticRoute> StaticRoutes { get { throw null; } set { } }
        public Azure.Provisioning.Network.StaticRoutesConfig StaticRoutesConfig { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VngClientConnectionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VngClientConnectionConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualNetworkGatewayPolicyGroups { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace VpnClientAddressPool { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VpnAuthenticationType
    {
        AAD = 0,
        Certificate = 1,
        Radius = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AAD")]
        Aad = 3,
    }
    public partial class VpnClientConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnClientConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AadAudience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AadIssuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AadTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RadiusServerAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RadiusServer> RadiusServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RadiusServerSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VngClientConnectionConfiguration> VngClientConnectionConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnAuthenticationType> VpnAuthenticationTypes { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace VpnClientAddressPool { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPsecPolicy> VpnClientIPsecPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnClientProtocol> VpnClientProtocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnClientRevokedCertificate> VpnClientRevokedCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnClientRootCertificate> VpnClientRootCertificates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnClientConnectionHealth : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnClientConnectionHealth() { }
        public Azure.Provisioning.BicepList<string> AllocatedIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalEgressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalIngressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> VpnClientConnectionsCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VpnClientProtocol
    {
        IkeV2 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SSTP")]
        Sstp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OpenVPN")]
        OpenVpn = 2,
    }
    public partial class VpnClientRevokedCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnClientRevokedCertificate() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnClientRootCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnClientRootCertificate() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PublicCertData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ConnectionBandwidth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnConnectionStatus> ConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DpdTimeoutSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> EgressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableBgp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableInternetSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableRateLimiting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> IngressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPsecPolicy> IPsecPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVpnSiteId { get { throw null; } set { } }
        public Azure.Provisioning.Network.RoutingConfiguration RoutingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RoutingWeight { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.TrafficSelectorPolicy> TrafficSelectorPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseLocalAzureIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePolicyBasedTrafficSelectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionProtocol> VpnConnectionProtocolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnSiteLinkConnectionData> VpnLinkConnections { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum VpnConnectionStatus
    {
        Unknown = 0,
        Connecting = 1,
        Connected = 2,
        NotConnected = 3,
    }
    public partial class VpnGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.BgpSettings BgpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnConnection> Connections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBgpRouteTranslationForNat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnGatewayIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRoutingPreferenceInternet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnGatewayNatRule> NatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualHubId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VpnGatewayScaleUnit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum VpnGatewayGeneration
    {
        None = 0,
        Generation1 = 1,
        Generation2 = 2,
    }
    public partial class VpnGatewayIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnGatewayIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicIPAddress { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnGatewayNatRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnGatewayNatRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EgressVpnSiteLinkConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnNatRuleMapping> ExternalMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IngressVpnSiteLinkConnections { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnNatRuleMapping> InternalMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnNatRuleMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnNatRuleType> VpnNatRuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnGatewayNatRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum VpnGatewayTunnelingProtocol
    {
        IkeV2 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OpenVPN")]
        OpenVpn = 1,
    }
    public partial class VpnLinkBgpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnLinkBgpSettings() { }
        public Azure.Provisioning.BicepValue<long> Asn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BgpPeeringAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VpnLinkConnectionMode
    {
        Default = 0,
        ResponderOnly = 1,
        InitiatorOnly = 2,
    }
    public partial class VpnLinkConnectionSharedKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnLinkConnectionSharedKey(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnLinkConnectionSharedKeyProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnLinkConnectionSharedKey FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VpnLinkConnectionSharedKeyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnLinkConnectionSharedKeyProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SharedKeyLength { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnLinkProviderProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnLinkProviderProperties() { }
        public Azure.Provisioning.BicepValue<string> LinkProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LinkSpeedInMbps { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnNatRuleMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnNatRuleMapping() { }
        public Azure.Provisioning.BicepValue<string> AddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PortRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VpnNatRuleMode
    {
        EgressSnat = 0,
        IngressSnat = 1,
    }
    public enum VpnNatRuleType
    {
        Static = 0,
        Dynamic = 1,
    }
    public enum VpnPolicyMemberAttributeType
    {
        CertificateGroupId = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AADGroupId")]
        AadGroupId = 1,
        RadiusAzureGroupId = 2,
    }
    public partial class VpnServerConfigRadiusClientRootCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnServerConfigRadiusClientRootCertificate() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnServerConfigRadiusServerRootCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnServerConfigRadiusServerRootCertificate() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PublicCertData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnServerConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnServerConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.AadAuthenticationParameters AadAuthenticationParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigurationPolicyGroup> ConfigurationPolicyGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.P2SVpnGateway> P2SVpnGateways { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigRadiusClientRootCertificate> RadiusClientRootCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RadiusServerAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigRadiusServerRootCertificate> RadiusServerRootCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RadiusServer> RadiusServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RadiusServerSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnAuthenticationType> VpnAuthenticationTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPsecPolicy> VpnClientIPsecPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigVpnClientRevokedCertificate> VpnClientRevokedCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigVpnClientRootCertificate> VpnClientRootCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnGatewayTunnelingProtocol> VpnProtocols { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnServerConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VpnServerConfigurationPolicyGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnServerConfigurationPolicyGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> P2SConnectionConfigurations { get { throw null; } }
        public Azure.Provisioning.Network.VpnServerConfiguration? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnServerConfigurationPolicyGroupMember> PolicyMembers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnServerConfigurationPolicyGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VpnServerConfigurationPolicyGroupMember : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnServerConfigurationPolicyGroupMember() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnPolicyMemberAttributeType> AttributeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AttributeValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnServerConfigVpnClientRevokedCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnServerConfigVpnClientRevokedCertificate() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnServerConfigVpnClientRootCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnServerConfigVpnClientRootCertificate() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PublicCertData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnSite : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VpnSite(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace AddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.BgpSettings BgpProperties { get { throw null; } set { } }
        public Azure.Provisioning.Network.DeviceProperties DeviceProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecuritySite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.O365BreakOutCategoryPolicies O365BreakOutCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SiteKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualWanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VpnSiteLinkData> VpnSiteLinks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VpnSite FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class VpnSiteLinkConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnSiteLinkConnectionData() { }
        public Azure.Provisioning.BicepValue<int> ConnectionBandwidth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnConnectionStatus> ConnectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DpdTimeoutSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> EgressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EgressNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBgp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableRateLimiting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> IngressBytesTransferred { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IngressNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPsecPolicy> IPsecPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RoutingWeight { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseLocalAzureIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePolicyBasedTrafficSelectors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkGatewayConnectionProtocol> VpnConnectionProtocolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayCustomBgpIPAddressIPConfiguration> VpnGatewayCustomBgpAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VpnLinkConnectionMode> VpnLinkConnectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VpnSiteLinkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VpnSiteLinkData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VpnSiteLinkData() { }
        public Azure.Provisioning.Network.VpnLinkBgpSettings BgpProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.VpnLinkProviderProperties LinkProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VpnType
    {
        PolicyBased = 0,
        RouteBased = 1,
    }
    public enum WebApplicationFirewallAction
    {
        Allow = 0,
        Block = 1,
        Log = 2,
        JSChallenge = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CAPTCHA")]
        Captcha = 4,
    }
    public partial class WebApplicationFirewallCustomRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebApplicationFirewallCustomRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GroupByUserSession> GroupByUserSession { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.MatchCondition> MatchConditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ApplicationGatewayFirewallRateLimitDuration> RateLimitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RateLimitThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallRuleType> RuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationFirewallEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum WebApplicationFirewallMatchVariable
    {
        RemoteAddr = 0,
        RequestMethod = 1,
        QueryString = 2,
        PostArgs = 3,
        RequestUri = 4,
        RequestHeaders = 5,
        RequestBody = 6,
        RequestCookies = 7,
    }
    public enum WebApplicationFirewallMode
    {
        Prevention = 0,
        Detection = 1,
    }
    public enum WebApplicationFirewallOperator
    {
        IPMatch = 0,
        Equal = 1,
        Contains = 2,
        LessThan = 3,
        GreaterThan = 4,
        LessThanOrEqual = 5,
        GreaterThanOrEqual = 6,
        BeginsWith = 7,
        EndsWith = 8,
        Regex = 9,
        GeoMatch = 10,
        Any = 11,
    }
    public partial class WebApplicationFirewallPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebApplicationFirewallPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> ApplicationGatewayForContainers { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGateway> ApplicationGateways { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.WebApplicationFirewallCustomRule> CustomRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> HttpListeners { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Network.ManagedRulesDefinition ManagedRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PathBasedRules { get { throw null; } }
        public Azure.Provisioning.Network.PolicySettings PolicySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.WebApplicationFirewallPolicyResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.WebApplicationFirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum WebApplicationFirewallPolicyResourceState
    {
        Creating = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
        Deleting = 5,
    }
    public enum WebApplicationFirewallRuleType
    {
        MatchRule = 0,
        RateLimitRule = 1,
        Invalid = 2,
    }
    public partial class WebApplicationFirewallScrubbingRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebApplicationFirewallScrubbingRules() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScrubbingRuleEntryMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScrubbingRuleEntryMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ScrubbingRuleEntryState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationFirewallScrubbingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum WebApplicationFirewallState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum WebApplicationFirewallTransform
    {
        Uppercase = 0,
        Lowercase = 1,
        Trim = 2,
        UrlDecode = 3,
        UrlEncode = 4,
        RemoveNulls = 5,
        HtmlEntityDecode = 6,
    }
}
