namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    public partial class AzureKeyVaultConfigurationOptions
    {
        public AzureKeyVaultConfigurationOptions() { }
        public Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager Manager { get { throw null; } set { } }
        public System.TimeSpan? ReloadInterval { get { throw null; } set { } }
    }
    public partial class AzureKeyVaultConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider, System.IDisposable
    {
        public AzureKeyVaultConfigurationProvider(Azure.Security.KeyVault.Secrets.SecretClient client, Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions options = null) { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public override void Load() { }
    }
    public partial class AzureKeyVaultConfigurationSource : Microsoft.Extensions.Configuration.IConfigurationSource
    {
        public AzureKeyVaultConfigurationSource(Azure.Security.KeyVault.Secrets.SecretClient client, Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions options) { }
        public Microsoft.Extensions.Configuration.IConfigurationProvider Build(Microsoft.Extensions.Configuration.IConfigurationBuilder builder) { throw null; }
    }
    public partial class KeyVaultSecretManager
    {
        public KeyVaultSecretManager() { }
        public virtual System.Collections.Generic.Dictionary<string, string> GetData(System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Secrets.KeyVaultSecret> secrets) { throw null; }
        public virtual string GetKey(Azure.Security.KeyVault.Secrets.KeyVaultSecret secret) { throw null; }
        public virtual bool Load(Azure.Security.KeyVault.Secrets.SecretProperties secret) { throw null; }
    }
}
namespace Microsoft.Extensions.Configuration
{
    public static partial class AzureKeyVaultConfigurationExtensions
    {
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, Azure.Security.KeyVault.Secrets.SecretClient client, Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions options) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, Azure.Security.KeyVault.Secrets.SecretClient client, Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager manager) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Uri vaultUri, Azure.Core.TokenCredential credential) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions options) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager manager) { throw null; }
    }
}
