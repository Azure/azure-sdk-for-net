namespace Azure.Projects
{
    public static partial class Azd
    {
        public static void Init(Azure.Projects.ProjectClient client, string? infraDirectory = null) { }
        public static void Init(Azure.Projects.ProjectInfrastructure infra, string? infraDirectory = null) { }
        public static void InitDeployment(Azure.Projects.ProjectInfrastructure infra, string? webProjectName) { }
    }
    public static partial class AzureProjectsCommands
    {
        public static bool TryExecuteCommand(this Azure.Projects.ProjectInfrastructure cmi, string[] args) { throw null; }
    }
    public static partial class ProjectClientExtensions
    {
        public static T AddFeature<T>(this Azure.Projects.ProjectClient client, T feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Projects.ProjectInfrastructure GetInfrastructure(this Azure.Projects.ProjectClient client) { throw null; }
    }
    public partial class ProjectInfrastructure
    {
        public ProjectInfrastructure(string? cmId = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ConnectionCollection Connections { get { throw null; } }
        public Azure.Projects.Core.FeatureCollection Features { get { throw null; } }
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddEndpoints<T>() { }
        public T AddFeature<T>(T feature) where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public Azure.Projects.ProjectClient GetClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public static partial class ProjectInfrastructureConfiguration
    {
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddProjectClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder builder, Azure.Projects.ProjectInfrastructure cm) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddProjectClientConfiguration(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, Azure.Projects.ProjectInfrastructure cm) { throw null; }
    }
}
namespace Azure.Projects.AIFoundry
{
    public partial class AIFoundryFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public AIFoundryFeature() { }
        public AIFoundryFeature(string connectionString) { }
        public System.Collections.Generic.List<Azure.Core.ClientConnection> Connections { get { throw null; } set { } }
        protected internal override void EmitConnections(System.Collections.Generic.ICollection<Azure.Core.ClientConnection> connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure cm) { throw null; }
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
        protected internal System.Collections.Generic.Dictionary<Azure.Provisioning.Primitives.Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Primitives.ProvisionableResource Resource { get { throw null; } }
        protected internal virtual void EmitConnections(System.Collections.Generic.ICollection<Azure.Core.ClientConnection> connections, string cmId) { }
        protected internal virtual void EmitFeatures(Azure.Projects.Core.FeatureCollection features, string cmId) { }
        protected abstract Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure cm);
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
        public void Add(Azure.Projects.Core.AzureProjectFeature item) { }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.Projects.Core.AzureProjectFeature { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Projects.Core.AzureProjectFeature> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}
namespace Azure.Projects.KeyVault
{
    public partial class KeyVaultFeature : Azure.Projects.Core.AzureProjectFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected internal override void EmitConnections(System.Collections.Generic.ICollection<Azure.Core.ClientConnection> connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.Projects.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace System.ClientModel.TypeSpec
{
    public static partial class TypeSpecWriter
    {
        public static void WriteModel(System.IO.Stream output, System.Type model) { }
        public static void WriteModel<T>(System.IO.Stream output) { }
        public static void WriteServer(System.IO.Stream output, System.Type service) { }
        public static void WriteServer<T>(System.IO.Stream output) { }
    }
}
