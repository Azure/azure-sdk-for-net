namespace Microsoft.AspNetCore.DataProtection
{
    public static partial class AzureDataProtectionKeyVaultKeyBuilderExtensions
    {
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, Azure.Core.Cryptography.IKeyEncryptionKeyResolver client, string keyIdentifier) { throw null; }
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, string keyIdentifier) { throw null; }
        public static Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder builder, string keyIdentifier, Azure.Core.TokenCredential tokenCredential) { throw null; }
    }
}
