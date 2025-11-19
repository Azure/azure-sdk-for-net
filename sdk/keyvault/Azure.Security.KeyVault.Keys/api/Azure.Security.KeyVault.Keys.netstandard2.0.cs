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
    public partial class CreateOctKeyOptions : Azure.Security.KeyVault.Keys.CreateKeyOptions
    {
        public CreateOctKeyOptions(string name, bool hardwareProtected = false) { }
        public bool HardwareProtected { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.KeyType KeyType { get { throw null; } }
        public string Name { get { throw null; } }
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
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters DecryptParameters(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = null, byte[] authenticationTag = null, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptResult DecryptResult(string keyId = null, byte[] plaintext = null, Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm = default(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm)) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters EncryptParameters(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = null, byte[] additionalAuthenticatedData = null) { throw null; }
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
        protected DeleteKeyOperation() { }
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
    public partial class KeyAttestation
    {
        public KeyAttestation() { }
        public System.ReadOnlyMemory<byte> CertificatePemFile { get { throw null; } }
        public System.ReadOnlyMemory<byte> PrivateKeyAttestation { get { throw null; } }
        public System.ReadOnlyMemory<byte> PublicKeyAttestation { get { throw null; } }
        public string Version { get { throw null; } }
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
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> CreateOctKey(Azure.Security.KeyVault.Keys.CreateOctKeyOptions octKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> CreateOctKeyAsync(Azure.Security.KeyVault.Keys.CreateOctKeyOptions octKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> CreateRsaKey(Azure.Security.KeyVault.Keys.CreateRsaKeyOptions rsaKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> CreateRsaKeyAsync(Azure.Security.KeyVault.Keys.CreateRsaKeyOptions rsaKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient GetCryptographyClient(string keyName, string keyVersion = null) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.DeletedKey>> GetDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.DeletedKey> GetDeletedKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> GetKey(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> GetKeyAsync(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> GetKeyAttestation(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> GetKeyAttestationAsync(string name, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyRotationPolicy> GetKeyRotationPolicy(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyRotationPolicy>> GetKeyRotationPolicyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeyVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Keys.KeyProperties> GetPropertiesOfKeyVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<byte[]> GetRandomBytes(int count, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<byte[]>> GetRandomBytesAsync(int count, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ImportKey(Azure.Security.KeyVault.Keys.ImportKeyOptions importKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> ImportKey(string name, Azure.Security.KeyVault.Keys.JsonWebKey keyMaterial, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ImportKeyAsync(Azure.Security.KeyVault.Keys.ImportKeyOptions importKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> ImportKeyAsync(string name, Azure.Security.KeyVault.Keys.JsonWebKey keyMaterial, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PurgeDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PurgeDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.ReleaseKeyResult> ReleaseKey(Azure.Security.KeyVault.Keys.ReleaseKeyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.ReleaseKeyResult> ReleaseKey(string name, string targetAttestationToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.ReleaseKeyResult>> ReleaseKeyAsync(Azure.Security.KeyVault.Keys.ReleaseKeyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.ReleaseKeyResult>> ReleaseKeyAsync(string name, string targetAttestationToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> RestoreKeyBackup(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> RestoreKeyBackupAsync(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> RotateKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> RotateKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.DeleteKeyOperation StartDeleteKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.DeleteKeyOperation> StartDeleteKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.RecoverDeletedKeyOperation StartRecoverDeletedKey(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.RecoverDeletedKeyOperation> StartRecoverDeletedKeyAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey> UpdateKeyProperties(Azure.Security.KeyVault.Keys.KeyProperties properties, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOperations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyVaultKey>> UpdateKeyPropertiesAsync(Azure.Security.KeyVault.Keys.KeyProperties properties, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOperations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Keys.KeyRotationPolicy> UpdateKeyRotationPolicy(string keyName, Azure.Security.KeyVault.Keys.KeyRotationPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Keys.KeyRotationPolicy>> UpdateKeyRotationPolicyAsync(string keyName, Azure.Security.KeyVault.Keys.KeyRotationPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyClientOptions : Azure.Core.ClientOptions
    {
        public KeyClientOptions(Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion version = Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion.V2025_07_01) { }
        public bool DisableChallengeResourceVerification { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.KeyClientOptions.ServiceVersion Version { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyExportEncryptionAlgorithm : System.IEquatable<Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyExportEncryptionAlgorithm(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm CkmRsaAesKeyWrap { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm RsaAesKeyWrap256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm RsaAesKeyWrap384 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm left, Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm left, Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class KeyModelFactory
    {
        public static Azure.Security.KeyVault.Keys.DeletedKey DeletedKey(Azure.Security.KeyVault.Keys.KeyProperties properties, Azure.Security.KeyVault.Keys.JsonWebKey key, System.Uri recoveryId = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Keys.JsonWebKey JsonWebKey(Azure.Security.KeyVault.Keys.KeyType keyType, string id = null, System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Keys.KeyOperation> keyOps = null, Azure.Security.KeyVault.Keys.KeyCurveName? curveName = default(Azure.Security.KeyVault.Keys.KeyCurveName?), byte[] d = null, byte[] dp = null, byte[] dq = null, byte[] e = null, byte[] k = null, byte[] n = null, byte[] p = null, byte[] q = null, byte[] qi = null, byte[] t = null, byte[] x = null, byte[] y = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Security.KeyVault.Keys.KeyProperties KeyProperties(System.Uri id, System.Uri vaultUri, string name, string version, bool managed, System.DateTimeOffset? createdOn, System.DateTimeOffset? updatedOn, string recoveryLevel) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyProperties KeyProperties(System.Uri id = null, System.Uri vaultUri = null, string name = null, string version = null, bool managed = false, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string recoveryLevel = null, int? recoverableDays = default(int?)) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyRotationPolicy KeyRotationPolicy(System.Uri id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyVaultKey KeyVaultKey(Azure.Security.KeyVault.Keys.KeyProperties properties, Azure.Security.KeyVault.Keys.JsonWebKey key) { throw null; }
        public static Azure.Security.KeyVault.Keys.ReleaseKeyResult ReleaseKeyResult(string value) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyOperation : System.IEquatable<Azure.Security.KeyVault.Keys.KeyOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyOperation(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyOperation Decrypt { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyOperation Encrypt { get { throw null; } }
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
        public Azure.Security.KeyVault.Keys.KeyAttestation Attestation { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public bool? Exportable { get { throw null; } set { } }
        public string HsmPlatform { get { throw null; } }
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
        public KeyReleasePolicy(System.BinaryData encodedPolicy) { }
        public string ContentType { get { throw null; } set { } }
        public System.BinaryData EncodedPolicy { get { throw null; } }
        public bool? Immutable { get { throw null; } set { } }
    }
    public partial class KeyRotationLifetimeAction
    {
        public KeyRotationLifetimeAction(Azure.Security.KeyVault.Keys.KeyRotationPolicyAction action) { }
        public Azure.Security.KeyVault.Keys.KeyRotationPolicyAction Action { get { throw null; } }
        public string TimeAfterCreate { get { throw null; } set { } }
        public string TimeBeforeExpiry { get { throw null; } set { } }
    }
    public partial class KeyRotationPolicy
    {
        public KeyRotationPolicy() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ExpiresIn { get { throw null; } set { } }
        public System.Uri Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Keys.KeyRotationLifetimeAction> LifetimeActions { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyRotationPolicyAction : System.IEquatable<Azure.Security.KeyVault.Keys.KeyRotationPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyRotationPolicyAction(string value) { throw null; }
        public static Azure.Security.KeyVault.Keys.KeyRotationPolicyAction Notify { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.KeyRotationPolicyAction Rotate { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyRotationPolicyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Keys.KeyRotationPolicyAction left, Azure.Security.KeyVault.Keys.KeyRotationPolicyAction right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Keys.KeyRotationPolicyAction (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Keys.KeyRotationPolicyAction left, Azure.Security.KeyVault.Keys.KeyRotationPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct KeyVaultKeyIdentifier : System.IEquatable<Azure.Security.KeyVault.Keys.KeyVaultKeyIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultKeyIdentifier(System.Uri id) { throw null; }
        public string Name { get { throw null; } }
        public System.Uri SourceId { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Keys.KeyVaultKeyIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public static bool TryCreate(System.Uri id, out Azure.Security.KeyVault.Keys.KeyVaultKeyIdentifier identifier) { throw null; }
    }
    public partial class RecoverDeletedKeyOperation : Azure.Operation<Azure.Security.KeyVault.Keys.KeyVaultKey>
    {
        protected RecoverDeletedKeyOperation() { }
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
    public partial class ReleaseKeyOptions
    {
        public ReleaseKeyOptions(string name, string targetAttestationToken) { }
        public Azure.Security.KeyVault.Keys.KeyExportEncryptionAlgorithm? Algorithm { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Nonce { get { throw null; } set { } }
        public string TargetAttestationToken { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ReleaseKeyResult
    {
        internal ReleaseKeyResult() { }
        public string Value { get { throw null; } }
    }
}
namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public partial class CryptographyClient : Azure.Core.Cryptography.IKeyEncryptionKey
    {
        protected CryptographyClient() { }
        public CryptographyClient(Azure.Security.KeyVault.Keys.JsonWebKey key) { }
        public CryptographyClient(Azure.Security.KeyVault.Keys.JsonWebKey key, Azure.Security.KeyVault.Keys.Cryptography.LocalCryptographyClientOptions options) { }
        public CryptographyClient(System.Uri keyId, Azure.Core.TokenCredential credential) { }
        public CryptographyClient(System.Uri keyId, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions options) { }
        public virtual string KeyId { get { throw null; } }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKey(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.UnwrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken) { throw null; }
        byte[] Azure.Core.Cryptography.IKeyEncryptionKey.WrapKey(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Threading.Tasks.Task<byte[]> Azure.Core.Cryptography.IKeyEncryptionKey.WrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.RSAKeyVault CreateRSA(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.RSAKeyVault> CreateRSAAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters decryptParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.DecryptResult Decrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters decryptParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.DecryptResult> DecryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] ciphertext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Keys.Cryptography.EncryptResult Encrypt(Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters encryptParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm algorithm, byte[] plaintext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Keys.Cryptography.EncryptResult> EncryptAsync(Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters encryptParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public CryptographyClientOptions(Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion version = Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion.V2025_07_01) { }
        public bool DisableChallengeResourceVerification { get { throw null; } set { } }
        public Azure.Security.KeyVault.Keys.Cryptography.CryptographyClientOptions.ServiceVersion Version { get { throw null; } }
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
    public partial class DecryptParameters
    {
        internal DecryptParameters() { }
        public byte[] AdditionalAuthenticatedData { get { throw null; } }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public byte[] AuthenticationTag { get { throw null; } }
        public byte[] Ciphertext { get { throw null; } }
        public byte[] Iv { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A128CbcPadParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A128CbcParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A128GcmParameters(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A192CbcPadParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A192CbcParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A192GcmParameters(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A256CbcPadParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A256CbcParameters(byte[] ciphertext, byte[] iv) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters A256GcmParameters(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters Rsa15Parameters(byte[] ciphertext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters RsaOaep256Parameters(byte[] ciphertext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.DecryptParameters RsaOaepParameters(byte[] ciphertext) { throw null; }
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
    public partial class EncryptParameters
    {
        internal EncryptParameters() { }
        public byte[] AdditionalAuthenticatedData { get { throw null; } }
        public Azure.Security.KeyVault.Keys.Cryptography.EncryptionAlgorithm Algorithm { get { throw null; } }
        public byte[] Iv { get { throw null; } }
        public byte[] Plaintext { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A128CbcPadParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A128CbcParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A128GcmParameters(byte[] plaintext, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A192CbcPadParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A192CbcParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A192GcmParameters(byte[] plaintext, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A256CbcPadParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A256CbcParameters(byte[] plaintext, byte[] iv = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters A256GcmParameters(byte[] plaintext, byte[] additionalAuthenticatedData = null) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters Rsa15Parameters(byte[] plaintext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters RsaOaep256Parameters(byte[] plaintext) { throw null; }
        public static Azure.Security.KeyVault.Keys.Cryptography.EncryptParameters RsaOaepParameters(byte[] plaintext) { throw null; }
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
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm CkmAesKeyWrap { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.KeyWrapAlgorithm CkmAesKeyWrapPad { get { throw null; } }
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
    public partial class LocalCryptographyClientOptions : Azure.Core.ClientOptions
    {
        public LocalCryptographyClientOptions() { }
    }
    public partial class RSAKeyVault : System.Security.Cryptography.RSA
    {
        internal RSAKeyVault() { }
        public override string KeyExchangeAlgorithm { get { throw null; } }
        public string KeyId { get { throw null; } }
        public override int KeySize { get { throw null; } set { } }
        public override System.Security.Cryptography.KeySizes[] LegalKeySizes { get { throw null; } }
        public override byte[] Decrypt(byte[] data, System.Security.Cryptography.RSAEncryptionPadding padding) { throw null; }
        protected override void Dispose(bool disposing) { }
        public override byte[] Encrypt(byte[] data, System.Security.Cryptography.RSAEncryptionPadding padding) { throw null; }
        public override System.Security.Cryptography.RSAParameters ExportParameters(bool includePrivateParameters) { throw null; }
        protected override byte[] HashData(byte[] data, int offset, int count, System.Security.Cryptography.HashAlgorithmName hashAlgorithm) { throw null; }
        protected override byte[] HashData(System.IO.Stream data, System.Security.Cryptography.HashAlgorithmName hashAlgorithm) { throw null; }
        public override void ImportParameters(System.Security.Cryptography.RSAParameters parameters) { }
        public override byte[] SignHash(byte[] hash, System.Security.Cryptography.HashAlgorithmName hashAlgorithm, System.Security.Cryptography.RSASignaturePadding padding) { throw null; }
        public override bool VerifyHash(byte[] hash, byte[] signature, System.Security.Cryptography.HashAlgorithmName hashAlgorithm, System.Security.Cryptography.RSASignaturePadding padding) { throw null; }
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
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm HS256 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm HS384 { get { throw null; } }
        public static Azure.Security.KeyVault.Keys.Cryptography.SignatureAlgorithm HS512 { get { throw null; } }
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
