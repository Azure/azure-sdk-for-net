namespace Azure.CloudMachine
{
    public partial class ClientCache
    {
        public ClientCache() { }
        public T Get<T>(string id, System.Func<T> value) where T : class { throw null; }
    }
    public partial class CloudMachineClient
    {
        protected CloudMachineClient() { }
        public CloudMachineClient(Azure.Identity.DefaultAzureCredential? credential = null, Microsoft.Extensions.Configuration.IConfiguration? configuration = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.CloudMachine.ClientCache ClientCache { get { throw null; } }
        public Azure.Core.TokenCredential Credential { get { throw null; } }
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.CloudMachine.CloudMachineClient.CloudMachineProperties Properties { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct CloudMachineProperties
        {
            private object _dummy;
            private int _dummyPrimitive;
            public System.Uri BlobServiceUri { get { throw null; } }
            public System.Uri DefaultContainerUri { get { throw null; } }
            public System.Uri KeyVaultUri { get { throw null; } }
            public string ServiceBusNamespace { get { throw null; } }
        }
    }
    public static partial class MessagingServices
    {
        public static void Send(this Azure.CloudMachine.CloudMachineClient cm, object serializable) { }
    }
    public static partial class StorageServices
    {
        public static System.BinaryData Download(this Azure.CloudMachine.CloudMachineClient cm, string name) { throw null; }
        public static string Upload(this Azure.CloudMachine.CloudMachineClient cm, object json, string? name = null) { throw null; }
    }
}
namespace Azure.Provisioning.CloudMachine
{
    public abstract partial class CloudMachineFeature
    {
        protected CloudMachineFeature() { }
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
        public static Azure.Security.KeyVault.Secrets.SecretClient GetKeyVaultSecretClient(this Azure.CloudMachine.CloudMachineClient client) { throw null; }
    }
    public partial class KeyVaultFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public KeyVaultFeature() { }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure cm) { }
    }
}
namespace Azure.Provisioning.CloudMachine.OpenAI
{
    public partial class OpenAIFeature : Azure.Provisioning.CloudMachine.CloudMachineFeature
    {
        public OpenAIFeature() { }
        public override void AddTo(Azure.Provisioning.CloudMachine.CloudMachineInfrastructure cm) { }
    }
    public static partial class OpenAIFeatureExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetOpenAIClient(this Azure.CloudMachine.CloudMachineClient client) { throw null; }
    }
}
