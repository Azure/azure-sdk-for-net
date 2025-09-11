namespace Azure.Security.KeyVault.Certificates
{
    public partial class AdministratorContact
    {
        public AdministratorContact() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class CertificateClient
    {
        protected CertificateClient() { }
        public CertificateClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public CertificateClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Certificates.CertificateClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<byte[]> BackupCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<byte[]>> BackupCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer> CreateIssuer(Azure.Security.KeyVault.Certificates.CertificateIssuer issuer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer>> CreateIssuerAsync(Azure.Security.KeyVault.Certificates.CertificateIssuer issuer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>> DeleteContacts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>>> DeleteContactsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer> DeleteIssuer(string issuerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer>> DeleteIssuerAsync(string issuerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Security.Cryptography.X509Certificates.X509Certificate2> DownloadCertificate(Azure.Security.KeyVault.Certificates.DownloadCertificateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Security.Cryptography.X509Certificates.X509Certificate2> DownloadCertificate(string certificateName, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Security.Cryptography.X509Certificates.X509Certificate2>> DownloadCertificateAsync(Azure.Security.KeyVault.Certificates.DownloadCertificateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Security.Cryptography.X509Certificates.X509Certificate2>> DownloadCertificateAsync(string certificateName, string version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy> GetCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> GetCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Certificates.CertificateOperation GetCertificateOperation(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.CertificateOperation> GetCertificateOperationAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificatePolicy> GetCertificatePolicy(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificatePolicy>> GetCertificatePolicyAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificate> GetCertificateVersion(string certificateName, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificate>> GetCertificateVersionAsync(string certificateName, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>> GetContacts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>>> GetContactsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.DeletedCertificate> GetDeletedCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.DeletedCertificate>> GetDeletedCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Certificates.DeletedCertificate> GetDeletedCertificates(bool includePending = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Certificates.DeletedCertificate> GetDeletedCertificatesAsync(bool includePending = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer> GetIssuer(string issuerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer>> GetIssuerAsync(string issuerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Certificates.CertificateProperties> GetPropertiesOfCertificates(bool includePending = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Certificates.CertificateProperties> GetPropertiesOfCertificatesAsync(bool includePending = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Certificates.CertificateProperties> GetPropertiesOfCertificateVersions(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Certificates.CertificateProperties> GetPropertiesOfCertificateVersionsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Certificates.IssuerProperties> GetPropertiesOfIssuers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Certificates.IssuerProperties> GetPropertiesOfIssuersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy> ImportCertificate(Azure.Security.KeyVault.Certificates.ImportCertificateOptions importCertificateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> ImportCertificateAsync(Azure.Security.KeyVault.Certificates.ImportCertificateOptions importCertificateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy> MergeCertificate(Azure.Security.KeyVault.Certificates.MergeCertificateOptions mergeCertificateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> MergeCertificateAsync(Azure.Security.KeyVault.Certificates.MergeCertificateOptions mergeCertificateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PurgeDeletedCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PurgeDeletedCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy> RestoreCertificateBackup(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> RestoreCertificateBackupAsync(byte[] backup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>> SetContacts(System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Certificates.CertificateContact> contacts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateContact>>> SetContactsAsync(System.Collections.Generic.IEnumerable<Azure.Security.KeyVault.Certificates.CertificateContact> contacts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Certificates.CertificateOperation StartCreateCertificate(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null, bool? preserveCertificateOrder = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Security.KeyVault.Certificates.CertificateOperation StartCreateCertificate(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled, System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.CertificateOperation> StartCreateCertificateAsync(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null, bool? preserveCertificateOrder = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.CertificateOperation> StartCreateCertificateAsync(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled, System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Certificates.DeleteCertificateOperation StartDeleteCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.DeleteCertificateOperation> StartDeleteCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Certificates.RecoverDeletedCertificateOperation StartRecoverDeletedCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.RecoverDeletedCertificateOperation> StartRecoverDeletedCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificatePolicy> UpdateCertificatePolicy(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificatePolicy>> UpdateCertificatePolicyAsync(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificate> UpdateCertificateProperties(Azure.Security.KeyVault.Certificates.CertificateProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificate>> UpdateCertificatePropertiesAsync(Azure.Security.KeyVault.Certificates.CertificateProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer> UpdateIssuer(Azure.Security.KeyVault.Certificates.CertificateIssuer issuer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Certificates.CertificateIssuer>> UpdateIssuerAsync(Azure.Security.KeyVault.Certificates.CertificateIssuer issuer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateClientOptions : Azure.Core.ClientOptions
    {
        public CertificateClientOptions(Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion version = Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion.V7_6) { }
        public bool DisableChallengeResourceVerification { get { throw null; } set { } }
        public Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_0 = 0,
            V7_1 = 1,
            V7_2 = 2,
            V7_3 = 3,
            V7_4 = 4,
            V7_5 = 5,
            V7_6 = 6,
        }
    }
    public partial class CertificateContact
    {
        public CertificateContact() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateContentType : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateContentType(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateContentType Pem { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateContentType Pkcs12 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.CertificateContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Certificates.CertificateContentType left, Azure.Security.KeyVault.Certificates.CertificateContentType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Certificates.CertificateContentType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Certificates.CertificateContentType left, Azure.Security.KeyVault.Certificates.CertificateContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateIssuer
    {
        public CertificateIssuer(string name) { }
        public CertificateIssuer(string name, string provider) { }
        public string AccountId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.AdministratorContact> AdministratorContacts { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string OrganizationId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Provider { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateKeyCurveName : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateKeyCurveName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateKeyCurveName(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P256 { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P256K { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P384 { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P521 { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.CertificateKeyCurveName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Certificates.CertificateKeyCurveName left, Azure.Security.KeyVault.Certificates.CertificateKeyCurveName right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Certificates.CertificateKeyCurveName (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Certificates.CertificateKeyCurveName left, Azure.Security.KeyVault.Certificates.CertificateKeyCurveName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateKeyType : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateKeyType(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType Ec { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType EcHsm { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType Rsa { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType RsaHsm { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.CertificateKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Certificates.CertificateKeyType left, Azure.Security.KeyVault.Certificates.CertificateKeyType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Certificates.CertificateKeyType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Certificates.CertificateKeyType left, Azure.Security.KeyVault.Certificates.CertificateKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateKeyUsage : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateKeyUsage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateKeyUsage(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage CrlSign { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DataEncipherment { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DecipherOnly { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DigitalSignature { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage EncipherOnly { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyAgreement { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyCertSign { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyEncipherment { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage NonRepudiation { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.CertificateKeyUsage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Certificates.CertificateKeyUsage left, Azure.Security.KeyVault.Certificates.CertificateKeyUsage right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Certificates.CertificateKeyUsage (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Certificates.CertificateKeyUsage left, Azure.Security.KeyVault.Certificates.CertificateKeyUsage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class CertificateModelFactory
    {
        public static Azure.Security.KeyVault.Certificates.CertificateIssuer CertificateIssuer(Azure.Security.KeyVault.Certificates.IssuerProperties properties, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateOperationError CertificateOperationError(string code = null, string message = null, Azure.Security.KeyVault.Certificates.CertificateOperationError innerError = null) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateOperationProperties CertificateOperationProperties(System.Uri id = null, string name = null, System.Uri vaultUri = null, string issuerName = null, string certificateType = null, bool? certificateTransparency = default(bool?), byte[] csr = null, bool cancellationRequested = false, string requestId = null, string status = null, string statusDetails = null, string target = null, Azure.Security.KeyVault.Certificates.CertificateOperationError error = null) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicy CertificatePolicy(string subject = null, Azure.Security.KeyVault.Certificates.SubjectAlternativeNames subjectAlternativeNames = null, string issuerName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Security.KeyVault.Certificates.CertificateProperties CertificateProperties(System.Uri id, string name, System.Uri vaultUri, string version, byte[] x509thumbprint, System.DateTimeOffset? notBefore, System.DateTimeOffset? expiresOn, System.DateTimeOffset? createdOn, System.DateTimeOffset? updatedOn, string recoveryLevel) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateProperties CertificateProperties(System.Uri id = null, string name = null, System.Uri vaultUri = null, string version = null, byte[] x509thumbprint = null, System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string recoveryLevel = null, int? recoverableDays = default(int?)) { throw null; }
        public static Azure.Security.KeyVault.Certificates.DeletedCertificate DeletedCertificate(Azure.Security.KeyVault.Certificates.CertificateProperties properties, System.Uri keyId = null, System.Uri secretId = null, byte[] cer = null, Azure.Security.KeyVault.Certificates.CertificatePolicy policy = null, System.Uri recoveryId = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Security.KeyVault.Certificates.IssuerProperties IssuerProperties(System.Uri id = null, string name = null) { throw null; }
        public static Azure.Security.KeyVault.Certificates.KeyVaultCertificate KeyVaultCertificate(Azure.Security.KeyVault.Certificates.CertificateProperties properties, System.Uri keyId = null, System.Uri secretId = null, byte[] cer = null) { throw null; }
        public static Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy KeyVaultCertificateWithPolicy(Azure.Security.KeyVault.Certificates.CertificateProperties properties, System.Uri keyId = null, System.Uri secretId = null, byte[] cer = null, Azure.Security.KeyVault.Certificates.CertificatePolicy policy = null) { throw null; }
    }
    public partial class CertificateOperation : Azure.Operation<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>
    {
        protected CertificateOperation() { }
        public CertificateOperation(Azure.Security.KeyVault.Certificates.CertificateClient client, string name) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public virtual Azure.Security.KeyVault.Certificates.CertificateOperationProperties Properties { get { throw null; } }
        public override Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy Value { get { throw null; } }
        public virtual void Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class CertificateOperationError
    {
        internal CertificateOperationError() { }
        public string Code { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateOperationError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class CertificateOperationProperties
    {
        internal CertificateOperationProperties() { }
        public bool CancellationRequested { get { throw null; } }
        public bool? CertificateTransparency { get { throw null; } }
        public string CertificateType { get { throw null; } }
        public byte[] Csr { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateOperationError Error { get { throw null; } }
        public System.Uri Id { get { throw null; } }
        public string IssuerName { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? PreserveCertificateOrder { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public string Target { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
    }
    public partial class CertificatePolicy
    {
        public CertificatePolicy() { }
        public CertificatePolicy(string issuerName, Azure.Security.KeyVault.Certificates.SubjectAlternativeNames subjectAlternativeNames) { }
        public CertificatePolicy(string issuerName, string subject) { }
        public CertificatePolicy(string issuerName, string subject, Azure.Security.KeyVault.Certificates.SubjectAlternativeNames subjectAlternativeNames) { }
        public bool? CertificateTransparency { get { throw null; } set { } }
        public string CertificateType { get { throw null; } set { } }
        public Azure.Security.KeyVault.Certificates.CertificateContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicy Default { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnhancedKeyUsage { get { throw null; } }
        public bool? Exportable { get { throw null; } set { } }
        public string IssuerName { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateKeyCurveName? KeyCurveName { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
        public Azure.Security.KeyVault.Certificates.CertificateKeyType? KeyType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateKeyUsage> KeyUsage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.LifetimeAction> LifetimeActions { get { throw null; } }
        public bool? ReuseKey { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.SubjectAlternativeNames SubjectAlternativeNames { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public int? ValidityInMonths { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePolicyAction : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificatePolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePolicyAction(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicyAction AutoRenew { get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicyAction EmailContacts { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.CertificatePolicyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Certificates.CertificatePolicyAction left, Azure.Security.KeyVault.Certificates.CertificatePolicyAction right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Certificates.CertificatePolicyAction (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Certificates.CertificatePolicyAction left, Azure.Security.KeyVault.Certificates.CertificatePolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateProperties
    {
        public CertificateProperties(string name) { }
        public CertificateProperties(System.Uri id) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public int? RecoverableDays { get { throw null; } }
        public string RecoveryLevel { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public byte[] X509Thumbprint { get { throw null; } }
        public string X509ThumbprintString { get { throw null; } }
    }
    public partial class DeleteCertificateOperation : Azure.Operation<Azure.Security.KeyVault.Certificates.DeletedCertificate>
    {
        protected DeleteCertificateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Certificates.DeletedCertificate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.DeletedCertificate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.DeletedCertificate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class DeletedCertificate : Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy
    {
        internal DeletedCertificate() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.Uri RecoveryId { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
    }
    public partial class DownloadCertificateOptions
    {
        public DownloadCertificateOptions(string certificateName) { }
        public string CertificateName { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509KeyStorageFlags KeyStorageFlags { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ImportCertificateOptions
    {
        public ImportCertificateOptions(string name, byte[] certificate) { }
        public byte[] Certificate { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public Azure.Security.KeyVault.Certificates.CertificatePolicy Policy { get { throw null; } set { } }
        public bool? PreserveCertificateOrder { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IssuerProperties
    {
        internal IssuerProperties() { }
        public System.Uri Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Provider { get { throw null; } set { } }
    }
    public partial class KeyVaultCertificate
    {
        internal KeyVaultCertificate() { }
        public byte[] Cer { get { throw null; } }
        public System.Uri Id { get { throw null; } }
        public System.Uri KeyId { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? PreserveCertificateOrder { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateProperties Properties { get { throw null; } }
        public System.Uri SecretId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultCertificateIdentifier : System.IEquatable<Azure.Security.KeyVault.Certificates.KeyVaultCertificateIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultCertificateIdentifier(System.Uri id) { throw null; }
        public string Name { get { throw null; } }
        public System.Uri SourceId { get { throw null; } }
        public System.Uri VaultUri { get { throw null; } }
        public string Version { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Certificates.KeyVaultCertificateIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public static bool TryCreate(System.Uri id, out Azure.Security.KeyVault.Certificates.KeyVaultCertificateIdentifier identifier) { throw null; }
    }
    public partial class KeyVaultCertificateWithPolicy : Azure.Security.KeyVault.Certificates.KeyVaultCertificate
    {
        internal KeyVaultCertificateWithPolicy() { }
        public Azure.Security.KeyVault.Certificates.CertificatePolicy Policy { get { throw null; } }
    }
    public partial class LifetimeAction
    {
        public LifetimeAction(Azure.Security.KeyVault.Certificates.CertificatePolicyAction action) { }
        public Azure.Security.KeyVault.Certificates.CertificatePolicyAction Action { get { throw null; } }
        public int? DaysBeforeExpiry { get { throw null; } set { } }
        public int? LifetimePercentage { get { throw null; } set { } }
    }
    public partial class MergeCertificateOptions
    {
        public MergeCertificateOptions(string name, System.Collections.Generic.IEnumerable<byte[]> x509Certificates) { }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IEnumerable<byte[]> X509Certificates { get { throw null; } }
    }
    public partial class RecoverDeletedCertificateOperation : Azure.Operation<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>
    {
        protected RecoverDeletedCertificateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SubjectAlternativeNames
    {
        public SubjectAlternativeNames() { }
        public System.Collections.Generic.IList<string> DnsNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> UserPrincipalNames { get { throw null; } }
    }
    public static partial class WellKnownIssuerNames
    {
        public const string Self = "Self";
        public const string Unknown = "Unknown";
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class CertificateClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Certificates.CertificateClient, Azure.Security.KeyVault.Certificates.CertificateClientOptions> AddCertificateClient<TBuilder>(this TBuilder builder, System.Uri vaultUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Certificates.CertificateClient, Azure.Security.KeyVault.Certificates.CertificateClientOptions> AddCertificateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
