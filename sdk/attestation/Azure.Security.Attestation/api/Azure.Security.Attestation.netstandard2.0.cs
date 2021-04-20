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
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestOpenEnclave(Azure.Security.Attestation.AttestRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestOpenEnclaveAsync(Azure.Security.Attestation.AttestRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult> AttestSgxEnclave(Azure.Security.Attestation.AttestRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.AttestationResult>> AttestSgxEnclaveAsync(Azure.Security.Attestation.AttestRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> AttestTpm(System.BinaryData request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> AttestTpmAsync(System.BinaryData request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>> GetSigningCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner>>> GetSigningCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationClientOptions : Azure.Core.ClientOptions
    {
        public AttestationClientOptions(Azure.Security.Attestation.AttestationClientOptions.ServiceVersion version = Azure.Security.Attestation.AttestationClientOptions.ServiceVersion.V2020_10_01, Azure.Security.Attestation.TokenValidationOptions tokenOptions = null) { }
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
        public byte[] DeprecatedEnclaveHeldData { get { throw null; } }
        public byte[] DeprecatedEnclaveHeldData2 { get { throw null; } }
        public bool? DeprecatedIsDebuggable { get { throw null; } }
        public string DeprecatedMrEnclave { get { throw null; } }
        public string DeprecatedMrSigner { get { throw null; } }
        public byte[] DeprecatedPolicyHash { get { throw null; } }
        public float? DeprecatedProductId { get { throw null; } }
        public string DeprecatedRpData { get { throw null; } }
        public object DeprecatedSgxCollateral { get { throw null; } }
        public float? DeprecatedSvn { get { throw null; } }
        public string DeprecatedTee { get { throw null; } }
        public string DeprecatedVersion { get { throw null; } }
        public byte[] EnclaveHeldData { get { throw null; } }
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
        public byte[] PolicyHash { get { throw null; } }
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
        public AttestationSigner(System.Security.Cryptography.X509Certificates.X509Certificate2[] signingCertificates, string certificateKeyId) { }
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
        public string TokenBody { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenBodyBytes { get { throw null; } }
        public string TokenHeader { get { throw null; } }
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
        public virtual bool ValidateToken(Azure.Security.Attestation.TokenValidationOptions options, System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner> attestationSigningCertificates, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> ValidateTokenAsync(Azure.Security.Attestation.TokenValidationOptions options, System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.AttestationSigner> attestationSigningCertificates, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationTokenSigningKey
    {
        public AttestationTokenSigningKey(System.Security.Cryptography.AsymmetricAlgorithm signer, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public AttestationTokenSigningKey(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate) { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 Certificate { get { throw null; } }
        public System.Security.Cryptography.AsymmetricAlgorithm Signer { get { throw null; } }
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
    public partial class AttestRequest
    {
        public AttestRequest(System.BinaryData evidence = null, Azure.Security.Attestation.AttestationData initTimeData = null, Azure.Security.Attestation.AttestationData runTimeData = null, string draftPolicyForAttestation = null) { }
        public string DraftPolicyForAttestation { get { throw null; } set { } }
        public System.BinaryData Evidence { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationData InittimeData { get { throw null; } set { } }
        public Azure.Security.Attestation.AttestationData RuntimeData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateModification : System.IEquatable<Azure.Security.Attestation.CertificateModification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateModification(string value) { throw null; }
        public static Azure.Security.Attestation.CertificateModification IsAbsent { get { throw null; } }
        public static Azure.Security.Attestation.CertificateModification IsPresent { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.CertificateModification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.CertificateModification left, Azure.Security.Attestation.CertificateModification right) { throw null; }
        public static implicit operator Azure.Security.Attestation.CertificateModification (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.CertificateModification left, Azure.Security.Attestation.CertificateModification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyCertificatesModificationResult
    {
        internal PolicyCertificatesModificationResult() { }
        public Azure.Security.Attestation.CertificateModification? CertificateResolution { get { throw null; } }
        public string CertificateThumbprint { get { throw null; } }
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
        public byte[] PolicyTokenHash { get { throw null; } }
    }
    public partial class StoredAttestationPolicy
    {
        public StoredAttestationPolicy() { }
        public string AttestationPolicy { get { throw null; } set { } }
    }
    public partial class TokenValidationOptions
    {
        public TokenValidationOptions(bool validateToken = true, bool validateExpirationTime = true, bool validateNotBeforeTime = true, bool validateIssuer = false, string expectedIssuer = null, int timeValidationSlack = 0, System.Func<Azure.Security.Attestation.AttestationToken, Azure.Security.Attestation.AttestationSigner, bool> validationCallback = null) { }
        public string ExpectedIssuer { get { throw null; } set { } }
        public long TimeValidationSlack { get { throw null; } set { } }
        public bool ValidateExpirationTime { get { throw null; } set { } }
        public bool ValidateIssuer { get { throw null; } set { } }
        public bool ValidateNotBeforeTime { get { throw null; } set { } }
        public bool ValidateToken { get { throw null; } set { } }
        public System.Func<Azure.Security.Attestation.AttestationToken, Azure.Security.Attestation.AttestationSigner, bool> ValidationCallback { get { throw null; } set { } }
    }
}
