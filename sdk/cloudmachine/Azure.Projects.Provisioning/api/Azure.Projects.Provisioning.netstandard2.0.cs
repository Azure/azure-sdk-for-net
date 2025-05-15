namespace Azure.Projects
{
    public partial class AppConfigurationFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AppConfigurationFeature() { }
        public Azure.Projects.AppConfigurationFeature.SkuName Sku { get { throw null; } set { } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        public enum SkuName
        {
            Free = 0,
            Developer = 1,
            Standard = 2,
            Premium = 3,
        }
    }
    public partial class AppConfigurationSettingFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AppConfigurationSettingFeature(string key, string value) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        protected internal override void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
    public partial class AppServiceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AppServiceFeature() { }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
    public static partial class Azd
    {
        public static void Init(Azure.Projects.ProjectInfrastructure infra, string? infraDirectory = null) { }
        public static void InitDeployment(Azure.Projects.ProjectInfrastructure infra, string? webProjectName) { }
    }
    public static partial class AzureProjectsCommands
    {
        public static bool TryExecuteCommand(this Azure.Projects.ProjectInfrastructure infrastructure, string[] args) { throw null; }
    }
    public partial class BlobContainerFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public BlobContainerFeature(string containerName, bool isObservable = true) { }
        public string ContainerName { get { throw null; } }
        public Azure.Projects.BlobServiceFeature? Service { get { throw null; } set { } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        protected internal override void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
        public override string ToString() { throw null; }
    }
    public partial class BlobServiceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public BlobServiceFeature() { }
        public Azure.Projects.StorageAccountFeature? Account { get { throw null; } set { } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        protected internal override void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public KeyVaultFeature() { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
    public partial class ProjectInfrastructure
    {
        public ProjectInfrastructure(Azure.Projects.Core.ConnectionStore connections, string? projectId = null) { }
        public ProjectInfrastructure(string? projectId = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Projects.Core.ConnectionStore Connections { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Projects.Core.FeatureCollection Features { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public string ProjectId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddConstruct(string id, Azure.Provisioning.Primitives.NamedProvisionableConstruct construct) { }
        public T AddFeature<T>(T feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddSystemRole(Azure.Provisioning.Primitives.Provisionable provisionable, string roleName, string roleId) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public T GetConstruct<T>(string id) where T : Azure.Provisioning.Primitives.NamedProvisionableConstruct { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusNamespaceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public ServiceBusNamespaceFeature(string namespaceName) { }
        public string Name { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusSkuName Sku { get { throw null; } }
        public Azure.Provisioning.ServiceBus.ServiceBusSkuTier Tier { get { throw null; } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
    public partial class StorageAccountFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public StorageAccountFeature(string accountName, Azure.Provisioning.Storage.StorageSkuName sku = Azure.Provisioning.Storage.StorageSkuName.StandardLrs) { }
        public string Name { get { throw null; } }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Projects.Core
{
    public partial class AppConfigConnectionStore : Azure.Projects.Core.ConnectionStore
    {
        public AppConfigConnectionStore() { }
        public AppConfigConnectionStore(Azure.Projects.AppConfigurationFeature appConfig) { }
        public AppConfigConnectionStore(Azure.Projects.AppConfigurationFeature.SkuName sku) { }
        public override void EmitConnection(Azure.Projects.ProjectInfrastructure infrastructure, string connectionId, string endpoint) { }
        public override bool TryGetFeature(out Azure.Projects.Core.AzureProjectFeature? feature) { throw null; }
    }
    public abstract partial class AzureProjectFeature
    {
        protected AzureProjectFeature() { }
        protected AzureProjectFeature(string id) { }
        public string Id { get { throw null; } }
        protected void EmitConnection(Azure.Projects.ProjectInfrastructure infrastructure, string connectionId, string endpoint) { }
        protected internal abstract void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure);
        protected internal virtual void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public abstract partial class ConnectionStore
    {
        protected ConnectionStore() { }
        public abstract void EmitConnection(Azure.Projects.ProjectInfrastructure infrastructure, string connectionId, string endpoint);
        public virtual bool TryGetFeature(out Azure.Projects.Core.AzureProjectFeature? feature) { throw null; }
    }
    public partial class FeatureCollection : System.Collections.Generic.IEnumerable<Azure.Projects.Core.AzureProjectFeature>, System.Collections.IEnumerable
    {
        internal FeatureCollection() { }
        public void Append(Azure.Projects.Core.AzureProjectFeature feature) { }
        public string CreateUniqueBicepIdentifier(string baseIdentifier) { throw null; }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Projects.Core.AzureProjectFeature> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGet<T>(string id, out T? feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        public bool TryGet<T>(out T? feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
    }
}
namespace Azure.Projects.Ofx
{
    public partial class OfxFeatures : Azure.Projects.Core.AzureProjectFeature
    {
        public OfxFeatures() { }
        protected internal override void EmitConstructs(Azure.Projects.ProjectInfrastructure infrastructure) { }
        protected internal override void EmitFeatures(Azure.Projects.ProjectInfrastructure infrastructure) { }
    }
}
