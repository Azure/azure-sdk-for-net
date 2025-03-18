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
        public virtual Azure.Operation<System.BinaryData> CreateEntry(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateEntryAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntry(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntry(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryAsync(string entryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryAsync(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryStatement(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntryStatement(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryStatementAsync(string entryId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryStatementAsync(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperation(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicKeys(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.JwksDocument> GetPublicKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicKeysAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.JwksDocument>> GetPublicKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTransparencyConfigCbor(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetTransparencyConfigCbor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransparencyConfigCborAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetTransparencyConfigCborAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void RunTransparentStatementVerification(byte[] transparentStatementCoseSign1Bytes, byte[] signedStatement) { }
    }
    public partial class CodeTransparencyClientOptions : Azure.Core.ClientOptions
    {
        public CodeTransparencyClientOptions(Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion version = Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion.V2025_01_31_Preview) { }
        public double CacheTTLSeconds { get { throw null; } set { } }
        public string IdentityClientEndpoint { get { throw null; } set { } }
        public virtual Azure.Security.CodeTransparency.CodeTransparencyCertificateClient CreateCertificateClient() { throw null; }
        public enum ServiceVersion
        {
            V2025_01_31_Preview = 1,
        }
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
    public partial class JwksDocument : System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JwksDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JwksDocument>
    {
        internal JwksDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.CodeTransparency.JsonWebKey> Keys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.JwksDocument System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JwksDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.CodeTransparency.JwksDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.CodeTransparency.JwksDocument System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JwksDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JwksDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.CodeTransparency.JwksDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OperationStatus
    {
        Running = 0,
        Failed = 1,
        Succeeded = 2,
    }
    public static partial class SecurityCodeTransparencyModelFactory
    {
        public static Azure.Security.CodeTransparency.JsonWebKey JsonWebKey(string alg = null, string crv = null, string d = null, string dp = null, string dq = null, string e = null, string k = null, string kid = null, string kty = null, string n = null, string p = null, string q = null, string qi = null, string use = null, string x = null, System.Collections.Generic.IEnumerable<string> x5c = null, string y = null) { throw null; }
        public static Azure.Security.CodeTransparency.JwksDocument JwksDocument(System.Collections.Generic.IEnumerable<Azure.Security.CodeTransparency.JsonWebKey> keys = null) { throw null; }
    }
    public partial class ServiceIdentityResult
    {
        internal ServiceIdentityResult() { }
        public System.DateTime CreatedAt { get { throw null; } }
        public string TlsCertificatePem { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 GetCertificate() { throw null; }
    }
}
namespace Azure.Security.CodeTransparency.Receipt
{
    public partial class CcfReceipt
    {
        public const int CCF_PROOF_LEAF_LABEL = 1;
        public const int CCF_PROOF_PATH_LABEL = 2;
        public const int CCF_TREE_ALG_LABEL = 2;
        public const int COSE_HEADER_EMBEDDED_RECEIPTS = 394;
        public const int COSE_PHDR_VDP_LABEL = 396;
        public const int COSE_PHDR_VDS_LABEL = 395;
        public const int COSE_RECEIPT_CWT_ISS_LABEL = 1;
        public const int COSE_RECEIPT_CWT_MAP_LABEL = 15;
        public const int COSE_RECEIPT_INCLUSION_PROOF_LABEL = -1;
        public const ulong RECEIPT_HEADER_ISSUER = (ulong)391;
        public const ulong RECEIPT_HEADER_KEY_ID = (ulong)4;
        public const string RECEIPT_HEADER_REGISTRATION_TIME = "registration_time";
        public const string RECEIPT_HEADER_SERVICE_ID = "service_id";
        public const string RECEIPT_HEADER_TREE_ALGORITHM = "tree_alg";
        public const string SUPPORTED_TREE_ALGORITHM = "CCF";
        public CcfReceipt() { }
        public partial class Leaf
        {
            public Leaf() { }
            public byte[] DataHash { get { throw null; } set { } }
            public string InternalEvidence { get { throw null; } set { } }
            public byte[] InternalTransactionHash { get { throw null; } set { } }
        }
        public partial class ProofElement
        {
            public ProofElement() { }
            public byte[] Hash { get { throw null; } set { } }
            public bool Left { get { throw null; } set { } }
        }
    }
    public partial class CcfReceiptVerifier
    {
        public CcfReceiptVerifier() { }
        public static void VerifyTransparentStatementReceipt(Azure.Security.CodeTransparency.JsonWebKey jsonWebKey, byte[] receiptBytes, byte[] signedStatementBytes) { }
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
