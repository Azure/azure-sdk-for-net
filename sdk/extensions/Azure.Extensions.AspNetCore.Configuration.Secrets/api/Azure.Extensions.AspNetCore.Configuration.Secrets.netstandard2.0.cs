namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    public partial class KeyVaultSecretManager
    {
        public KeyVaultSecretManager() { }
        public virtual string GetKey(Azure.Security.KeyVault.Secrets.KeyVaultSecret secret) { throw null; }
        public virtual bool Load(Azure.Security.KeyVault.Secrets.SecretProperties secret) { throw null; }
    }
}
namespace Microsoft.Extensions.Configuration
{
    public static partial class AzureKeyVaultConfigurationExtensions
    {
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, Azure.Security.KeyVault.Secrets.SecretClient client, Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager manager) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Uri vaultUri, Azure.Core.TokenCredential credential) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddAzureKeyVault(this Microsoft.Extensions.Configuration.IConfigurationBuilder configurationBuilder, System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager manager) { throw null; }
    }
}
