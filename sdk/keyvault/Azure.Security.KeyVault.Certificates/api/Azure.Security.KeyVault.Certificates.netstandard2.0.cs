namespace Azure.Security.KeyVault.Certificates
{
    public partial class AdministratorContact
    {
        public AdministratorContact() { }
        public string Email { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string FirstName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string LastName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Phone { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
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
        public virtual Azure.Security.KeyVault.Certificates.CertificateOperation StartCreateCertificate(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Certificates.CertificateOperation> StartCreateCertificateAsync(string certificateName, Azure.Security.KeyVault.Certificates.CertificatePolicy policy, bool? enabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public CertificateClientOptions(Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion version = Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion.V7_1_Preview) { }
        public Azure.Security.KeyVault.Certificates.CertificateClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public enum ServiceVersion
        {
            V7_0 = 0,
            V7_1_Preview = 1,
        }
    }
    public partial class CertificateContact
    {
        public CertificateContact() { }
        public string Email { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Phone { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateContentType : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateContentType(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateContentType Pem { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateContentType Pkcs12 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public string AccountId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.AdministratorContact> AdministratorContacts { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Uri Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string OrganizationId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Password { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Provider { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateKeyCurveName : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificateKeyCurveName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateKeyCurveName(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P256 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P256K { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P384 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyCurveName P521 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType Ec { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType EcHsm { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType Rsa { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyType RsaHsm { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage CrlSign { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DataEncipherment { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DecipherOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage DigitalSignature { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage EncipherOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyAgreement { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyCertSign { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage KeyEncipherment { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificateKeyUsage NonRepudiation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public CertificateOperation(Azure.Security.KeyVault.Certificates.CertificateClient client, string name) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateOperationProperties Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public string Code { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateOperationError InnerError { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Message { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class CertificateOperationProperties
    {
        internal CertificateOperationProperties() { }
        public bool CancellationRequested { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? CertificateTransparency { get { throw null; } }
        public string CertificateType { get { throw null; } }
        public byte[] Csr { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateOperationError Error { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string IssuerName { get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string RequestId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Status { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string StatusDetails { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Target { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri VaultUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class CertificatePolicy
    {
        public CertificatePolicy(string issuerName, Azure.Security.KeyVault.Certificates.SubjectAlternativeNames subjectAlternativeNames) { }
        public CertificatePolicy(string issuerName, string subject) { }
        public CertificatePolicy(string issuerName, string subject, Azure.Security.KeyVault.Certificates.SubjectAlternativeNames subjectAlternativeNames) { }
        public bool? CertificateTransparency { get { throw null; } set { } }
        public string CertificateType { get { throw null; } set { } }
        public Azure.Security.KeyVault.Certificates.CertificateContentType? ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset? CreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicy Default { get { throw null; } }
        public bool? Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IList<string> EnhancedKeyUsage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? Exportable { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string IssuerName { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateKeyCurveName? KeyCurveName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int? KeySize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Security.KeyVault.Certificates.CertificateKeyType? KeyType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.CertificateKeyUsage> KeyUsage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Certificates.LifetimeAction> LifetimeActions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? ReuseKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Subject { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Security.KeyVault.Certificates.SubjectAlternativeNames SubjectAlternativeNames { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? ValidityInMonths { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePolicyAction : System.IEquatable<Azure.Security.KeyVault.Certificates.CertificatePolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePolicyAction(string value) { throw null; }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicyAction AutoRenew { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Security.KeyVault.Certificates.CertificatePolicyAction EmailContacts { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public System.Uri Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public int? RecoverableDays { get { throw null; } }
        public string RecoveryLevel { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Uri VaultUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public byte[] X509Thumbprint { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class DeleteCertificateOperation : Azure.Operation<Azure.Security.KeyVault.Certificates.DeletedCertificate>
    {
        internal DeleteCertificateOperation() { }
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
        public System.DateTimeOffset? DeletedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri RecoveryId { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ImportCertificateOptions
    {
        public ImportCertificateOptions(string name, byte[] certificate) { }
        public byte[] Certificate { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Password { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Security.KeyVault.Certificates.CertificatePolicy Policy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IssuerProperties
    {
        internal IssuerProperties() { }
        public System.Uri Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Provider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class KeyVaultCertificate
    {
        internal KeyVaultCertificate() { }
        public byte[] Cer { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri Id { get { throw null; } }
        public System.Uri KeyId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Certificates.CertificateProperties Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri SecretId { get { throw null; } }
    }
    public partial class KeyVaultCertificateWithPolicy : Azure.Security.KeyVault.Certificates.KeyVaultCertificate
    {
        internal KeyVaultCertificateWithPolicy() { }
        public Azure.Security.KeyVault.Certificates.CertificatePolicy Policy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class LifetimeAction
    {
        public LifetimeAction(Azure.Security.KeyVault.Certificates.CertificatePolicyAction action) { }
        public Azure.Security.KeyVault.Certificates.CertificatePolicyAction Action { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? DaysBeforeExpiry { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int? LifetimePercentage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class MergeCertificateOptions
    {
        public MergeCertificateOptions(string name, System.Collections.Generic.IEnumerable<byte[]> x509Certificates) { }
        public bool? Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IEnumerable<byte[]> X509Certificates { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class RecoverDeletedCertificateOperation : Azure.Operation<Azure.Security.KeyVault.Certificates.KeyVaultCertificateWithPolicy>
    {
        internal RecoverDeletedCertificateOperation() { }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Security.KeyVault.Certificates.CertificateClient, Azure.Security.KeyVault.Certificates.CertificateClientOptions> AddCertificateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
