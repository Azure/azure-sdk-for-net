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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CacheExpirationActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CacheExpirationActionProperties() { }
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnCustomDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_04_02;
            public static readonly string V2016_10_02;
            public static readonly string V2017_04_02;
            public static readonly string V2017_10_12;
            public static readonly string V2018_04_02;
            public static readonly string V2019_04_15;
            public static readonly string V2019_12_31;
            public static readonly string V2020_03_31;
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_04_02;
            public static readonly string V2016_10_02;
            public static readonly string V2017_04_02;
            public static readonly string V2017_10_12;
            public static readonly string V2018_04_02;
            public static readonly string V2019_04_15;
            public static readonly string V2019_12_31;
            public static readonly string V2020_03_31;
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnOrigin FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_04_02;
            public static readonly string V2016_10_02;
            public static readonly string V2017_04_02;
            public static readonly string V2017_10_12;
            public static readonly string V2018_04_02;
            public static readonly string V2019_04_15;
            public static readonly string V2019_12_31;
            public static readonly string V2020_03_31;
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnOriginGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnOriginGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnOriginGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_12_31;
            public static readonly string V2020_03_31;
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class CdnProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CdnProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_04_02;
            public static readonly string V2016_10_02;
            public static readonly string V2017_04_02;
            public static readonly string V2017_10_12;
            public static readonly string V2018_04_02;
            public static readonly string V2019_04_15;
            public static readonly string V2019_12_31;
            public static readonly string V2020_03_31;
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.CdnWebApplicationFirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_04_15;
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedCustomDomain : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedCustomDomain() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedOrigin : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedOrigin() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeepCreatedOriginGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeepCreatedOriginGroup() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRule() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleCacheKeyQueryStringAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleCacheKeyQueryStringAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleClientPortCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleClientPortCondition() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleHostNameCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleHostNameCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleHttpVersionCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleHttpVersionCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleIsDeviceCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleIsDeviceCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRulePostArgsCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRulePostArgsCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleQueryStringCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleQueryStringCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRemoteAddressCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRemoteAddressCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestBodyCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestBodyCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestHeaderAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleRequestHeaderAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestHeaderCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestHeaderCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestMethodCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestMethodCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestSchemeCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestSchemeCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRequestUriCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleRequestUriCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleResponseHeaderAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleResponseHeaderAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleRouteConfigurationOverrideAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public DeliveryRuleRouteConfigurationOverrideAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleServerPortCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleServerPortCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleSocketAddressCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleSocketAddressCondition() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleSslProtocolMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeliveryRuleSslProtocolMatchCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriFileExtensionCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileExtensionCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriFileNameCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileNameCondition() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeliveryRuleUriPathCondition : Azure.Provisioning.Cdn.DeliveryRuleCondition
    {
        public DeliveryRuleUriPathCondition() { }
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorCustomDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorCustomDomainHttpsContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorCustomDomainHttpsContent() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet() { }
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorOriginGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorOrigin FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorOriginGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorOriginGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorOriginGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorEndpoint? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRoute FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorRouteCacheConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontDoorRouteCacheConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontDoorRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.FrontDoorRuleSet? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorRuleSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorRuleSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorRuleSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class FrontDoorSecret : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontDoorSecret(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorSecret FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Cdn.CdnProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Cdn.FrontDoorSecurityPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_09_01;
            public static readonly string V2021_06_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_09_01;
            public static readonly string V2025_04_15;
            public static readonly string V2025_06_01;
        }
    }
    public partial class GeoFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GeoFilter() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GeoFilterAction
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Block             Serialized Name: GeoFilterActions.Block")]
        Block = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Allow             Serialized Name: GeoFilterActions.Allow")]
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
        protected override void DefineProvisionableProperties() { }
    }
    public enum HeaderActionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DeliveryRuleHeaderActionParameters")]
        HeaderAction = 0,
    }
    public enum HealthProbeProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="NotSet             Serialized Name: ProbeProtocol.NotSet")]
        NotSet = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Http             Serialized Name: ProbeProtocol.Http")]
        Http = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Https             Serialized Name: ProbeProtocol.Https")]
        Https = 2,
    }
    public enum HealthProbeRequestType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="NotSet             Serialized Name: HealthProbeRequestType.NotSet")]
        NotSet = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET             Serialized Name: HealthProbeRequestType.GET")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD             Serialized Name: HealthProbeRequestType.HEAD")]
        Head = 2,
    }
    public partial class HealthProbeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthProbeSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HostNameMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostNameMatchCondition() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedCertificateProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public ManagedCertificateProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleGroupOverrideSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleGroupOverrideSetting() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedRuleOverrideSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedRuleOverrideSetting() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OriginGroupOverrideAction : Azure.Provisioning.Cdn.DeliveryRuleAction
    {
        public OriginGroupOverrideAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OriginGroupOverrideActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OriginGroupOverrideActionProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostArgsMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostArgsMatchCondition() { }
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="NotSet             Serialized Name: QueryStringCachingBehavior.NotSet")]
        NotSet = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IgnoreQueryString             Serialized Name: QueryStringCachingBehavior.IgnoreQueryString")]
        IgnoreQueryString = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="BypassCaching             Serialized Name: QueryStringCachingBehavior.BypassCaching")]
        BypassCaching = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UseQueryString             Serialized Name: QueryStringCachingBehavior.UseQueryString")]
        UseQueryString = 3,
    }
    public partial class QueryStringMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueryStringMatchCondition() { }
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="None             Serialized Name: ResponseBasedDetectedErrorTypes.None")]
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TcpErrorsOnly             Serialized Name: ResponseBasedDetectedErrorTypes.TcpErrorsOnly")]
        TcpErrorsOnly = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TcpAndHttpErrors             Serialized Name: ResponseBasedDetectedErrorTypes.TcpAndHttpErrors")]
        TcpAndHttpErrors = 2,
    }
    public partial class ResponseBasedOriginErrorDetectionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseBasedOriginErrorDetectionSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteCacheCompressionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteCacheCompressionSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RouteConfigurationOverrideActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteConfigurationOverrideActionProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecurityPolicyWebApplicationFirewallAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityPolicyWebApplicationFirewallAssociation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerPortMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerPortMatchCondition() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharedPrivateLinkResourceStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Pending             Serialized Name: SharedPrivateLinkResourceStatus.Pending")]
        Pending = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Approved             Serialized Name: SharedPrivateLinkResourceStatus.Approved")]
        Approved = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Rejected             Serialized Name: SharedPrivateLinkResourceStatus.Rejected")]
        Rejected = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Disconnected             Serialized Name: SharedPrivateLinkResourceStatus.Disconnected")]
        Disconnected = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Timeout             Serialized Name: SharedPrivateLinkResourceStatus.Timeout")]
        Timeout = 4,
    }
    public partial class SocketAddressMatchCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SocketAddressMatchCondition() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriRedirectActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriRedirectActionProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriRewriteActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriRewriteActionProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningActionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriSigningActionProperties() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningKeyProperties : Azure.Provisioning.Cdn.FrontDoorSecretProperties
    {
        public UriSigningKeyProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UriSigningParamIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UriSigningParamIdentifier() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserManagedHttpsContent : Azure.Provisioning.Cdn.CustomDomainHttpsContent
    {
        public UserManagedHttpsContent() { }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WafPolicySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WafPolicySettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebApplicationFirewallPolicyProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
        Failed = 2,
    }
}
