namespace Azure.Projects
{
    public static partial class Azd
    {
        public static void Init(Azure.Projects.ProjectInfrastructure infra, string? infraDirectory = null) { }
        public static void InitDeployment(Azure.Projects.ProjectInfrastructure infra, string? webProjectName) { }
    }
    public static partial class AzureProjectsCommands
    {
        public static bool TryExecuteCommand(this Azure.Projects.ProjectInfrastructure infrastructure, string[] args) { throw null; }
    }
    public static partial class OfxExtensions
    {
        public static void AddBlobsContainer(this Azure.Projects.ProjectInfrastructure infra, string? containerName = null, bool enableEvents = true) { }
        public static void AddOfx(this Azure.Projects.ProjectInfrastructure infra) { }
    }
    public partial class ProjectInfrastructure
    {
        public ProjectInfrastructure(string? projectId = null) { }
        public Azure.Projects.Core.FeatureCollection Features { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public string ProjectId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddConstruct(Azure.Provisioning.Primitives.NamedProvisionableConstruct construct) { }
        public T AddFeature<T>(T feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddSystemRole(Azure.Provisioning.Primitives.Provisionable provisionable, string roleName, string roleId) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Azure.Projects.AIFoundry
{
    public partial class AIProjectFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AIProjectFeature() { }
        public AIProjectFeature(string connectionString) { }
        public System.Collections.Generic.List<System.ClientModel.Primitives.ClientConnection> Connections { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.Projects.AppConfiguration
{
    public partial class AppConfigurationSettingFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AppConfigurationSettingFeature(string key, string value, string bicepIdentifier = "cm_config_setting") { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected internal override void AddImplicitFeatures(Azure.Projects.Core.FeatureCollection features, string projectId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.Projects.AppService
{
    public partial class AppServiceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AppServiceFeature() { }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.Projects.Core
{
    public abstract partial class AzureProjectFeature
    {
        protected AzureProjectFeature() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Primitives.ProvisionableResource Resource { get { throw null; } }
        protected internal virtual void AddImplicitFeatures(Azure.Projects.Core.FeatureCollection features, string projectId) { }
        protected void EmitConnection(Azure.Projects.ProjectInfrastructure infrastructure, string connectionId, string endpoint) { }
        protected abstract Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure);
        protected static T EnsureEmits<T>(Azure.Projects.Core.AzureProjectFeature feature) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class FeatureCollection : System.Collections.Generic.IEnumerable<Azure.Projects.Core.AzureProjectFeature>, System.Collections.IEnumerable
    {
        internal FeatureCollection() { }
        public void Append(Azure.Projects.Core.AzureProjectFeature feature) { }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Projects.Core.AzureProjectFeature> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGet<T>(out T? feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
    }
}
namespace Azure.Projects.KeyVault
{
    public partial class KeyVaultFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.Projects.ServiceBus
{
    public partial class ServiceBusNamespaceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public ServiceBusNamespaceFeature(string name, Azure.Provisioning.ServiceBus.ServiceBusSkuName sku = Azure.Provisioning.ServiceBus.ServiceBusSkuName.Standard, Azure.Provisioning.ServiceBus.ServiceBusSkuTier tier = Azure.Provisioning.ServiceBus.ServiceBusSkuTier.Standard) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.Projects.Storage
{
    public partial class BlobContainerFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public BlobContainerFeature(string containerName = "default") { }
        public string ContainerName { get { throw null; } }
        public Azure.Projects.Storage.BlobServiceFeature? Service { get { throw null; } set { } }
        protected internal override void AddImplicitFeatures(Azure.Projects.Core.FeatureCollection features, string projectId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
    public partial class BlobServiceFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public BlobServiceFeature() { }
        public Azure.Projects.Storage.StorageAccountFeature? Account { get { throw null; } set { } }
        protected internal override void AddImplicitFeatures(Azure.Projects.Core.FeatureCollection features, string projectId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure cm) { throw null; }
    }
    public partial class StorageAccountFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public StorageAccountFeature(string accountName, Azure.Provisioning.Storage.StorageSkuName sku = Azure.Provisioning.Storage.StorageSkuName.StandardLrs) { }
        public string Name { get { throw null; } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
