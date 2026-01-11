namespace Azure.Provisioning.AppContainers
{
    public partial class AppContainerResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppContainerResources() { }
        public Azure.Provisioning.BicepValue<double> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EphemeralStorage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Memory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppContainersBuiltInRole : System.IEquatable<Azure.Provisioning.AppContainers.AppContainersBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppContainersBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.AppContainers.AppContainersBuiltInRole Contributor { get { throw null; } }
        public static Azure.Provisioning.AppContainers.AppContainersBuiltInRole Owner { get { throw null; } }
        public static Azure.Provisioning.AppContainers.AppContainersBuiltInRole Reader { get { throw null; } }
        public bool Equals(Azure.Provisioning.AppContainers.AppContainersBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.AppContainers.AppContainersBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.AppContainers.AppContainersBuiltInRole left, Azure.Provisioning.AppContainers.AppContainersBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.AppContainers.AppContainersBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.AppContainers.AppContainersBuiltInRole left, Azure.Provisioning.AppContainers.AppContainersBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerApp : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerApp(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.ContainerAppConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomDomainVerificationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EventStreamEndpoint { get { throw null; } }
        public Azure.Provisioning.AppContainers.ContainerAppExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestReadyRevisionName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LatestRevisionFqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LatestRevisionName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedEnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> OutboundIPAddressList { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppRunningStatus> RunningStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTemplate Template { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadProfileName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerApp FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum ContainerAppAccessMode
    {
        ReadOnly = 0,
        ReadWrite = 1,
    }
    public enum ContainerAppActiveRevisionsMode
    {
        Multiple = 0,
        Single = 1,
    }
    public partial class ContainerAppAllowedPrincipals : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAllowedPrincipals() { }
        public Azure.Provisioning.BicepList<string> Groups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Identities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAppleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAppleConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAppleRegistrationConfiguration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAppleRegistrationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAppleRegistrationConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAuthConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppAuthConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.EncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppGlobalValidation GlobalValidation { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppHttpSettings HttpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.AppContainers.ContainerAppIdentityProvidersConfiguration IdentityProviders { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppLogin Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerApp? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAuthPlatform Platform { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppAuthConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppAuthPlatform : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAuthPlatform() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureActiveDirectoryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureActiveDirectoryConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsAutoProvisioned { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureActiveDirectoryLoginConfiguration Login { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureActiveDirectoryRegistrationConfiguration Registration { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureActiveDirectoryValidationConfiguration Validation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureActiveDirectoryLoginConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureActiveDirectoryLoginConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsWwwAuthenticationDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureActiveDirectoryRegistrationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureActiveDirectoryRegistrationConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateIssuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateSubjectAlternativeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OpenIdIssuer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureActiveDirectoryValidationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureActiveDirectoryValidationConfiguration() { }
        public Azure.Provisioning.BicepList<string> AllowedAudiences { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppDefaultAuthorizationPolicy DefaultAuthorizationPolicy { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppJwtClaimChecks JwtClaimChecks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureFileProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureFileProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShareName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppAzureStaticWebAppsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppAzureStaticWebAppsConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistrationClientId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCertificateKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCertificateKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCertificateProperties() { }
        public Azure.Provisioning.AppContainers.ContainerAppCertificateKeyVaultProperties CertificateKeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IssueOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppCertificateProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicKeyHash { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SubjectAlternativeNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppCertificateProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        DeleteFailed = 3,
        Pending = 4,
    }
    public partial class ContainerAppClientRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppClientRegistration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppActiveRevisionsMode> ActiveRevisionsMode { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppDaprConfiguration Dapr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableMetrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppIdentitySettings> IdentitySettings { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppIngressConfiguration Ingress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxInactiveRevisions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppRegistryCredentials> Registries { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppWritableSecret> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppConnectedEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppConnectedEnvironment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.ContainerAppCustomDomainConfiguration CustomDomainConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DaprAIConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeploymentErrors { get { throw null; } }
        public Azure.Provisioning.AppContainers.ContainerAppExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironmentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StaticIP { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppConnectedEnvironmentCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppConnectedEnvironmentCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCertificateProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironmentCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppConnectedEnvironmentDaprComponent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppConnectedEnvironmentDaprComponent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ComponentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IgnoreErrors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppDaprMetadata> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppWritableSecret> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretStoreComponent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironmentDaprComponent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum ContainerAppConnectedEnvironmentProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Waiting = 3,
        InitializationInProgress = 4,
        InfrastructureSetupInProgress = 5,
        InfrastructureSetupComplete = 6,
        ScheduledForDelete = 7,
    }
    public partial class ContainerAppConnectedEnvironmentStorage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppConnectedEnvironmentStorage(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.ContainerAppAzureFileProperties ConnectedEnvironmentStorageAzureFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppConnectedEnvironmentStorage FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppContainer() { }
        public Azure.Provisioning.BicepList<string> Args { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppEnvironmentVariable> Env { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppProbe> Probes { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.AppContainerResources Resources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCookieExpiration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCookieExpiration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppCookieExpirationConvention> Convention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeToExpiration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppCookieExpirationConvention
    {
        FixedTime = 0,
        IdentityProviderDerived = 1,
    }
    public partial class ContainerAppCorsPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCorsPolicy() { }
        public Azure.Provisioning.BicepValue<bool> AllowCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExposeHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAge { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCredentials() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCustomDomain : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCustomDomain() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppCustomDomainBindingType> BindingType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppCustomDomainBindingType
    {
        Disabled = 0,
        SniEnabled = 1,
    }
    public partial class ContainerAppCustomDomainConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCustomDomainConfiguration() { }
        public Azure.Provisioning.AppContainers.ContainerAppCertificateKeyVaultProperties CertificateKeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertificatePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CertificateValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomDomainVerificationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DnsSuffix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCustomOpenIdConnectProviderConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCustomOpenIdConnectProviderConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppOpenIdConnectLogin Login { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppOpenIdConnectRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppCustomScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppCustomScaleRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRuleAuth> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomScaleRuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppDaprConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppDaprConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AppPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppProtocol> AppProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpMaxRequestSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpReadBufferSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsApiLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppDaprLogLevel> LogLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppDaprLogLevel
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
    public partial class ContainerAppDaprMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppDaprMetadata() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppDefaultAuthorizationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppDefaultAuthorizationPolicy() { }
        public Azure.Provisioning.BicepList<string> AllowedApplications { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAllowedPrincipals AllowedPrincipals { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppEnvironmentProvisioningState
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
    public partial class ContainerAppEnvironmentVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppEnvironmentVariable() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppExtendedLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppExtendedLocation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppExtendedLocationType> ExtendedLocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppExtendedLocationType
    {
        CustomLocation = 0,
    }
    public partial class ContainerAppFacebookConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppFacebookConfiguration() { }
        public Azure.Provisioning.BicepValue<string> GraphApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppForwardProxy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppForwardProxy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppForwardProxyConvention> Convention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomHostHeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomProtoHeaderName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppForwardProxyConvention
    {
        NoProxy = 0,
        Standard = 1,
        Custom = 2,
    }
    public partial class ContainerAppGitHubActionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppGitHubActionConfiguration() { }
        public Azure.Provisioning.AppContainers.ContainerAppCredentials AzureCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContextPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GitHubPersonalAccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OS { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishType { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppRegistryInfo RegistryInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeStack { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppGitHubConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppGitHubConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppClientRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppGlobalValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppGlobalValidation() { }
        public Azure.Provisioning.BicepList<string> ExcludedPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RedirectToProvider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppUnauthenticatedClientActionV2> UnauthenticatedClientAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppGoogleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppGoogleConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LoginScopes { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppClientRegistration Registration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ValidationAllowedAudiences { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppHttpHeaderInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppHttpHeaderInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppHttpRequestInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppHttpRequestInfo() { }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppHttpHeaderInfo> HttpHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppHttpScheme> Scheme { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppHttpScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppHttpScaleRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRuleAuth> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppHttpScheme
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTPS")]
        Https = 1,
    }
    public partial class ContainerAppHttpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppHttpSettings() { }
        public Azure.Provisioning.AppContainers.ContainerAppForwardProxy ForwardProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireHttps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoutesApiPrefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppIdentityProvidersConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppIdentityProvidersConfiguration() { }
        public Azure.Provisioning.AppContainers.ContainerAppAppleConfiguration Apple { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureActiveDirectoryConfiguration AzureActiveDirectory { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureStaticWebAppsConfiguration AzureStaticWebApps { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.AppContainers.ContainerAppCustomOpenIdConnectProviderConfiguration> CustomOpenIdConnectProviders { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppFacebookConfiguration Facebook { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppGitHubConfiguration GitHub { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppGoogleConfiguration Google { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTwitterConfiguration Twitter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppIdentitySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppIdentitySettings() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppIdentitySettingsLifeCycle> Lifecycle { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppIdentitySettingsLifeCycle
    {
        Init = 0,
        Main = 1,
        None = 2,
        All = 3,
    }
    public enum ContainerAppIngressClientCertificateMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ignore")]
        Ignore = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="accept")]
        Accept = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="require")]
        Require = 2,
    }
    public partial class ContainerAppIngressConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppIngressConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.IngressPortMapping> AdditionalPortMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowInsecure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppIngressClientCertificateMode> ClientCertificateMode { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCorsPolicy CorsPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppCustomDomain> CustomDomains { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ExposedPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> External { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppIPSecurityRestrictionRule> IPSecurityRestrictions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.StickySessionAffinity> StickySessionsAffinity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppRevisionTrafficWeight> Traffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppIngressTransportMethod> Transport { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppIngressTransportMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="auto")]
        Auto = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="http2")]
        Http2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="tcp")]
        Tcp = 3,
    }
    public partial class ContainerAppInitContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppInitContainer() { }
        public Azure.Provisioning.BicepList<string> Args { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppEnvironmentVariable> Env { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.AppContainerResources Resources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppIPRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class ContainerAppIPSecurityRestrictionRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppIPSecurityRestrictionRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppIPRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddressRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppJob(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.ContainerAppJobConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventStreamEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> OutboundIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppJobProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppJobTemplate Template { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadProfileName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppJob FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppJobConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppJobConfiguration() { }
        public Azure.Provisioning.AppContainers.EventTriggerConfiguration EventTriggerConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppIdentitySettings> IdentitySettings { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.JobConfigurationManualTriggerConfig ManualTriggerConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppRegistryCredentials> Registries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaRetryLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaTimeout { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.JobConfigurationScheduleTriggerConfig ScheduleTriggerConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppWritableSecret> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppJobTriggerType> TriggerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppJobProvisioningState
    {
        InProgress = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Deleting = 4,
    }
    public partial class ContainerAppJobScale : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppJobScale() { }
        public Azure.Provisioning.BicepValue<int> MaxExecutions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinExecutions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PollingIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppJobScaleRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppJobScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppJobScaleRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRuleAuth> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JobScaleRuleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppJobTemplate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppJobTemplate() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppInitContainer> InitContainers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppVolume> Volumes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppJobTriggerType
    {
        Schedule = 0,
        Event = 1,
        Manual = 2,
    }
    public partial class ContainerAppJwtClaimChecks : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppJwtClaimChecks() { }
        public Azure.Provisioning.BicepList<string> AllowedClientApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppLogAnalyticsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppLogAnalyticsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppLogin : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppLogin() { }
        public Azure.Provisioning.BicepList<string> AllowedExternalRedirectUrls { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppLoginNonce Nonce { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoutesLogoutEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTokenStore TokenStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppLoginNonce : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppLoginNonce() { }
        public Azure.Provisioning.BicepValue<string> NonceExpirationInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateNonce { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppLogsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppLogsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppLogAnalyticsConfiguration LogAnalyticsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppManagedCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppManagedCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ManagedCertificateProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppManagedCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppManagedEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppManagedEnvironment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.AppContainers.ContainerAppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCustomDomainConfiguration CustomDomainConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DaprAIConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DaprAIInstrumentationKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DaprVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeploymentErrors { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EventStreamEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InfrastructureResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMtlsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KedaVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppEnvironmentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StaticIP { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppVnetConfiguration VnetConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppWorkloadProfile> WorkloadProfiles { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.AppContainers.AppContainersBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.AppContainers.AppContainersBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppManagedEnvironmentCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppManagedEnvironmentCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCertificateProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppManagedEnvironmentCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppManagedEnvironmentDaprComponent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppManagedEnvironmentDaprComponent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ComponentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IgnoreErrors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppDaprMetadata> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppWritableSecret> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretStoreComponent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppManagedEnvironmentDaprComponent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum ContainerAppManagedEnvironmentOutBoundType
    {
        LoadBalancer = 0,
        UserDefinedRouting = 1,
    }
    public partial class ContainerAppManagedEnvironmentStorage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppManagedEnvironmentStorage(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.AppContainers.ContainerAppAzureFileProperties ManagedEnvironmentStorageAzureFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ManagedEnvironmentStorageProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppManagedEnvironmentStorage FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ContainerAppNfsAzureFileProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppNfsAzureFileProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShareName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppOpenIdConnectClientCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppOpenIdConnectClientCredential() { }
        public Azure.Provisioning.BicepValue<string> ClientSecretSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppOpenIdConnectClientCredentialMethod> Method { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppOpenIdConnectClientCredentialMethod
    {
        ClientSecretPost = 0,
    }
    public partial class ContainerAppOpenIdConnectConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppOpenIdConnectConfig() { }
        public Azure.Provisioning.BicepValue<string> AuthorizationEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> CertificationUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WellKnownOpenIdConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppOpenIdConnectLogin : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppOpenIdConnectLogin() { }
        public Azure.Provisioning.BicepValue<string> NameClaimType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppOpenIdConnectRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppOpenIdConnectRegistration() { }
        public Azure.Provisioning.AppContainers.ContainerAppOpenIdConnectClientCredential ClientCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppOpenIdConnectConfig OpenIdConnectConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppProbe : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppProbe() { }
        public Azure.Provisioning.BicepValue<int> FailureThreshold { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppHttpRequestInfo HttpGet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InitialDelaySeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PeriodSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppProbeType> ProbeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SuccessThreshold { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTcpSocketRequestInfo TcpSocket { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TerminationGracePeriodSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppProbeType
    {
        Liveness = 0,
        Readiness = 1,
        Startup = 2,
    }
    public enum ContainerAppProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc")]
        Grpc = 1,
    }
    public enum ContainerAppProvisioningState
    {
        InProgress = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Deleting = 4,
    }
    public partial class ContainerAppQueueScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppQueueScaleRule() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRuleAuth> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueLength { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueueName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppRegistration() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppRegistryCredentials() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordSecretRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppRegistryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppRegistryInfo() { }
        public Azure.Provisioning.BicepValue<string> RegistryPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistryServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistryUserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppRevisionTrafficWeight : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppRevisionTrafficWeight() { }
        public Azure.Provisioning.BicepValue<bool> IsLatestRevision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RevisionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppRunningStatus
    {
        Progressing = 0,
        Running = 1,
        Stopped = 2,
        Suspended = 3,
        Ready = 4,
    }
    public partial class ContainerAppScale : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppScale() { }
        public Azure.Provisioning.BicepValue<int> CooldownPeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxReplicas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinReplicas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PollingInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppScaleRule() { }
        public Azure.Provisioning.AppContainers.ContainerAppQueueScaleRule AzureQueue { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppCustomScaleRule Custom { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppHttpScaleRule Http { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTcpScaleRule Tcp { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppScaleRuleAuth : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppScaleRuleAuth() { }
        public Azure.Provisioning.BicepValue<string> SecretRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TriggerParameter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppServiceBind : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppServiceBind() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppSourceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerAppSourceControl(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppGitHubActionConfiguration GitHubActionConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppSourceControlOperationState> OperationState { get { throw null; } }
        public Azure.Provisioning.AppContainers.ContainerApp? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepoUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.ContainerAppSourceControl FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_03_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum ContainerAppSourceControlOperationState
    {
        InProgress = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
    }
    public enum ContainerAppStorageType
    {
        AzureFile = 0,
        EmptyDir = 1,
        Secret = 2,
        NfsAzureFile = 3,
    }
    public partial class ContainerAppTcpScaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTcpScaleRule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppScaleRuleAuth> Auth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppTcpSocketRequestInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTcpSocketRequestInfo() { }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppTemplate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTemplate() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppInitContainer> InitContainers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RevisionSuffix { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppScale Scale { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppServiceBind> ServiceBinds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TerminationGracePeriodSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppVolume> Volumes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppTokenStore : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTokenStore() { }
        public Azure.Provisioning.BicepValue<string> AzureBlobStorageSasUrlSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> TokenRefreshExtensionHours { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppTwitterConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTwitterConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppTwitterRegistration Registration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppTwitterRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppTwitterRegistration() { }
        public Azure.Provisioning.BicepValue<string> ConsumerKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConsumerSecretSettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerAppUnauthenticatedClientActionV2
    {
        RedirectToLoginPage = 0,
        AllowAnonymous = 1,
        Return401 = 2,
        Return403 = 3,
    }
    public partial class ContainerAppVnetConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppVnetConfiguration() { }
        public Azure.Provisioning.BicepValue<string> DockerBridgeCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InfrastructureSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInternal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlatformReservedCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlatformReservedDnsIP { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppVolume : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppVolume() { }
        public Azure.Provisioning.BicepValue<string> MountOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.SecretVolumeItem> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppStorageType> StorageType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppVolumeMount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppVolumeMount() { }
        public Azure.Provisioning.BicepValue<string> MountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VolumeName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppWorkloadProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppWorkloadProfile() { }
        public Azure.Provisioning.BicepValue<int> MaximumNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadProfileType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerAppWritableSecret : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerAppWritableSecret() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerType
    {
        CustomContainer = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PythonLTS")]
        PythonLts = 1,
    }
    public partial class CustomContainerTemplate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomContainerTemplate() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.SessionContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IngressTargetPort { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.SessionRegistryCredentials RegistryCredentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncryptionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionSettings() { }
        public Azure.Provisioning.BicepValue<string> ContainerAppAuthEncryptionSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerAppAuthSigningSecretName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventTriggerConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventTriggerConfiguration() { }
        public Azure.Provisioning.BicepValue<int> Parallelism { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCompletionCount { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppJobScale Scale { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IngressPortMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IngressPortMapping() { }
        public Azure.Provisioning.BicepValue<int> ExposedPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> External { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JavaComponent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public JavaComponent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppManagedEnvironment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.JavaComponentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.JavaComponent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_01;
        }
    }
    public partial class JavaComponentConfigurationProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JavaComponentConfigurationProperty() { }
        public Azure.Provisioning.BicepValue<string> PropertyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JavaComponentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JavaComponentProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.JavaComponentConfigurationProperty> Configurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.JavaComponentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.AppContainers.JavaComponentPropertiesScale Scale { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.JavaComponentServiceBind> ServiceBinds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JavaComponentPropertiesScale : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JavaComponentPropertiesScale() { }
        public Azure.Provisioning.BicepValue<int> MaxReplicas { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinReplicas { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JavaComponentProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Deleting = 3,
        InProgress = 4,
    }
    public partial class JavaComponentServiceBind : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JavaComponentServiceBind() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JobConfigurationManualTriggerConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobConfigurationManualTriggerConfig() { }
        public Azure.Provisioning.BicepValue<int> Parallelism { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCompletionCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JobConfigurationScheduleTriggerConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobConfigurationScheduleTriggerConfig() { }
        public Azure.Provisioning.BicepValue<string> CronExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Parallelism { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCompletionCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedCertificateDomainControlValidation
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CNAME")]
        Cname = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 1,
        TXT = 2,
    }
    public partial class ManagedCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedCertificateProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ManagedCertificateDomainControlValidation> DomainControlValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppCertificateProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationToken { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedEnvironmentStorageProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedEnvironmentStorageProperties() { }
        public Azure.Provisioning.AppContainers.ContainerAppAzureFileProperties AzureFile { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.ContainerAppNfsAzureFileProperties NfsAzureFile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PoolManagementType
    {
        Manual = 0,
        Dynamic = 1,
    }
    public partial class SecretVolumeItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretVolumeItem() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretRef { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionContainer() { }
        public Azure.Provisioning.BicepList<string> Args { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.ContainerAppEnvironmentVariable> Env { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.SessionContainerResources Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionContainerResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionContainerResources() { }
        public Azure.Provisioning.BicepValue<double> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Memory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionNetworkStatus
    {
        EgressEnabled = 0,
        EgressDisabled = 1,
    }
    public partial class SessionPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SessionPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerType> ContainerType { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.CustomContainerTemplate CustomContainerTemplate { get { throw null; } set { } }
        public Azure.Provisioning.AppContainers.SessionPoolLifecycleConfiguration DynamicPoolLifecycleConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.SessionPoolManagedIdentitySetting> ManagedIdentitySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PoolManagementEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.PoolManagementType> PoolManagementType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.SessionPoolProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.AppContainers.SessionPoolScaleConfiguration ScaleConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AppContainers.SessionPoolSecret> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.SessionNetworkStatus> SessionNetworkStatus { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AppContainers.SessionPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_01;
        }
    }
    public partial class SessionPoolLifecycleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionPoolLifecycleConfiguration() { }
        public Azure.Provisioning.BicepValue<int> CooldownPeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.SessionPoolLifecycleType> LifecycleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAlivePeriodInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionPoolLifecycleType
    {
        Timed = 0,
        OnContainerExit = 1,
    }
    public partial class SessionPoolManagedIdentitySetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionPoolManagedIdentitySetting() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AppContainers.ContainerAppIdentitySettingsLifeCycle> Lifecycle { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionPoolProvisioningState
    {
        InProgress = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Deleting = 4,
    }
    public partial class SessionPoolScaleConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionPoolScaleConfiguration() { }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentSessions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReadySessionInstances { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionPoolSecret : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionPoolSecret() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionRegistryCredentials() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordSecretRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SpringBootAdminComponent : Azure.Provisioning.AppContainers.JavaComponentProperties
    {
        public SpringBootAdminComponent() { }
        public Azure.Provisioning.BicepValue<string> IngressFqdn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SpringCloudConfigComponent : Azure.Provisioning.AppContainers.JavaComponentProperties
    {
        public SpringCloudConfigComponent() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SpringCloudEurekaComponent : Azure.Provisioning.AppContainers.JavaComponentProperties
    {
        public SpringCloudEurekaComponent() { }
        public Azure.Provisioning.BicepValue<string> IngressFqdn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StickySessionAffinity
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="sticky")]
        Sticky = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 1,
    }
}
