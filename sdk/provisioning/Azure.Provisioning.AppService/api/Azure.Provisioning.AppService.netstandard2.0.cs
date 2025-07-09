namespace Azure.Provisioning.AppService
{
    public partial class AppCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CanonicalName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CerBlob { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DomainValidationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KeyVaultSecretStatus> KeyVaultSecretStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PfxBlob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicKeyHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelfLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServerFarmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppDaprConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppDaprConfig() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AppPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpMaxRequestSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpReadBufferSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApiLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppDaprLogLevel> LogLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppDaprLogLevel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="info")]
        Info = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="debug")]
        Debug = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="warn")]
        Warn = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="error")]
        Error = 3,
    }
    public partial class ApplicationLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationLogsConfig() { }
        public Azure.Provisioning.AppService.AppServiceBlobStorageApplicationLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceTableStorageApplicationLogsConfig AzureTableStorage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.WebAppLogLevel> FileSystemLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppLogsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppLogsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.AppService.LogAnalyticsConfiguration LogAnalyticsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppRegistration() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAadAllowedPrincipals : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAadAllowedPrincipals() { }
        public Azure.Provisioning.BicepList<string> Groups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Identities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAadLoginFlow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAadLoginFlow() { }
        public Azure.Provisioning.BicepValue<bool> IsWwwAuthenticateDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAadProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAadProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsAutoProvisioned { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAadLoginFlow Login { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAadRegistration Registration { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAadValidation Validation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAadRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAadRegistration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateIssuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateSubjectAlternativeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateThumbprintString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OpenIdIssuer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAadValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAadValidation() { }
        public Azure.Provisioning.BicepList<string> AllowedAudiences { get { throw null; } set { } }
        public Azure.Provisioning.AppService.DefaultAuthorizationPolicy DefaultAuthorizationPolicy { get { throw null; } set { } }
        public Azure.Provisioning.AppService.JwtClaimChecks JwtClaimChecks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAppleProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAppleProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAppleRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceAppleRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceAppleRegistration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceArmPlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceArmPlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PromotionCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceBlobStorageApplicationLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceBlobStorageApplicationLogsConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.WebAppLogLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SasUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceBlobStorageHttpLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceBlobStorageHttpLogsConfig() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SasUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceBuiltInRole : System.IEquatable<Azure.Provisioning.AppService.AppServiceBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.AppService.AppServiceBuiltInRole WebPlanContributor { get { throw null; } }
        public static Azure.Provisioning.AppService.AppServiceBuiltInRole WebsiteContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.AppService.AppServiceBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.AppService.AppServiceBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.AppService.AppServiceBuiltInRole left, Azure.Provisioning.AppService.AppServiceBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.AppService.AppServiceBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.AppService.AppServiceBuiltInRole left, Azure.Provisioning.AppService.AppServiceBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceCertificateOrder? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KeyVaultSecretStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServiceCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceCertificateDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceCertificateDetails() { }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotAfter { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotBefore { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RawData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SignatureAlgorithm { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceCertificateNotRenewableReason
    {
        RegistrationStatusNotSupportedForRenewal = 0,
        ExpirationNotInRenewalTimeRange = 1,
        SubscriptionNotActive = 2,
    }
    public partial class AppServiceCertificateOrder : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceCertificateOrder(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppService.AppServiceCertificateProperties> Certificates { get { throw null; } set { } }
        public Azure.Provisioning.AppService.CertificateOrderContact Contact { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Csr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DistinguishedName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainVerificationToken { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateKeyExternal { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> KeySize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastCertificateIssuedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextAutoRenewTimeStamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CertificateProductType> ProductType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceCertificateDetails Root { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CertificateOrderStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidityInYears { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServiceCertificateOrder FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceCertificateProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KeyVaultSecretStatus> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceCorsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceCorsSettings() { }
        public Azure.Provisioning.BicepList<string> AllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCredentialsSupported { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceDnsType
    {
        AzureDns = 0,
        DefaultDomainRegistrarDns = 1,
    }
    public partial class AppServiceDomain : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceDomain(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthCode { get { throw null; } set { } }
        public Azure.Provisioning.AppService.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.Provisioning.AppService.RegistrationContactInfo ContactAdmin { get { throw null; } set { } }
        public Azure.Provisioning.AppService.RegistrationContactInfo ContactBilling { get { throw null; } set { } }
        public Azure.Provisioning.AppService.RegistrationContactInfo ContactRegistrant { get { throw null; } set { } }
        public Azure.Provisioning.AppService.RegistrationContactInfo ContactTech { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceDnsType> DnsType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsZoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDnsRecordManagementReady { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDomainPrivacyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRenewedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NameServers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceDomainStatus> RegistrationStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceDnsType> TargetDnsType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServiceDomain FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2018_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum AppServiceDomainStatus
    {
        Unknown = 0,
        Active = 1,
        Awaiting = 2,
        Cancelled = 3,
        Confiscated = 4,
        Disabled = 5,
        Excluded = 6,
        Expired = 7,
        Failed = 8,
        Held = 9,
        Locked = 10,
        Parked = 11,
        Pending = 12,
        Reserved = 13,
        Reverted = 14,
        Suspended = 15,
        Transferred = 16,
        Unlocked = 17,
        Unparked = 18,
        Updated = 19,
        JsonConverterFailed = 20,
    }
    public partial class AppServiceEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceEnvironment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> ClusterSettings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.CustomDnsSuffixConfigurationData CustomDnsSuffixConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DedicatedHostCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontEndScaleFactor { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasLinuxWorkers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.LoadBalancingMode> InternalLoadBalancingMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IPSslAddressCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSuspended { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumNumberOfMachines { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MultiRoleCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MultiSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AseV3NetworkingConfigurationData NetworkingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.HostingEnvironmentStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceEnvironmentUpgradeAvailability> UpgradeAvailability { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceEnvironmentUpgradePreference> UpgradePreference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> UserWhitelistedIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceVirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServiceEnvironment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum AppServiceEnvironmentUpgradeAvailability
    {
        None = 0,
        Ready = 1,
    }
    public enum AppServiceEnvironmentUpgradePreference
    {
        None = 0,
        Early = 1,
        Late = 2,
        Manual = 3,
    }
    public partial class AppServiceFacebookProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceFacebookProvider() { }
        public Azure.Provisioning.BicepValue<string> GraphApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceForwardProxy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceForwardProxy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ForwardProxyConvention> Convention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomHostHeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomProtoHeaderName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceFtpsState
    {
        AllAllowed = 0,
        FtpsOnly = 1,
        Disabled = 2,
    }
    public partial class AppServiceGitHubProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceGitHubProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppService.ClientRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceGoogleProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceGoogleProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppService.ClientRegistration Registration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ValidationAllowedAudiences { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceHostName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceHostName() { }
        public Azure.Provisioning.BicepValue<string> AzureResourceName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceResourceType> AzureResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomHostNameDnsRecordType> CustomHostNameDnsRecordType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceHostNameType> HostNameType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SiteNames { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceHostNameType
    {
        Verified = 0,
        Managed = 1,
    }
    public enum AppServiceHostType
    {
        Standard = 0,
        Repository = 1,
    }
    public partial class AppServiceHttpLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceHttpLogsConfig() { }
        public Azure.Provisioning.AppService.AppServiceBlobStorageHttpLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.Provisioning.AppService.FileSystemHttpLogsConfig FileSystem { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceHttpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceHttpSettings() { }
        public Azure.Provisioning.AppService.AppServiceForwardProxy ForwardProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoutesApiPrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceIdentityProviders : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceIdentityProviders() { }
        public Azure.Provisioning.AppService.AppServiceAppleProvider Apple { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAadProvider AzureActiveDirectory { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceStaticWebAppsProvider AzureStaticWebApps { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppService.CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceFacebookProvider Facebook { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceGitHubProvider GitHub { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceGoogleProvider Google { get { throw null; } set { } }
        public Azure.Provisioning.AppService.LegacyMicrosoftAccount LegacyMicrosoftAccount { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceTwitterProvider Twitter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceIPFilterTag
    {
        Default = 0,
        XffProxy = 1,
        ServiceTag = 2,
    }
    public enum AppServiceIPMode
    {
        IPv4 = 0,
        IPv6 = 1,
        IPv4AndIPv6 = 2,
    }
    public partial class AppServiceIPSecurityRestriction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceIPSecurityRestriction() { }
        public Azure.Provisioning.BicepValue<string> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<string>> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddressOrCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubnetMask { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SubnetTrafficTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceIPFilterTag> Tag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VnetTrafficTag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceNameValuePair : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceNameValuePair() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServicePlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServicePlan(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FreeOfferExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GeoRegion { get { throw null; } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAsyncScalingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsElasticScaleEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHyperV { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPerSiteScaling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSpot { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsXenon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.AppService.KubeEnvironmentProfile KubeEnvironmentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumElasticWorkerCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumNumberOfWorkers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfSites { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SpotExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServicePlanStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subscription { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetWorkerCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetWorkerSizeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkerTierName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServicePlan FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum AppServicePlanStatus
    {
        Ready = 0,
        Pending = 1,
        Creating = 2,
    }
    public partial class AppServicePlanVirtualNetworkConnectionGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServicePlanVirtualNetworkConnectionGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VpnPackageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServicePlanVirtualNetworkConnectionGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum AppServiceResourceType
    {
        Website = 0,
        TrafficManager = 1,
    }
    public partial class AppServiceSkuCapability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceSkuCapability() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceSkuCapacity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceSkuCapacity() { }
        public Azure.Provisioning.BicepValue<int> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ElasticMaximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minimum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceSkuDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceSkuDescription() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceSkuCapability> Capabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceSkuCapacity SkuCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceSourceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceSourceControl(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Token { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenSecret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AppServiceSourceControl FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceStaticWebAppsProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceStaticWebAppsProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistrationClientId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceStorageAccessInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceStorageAccessInfo() { }
        public Azure.Provisioning.BicepValue<string> AccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceStorageProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShareName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceStorageAccountState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceStorageType> StorageType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceStorageAccountState
    {
        Ok = 0,
        InvalidCredentials = 1,
        InvalidShare = 2,
        NotValidated = 3,
    }
    public enum AppServiceStorageProtocol
    {
        Smb = 0,
        Http = 1,
        Nfs = 2,
    }
    public enum AppServiceStorageType
    {
        AzureFiles = 0,
        AzureBlob = 1,
    }
    public enum AppServiceSupportedTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.3")]
        One3 = 3,
    }
    public partial class AppServiceTableStorageApplicationLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceTableStorageApplicationLogsConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.WebAppLogLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUriString { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceTlsCipherSuite
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_AES_256_GCM_SHA384")]
        TlsAes256GcmSha384 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_AES_128_GCM_SHA256")]
        TlsAes128GcmSha256 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384")]
        TlsECDiffieHellmanECDsaWithAes256GcmSha384 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256")]
        TlsECDiffieHellmanECDsaWithAes128CbcSha256 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256")]
        TlsECDiffieHellmanECDsaWithAes128GcmSha256 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384")]
        TlsECDiffieHellmanRsaWithAes256GcmSha384 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256")]
        TlsECDiffieHellmanRsaWithAes128GcmSha256 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384")]
        TlsECDiffieHellmanRsaWithAes256CbcSha384 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256")]
        TlsECDiffieHellmanRsaWithAes128CbcSha256 = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA")]
        TlsECDiffieHellmanRsaWithAes256CbcSha = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA")]
        TlsECDiffieHellmanRsaWithAes128CbcSha = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_GCM_SHA384")]
        TlsRsaWithAes256GcmSha384 = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_GCM_SHA256")]
        TlsRsaWithAes128GcmSha256 = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_CBC_SHA256")]
        TlsRsaWithAes256CbcSha256 = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_CBC_SHA256")]
        TlsRsaWithAes128CbcSha256 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_256_CBC_SHA")]
        TlsRsaWithAes256CbcSha = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS_RSA_WITH_AES_128_CBC_SHA")]
        TlsRsaWithAes128CbcSha = 16,
    }
    public partial class AppServiceTokenStore : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceTokenStore() { }
        public Azure.Provisioning.BicepValue<string> AzureBlobStorageSasUrlSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileSystemDirectory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> TokenRefreshExtensionHours { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceTwitterProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceTwitterProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppService.TwitterRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceUsageState
    {
        Normal = 0,
        Exceeded = 1,
    }
    public partial class AppServiceVirtualNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceVirtualNetworkProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceVirtualNetworkRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceVirtualNetworkRoute() { }
        public Azure.Provisioning.BicepValue<string> EndAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceVirtualNetworkRouteType> RouteType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartAddress { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceVirtualNetworkRouteType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DEFAULT")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="INHERITED")]
        Inherited = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="STATIC")]
        Static = 2,
    }
    public partial class ArcConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArcConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ArtifactStorageType> ArtifactsStorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ArtifactStorageAccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ArtifactStorageClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ArtifactStorageMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ArtifactStorageNodeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.FrontEndServiceType> FrontEndServiceKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubeConfig { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArtifactStorageType
    {
        LocalNode = 0,
        NetworkFileSystem = 1,
    }
    public partial class AseV3NetworkingConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AseV3NetworkingConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowNewPrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> ExternalInboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InboundIPAddressOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> InternalInboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsFtpEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRemoteDebugEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> LinuxOutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> WindowsOutboundIPAddresses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.AseV3NetworkingConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class AseV3NetworkingConfigurationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AseV3NetworkingConfigurationData() { }
        public Azure.Provisioning.BicepValue<bool> AllowNewPrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> ExternalInboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InboundIPAddressOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> InternalInboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsFtpEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRemoteDebugEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> LinuxOutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> WindowsOutboundIPAddresses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AuthPlatform : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AuthPlatform() { }
        public Azure.Provisioning.BicepValue<string> ConfigFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoGeneratedDomainNameLabelScope
    {
        TenantReuse = 0,
        SubscriptionReuse = 1,
        ResourceGroupReuse = 2,
        NoReuse = 3,
    }
    public partial class AutoHealActions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoHealActions() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AutoHealActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AutoHealCustomAction CustomAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinProcessExecutionTime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoHealActionType
    {
        Recycle = 0,
        LogEvent = 1,
        CustomAction = 2,
    }
    public partial class AutoHealCustomAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoHealCustomAction() { }
        public Azure.Provisioning.BicepValue<string> Exe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoHealRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoHealRules() { }
        public Azure.Provisioning.AppService.AutoHealActions Actions { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AutoHealTriggers Triggers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoHealTriggers : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoHealTriggers() { }
        public Azure.Provisioning.BicepValue<int> PrivateBytesInKB { get { throw null; } set { } }
        public Azure.Provisioning.AppService.RequestsBasedTrigger Requests { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SlowRequestsBasedTrigger SlowRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.SlowRequestsBasedTrigger> SlowRequestsWithPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StatusCodesBasedTrigger> StatusCodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StatusCodesRangeBasedTrigger> StatusCodesRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CertificateOrderContact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CertificateOrderContact() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NameFirst { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NameLast { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CertificateOrderStatus
    {
        Pendingissuance = 0,
        Issued = 1,
        Revoked = 2,
        Canceled = 3,
        Denied = 4,
        Pendingrevocation = 5,
        PendingRekey = 6,
        Unused = 7,
        Expired = 8,
        NotSubmitted = 9,
    }
    public enum CertificateProductType
    {
        StandardDomainValidatedSsl = 0,
        StandardDomainValidatedWildCardSsl = 1,
    }
    public enum ClientCertMode
    {
        Required = 0,
        Optional = 1,
        OptionalInteractiveUser = 2,
    }
    public enum ClientCredentialMethod
    {
        ClientSecretPost = 0,
    }
    public partial class ClientRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClientRegistration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CloningInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloningInfo() { }
        public Azure.Provisioning.BicepDictionary<string> AppSettingsOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CanOverwrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CloneCustomHostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CloneSourceControl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ConfigureLoadBalancing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> CorrelationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostingEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceWebAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> SourceWebAppLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TrafficManagerProfileId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrafficManagerProfileName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComputeModeOption
    {
        Shared = 0,
        Dedicated = 1,
        Dynamic = 2,
    }
    public enum ConnectionStringType
    {
        MySql = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLServer")]
        SqlServer = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLAzure")]
        SqlAzure = 2,
        Custom = 3,
        NotificationHub = 4,
        ServiceBus = 5,
        EventHub = 6,
        ApiHub = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DocDb")]
        DocDB = 8,
        RedisCache = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PostgreSQL")]
        PostgreSql = 10,
    }
    public partial class ConnStringInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnStringInfo() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ConnectionStringType> ConnectionStringType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AppSubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ControlPlaneSubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DaprAIInstrumentationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerBridgeCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlatformReservedCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlatformReservedDnsIP { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CookieExpirationConvention
    {
        FixedTime = 0,
        IdentityProviderDerived = 1,
    }
    public partial class CustomDnsSuffixConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CustomDnsSuffixConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomDnsSuffixProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.CustomDnsSuffixConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class CustomDnsSuffixConfigurationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDnsSuffixConfigurationData() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomDnsSuffixProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomDnsSuffixProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Degraded = 2,
        InProgress = 3,
    }
    public enum CustomDomainStatus
    {
        RetrievingValidationToken = 0,
        Validating = 1,
        Adding = 2,
        Ready = 3,
        Failed = 4,
        Deleting = 5,
        Unhealthy = 6,
    }
    public enum CustomHostNameDnsRecordType
    {
        CName = 0,
        A = 1,
    }
    public partial class CustomOpenIdConnectProvider : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomOpenIdConnectProvider() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppService.OpenIdConnectLogin Login { get { throw null; } set { } }
        public Azure.Provisioning.AppService.OpenIdConnectRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DefaultAuthorizationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefaultAuthorizationPolicy() { }
        public Azure.Provisioning.BicepList<string> AllowedApplications { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceAadAllowedPrincipals AllowedPrincipals { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DomainNotRenewableReason
    {
        RegistrationStatusNotSupportedForRenewal = 0,
        ExpirationNotInRenewalTimeRange = 1,
        SubscriptionNotActive = 2,
    }
    public partial class DomainOwnershipIdentifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DomainOwnershipIdentifier(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OwnershipId { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceDomain? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.DomainOwnershipIdentifier FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2018_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class DomainPurchaseConsent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DomainPurchaseConsent() { }
        public Azure.Provisioning.BicepValue<string> AgreedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AgreedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AgreementKeys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnterpriseGradeCdnStatus
    {
        Enabled = 0,
        Enabling = 1,
        Disabled = 2,
        Disabling = 3,
    }
    public partial class FileSystemHttpLogsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FileSystemHttpLogsConfig() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInMb { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ForwardProxyConvention
    {
        NoProxy = 0,
        Standard = 1,
        Custom = 2,
    }
    public enum FrontEndServiceType
    {
        NodePort = 0,
        LoadBalancer = 1,
    }
    public partial class FunctionAppAlwaysReadyConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppAlwaysReadyConfig() { }
        public Azure.Provisioning.BicepValue<int> AlwaysReadyInstanceCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<float> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FunctionAppConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppConfig() { }
        public Azure.Provisioning.AppService.FunctionAppStorage DeploymentStorage { get { throw null; } set { } }
        public Azure.Provisioning.AppService.FunctionAppRuntime Runtime { get { throw null; } set { } }
        public Azure.Provisioning.AppService.FunctionAppScaleAndConcurrency ScaleAndConcurrency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FunctionAppResourceConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppResourceConfig() { }
        public Azure.Provisioning.BicepValue<double> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Memory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FunctionAppRuntime : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppRuntime() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.FunctionAppRuntimeName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FunctionAppRuntimeName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="dotnet-isolated")]
        DotnetIsolated = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="node")]
        Node = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="java")]
        Java = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="powershell")]
        Powershell = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="python")]
        Python = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="custom")]
        Custom = 5,
    }
    public partial class FunctionAppScaleAndConcurrency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppScaleAndConcurrency() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.FunctionAppAlwaysReadyConfig> AlwaysReady { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConcurrentHttpPerInstanceConcurrency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FunctionAppInstanceMemoryMB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FunctionAppMaximumInstanceCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<float> HttpPerInstanceConcurrency { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<float> InstanceMemoryMB { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<float> MaximumInstanceCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FunctionAppStorage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppStorage() { }
        public Azure.Provisioning.AppService.FunctionAppStorageAuthentication Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.FunctionAppStorageType> StorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FunctionAppStorageAccountAuthenticationType
    {
        SystemAssignedIdentity = 0,
        UserAssignedIdentity = 1,
        StorageAccountConnectionString = 2,
    }
    public partial class FunctionAppStorageAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FunctionAppStorageAuthentication() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.FunctionAppStorageAccountAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountConnectionStringName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FunctionAppStorageType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="blobContainer")]
        BlobContainer = 0,
    }
    public partial class GitHubActionCodeConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubActionCodeConfiguration() { }
        public Azure.Provisioning.BicepValue<string> RuntimeStack { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubActionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubActionConfiguration() { }
        public Azure.Provisioning.AppService.GitHubActionCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.AppService.GitHubActionContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> GenerateWorkflowFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLinux { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubActionContainerConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubActionContainerConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GlobalValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GlobalValidation() { }
        public Azure.Provisioning.BicepList<string> ExcludedPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAuthenticationRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RedirectToProvider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.UnauthenticatedClientActionV2> UnauthenticatedClientAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HostingEnvironmentMultiRolePool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HostingEnvironmentMultiRolePool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ComputeModeOption> ComputeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> InstanceNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkerSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WorkerSizeId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.HostingEnvironmentMultiRolePool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class HostingEnvironmentPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HostingEnvironmentPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.AppService.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.HostingEnvironmentPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_01_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class HostingEnvironmentProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostingEnvironmentProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HostingEnvironmentStatus
    {
        Preparing = 0,
        Ready = 1,
        Scaling = 2,
        Deleting = 3,
    }
    public partial class HostingEnvironmentWorkerPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HostingEnvironmentWorkerPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ComputeModeOption> ComputeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> InstanceNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkerSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WorkerSizeId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.HostingEnvironmentWorkerPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum HostNameBindingSslState
    {
        Disabled = 0,
        SniEnabled = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpBasedEnabled")]
        IPBasedEnabled = 2,
    }
    public partial class HostNameSslState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostNameSslState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceHostType> HostType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.HostNameBindingSslState> SslState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ToUpdate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualIP { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HttpRequestHandlerMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HttpRequestHandlerMapping() { }
        public Azure.Provisioning.BicepValue<string> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Extension { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptProcessor { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JwtClaimChecks : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JwtClaimChecks() { }
        public Azure.Provisioning.BicepList<string> AllowedClientApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultSecretStatus
    {
        Unknown = 0,
        Initialized = 1,
        WaitingOnCertificateOrder = 2,
        Succeeded = 3,
        CertificateOrderFailed = 4,
        OperationNotPermittedOnKeyVault = 5,
        AzureServiceUnauthorizedToAccessKeyVault = 6,
        KeyVaultDoesNotExist = 7,
        KeyVaultSecretDoesNotExist = 8,
        UnknownError = 9,
        ExternalPrivateKey = 10,
    }
    public partial class KubeEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubeEnvironment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AksResourceId { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.AppService.ArcConfiguration ArcConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.AppService.ContainerAppsConfiguration ContainerAppsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeploymentErrors { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EnvironmentType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsInternalLoadBalancerEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KubeEnvironmentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StaticIP { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.KubeEnvironment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class KubeEnvironmentProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubeEnvironmentProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubeEnvironmentProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Waiting = 3,
        InitializationInProgress = 4,
        InfrastructureSetupInProgress = 5,
        InfrastructureSetupComplete = 6,
        ScheduledForDelete = 7,
        UpgradeRequested = 8,
        UpgradeFailed = 9,
    }
    public partial class LegacyMicrosoftAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LegacyMicrosoftAccount() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppService.ClientRegistration Registration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ValidationAllowedAudiences { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancingMode
    {
        None = 0,
        Web = 1,
        Publishing = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Web, Publishing")]
        WebPublishing = 3,
    }
    public partial class LogAnalyticsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogAnalyticsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoginFlowNonceSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoginFlowNonceSettings() { }
        public Azure.Provisioning.BicepValue<string> NonceExpirationInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateNonce { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogsSiteConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogsSiteConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppService.ApplicationLogsConfig ApplicationLogs { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceHttpLogsConfig HttpLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedErrorMessagesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFailedRequestsTracingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.LogsSiteConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class LogsSiteSlotConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogsSiteSlotConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppService.ApplicationLogsConfig ApplicationLogs { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceHttpLogsConfig HttpLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedErrorMessagesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFailedRequestsTracingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.LogsSiteSlotConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum ManagedPipelineMode
    {
        Integrated = 0,
        Classic = 1,
    }
    public enum MSDeployProvisioningState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="accepted")]
        Accepted = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="running")]
        Running = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="succeeded")]
        Succeeded = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="failed")]
        Failed = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="canceled")]
        Canceled = 4,
    }
    public partial class OpenIdConnectClientCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenIdConnectClientCredential() { }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ClientCredentialMethod> Method { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OpenIdConnectConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenIdConnectConfig() { }
        public Azure.Provisioning.BicepValue<string> AuthorizationEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> CertificationUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WellKnownOpenIdConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OpenIdConnectLogin : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenIdConnectLogin() { }
        public Azure.Provisioning.BicepValue<string> NameClaimType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OpenIdConnectRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenIdConnectRegistration() { }
        public Azure.Provisioning.AppService.OpenIdConnectClientCredential ClientCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.AppService.OpenIdConnectConfig OpenIdConnectConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OutboundVnetRouting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OutboundVnetRouting() { }
        public Azure.Provisioning.BicepValue<bool> IsAllTrafficEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApplicationTrafficEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBackupRestoreTrafficEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsContentShareTrafficEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsImagePullTrafficEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateAccessSubnet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateAccessSubnet() { }
        public Azure.Provisioning.BicepValue<int> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateAccessVirtualNetwork : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateAccessVirtualNetwork() { }
        public Azure.Provisioning.BicepValue<int> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.PrivateAccessSubnet> Subnets { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateLinkConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public enum PublicCertificateLocation
    {
        Unknown = 0,
        CurrentUserMy = 1,
        LocalMachineMy = 2,
    }
    public partial class PublishingUser : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PublishingUser(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublishingPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingPasswordHash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingPasswordHashSalt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ScmUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.PublishingUser FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class RampUpRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RampUpRule() { }
        public Azure.Provisioning.BicepValue<string> ActionHostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ChangeDecisionCallbackUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ChangeIntervalInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ChangeStep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MaxReroutePercentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinReroutePercentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ReroutePercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RedundancyMode
    {
        None = 0,
        Manual = 1,
        Failover = 2,
        ActiveActive = 3,
        GeoRedundant = 4,
    }
    public partial class RegistrationAddressInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistrationAddressInfo() { }
        public Azure.Provisioning.BicepValue<string> Address1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Address2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostalCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistrationContactInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistrationContactInfo() { }
        public Azure.Provisioning.AppService.RegistrationAddressInfo AddressMailing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JobTitle { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameFirst { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameLast { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NameMiddle { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Organization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RemotePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RemotePrivateEndpointConnection() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.AppService.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RequestsBasedTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestsBasedTrigger() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponseMessageEnvelopeRemotePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseMessageEnvelopeRemotePrivateEndpointConnection() { }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceArmPlan Plan { get { throw null; } }
        public Azure.Provisioning.AppService.RemotePrivateEndpointConnection Properties { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScmSiteBasicPublishingCredentialsPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScmSiteBasicPublishingCredentialsPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.ScmSiteBasicPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class ScmSiteSlotBasicPublishingCredentialsPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScmSiteSlotBasicPublishingCredentialsPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.ScmSiteSlotBasicPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum ScmType
    {
        None = 0,
        Dropbox = 1,
        Tfs = 2,
        LocalGit = 3,
        GitHub = 4,
        CodePlexGit = 5,
        CodePlexHg = 6,
        BitbucketGit = 7,
        BitbucketHg = 8,
        ExternalGit = 9,
        ExternalHg = 10,
        OneDrive = 11,
        VSO = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VSTSRM")]
        Vstsrm = 13,
    }
    public partial class SiteAuthSettingsV2 : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteAuthSettingsV2(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppService.GlobalValidation GlobalValidation { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceHttpSettings HttpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.AppService.AppServiceIdentityProviders IdentityProviders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebAppLoginInfo Login { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AuthPlatform Platform { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteAuthSettingsV2 FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SiteCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CanonicalName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CerBlob { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DomainValidationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KeyVaultSecretStatus> KeyVaultSecretStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PfxBlob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicKeyHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelfLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServerFarmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SiteConfigProperties() { }
        public Azure.Provisioning.BicepValue<string> AcrUserManagedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowIPSecurityRestrictionsForScmToUseMain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ApiDefinitionUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiManagementConfigId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppCommandLine { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> AppSettings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AutoSwapSlotName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppService.AppServiceStorageAccessInfo> AzureStorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceCorsSettings Cors { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DefaultDocuments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DocumentRoot { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ElasticWebAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.RampUpRule> ExperimentsRampUpRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceFtpsState> FtpsState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FunctionAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.HttpRequestHandlerMapping> HandlerMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HealthCheckPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Http20ProxyFlag { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> IPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAlwaysOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoHealEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedErrorLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttp20Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalMySqlEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequestTracingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetRouteAllEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebSocketsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteLimits Limits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinuxFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteLoadBalancing> LoadBalancing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ManagedPipelineMode> ManagedPipelineMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ManagedServiceIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceTlsCipherSuite> MinTlsCipherSuite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> MinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetFrameworkVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhpVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PowerShellVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreWarmedInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingUsername { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebAppPushSettings Push { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PythonVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemoteDebuggingVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestTracingExpirationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> ScmIPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ScmType> ScmType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TracingOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Use32BitWorkerProcess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseManagedIdentityCreds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VnetPrivatePortsCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebsiteTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WindowsFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> XManagedServiceIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SiteContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteContainer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteContainerAuthType> AuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.WebAppEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> InheritAppSettingsAndConnectionStrings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartUpCommand { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.SiteContainerVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteContainer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum SiteContainerAuthType
    {
        Anonymous = 0,
        UserCredentials = 1,
        SystemIdentity = 2,
        UserAssigned = 3,
    }
    public partial class SiteContainerVolumeMount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SiteContainerVolumeMount() { }
        public Azure.Provisioning.BicepValue<string> ContainerMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VolumeSubPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SiteDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class SiteDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteDeployment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Author { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorEmail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsActive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteDeployment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteDnsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SiteDnsConfig() { }
        public Azure.Provisioning.BicepValue<string> DnsAltServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DnsLegacySortOrder { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DnsMaxCacheTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DnsRetryAttemptCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DnsRetryAttemptTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SiteDomainOwnershipIdentifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteDomainOwnershipIdentifier(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteDomainOwnershipIdentifier FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DBType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAppOffline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.MSDeployProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> SetParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SetParametersXmlFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipAppData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum SiteExtensionType
    {
        Gallery = 0,
        WebRoot = 1,
    }
    public partial class SiteFunction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteFunction(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Config { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConfigHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Files { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Href { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvokeUrlTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptRootPathHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretsFileHref { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TestData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TestDataHref { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteFunction FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteHostNameBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteHostNameBinding(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AzureResourceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceResourceType> AzureResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomHostNameDnsRecordType> CustomHostNameDnsRecordType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceHostNameType> HostNameType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.HostNameBindingSslState> SslState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualIP { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteHostNameBinding FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteHybridConnectionNamespaceRelay : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteHybridConnectionNamespaceRelay(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RelayArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SendKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SendKeyValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusSuffix { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteHybridConnectionNamespaceRelay FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SiteInstanceExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteInstanceExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DBType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAppOffline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.MSDeployProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> SetParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SetParametersXmlFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipAppData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteInstanceExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SiteLimits : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SiteLimits() { }
        public Azure.Provisioning.BicepValue<long> MaxDiskSizeInMb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxMemoryInMb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MaxPercentageCpu { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SiteLoadBalancing
    {
        WeightedRoundRobin = 0,
        LeastRequests = 1,
        LeastResponseTime = 2,
        WeightedTotalTraffic = 3,
        RequestHash = 4,
        PerSiteRoundRobin = 5,
        LeastRequestsWithTieBreaker = 6,
    }
    public partial class SiteMachineKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SiteMachineKey() { }
        public Azure.Provisioning.BicepValue<string> Decryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DecryptionKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Validation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SiteNetworkConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteNetworkConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSwiftSupported { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteNetworkConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SitePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SitePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.AppService.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SitePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SitePublicCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SitePublicCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Blob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.PublicCertificateLocation> PublicCertificateLocation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SitePublicCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CanonicalName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CerBlob { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DomainValidationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.KeyVaultSecretStatus> KeyVaultSecretStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PfxBlob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicKeyHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelfLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServerFarmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotDeployment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Author { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthorEmail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsActive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotDeployment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotDomainOwnershipIdentifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotDomainOwnershipIdentifier(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotDomainOwnershipIdentifier FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DBType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAppOffline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.MSDeployProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> SetParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SetParametersXmlFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipAppData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotFunction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotFunction(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Config { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConfigHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Files { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Href { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InvokeUrlTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptRootPathHref { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretsFileHref { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TestData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TestDataHref { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotFunction FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotHostNameBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotHostNameBinding(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AzureResourceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceResourceType> AzureResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomHostNameDnsRecordType> CustomHostNameDnsRecordType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceHostNameType> HostNameType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.HostNameBindingSslState> SslState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualIP { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotHostNameBinding FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotHybridConnectionNamespaceRelay : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotHybridConnectionNamespaceRelay(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RelayArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SendKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SendKeyValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusSuffix { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotHybridConnectionNamespaceRelay FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SiteSlotInstanceExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotInstanceExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DBType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deployer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAppOffline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.MSDeployProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> SetParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SetParametersXmlFileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipAppData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotInstanceExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SiteSlotNetworkConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotNetworkConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSwiftSupported { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotNetworkConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.AppService.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotSiteContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotSiteContainer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteContainerAuthType> AuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.WebAppEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> InheritAppSettingsAndConnectionStrings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartUpCommand { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.SiteContainerVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotSiteContainer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotVirtualNetworkConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotVirtualNetworkConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CertBlob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertThumbprintString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsResyncRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSwift { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceVirtualNetworkRoute> Routes { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotVirtualNetworkConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteSlotVirtualNetworkConnectionGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteSlotVirtualNetworkConnectionGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteSlotVirtualNetworkConnection? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VpnPackageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteSlotVirtualNetworkConnectionGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteVirtualNetworkConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteVirtualNetworkConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CertBlob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertThumbprintString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsResyncRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSwift { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceVirtualNetworkRoute> Routes { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteVirtualNetworkConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SiteVirtualNetworkConnectionGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SiteVirtualNetworkConnectionGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteVirtualNetworkConnection? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VpnPackageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SiteVirtualNetworkConnectionGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SlotConfigNames : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SlotConfigNames(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AppSettingNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AzureStorageConfigNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ConnectionStringNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.SlotConfigNames FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class SlotSwapStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SlotSwapStatus() { }
        public Azure.Provisioning.BicepValue<string> DestinationSlotName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceSlotName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimestampUtc { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SlowRequestsBasedTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SlowRequestsBasedTrigger() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeTaken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StagingEnvironmentPolicy
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class StaticSite : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSite(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowConfigFileUpdates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentDistributionEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepList<string> CustomDomains { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteDatabaseConnectionOverview> DatabaseConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultHostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.EnterpriseGradeCdnStatus> EnterpriseGradeCdnStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteLinkedBackendInfo> LinkedBackends { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.ResponseMessageEnvelopeRemotePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Provider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.StagingEnvironmentPolicy> StagingEnvironmentPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSiteTemplate TemplateProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSite FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum StaticSiteBasicAuthName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class StaticSiteBasicAuthProperty : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteBasicAuthProperty(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApplicableEnvironmentsMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Environments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SecretUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteBasicAuthProperty FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteBuildDatabaseConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteBuildDatabaseConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteDatabaseConnectionConfigurationFileOverview> ConfigurationFiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteBuildDatabaseConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteBuildLinkedBackend : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteBuildLinkedBackend(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteBuildLinkedBackend FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteBuildProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteBuildProperties() { }
        public Azure.Provisioning.BicepValue<string> ApiBuildCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppArtifactLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppBuildCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GithubActionSecretNameOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OutputLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipGithubActionWorkflowGeneration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticSiteBuildUserProvidedFunctionApp : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteBuildUserProvidedFunctionApp(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FunctionAppRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FunctionAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteBuildUserProvidedFunctionApp FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteCustomDomainOverview : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteCustomDomainOverview(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DomainName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CustomDomainStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationToken { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteCustomDomainOverview FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteDatabaseConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteDatabaseConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteDatabaseConnectionConfigurationFileOverview> ConfigurationFiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteDatabaseConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteDatabaseConnectionConfigurationFileOverview : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteDatabaseConnectionConfigurationFileOverview() { }
        public Azure.Provisioning.BicepValue<string> Contents { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StaticSiteDatabaseConnectionConfigurationFileOverviewType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticSiteDatabaseConnectionOverview : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteDatabaseConnectionOverview() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.StaticSiteDatabaseConnectionConfigurationFileOverview> ConfigurationFiles { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionIdentity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticSiteLinkedBackend : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteLinkedBackend(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteLinkedBackend FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteLinkedBackendInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteLinkedBackendInfo() { }
        public Azure.Provisioning.BicepValue<string> BackendResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticSitePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSitePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> IPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.AppService.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSitePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteTemplate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteTemplate() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Owner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> TemplateRepositoryUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticSiteUserProvidedFunctionApp : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StaticSiteUserProvidedFunctionApp(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FunctionAppRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FunctionAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.StaticSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.StaticSiteUserProvidedFunctionApp FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class StaticSiteUserProvidedFunctionAppData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StaticSiteUserProvidedFunctionAppData() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FunctionAppRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FunctionAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StatusCodesBasedTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StatusCodesBasedTrigger() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SubStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Win32Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StatusCodesRangeBasedTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StatusCodesRangeBasedTrigger() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StatusCodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TwitterRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TwitterRegistration() { }
        public Azure.Provisioning.BicepValue<string> ConsumerKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConsumerSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UnauthenticatedClientActionV2
    {
        RedirectToLoginPage = 0,
        AllowAnonymous = 1,
        Return401 = 2,
        Return403 = 3,
    }
    public partial class VirtualApplication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualApplication() { }
        public Azure.Provisioning.BicepValue<bool> IsPreloadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhysicalPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.VirtualDirectory> VirtualDirectories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualDirectory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualDirectory() { }
        public Azure.Provisioning.BicepValue<string> PhysicalPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebAppCookieExpiration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebAppCookieExpiration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.CookieExpirationConvention> Convention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeToExpiration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebAppEnvironmentVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebAppEnvironmentVariable() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebAppLoginInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebAppLoginInfo() { }
        public Azure.Provisioning.BicepList<string> AllowedExternalRedirectUrls { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebAppCookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.Provisioning.AppService.LoginFlowNonceSettings Nonce { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoutesLogoutEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceTokenStore TokenStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebAppLogLevel
    {
        Off = 0,
        Verbose = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
    }
    public partial class WebAppPushSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebAppPushSettings() { }
        public Azure.Provisioning.BicepValue<string> DynamicTagsJson { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPushEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TagsRequiringAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TagWhitelistJson { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebSite : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSite(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AppServicePlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AutoGeneratedDomainNameLabelScope> AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.WebSiteAvailabilityState> AvailabilityState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ClientCertMode> ClientCertMode { get { throw null; } set { } }
        public Azure.Provisioning.AppService.CloningInfo CloningInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ContainerSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomDomainVerificationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DailyMemoryTimeQuota { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppDaprConfig DaprConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultHostName { get { throw null; } }
        public Azure.Provisioning.AppService.SiteDnsConfig DnsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledHostNames { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.AppService.FunctionAppConfig FunctionAppConfig { get { throw null; } set { } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.HostNameSslState> HostNameSslStates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> InProgressOperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceIPMode> IPMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityPartitioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultContainer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEndToEndEncryptionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHostNameDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpsOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHyperV { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsScmSiteAlsoStopped { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSshEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageAccountRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetBackupRestoreEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetContentShareEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetImagePullEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetRouteAllEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsXenon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedTimeUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedEnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxNumberOfWorkers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.AppService.OutboundVnetRouting OutboundVnetRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.RedundancyMode> RedundancyMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositorySiteName { get { throw null; } }
        public Azure.Provisioning.AppService.FunctionAppResourceConfig ResourceConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } }
        public Azure.Provisioning.AppService.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } }
        public Azure.Provisioning.AppService.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SuspendOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetSwapSlot { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceUsageState> UsageState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadProfileName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSite FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public enum WebSiteAvailabilityState
    {
        Normal = 0,
        Limited = 1,
        DisasterRecoveryMode = 2,
    }
    public partial class WebSiteConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AcrUserManagedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowIPSecurityRestrictionsForScmToUseMain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ApiDefinitionUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiManagementConfigId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppCommandLine { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> AppSettings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AutoSwapSlotName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppService.AppServiceStorageAccessInfo> AzureStorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceCorsSettings Cors { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DefaultDocuments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DocumentRoot { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ElasticWebAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.RampUpRule> ExperimentsRampUpRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceFtpsState> FtpsState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FunctionAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.HttpRequestHandlerMapping> HandlerMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HealthCheckPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Http20ProxyFlag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> IPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAlwaysOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoHealEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedErrorLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttp20Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalMySqlEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequestTracingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetRouteAllEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebSocketsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteLimits Limits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinuxFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteLoadBalancing> LoadBalancing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ManagedPipelineMode> ManagedPipelineMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ManagedServiceIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceTlsCipherSuite> MinTlsCipherSuite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> MinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NetFrameworkVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhpVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PowerShellVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreWarmedInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingUsername { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebAppPushSettings Push { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PythonVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemoteDebuggingVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestTracingExpirationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> ScmIPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ScmType> ScmType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TracingOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Use32BitWorkerProcess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseManagedIdentityCreds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VnetPrivatePortsCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebsiteTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WindowsFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> XManagedServiceIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Authors { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Comment { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DownloadCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteExtensionType> ExtensionType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ExtensionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> FeedUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IconUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InstalledOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InstallerCommandLineParams { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> LicenseUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> LocalIsLatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ProjectUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteFtpPublishingCredentialsPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteFtpPublishingCredentialsPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteFtpPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteHybridConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteHybridConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> BiztalkUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteHybridConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSitePremierAddon : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSitePremierAddon(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplaceOffer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplacePublisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Vendor { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSitePremierAddon FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2016_03_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSitePrivateAccess : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSitePrivateAccess(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.PrivateAccessVirtualNetwork> VirtualNetworks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSitePrivateAccess FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlot(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AppServicePlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AutoGeneratedDomainNameLabelScope> AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.WebSiteAvailabilityState> AvailabilityState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ClientCertMode> ClientCertMode { get { throw null; } set { } }
        public Azure.Provisioning.AppService.CloningInfo CloningInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ContainerSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomDomainVerificationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DailyMemoryTimeQuota { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppDaprConfig DaprConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultHostName { get { throw null; } }
        public Azure.Provisioning.AppService.SiteDnsConfig DnsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledHostNames { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.AppService.FunctionAppConfig FunctionAppConfig { get { throw null; } set { } }
        public Azure.Provisioning.AppService.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostNames { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.HostNameSslState> HostNameSslStates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> InProgressOperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceIPMode> IPMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityPartitioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientAffinityProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultContainer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEndToEndEncryptionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHostNameDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpsOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHyperV { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsScmSiteAlsoStopped { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSshEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageAccountRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetBackupRestoreEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetContentShareEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetImagePullEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetRouteAllEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsXenon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedTimeUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedEnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxNumberOfWorkers { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.AppService.OutboundVnetRouting OutboundVnetRouting { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.RedundancyMode> RedundancyMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositorySiteName { get { throw null; } }
        public Azure.Provisioning.AppService.FunctionAppResourceConfig ResourceConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } }
        public Azure.Provisioning.AppService.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } }
        public Azure.Provisioning.AppService.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SuspendOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetSwapSlot { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceUsageState> UsageState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadProfileName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlot FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AcrUserManagedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowIPSecurityRestrictionsForScmToUseMain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ApiDefinitionUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiManagementConfigId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppCommandLine { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> AppSettings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AutoSwapSlotName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppService.AppServiceStorageAccessInfo> AzureStorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.Provisioning.AppService.AppServiceCorsSettings Cors { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DefaultDocuments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DocumentRoot { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ElasticWebAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.RampUpRule> ExperimentsRampUpRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceFtpsState> FtpsState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FunctionAppScaleLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.HttpRequestHandlerMapping> HandlerMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HealthCheckPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Http20ProxyFlag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> IPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAlwaysOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoHealEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedErrorLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttp20Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalMySqlEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequestTracingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetRouteAllEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebSocketsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaContainerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JavaVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteLimits Limits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinuxFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteLoadBalancing> LoadBalancing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.Provisioning.AppService.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ManagedPipelineMode> ManagedPipelineMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ManagedServiceIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceNameValuePair> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceTlsCipherSuite> MinTlsCipherSuite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> MinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NetFrameworkVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhpVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PowerShellVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PreWarmedInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingUsername { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebAppPushSettings Push { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PythonVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RemoteDebuggingVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestTracingExpirationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteDefaultAction> ScmIPSecurityRestrictionsDefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.AppServiceSupportedTlsVersion> ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.ScmType> ScmType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TracingOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Use32BitWorkerProcess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseManagedIdentityCreds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VnetPrivatePortsCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebsiteTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WindowsFxVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> XManagedServiceIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Authors { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Comment { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DownloadCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.SiteExtensionType> ExtensionType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ExtensionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> FeedUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IconUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> InstalledOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InstallerCommandLineParams { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> LicenseUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> LocalIsLatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LocalPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ProjectUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotFtpPublishingCredentialsPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotFtpPublishingCredentialsPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Allow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotFtpPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotHybridConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotHybridConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> BiztalkUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntityName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotHybridConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotPremierAddOn : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotPremierAddOn(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplaceOffer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplacePublisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Vendor { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotPremierAddOn FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotPrivateAccess : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotPrivateAccess(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppService.PrivateAccessVirtualNetwork> VirtualNetworks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotPrivateAccess FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotPublicCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotPublicCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Blob { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppService.PublicCertificateLocation> PublicCertificateLocation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotPublicCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSlotSourceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSlotSourceControl(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.AppService.GitHubActionConfiguration GitHubActionConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeploymentRollbackEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGitHubAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManualIntegration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMercurial { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSiteSlot? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepoUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSlotSourceControl FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class WebSiteSourceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WebSiteSourceControl(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.AppService.GitHubActionConfiguration GitHubActionConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeploymentRollbackEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGitHubAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManualIntegration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMercurial { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.AppService.WebSite? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepoUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppService.WebSiteSourceControl FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_06_01;
            public static readonly string V2014_11_01;
            public static readonly string V2015_01_01;
            public static readonly string V2015_02_01;
            public static readonly string V2015_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2015_06_01;
            public static readonly string V2015_07_01;
            public static readonly string V2015_08_01;
            public static readonly string V2015_11_01;
            public static readonly string V2016_03_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2017_08_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_08_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_10_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_12_01;
            public static readonly string V2024_04_01;
            public static readonly string V2024_11_01;
        }
    }
}
