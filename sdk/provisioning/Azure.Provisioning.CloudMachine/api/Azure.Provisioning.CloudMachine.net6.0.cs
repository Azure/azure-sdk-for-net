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
    public partial class CloudMachineInfrastructure : Azure.Provisioning.Infrastructure
    {
        public CloudMachineInfrastructure(string cloudMachineId) : base (default(string)) { }
        public Azure.Provisioning.ProvisioningParameter PrincipalIdParameter { get { throw null; } }
        public override Azure.Provisioning.ProvisioningPlan Build(Azure.Provisioning.ProvisioningContext? context = null) { throw null; }
        public static bool Configure(string[] args, System.Action<Azure.Provisioning.CloudMachine.CloudMachineInfrastructure>? configure = null) { throw null; }
    }
}
