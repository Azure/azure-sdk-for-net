namespace Azure.Security.Attestation
{
    public partial class AttestationAdministrationClient
    {
        protected AttestationAdministrationClient() { }
        public AttestationAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AttestationAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.Attestation.AttestationClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesModificationResult> AddPolicyManagementCertificate(Azure.Security.Attestation.SecuredAttestationToken certificateToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesModificationResult>> AddPolicyManagementCertificateAsync(Azure.Security.Attestation.SecuredAttestationToken certificateToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.StoredAttestationPolicy> GetPolicy(Azure.Security.Attestation.Models.AttestationType attestationType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.StoredAttestationPolicy>> GetPolicyAsync(Azure.Security.Attestation.Models.AttestationType attestationType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesResult> GetPolicyManagementCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesResult>> GetPolicyManagementCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesModificationResult> RemovePolicyManagementCertificate(Azure.Security.Attestation.SecuredAttestationToken certificateToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyCertificatesModificationResult>> RemovePolicyManagementCertificateAsync(Azure.Security.Attestation.SecuredAttestationToken certificateToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyResult> ResetPolicy(Azure.Security.Attestation.Models.AttestationType attestationType, Azure.Security.Attestation.AttestationToken authorizationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyResult>> ResetPolicyAsync(Azure.Security.Attestation.Models.AttestationType attestationType, Azure.Security.Attestation.AttestationToken authorizationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyResult> SetPolicy(Azure.Security.Attestation.Models.AttestationType attestationType, Azure.Security.Attestation.AttestationToken policyToSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.PolicyResult>> SetPolicyAsync(Azure.Security.Attestation.Models.AttestationType attestationType, Azure.Security.Attestation.AttestationToken policyToSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationClient
    {
        protected AttestationClient() { }
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AttestationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.Attestation.AttestationClientOptions options) { }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.AttestationResult> AttestOpenEnclave(System.ReadOnlyMemory<byte> report, System.BinaryData initTimeData, bool initTimeDataIsObject, System.BinaryData runTimeData, bool runTimeDataIsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.AttestationResult>> AttestOpenEnclaveAsync(System.ReadOnlyMemory<byte> report, System.BinaryData initTimeData, bool initTimeDataIsObject, System.BinaryData runTimeData, bool runTimeDataIsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.AttestationResult> AttestSgxEnclave(System.ReadOnlyMemory<byte> quote, System.BinaryData initTimeData, bool initTimeDataIsObject, System.BinaryData runTimeData, bool runTimeDataIsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.Attestation.AttestationResponse<Azure.Security.Attestation.Models.AttestationResult>> AttestSgxEnclaveAsync(System.ReadOnlyMemory<byte> quote, System.BinaryData initTimeData, bool initTimeDataIsObject, System.BinaryData runTimeData, bool runTimeDataIsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> AttestTpm(System.BinaryData request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> AttestTpmAsync(System.BinaryData request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.Models.AttestationSigner>> GetSigningCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.Models.AttestationSigner>>> GetSigningCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationClientOptions : Azure.Core.ClientOptions
    {
        public AttestationClientOptions(Azure.Security.Attestation.AttestationClientOptions.ServiceVersion version = Azure.Security.Attestation.AttestationClientOptions.ServiceVersion.V2020_10_01, System.Func<Azure.Security.Attestation.AttestationToken, Azure.Security.Attestation.Models.AttestationSigner, bool> validationCallback = null, bool validateAttestationTokens = true) { }
        public System.Func<Azure.Security.Attestation.AttestationToken, Azure.Security.Attestation.Models.AttestationSigner, bool> ValidationCallback { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_10_01 = 1,
        }
    }
    public partial class AttestationResponse<T> : Azure.Response<T> where T : class
    {
        internal AttestationResponse() { }
        public Azure.Security.Attestation.AttestationToken Token { get { throw null; } }
        public override T Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
    }
    public partial class AttestationToken
    {
        protected AttestationToken() { }
        public string CertificateThumbprint { get { throw null; } }
        public System.DateTimeOffset ExpirationTime { get { throw null; } }
        public System.DateTimeOffset IssuedAtTime { get { throw null; } }
        public System.DateTimeOffset NotBeforeTime { get { throw null; } }
        public string TokenBody { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenBodyBytes { get { throw null; } }
        public string TokenHeader { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenHeaderBytes { get { throw null; } }
        public System.ReadOnlyMemory<byte> TokenSignatureBytes { get { throw null; } }
        public T GetBody<T>() where T : class { throw null; }
        public override string ToString() { throw null; }
        public virtual bool ValidateToken(System.Collections.Generic.IReadOnlyList<Azure.Security.Attestation.Models.AttestationSigner> attestationSigningCertificates, System.Func<Azure.Security.Attestation.AttestationToken, Azure.Security.Attestation.Models.AttestationSigner, bool> validationCallback = null) { throw null; }
    }
    public partial class SecuredAttestationToken : Azure.Security.Attestation.AttestationToken
    {
        public SecuredAttestationToken(object body, System.Security.Cryptography.AsymmetricAlgorithm signingKey, System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate) { }
        public SecuredAttestationToken(object body, System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate) { }
        public SecuredAttestationToken(System.Security.Cryptography.AsymmetricAlgorithm signingKey, System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate) { }
        public SecuredAttestationToken(System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate) { }
    }
    public partial class UnsecuredAttestationToken : Azure.Security.Attestation.AttestationToken
    {
        public UnsecuredAttestationToken() { }
        public UnsecuredAttestationToken(object body) { }
    }
}
namespace Azure.Security.Attestation.Models
{
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationType : System.IEquatable<Azure.Security.Attestation.Models.AttestationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationType(string value) { throw null; }
        public static Azure.Security.Attestation.Models.AttestationType OpenEnclave { get { throw null; } }
        public static Azure.Security.Attestation.Models.AttestationType SgxEnclave { get { throw null; } }
        public static Azure.Security.Attestation.Models.AttestationType Tpm { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.Models.AttestationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.Models.AttestationType left, Azure.Security.Attestation.Models.AttestationType right) { throw null; }
        public static implicit operator Azure.Security.Attestation.Models.AttestationType (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.Models.AttestationType left, Azure.Security.Attestation.Models.AttestationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateModification : System.IEquatable<Azure.Security.Attestation.Models.CertificateModification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateModification(string value) { throw null; }
        public static Azure.Security.Attestation.Models.CertificateModification IsAbsent { get { throw null; } }
        public static Azure.Security.Attestation.Models.CertificateModification IsPresent { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.Models.CertificateModification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.Models.CertificateModification left, Azure.Security.Attestation.Models.CertificateModification right) { throw null; }
        public static implicit operator Azure.Security.Attestation.Models.CertificateModification (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.Models.CertificateModification left, Azure.Security.Attestation.Models.CertificateModification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyCertificateModification
    {
        public PolicyCertificateModification(System.Security.Cryptography.X509Certificates.X509Certificate2 bodyCertificate) { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2 PolicyCertificate { get { throw null; } }
    }
    public partial class PolicyCertificatesModificationResult
    {
        internal PolicyCertificatesModificationResult() { }
        public Azure.Security.Attestation.Models.CertificateModification? CertificateResolution { get { throw null; } }
        public string CertificateThumbprint { get { throw null; } }
    }
    public partial class PolicyCertificatesResult
    {
        public PolicyCertificatesResult() { }
        public System.Collections.Generic.IReadOnlyList<System.Security.Cryptography.X509Certificates.X509Certificate2> GetPolicyCertificates() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyModification : System.IEquatable<Azure.Security.Attestation.Models.PolicyModification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyModification(string value) { throw null; }
        public static Azure.Security.Attestation.Models.PolicyModification Removed { get { throw null; } }
        public static Azure.Security.Attestation.Models.PolicyModification Updated { get { throw null; } }
        public bool Equals(Azure.Security.Attestation.Models.PolicyModification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.Attestation.Models.PolicyModification left, Azure.Security.Attestation.Models.PolicyModification right) { throw null; }
        public static implicit operator Azure.Security.Attestation.Models.PolicyModification (string value) { throw null; }
        public static bool operator !=(Azure.Security.Attestation.Models.PolicyModification left, Azure.Security.Attestation.Models.PolicyModification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyResult
    {
        public PolicyResult() { }
        public Azure.Security.Attestation.Models.PolicyModification PolicyResolution { get { throw null; } }
        public Azure.Security.Attestation.Models.AttestationSigner PolicySigner { get { throw null; } }
        public byte[] PolicyTokenHash { get { throw null; } }
    }
    public partial class StoredAttestationPolicy
    {
        public StoredAttestationPolicy() { }
        public string AttestationPolicy { get { throw null; } set { } }
    }
    public partial class TpmAttestationRequest
    {
        public TpmAttestationRequest() { }
        public System.ReadOnlyMemory<byte> Data { get { throw null; } set { } }
    }
    public partial class TpmAttestationResponse
    {
        internal TpmAttestationResponse() { }
        public System.ReadOnlyMemory<byte> Data { get { throw null; } }
    }
}
