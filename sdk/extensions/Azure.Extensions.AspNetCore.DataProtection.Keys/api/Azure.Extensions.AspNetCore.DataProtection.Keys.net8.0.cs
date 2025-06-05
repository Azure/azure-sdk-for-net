namespace Microsoft.AspNetCore.DataProtection
{
    public static partial class AzureDataProtectionKeyVaultKeyBuilderExtensions
    {
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, string keyIdentifier, Azure.Core.Cryptography.IKeyEncryptionKeyResolver keyResolver) { throw null; }
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, string keyIdentifier, System.Func<System.IServiceProvider, Azure.Core.Cryptography.IKeyEncryptionKeyResolver> keyResolverFactory) { throw null; }
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, string keyIdentifier, System.Func<System.IServiceProvider, Azure.Core.TokenCredential> tokenCredentialFactory) { throw null; }
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, System.Uri keyIdentifier, Azure.Core.TokenCredential tokenCredential) { throw null; }
    }
}
