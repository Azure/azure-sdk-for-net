namespace Azure.CloudMachine
{
    public partial class CloudMachineClient : Azure.CloudMachine.CloudMachineWorkspace
    {
        public CloudMachineClient(Azure.Identity.DefaultAzureCredential? credential = null, Microsoft.Extensions.Configuration.IConfiguration? configuration = null) : base (default(Azure.Identity.DefaultAzureCredential), default(Microsoft.Extensions.Configuration.IConfiguration)) { }
        public Azure.CloudMachine.MessagingServices Messaging { get { throw null; } }
        public Azure.CloudMachine.StorageServices Storage { get { throw null; } }
    }
    public partial class CloudMachineWorkspace : Azure.Core.WorkspaceClient
    {
        public CloudMachineWorkspace(Azure.Identity.DefaultAzureCredential? credential = null, Microsoft.Extensions.Configuration.IConfiguration? configuration = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Core.TokenCredential Credential { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Core.ClientConfiguration? GetConfiguration(string clientId, string? instanceId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessagingServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void SendMessage(object serializable) { }
        public void WhenMessageReceived(System.Action<string> received) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.BinaryData DownloadBlob(string name) { throw null; }
        public string UploadBlob(object json, string? name = null) { throw null; }
        public void WhenBlobCreated(System.Func<string, System.Threading.Tasks.Task> function) { }
        public void WhenBlobUploaded(System.Action<string> function) { }
    }
}
namespace Azure.Core
{
    public partial class ClientCache
    {
        public ClientCache() { }
        public T Get<T>(string id, System.Func<T> value) where T : class { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientConfiguration
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientConfiguration(string endpoint, string? apiKey = null) { throw null; }
        public string? ApiKey { get { throw null; } }
        public Azure.Core.CredentialType CredentailType { get { throw null; } }
        public string Endpoint { get { throw null; } }
    }
    public enum CredentialType
    {
        EntraId = 0,
        ApiKey = 1,
    }
    public abstract partial class WorkspaceClient
    {
        protected WorkspaceClient() { }
        public abstract Azure.Core.TokenCredential Credential { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ClientCache Subclients { get { throw null; } }
        public abstract Azure.Core.ClientConfiguration? GetConfiguration(string clientId, string? instanceId = null);
    }
}
namespace Azure.Provisioning.CloudMachine
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public abstract void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure cm);
    }
    public partial class CloudMachineInfrastructure
    {
        public CloudMachineInfrastructure(string cmId) { }
        public string Id { get { throw null; } }
        public Azure.Provisioning.Roles.UserAssignedIdentity Identity { get { throw null; } }
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public void AddFeature(Azure.Provisioning.CloudMachine.CloudMachineFeature resource) { }
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisioningConstruct resource) { }
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
        public static bool Configure(string[] args, System.Action<Azure.Provisioning.CloudMachine.CloudMachineInfrastructure>? configure = null) { throw null; }
    }
}
namespace Azure.Provisioning.CloudMachine.KeyVault
{
    public static partial class KeyVaultExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetKeyVaultSecretsClient(this Azure.Core.WorkspaceClient workspace) { throw null; }
    }
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature() { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure infrastructure) { }
    }
}
namespace Azure.Provisioning.CloudMachine.OpenAI
{
    public partial class OpenAIFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIFeature(string model, string modelVersion) { }
        public string Model { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure infrastructure) { }
    }
    public static partial class OpenAIFeatureExtensions
    {
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this Azure.Core.WorkspaceClient workspace) { throw null; }
    }
}
