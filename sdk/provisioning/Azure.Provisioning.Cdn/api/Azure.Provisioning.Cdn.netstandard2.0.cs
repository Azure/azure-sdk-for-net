namespace Azure.Provisioning.Cdn
{
    public enum AfdCipherSuiteSetType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS10_2019")]
        Tls1_0_2019 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS12_2022")]
        Tls1_2_2022 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS12_2023")]
        Tls1_2_2023 = 2,
        Customized = 3,
    }
    public enum AfdCustomizedCipherSuiteForTls12
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECDHE_RSA_AES128_GCM_SHA256")]
        Ecdhe_Rsa_Aes128_Gcm_Sha256 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECDHE_RSA_AES256_GCM_SHA384")]
        Ecdhe_Rsa_Aes256_Gcm_Sha384 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DHE_RSA_AES256_GCM_SHA384")]
        Dhe_Rsa_Aes256_Gcm_Sha384 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DHE_RSA_AES128_GCM_SHA256")]
        Dhe_Rsa_Aes128_Gcm_Sha256 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECDHE_RSA_AES128_SHA256")]
        Ecdhe_Rsa_Aes128_Sha256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ECDHE_RSA_AES256_SHA384")]
        Ecdhe_Rsa_Aes256_Sha384 = 5,
    }
    public enum AfdCustomizedCipherSuiteForTls13
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_AES_128_GCM_SHA256")]
        Tls_Aes_128_Gcm_Sha256 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_AES_256_GCM_SHA384")]
        Tls_Aes_256_Gcm_Sha384 = 1,
    }
    public partial class AzureFirstPartyManagedCertificateProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public AzureFirstPartyManagedCertificateProperties() { }
        public Azure.Provisioning.BicepValue<string> CertificateAuthority { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExpirationDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecretSourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SubjectAlternativeNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CacheBehaviorSetting
    {
        BypassCache = 0,
        Override = 1,
        SetIfMissing = 2,
    }
    public partial class CacheConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CacheConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RuleCacheBehavior> CacheBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> CacheDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RuleIsCompressionEnabled> IsCompressionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RuleQueryStringCachingBehavior> QueryStringCachingBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CacheExpirationActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CacheExpirationActionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CacheBehaviorSetting> CacheBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> CacheDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnCacheLevel> CacheType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CacheExpirationActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleCacheExpirationActionParameters")]
        CacheExpirationAction = 0,
    }
    public partial class CacheKeyQueryStringActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CacheKeyQueryStringActionProperties() { }
        public Azure.Provisioning.BicepValue<string> QueryParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.QueryStringBehavior> QueryStringBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CacheKeyQueryStringActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleCacheKeyQueryStringBehaviorActionParameters")]
        CacheKeyQueryStringBehaviorAction = 0,
    }
    public enum CdnCacheLevel
    {
        All = 0,
    }
    public partial class CdnCertificateSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CdnCertificateSource() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnManagedCertificateType> CertificateType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CdnCertificateSourceType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CdnCertificateSourceParameters")]
        CdnCertificateSource = 0,
    }
    public partial class CdnCustomDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnCustomDomain(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Cdn.CustomDomainHttpsContent CustomDomainHttpsContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CustomHttpsAvailabilityState> CustomHttpsAvailabilityState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CustomHttpsProvisioningState> CustomHttpsProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CustomHttpsProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CustomDomainResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnCustomDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> ContentTypesToCompress { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.CdnCustomDomain> CustomDomains { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeepCreatedCustomDomain> DeepCreatedCustomDomains { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultOriginGroupId { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.EndpointDeliveryPolicy DeliveryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.GeoFilter> GeoFilters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsCompressionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpsAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OptimizationType> OptimizationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeepCreatedOriginGroup> OriginGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginHostHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeepCreatedOrigin> Origins { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProbePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnEndpointProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.QueryStringCachingBehavior> QueryStringCachingBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.EndpointResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.UriSigningKey> UriSigningKeys { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public enum CdnEndpointProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
        Deleting = 3,
        Creating = 4,
    }
    public enum CdnManagedCertificateType
    {
        Shared = 0,
        Dedicated = 1,
    }
    public partial class CdnManagedHttpsContent : Azure.Provisioning.Cdn.CustomDomainHttpsContent
    {
        public CdnManagedHttpsContent() { }
        public Azure.Provisioning.Cdn.CdnCertificateSource CertificateSourceParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CdnMinimumTlsVersion
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS 1.0")]
        Tls1_0 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS 1.2")]
        Tls1_2 = 2,
    }
    public partial class CdnOrigin : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnOrigin(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginHostHeader { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PrivateEndpointStatus> PrivateEndpointStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkApprovalMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OriginProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OriginResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnOrigin FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnOriginGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnOriginGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Cdn.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Origins { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OriginGroupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OriginGroupResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.Cdn.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnOriginGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> ExtendedProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> FrontDoorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.ProfileLogScrubbing LogScrubbing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OriginResponseTimeoutSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ProfileProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ProfileResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public enum CdnSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Verizon")]
        StandardVerizon = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_Verizon")]
        PremiumVerizon = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Custom_Verizon")]
        CustomVerizon = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Akamai")]
        StandardAkamai = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ChinaCdn")]
        StandardChinaCdn = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_Microsoft")]
        StandardMicrosoft = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_AzureFrontDoor")]
        StandardAzureFrontDoor = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_AzureFrontDoor")]
        PremiumAzureFrontDoor = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_955BandWidth_ChinaCdn")]
        Standard955BandWidthChinaCdn = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_AvgBandWidth_ChinaCdn")]
        StandardAvgBandWidthChinaCdn = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardPlus_ChinaCdn")]
        StandardPlusChinaCdn = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardPlus_955BandWidth_ChinaCdn")]
        StandardPlus955BandWidthChinaCdn = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardPlus_AvgBandWidth_ChinaCdn")]
        StandardPlusAvgBandWidthChinaCdn = 12,
    }
    public partial class CdnWebApplicationFirewallPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnWebApplicationFirewallPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.CustomRule> CustomRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> EndpointLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ExtendedProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.WafPolicyManagedRuleSet> ManagedRuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.WafPolicySettings PolicySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.WebApplicationFirewallPolicyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.RateLimitRule> RateLimitRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PolicyResourceState> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnWebApplicationFirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public enum CertificateDeleteAction
    {
        NoAction = 0,
    }
    public enum CertificateUpdateAction
    {
        NoAction = 0,
    }
    public partial class ClientPortMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClientPortMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ClientPortOperator> ClientPortOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClientPortMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleClientPortConditionParameters")]
        ClientPortCondition = 0,
    }
    public enum ClientPortOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class CookiesMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CookiesMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CookiesOperator> CookiesOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CookiesMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleCookiesConditionParameters")]
        CookiesCondition = 0,
    }
    public enum CookiesOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class CustomDomainHttpsContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDomainHttpsContent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CdnMinimumTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.SecureDeliveryProtocolType> ProtocolType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomDomainResourceState
    {
        Creating = 0,
        Active = 1,
        Deleting = 2,
    }
    public partial class CustomerCertificateProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public CustomerCertificateProperties() { }
        public Azure.Provisioning.BicepValue<string> CertificateAuthority { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecretSourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SubjectAlternativeNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseLatestVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomHttpsAvailabilityState
    {
        SubmittingDomainControlValidationRequest = 0,
        PendingDomainControlValidationREquestApproval = 1,
        DomainControlValidationRequestApproved = 2,
        DomainControlValidationRequestRejected = 3,
        DomainControlValidationRequestTimedOut = 4,
        IssuingCertificate = 5,
        DeployingCertificate = 6,
        CertificateDeployed = 7,
        DeletingCertificate = 8,
        CertificateDeleted = 9,
    }
    public enum CustomHttpsProvisioningState
    {
        Enabling = 0,
        Enabled = 1,
        Disabling = 2,
        Disabled = 3,
        Failed = 4,
    }
    public partial class CustomRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OverrideActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CustomRuleEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.CustomRuleMatchCondition> MatchConditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomRuleEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class CustomRuleMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomRuleMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.MatchOperator> MatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.WafMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.TransformType> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedCustomDomain : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedCustomDomain() { }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedOrigin : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedOrigin() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginHostHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PrivateEndpointStatus> PrivateEndpointStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkApprovalMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedOriginGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedOriginGroup() { }
        public Azure.Provisioning.Cdn.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Origins { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRuleAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRuleCondition> Conditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRuleAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleCacheExpirationAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleCacheExpirationAction() { }
        public Azure.Provisioning.Cdn.CacheExpirationActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleCacheKeyQueryStringAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleCacheKeyQueryStringAction() { }
        public Azure.Provisioning.Cdn.CacheKeyQueryStringActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleClientPortCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleClientPortCondition() { }
        public Azure.Provisioning.Cdn.ClientPortMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRuleCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleCookiesCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleCookiesCondition() { }
        public Azure.Provisioning.Cdn.CookiesMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleHostNameCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleHostNameCondition() { }
        public Azure.Provisioning.Cdn.HostNameMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleHttpVersionCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleHttpVersionCondition() { }
        public Azure.Provisioning.Cdn.HttpVersionMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleIsDeviceCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleIsDeviceCondition() { }
        public Azure.Provisioning.Cdn.IsDeviceMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRulePostArgsCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRulePostArgsCondition() { }
        public Azure.Provisioning.Cdn.PostArgsMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleQueryStringCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleQueryStringCondition() { }
        public Azure.Provisioning.Cdn.QueryStringMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRemoteAddressCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRemoteAddressCondition() { }
        public Azure.Provisioning.Cdn.RemoteAddressMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestBodyCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestBodyCondition() { }
        public Azure.Provisioning.Cdn.RequestBodyMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestHeaderAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleRequestHeaderAction() { }
        public Azure.Provisioning.Cdn.HeaderActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestHeaderCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestHeaderCondition() { }
        public Azure.Provisioning.Cdn.RequestHeaderMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestMethodCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestMethodCondition() { }
        public Azure.Provisioning.Cdn.RequestMethodMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestSchemeCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestSchemeCondition() { }
        public Azure.Provisioning.Cdn.RequestSchemeMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestUriCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestUriCondition() { }
        public Azure.Provisioning.Cdn.RequestUriMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleResponseHeaderAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleResponseHeaderAction() { }
        public Azure.Provisioning.Cdn.HeaderActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRouteConfigurationOverrideAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleRouteConfigurationOverrideAction() { }
        public Azure.Provisioning.Cdn.RouteConfigurationOverrideActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleServerPortCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleServerPortCondition() { }
        public Azure.Provisioning.Cdn.ServerPortMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleSocketAddressCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleSocketAddressCondition() { }
        public Azure.Provisioning.Cdn.SocketAddressMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DeliveryRuleSslProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLSv1.2")]
        Tls1_2 = 2,
    }
    public partial class DeliveryRuleSslProtocolCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleSslProtocolCondition() { }
        public Azure.Provisioning.Cdn.DeliveryRuleSslProtocolMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleSslProtocolMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRuleSslProtocolMatchCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRuleSslProtocol> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.SslProtocolOperator> SslProtocolOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriFileExtensionCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileExtensionCondition() { }
        public Azure.Provisioning.Cdn.UriFileExtensionMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriFileNameCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileNameCondition() { }
        public Azure.Provisioning.Cdn.UriFileNameMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriPathCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriPathCondition() { }
        public Azure.Provisioning.Cdn.UriPathMatchCondition Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DestinationProtocol
    {
        MatchRequest = 0,
        Http = 1,
        Https = 2,
    }
    public enum DomainNameLabelScope
    {
        TenantReuse = 0,
        SubscriptionReuse = 1,
        ResourceGroupReuse = 2,
        NoReuse = 3,
    }
    public partial class DomainValidationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainValidationProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationToken { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DomainValidationState
    {
        Unknown = 0,
        Submitting = 1,
        Pending = 2,
        Rejected = 3,
        TimedOut = 4,
        PendingRevalidation = 5,
        Approved = 6,
        RefreshingValidationToken = 7,
        InternalError = 8,
    }
    public enum EnabledState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class EndpointDeliveryPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EndpointDeliveryPolicy() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EndpointResourceState
    {
        Creating = 0,
        Deleting = 1,
        Running = 2,
        Starting = 3,
        Stopped = 4,
        Stopping = 5,
    }
    public enum ForwardingProtocol
    {
        HttpOnly = 0,
        HttpsOnly = 1,
        MatchRequest = 2,
    }
    public partial class FrontDoorActivatedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorActivatedResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsActive { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontDoorCertificateType
    {
        CustomerCertificate = 0,
        ManagedCertificate = 1,
        AzureFirstPartyManagedCertificate = 2,
    }
    public partial class FrontDoorCustomDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorCustomDomain(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DnsZoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.DomainValidationState> DomainValidationState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ExtendedProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PreValidatedCustomDomainResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Cdn.FrontDoorCustomDomainHttpsContent TlsSettings { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.DomainValidationProperties ValidationProperties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorCustomDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorCustomDomainHttpsContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorCustomDomainHttpsContent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorCertificateType> CertificateType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.AfdCipherSuiteSetType> CipherSuiteSetType { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet CustomizedCipherSuiteSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorMinimumTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecretId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.AfdCustomizedCipherSuiteForTls12> CipherSuiteSetForTls12 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.AfdCustomizedCipherSuiteForTls13> CipherSuiteSetForTls13 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FrontDoorDeploymentStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public partial class FrontDoorEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.DomainNameLabelScope> AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.EnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public enum FrontDoorEndpointProtocol
    {
        Http = 0,
        Https = 1,
    }
    public enum FrontDoorMinimumTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS 1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS 1.2")]
        Tls1_2 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS 1.3")]
        Tls1_3 = 2,
    }
    public partial class FrontDoorOrigin : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorOrigin(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.EnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnforceCertificateNameCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginGroupName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OriginHostHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OriginId { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorOriginGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Cdn.SharedPrivateLinkResourceProperties SharedPrivateLinkResource { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorOrigin FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorOriginGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorOriginGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Cdn.OriginAuthenticationProperties Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.Cdn.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Cdn.LoadBalancingSettings LoadBalancingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.EnabledState> SessionAffinityState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TrafficRestorationTimeInMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorOriginGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public enum FrontDoorProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
        Deleting = 3,
        Creating = 4,
    }
    public enum FrontDoorQueryStringCachingBehavior
    {
        IgnoreQueryString = 0,
        UseQueryString = 1,
        IgnoreSpecifiedQueryStrings = 2,
        IncludeSpecifiedQueryStrings = 3,
    }
    public partial class FrontDoorRoute : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRoute(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Cdn.FrontDoorRouteCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.FrontDoorActivatedResourceInfo> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.EnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ForwardingProtocol> ForwardingProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HttpsRedirect> HttpsRedirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.LinkToDefaultDomain> LinkToDefaultDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OriginGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OriginPath { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PatternsToMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RuleSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.FrontDoorEndpointProtocol> SupportedProtocols { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRoute FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorRouteCacheConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorRouteCacheConfiguration() { }
        public Azure.Provisioning.Cdn.RouteCacheCompressionSettings CompressionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorQueryStringCachingBehavior> QueryStringCachingBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRuleAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.DeliveryRuleCondition> Conditions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.MatchProcessingBehavior> MatchProcessingBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorRuleSet? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RuleSetName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorRuleSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRuleSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRuleSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorSecret : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorSecret(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.Cdn.FrontDoorSecretProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorSecret FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorSecretProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorSecretProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorSecurityPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorSecurityPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorDeploymentStatus> DeploymentStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileName { get { throw null; } }
        public Azure.Provisioning.Cdn.SecurityPolicyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.FrontDoorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorSecurityPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_06_01;
        }
    }
    public partial class GeoFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GeoFilter() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.GeoFilterAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CountryCodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GeoFilterAction
    {
        Block = 0,
        Allow = 1,
    }
    public enum HeaderAction
    {
        Append = 0,
        Overwrite = 1,
        Delete = 2,
    }
    public partial class HeaderActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HeaderActionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HeaderAction> HeaderAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HeaderActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleHeaderActionParameters")]
        HeaderAction = 0,
    }
    public enum HealthProbeProtocol
    {
        NotSet = 0,
        Http = 1,
        Https = 2,
    }
    public enum HealthProbeRequestType
    {
        NotSet = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 2,
    }
    public partial class HealthProbeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthProbeSettings() { }
        public Azure.Provisioning.BicepValue<int> ProbeIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProbePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HealthProbeProtocol> ProbeProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HealthProbeRequestType> ProbeRequestType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HostNameMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostNameMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HostNameOperator> HostNameOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HostNameMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleHostNameConditionParameters")]
        HostNameCondition = 0,
    }
    public enum HostNameOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class HttpErrorRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HttpErrorRange() { }
        public Azure.Provisioning.BicepValue<int> Begin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> End { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HttpsRedirect
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class HttpVersionMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HttpVersionMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.HttpVersionOperator> HttpVersionOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HttpVersionMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleHttpVersionConditionParameters")]
        HttpVersionCondition = 0,
    }
    public enum HttpVersionOperator
    {
        Equal = 0,
    }
    public partial class IsDeviceMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IsDeviceMatchCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.IsDeviceOperator> IsDeviceOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.IsDeviceMatchConditionMatchValue> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IsDeviceMatchConditionMatchValue
    {
        Mobile = 0,
        Desktop = 1,
    }
    public enum IsDeviceMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleIsDeviceConditionParameters")]
        IsDeviceCondition = 0,
    }
    public enum IsDeviceOperator
    {
        Equal = 0,
    }
    public partial class KeyVaultCertificateSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultCertificateSource() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CertificateDeleteAction> DeleteRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.CertificateUpdateAction> UpdateRule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VaultName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultCertificateSourceType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="KeyVaultCertificateSourceParameters")]
        KeyVaultCertificateSource = 0,
    }
    public partial class KeyVaultSigningKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultSigningKey() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.KeyVaultSigningKeyType> KeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VaultName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultSigningKeyType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="KeyVaultSigningKeyParameters")]
        KeyVaultSigningKey = 0,
    }
    public enum LinkToDefaultDomain
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class LoadBalancingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancingSettings() { }
        public Azure.Provisioning.BicepValue<int> AdditionalLatencyInMilliseconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SampleSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SuccessfulSamplesRequired { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedCertificateProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public ManagedCertificateProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleGroupOverrideSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleGroupOverrideSetting() { }
        public Azure.Provisioning.BicepValue<string> RuleGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.ManagedRuleOverrideSetting> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleOverrideSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleOverrideSetting() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OverrideActionType> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ManagedRuleSetupState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedRuleSetupState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum MatchOperator
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
        RegEx = 11,
    }
    public enum MatchProcessingBehavior
    {
        Continue = 0,
        Stop = 1,
    }
    public enum OptimizationType
    {
        GeneralWebDelivery = 0,
        GeneralMediaStreaming = 1,
        VideoOnDemandMediaStreaming = 2,
        LargeFileDownload = 3,
        DynamicSiteAcceleration = 4,
    }
    public partial class OriginAuthenticationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OriginAuthenticationProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.OriginAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OriginAuthenticationType
    {
        SystemAssignedIdentity = 0,
        UserAssignedIdentity = 1,
    }
    public partial class OriginGroupOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OriginGroupOverride() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ForwardingProtocol> ForwardingProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OriginGroupId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OriginGroupOverrideAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public OriginGroupOverrideAction() { }
        public Azure.Provisioning.Cdn.OriginGroupOverrideActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OriginGroupOverrideActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OriginGroupOverrideActionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OriginGroupId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OriginGroupOverrideActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleOriginGroupOverrideActionParameters")]
        OriginGroupOverrideAction = 0,
    }
    public enum OriginGroupProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
        Deleting = 3,
        Creating = 4,
    }
    public enum OriginGroupResourceState
    {
        Creating = 0,
        Active = 1,
        Deleting = 2,
    }
    public enum OriginProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
        Deleting = 3,
        Creating = 4,
    }
    public enum OriginResourceState
    {
        Creating = 0,
        Active = 1,
        Deleting = 2,
    }
    public enum OverrideActionType
    {
        Allow = 0,
        Block = 1,
        Log = 2,
        Redirect = 3,
    }
    public enum ParamIndicator
    {
        Expires = 0,
        KeyId = 1,
        Signature = 2,
    }
    public enum PolicyEnabledState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum PolicyMode
    {
        Prevention = 0,
        Detection = 1,
    }
    public enum PolicyResourceState
    {
        Creating = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
        Deleting = 5,
    }
    public partial class PolicySettingsDefaultCustomBlockResponseStatusCode : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolicySettingsDefaultCustomBlockResponseStatusCode() { }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredFive { get { throw null; } }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredSix { get { throw null; } }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredThree { get { throw null; } }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredTwentyNine { get { throw null; } }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode TwoHundred { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostArgsMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostArgsMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PostArgsOperator> PostArgsOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostArgsMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRulePostArgsConditionParameters")]
        PostArgsCondition = 0,
    }
    public enum PostArgsOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public enum PreTransformCategory
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
    public enum PrivateEndpointStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class ProfileLogScrubbing : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProfileLogScrubbing() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.ProfileScrubbingRules> ScrubbingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ProfileScrubbingState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProfileProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Updating = 2,
        Deleting = 3,
        Creating = 4,
    }
    public enum ProfileResourceState
    {
        Creating = 0,
        Active = 1,
        Deleting = 2,
        Disabled = 3,
        Migrating = 4,
        Migrated = 5,
        PendingMigrationCommit = 6,
        CommittingMigration = 7,
        AbortingMigration = 8,
    }
    public partial class ProfileScrubbingRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProfileScrubbingRules() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ScrubbingRuleEntryMatchVariable> MatchVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ScrubbingRuleEntryMatchOperator> SelectorMatchOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ScrubbingRuleEntryState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProfileScrubbingState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum QueryStringBehavior
    {
        Include = 0,
        IncludeAll = 1,
        Exclude = 2,
        ExcludeAll = 3,
    }
    public enum QueryStringCachingBehavior
    {
        NotSet = 0,
        IgnoreQueryString = 1,
        BypassCaching = 2,
        UseQueryString = 3,
    }
    public partial class QueryStringMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueryStringMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.QueryStringOperator> QueryStringOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QueryStringMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleQueryStringConditionParameters")]
        QueryStringCondition = 0,
    }
    public enum QueryStringOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class RateLimitRule : Azure.Provisioning.Cdn.CustomRule
    {
        public RateLimitRule() { }
        public Azure.Provisioning.BicepValue<int> RateLimitDurationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RateLimitThreshold { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedirectType
    {
        Moved = 0,
        Found = 1,
        TemporaryRedirect = 2,
        PermanentRedirect = 3,
    }
    public partial class RemoteAddressMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RemoteAddressMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RemoteAddressOperator> RemoteAddressOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RemoteAddressMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRemoteAddressConditionParameters")]
        RemoteAddressCondition = 0,
    }
    public enum RemoteAddressOperator
    {
        Any = 0,
        IPMatch = 1,
        GeoMatch = 2,
    }
    public partial class RequestBodyMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestBodyMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RequestBodyOperator> RequestBodyOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RequestBodyMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRequestBodyConditionParameters")]
        RequestBodyCondition = 0,
    }
    public enum RequestBodyOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class RequestHeaderMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestHeaderMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RequestHeaderOperator> RequestHeaderOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RequestHeaderMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRequestHeaderConditionParameters")]
        RequestHeaderCondition = 0,
    }
    public enum RequestHeaderOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class RequestMethodMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestMethodMatchCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.RequestMethodMatchConditionMatchValue> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RequestMethodOperator> RequestMethodOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RequestMethodMatchConditionMatchValue
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PUT")]
        Put = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DELETE")]
        Delete = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OPTIONS")]
        Options = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TRACE")]
        Trace = 6,
    }
    public enum RequestMethodMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRequestMethodConditionParameters")]
        RequestMethodCondition = 0,
    }
    public enum RequestMethodOperator
    {
        Equal = 0,
    }
    public partial class RequestSchemeMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestSchemeMatchCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.RequestSchemeMatchConditionMatchValue> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RequestSchemeOperator> RequestSchemeOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RequestSchemeMatchConditionMatchValue
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTPS")]
        Https = 1,
    }
    public enum RequestSchemeMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRequestSchemeConditionParameters")]
        RequestSchemeCondition = 0,
    }
    public enum RequestSchemeOperator
    {
        Equal = 0,
    }
    public partial class RequestUriMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestUriMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RequestUriOperator> RequestUriOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RequestUriMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRequestUriConditionParameters")]
        RequestUriCondition = 0,
    }
    public enum RequestUriOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public enum ResponseBasedDetectedErrorType
    {
        None = 0,
        TcpErrorsOnly = 1,
        TcpAndHttpErrors = 2,
    }
    public partial class ResponseBasedOriginErrorDetectionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseBasedOriginErrorDetectionSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.HttpErrorRange> HttpErrorRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ResponseBasedDetectedErrorType> ResponseBasedDetectedErrorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ResponseBasedFailoverThresholdPercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteCacheCompressionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteCacheCompressionSettings() { }
        public Azure.Provisioning.BicepList<string> ContentTypesToCompress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCompressionEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteConfigurationOverrideActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteConfigurationOverrideActionProperties() { }
        public Azure.Provisioning.Cdn.CacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.OriginGroupOverride OriginGroupOverride { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RouteConfigurationOverrideActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleRouteConfigurationOverrideActionParameters")]
        RouteConfigurationOverrideAction = 0,
    }
    public enum RuleCacheBehavior
    {
        HonorOrigin = 0,
        OverrideAlways = 1,
        OverrideIfOriginMissing = 2,
    }
    public enum RuleIsCompressionEnabled
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum RuleQueryStringCachingBehavior
    {
        IgnoreQueryString = 0,
        UseQueryString = 1,
        IgnoreSpecifiedQueryStrings = 2,
        IncludeSpecifiedQueryStrings = 3,
    }
    public enum ScrubbingRuleEntryMatchOperator
    {
        EqualsAny = 0,
    }
    public enum ScrubbingRuleEntryMatchVariable
    {
        RequestIPAddress = 0,
        RequestUri = 1,
        QueryStringArgNames = 2,
    }
    public enum ScrubbingRuleEntryState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum SecureDeliveryProtocolType
    {
        ServerNameIndication = 0,
        IPBased = 1,
    }
    public partial class SecurityPolicyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityPolicyProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityPolicyWebApplicationFirewall : Azure.Provisioning.Cdn.SecurityPolicyProperties
    {
        public SecurityPolicyWebApplicationFirewall() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.SecurityPolicyWebApplicationFirewallAssociation> Associations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WafPolicyId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityPolicyWebApplicationFirewallAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityPolicyWebApplicationFirewallAssociation() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.FrontDoorActivatedResourceInfo> Domains { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PatternsToMatch { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerPortMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerPortMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ServerPortOperator> ServerPortOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerPortMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleServerPortConditionParameters")]
        ServerPortCondition = 0,
    }
    public enum ServerPortOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class SharedPrivateLinkResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharedPrivateLinkResourceProperties() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.SharedPrivateLinkResourceStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class SocketAddressMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SocketAddressMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.SocketAddressOperator> SocketAddressOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SocketAddressMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleSocketAddrConditionParameters")]
        SocketAddressCondition = 0,
    }
    public enum SocketAddressOperator
    {
        Any = 0,
        IPMatch = 1,
    }
    public enum SslProtocolMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleSslProtocolConditionParameters")]
        SslProtocolCondition = 0,
    }
    public enum SslProtocolOperator
    {
        Equal = 0,
    }
    public enum TransformType
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
    public partial class UriFileExtensionMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriFileExtensionMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.UriFileExtensionOperator> UriFileExtensionOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriFileExtensionMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlFileExtensionMatchConditionParameters")]
        UriFileExtensionMatchCondition = 0,
    }
    public enum UriFileExtensionOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class UriFileNameMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriFileNameMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.UriFileNameOperator> UriFileNameOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriFileNameMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlFilenameConditionParameters")]
        UriFilenameCondition = 0,
    }
    public enum UriFileNameOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        RegEx = 9,
    }
    public partial class UriPathMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriPathMatchCondition() { }
        public Azure.Provisioning.BicepList<string> MatchValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NegateCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.PreTransformCategory> Transforms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.UriPathOperator> UriPathOperator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriPathMatchConditionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlPathMatchConditionParameters")]
        UriPathMatchCondition = 0,
    }
    public enum UriPathOperator
    {
        Any = 0,
        Equal = 1,
        Contains = 2,
        BeginsWith = 3,
        EndsWith = 4,
        LessThan = 5,
        LessThanOrEqual = 6,
        GreaterThan = 7,
        GreaterThanOrEqual = 8,
        Wildcard = 9,
        RegEx = 10,
    }
    public partial class UriRedirectAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public UriRedirectAction() { }
        public Azure.Provisioning.Cdn.UriRedirectActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriRedirectActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriRedirectActionProperties() { }
        public Azure.Provisioning.BicepValue<string> CustomFragment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomHostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomQueryString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.DestinationProtocol> DestinationProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.RedirectType> RedirectType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriRedirectActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlRedirectActionParameters")]
        UriRedirectAction = 0,
    }
    public partial class UriRewriteAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public UriRewriteAction() { }
        public Azure.Provisioning.Cdn.UriRewriteActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriRewriteActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriRewriteActionProperties() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreserveUnmatchedPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourcePattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriRewriteActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlRewriteActionParameters")]
        UriRewriteAction = 0,
    }
    public partial class UriSigningAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public UriSigningAction() { }
        public Azure.Provisioning.Cdn.UriSigningActionProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriSigningActionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.UriSigningAlgorithm> Algorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.UriSigningParamIdentifier> ParameterNameOverride { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UriSigningActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleUrlSigningActionParameters")]
        UriSigningAction = 0,
    }
    public enum UriSigningAlgorithm
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SHA256")]
        Sha256 = 0,
    }
    public partial class UriSigningKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriSigningKey() { }
        public Azure.Provisioning.BicepValue<string> KeyId { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.KeyVaultSigningKey KeySourceParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningKeyProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public UriSigningKeyProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecretSourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningParamIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriSigningParamIdentifier() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.ParamIndicator> ParamIndicator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParamName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserManagedHttpsContent : Azure.Provisioning.Cdn.CustomDomainHttpsContent
    {
        public UserManagedHttpsContent() { }
        public Azure.Provisioning.Cdn.KeyVaultCertificateSource CertificateSourceParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WafMatchVariable
    {
        RemoteAddr = 0,
        SocketAddr = 1,
        RequestMethod = 2,
        RequestHeader = 3,
        RequestUri = 4,
        QueryString = 5,
        RequestBody = 6,
        Cookies = 7,
        PostArgs = 8,
    }
    public partial class WafPolicyManagedRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WafPolicyManagedRuleSet() { }
        public Azure.Provisioning.BicepValue<int> AnomalyScore { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Cdn.ManagedRuleGroupOverrideSetting> RuleGroupOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleSetVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WafPolicySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WafPolicySettings() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultCustomBlockResponseBody { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.PolicySettingsDefaultCustomBlockResponseStatusCode DefaultCustomBlockResponseStatusCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DefaultRedirectUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PolicyEnabledState> EnabledState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Cdn.PolicyMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationFirewallPolicyProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
        Failed = 2,
    }
}
