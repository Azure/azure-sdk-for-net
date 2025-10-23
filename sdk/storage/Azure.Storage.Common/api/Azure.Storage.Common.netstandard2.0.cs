namespace Azure.Storage
{
    public partial class ClientSideEncryptionOptions
    {
        public ClientSideEncryptionOptions(Azure.Storage.ClientSideEncryptionVersion version) { }
        public Azure.Storage.ClientSideEncryptionVersion EncryptionVersion { get { throw null; } }
        public Azure.Core.Cryptography.IKeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.Core.Cryptography.IKeyEncryptionKeyResolver KeyResolver { get { throw null; } set { } }
        public string KeyWrapAlgorithm { get { throw null; } set { } }
    }
    public enum ClientSideEncryptionVersion
    {
        [System.ObsoleteAttribute("This version is considered insecure. Applications are encouraged to migrate to version 2.0 or to one of Azure Storage's server-side encryption solutions. See http://aka.ms/azstorageclientencryptionblog for more details.")]
        V1_0 = 1,
        V2_0 = 2,
    }
    public partial class DownloadTransferValidationOptions
    {
        public DownloadTransferValidationOptions() { }
        public bool AutoValidateChecksum { get { throw null; } set { } }
        public Azure.Storage.StorageChecksumAlgorithm ChecksumAlgorithm { get { throw null; } set { } }
    }
    public enum Request100ContinueMode
    {
        Auto = 0,
        Always = 1,
        Never = 2,
    }
    public partial class Request100ContinueOptions
    {
        public Request100ContinueOptions() { }
        public System.TimeSpan AutoInterval { get { throw null; } set { } }
        public long? ContentLengthThreshold { get { throw null; } set { } }
        public Azure.Storage.Request100ContinueMode Mode { get { throw null; } set { } }
    }
    public enum StorageChecksumAlgorithm
    {
        Auto = 0,
        None = 1,
        MD5 = 2,
        StorageCrc64 = 3,
    }
    public partial class StorageCrc64HashAlgorithm : System.IO.Hashing.NonCryptographicHashAlgorithm
    {
        internal StorageCrc64HashAlgorithm() : base (default(int)) { }
        public override void Append(System.ReadOnlySpan<byte> source) { }
        public static Azure.Storage.StorageCrc64HashAlgorithm Create() { throw null; }
        protected override void GetCurrentHashCore(System.Span<byte> destination) { }
        public override void Reset() { }
    }
    public static partial class StorageExtensions
    {
        public static System.IDisposable CreateServiceTimeoutScope(System.TimeSpan? timeout) { throw null; }
    }
    public partial class StorageSharedKeyCredential
    {
        public StorageSharedKeyCredential(string accountName, string accountKey) { }
        public string AccountName { get { throw null; } }
        protected static string ComputeSasSignature(Azure.Storage.StorageSharedKeyCredential credential, string message) { throw null; }
        public void SetAccountKey(string accountKey) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct StorageTransferOptions : System.IEquatable<Azure.Storage.StorageTransferOptions>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? InitialTransferLength { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? MaximumTransferLength { get { throw null; } set { } }
        public long? MaximumTransferSize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.StorageTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.StorageTransferOptions left, Azure.Storage.StorageTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.StorageTransferOptions left, Azure.Storage.StorageTransferOptions right) { throw null; }
    }
    public partial class TransferValidationOptions
    {
        public TransferValidationOptions() { }
        public Azure.Storage.DownloadTransferValidationOptions Download { get { throw null; } }
        public Azure.Storage.UploadTransferValidationOptions Upload { get { throw null; } }
    }
    public partial class UploadTransferValidationOptions
    {
        public UploadTransferValidationOptions() { }
        public Azure.Storage.StorageChecksumAlgorithm ChecksumAlgorithm { get { throw null; } set { } }
        public System.ReadOnlyMemory<byte> PrecalculatedChecksum { get { throw null; } set { } }
    }
}
namespace Azure.Storage.Sas
{
    public partial class AccountSasBuilder
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public AccountSasBuilder() { }
        public AccountSasBuilder(Azure.Storage.Sas.AccountSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Sas.AccountSasServices services, Azure.Storage.Sas.AccountSasResourceTypes resourceTypes) { }
        public string EncryptionScope { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { get { throw null; } set { } }
        public Azure.Storage.Sas.AccountSasResourceTypes ResourceTypes { get { throw null; } set { } }
        public Azure.Storage.Sas.AccountSasServices Services { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Version { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.AccountSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential, out string stringToSign) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum AccountSasPermissions
    {
        All = -1,
        Read = 1,
        Write = 2,
        Delete = 4,
        List = 8,
        Add = 16,
        Create = 32,
        Update = 64,
        Process = 128,
        Tag = 256,
        Filter = 512,
        DeleteVersion = 1024,
        SetImmutabilityPolicy = 2048,
        PermanentDelete = 4096,
    }
    [System.FlagsAttribute]
    public enum AccountSasResourceTypes
    {
        All = -1,
        Service = 1,
        Container = 2,
        Object = 4,
    }
    [System.FlagsAttribute]
    public enum AccountSasServices
    {
        All = -1,
        Blobs = 1,
        Queues = 2,
        Files = 4,
        Tables = 8,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SasIPRange : System.IEquatable<Azure.Storage.Sas.SasIPRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SasIPRange(System.Net.IPAddress start, System.Net.IPAddress end = null) { throw null; }
        public System.Net.IPAddress End { get { throw null; } }
        public System.Net.IPAddress Start { get { throw null; } }
        public bool Equals(Azure.Storage.Sas.SasIPRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Sas.SasIPRange left, Azure.Storage.Sas.SasIPRange right) { throw null; }
        public static bool operator !=(Azure.Storage.Sas.SasIPRange left, Azure.Storage.Sas.SasIPRange right) { throw null; }
        public static Azure.Storage.Sas.SasIPRange Parse(string s) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SasProtocol
    {
        None = 0,
        HttpsAndHttp = 1,
        Https = 2,
    }
    public partial class SasQueryParameters
    {
        public const string DefaultSasVersion = "2026-04-06";
        protected SasQueryParameters() { }
        protected SasQueryParameters(System.Collections.Generic.IDictionary<string, string> values) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected SasQueryParameters(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected SasQueryParameters(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected SasQueryParameters(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?), string encryptionScope = null) { }
        protected SasQueryParameters(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?), string encryptionScope = null, string delegatedUserObjectId = null) { }
        public string AgentObjectId { get { throw null; } }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public string ContentEncoding { get { throw null; } }
        public string ContentLanguage { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string DelegatedUserObjectId { get { throw null; } }
        public int? DirectoryDepth { get { throw null; } }
        public static Azure.Storage.Sas.SasQueryParameters Empty { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Identifier { get { throw null; } }
        public Azure.Storage.Sas.SasIPRange IPRange { get { throw null; } }
        public string Permissions { get { throw null; } }
        public string PreauthorizedAgentObjectId { get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { get { throw null; } }
        public string Resource { get { throw null; } }
        public Azure.Storage.Sas.AccountSasResourceTypes? ResourceTypes { get { throw null; } }
        public Azure.Storage.Sas.AccountSasServices? Services { get { throw null; } }
        public string Signature { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public string Version { get { throw null; } }
        protected internal void AppendProperties(System.Text.StringBuilder stringBuilder) { }
        protected static Azure.Storage.Sas.SasQueryParameters Create(System.Collections.Generic.IDictionary<string, string> values) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected static Azure.Storage.Sas.SasQueryParameters Create(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected static Azure.Storage.Sas.SasQueryParameters Create(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected static Azure.Storage.Sas.SasQueryParameters Create(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?), string encryptionScope = null) { throw null; }
        protected static Azure.Storage.Sas.SasQueryParameters Create(string version, Azure.Storage.Sas.AccountSasServices? services, Azure.Storage.Sas.AccountSasResourceTypes? resourceTypes, Azure.Storage.Sas.SasProtocol protocol, System.DateTimeOffset startsOn, System.DateTimeOffset expiresOn, Azure.Storage.Sas.SasIPRange ipRange, string identifier, string resource, string permissions, string signature, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null, string authorizedAadObjectId = null, string unauthorizedAadObjectId = null, string correlationId = null, int? directoryDepth = default(int?), string encryptionScope = null, string delegatedUserObjectId = null) { throw null; }
        public override string ToString() { throw null; }
    }
}
