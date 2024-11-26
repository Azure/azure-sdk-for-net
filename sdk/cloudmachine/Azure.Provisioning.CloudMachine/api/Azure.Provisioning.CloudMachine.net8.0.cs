namespace Azure
{
    public partial class RestCallFailedException : System.Exception
    {
        public RestCallFailedException(string message, System.ClientModel.Primitives.PipelineResponse response) { }
    }
    public partial class RestClient
    {
        public RestClient() { }
        public RestClient(System.ClientModel.Primitives.PipelinePolicy auth) { }
        public static Azure.RestClient Shared { get { throw null; } }
        public System.ClientModel.Primitives.PipelineMessage Create(string method, System.Uri uri) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Get(string uri, System.ClientModel.Primitives.RequestOptions? options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Patch(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions? options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Post(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions? options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Put(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions? options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Send(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.RequestOptions? options = null) { throw null; }
    }
    public partial class RestClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public RestClientOptions() { }
    }
}
namespace Azure.CloudMachine
{
    public partial class CloudMachineCommands
    {
        public CloudMachineCommands() { }
        public static bool Execute(string[] args, System.Action<Azure.CloudMachine.CloudMachineInfrastructure>? configure = null, bool exitProcessIfHandled = true) { throw null; }
    }
    public partial class CloudMachineInfrastructure
    {
        public CloudMachineInfrastructure(string cmId) { }
        public Azure.CloudMachine.FeatureCollection Features { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddEndpoints<T>() { }
        public void AddFeature(Azure.Provisioning.CloudMachine.CloudMachineFeature feature) { }
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
    }
    public partial class EventGridSystemTopicFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public EventGridSystemTopicFeature(string name, Azure.Provisioning.CloudMachine.CloudMachineFeature source) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class FeatureCollection
    {
        public FeatureCollection() { }
        public System.Collections.Generic.IEnumerable<T> FindAll<T>() where T : Azure.Provisioning.CloudMachine.CloudMachineFeature { throw null; }
    }
    public partial class ServiceBusNamespaceFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusNamespaceFeature(string name, Azure.Provisioning.ServiceBus.ServiceBusSkuName sku = Azure.Provisioning.ServiceBus.ServiceBusSkuName.Standard, Azure.Provisioning.ServiceBus.ServiceBusSkuTier tier = Azure.Provisioning.ServiceBus.ServiceBusSkuTier.Standard) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class ServiceBusSubscriptionFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusSubscriptionFeature(string name, Azure.CloudMachine.ServiceBusTopicFeature parent) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class ServiceBusTopicFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public ServiceBusTopicFeature(string name, Azure.CloudMachine.ServiceBusNamespaceFeature parent) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class StorageFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public StorageFeature(string accountName, Azure.Provisioning.Storage.StorageSkuName sku = Azure.Provisioning.Storage.StorageSkuName.StandardLrs, System.Collections.Generic.IEnumerable<string>? containerNames = null) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
    public partial class SystemTopicEventSubscriptionFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public SystemTopicEventSubscriptionFeature(string name, Azure.CloudMachine.EventGridSystemTopicFeature parent, Azure.CloudMachine.ServiceBusTopicFeature destination, Azure.CloudMachine.ServiceBusNamespaceFeature parentNamespace) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.AppService
{
    public partial class AppServiceFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public AppServiceFeature(Azure.Provisioning.AppService.AppServiceSkuDescription? sku = null) { }
        public Azure.Provisioning.AppService.AppServiceSkuDescription Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure infrastructure) { throw null; }
    }
}
namespace Azure.CloudMachine.OpenAI
{
    public enum AIModelKind
    {
        Chat = 0,
        Embedding = 1,
    }
    public partial class OpenAIModel : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIModel(string model, string modelVersion, Azure.CloudMachine.OpenAI.AIModelKind kind = Azure.CloudMachine.OpenAI.AIModelKind.Chat) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public override void AddTo(Azure.CloudMachine.CloudMachineInfrastructure cm) { }
        protected override Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure cm) { throw null; }
    }
}
namespace Azure.Provisioning.CloudMachine
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.Primitives.ProvisionableResource Emitted { get { throw null; } protected set { } }
        protected internal System.Collections.Generic.Dictionary<Azure.Provisioning.Primitives.Provisionable, (string RoleName, string RoleId)[]> RequiredSystemRoles { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual void AddTo(Azure.CloudMachine.CloudMachineInfrastructure cm) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Emit(Azure.CloudMachine.CloudMachineInfrastructure cm) { }
        protected abstract Azure.Provisioning.Primitives.ProvisionableResource EmitCore(Azure.CloudMachine.CloudMachineInfrastructure cm);
        protected static T ValidateIsOfType<T>(Azure.Provisioning.CloudMachine.CloudMachineFeature resource) { throw null; }
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
