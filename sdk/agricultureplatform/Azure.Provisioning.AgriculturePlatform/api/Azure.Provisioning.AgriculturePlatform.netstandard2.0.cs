namespace Azure.Provisioning.AgriculturePlatform
{
    public enum AgriculturePlatformProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public partial class AgriculturePlatformSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgriculturePlatformSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AgriculturePlatform.AgriculturePlatformSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgriculturePlatformSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class AgricultureService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AgricultureService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.AgriculturePlatform.AgricultureServiceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.AgriculturePlatform.AgriculturePlatformSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.AgriculturePlatform.AgricultureService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class AgricultureServiceConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgricultureServiceConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AppServiceResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CosmosDBResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> InstanceUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RedisCacheResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgricultureServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgricultureServiceProperties() { }
        public Azure.Provisioning.AgriculturePlatform.AgricultureServiceConfig Config { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AgriculturePlatform.DataConnectorCredentialMap> DataConnectorCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.AgriculturePlatform.InstalledSolutionMap> InstalledSolutions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AgriculturePlatform.AgriculturePlatformProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgricultureSolution : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgricultureSolution() { }
        public Azure.Provisioning.BicepValue<string> ApplicationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketPlacePublisherId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SaasSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SaasSubscriptionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AuthCredentialsKind
    {
        OAuthClientCredentials = 0,
        ApiKeyAuthCredentials = 1,
    }
    public partial class DataConnectorCredentialMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataConnectorCredentialMap() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.AgriculturePlatform.DataConnectorCredentials Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataConnectorCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataConnectorCredentials() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.AgriculturePlatform.AuthCredentialsKind> Kind { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InstalledSolutionMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InstalledSolutionMap() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.AgriculturePlatform.AgricultureSolution Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
