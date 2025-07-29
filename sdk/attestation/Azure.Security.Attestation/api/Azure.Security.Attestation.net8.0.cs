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
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.Attestation.AttestationClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestOpenEnclave(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestOpenEnclaveAsync(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestSgxEnclave(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestSgxEnclaveAsync(Azure.Security.Attestation.AttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.Attestation.TpmAttestationResponse> AttestTpm(Azure.Security.Attestation.TpmAttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.Attestation.TpmAttestationResponse>> AttestTpmAsync(Azure.Security.Attestation.TpmAttestationRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>> GetSigningCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>>> GetSigningCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AttestationResult
    {
        internal AttestationResult() { }
        public object Confirmation { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedEnclaveHeldData is deprecated, use EnclaveHeldData instead")]
        public System.BinaryData DeprecatedEnclaveHeldData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedEnclaveHeldData2 is deprecated, use EnclaveHeldData instead")]
        public System.BinaryData DeprecatedEnclaveHeldData2 { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedIsDebuggable is deprecated, use IsDebuggable instead")]
        public bool? DeprecatedIsDebuggable { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedMrEnclave is deprecated, use MrEnclave instead")]
        public string DeprecatedMrEnclave { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedMrSigner is deprecated, use MrSigner instead")]
        public string DeprecatedMrSigner { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedPolicyHash is deprecated, use PolicyHash instead")]
        public System.BinaryData DeprecatedPolicyHash { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedPolicySigner is deprecated, use PolicySigner instead")]
        public Azure.Security.Attestation.AttestationSigner DeprecatedPolicySigner { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedProductId is deprecated, use ProductId instead")]
        public float? DeprecatedProductId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedRpData is deprecated, use Nonce instead")]
        public string DeprecatedRpData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedSgxCollateral is deprecated, use SgxCollateral instead")]
        public object DeprecatedSgxCollateral { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedSvn is deprecated, use Svn instead")]
        public float? DeprecatedSvn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedTee is deprecated, use Tee instead")]
        public string DeprecatedTee { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DeprecatedVersion is deprecated, use Version instead")]
        public string DeprecatedVersion { get { throw null; } }
        public System.BinaryData EnclaveHeldData { get { throw null; } }
        public System.DateTimeOffset Expiration { get { throw null; } }
        public object InittimeClaims { get { throw null; } }
        public bool? IsDebuggable { get { throw null; } }
        public System.DateTimeOffset IssuedAt { get { throw null; } }
        public System.Uri Issuer { get { throw null; } }
        public string MrEnclave { get { throw null; } }
        public string MrSigner { get { throw null; } }
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
    }
    public partial class AttestationSigner
    {
        public AttestationSigner(System.Collections.Generic.IEnumerable<System.Security.Cryptography.X509Certificates.X509Certificate2> signingCertificates, string certificateKeyId) { }
        public string CertificateKeyId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Security.Cryptography.X509Certificates.X509Certificate2> SigningCertificates { get { throw null; } }
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
        public static Azure.Security.Attestation.AttestationType OpenEnclave { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType SgxEnclave { get { throw null; } }
        public static Azure.Security.Attestation.AttestationType Tpm { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.AttestationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.AttestationType left, Azure.Security.Attestation.AttestationType right) { throw null; }
        public static implicit operator Azure.Security.Attestation.AttestationType (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.AttestationType left, Azure.Security.Attestation.AttestationType right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.PolicyCertificateResolution left, Azure.Security.Attestation.PolicyCertificateResolution right) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyCertificateResolution (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.PolicyCertificateResolution left, Azure.Security.Attestation.PolicyCertificateResolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyCertificatesModificationResult
    {
        public PolicyCertificatesModificationResult() { }
        public Azure.Security.Attestation.PolicyCertificateResolution? CertificateResolution { get { throw null; } set { } }
        public string CertificateThumbprint { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.PolicyModification left, Azure.Security.Attestation.PolicyModification right) { throw null; }
        public static implicit operator Azure.Security.Attestation.PolicyModification (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.PolicyModification left, Azure.Security.Attestation.PolicyModification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyModificationResult
    {
        public PolicyModificationResult() { }
        public Azure.Security.Attestation.PolicyModification PolicyResolution { get { throw null; } }
        public Azure.Security.Attestation.AttestationSigner PolicySigner { get { throw null; } }
        public System.BinaryData PolicyTokenHash { get { throw null; } }
    }
    public partial class StoredAttestationPolicy
    {
        public StoredAttestationPolicy() { }
        public string AttestationPolicy { get { throw null; } set { } }
    }
    public partial class TpmAttestationRequest
    {
        public TpmAttestationRequest() { }
        public System.BinaryData Data { get { throw null; } set { } }
    }
    public partial class TpmAttestationResponse
    {
        internal TpmAttestationResponse() { }
        public System.BinaryData Data { get { throw null; } }
    }
}
