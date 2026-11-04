namespace Azure.Provisioning.SecretsStoreExtension
{
    public enum AzureCloudName
    {
        AzurePublicCloud = 0,
        AzureUSGovernmentCloud = 1,
        AzureChinaCloud = 2,
        AzureGermanCloud = 3,
        AzureStackCloud = 4,
    }
    public partial class KeyVaultSecretProviderClass : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KeyVaultSecretProviderClass(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecretsStoreExtension.KeyVaultSecretProviderClassProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecretsStoreExtension.KeyVaultSecretProviderClass FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_08_21_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_25_PREVIEW;
        }
    }
    public partial class KeyVaultSecretProviderClassProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultSecretProviderClassProperties() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecretsStoreExtension.AzureCloudName> CloudName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyvaultName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Objects { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecretsStoreExtension.SecretsStoreExtensionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesSecretObjectMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesSecretObjectMapping() { }
        public Azure.Provisioning.BicepValue<string> SourcePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesSecretType
    {
        Opaque = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetes.io/tls")]
        Tls = 1,
    }
    public enum SecretsStoreExtensionProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
    }
    public partial class SecretSync : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecretSync(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SecretsStoreExtension.SecretSyncProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SecretsStoreExtension.SecretSync FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_08_21_PREVIEW;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_25_PREVIEW;
        }
    }
    public partial class SecretSyncCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretSyncCondition() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastTransitionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> ObservedGeneration { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecretsStoreExtension.SecretSyncConditionStatusType> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecretSyncConditionStatusType
    {
        True = 0,
        False = 1,
        Unknown = 2,
    }
    public partial class SecretSyncProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretSyncProperties() { }
        public Azure.Provisioning.BicepValue<string> ForceSynchronization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecretsStoreExtension.KubernetesSecretType> KubernetesSecretType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecretsStoreExtension.KubernetesSecretObjectMapping> ObjectSecretMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SecretsStoreExtension.SecretsStoreExtensionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecretProviderClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountName { get { throw null; } set { } }
        public Azure.Provisioning.SecretsStoreExtension.SecretSyncStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecretSyncStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretSyncStatus() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SecretsStoreExtension.SecretSyncCondition> Conditions { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSuccessfulSyncOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
