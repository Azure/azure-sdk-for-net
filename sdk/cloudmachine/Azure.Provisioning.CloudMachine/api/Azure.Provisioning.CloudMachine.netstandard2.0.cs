namespace Azure.CloudMachine
{
    public static partial class Azd
    {
        public static void Init(Azure.CloudMachine.ProjectClient client, string? infraDirectory = null) { }
        public static void Init(Azure.CloudMachine.ProjectInfrastructure infra, string? infraDirectory = null) { }
        public static void InitDeployment(Azure.CloudMachine.ProjectInfrastructure infra, string? webProjectName) { }
    }
    public static partial class CloudMachineClientExtensions
    {
        public static T AddFeature<T>(this Azure.CloudMachine.ProjectClient client, T feature) where T : Azure.CloudMachine.Core.CloudMachineFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.CloudMachine.ProjectInfrastructure GetInfrastructure(this Azure.CloudMachine.ProjectClient client) { throw null; }
    }
    public static partial class CloudMachineCommands
    {
        public static bool TryExecuteCommand(this Azure.CloudMachine.ProjectInfrastructure cmi, string[] args) { throw null; }
    }
    public static partial class CloudMachineInfrastructureConfiguration
    {
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddCloudMachine(this Microsoft.Extensions.Hosting.IHostApplicationBuilder builder, Azure.CloudMachine.ProjectInfrastructure cm) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddCloudMachineConfiguration(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, Azure.CloudMachine.ProjectInfrastructure cm) { throw null; }
    }
    public partial class ProjectInfrastructure
    {
        public ProjectInfrastructure(string? cmId = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ConnectionCollection Connections { get { throw null; } }
        public Azure.CloudMachine.Core.FeatureCollection Features { get { throw null; } }
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddEndpoints<T>() { }
        public T AddFeature<T>(T feature) where T : Azure.CloudMachine.Core.CloudMachineFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public Azure.CloudMachine.ProjectClient GetClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Azure.CloudMachine.AIFoundry
{
    public partial class AIFoundryFeature : Azure.CloudMachine.Core.CloudMachineFeature
    {
        public AIFoundryFeature(string connectionString) { }
        protected internal override void EmitConnections(Azure.Core.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.ProjectInfrastructure cm) { throw null; }
    }
}
namespace Azure.CloudMachine.AppService
{
    public partial class AppServiceFeature : Azure.CloudMachine.Core.CloudMachineFeature
    {
        public AppServiceFeature() { }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.ProjectInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.Core
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
        protected internal System.Collections.Generic.Dictionary<Azure.Provisioning.Primitives.Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Primitives.ProvisionableResource Resource { get { throw null; } }
        protected internal virtual void EmitConnections(Azure.Core.ConnectionCollection connections, string cmId) { }
        protected internal virtual void EmitFeatures(Azure.CloudMachine.Core.FeatureCollection features, string cmId) { }
        protected abstract Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.ProjectInfrastructure cm);
        protected static T EnsureEmits<T>(Azure.CloudMachine.Core.CloudMachineFeature feature) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class FeatureCollection : System.Collections.Generic.IEnumerable<Azure.CloudMachine.Core.CloudMachineFeature>, System.Collections.IEnumerable
    {
        internal FeatureCollection() { }
        public void Add(Azure.CloudMachine.Core.CloudMachineFeature item) { }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.CloudMachine.Core.CloudMachineFeature { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.CloudMachine.Core.CloudMachineFeature> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public partial class KeyVaultFeature : Azure.CloudMachine.Core.CloudMachineFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected internal override void EmitConnections(Azure.Core.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.ProjectInfrastructure infrastructure) { throw null; }
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
