namespace Azure.Security.KeyVault.Keys
{
    public partial class CreateEcKeyOptions : Azure.Security.KeyVault.Keys.CreateKeyOptions
    {
        public CreateEcKeyOptions(string name, bool hardwareProtected = false) { }
        public Azure.Security.KeyVault.Keys.KeyCurveName? CurveName { get { throw null; } set { } }
        public bool HardwareProtected { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyType KeyType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CreateKeyOptions
    {
        public CreateKeyOptions() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public bool? Exportable { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Keys.KeyOperation> KeyOperations { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.KeyReleasePolicy ReleasePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CreateRsaKeyOptions : Azure.Security.KeyVault.Keys.CreateKeyOptions
    {
        public CreateRsaKeyOptions(string name, bool hardwareProtected = false) { }
        public bool HardwareProtected { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.KeyType KeyType { get { throw null; } }
        public string Name { get { throw null; } }
        public int? PublicExponent { get { throw null; } set { } }
    }
    public static partial class CryptographyModelFactory
    {
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions DecryptOptions(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = null, byte[] authenticationTag = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptResult DecryptResult(string keyId = null, byte[] plaintext = null, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm)) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions EncryptOptions(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptResult EncryptResult(string keyId, byte[] ciphertext, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptResult EncryptResult(string keyId = null, byte[] ciphertext = null, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm), byte[] iv = null, byte[] authenticatedTag = null, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignResult SignResult(string keyId = null, byte[] signature = null, Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm)) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.UnwrapResult UnwrapResult(string keyId = null, byte[] key = null, Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm)) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.VerifyResult VerifyResult(string keyId = null, bool isValid = false, Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm)) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.WrapResult WrapResult(string keyId = null, byte[] key = null, Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm)) { throw null; }
    }
    public partial class DeletedKey : Azure.Security.KeyVault.Keys.KeyVaultKey
    {
        internal DeletedKey() : base (default(string)) { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.Uri RecoveryId { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
    }
    public partial class DeleteKeyOperation : Azure.Operation<Azure.Security.KeyVault.Keys.DeletedKey>
    {
        internal DeleteKeyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Keys.DeletedKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ImportKeyOptions
    {
        public ImportKeyOptions(string name, Azure.Security.KeyVault.Keys.JsonWebKey keyMaterial) { }
        public bool? HardwareProtected { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.JsonWebKey Key { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyProperties Properties { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyReleasePolicy ReleasePolicy { get { throw null; } set { } }
    }
    public partial class JsonWebKey
    {
        public JsonWebKey(System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps) { }
        public JsonWebKey(System.Security.Cryptography.Aes aesProvider, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps = null) { }
        public JsonWebKey(System.Security.Cryptography.ECDsa ecdsa, bool includePrivateParameters = false, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps = null) { }
        public JsonWebKey(System.Security.Cryptography.RSA rsaProvider, bool includePrivateParameters = false, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps = null) { }
        public Azure.Security.KeyVault.Keys.KeyCurveName? CurveName { get { throw null; } set { } }
        public byte[] D { get { throw null; } set { } }
        public byte[] DP { get { throw null; } set { } }
        public byte[] DQ { get { throw null; } set { } }
        public byte[] E { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public byte[] K { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.Security.KeyVault.Keys.KeyOperation> KeyOps { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyType KeyType { get { throw null; } set { } }
        public byte[] N { get { throw null; } set { } }
        public byte[] P { get { throw null; } set { } }
        public byte[] Q { get { throw null; } set { } }
        public byte[] QI { get { throw null; } set { } }
        public byte[] T { get { throw null; } set { } }
        public byte[] X { get { throw null; } set { } }
        public byte[] Y { get { throw null; } set { } }
        public System.Security.Cryptography.Aes ToAes() { throw null; }
        public System.Security.Cryptography.ECDsa ToECDsa(bool includePrivateParameters = false) { throw null; }
        public System.Security.Cryptography.RSA ToRSA(bool includePrivateParameters = false) { throw null; }
    }
    public partial class KeyClient
    {
        protected KeyClient() { }
        public KeyClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Keys.KeyClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<byte[]> BackupKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<byte[]>> BackupKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> CreateEcKey(Azure.Security.KeyVault.Keys.CreateEcKeyOptions ecKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> CreateEcKeyAsync(Azure.Security.KeyVault.Keys.CreateEcKeyOptions ecKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> CreateKey(string name, Azure.Security.KeyVault.Keys.KeyType keyType, Azure.Security.KeyVault.Keys.CreateKeyOptions keyOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> CreateKeyAsync(string name, Azure.Security.KeyVault.Keys.KeyType keyType, Azure.Security.KeyVault.Keys.CreateKeyOptions keyOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> CreateRsaKey(Azure.Security.KeyVault.Keys.CreateRsaKeyOptions rsaKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> CreateRsaKeyAsync(Azure.Security.KeyVault.Keys.CreateRsaKeyOptions rsaKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ExportKey(string name, string version, string environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ExportKey(string name, string environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ExportKeyAsync(string name, string version, string environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ExportKeyAsync(string name, string environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey>> GetDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> GetKey(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> GetKeyAsync(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeyVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeyVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ImportKey(Azure.Security.KeyVault.Keys.ImportKeyOptions importKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ImportKey(string name, Azure.Security.KeyVault.Keys.JsonWebKey keyMaterial, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ImportKeyAsync(Azure.Security.KeyVault.Keys.ImportKeyOptions importKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ImportKeyAsync(string name, Azure.Security.KeyVault.Keys.JsonWebKey keyMaterial, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PurgeDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PurgeDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> RestoreKeyBackup(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> RestoreKeyBackupAsync(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.DeleteKeyOperation StartDeleteKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.DeleteKeyOperation> StartDeleteKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.RecoverDeletedKeyOperation StartRecoverDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.RecoverDeletedKeyOperation> StartRecoverDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> UpdateKeyProperties(Azure.Security.KeyVault.Keys.KeyProperties properties, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOperations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> UpdateKeyPropertiesAsync(Azure.Security.KeyVault.Keys.KeyProperties properties, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOperations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyClientOptions : Azure.Core.ClientOptions
    {
        public KeyClientOptions(Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion version = Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion.V7_1) { }
        public Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_0 = 0,
            V7_1 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyCurveName : System.IEquatable<Azure.Security.KeyVault.Keys.KeyCurveName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyCurveName(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyCurveName P256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyCurveName P256K { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyCurveName P384 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyCurveName P521 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyCurveName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.KeyCurveName left, Azure.Security.KeyVault.Keys.KeyCurveName right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.KeyCurveName (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.KeyCurveName left, Azure.Security.KeyVault.Keys.KeyCurveName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class KeyModelFactory
    {
        public static Azure.Security.KeyVault.Keys.DeletedKey DeletedKey(Azure.Security.KeyVault.Keys.KeyProperties properties, Azure.Security.KeyVault.Keys.JsonWebKey key, System.Uri recoveryId = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Keys.JsonWebKey JsonWebKey(Azure.Security.KeyVault.Keys.KeyType keyType, string id = null, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps = null, Azure.Security.KeyVault.Keys.KeyCurveName? curveName = default(Azure.Security.KeyVault.Keys.KeyCurveName?), byte[] d = null, byte[] dp = null, byte[] dq = null, byte[] e = null, byte[] k = null, byte[] n = null, byte[] p = null, byte[] q = null, byte[] qi = null, byte[] t = null, byte[] x = null, byte[] y = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Security.KeyVault.Keys.KeyProperties KeyProperties(System.Uri id, System.Uri vaultUri, string name, string version, bool managed, System.DateTimeOffset? createdOn, System.DateTimeOffset? updatedOn, string recoveryLevel) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyProperties KeyProperties(System.Uri id = null, System.Uri vaultUri = null, string name = null, string version = null, bool managed = false, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string recoveryLevel = null, int? recoverableDays = default(int?)) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyVaultKey KeyVaultKey(Azure.Security.KeyVault.Keys.KeyProperties properties, Azure.Security.KeyVault.Keys.JsonWebKey key) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyOperation : System.IEquatable<Azure.Security.KeyVault.Keys.KeyOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyOperation(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyOperation Decrypt { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Encrypt { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Export { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Import { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Sign { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation UnwrapKey { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Verify { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation WrapKey { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.KeyOperation left, Azure.Security.KeyVault.Keys.KeyOperation right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.KeyOperation (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.KeyOperation left, Azure.Security.KeyVault.Keys.KeyOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyProperties
    {
        public KeyProperties(string name) { }
        public KeyProperties(System.Uri id) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public bool? Exportable { get { throw null; } set { } }
        public System.Uri Id { get { throw null; } }
        public bool Managed { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        public int? RecoverableDays { get { throw null; } }
        public string RecoveryLevel { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyReleasePolicy ReleasePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyReleasePolicy
    {
        public KeyReleasePolicy(byte[] data) { }
        public string ContentType { get { throw null; } set { } }
        public byte[] Data { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.Security.KeyVault.Keys.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyType Ec { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyType EcHsm { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyType Oct { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyType OctHsm { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyType Rsa { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyType RsaHsm { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.KeyType left, Azure.Security.KeyVault.Keys.KeyType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.KeyType left, Azure.Security.KeyVault.Keys.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKey
    {
        public KeyVaultKey(string name) { }
        public System.Uri Id { get { throw null; } }
        public Azure.Security.KeyVault.Keys.JsonWebKey Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<Azure.Security.KeyVault.Keys.KeyOperation> KeyOperations { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyType KeyType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Keys.KeyProperties Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultKeyIdentifier
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Name { get { throw null; } }
        public System.Uri SourceId { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyVaultKeyIdentifier Parse(System.Uri id) { throw null; }
        public static bool TryParse(System.Uri id, out Azure.Security.KeyVault.Keys.KeyVaultKeyIdentifier keyId) { throw null; }
    }
    public partial class RecoverDeletedKeyOperation : Azure.Operation<Azure.Security.KeyVault.Keys.KeyVaultKey>
    {
        internal RecoverDeletedKeyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Keys.KeyVaultKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public partial class CryptographyClient : Azure.Core.Cryptography.IKeyEncryptionKey
    {
        protected CryptographyClient() { }
        public CryptographyClient(System.Uri keyId, Azure.Core.TokenCredential credential) { }
        public CryptographyClient(System.Uri keyId, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions options) { }
        public virtual string KeyId { get { throw null; } }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKey(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.WrapKey(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.WrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult Sign(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult SignData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult SignData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.UnwrapResult UnwrapKey(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.UnwrapResult> UnwrapKeyAsync(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult Verify(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult VerifyData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult VerifyData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.WrapResult WrapKey(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.WrapResult> WrapKeyAsync(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CryptographyClientOptions : Azure.Core.ClientOptions
    {
        public CryptographyClientOptions(Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion version = Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion.V7_1) { }
        public Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_0 = 0,
            V7_1 = 1,
        }
    }
    public partial class DecryptOptions
    {
        internal DecryptOptions() { }
        public byte[] AdditionalAuthenticatedData { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public byte[] AuthenticationTag { get { throw null; } }
        public byte[] Ciphertext { get { throw null; } }
        public byte[] Iv { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A128CbcOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A128CbcPadOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A128GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A192CbcOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A192CbcPadOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A192GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A256CbcOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A256CbcPadOptions(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions A256GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions Rsa15Options(byte[] ciphertext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions RsaOaep256Options(byte[] ciphertext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions RsaOaepOptions(byte[] ciphertext) { throw null; }
    }
    public partial class DecryptResult
    {
        internal DecryptResult() { }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public string KeyId { get { throw null; } }
        public byte[] Plaintext { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAlgorithm : System.IEquatable<Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAlgorithm(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A128Cbc { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A128CbcPad { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A128Gcm { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A192Cbc { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A192CbcPad { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A192Gcm { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A256Cbc { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A256CbcPad { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm A256Gcm { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Rsa15 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm RsaOaep { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm RsaOaep256 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptOptions
    {
        internal EncryptOptions() { }
        public byte[] AdditionalAuthenticatedData { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public byte[] Iv { get { throw null; } }
        public byte[] Plaintext { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A128CbcOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A128CbcPadOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A128GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A192CbcOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A192CbcPadOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A192GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A256CbcOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A256CbcPadOptions(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions A256GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions Rsa15Options(byte[] plaintext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions RsaOaep256Options(byte[] plaintext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions RsaOaepOptions(byte[] plaintext) { throw null; }
    }
    public partial class EncryptResult
    {
        internal EncryptResult() { }
        public byte[] AdditionalAuthenticatedData { get { throw null; } }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public byte[] AuthenticationTag { get { throw null; } }
        public byte[] Ciphertext { get { throw null; } }
        public byte[] Iv { get { throw null; } }
        public string KeyId { get { throw null; } }
    }
    public partial class KeyResolver : Azure.Core.Cryptography.IKeyEncryptionKeyResolver
    {
        protected KeyResolver() { }
        public KeyResolver(Azure.Core.TokenCredential credential) { }
        public KeyResolver(Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions options) { }
        Azure.Core.Cryptography.IKeyEncryptionKey Azure.Core.Cryptography.IKeyEncryptionKeyResolver.Resolve(string keyId, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<Azure.Core.Cryptography.IKeyEncryptionKey> Azure.Core.Cryptography.IKeyEncryptionKeyResolver.ResolveAsync(string keyId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient Resolve(System.Uri keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient> ResolveAsync(System.Uri keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyWrapAlgorithm : System.IEquatable<Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyWrapAlgorithm(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm A128KW { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm A192KW { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm A256KW { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm Rsa15 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm RsaOaep { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm RsaOaep256 { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class LocalCryptographyClient : Azure.Core.Cryptography.IKeyEncryptionKey
    {
        protected LocalCryptographyClient() { }
        public LocalCryptographyClient(Azure.Security.KeyVault.Keys.JsonWebKey jsonWebKey) { }
        public string KeyId { get { throw null; } }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKey(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.WrapKey(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.WrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.DecryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult Sign(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult SignData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.SignResult SignData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.SignResult> SignDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.UnwrapResult UnwrapKey(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.UnwrapResult> UnwrapKeyAsync(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult Verify(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] digest, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult VerifyData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.VerifyResult VerifyData(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, byte[] data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.VerifyResult> VerifyDataAsync(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm algorithm, System.IO.Stream data, byte[] signature, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.WrapResult WrapKey(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.WrapResult> WrapKeyAsync(Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm algorithm, byte[] key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignatureAlgorithm : System.IEquatable<Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignatureAlgorithm(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm ES256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm ES256K { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm ES384 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm ES512 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm PS256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm PS384 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm PS512 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm RS256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm RS384 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm RS512 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm left, Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignResult
    {
        internal SignResult() { }
        public Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm Algorithm { get { throw null; } }
        public string KeyId { get { throw null; } }
        public byte[] Signature { get { throw null; } }
    }
    public partial class UnwrapResult
    {
        internal UnwrapResult() { }
        public Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm Algorithm { get { throw null; } }
        public byte[] Key { get { throw null; } }
        public string KeyId { get { throw null; } }
    }
    public partial class VerifyResult
    {
        internal VerifyResult() { }
        public Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm Algorithm { get { throw null; } }
        public bool IsValid { get { throw null; } }
        public string KeyId { get { throw null; } }
    }
    public partial class WrapResult
    {
        internal WrapResult() { }
        public Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm Algorithm { get { throw null; } }
        public byte[] EncryptedKey { get { throw null; } }
        public string KeyId { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class KeyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient, Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions> AddCryptographyClient<TBuilder>(this TBuilder builder, System.Uri vaultUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient, Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions> AddCryptographyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Keys.KeyClient, Azure.Security.KeyVault.Keys.KeyClientOptions> AddKeyClient<TBuilder>(this TBuilder builder, System.Uri vaultUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Keys.KeyClient, Azure.Security.KeyVault.Keys.KeyClientOptions> AddKeyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
