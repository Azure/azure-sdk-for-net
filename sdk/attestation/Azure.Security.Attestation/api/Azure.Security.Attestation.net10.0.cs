namespace Azure.Security.Attestation
{
    public partial class AttestationAdministrationClient
    {
        protected AttestationAdministrationClient() { }
        public AttestationAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AttestationAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.Attestation.AttestationClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyCertificatesModificationResult> AddPolicyManagementCertificate(System.Security.Cryptography.X509Certificates.X509Certificate2 newSigningCertificate, Azure.Security.Attestation.AttestationTokenSigningKey existingSigningKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyCertificatesModificationResult>> AddPolicyManagementCertificateAsync(System.Security.Cryptography.X509Certificates.X509Certificate2 newSigningCertificate, Azure.Security.Attestation.AttestationTokenSigningKey existingSigningKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<string> GetPolicy(Azure.Security.Attestation.AttestationType attestationType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<string>> GetPolicyAsync(Azure.Security.Attestation.AttestationType attestationType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<System.Collections.Generic.IReadOnlyList<System.Security.Cryptography.X509Certificates.X509Certificate2>> GetPolicyManagementCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<System.Collections.Generic.IReadOnlyList<System.Security.Cryptography.X509Certificates.X509Certificate2>>> GetPolicyManagementCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyCertificatesModificationResult> RemovePolicyManagementCertificate(System.Security.Cryptography.X509Certificates.X509Certificate2 certificateToRemove, Azure.Security.Attestation.AttestationTokenSigningKey existingSigningKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyCertificatesModificationResult>> RemovePolicyManagementCertificateAsync(System.Security.Cryptography.X509Certificates.X509Certificate2 certificateToRemove, Azure.Security.Attestation.AttestationTokenSigningKey existingSigningKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyModificationResult> ResetPolicy(Azure.Security.Attestation.AttestationType attestationType, Azure.Security.Attestation.AttestationTokenSigningKey signingKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyModificationResult>> ResetPolicyAsync(Azure.Security.Attestation.AttestationType attestationType, Azure.Security.Attestation.AttestationTokenSigningKey signingKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyModificationResult> SetPolicy(Azure.Security.Attestation.AttestationType attestationType, string policyToSet, Azure.Security.Attestation.AttestationTokenSigningKey signingKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.PolicyModificationResult>> SetPolicyAsync(Azure.Security.Attestation.AttestationType attestationType, string policyToSet, Azure.Security.Attestation.AttestationTokenSigningKey signingKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationClient
    {
        protected AttestationClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public AttestationClient(Azure.Security.Attestation.AttestationClientSettings settings) { }
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.Attestation.AttestationClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestOpenEnclave(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestOpenEnclaveAsync(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestSgxEnclave(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestSgxEnclaveAsync(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.Attestation.TpmAttestationResponse> AttestTpm(Azure.Security.Attestation.TpmAttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.Attestation.TpmAttestationResponse>> AttestTpmAsync(Azure.Security.Attestation.TpmAttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationRestClient GetAttestationRestClient() { throw null; }
        public virtual Azure.Security.Attestation.MetadataConfigurationRestClient GetMetadataConfigurationRestClient() { throw null; }
        public virtual Azure.Security.Attestation.PolicyCertificatesRestClient GetPolicyCertificatesRestClient() { throw null; }
        public virtual Azure.Security.Attestation.PolicyRestClient GetPolicyRestClient() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>> GetSigningCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>>> GetSigningCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.SigningCertificatesRestClient GetSigningCertificatesRestClient() { throw null; }
        public virtual Azure.Security.Attestation.TcbBaselinesRestClient GetTcbBaselinesRestClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class AttestationClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddAttestationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddAttestationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Security.Attestation.AttestationClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedAttestationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedAttestationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Security.Attestation.AttestationClientSettings> configureSettings) { throw null; }
    }
    public partial class AttestationClientOptions : Azure.Core.ClientOptions
    {
        public AttestationClientOptions(Azure.Security.Attestation.AttestationClientOptions.ServiceVersion version = Azure.Security.Attestation.AttestationClientOptions.ServiceVersion.V2020_10_01, Azure.Security.Attestation.AttestationTokenValidationOptions tokenOptions = null) { }
        public Azure.Security.Attestation.AttestationTokenValidationOptions TokenOptions { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_10_01 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AttestationClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AttestationClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class AttestationData
    {
        public AttestationData(System.BinaryData data, bool dataIsJson) { }
        public System.BinaryData BinaryData { get { throw null; } }
        public bool DataIsJson { get { throw null; } }
    }
    public static partial class AttestationModelFactory
    {
        public static Azure.Security.Attestation.AttestationResponse<T> AttestationResponse<T>(Azure.Response response, Azure.Security.Attestation.AttestationToken token, T body = null) where T : class { throw null; }
        public static Azure.Security.Attestation.AttestationResult AttestationResult(string jti = null, string issuer = null, System.DateTimeOffset issuedAt = default(System.DateTimeOffset), System.DateTimeOffset expiration = default(System.DateTimeOffset), System.DateTimeOffset notBefore = default(System.DateTimeOffset), object cnf = null, string nonce = null, string version = null, object runtimeClaims = null, object inittimeClaims = null, object policyClaims = null, string verifierType = null, Azure.Security.Attestation.AttestationSigner policySigner = null, System.BinaryData policyHash = null, bool? isDebuggable = default(bool?), float? productId = default(float?), string mrEnclave = null, string mrSigner = null, float? svn = default(float?), System.BinaryData enclaveHeldData = null, object sgxCollateral = null, string deprecatedVersion = null, bool? deprecatedIsDebuggable = default(bool?), object deprecatedSgxCollateral = null, System.BinaryData deprecatedEnclaveHeldData = null, System.BinaryData deprecatedEnclaveHeldData2 = null, float? deprecatedProductId = default(float?), string deprecatedMrEnclave = null, string deprecatedMrSigner = null, float? deprecatedSvn = default(float?), string deprecatedTee = null, Azure.Security.Attestation.AttestationSigner deprecatedPolicySigner = null, System.BinaryData deprecatedPolicyHash = null, string deprecatedRpData = null) { throw null; }
        public static Azure.Security.Attestation.PolicyCertificatesModificationResult PolicyCertificatesModificationResult(Azure.Security.Attestation.PolicyCertificateResolution certificateResolution, string certificateThumbprint) { throw null; }
        public static Azure.Security.Attestation.PolicyModificationResult PolicyModificationResult(Azure.Security.Attestation.PolicyModification policyModification, string policyHash, Azure.Security.Attestation.AttestationSigner signer) { throw null; }
        public static Azure.Security.Attestation.StoredAttestationPolicy StoredAttestationPolicy(string attestationPolicy = null) { throw null; }
        public static Azure.Security.Attestation.TpmAttestationRequest TpmAttestationRequest(System.BinaryData data = null) { throw null; }
        public static Azure.Security.Attestation.TpmAttestationResponse TpmAttestationResponse(System.BinaryData data = null) { throw null; }
    }
    public partial class AttestationRequest
    {
        public AttestationRequest() { }
        public string DraftPolicyForAttestation { get { throw null; } set { } }
        public System.BinaryData Evidence { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationData InittimeData { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationData RuntimeData { get { throw null; } set { } }
    }
    public partial class AttestationResponse<T> : Azure.Response<T> where T : class
    {
        internal AttestationResponse() { }
        public Azure.Security.Attestation.AttestationToken Token { get { throw null; } }
        public override T Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
    }
    public partial class AttestationRestClient
    {
        protected AttestationRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class AttestationResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationResult>
    {
        internal AttestationResult() { }
        public object Confirmation { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedEnclaveHeldData is deprecated, use EnclaveHeldData instead")]
        public System.BinaryData DeprecatedEnclaveHeldData { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedEnclaveHeldData2 is deprecated, use EnclaveHeldData instead")]
        public System.BinaryData DeprecatedEnclaveHeldData2 { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedIsDebuggable is deprecated, use IsDebuggable instead")]
        public bool? DeprecatedIsDebuggable { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedMrEnclave is deprecated, use MrEnclave instead")]
        public string DeprecatedMrEnclave { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedMrSigner is deprecated, use MrSigner instead")]
        public string DeprecatedMrSigner { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedPolicyHash is deprecated, use PolicyHash instead")]
        public System.BinaryData DeprecatedPolicyHash { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedPolicySigner is deprecated, use PolicySigner instead")]
        public Azure.Security.Attestation.AttestationSigner DeprecatedPolicySigner { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedProductId is deprecated, use ProductId instead")]
        public float? DeprecatedProductId { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedRpData is deprecated, use Nonce instead")]
        public string DeprecatedRpData { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedSgxCollateral is deprecated, use SgxCollateral instead")]
        public object DeprecatedSgxCollateral { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedSvn is deprecated, use Svn instead")]
        public float? DeprecatedSvn { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedTee is deprecated, use Tee instead")]
        public string DeprecatedTee { get { throw null; } }
        [System.ObsoleteAttribute("DeprecatedVersion is deprecated, use Version instead")]
        public string DeprecatedVersion { get { throw null; } }
        public System.BinaryData EnclaveHeldData { get { throw null; } }
        public long? Exp { get { throw null; } }
        public System.DateTimeOffset Expiration { get { throw null; } }
        public long? Iat { get { throw null; } }
        public object InittimeClaims { get { throw null; } }
        public bool? IsDebuggable { get { throw null; } }
        public string Iss { get { throw null; } }
        public System.DateTimeOffset IssuedAt { get { throw null; } }
        public System.Uri Issuer { get { throw null; } }
        public string Jti { get { throw null; } }
        public string MrEnclave { get { throw null; } }
        public string MrSigner { get { throw null; } }
        public long? Nbf { get { throw null; } }
        public string Nonce { get { throw null; } }
        public System.DateTimeOffset NotBefore { get { throw null; } }
        public object PolicyClaims { get { throw null; } }
        public System.BinaryData PolicyHash { get { throw null; } }
        public Azure.Security.Attestation.AttestationSigner PolicySigner { get { throw null; } }
        public float? ProductId { get { throw null; } }
        public object RuntimeClaims { get { throw null; } }
        public object SgxCollateral { get { throw null; } }
        public float? Svn { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public string VerifierType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.Security.Attestation.AttestationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.Attestation.AttestationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.AttestationResult System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.AttestationResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationSigner : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationSigner>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationSigner>
    {
        public AttestationSigner(System.Collections.Generic.IEnumerable<System.Security.Cryptography.X509Certificates.X509Certificate2> signingCertificates, string certificateKeyId) { }
        public string CertificateKeyId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Security.Cryptography.X509Certificates.X509Certificate2> SigningCertificates { get { throw null; } }
        Azure.Security.Attestation.AttestationSigner System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationSigner>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.AttestationSigner>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.AttestationSigner System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationSigner>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationSigner>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.AttestationSigner>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationToken
    {
        protected AttestationToken() { }
        public AttestationToken(Azure.Security.Attestation.AttestationTokenSigningKey signingKey) { }
        public AttestationToken(System.BinaryData body) { }
        public AttestationToken(System.BinaryData body, Azure.Security.Attestation.AttestationTokenSigningKey signingKey) { }
        public string Algorithm { get { throw null; } }
        public string CertificateThumbprint { get { throw null; } }
        public string ContentType { get { throw null; } }
        public bool? Critical { get { throw null; } }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } }
        public System.DateTimeOffset? IssuedAtTime { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string KeyId { get { throw null; } }
        public System.Uri KeyUrl { get { throw null; } }
        public System.DateTimeOffset? NotBeforeTime { get { throw null; } }
        public Azure.Security.Attestation.AttestationSigner SigningCertificate { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenBodyBytes { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenHeaderBytes { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenSignatureBytes { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Certificate2[] X509CertificateChain { get { throw null; } }
        public string X509CertificateSha256Thumbprint { get { throw null; } }
        public string X509CertificateThumbprint { get { throw null; } }
        public System.Uri X509Url { get { throw null; } }
        public static Azure.Security.Attestation.AttestationToken Deserialize(string token) { throw null; }
        public virtual T GetBody<T>() where T : class { throw null; }
        public string Serialize() { throw null; }
        public virtual bool ValidateToken(Azure.Security.Attestation.AttestationTokenValidationOptions options, System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner> attestationSigningCertificates, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> ValidateTokenAsync(Azure.Security.Attestation.AttestationTokenValidationOptions options, System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner> attestationSigningCertificates, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationTokenSigningKey
    {
        public AttestationTokenSigningKey(System.Security.Cryptography.AsymmetricAlgorithm signer, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public AttestationTokenSigningKey(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 Certificate { get { throw null; } }
        public System.Security.Cryptography.AsymmetricAlgorithm Signer { get { throw null; } }
    }
    public partial class AttestationTokenValidationEventArgs : Azure.SyncAsyncEventArgs
    {
        internal AttestationTokenValidationEventArgs() : base (default(bool), default(System.Threading.CancellationToken)) { }
        public bool IsValid { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationSigner Signer { get { throw null; } }
        public Azure.Security.Attestation.AttestationToken Token { get { throw null; } }
    }
    public partial class AttestationTokenValidationFailedException : System.InvalidOperationException
    {
        public AttestationTokenValidationFailedException(string message) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner> Signers { get { throw null; } }
        public Azure.Security.Attestation.AttestationToken Token { get { throw null; } }
    }
    public partial class AttestationTokenValidationOptions
    {
        public AttestationTokenValidationOptions() { }
        public string ExpectedIssuer { get { throw null; } set { } }
        public long TimeValidationSlack { get { throw null; } set { } }
        public bool ValidateExpirationTime { get { throw null; } set { } }
        public bool ValidateIssuer { get { throw null; } set { } }
        public bool ValidateNotBeforeTime { get { throw null; } set { } }
        public bool ValidateToken { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Security.Attestation.AttestationTokenValidationEventArgs> TokenValidated { add { } remove { } }
        public Azure.Security.Attestation.AttestationTokenValidationOptions Clone() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationType : System.IEquatable<Azure.Security.Attestation.AttestationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationType(string value) { throw null; }
        public static Azure.Security.Attestation.AttestationType AzureGuest { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType OpenEnclave { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType SevSnpVm { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType SgxEnclave { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType TdxVm { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType Tpm { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.AttestationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.AttestationType left, Azure.Security.Attestation.AttestationType right) { throw null; }
        public static implicit operator Azure.Security.Attestation.AttestationType (string value) { throw null; }
        public static implicit operator Azure.Security.Attestation.AttestationType? (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.AttestationType left, Azure.Security.Attestation.AttestationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSecurityAttestationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureSecurityAttestationContext() { }
        public static Azure.Security.Attestation.AzureSecurityAttestationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MetadataConfigurationRestClient
    {
        protected MetadataConfigurationRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyCertificateResolution : System.IEquatable<Azure.Security.Attestation.PolicyCertificateResolution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyCertificateResolution(string value) { throw null; }
        public static Azure.Security.Attestation.PolicyCertificateResolution IsAbsent { get { throw null; } }
        public static Azure.Security.Attestation.PolicyCertificateResolution IsPresent { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.PolicyCertificateResolution other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.PolicyCertificateResolution left, Azure.Security.Attestation.PolicyCertificateResolution right) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyCertificateResolution (string value) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyCertificateResolution? (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.PolicyCertificateResolution left, Azure.Security.Attestation.PolicyCertificateResolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyCertificatesModificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>
    {
        public PolicyCertificatesModificationResult() { }
        public Azure.Security.Attestation.PolicyCertificateResolution? CertificateResolution { get { throw null; } set { } }
        public string CertificateThumbprint { get { throw null; } set { } }
        protected virtual Azure.Security.Attestation.PolicyCertificatesModificationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.Attestation.PolicyCertificatesModificationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.PolicyCertificatesModificationResult System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.PolicyCertificatesModificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyCertificatesModificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyCertificatesRestClient
    {
        protected PolicyCertificatesRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyModification : System.IEquatable<Azure.Security.Attestation.PolicyModification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyModification(string value) { throw null; }
        public static Azure.Security.Attestation.PolicyModification Removed { get { throw null; } }
        public static Azure.Security.Attestation.PolicyModification Updated { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.PolicyModification other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.PolicyModification left, Azure.Security.Attestation.PolicyModification right) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyModification (string value) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyModification? (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.PolicyModification left, Azure.Security.Attestation.PolicyModification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyModificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyModificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyModificationResult>
    {
        public PolicyModificationResult() { }
        public Azure.Security.Attestation.PolicyModification PolicyResolution { get { throw null; } }
        public Azure.Security.Attestation.AttestationSigner PolicySigner { get { throw null; } }
        public System.BinaryData PolicyTokenHash { get { throw null; } }
        protected virtual Azure.Security.Attestation.PolicyModificationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.Attestation.PolicyModificationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.PolicyModificationResult System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyModificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.PolicyModificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.PolicyModificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyModificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyModificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.PolicyModificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyRestClient
    {
        protected PolicyRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class SigningCertificatesRestClient
    {
        protected SigningCertificatesRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class StoredAttestationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.StoredAttestationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.StoredAttestationPolicy>
    {
        public StoredAttestationPolicy() { }
        public string AttestationPolicy { get { throw null; } set { } }
        protected virtual Azure.Security.Attestation.StoredAttestationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.Attestation.StoredAttestationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.StoredAttestationPolicy System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.StoredAttestationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.StoredAttestationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.StoredAttestationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.StoredAttestationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.StoredAttestationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.StoredAttestationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TcbBaselinesRestClient
    {
        protected TcbBaselinesRestClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class TpmAttestationRequest : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationRequest>
    {
        public TpmAttestationRequest() { }
        public System.BinaryData Data { get { throw null; } set { } }
        protected virtual Azure.Security.Attestation.TpmAttestationRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.Attestation.TpmAttestationRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.TpmAttestationRequest System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.TpmAttestationRequest System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TpmAttestationResponse : System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationResponse>
    {
        internal TpmAttestationResponse() { }
        public System.BinaryData Data { get { throw null; } }
        protected virtual Azure.Security.Attestation.TpmAttestationResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.Attestation.TpmAttestationResponse (Azure.Response response) { throw null; }
        protected virtual Azure.Security.Attestation.TpmAttestationResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.Attestation.TpmAttestationResponse System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.Attestation.TpmAttestationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.Attestation.TpmAttestationResponse System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.Attestation.TpmAttestationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
