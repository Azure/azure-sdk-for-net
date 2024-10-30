public partial class AiModel
{
    public AiModel(string model, string modelVersion) { }
    public string Model { get { throw null; } }
    public string ModelVersion { get { throw null; } }
}
namespace Azure.CloudMachine
{
    public partial class CloudMachineClient : Azure.CloudMachine.CloudMachineWorkspace
    {
        public CloudMachineClient(Azure.Core.TokenCredential? credential = null, Microsoft.Extensions.Configuration.IConfiguration? configuration = null) : base (default(Azure.Core.TokenCredential), default(Microsoft.Extensions.Configuration.IConfiguration)) { }
        public Azure.CloudMachine.MessagingServices Messaging { get { throw null; } }
        public Azure.CloudMachine.StorageServices Storage { get { throw null; } }
    }
    public partial class CloudMachineWorkspace : Azure.Core.ClientWorkspace
    {
        public CloudMachineWorkspace(Azure.Core.TokenCredential? credential = null, Microsoft.Extensions.Configuration.IConfiguration? configuration = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Core.ClientConnectionOptions GetConnectionOptions(System.Type clientType, string? instanceId = null) { throw null; }
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
    public partial class StorageFile
    {
        internal StorageFile() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string Path { get { throw null; } }
        public string RequestId { get { throw null; } }
        public void Delete() { }
        public System.BinaryData Download() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Response (Azure.CloudMachine.StorageFile result) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void DeleteBlob(string path) { }
        public System.BinaryData DownloadBlob(string path) { throw null; }
        public string UploadBinaryData(System.BinaryData data, string? name = null, bool overwrite = false) { throw null; }
        public string UploadBytes(byte[] bytes, string? name = null, bool overwrite = false) { throw null; }
        public string UploadBytes(System.ReadOnlyMemory<byte> bytes, string? name = null, bool overwrite = false) { throw null; }
        public string UploadJson(object json, string? name = null, bool overwrite = false) { throw null; }
        public string UploadStream(System.IO.Stream fileStream, string? name = null, bool overwrite = false) { throw null; }
        public void WhenBlobUploaded(System.Action<Azure.CloudMachine.StorageFile> function) { }
    }
}
namespace Azure.Core
{
    public partial class ClientCache
    {
        public ClientCache() { }
        public T Get<T>(System.Func<T> value, string? id = null) where T : class { throw null; }
    }
    public enum ClientConnectionKind
    {
        EntraId = 0,
        ApiKey = 1,
        OutOfBand = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientConnectionOptions
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientConnectionOptions(string subclientId) { throw null; }
        public ClientConnectionOptions(System.Uri endpoint, Azure.Core.TokenCredential credential) { throw null; }
        public ClientConnectionOptions(System.Uri endpoint, string apiKey) { throw null; }
        public string? ApiKeyCredential { get { throw null; } }
        public Azure.Core.ClientConnectionKind ConnectionKind { get { throw null; } }
        public System.Uri? Endpoint { get { throw null; } }
        public string? Id { get { throw null; } }
        public Azure.Core.TokenCredential? TokenCredential { get { throw null; } }
    }
    public abstract partial class ClientWorkspace
    {
        protected ClientWorkspace() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ClientCache Subclients { get { throw null; } }
        public abstract Azure.Core.ClientConnectionOptions GetConnectionOptions(System.Type clientType, string? instanceId = null);
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
        public void AddEndpoints<T>() { }
        public void AddFeature(Azure.Provisioning.CloudMachine.CloudMachineFeature resource) { }
        public void AddResource(Azure.Provisioning.Primitives.NamedProvisionableConstruct resource) { }
        public Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningBuildOptions? context = null) { throw null; }
        public static bool Configure(string[] args, System.Action<Azure.Provisioning.CloudMachine.CloudMachineInfrastructure>? configure = null) { throw null; }
    }
}
namespace Azure.Provisioning.CloudMachine.KeyVault
{
    public static partial class KeyVaultExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetKeyVaultSecretsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
    }
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature(Azure.Provisioning.KeyVault.KeyVaultSku? sku = null) { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure infrastructure) { }
    }
}
namespace Azure.Provisioning.CloudMachine.OpenAI
{
    public static partial class AzureOpenAIExtensions
    {
        public static Azure.Provisioning.CloudMachine.OpenAI.EmbeddingKnowledgebase CreateEmbeddingKnowledgebase(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static Azure.Provisioning.CloudMachine.OpenAI.OpenAIConversation CreateOpenAIConversation(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static OpenAI.Embeddings.EmbeddingClient GetOpenAIEmbeddingsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
    }
    public partial class EmbeddingKnowledgebase
    {
        internal EmbeddingKnowledgebase() { }
        public void Add(string fact) { }
    }
    public partial class OpenAIConversation
    {
        internal OpenAIConversation() { }
        public string Say(string message) { throw null; }
    }
    public partial class OpenAIFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIFeature(AiModel chatDeployment, AiModel? embeddingsDeployment = null) { }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure cloudMachine) { }
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
