namespace Azure.Security.CodeTransparency
{
    public enum AuthorizedReceiptBehavior
    {
        VerifyAnyMatching = 0,
        VerifyAllMatching = 1,
        RequireAll = 2,
    }
    public partial class AzureSecurityCodeTransparencyContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        public AzureSecurityCodeTransparencyContext() { }
    }
    public partial class CcfReceipt
    {
        public static readonly int CcfProofLeafLabel;
        public static readonly int CcfProofPathLabel;
        public static readonly int CcfTreeAlgLabel;
        public static readonly int CoseHeaderEmbeddedReceipts;
        public static readonly int CosePhdrVdpLabel;
        public static readonly int CosePhdrVdsLabel;
        public static readonly int CoseReceiptCwtIssLabel;
        public static readonly int CoseReceiptCwtMapLabel;
        public static readonly int CoseReceiptInclusionProofLabel;
        public static readonly ulong ReceiptHeaderIssuer;
        public static readonly ulong ReceiptHeaderKeyId;
        public static readonly string ReceiptHeaderRegistrationTime;
        public static readonly string ReceiptHeaderServiceId;
        public static readonly string ReceiptHeaderTreeAlgorithm;
        public static readonly string SupportedTreeAlgorithm;
        public CcfReceipt() { }
        public static string GetRegistrationTransactionId(byte[] receiptCoseSign1Bytes) { throw null; }
    }
    public partial class CcfReceiptVerifier
    {
        public CcfReceiptVerifier() { }
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, Azure.Security.CodeTransparency.CodeTransparencyVerificationKey verificationKey) { }
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet verificationKeys) { }
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, string keyId, System.Security.Cryptography.ECDsa publicKey) { }
    }
    public static partial class CodeTransparencyCbor
    {
        public static string GetStringValueFromCborMapByKey(byte[] cborBytes, int key) { throw null; }
        public static string GetStringValueFromCborMapByKey(byte[] cborBytes, string key) { throw null; }
    }
    public partial class CodeTransparencyCertificateClient
    {
        protected CodeTransparencyCertificateClient() { }
        public CodeTransparencyCertificateClient(System.Uri endpoint) { }
        public CodeTransparencyCertificateClient(System.Uri endpoint, Azure.Security.CodeTransparency.CodeTransparencyClientOptions options) { }
        public virtual Azure.Response GetServiceIdentity(string ledgerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.ServiceIdentityResult> GetServiceIdentity(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServiceIdentityAsync(string ledgerId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.ServiceIdentityResult>> GetServiceIdentityAsync(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeTransparencyClient
    {
        public static readonly string UnknownIssuerPrefix;
        protected CodeTransparencyClient() { }
        public CodeTransparencyClient(Azure.Security.CodeTransparency.CodeTransparencyClientSettings settings) { }
        public CodeTransparencyClient(System.Uri endpoint) { }
        public CodeTransparencyClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public CodeTransparencyClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Security.CodeTransparency.CodeTransparencyClientOptions options) { }
        public CodeTransparencyClient(System.Uri endpoint, Azure.Security.CodeTransparency.CodeTransparencyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateEntry(Azure.Core.RequestContent content, bool? waitForCommit = default(bool?), Azure.RequestContext context = null) { throw null; }
        [System.ObsoleteAttribute("Use CreateEntry(BinaryData, bool, CancellationToken) instead.")]
        public virtual Azure.Security.CodeTransparency.CreateEntryOperation CreateEntry(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<System.BinaryData> CreateEntry(System.BinaryData body, bool? waitForCommit = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateEntryAsync(Azure.Core.RequestContent content, bool? waitForCommit = default(bool?), Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        [System.ObsoleteAttribute("Use CreateEntryAsync(BinaryData, bool, CancellationToken) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Security.CodeTransparency.CreateEntryOperation> CreateEntryAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> CreateEntryAsync(System.BinaryData body, bool? waitForCommit = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateEntryV09(Azure.Core.RequestContent content, bool? waitForCommit = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.NullableResponse<System.BinaryData> CreateEntryV09(System.BinaryData body, bool? waitForCommit = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateEntryV09Async(Azure.Core.RequestContent content, bool? waitForCommit = default(bool?), Azure.RequestContext context = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> CreateEntryV09Async(System.BinaryData body, bool? waitForCommit = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntry(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.NullableResponse<System.BinaryData> GetEntry(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryAsync(string entryId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> GetEntryAsync(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static string GetEntryIdFromLocation(Azure.Response response) { throw null; }
        public virtual Azure.Response GetEntryStatement(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntryStatement(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryStatementAsync(string entryId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryStatementAsync(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryStatementV09(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetEntryStatementV09(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryStatementV09Async(string entryId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetEntryStatementV09Async(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntryV09(string entryId, Azure.RequestContext context) { throw null; }
        public virtual Azure.NullableResponse<System.BinaryData> GetEntryV09(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntryV09Async(string entryId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> GetEntryV09Async(string entryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("GetOperation is deprecated as it was removed from the recent IETF SCITT draft.")]
        public virtual Azure.Response GetOperation(string operationId, Azure.RequestContext context) { throw null; }
        [System.ObsoleteAttribute("GetOperation is deprecated as it was removed from the recent IETF SCITT draft.")]
        public virtual Azure.NullableResponse<System.BinaryData> GetOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        [System.ObsoleteAttribute("GetOperationAsync is deprecated as it was removed from the recent IETF SCITT draft.")]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        [System.ObsoleteAttribute("GetOperationAsync is deprecated as it was removed from the recent IETF SCITT draft.")]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> GetOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperationV09(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.NullableResponse<System.BinaryData> GetOperationV09(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationV09Async(string operationId, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<System.BinaryData>> GetOperationV09Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicKeys(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet> GetPublicKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicKeysAsync(Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet>> GetPublicKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetScittKey(string kid, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKey> GetScittKey(string kid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScittKeyAsync(string kid, Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKey>> GetScittKeyAsync(string kid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetScittKeys(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet> GetScittKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScittKeysAsync(Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet>> GetScittKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTransparencyConfigCbor(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetTransparencyConfigCbor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransparencyConfigCborAsync(Azure.RequestContext context) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetTransparencyConfigCborAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("Use the static VerifyTransparentStatement method with options instead.")]
        public virtual void RunTransparentStatementVerification(byte[] transparentStatementCoseSign1Bytes) { }
        public virtual void RunTransparentStatementVerification(byte[] signedStatementCoseSign1Bytes, byte[] receiptCoseSign1Bytes) { }
        public static void VerifyTransparentStatement(byte[] transparentStatementCoseSign1Bytes, Azure.Security.CodeTransparency.CodeTransparencyVerificationOptions verificationOptions = null, Azure.Security.CodeTransparency.CodeTransparencyClientOptions clientOptions = null) { }
    }
    public static partial class CodeTransparencyClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddCodeTransparencyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddCodeTransparencyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Security.CodeTransparency.CodeTransparencyClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedCodeTransparencyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedCodeTransparencyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Security.CodeTransparency.CodeTransparencyClientSettings> configureSettings) { throw null; }
    }
    public partial class CodeTransparencyClientOptions : Azure.Core.ClientOptions
    {
        public CodeTransparencyClientOptions(Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion version = Azure.Security.CodeTransparency.CodeTransparencyClientOptions.ServiceVersion.V2026_03_26) { }
        public double CacheTTLSeconds { get { throw null; } set { } }
        public string IdentityClientEndpoint { get { throw null; } set { } }
        public virtual Azure.Security.CodeTransparency.CodeTransparencyCertificateClient CreateCertificateClient() { throw null; }
        public enum ServiceVersion
        {
            V2026_03_26 = 1,
        }
    }
    public partial class CodeTransparencyClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public CodeTransparencyClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Security.CodeTransparency.CodeTransparencyClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public enum CodeTransparencyKeyResolutionMode
    {
        TrustStoreThenNetwork = 0,
        TrustStoreOnly = 1,
    }
    public static partial class CodeTransparencyModelFactory
    {
        public static Azure.Security.CodeTransparency.ServiceIdentityResult ServiceIdentityResult(string ledgerTlsCertificate) { throw null; }
    }
    public enum CodeTransparencyOperationStatus
    {
        Running = 0,
        Failed = 1,
        Succeeded = 2,
    }
    public sealed partial class CodeTransparencyTrustStore
    {
        public CodeTransparencyTrustStore() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet> KeysByIssuer { get { throw null; } }
        public static Azure.Security.CodeTransparency.CodeTransparencyTrustStore FromBinaryData(System.BinaryData data) { throw null; }
        public bool RemoveKeys(string issuerDomain) { throw null; }
        public void SetKeys(string issuerDomain, Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet keys) { }
        public System.BinaryData ToBinaryData() { throw null; }
        public bool TryGetKeys(string issuerDomain, out Azure.Security.CodeTransparency.CodeTransparencyVerificationKeySet keys) { throw null; }
    }
    public sealed partial class CodeTransparencyVerificationKey
    {
        public CodeTransparencyVerificationKey(string keyId, System.Security.Cryptography.ECDsa publicKey) { }
        public string KeyId { get { throw null; } }
        public System.Security.Cryptography.ECDsa ToECDsa() { throw null; }
    }
    public sealed partial class CodeTransparencyVerificationKeySet
    {
        public CodeTransparencyVerificationKeySet(System.Collections.Generic.IEnumerable<Azure.Security.CodeTransparency.CodeTransparencyVerificationKey> keys) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.CodeTransparency.CodeTransparencyVerificationKey> Keys { get { throw null; } }
        public bool TryGetKey(string keyId, out Azure.Security.CodeTransparency.CodeTransparencyVerificationKey key) { throw null; }
    }
    public sealed partial class CodeTransparencyVerificationOptions
    {
        public CodeTransparencyVerificationOptions() { }
        public System.Collections.Generic.IList<string> AuthorizedDomains { get { throw null; } set { } }
        public Azure.Security.CodeTransparency.AuthorizedReceiptBehavior AuthorizedReceiptBehavior { get { throw null; } set { } }
        public Azure.Security.CodeTransparency.CodeTransparencyKeyResolutionMode KeyResolutionMode { get { throw null; } set { } }
        public Azure.Security.CodeTransparency.CodeTransparencyTrustStore TrustStore { get { throw null; } set { } }
        public Azure.Security.CodeTransparency.UnauthorizedReceiptBehavior UnauthorizedReceiptBehavior { get { throw null; } set { } }
    }
    public partial class CreateEntryOperation : Azure.Operation<System.BinaryData>
    {
        protected CreateEntryOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceIdentityResult
    {
        internal ServiceIdentityResult() { }
        public System.DateTime CreatedAt { get { throw null; } }
        public string TlsCertificatePem { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 GetCertificate() { throw null; }
    }
    public enum UnauthorizedReceiptBehavior
    {
        VerifyAll = 0,
        IgnoreAll = 1,
        FailIfPresent = 2,
    }
}
