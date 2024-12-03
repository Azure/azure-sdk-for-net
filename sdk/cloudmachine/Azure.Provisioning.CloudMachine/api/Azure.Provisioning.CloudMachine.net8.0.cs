namespace Azure.CloudMachine
{
    public static partial class Azd
    {
        public static void Init(Azure.CloudMachine.CloudMachineClient client, string? infraDirectory = null) { }
        public static void Init(Azure.CloudMachine.CloudMachineInfrastructure infra, string? infraDirectory = null) { }
        public static void InitDeployment(Azure.CloudMachine.CloudMachineInfrastructure infra, string? webProjectName) { }
    }
    public static partial class CloudMachineClientExtensions
    {
        public static T AddFeature<T>(this Azure.CloudMachine.CloudMachineClient client, T feature) where T : Azure.Provisioning.CloudMachine.CloudMachineFeature { throw null; }
        public static void Configure(this Azure.CloudMachine.CloudMachineClient client, System.Action<Azure.CloudMachine.CloudMachineInfrastructure>? configure = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.CloudMachine.CloudMachineInfrastructure GetInfrastructure(this Azure.CloudMachine.CloudMachineClient client) { throw null; }
    }
    public static partial class CloudMachineCommands
    {
        public static bool Execute(string[] args, System.Action<Azure.CloudMachine.CloudMachineInfrastructure>? configure = null, bool exitProcessIfHandled = true) { throw null; }
    }
    public partial class CloudMachineInfrastructure
    {
        public CloudMachineInfrastructure(string? cmId = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.CloudMachine.ConnectionCollection Connections { get { throw null; } }
        public Azure.CloudMachine.FeatureCollection Features { get { throw null; } }
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddEndpoints<T>() { }
        public T AddFeature<T>(T feature) where T : Azure.Provisioning.CloudMachine.CloudMachineFeature { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public Azure.CloudMachine.CloudMachineClient GetClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class FeatureCollection : System.Collections.Generic.IEnumerable<Azure.Provisioning.CloudMachine.CloudMachineFeature>, System.Collections.IEnumerable
    {
        internal FeatureCollection() { }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.Provisioning.CloudMachine.CloudMachineFeature { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Provisioning.CloudMachine.CloudMachineFeature> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusNamespaceFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusNamespaceFeature(string name, Azure.Provisioning.ServiceBus.ServiceBusSkuName sku = Azure.Provisioning.ServiceBus.ServiceBusSkuName.Standard, Azure.Provisioning.ServiceBus.ServiceBusSkuTier tier = Azure.Provisioning.ServiceBus.ServiceBusSkuTier.Standard) { }
        protected internal override void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class ServiceBusSubscriptionFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusSubscriptionFeature(string name, Azure.CloudMachine.ServiceBusTopicFeature parent) { }
        protected internal override void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class ServiceBusTopicFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusTopicFeature(string name, Azure.CloudMachine.ServiceBusNamespaceFeature parent) { }
        public string Name { get { throw null; } }
        protected internal override void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.AppService
{
    public partial class AppServiceFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public AppServiceFeature() { }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected internal override void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.OpenAI
{
    public enum AIModelKind
    {
        Chat = 0,
        Embedding = 1,
    }
    public partial class OpenAIModelFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIModelFeature(string model, string modelVersion, Azure.CloudMachine.OpenAI.AIModelKind kind = Azure.CloudMachine.OpenAI.AIModelKind.Chat) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        protected internal override void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected internal override void EmitFeatures(Azure.CloudMachine.FeatureCollection features, string cmId) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure cm) { throw null; }
    }
}
namespace Azure.Provisioning.CloudMachine
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
        protected internal System.Collections.Generic.Dictionary<Azure.Provisioning.Primitives.Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Primitives.ProvisionableResource Resource { get { throw null; } }
        protected internal virtual void EmitConnections(Azure.CloudMachine.ConnectionCollection connections, string cmId) { }
        protected internal virtual void EmitFeatures(Azure.CloudMachine.FeatureCollection features, string cmId) { }
        protected abstract Azure.Provisioning.Primitives.ProvisionableResource EmitResources(Azure.CloudMachine.CloudMachineInfrastructure cm);
        protected static T EnsureEmits<T>(Azure.Provisioning.CloudMachine.CloudMachineFeature feature) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
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
