namespace Azure.Security.CodeTransparency
{
    public partial class CodeTransparencyCertificateClient
    {
        protected CodeTransparencyCertificateClient() { }
        public CodeTransparencyCertificateClient(System.Uri certificateEndpoint) { }
        public CodeTransparencyCertificateClient(System.Uri certificateEndpoint, Azure.Security.CodeTransparency.CodeTransparencyClientOptions options) { }
        public virtual Azure.Response GetServiceIdentity(string ledgerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.ServiceIdentityResult> GetServiceIdentity(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServiceIdentityAsync(string ledgerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.ServiceIdentityResult>> GetServiceIdentityAsync(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeTransparencyClient
    {
        protected CodeTransparencyClient() { }
        public CodeTransparencyClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public CodeTransparencyClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Security.CodeTransparency.CodeTransparencyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.Security.CodeTransparency.GetOperationResult> CreateEntry(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Security.CodeTransparency.GetOperationResult>> CreateEntryAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCodeTransparencyConfig(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyConfiguration> GetCodeTransparencyConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCodeTransparencyConfigAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>> GetCodeTransparencyConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCodeTransparencyVersion(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.VersionResult> GetCodeTransparencyVersion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCodeTransparencyVersionAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.VersionResult>> GetCodeTransparencyVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDidConfig(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.DidDocument> GetDidConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDidConfigAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.DidDocument>> GetDidConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntry(string entryId, bool? embedReceipt, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntry(string entryId, bool? embedReceipt = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryAsync(string entryId, bool? embedReceipt, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryAsync(string entryId, bool? embedReceipt = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEntryIds(long? from, long? to, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetEntryIds(long? from = default(long?), long? to = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEntryIdsAsync(long? from, long? to, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetEntryIdsAsync(long? from = default(long?), long? to = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryReceipt(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntryReceipt(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryReceiptAsync(string entryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryReceiptAsync(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryStatus(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.GetOperationResult> GetEntryStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryStatusAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.GetOperationResult>> GetEntryStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryStatuses(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.ListOperationResult> GetEntryStatuses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryStatusesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.ListOperationResult>> GetEntryStatusesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetParameters(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.ParametersResult> GetParameters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetParametersAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.ParametersResult>> GetParametersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeTransparencyClientOptions : Azure.Core.ClientOptions
    {
        public CodeTransparencyClientOptions(Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion version = Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion.V2024_01_11_Preview) { }
        public double CacheTTLSeconds { get { throw null; } set { } }
        public string IdentityClientEndpoint { get { throw null; } set { } }
        public virtual Azure.Security.CodeTransparency.CodeTransparencyCertificateClient CreateCertificateClient() { throw null; }
        public enum ServiceVersion
        {
            V2024_01_11_Preview = 1,
        }
    }
    public partial class CodeTransparencyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>
    {
        internal CodeTransparencyConfiguration() { }
        public Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication Authentication { get { throw null; } }
        public Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy Policy { get { throw null; } }
        public string ServiceIdentifier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeTransparencyConfigurationAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>
    {
        internal CodeTransparencyConfigurationAuthentication() { }
        public bool AllowUnauthenticated { get { throw null; } }
        public Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt Jwt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeTransparencyConfigurationAuthenticationJwt : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>
    {
        internal CodeTransparencyConfigurationAuthenticationJwt() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RequiredClaims { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeTransparencyConfigurationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>
    {
        internal CodeTransparencyConfigurationPolicy() { }
        public System.Collections.Generic.IReadOnlyList<string> AcceptedAlgorithms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AcceptedDidIssuers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEntryResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CreateEntryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CreateEntryResult>
    {
        internal CreateEntryResult() { }
        public string OperationId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CreateEntryResult System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CreateEntryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.CreateEntryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.CreateEntryResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CreateEntryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CreateEntryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.CreateEntryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DidDocument : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocument>
    {
        internal DidDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.CodeTransparency.DidDocumentKey> AssertionMethod { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.DidDocument System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.DidDocument System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DidDocumentKey : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocumentKey>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocumentKey>
    {
        internal DidDocumentKey() { }
        public string Controller { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Security.CodeTransparency.JsonWebKey PublicKeyJwk { get { throw null; } }
        public Azure.Security.CodeTransparency.DidDocumentKeyType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.DidDocumentKey System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocumentKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.DidDocumentKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.DidDocumentKey System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocumentKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocumentKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.DidDocumentKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DidDocumentKeyType : System.IEquatable<Azure.Security.CodeTransparency.DidDocumentKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DidDocumentKeyType(string value) { throw null; }
        public static Azure.Security.CodeTransparency.DidDocumentKeyType JsonWebKey2020 { get { throw null; } }
        public bool Equals(Azure.Security.CodeTransparency.DidDocumentKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.CodeTransparency.DidDocumentKeyType left, Azure.Security.CodeTransparency.DidDocumentKeyType right) { throw null; }
        public static implicit operator Azure.Security.CodeTransparency.DidDocumentKeyType (string value) { throw null; }
        public static bool operator !=(Azure.Security.CodeTransparency.DidDocumentKeyType left, Azure.Security.CodeTransparency.DidDocumentKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.GetOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.GetOperationResult>
    {
        internal GetOperationResult() { }
        public string EntryId { get { throw null; } }
        public string Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Security.CodeTransparency.OperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.GetOperationResult System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.GetOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.GetOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.GetOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.GetOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.GetOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.GetOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsonWebKey : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JsonWebKey>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JsonWebKey>
    {
        internal JsonWebKey() { }
        public string Alg { get { throw null; } }
        public string Crv { get { throw null; } }
        public string D { get { throw null; } }
        public string Dp { get { throw null; } }
        public string Dq { get { throw null; } }
        public string E { get { throw null; } }
        public string K { get { throw null; } }
        public string Kid { get { throw null; } }
        public string Kty { get { throw null; } }
        public string N { get { throw null; } }
        public string P { get { throw null; } }
        public string Q { get { throw null; } }
        public string Qi { get { throw null; } }
        public string Use { get { throw null; } }
        public string X { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> X5c { get { throw null; } }
        public string Y { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.JsonWebKey System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JsonWebKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JsonWebKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.JsonWebKey System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JsonWebKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JsonWebKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JsonWebKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ListOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ListOperationResult>
    {
        internal ListOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.CodeTransparency.GetOperationResult> Operations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.ListOperationResult System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ListOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ListOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.ListOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ListOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ListOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ListOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Security.CodeTransparency.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Security.CodeTransparency.OperationStatus Failed { get { throw null; } }
        public static Azure.Security.CodeTransparency.OperationStatus Running { get { throw null; } }
        public static Azure.Security.CodeTransparency.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Security.CodeTransparency.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.CodeTransparency.OperationStatus left, Azure.Security.CodeTransparency.OperationStatus right) { throw null; }
        public static implicit operator Azure.Security.CodeTransparency.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Security.CodeTransparency.OperationStatus left, Azure.Security.CodeTransparency.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParametersResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ParametersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ParametersResult>
    {
        internal ParametersResult() { }
        public string ServiceCertificate { get { throw null; } }
        public string ServiceId { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public string TreeAlgorithm { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.ParametersResult System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ParametersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.ParametersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.ParametersResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ParametersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ParametersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.ParametersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SecurityCodeTransparencyModelFactory
    {
        public static Azure.Security.CodeTransparency.CodeTransparencyConfiguration CodeTransparencyConfiguration(Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy policy = null, Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication authentication = null, string serviceIdentifier = null) { throw null; }
        public static Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthentication CodeTransparencyConfigurationAuthentication(bool allowUnauthenticated = false, Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt jwt = null) { throw null; }
        public static Azure.Security.CodeTransparency.CodeTransparencyConfigurationAuthenticationJwt CodeTransparencyConfigurationAuthenticationJwt(System.Collections.Generic.IReadOnlyDictionary<string, string> requiredClaims = null) { throw null; }
        public static Azure.Security.CodeTransparency.CodeTransparencyConfigurationPolicy CodeTransparencyConfigurationPolicy(System.Collections.Generic.IEnumerable<string> acceptedAlgorithms = null, System.Collections.Generic.IEnumerable<string> acceptedDidIssuers = null) { throw null; }
        public static Azure.Security.CodeTransparency.CreateEntryResult CreateEntryResult(string operationId = null) { throw null; }
        public static Azure.Security.CodeTransparency.DidDocument DidDocument(string id = null, System.Collections.Generic.IEnumerable<Azure.Security.CodeTransparency.DidDocumentKey> assertionMethod = null) { throw null; }
        public static Azure.Security.CodeTransparency.DidDocumentKey DidDocumentKey(string id = null, string controller = null, Azure.Security.CodeTransparency.DidDocumentKeyType type = default(Azure.Security.CodeTransparency.DidDocumentKeyType), Azure.Security.CodeTransparency.JsonWebKey publicKeyJwk = null) { throw null; }
        public static Azure.Security.CodeTransparency.GetOperationResult GetOperationResult(string entryId = null, string error = null, string operationId = null, Azure.Security.CodeTransparency.OperationStatus status = default(Azure.Security.CodeTransparency.OperationStatus)) { throw null; }
        public static Azure.Security.CodeTransparency.JsonWebKey JsonWebKey(string alg = null, string crv = null, string d = null, string dp = null, string dq = null, string e = null, string k = null, string kid = null, string kty = null, string n = null, string p = null, string q = null, string qi = null, string use = null, string x = null, System.Collections.Generic.IEnumerable<string> x5c = null, string y = null) { throw null; }
        public static Azure.Security.CodeTransparency.ListOperationResult ListOperationResult(System.Collections.Generic.IEnumerable<Azure.Security.CodeTransparency.GetOperationResult> operations = null) { throw null; }
        public static Azure.Security.CodeTransparency.ParametersResult ParametersResult(string serviceCertificate = null, string serviceId = null, string signatureAlgorithm = null, string treeAlgorithm = null) { throw null; }
        public static Azure.Security.CodeTransparency.VersionResult VersionResult(string scittVersion = null) { throw null; }
    }
    public partial class ServiceIdentityResult
    {
        internal ServiceIdentityResult() { }
        public System.DateTime CreatedAt { get { throw null; } }
        public string TlsCertificatePem { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 GetCertificate() { throw null; }
    }
    public partial class VersionResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.VersionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.VersionResult>
    {
        internal VersionResult() { }
        public string ScittVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.VersionResult System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.VersionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.VersionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.VersionResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.VersionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.VersionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.VersionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Security.CodeTransparency.Receipt
{
    public partial class CcfReceipt
    {
        public const int COSE_HEADER_EMBEDDED_RECEIPTS = 394;
        public const ulong RECEIPT_HEADER_ISSUER = (ulong)391;
        public const ulong RECEIPT_HEADER_KEY_ID = (ulong)4;
        public const string RECEIPT_HEADER_REGISTRATION_TIME = "registration_time";
        public const string RECEIPT_HEADER_SERVICE_ID = "service_id";
        public const string RECEIPT_HEADER_TREE_ALGORITHM = "tree_alg";
        public const string SUPPORTED_TREE_ALGORITHM = "CCF";
        public CcfReceipt() { }
        public Azure.Security.CodeTransparency.Receipt.CcfReceipt.ReceiptContents Contents { get { throw null; } set { } }
        public byte[] SignProtectedRaw { get { throw null; } set { } }
        protected byte[] ComputeLeaf(System.Security.Cryptography.Cose.CoseSign1Message coseSign1Message) { throw null; }
        public static Azure.Security.CodeTransparency.Receipt.CcfReceipt Deserialize(byte[] cbor) { throw null; }
        public static Azure.Security.CodeTransparency.Receipt.CcfReceipt Deserialize(System.Formats.Cbor.CborReader reader) { throw null; }
        public static System.Collections.Generic.List<Azure.Security.CodeTransparency.Receipt.CcfReceipt> DeserializeMany(byte[] cbor) { throw null; }
        public Azure.Security.CodeTransparency.Receipt.CcfReceipt.SignProtected GetSignProtected() { throw null; }
        protected System.Security.Cryptography.X509Certificates.X509Certificate2 ParseAndVerifyNodeCert(System.Security.Cryptography.X509Certificates.X509Certificate2 serviceCert, Azure.Security.CodeTransparency.Receipt.CcfReceipt.SignProtected signProtected) { throw null; }
        protected byte[] RecomputeSignedRootHash(System.Security.Cryptography.Cose.CoseSign1Message coseSign1Message) { throw null; }
        public void VerifyReceipt(byte[] coseSign1Bytes, System.Security.Cryptography.X509Certificates.X509Certificate2 serviceCert) { }
        protected bool VerifySignature(byte[] signedRootHash, System.Security.Cryptography.X509Certificates.X509Certificate2 serviceCert, Azure.Security.CodeTransparency.Receipt.CcfReceipt.SignProtected signProtected) { throw null; }
        public partial class CounterSignStruct
        {
            public readonly byte[] ExternalAad;
            public CounterSignStruct() { }
            public byte[] BodyProtected { get { throw null; } set { } }
            public string Context { get { throw null; } set { } }
            public Azure.Security.CodeTransparency.Receipt.CcfReceipt.OtherCounterSignFields OtherFields { get { throw null; } set { } }
            public byte[] Payload { get { throw null; } set { } }
            public byte[] SignProtected { get { throw null; } set { } }
            public static Azure.Security.CodeTransparency.Receipt.CcfReceipt.CounterSignStruct Build(Azure.Security.CodeTransparency.Receipt.CcfReceipt receipt, System.Security.Cryptography.Cose.CoseSign1Message coseSign1Message) { throw null; }
            public byte[] Serialize() { throw null; }
        }
        public partial class LeafInfo
        {
            public LeafInfo() { }
            public byte[] InternalData { get { throw null; } set { } }
            public byte[] InternalHash { get { throw null; } set { } }
            public byte[] LeafBytes(byte[] dataHash) { throw null; }
        }
        public partial class OtherCounterSignFields
        {
            public OtherCounterSignFields() { }
            public byte[] Signature { get { throw null; } set { } }
        }
        public partial class ProofElement
        {
            public ProofElement() { }
            public byte[] Hash { get { throw null; } set { } }
            public bool? Left { get { throw null; } set { } }
        }
        public partial class ReceiptContents
        {
            public ReceiptContents() { }
            public Azure.Security.CodeTransparency.Receipt.CcfReceipt.LeafInfo LeafInfo { get { throw null; } set { } }
            public byte[] NodeCertificate { get { throw null; } set { } }
            public System.Collections.Generic.List<Azure.Security.CodeTransparency.Receipt.CcfReceipt.ProofElement> ProofElements { get { throw null; } set { } }
            public byte[] Signature { get { throw null; } set { } }
            public byte[] ComputeRootHash(byte[] leafHash) { throw null; }
        }
        public partial class SignProtected
        {
            public SignProtected() { }
            public string Issuer { get { throw null; } set { } }
            public string KeyId { get { throw null; } set { } }
            public string ServiceId { get { throw null; } set { } }
            public ulong SignedAt { get { throw null; } set { } }
            public string TreeAlg { get { throw null; } set { } }
            public static Azure.Security.CodeTransparency.Receipt.CcfReceipt.SignProtected Deserialize(byte[] signProtectedBytes) { throw null; }
        }
    }
    public partial class CcfReceiptVerifier
    {
        public CcfReceiptVerifier() { }
        public static void RunVerification(byte[] ccfReceiptOrCoseBytes, byte[] coseSign1Bytes = null, System.Func<Azure.Security.CodeTransparency.Receipt.DidWebReference, Azure.Security.CodeTransparency.DidDocument> didResolver = null) { }
        public static void RunVerification(System.Security.Cryptography.X509Certificates.X509Certificate2 serviceCertificate, byte[] ccfReceiptOrCoseBytes, byte[] coseSign1Bytes = null) { }
    }
    public partial class DidWebReference
    {
        public readonly System.Uri DidDocUrl;
        public readonly string KeyId;
        public DidWebReference(Azure.Security.CodeTransparency.Receipt.CcfReceipt receipt) { }
        public DidWebReference(System.Uri uri, string id) { }
        public static System.Func<Azure.Security.CodeTransparency.Receipt.DidWebReference, Azure.Security.CodeTransparency.DidDocument> defaultResolver(Azure.Security.CodeTransparency.CodeTransparencyClientOptions clientOptions = null) { throw null; }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 GetCert(System.Func<Azure.Security.CodeTransparency.Receipt.DidWebReference, Azure.Security.CodeTransparency.DidDocument> resolver = null) { throw null; }
        public static System.Security.Cryptography.X509Certificates.X509Certificate2 JwkToCert(Azure.Security.CodeTransparency.DidDocumentKey method) { throw null; }
        public static System.Security.Cryptography.X509Certificates.X509Certificate2 ParseCert(Azure.Security.CodeTransparency.DidDocument doc, string keyId) { throw null; }
        public static System.Uri ParseDidDocUrl(string issuer) { throw null; }
        public static System.Collections.Generic.List<Azure.Security.CodeTransparency.DidDocumentKey> SupportedAssertionMethods(Azure.Security.CodeTransparency.DidDocument doc) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class SecurityCodeTransparencyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.CodeTransparency.CodeTransparencyClient, Azure.Security.CodeTransparency.CodeTransparencyClientOptions> AddCodeTransparencyClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.CodeTransparency.CodeTransparencyClient, Azure.Security.CodeTransparency.CodeTransparencyClientOptions> AddCodeTransparencyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
