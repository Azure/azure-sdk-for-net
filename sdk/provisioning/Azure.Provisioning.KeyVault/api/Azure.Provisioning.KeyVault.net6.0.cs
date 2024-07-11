namespace Azure.Provisioning.KeyVaults
{
    public partial class KeyVault : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultData>
    {
        public KeyVault(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "kv", string version = "2022-07-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultData>), default(bool)) { }
        public void AddAccessPolicy(Azure.Provisioning.Output output) { }
        public static Azure.Provisioning.KeyVaults.KeyVault FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Provisioning.KeyVaults.KeyVault AddKeyVault(this Azure.Provisioning.IConstruct construct, Azure.Provisioning.ResourceManager.ResourceGroup? resourceGroup = null, string name = "kv") { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.Provisioning.KeyVaults.KeyVaultSecret> GetSecrets(this Azure.Provisioning.IConstruct construct) { throw null; }
    }
    public partial class KeyVaultSecret : Azure.Provisioning.Resource<Azure.ResourceManager.KeyVault.KeyVaultSecretData>
    {
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, Azure.Provisioning.KeyVaults.KeyVault? parent = null, string name = "kvs", string version = "2022-07-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>), default(bool)) { }
        public KeyVaultSecret(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ConnectionString connectionString, Azure.Provisioning.KeyVaults.KeyVault? parent = null, string version = "2022-07-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.KeyVault.KeyVaultSecretData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.KeyVaults.KeyVaultSecret FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.KeyVaults.KeyVault parent) { throw null; }
    }
}
