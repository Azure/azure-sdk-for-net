namespace Azure.Provisioning.HealthcareApis
{
    public partial class DicomService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DicomService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.HealthcareApis.DicomServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.DicomServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.FhirServiceEventState> EventState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDataPartitionsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceStorageConfiguration StorageConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.DicomService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class DicomServiceAuthenticationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DicomServiceAuthenticationConfiguration() { }
        public Azure.Provisioning.BicepList<string> Audiences { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Authority { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DicomServiceCorsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DicomServiceCorsConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> AllowCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAge { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Methods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Origins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FhirResourceVersionPolicy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="no-version")]
        NoVersion = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="versioned")]
        Versioned = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="versioned-update")]
        VersionedUpdate = 2,
    }
    public partial class FhirService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FhirService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.HealthcareApis.FhirServiceAcrConfiguration AcrConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.FhirServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.FhirServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.FhirServiceEventState> EventState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExportStorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ImplementationGuidesIsUsCoreMissingDataEnabled { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.FhirServiceImportConfiguration ImportConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.FhirServiceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.FhirServiceResourceVersionPolicyConfiguration ResourceVersionPolicyConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.FhirService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class FhirServiceAcrConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FhirServiceAcrConfiguration() { }
        public Azure.Provisioning.BicepList<string> LoginServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServiceOciArtifactEntry> OciArtifacts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FhirServiceAuthenticationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FhirServiceAuthenticationConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Audience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSmartProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.SmartIdentityProviderConfiguration> SmartIdentityProviders { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FhirServiceCorsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FhirServiceCorsConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> AllowCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAge { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Methods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Origins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FhirServiceEventState
    {
        Disabled = 0,
        Enabled = 1,
        Updating = 2,
    }
    public partial class FhirServiceImportConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FhirServiceImportConfiguration() { }
        public Azure.Provisioning.BicepValue<string> IntegrationDataStore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInitialImportMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FhirServiceKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="fhir-Stu3")]
        FhirStu3 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="fhir-R4")]
        FhirR4 = 1,
    }
    public partial class FhirServiceResourceVersionPolicyConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FhirServiceResourceVersionPolicyConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.FhirResourceVersionPolicy> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.HealthcareApis.FhirResourceVersionPolicy> ResourceTypeOverrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisIotConnector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisIotConnector(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> DeviceMappingContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisIotConnectorEventHubIngestionConfiguration IngestionEndpointConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisIotConnector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisIotConnectorEventHubIngestionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisIotConnectorEventHubIngestionConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedEventHubNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisIotFhirDestination : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisIotFhirDestination(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> FhirMappingContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FhirServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisIotConnector Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisIotIdentityResolutionType> ResourceIdentityResolutionType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisIotFhirDestination FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public enum HealthcareApisIotIdentityResolutionType
    {
        Create = 0,
        Lookup = 1,
    }
    public partial class HealthcareApisIotMappingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisIotMappingProperties() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Content { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HealthcareApisKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="fhir")]
        Fhir = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="fhir-Stu3")]
        FhirStu3 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="fhir-R4")]
        FhirR4 = 2,
    }
    public enum HealthcareApisPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum HealthcareApisPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class HealthcareApisPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HealthcareApisProvisioningState
    {
        Deleting = 0,
        Succeeded = 1,
        Creating = 2,
        Accepted = 3,
        Verifying = 4,
        Updating = 5,
        Failed = 6,
        Canceled = 7,
        Deprovisioned = 8,
        Moving = 9,
        Suspended = 10,
        Warned = 11,
        SystemMaintenance = 12,
    }
    public enum HealthcareApisPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class HealthcareApisService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisServiceAccessPolicyEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceAccessPolicyEntry() { }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceAcrConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceAcrConfiguration() { }
        public Azure.Provisioning.BicepList<string> LoginServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServiceOciArtifactEntry> OciArtifacts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceAuthenticationConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceAuthenticationConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Audience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSmartProxyEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceCorsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceCorsConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> AllowCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAge { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Methods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Origins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceCosmosDBConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceCosmosDBConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CrossTenantCmkApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OfferThroughput { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceImportConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceImportConfiguration() { }
        public Azure.Provisioning.BicepValue<string> IntegrationDataStore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInitialImportMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceOciArtifactEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceOciArtifactEntry() { }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoginServer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServicePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisServicePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.HealthcareApis.HealthcareApisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisServicePrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal HealthcareApisServicePrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServiceAccessPolicyEntry> AccessPolicies { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceAcrConfiguration AcrConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceCosmosDBConfiguration CosmosDBConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExportStorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisServiceImportConfiguration ImportConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisServiceStorageConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisServiceStorageConfiguration() { }
        public Azure.Provisioning.BicepValue<string> FileSystemName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEventQueueName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HealthcareApisWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisWorkspacePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HealthcareApisWorkspacePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.HealthcareApis.HealthcareApisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisWorkspacePrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal HealthcareApisWorkspacePrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.HealthcareApis.HealthcareApisWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_04_01_PREVIEW;
        }
    }
    public partial class HealthcareApisWorkspaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HealthcareApisWorkspaceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.HealthcareApisServicePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.HealthcareApis.HealthcareApisPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SmartDataAction
    {
        Read = 0,
    }
    public partial class SmartIdentityProviderApplication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SmartIdentityProviderApplication() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.SmartDataAction> AllowedDataActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Audience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SmartIdentityProviderConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SmartIdentityProviderConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.HealthcareApis.SmartIdentityProviderApplication> Applications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
