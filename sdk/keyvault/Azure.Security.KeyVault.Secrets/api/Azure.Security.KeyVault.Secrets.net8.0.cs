namespace Azure.Security.KeyVault.Secrets
{
    public partial class DeletedSecret : Azure.Security.KeyVault.Secrets.KeyVaultSecret
    {
        internal DeletedSecret() : base (default(string), default(string)) { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.Uri RecoveryId { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
    }
    public partial class DeleteSecretOperation : Azure.Operation<Azure.Security.KeyVault.Secrets.DeletedSecret>
    {
        protected DeleteSecretOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Secrets.DeletedSecret Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Secrets.DeletedSecret>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Secrets.DeletedSecret>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class KeyVaultSecret
    {
        public KeyVaultSecret(string name, string value) { }
        public System.Uri Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Secrets.SecretProperties Properties { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSecretIdentifier : System.IEquatable<Azure.Security.KeyVault.Secrets.KeyVaultSecretIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSecretIdentifier(System.Uri id) { throw null; }
        public string Name { get { throw null; } }
        public System.Uri SourceId { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Secrets.KeyVaultSecretIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public static bool TryCreate(System.Uri id, out Azure.Security.KeyVault.Secrets.KeyVaultSecretIdentifier identifier) { throw null; }
    }
    public partial class RecoverDeletedSecretOperation : Azure.Operation<Azure.Security.KeyVault.Secrets.SecretProperties>
    {
        protected RecoverDeletedSecretOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Secrets.SecretProperties Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SecretClient
    {
        protected SecretClient() { }
        public SecretClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public SecretClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Secrets.SecretClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<byte[]> BackupSecret(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<byte[]>> BackupSecretAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.DeletedSecret> GetDeletedSecret(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.DeletedSecret>> GetDeletedSecretAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Secrets.DeletedSecret> GetDeletedSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Secrets.DeletedSecret> GetDeletedSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Secrets.SecretProperties> GetPropertiesOfSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Secrets.SecretProperties> GetPropertiesOfSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Secrets.SecretProperties> GetPropertiesOfSecretVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Secrets.SecretProperties> GetPropertiesOfSecretVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret> GetSecret(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret>> GetSecretAsync(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PurgeDeletedSecret(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PurgeDeletedSecretAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties> RestoreSecretBackup(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties>> RestoreSecretBackupAsync(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret> SetSecret(Azure.Security.KeyVault.Secrets.KeyVaultSecret secret, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret> SetSecret(string name, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret>> SetSecretAsync(Azure.Security.KeyVault.Secrets.KeyVaultSecret secret, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.KeyVaultSecret>> SetSecretAsync(string name, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Secrets.DeleteSecretOperation StartDeleteSecret(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Secrets.DeleteSecretOperation> StartDeleteSecretAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Secrets.RecoverDeletedSecretOperation StartRecoverDeletedSecret(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Secrets.RecoverDeletedSecretOperation> StartRecoverDeletedSecretAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties> UpdateSecretProperties(Azure.Security.KeyVault.Secrets.SecretProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Secrets.SecretProperties>> UpdateSecretPropertiesAsync(Azure.Security.KeyVault.Secrets.SecretProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretClientOptions : Azure.Core.ClientOptions
    {
        public SecretClientOptions(Azure.Security.KeyVault.Secrets.SecretClientOptions.ServiceVersion version = Azure.Security.KeyVault.Secrets.SecretClientOptions.ServiceVersion.V2025_07_01) { }
        public bool DisableChallengeResourceVerification { get { throw null; } set { } }
        public Azure.Security.KeyVault.Secrets.SecretClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_0 = 0,
            V7_1 = 1,
            V7_2 = 2,
            V7_3 = 3,
            V7_4 = 4,
            V7_5 = 5,
            V7_6 = 6,
            V2025_07_01 = 7,
        }
    }
    public static partial class SecretModelFactory
    {
        public static Azure.Security.KeyVault.Secrets.DeletedSecret DeletedSecret(Azure.Security.KeyVault.Secrets.SecretProperties properties, string value = null, System.Uri recoveryId = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Secrets.KeyVaultSecret KeyVaultSecret(Azure.Security.KeyVault.Secrets.SecretProperties properties, string value = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Security.KeyVault.Secrets.SecretProperties SecretProperties(System.Uri id, System.Uri vaultUri, string name, string version, bool managed, System.Uri keyId, System.DateTimeOffset? createdOn, System.DateTimeOffset? updatedOn, string recoveryLevel) { throw null; }
        public static Azure.Security.KeyVault.Secrets.SecretProperties SecretProperties(System.Uri id = null, System.Uri vaultUri = null, string name = null, string version = null, bool managed = false, System.Uri keyId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string recoveryLevel = null, int? recoverableDays = default(int?)) { throw null; }
    }
    public partial class SecretProperties
    {
        public SecretProperties(string name) { }
        public SecretProperties(System.Uri id) { }
        public string ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public System.Uri Id { get { throw null; } }
        public System.Uri KeyId { get { throw null; } }
        public bool Managed { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        public int? RecoverableDays { get { throw null; } }
        public string RecoveryLevel { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SecretClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Secrets.SecretClient, Azure.Security.KeyVault.Secrets.SecretClientOptions> AddSecretClient<TBuilder>(this TBuilder builder, System.Uri vaultUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Secrets.SecretClient, Azure.Security.KeyVault.Secrets.SecretClientOptions> AddSecretClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
