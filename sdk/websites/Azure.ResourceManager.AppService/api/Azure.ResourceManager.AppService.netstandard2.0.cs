namespace Azure.ResourceManager.AppService
{
    public partial class ApiKeyVaultReferenceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiKeyVaultReferenceData() { }
        public string ActiveVersion { get { throw null; } set { } }
        public string Details { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ConfigReferenceSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ResolveStatus? Status { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
    }
    public partial class AppCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppCertificateResource>, System.Collections.IEnumerable
    {
        protected AppCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppCertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppCertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CanonicalName { get { throw null; } set { } }
        public byte[] CerBlob { get { throw null; } }
        public string DomainValidationMethod { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> HostNames { get { throw null; } }
        public System.DateTimeOffset? IssueOn { get { throw null; } }
        public string Issuer { get { throw null; } }
        public bool? IsValid { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? KeyVaultSecretStatus { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public byte[] PfxBlob { get { throw null; } set { } }
        public string PublicKeyHash { get { throw null; } }
        public string SelfLink { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServerFarmId { get { throw null; } set { } }
        public string SiteName { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
    }
    public partial class AppCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.AppCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource> Update(Azure.ResourceManager.AppService.Models.AppCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>, System.Collections.IEnumerable
    {
        protected AppServiceCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServiceCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServiceCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServiceCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceCertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServiceCertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
    }
    public partial class AppServiceCertificateOrderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>, System.Collections.IEnumerable
    {
        protected AppServiceCertificateOrderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateOrderName, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateOrderName, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> Get(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> GetAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceCertificateOrderData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServiceCertificateOrderData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceCertificateProperties> Certificates { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuedOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewTimeStamp { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateProductType? ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
    }
    public partial class AppServiceCertificateOrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateOrderResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> GetAppServiceCertificate(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> GetAppServiceCertificateAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateCollection GetAppServiceCertificates() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> GetCertificateOrderDetector(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>> GetCertificateOrderDetectorAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.CertificateOrderDetectorCollection GetCertificateOrderDetectors() { throw null; }
        public virtual Azure.Response Reissue(Azure.ResourceManager.AppService.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReissueAsync(Azure.ResourceManager.AppService.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Renew(Azure.ResourceManager.AppService.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(Azure.ResourceManager.AppService.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendEmail(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendEmailAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendRequestEmails(Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendRequestEmailsAsync(Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CertificateOrderAction> RetrieveCertificateActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CertificateOrderAction> RetrieveCertificateActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceCertificateEmail> RetrieveCertificateEmailHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceCertificateEmail> RetrieveCertificateEmailHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteSeal> RetrieveSiteSeal(Azure.ResourceManager.AppService.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteSeal>> RetrieveSiteSealAsync(Azure.ResourceManager.AppService.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> Update(Azure.ResourceManager.AppService.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyDomainOwnership(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyDomainOwnershipAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> Update(Azure.ResourceManager.AppService.Models.AppServiceCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceDetectorData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceDetectorData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DataProviderMetadata> DataProvidersMetadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticDataset> Dataset { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorInfo Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceStatusInfo Status { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.QueryUtterancesResults SuggestedUtterances { get { throw null; } set { } }
    }
    public partial class AppServiceDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceDomainResource>, System.Collections.IEnumerable
    {
        protected AppServiceDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.AppServiceDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.AppServiceDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServiceDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServiceDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceDomainData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServiceDomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AuthCode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactBilling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactRegistrant { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactTech { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsDnsRecordManagementReady { get { throw null; } }
        public bool? IsDomainPrivacyEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDomainStatus? RegistrationStatus { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDnsType? TargetDnsType { get { throw null; } set { } }
    }
    public partial class AppServiceDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceDomainResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> GetDomainOwnershipIdentifier(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> GetDomainOwnershipIdentifierAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.DomainOwnershipIdentifierCollection GetDomainOwnershipIdentifiers() { throw null; }
        public virtual Azure.Response Renew(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> Update(Azure.ResourceManager.AppService.Models.AppServiceDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>, System.Collections.IEnumerable
    {
        protected AppServiceEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServiceEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IPSslAddressCount { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
    }
    public partial class AppServiceEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceEnvironmentResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableAllForHostingEnvironmentRecommendation(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAllForHostingEnvironmentRecommendationAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteData> GetAllWebAppData(string propertiesToInclude = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteData> GetAllWebAppDataAsync(string propertiesToInclude = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource GetAseV3NetworkingConfiguration() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StampCapacity> GetCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StampCapacity> GetCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.HostingEnvironmentDiagnostics> GetDiagnostics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.HostingEnvironmentDiagnostics> GetDiagnosticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.HostingEnvironmentDiagnostics> GetDiagnosticsItem(string diagnosticsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.HostingEnvironmentDiagnostics>> GetDiagnosticsItemAsync(string diagnosticsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForHostingEnvironmentRecommendations(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForHostingEnvironmentRecommendationsAsync(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> GetHostingEnvironmentDetector(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>> GetHostingEnvironmentDetectorAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HostingEnvironmentDetectorCollection GetHostingEnvironmentDetectors() { throw null; }
        public virtual Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource GetHostingEnvironmentMultiRolePool() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> GetHostingEnvironmentPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> GetHostingEnvironmentPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionCollection GetHostingEnvironmentPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource> GetHostingEnvironmentRecommendation(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource>> GetHostingEnvironmentRecommendationAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HostingEnvironmentRecommendationCollection GetHostingEnvironmentRecommendations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> GetHostingEnvironmentWorkerPool(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> GetHostingEnvironmentWorkerPoolAsync(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolCollection GetHostingEnvironmentWorkerPools() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.InboundEnvironmentEndpoint> GetInboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.InboundEnvironmentEndpoint> GetInboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceOperation> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceOperation> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForHostingEnvironmentRecommendations(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForHostingEnvironmentRecommendationsAsync(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceEnvironmentAddressResult> GetVipInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceEnvironmentAddressResult>> GetVipInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reboot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetAllFiltersForHostingEnvironmentRecommendation(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAllFiltersForHostingEnvironmentRecommendationAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> Update(Azure.ResourceManager.AppService.Models.AppServiceEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AppServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppService.Models.DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.ResourceNameAvailability> CheckAppServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ResourceNameAvailability>> CheckAppServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DisableAppServiceRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DisableAppServiceRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.ResourceHealthMetadataData> GetAllResourceHealthMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.ResourceHealthMetadataData> GetAllResourceHealthMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.ResourceHealthMetadataData> GetAllResourceHealthMetadataData(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.ResourceHealthMetadataData> GetAllResourceHealthMetadataDataAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServiceIdentifierData> GetAllSiteIdentifierData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceIdentifierData> GetAllSiteIdentifierDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource> GetAppCertificate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppCertificateResource>> GetAppCertificateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppCertificateResource GetAppCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppCertificateCollection GetAppCertificates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppCertificateResource> GetAppCertificates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppCertificateResource> GetAppCertificatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrder(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> GetAppServiceCertificateOrderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateOrderCollection GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateResource GetAppServiceCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceDeploymentLocations> GetAppServiceDeploymentLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceDeploymentLocations>> GetAppServiceDeploymentLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAppServiceDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> GetAppServiceDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceDomainNameIdentifier> GetAppServiceDomainRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceDomainResource GetAppServiceDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceDomainCollection GetAppServiceDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAppServiceDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAppServiceDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> GetAppServiceEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> GetAppServiceEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceEnvironmentResource GetAppServiceEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceEnvironmentCollection GetAppServiceEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> GetAppServiceEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> GetAppServiceEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> GetAppServicePlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource GetAppServicePlanHybridConnectionNamespaceRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanResource GetAppServicePlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanCollection GetAppServicePlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource GetAppServicePlanVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource GetAppServicePlanVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource> GetAppServiceSourceControl(this Azure.ResourceManager.Resources.TenantResource tenantResource, string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource>> GetAppServiceSourceControlAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceSourceControlResource GetAppServiceSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceSourceControlCollection GetAppServiceSourceControls(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource GetAseV3NetworkingConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksOnPremProviders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksOnPremProvidersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceBillingMeter> GetBillingMeters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingLocation = null, string osType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceBillingMeter> GetBillingMetersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingLocation = null, string osType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.CertificateOrderDetectorResource GetCertificateOrderDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequestDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSite(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetDeletedSiteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.DeletedSiteResource GetDeletedSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.DeletedSiteCollection GetDeletedSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSitesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSitesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedWebAppByLocationDeletedWebApp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetDeletedWebAppByLocationDeletedWebAppAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksForLocationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceGeoRegion> GetGeoRegions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceSkuName? sku = default(Azure.ResourceManager.AppService.Models.AppServiceSkuName?), bool? linuxWorkersEnabled = default(bool?), bool? xenonWorkersEnabled = default(bool?), bool? linuxDynamicWorkersEnabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceGeoRegion> GetGeoRegionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceSkuName? sku = default(Azure.ResourceManager.AppService.Models.AppServiceSkuName?), bool? linuxWorkersEnabled = default(bool?), bool? xenonWorkersEnabled = default(bool?), bool? linuxDynamicWorkersEnabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource GetHostingEnvironmentDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource GetHostingEnvironmentMultiRolePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource GetHostingEnvironmentPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource GetHostingEnvironmentRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource GetHostingEnvironmentWorkerPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HybridConnectionLimitResource GetHybridConnectionLimitResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> GetKubeEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.KubeEnvironmentResource GetKubeEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.KubeEnvironmentCollection GetKubeEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.LogsSiteConfigResource GetLogsSiteConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.LogsSiteSlotConfigResource GetLogsSiteSlotConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.MigrateMySqlStatusResource GetMigrateMySqlStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.NetworkFeatureResource GetNetworkFeatureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsCertificateRegistrationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsCertificateRegistrationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsDomainRegistrationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsDomainRegistrationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.PremierAddOnOffer> GetPremierAddOnOffers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PremierAddOnOffer> GetPremierAddOnOffersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.PublishingUserResource GetPublishingUser(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppService.PublishingUserResource GetPublishingUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource GetScmSiteBasicPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource GetScmSiteSlotBasicPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteBackupResource GetSiteBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteConfigAppsettingResource GetSiteConfigAppsettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteConfigSnapshotResource GetSiteConfigSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDeploymentResource GetSiteDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDetectorResource GetSiteDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource GetSiteDiagnosticAnalysisResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource GetSiteDiagnosticDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDiagnosticResource GetSiteDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource GetSiteDomainOwnershipIdentifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteExtensionResource GetSiteExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteFunctionResource GetSiteFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteHostNameBindingResource GetSiteHostNameBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource GetSiteHybridConnectionNamespaceRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceExtensionResource GetSiteInstanceExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource GetSiteInstanceProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceProcessResource GetSiteInstanceProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceResource GetSiteInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteNetworkConfigResource GetSiteNetworkConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource GetSitePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteProcessModuleResource GetSiteProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteProcessResource GetSiteProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePublicCertificateResource GetSitePublicCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteRecommendationResource GetSiteRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotBackupResource GetSiteSlotBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource GetSiteSlotConfigSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDeploymentResource GetSiteSlotDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDetectorResource GetSiteSlotDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource GetSiteSlotDiagnosticAnalysisResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource GetSiteSlotDiagnosticDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDiagnosticResource GetSiteSlotDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource GetSiteSlotDomainOwnershipIdentifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotExtensionResource GetSiteSlotExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotFunctionResource GetSiteSlotFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource GetSiteSlotHostNameBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource GetSiteSlotHybridConnectionNamespaceRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource GetSiteSlotInstanceExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource GetSiteSlotInstanceProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource GetSiteSlotInstanceProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceResource GetSiteSlotInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource GetSiteSlotNetworkConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource GetSiteSlotPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotProcessModuleResource GetSiteSlotProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotProcessResource GetSiteSlotProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource GetSiteSlotVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource GetSiteSlotVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource GetSiteVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource GetSiteVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceSkuResult> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceSkuResult>> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.SlotConfigNamesResource GetSlotConfigNamesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource> GetStaticSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource>> GetStaticSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteBuildResource GetStaticSiteBuildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource GetStaticSiteBuildUserProvidedFunctionAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource GetStaticSiteCustomDomainOverviewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource GetStaticSitePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteResource GetStaticSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteCollection GetStaticSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteResource> GetStaticSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteResource> GetStaticSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource GetStaticSiteUserProvidedFunctionAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource> GetTopLevelDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource>> GetTopLevelDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.TopLevelDomainResource GetTopLevelDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.TopLevelDomainCollection GetTopLevelDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksByLocation(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksByLocationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> GetWebSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> GetWebSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource GetWebSiteConfigConnectionStringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteConfigResource GetWebSiteConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource GetWebSiteContinuousWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteExtensionResource GetWebSiteExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource GetWebSiteFtpPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteHybridConnectionResource GetWebSiteHybridConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSitePremierAddonResource GetWebSitePremierAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSitePrivateAccessResource GetWebSitePrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteResource GetWebSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteResourceHealthMetadataResource GetWebSiteResourceHealthMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteCollection GetWebSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource GetWebSiteSlotConfigAppSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource GetWebSiteSlotConfigConnectionStringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotConfigResource GetWebSiteSlotConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource GetWebSiteSlotContinuousWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotExtensionResource GetWebSiteSlotExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource GetWebSiteSlotFtpPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource GetWebSiteSlotHybridConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource GetWebSiteSlotPremierAddOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource GetWebSiteSlotPrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource GetWebSiteSlotPublicCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotResource GetWebSiteSlotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotResourceHealthMetadataResource GetWebSiteSlotResourceHealthMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource GetWebSiteSlotSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource GetWebSiteSlotTriggeredWebJobHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource GetWebSiteSlotTriggeredWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotWebJobResource GetWebSiteSlotWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSourceControlResource GetWebSiteSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource GetWebSiteTriggeredWebJobHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource GetWebSiteTriggeredwebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteWebJobResource GetWebSiteWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreview> PreviewStaticSiteWorkflow(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreviewContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreview>> PreviewStaticSiteWorkflowAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreviewContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response ResetAllRecommendationFilters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ResetAllRecommendationFiltersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceValidateResult> Validate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.AppServiceValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response ValidateAppServiceCertificateOrderPurchaseInformation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidateAppServiceCertificateOrderPurchaseInformationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceValidateResult>> ValidateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.AppServiceValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.VirtualNetworkValidationFailureDetails> VerifyHostingEnvironmentVnet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.VirtualNetworkValidationFailureDetails>> VerifyHostingEnvironmentVnetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceIdentifierData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceIdentifierData() { }
        public string Kind { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AppServicePlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServicePlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServicePlanResource>, System.Collections.IEnumerable
    {
        protected AppServicePlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServicePlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServicePlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServicePlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServicePlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServicePlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServicePlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServicePlanData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServicePlanData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.DateTimeOffset? FreeOfferExpireOn { get { throw null; } set { } }
        public string GeoRegion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public bool? IsElasticScaleEnabled { get { throw null; } set { } }
        public bool? IsHyperV { get { throw null; } set { } }
        public bool? IsPerSiteScaling { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } set { } }
        public bool? IsSpot { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProfile KubeEnvironmentProfile { get { throw null; } set { } }
        public int? MaximumElasticWorkerCount { get { throw null; } set { } }
        public int? MaximumNumberOfWorkers { get { throw null; } }
        public int? NumberOfSites { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SpotExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServicePlanStatus? Status { get { throw null; } }
        public string Subscription { get { throw null; } }
        public int? TargetWorkerCount { get { throw null; } set { } }
        public int? TargetWorkerSizeId { get { throw null; } set { } }
        public string WorkerTierName { get { throw null; } set { } }
    }
    public partial class AppServicePlanHybridConnectionNamespaceRelayCollection : Azure.ResourceManager.ArmCollection
    {
        protected AppServicePlanHybridConnectionNamespaceRelayCollection() { }
        public virtual Azure.Response<bool> Exists(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource> Get(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource>> GetAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServicePlanHybridConnectionNamespaceRelayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServicePlanHybridConnectionNamespaceRelayResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string namespaceName, string relayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.HybridConnectionKey> GetHybridConnectionKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.HybridConnectionKey>> GetHybridConnectionKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetWebAppsByHybridConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetWebAppsByHybridConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServicePlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServicePlanResource() { }
        public virtual Azure.ResourceManager.AppService.AppServicePlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource> GetAppServicePlanHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayResource>> GetAppServicePlanHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AppServicePlanHybridConnectionNamespaceRelayCollection GetAppServicePlanHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> GetAppServicePlanVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>> GetAppServicePlanVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionCollection GetAppServicePlanVirtualNetworkConnections() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceSkuCapability> GetCapabilities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceSkuCapability> GetCapabilitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HybridConnectionLimitResource GetHybridConnectionLimit() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.HybridConnectionData> GetHybridConnectionRelays(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.HybridConnectionData> GetHybridConnectionRelaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetServerFarmSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetServerFarmSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteData> GetWebApps(string skipToken = null, string filter = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteData> GetWebAppsAsync(string skipToken = null, string filter = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RebootWorker(string workerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootWorkerAsync(string workerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RestartWebApps(bool? softRestart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartWebAppsAsync(bool? softRestart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> Update(Azure.ResourceManager.AppService.Models.AppServicePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServicePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServicePlanVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected AppServicePlanVirtualNetworkConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> Get(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>> GetAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServicePlanVirtualNetworkConnectionGatewayCollection : Azure.ResourceManager.ArmCollection
    {
        protected AppServicePlanVirtualNetworkConnectionGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServicePlanVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServicePlanVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServicePlanVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServicePlanVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> CreateOrUpdateVnetRoute(string routeName, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute>> CreateOrUpdateVnetRouteAsync(string routeName, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName) { throw null; }
        public virtual Azure.Response DeleteVnetRoute(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVnetRouteAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource> GetAppServicePlanVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayResource>> GetAppServicePlanVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionGatewayCollection GetAppServicePlanVirtualNetworkConnectionGateways() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> GetRoutesForVnet(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> GetRoutesForVnetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> UpdateVnetRoute(string routeName, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute>> UpdateVnetRouteAsync(string routeName, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceSourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceSourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceSourceControlResource>, System.Collections.IEnumerable
    {
        protected AppServiceSourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceSourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlType, Azure.ResourceManager.AppService.AppServiceSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceSourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlType, Azure.ResourceManager.AppService.AppServiceSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource> Get(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.AppServiceSourceControlResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceSourceControlResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource>> GetAsync(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.AppServiceSourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceSourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.AppServiceSourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceSourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceSourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceSourceControlData() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public string TokenSecret { get { throw null; } set { } }
    }
    public partial class AppServiceSourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceSourceControlResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string sourceControlType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceSourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceSourceControlResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceSourceControlResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceVirtualNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceVirtualNetworkData() { }
        public string CertBlob { get { throw null; } set { } }
        public System.BinaryData CertThumbprint { get { throw null; } }
        public string DnsServers { get { throw null; } set { } }
        public bool? IsResyncRequired { get { throw null; } }
        public bool? IsSwift { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> Routes { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetResourceId { get { throw null; } set { } }
    }
    public partial class AppServiceVirtualNetworkGatewayData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceVirtualNetworkGatewayData() { }
        public string Kind { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public System.Uri VpnPackageUri { get { throw null; } set { } }
    }
    public partial class AppServiceWorkerPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceWorkerPoolData() { }
        public Azure.ResourceManager.AppService.Models.ComputeModeOption? ComputeMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> InstanceNames { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
        public string WorkerSize { get { throw null; } set { } }
        public int? WorkerSizeId { get { throw null; } set { } }
    }
    public partial class AseV3NetworkingConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public AseV3NetworkingConfigurationData() { }
        public bool? AllowNewPrivateEndpointConnections { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> ExternalInboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> InternalInboundIPAddresses { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> LinuxOutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> WindowsOutboundIPAddresses { get { throw null; } }
    }
    public partial class AseV3NetworkingConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AseV3NetworkingConfigurationResource() { }
        public virtual Azure.ResourceManager.AppService.AseV3NetworkingConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AseV3NetworkingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AseV3NetworkingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateOrderDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>, System.Collections.IEnumerable
    {
        protected CertificateOrderDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> Get(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>> GetAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateOrderDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateOrderDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> Get(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>> GetAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContinuousWebJobData : Azure.ResourceManager.Models.ResourceData
    {
        public ContinuousWebJobData() { }
        public string DetailedStatus { get { throw null; } set { } }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public bool? IsUsingSdk { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri LogUri { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ContinuousWebJobStatus? Status { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
    }
    public partial class CsmPublishingCredentialsPoliciesEntityData : Azure.ResourceManager.Models.ResourceData
    {
        public CsmPublishingCredentialsPoliciesEntityData() { }
        public bool? Allow { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class DeletedSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.DeletedSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.DeletedSiteResource>, System.Collections.IEnumerable
    {
        protected DeletedSiteCollection() { }
        public virtual Azure.Response<bool> Exists(string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> Get(string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetAsync(string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.DeletedSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.DeletedSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.DeletedSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.DeletedSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedSiteData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedSiteData() { }
        public int? DeletedSiteId { get { throw null; } }
        public string DeletedSiteName { get { throw null; } }
        public string DeletedTimestamp { get { throw null; } }
        public string GeoRegionName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string KindPropertiesKind { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string Slot { get { throw null; } }
        public string Subscription { get { throw null; } }
    }
    public partial class DeletedSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedSiteResource() { }
        public virtual Azure.ResourceManager.AppService.DeletedSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string deletedSiteId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetDeletedWebAppSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetDeletedWebAppSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DetectorDefinitionResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DetectorDefinitionResourceData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public double? Rank { get { throw null; } }
    }
    public partial class DiagnosticCategoryData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticCategoryData() { }
        public string Description { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class DomainOwnershipIdentifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>, System.Collections.IEnumerable
    {
        protected DomainOwnershipIdentifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainOwnershipIdentifierData : Azure.ResourceManager.Models.ResourceData
    {
        public DomainOwnershipIdentifierData() { }
        public string Kind { get { throw null; } set { } }
        public string OwnershipId { get { throw null; } set { } }
    }
    public partial class DomainOwnershipIdentifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainOwnershipIdentifierResource() { }
        public virtual Azure.ResourceManager.AppService.DomainOwnershipIdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> Update(Azure.ResourceManager.AppService.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.AppService.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FunctionEnvelopeData : Azure.ResourceManager.Models.ResourceData
    {
        public FunctionEnvelopeData() { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string ConfigHref { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Files { get { throw null; } }
        public string FunctionAppId { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public string InvokeUrlTemplate { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string ScriptHref { get { throw null; } set { } }
        public string ScriptRootPathHref { get { throw null; } set { } }
        public string SecretsFileHref { get { throw null; } set { } }
        public string TestData { get { throw null; } set { } }
        public string TestDataHref { get { throw null; } set { } }
    }
    public partial class HostingEnvironmentDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>, System.Collections.IEnumerable
    {
        protected HostingEnvironmentDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> Get(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>> GetAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostingEnvironmentDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostingEnvironmentDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource> Get(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource>> GetAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentMultiRolePoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostingEnvironmentMultiRolePoolResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceWorkerPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRoleMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRoleMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRolePoolInstanceMetricDefinitions(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRolePoolInstanceMetricDefinitionsAsync(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePoolSkuInfo> GetMultiRolePoolSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePoolSkuInfo> GetMultiRolePoolSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetMultiRoleUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetMultiRoleUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> Update(Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HostingEnvironmentPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostingEnvironmentPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostingEnvironmentPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RemotePrivateEndpointConnectionARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentRecommendationCollection : Azure.ResourceManager.ArmCollection
    {
        protected HostingEnvironmentRecommendationCollection() { }
        public virtual Azure.Response<bool> Exists(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource> Get(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource>> GetAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentRecommendationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostingEnvironmentRecommendationResource() { }
        public virtual Azure.ResourceManager.AppService.RecommendationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostingEnvironmentName, string name) { throw null; }
        public virtual Azure.Response DisableRecommendationForHostingEnvironment(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationForHostingEnvironmentAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource> Get(bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource>> GetAsync(bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentWorkerPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>, System.Collections.IEnumerable
    {
        protected HostingEnvironmentWorkerPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workerPoolName, Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workerPoolName, Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> Get(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> GetAsync(string workerPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostingEnvironmentWorkerPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostingEnvironmentWorkerPoolResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceWorkerPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string workerPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetWebWorkerMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetWebWorkerMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetWebWorkerUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetWebWorkerUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetWorkerPoolInstanceMetricDefinitions(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetWorkerPoolInstanceMetricDefinitionsAsync(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePoolSkuInfo> GetWorkerPoolSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePoolSkuInfo> GetWorkerPoolSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> Update(Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceWorkerPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostNameBindingData : Azure.ResourceManager.Models.ResourceData
    {
        public HostNameBindingData() { }
        public string AzureResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceResourceType? AzureResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get { throw null; } set { } }
        public string DomainId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceHostNameType? HostNameType { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string SiteName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HostNameBindingSslState? SslState { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } }
    }
    public partial class HybridConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridConnectionData() { }
        public string Hostname { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RelayArmId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release, please use `RelayArmId` instead", false)]
        public System.Uri RelayArmUri { get { throw null; } set { } }
        public string RelayName { get { throw null; } set { } }
        public string SendKeyName { get { throw null; } set { } }
        public string SendKeyValue { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string ServiceBusSuffix { get { throw null; } set { } }
    }
    public partial class HybridConnectionLimitData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridConnectionLimitData() { }
        public int? Current { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public int? Maximum { get { throw null; } }
    }
    public partial class HybridConnectionLimitResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectionLimitResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionLimitData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HybridConnectionLimitResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HybridConnectionLimitResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KubeEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.KubeEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.KubeEnvironmentResource>, System.Collections.IEnumerable
    {
        protected KubeEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.KubeEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.KubeEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.KubeEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.KubeEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.KubeEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.KubeEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.KubeEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.KubeEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KubeEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KubeEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ArcConfiguration ArcConfiguration { get { throw null; } set { } }
        public string DefaultDomain { get { throw null; } }
        public string DeploymentErrors { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public bool? IsInternalLoadBalancerEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
    }
    public partial class KubeEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubeEnvironmentResource() { }
        public virtual Azure.ResourceManager.AppService.KubeEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> Update(Azure.ResourceManager.AppService.Models.KubeEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.KubeEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsSiteConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogsSiteConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SiteLogsConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.LogsSiteConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteLogsConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.LogsSiteConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteLogsConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.LogsSiteConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.LogsSiteConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsSiteSlotConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogsSiteSlotConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SiteLogsConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.LogsSiteSlotConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteLogsConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.LogsSiteSlotConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteLogsConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.LogsSiteSlotConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.LogsSiteSlotConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateMySqlStatusData : Azure.ResourceManager.Models.ResourceData
    {
        public MigrateMySqlStatusData() { }
        public bool? IsLocalMySqlEnabled { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceOperationStatus? MigrationOperationStatus { get { throw null; } }
        public string OperationId { get { throw null; } }
    }
    public partial class MigrateMySqlStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateMySqlStatusResource() { }
        public virtual Azure.ResourceManager.AppService.MigrateMySqlStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MSDeployStatusData : Azure.ResourceManager.Models.ResourceData
    {
        public MSDeployStatusData() { }
        public string Deployer { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public bool? IsComplete { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.MSDeployProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class NetworkFeatureCollection : Azure.ResourceManager.ArmCollection
    {
        protected NetworkFeatureCollection() { }
        public virtual Azure.Response<bool> Exists(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource> Get(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource>> GetAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFeatureData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkFeatureData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData> HybridConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.HybridConnectionData> HybridConnectionsV2 { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkProperties VirtualNetworkConnection { get { throw null; } }
        public string VirtualNetworkName { get { throw null; } }
    }
    public partial class NetworkFeatureResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFeatureResource() { }
        public virtual Azure.ResourceManager.AppService.NetworkFeatureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string view) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PremierAddOnData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PremierAddOnData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Kind { get { throw null; } set { } }
        public string MarketplaceOffer { get { throw null; } set { } }
        public string MarketplacePublisher { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
    }
    public partial class PrivateAccessData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateAccessData() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.PrivateAccessVirtualNetwork> VirtualNetworks { get { throw null; } }
    }
    public partial class ProcessInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public ProcessInfoData() { }
        public System.Collections.Generic.IList<string> Children { get { throw null; } }
        public string CommandLine { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string FileName { get { throw null; } set { } }
        public int? HandleCount { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public int? Identifier { get { throw null; } }
        public double? IisProfileTimeoutInSeconds { get { throw null; } set { } }
        public bool? IsIisProfileRunning { get { throw null; } set { } }
        public bool? IsProfileRunning { get { throw null; } set { } }
        public bool? IsScmSite { get { throw null; } set { } }
        public bool? IsWebjob { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Minidump { get { throw null; } set { } }
        public int? ModuleCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.ProcessModuleInfoData> Modules { get { throw null; } }
        public long? NonPagedSystemMemory { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OpenFileHandles { get { throw null; } }
        public long? PagedMemory { get { throw null; } set { } }
        public long? PagedSystemMemory { get { throw null; } set { } }
        public string Parent { get { throw null; } set { } }
        public long? PeakPagedMemory { get { throw null; } set { } }
        public long? PeakVirtualMemory { get { throw null; } set { } }
        public long? PeakWorkingSet { get { throw null; } set { } }
        public long? PrivateMemory { get { throw null; } set { } }
        public string PrivilegedCpuTime { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? ThreadCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> Threads { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
        public string TotalCpuTime { get { throw null; } set { } }
        public string UserCpuTime { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        public long? VirtualMemory { get { throw null; } set { } }
        public long? WorkingSet { get { throw null; } set { } }
    }
    public partial class ProcessModuleInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public ProcessModuleInfoData() { }
        public string BaseAddress { get { throw null; } set { } }
        public string FileDescription { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FileVersion { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public bool? IsDebug { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public int? ModuleMemorySize { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string ProductVersion { get { throw null; } set { } }
    }
    public partial class PublicCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public PublicCertificateData() { }
        public byte[] Blob { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.PublicCertificateLocation? PublicCertificateLocation { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } }
    }
    public partial class PublishingUserData : Azure.ResourceManager.Models.ResourceData
    {
        public PublishingUserData() { }
        public string Kind { get { throw null; } set { } }
        public string PublishingPassword { get { throw null; } set { } }
        public string PublishingPasswordHash { get { throw null; } set { } }
        public string PublishingPasswordHashSalt { get { throw null; } set { } }
        public string PublishingUserName { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } set { } }
    }
    public partial class PublishingUserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublishingUserResource() { }
        public virtual Azure.ResourceManager.AppService.PublishingUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublishingUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublishingUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.PublishingUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.PublishingUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecommendationRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendationRuleData() { }
        public string ActionName { get { throw null; } set { } }
        public string BladeName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryTags { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RecommendationChannel? Channels { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        public string ForwardLink { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.NotificationLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Guid? RecommendationId { get { throw null; } set { } }
        public string RecommendationName { get { throw null; } set { } }
    }
    public partial class RelayServiceConnectionEntityData : Azure.ResourceManager.Models.ResourceData
    {
        public RelayServiceConnectionEntityData() { }
        public System.Uri BiztalkUri { get { throw null; } set { } }
        public string EntityConnectionString { get { throw null; } set { } }
        public string EntityName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ResourceConnectionString { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnectionARMResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public RemotePrivateEndpointConnectionARMResourceData() { }
        public System.Collections.Generic.IList<System.Net.IPAddress> IPAddresses { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ResourceHealthMetadataData : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceHealthMetadataData() { }
        public string Category { get { throw null; } set { } }
        public bool? IsSignalAvailable { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class ScmSiteBasicPublishingCredentialsPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScmSiteBasicPublishingCredentialsPolicyResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScmSiteSlotBasicPublishingCredentialsPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScmSiteSlotBasicPublishingCredentialsPolicyResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteBackupResource>, System.Collections.IEnumerable
    {
        protected SiteBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> Get(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteBackupResource() { }
        public virtual Azure.ResourceManager.AppService.WebAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string backupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> GetBackupStatusSecrets(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetBackupStatusSecretsAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteConfigAppsettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>, System.Collections.IEnumerable
    {
        protected SiteConfigAppsettingCollection() { }
        public virtual Azure.Response<bool> Exists(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> Get(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>> GetAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteConfigAppsettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteConfigAppsettingResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string appSettingKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteConfigData : Azure.ResourceManager.Models.ResourceData
    {
        public SiteConfigData() { }
        public string AcrUserManagedIdentityId { get { throw null; } set { } }
        public bool? AllowIPSecurityRestrictionsForScmToUseMain { get { throw null; } set { } }
        public System.Uri ApiDefinitionUri { get { throw null; } set { } }
        public string ApiManagementConfigId { get { throw null; } set { } }
        public string AppCommandLine { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> AppSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public string AutoSwapSlotName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceStorageAccessInfo> AzureStorageAccounts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceCorsSettings Cors { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultDocuments { get { throw null; } set { } }
        public string DocumentRoot { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.RampUpRule> ExperimentsRampUpRules { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceFtpsState? FtpsState { get { throw null; } set { } }
        public int? FunctionAppScaleLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HttpRequestHandlerMapping> HandlerMappings { get { throw null; } set { } }
        public string HealthCheckPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceIPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public bool? IsAlwaysOn { get { throw null; } set { } }
        public bool? IsAutoHealEnabled { get { throw null; } set { } }
        public bool? IsDetailedErrorLoggingEnabled { get { throw null; } set { } }
        public bool? IsFunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public bool? IsHttp20Enabled { get { throw null; } set { } }
        public bool? IsHttpLoggingEnabled { get { throw null; } set { } }
        public bool? IsLocalMySqlEnabled { get { throw null; } set { } }
        public bool? IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public bool? IsRequestTracingEnabled { get { throw null; } set { } }
        public bool? IsVnetRouteAllEnabled { get { throw null; } set { } }
        public bool? IsWebSocketsEnabled { get { throw null; } set { } }
        public string JavaContainer { get { throw null; } set { } }
        public string JavaContainerVersion { get { throw null; } set { } }
        public string JavaVersion { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLimits Limits { get { throw null; } set { } }
        public string LinuxFxVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLoadBalancing? LoadBalancing { get { throw null; } set { } }
        public int? LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ManagedPipelineMode? ManagedPipelineMode { get { throw null; } set { } }
        public int? ManagedServiceIdentityId { get { throw null; } set { } }
        public int? MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion? MinTlsVersion { get { throw null; } set { } }
        public string NetFrameworkVersion { get { throw null; } set { } }
        public string NodeVersion { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public string PhpVersion { get { throw null; } set { } }
        public string PowerShellVersion { get { throw null; } set { } }
        public int? PreWarmedInstanceCount { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingUsername { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebAppPushSettings Push { get { throw null; } set { } }
        public string PythonVersion { get { throw null; } set { } }
        public string RemoteDebuggingVersion { get { throw null; } set { } }
        public System.DateTimeOffset? RequestTracingExpirationOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion? ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ScmType? ScmType { get { throw null; } set { } }
        public string TracingOptions { get { throw null; } set { } }
        public bool? Use32BitWorkerProcess { get { throw null; } set { } }
        public bool? UseManagedIdentityCreds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public int? VnetPrivatePortsCount { get { throw null; } set { } }
        public string WebsiteTimeZone { get { throw null; } set { } }
        public string WindowsFxVersion { get { throw null; } set { } }
        public int? XManagedServiceIdentityId { get { throw null; } set { } }
    }
    public partial class SiteConfigSnapshotCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteConfigSnapshotCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource> Get(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource>> GetAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteConfigSnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteConfigSnapshotResource() { }
        public virtual Azure.ResourceManager.AppService.SiteConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string snapshotId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RecoverSiteConfigurationSnapshot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecoverSiteConfigurationSnapshotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>, System.Collections.IEnumerable
    {
        protected SiteDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDeploymentResource() { }
        public virtual Azure.ResourceManager.AppService.WebAppDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> GetDeploymentLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetDeploymentLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDetectorResource>, System.Collections.IEnumerable
    {
        protected SiteDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource> Get(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource>> GetAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource> Get(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource>> GetAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDiagnosticAnalysisCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>, System.Collections.IEnumerable
    {
        protected SiteDiagnosticAnalysisCollection() { }
        public virtual Azure.Response<bool> Exists(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> Get(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>> GetAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDiagnosticAnalysisResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDiagnosticAnalysisResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteAnalysisDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string diagnosticCategory, string analysisName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticAnalysis> Execute(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticAnalysis>> ExecuteAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticResource>, System.Collections.IEnumerable
    {
        protected SiteDiagnosticCollection() { }
        public virtual Azure.Response<bool> Exists(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource> Get(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDiagnosticResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDiagnosticResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource>> GetAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDiagnosticDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>, System.Collections.IEnumerable
    {
        protected SiteDiagnosticDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> Get(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>> GetAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDiagnosticDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDiagnosticDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.DetectorDefinitionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string diagnosticCategory, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticDetectorResponse> Execute(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticDetectorResponse>> ExecuteAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDiagnosticResource() { }
        public virtual Azure.ResourceManager.AppService.DiagnosticCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string diagnosticCategory) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDiagnosticAnalysisCollection GetSiteDiagnosticAnalyses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource> GetSiteDiagnosticAnalysis(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticAnalysisResource>> GetSiteDiagnosticAnalysisAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource> GetSiteDiagnosticDetector(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticDetectorResource>> GetSiteDiagnosticDetectorAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDiagnosticDetectorCollection GetSiteDiagnosticDetectors() { throw null; }
    }
    public partial class SiteDomainOwnershipIdentifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>, System.Collections.IEnumerable
    {
        protected SiteDomainOwnershipIdentifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> Get(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> GetAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteDomainOwnershipIdentifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteDomainOwnershipIdentifierResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceIdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string domainOwnershipIdentifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> Update(Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteExtensionInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public SiteExtensionInfoData() { }
        public System.Collections.Generic.IList<string> Authors { get { throw null; } }
        public string Comment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public int? DownloadCount { get { throw null; } set { } }
        public string ExtensionId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteExtensionType? ExtensionType { get { throw null; } set { } }
        public System.Uri ExtensionUri { get { throw null; } set { } }
        public System.Uri FeedUri { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } set { } }
        public System.DateTimeOffset? InstalledOn { get { throw null; } set { } }
        public string InstallerCommandLineParams { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri LicenseUri { get { throw null; } set { } }
        public bool? LocalIsLatestVersion { get { throw null; } set { } }
        public string LocalPath { get { throw null; } set { } }
        public System.Uri ProjectUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } set { } }
        public string Summary { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SiteExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.MSDeployStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog> GetMSDeployLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog>> GetMSDeployLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteFunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteFunctionResource>, System.Collections.IEnumerable
    {
        protected SiteFunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource> Get(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteFunctionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteFunctionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource>> GetAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteFunctionResource() { }
        public virtual Azure.ResourceManager.AppService.FunctionEnvelopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo> CreateOrUpdateFunctionSecret(string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo>> CreateOrUpdateFunctionSecretAsync(string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFunctionSecret(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFunctionSecretAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetFunctionKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetFunctionKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetFunctionSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetFunctionSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteFunctionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteFunctionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteHostNameBindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteHostNameBindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteHostNameBindingResource>, System.Collections.IEnumerable
    {
        protected SiteHostNameBindingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHostNameBindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHostNameBindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource> Get(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteHostNameBindingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteHostNameBindingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource>> GetAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteHostNameBindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteHostNameBindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteHostNameBindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteHostNameBindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteHostNameBindingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteHostNameBindingResource() { }
        public virtual Azure.ResourceManager.AppService.HostNameBindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHostNameBindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHostNameBindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteHybridConnectionNamespaceRelayCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteHybridConnectionNamespaceRelayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, string relayName, Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, string relayName, Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> Get(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> GetAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteHybridConnectionNamespaceRelayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteHybridConnectionNamespaceRelayResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string namespaceName, string relayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> Update(Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> UpdateAsync(Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceResource>, System.Collections.IEnumerable
    {
        protected SiteInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource> Get(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource>> GetAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteInstanceExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteInstanceExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.MSDeployStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteInstanceExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteInstanceExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog> GetInstanceMSDeployLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog>> GetInstanceMSDeployLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteInstanceProcessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessResource>, System.Collections.IEnumerable
    {
        protected SiteInstanceProcessCollection() { }
        public virtual Azure.Response<bool> Exists(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource> Get(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteInstanceProcessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteInstanceProcessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource>> GetAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteInstanceProcessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteInstanceProcessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteInstanceProcessModuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>, System.Collections.IEnumerable
    {
        protected SiteInstanceProcessModuleCollection() { }
        public virtual Azure.Response<bool> Exists(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> Get(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>> GetAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteInstanceProcessModuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteInstanceProcessModuleResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessModuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string instanceId, string processId, string baseAddress) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteInstanceProcessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteInstanceProcessResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string instanceId, string processId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetInstanceProcessDump(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetInstanceProcessDumpAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetInstanceProcessThreads(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetInstanceProcessThreadsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource> GetSiteInstanceProcessModule(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource>> GetSiteInstanceProcessModuleAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteInstanceProcessModuleCollection GetSiteInstanceProcessModules() { throw null; }
    }
    public partial class SiteInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteInstanceResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteInstanceStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteInstanceExtensionResource GetSiteInstanceExtension() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource> GetSiteInstanceProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceProcessResource>> GetSiteInstanceProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteInstanceProcessCollection GetSiteInstanceProcesses() { throw null; }
    }
    public partial class SiteLogsConfigData : Azure.ResourceManager.Models.ResourceData
    {
        public SiteLogsConfigData() { }
        public Azure.ResourceManager.AppService.Models.ApplicationLogsConfig ApplicationLogs { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceHttpLogsConfig HttpLogs { get { throw null; } set { } }
        public bool? IsDetailedErrorMessagesEnabled { get { throw null; } set { } }
        public bool? IsFailedRequestsTracingEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class SiteNetworkConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteNetworkConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SwiftVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteNetworkConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteNetworkConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteNetworkConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteNetworkConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteNetworkConfigResource> Update(Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteNetworkConfigResource>> UpdateAsync(Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SitePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SitePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SitePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SitePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RemotePrivateEndpointConnectionARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteProcessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteProcessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteProcessResource>, System.Collections.IEnumerable
    {
        protected SiteProcessCollection() { }
        public virtual Azure.Response<bool> Exists(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource> Get(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteProcessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteProcessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource>> GetAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteProcessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteProcessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteProcessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteProcessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteProcessModuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteProcessModuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteProcessModuleResource>, System.Collections.IEnumerable
    {
        protected SiteProcessModuleCollection() { }
        public virtual Azure.Response<bool> Exists(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource> Get(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteProcessModuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteProcessModuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource>> GetAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteProcessModuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteProcessModuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteProcessModuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteProcessModuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteProcessModuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteProcessModuleResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessModuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string processId, string baseAddress) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteProcessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteProcessResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string processId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetProcessDump(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetProcessDumpAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetProcessThreads(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetProcessThreadsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource> GetSiteProcessModule(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessModuleResource>> GetSiteProcessModuleAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteProcessModuleCollection GetSiteProcessModules() { throw null; }
    }
    public partial class SitePublicCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SitePublicCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SitePublicCertificateResource>, System.Collections.IEnumerable
    {
        protected SitePublicCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePublicCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePublicCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource> Get(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SitePublicCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SitePublicCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource>> GetAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SitePublicCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SitePublicCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SitePublicCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SitePublicCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SitePublicCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SitePublicCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.PublicCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string publicCertificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePublicCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePublicCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecommendationCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteRecommendationCollection() { }
        public virtual Azure.Response<bool> Exists(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource> Get(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource>> GetAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecommendationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecommendationResource() { }
        public virtual Azure.ResourceManager.AppService.RecommendationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string name) { throw null; }
        public virtual Azure.Response Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource> Get(bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource>> GetAsync(bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotBackupResource>, System.Collections.IEnumerable
    {
        protected SiteSlotBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> Get(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotBackupResource() { }
        public virtual Azure.ResourceManager.AppService.WebAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string backupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetBackupStatusSecretsSlot(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetBackupStatusSecretsSlotAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotConfigSnapshotCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteSlotConfigSnapshotCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource> Get(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource>> GetAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotConfigSnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotConfigSnapshotResource() { }
        public virtual Azure.ResourceManager.AppService.SiteConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string snapshotId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RecoverSiteConfigurationSnapshotSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecoverSiteConfigurationSnapshotSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDeploymentResource() { }
        public virtual Azure.ResourceManager.AppService.WebAppDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> GetDeploymentLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetDeploymentLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WebAppDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDetectorResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource> Get(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource>> GetAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string slot, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource> Get(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource>> GetAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDiagnosticAnalysisCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDiagnosticAnalysisCollection() { }
        public virtual Azure.Response<bool> Exists(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> Get(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>> GetAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDiagnosticAnalysisResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDiagnosticAnalysisResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteAnalysisDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string slot, string diagnosticCategory, string analysisName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticAnalysis> ExecuteSiteAnalysisSlot(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticAnalysis>> ExecuteSiteAnalysisSlotAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDiagnosticCollection() { }
        public virtual Azure.Response<bool> Exists(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> Get(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>> GetAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDiagnosticDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDiagnosticDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> Get(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>> GetAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDiagnosticDetectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDiagnosticDetectorResource() { }
        public virtual Azure.ResourceManager.AppService.DetectorDefinitionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string slot, string diagnosticCategory, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticDetectorResponse> ExecuteSiteDetectorSlot(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DiagnosticDetectorResponse>> ExecuteSiteDetectorSlotAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDiagnosticResource() { }
        public virtual Azure.ResourceManager.AppService.DiagnosticCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string slot, string diagnosticCategory) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisCollection GetSiteSlotDiagnosticAnalyses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource> GetSiteSlotDiagnosticAnalysis(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticAnalysisResource>> GetSiteSlotDiagnosticAnalysisAsync(string analysisName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource> GetSiteSlotDiagnosticDetector(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorResource>> GetSiteSlotDiagnosticDetectorAsync(string detectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDiagnosticDetectorCollection GetSiteSlotDiagnosticDetectors() { throw null; }
    }
    public partial class SiteSlotDomainOwnershipIdentifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDomainOwnershipIdentifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> Get(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> GetAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotDomainOwnershipIdentifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotDomainOwnershipIdentifierResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceIdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string domainOwnershipIdentifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> Update(Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.MSDeployStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog> GetMSDeployLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog>> GetMSDeployLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotFunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotFunctionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotFunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource> Get(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotFunctionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotFunctionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> GetAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotFunctionResource() { }
        public virtual Azure.ResourceManager.AppService.FunctionEnvelopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo> CreateOrUpdateFunctionSecretSlot(string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo>> CreateOrUpdateFunctionSecretSlotAsync(string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFunctionSecretSlot(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFunctionSecretSlotAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetFunctionKeysSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetFunctionKeysSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetFunctionSecretsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetFunctionSecretsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotFunctionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.FunctionEnvelopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotHostNameBindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>, System.Collections.IEnumerable
    {
        protected SiteSlotHostNameBindingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> Get(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>> GetAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotHostNameBindingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotHostNameBindingResource() { }
        public virtual Azure.ResourceManager.AppService.HostNameBindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.HostNameBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotHybridConnectionNamespaceRelayCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteSlotHybridConnectionNamespaceRelayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, string relayName, Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, string relayName, Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> Get(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> GetAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotHybridConnectionNamespaceRelayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotHybridConnectionNamespaceRelayResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string namespaceName, string relayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> Update(Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> UpdateAsync(Azure.ResourceManager.AppService.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceResource>, System.Collections.IEnumerable
    {
        protected SiteSlotInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource> Get(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource>> GetAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotInstanceExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotInstanceExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.MSDeployStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.WebAppMSDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog> GetInstanceMSDeployLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppMSDeployLog>> GetInstanceMSDeployLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotInstanceProcessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>, System.Collections.IEnumerable
    {
        protected SiteSlotInstanceProcessCollection() { }
        public virtual Azure.Response<bool> Exists(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> Get(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>> GetAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotInstanceProcessModuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>, System.Collections.IEnumerable
    {
        protected SiteSlotInstanceProcessModuleCollection() { }
        public virtual Azure.Response<bool> Exists(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> Get(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>> GetAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotInstanceProcessModuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotInstanceProcessModuleResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessModuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId, string processId, string baseAddress) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotInstanceProcessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotInstanceProcessResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId, string processId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetInstanceProcessDumpSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetInstanceProcessDumpSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetInstanceProcessThreadsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetInstanceProcessThreadsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource> GetSiteSlotInstanceProcessModule(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource>> GetSiteSlotInstanceProcessModuleAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleCollection GetSiteSlotInstanceProcessModules() { throw null; }
    }
    public partial class SiteSlotInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotInstanceResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteInstanceStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource GetSiteSlotInstanceExtension() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource> GetSiteSlotInstanceProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource>> GetSiteSlotInstanceProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotInstanceProcessCollection GetSiteSlotInstanceProcesses() { throw null; }
    }
    public partial class SiteSlotNetworkConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotNetworkConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SwiftVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource> Update(Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource>> UpdateAsync(Azure.ResourceManager.AppService.SwiftVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RemotePrivateEndpointConnectionARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotProcessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessResource>, System.Collections.IEnumerable
    {
        protected SiteSlotProcessCollection() { }
        public virtual Azure.Response<bool> Exists(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource> Get(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotProcessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotProcessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource>> GetAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotProcessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotProcessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotProcessModuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>, System.Collections.IEnumerable
    {
        protected SiteSlotProcessModuleCollection() { }
        public virtual Azure.Response<bool> Exists(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> Get(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>> GetAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotProcessModuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotProcessModuleResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessModuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string processId, string baseAddress) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotProcessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotProcessResource() { }
        public virtual Azure.ResourceManager.AppService.ProcessInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string processId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetProcessDumpSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetProcessDumpSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetProcessThreadsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ProcessThreadInfo> GetProcessThreadsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource> GetSiteSlotProcessModule(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessModuleResource>> GetSiteSlotProcessModuleAsync(string baseAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotProcessModuleCollection GetSiteSlotProcessModules() { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotVirtualNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> Get(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> GetAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionGatewayCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteSlotVirtualNetworkConnectionGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Update(Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string vnetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> GetSiteSlotVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetSiteSlotVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayCollection GetSiteSlotVirtualNetworkConnectionGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> Update(Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public SiteSourceControlData() { }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.GitHubActionConfiguration GitHubActionConfiguration { get { throw null; } set { } }
        public bool? IsDeploymentRollbackEnabled { get { throw null; } set { } }
        public bool? IsGitHubAction { get { throw null; } set { } }
        public bool? IsManualIntegration { get { throw null; } set { } }
        public bool? IsMercurial { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
    }
    public partial class SiteVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteVirtualNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> Get(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> GetAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionGatewayCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteVirtualNetworkConnectionGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Update(Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceVirtualNetworkGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> GetSiteVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetSiteVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayCollection GetSiteVirtualNetworkConnectionGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> Update(Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.AppServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SlotConfigNamesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SlotConfigNamesResource() { }
        public virtual Azure.ResourceManager.AppService.SlotConfigNamesResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SlotConfigNamesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SlotConfigNamesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SlotConfigNamesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SlotConfigNamesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SlotConfigNamesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SlotConfigNamesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SlotConfigNamesResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SlotConfigNamesResourceData() { }
        public System.Collections.Generic.IList<string> AppSettingNames { get { throw null; } }
        public System.Collections.Generic.IList<string> AzureStorageConfigNames { get { throw null; } }
        public System.Collections.Generic.IList<string> ConnectionStringNames { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class StaticSiteBuildCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildResource>, System.Collections.IEnumerable
    {
        protected StaticSiteBuildCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteBuildResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteBuildResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteBuildData : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteBuildData() { }
        public string BuildId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string PullRequestTitle { get { throw null; } }
        public string SourceBranch { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps { get { throw null; } }
    }
    public partial class StaticSiteBuildResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteBuildResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> CreateOrUpdateAppSettings(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> CreateOrUpdateAppSettingsAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> CreateOrUpdateFunctionAppSettings(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> CreateOrUpdateFunctionAppSettingsAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateZipDeployment(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeployment staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateZipDeploymentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeployment staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetFunctionAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetFunctionAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverview> GetFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverview> GetFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetStaticSiteBuildAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetStaticSiteBuildAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> GetStaticSiteBuildUserProvidedFunctionApp(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> GetStaticSiteBuildUserProvidedFunctionAppAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppCollection GetStaticSiteBuildUserProvidedFunctionApps() { throw null; }
    }
    public partial class StaticSiteBuildUserProvidedFunctionAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>, System.Collections.IEnumerable
    {
        protected StaticSiteBuildUserProvidedFunctionAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> Get(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> GetAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteBuildUserProvidedFunctionAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteBuildUserProvidedFunctionAppResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string environmentName, string functionAppName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteResource>, System.Collections.IEnumerable
    {
        protected StaticSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.StaticSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.StaticSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteCustomDomainOverviewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>, System.Collections.IEnumerable
    {
        protected StaticSiteCustomDomainOverviewCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteCustomDomainOverviewData : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteCustomDomainOverviewData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CustomDomainStatus? Status { get { throw null; } }
        public string ValidationToken { get { throw null; } }
    }
    public partial class StaticSiteCustomDomainOverviewResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteCustomDomainOverviewResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateCustomDomainCanBeAddedToStaticSite(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateCustomDomainCanBeAddedToStaticSiteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StaticSiteData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AllowConfigFileUpdates { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public string ContentDistributionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CustomDomains { get { throw null; } }
        public string DefaultHostname { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResponseMessageEnvelopeRemotePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string Provider { get { throw null; } }
        public string RepositoryToken { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuDescription Sku { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteTemplate TemplateProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps { get { throw null; } }
    }
    public partial class StaticSitePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected StaticSitePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSitePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSitePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RemotePrivateEndpointConnectionARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> CreateOrUpdateAppSettings(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> CreateOrUpdateAppSettingsAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> CreateOrUpdateFunctionAppSettings(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> CreateOrUpdateFunctionAppSettingsAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationResult> CreateUserRolesInvitationLink(Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationResult>> CreateUserRolesInvitationLinkAsync(Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateZipDeploymentForStaticSite(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeployment staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateZipDeploymentForStaticSiteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeployment staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(string authprovider, string userid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string authprovider, string userid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Detach(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteStringList> GetConfiguredRoles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteStringList>> GetConfiguredRolesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetFunctionAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetFunctionAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource> GetStaticSiteBuild(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildResource>> GetStaticSiteBuildAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildCollection GetStaticSiteBuilds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource> GetStaticSiteCustomDomainOverview(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewResource>> GetStaticSiteCustomDomainOverviewAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewCollection GetStaticSiteCustomDomainOverviews() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverview> GetStaticSiteFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverview> GetStaticSiteFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> GetStaticSitePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> GetStaticSitePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionCollection GetStaticSitePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetStaticSiteSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetStaticSiteSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> GetStaticSiteUserProvidedFunctionApp(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> GetStaticSiteUserProvidedFunctionAppAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppCollection GetStaticSiteUserProvidedFunctionApps() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteUser> GetUsers(string authprovider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteUser> GetUsersAsync(string authprovider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetApiKey(Azure.ResourceManager.AppService.Models.StaticSiteResetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetApiKeyAsync(Azure.ResourceManager.AppService.Models.StaticSiteResetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource> Update(Azure.ResourceManager.AppService.Models.StaticSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.StaticSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUser> UpdateUser(string authprovider, string userid, Azure.ResourceManager.AppService.Models.StaticSiteUser staticSiteUserEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUser>> UpdateUserAsync(string authprovider, string userid, Azure.ResourceManager.AppService.Models.StaticSiteUser staticSiteUserEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteUserProvidedFunctionAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>, System.Collections.IEnumerable
    {
        protected StaticSiteUserProvidedFunctionAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> Get(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> GetAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteUserProvidedFunctionAppData : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteUserProvidedFunctionAppData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FunctionAppRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FunctionAppResourceId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class StaticSiteUserProvidedFunctionAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteUserProvidedFunctionAppResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string functionAppName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SwiftVirtualNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public SwiftVirtualNetworkData() { }
        public bool? IsSwiftSupported { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
    }
    public partial class TopLevelDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.TopLevelDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.TopLevelDomainResource>, System.Collections.IEnumerable
    {
        protected TopLevelDomainCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.TopLevelDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.TopLevelDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.TopLevelDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.TopLevelDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.TopLevelDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.TopLevelDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopLevelDomainData : Azure.ResourceManager.Models.ResourceData
    {
        public TopLevelDomainData() { }
        public bool? IsDomainPrivacySupported { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class TopLevelDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopLevelDomainResource() { }
        public virtual Azure.ResourceManager.AppService.TopLevelDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.TldLegalAgreement> GetAgreements(Azure.ResourceManager.AppService.Models.TopLevelDomainAgreementOption agreementOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.TldLegalAgreement> GetAgreementsAsync(Azure.ResourceManager.AppService.Models.TopLevelDomainAgreementOption agreementOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggeredJobHistoryData : Azure.ResourceManager.Models.ResourceData
    {
        public TriggeredJobHistoryData() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.TriggeredJobRun> Runs { get { throw null; } }
    }
    public partial class TriggeredWebJobData : Azure.ResourceManager.Models.ResourceData
    {
        public TriggeredWebJobData() { }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public System.Uri HistoryUri { get { throw null; } set { } }
        public bool? IsUsingSdk { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TriggeredJobRun LatestRun { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Uri SchedulerLogsUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
    }
    public partial class WebAppBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppBackupData() { }
        public int? BackupId { get { throw null; } }
        public string BackupName { get { throw null; } }
        public string BlobName { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceDatabaseBackupSetting> Databases { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public bool? IsScheduled { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRestoreOn { get { throw null; } }
        public string Log { get { throw null; } }
        public long? SizeInBytes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WebAppBackupStatus? Status { get { throw null; } }
        public System.Uri StorageAccountUri { get { throw null; } }
        public long? WebsiteSizeInBytes { get { throw null; } }
    }
    public partial class WebAppDeploymentData : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppDeploymentData() { }
        public string Author { get { throw null; } set { } }
        public string AuthorEmail { get { throw null; } set { } }
        public string Deployer { get { throw null; } set { } }
        public string Details { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? Status { get { throw null; } set { } }
    }
    public partial class WebJobData : Azure.ResourceManager.Models.ResourceData
    {
        public WebJobData() { }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public bool? IsUsingSdk { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
    }
    public partial class WebSiteAnalysisDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public WebSiteAnalysisDefinitionData() { }
        public string Description { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class WebSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteResource>, System.Collections.IEnumerable
    {
        protected WebSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteResource> GetAll(bool? includeSlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteResource> GetAllAsync(bool? includeSlots = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteConfigConnectionStringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>, System.Collections.IEnumerable
    {
        protected WebSiteConfigConnectionStringCollection() { }
        public virtual Azure.Response<bool> Exists(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> Get(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>> GetAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteConfigConnectionStringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteConfigConnectionStringResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string connectionStringKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SiteConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource> GetSiteConfigSnapshot(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigSnapshotResource>> GetSiteConfigSnapshotAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteConfigSnapshotCollection GetSiteConfigSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigResource> Update(Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteContinuousWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteContinuousWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteContinuousWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteContinuousWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.ContinuousWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartContinuousWebJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartContinuousWebJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopContinuousWebJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopContinuousWebJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WebSiteData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier AppServicePlanId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebSiteAvailabilityState? AvailabilityState { get { throw null; } }
        public string ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ClientCertMode? ClientCertMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CloningInfo CloningInfo { get { throw null; } set { } }
        public int? ContainerSize { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } set { } }
        public int? DailyMemoryTimeQuota { get { throw null; } set { } }
        public string DefaultHostName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledHostNames { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HostNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HostNameSslState> HostNameSslStates { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InProgressOperationId { get { throw null; } }
        public bool? IsClientAffinityEnabled { get { throw null; } set { } }
        public bool? IsClientCertEnabled { get { throw null; } set { } }
        public bool? IsDefaultContainer { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsHostNameDisabled { get { throw null; } set { } }
        public bool? IsHttpsOnly { get { throw null; } set { } }
        public bool? IsHyperV { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } set { } }
        public bool? IsScmSiteAlsoStopped { get { throw null; } set { } }
        public bool? IsStorageAccountRequired { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public int? MaxNumberOfWorkers { get { throw null; } }
        public string OutboundIPAddresses { get { throw null; } }
        public string PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RedundancyMode? RedundancyMode { get { throw null; } set { } }
        public string RepositorySiteName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset? SuspendOn { get { throw null; } }
        public string TargetSwapSlot { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceUsageState? UsageState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class WebSiteExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteExtensionResource>, System.Collections.IEnumerable
    {
        protected WebSiteExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource> Get(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource>> GetAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.SiteExtensionInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string siteExtensionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteExtensionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteFtpPublishingCredentialsPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteFtpPublishingCredentialsPolicyResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteHybridConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected WebSiteHybridConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteHybridConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteHybridConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RelayServiceConnectionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource> Update(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteInstanceStatusData : Azure.ResourceManager.Models.ResourceData
    {
        public WebSiteInstanceStatusData() { }
        public System.Uri ConsoleUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.ContainerInfo> Containers { get { throw null; } }
        public System.Uri DetectorUri { get { throw null; } set { } }
        public System.Uri HealthCheckUri { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteRuntimeState? State { get { throw null; } set { } }
        public System.Uri StatusUri { get { throw null; } set { } }
    }
    public partial class WebSitePremierAddonCollection : Azure.ResourceManager.ArmCollection
    {
        protected WebSitePremierAddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSitePremierAddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSitePremierAddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource> Get(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource>> GetAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSitePremierAddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSitePremierAddonResource() { }
        public virtual Azure.ResourceManager.AppService.PremierAddOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string premierAddOnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource> Update(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSitePrivateAccessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSitePrivateAccessResource() { }
        public virtual Azure.ResourceManager.AppService.PrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSitePrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSitePrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSitePrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSitePrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult> AnalyzeCustomHostname(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult>> AnalyzeCustomHostnameAsync(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ApplySlotConfigToProduction(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplySlotConfigToProductionAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebAppBackupData> Backup(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebAppBackupData>> BackupAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo> CreateOrUpdateHostSecret(string keyType, string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo>> CreateOrUpdateHostSecretAsync(string keyType, string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteBackupConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBackupConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteHostSecret(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteHostSecretAsync(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableAllForWebAppRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAllForWebAppRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequestInfo> DiscoverBackup(Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequestInfo>> DiscoverBackupAsync(Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateNewSitePublishingPassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateNewSitePublishingPasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteConfigData> GetAllConfigurationData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteConfigData> GetAllConfigurationDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HybridConnectionData> GetAllHybridConnectionData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HybridConnectionData>> GetAllHybridConnectionDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.PremierAddOnData> GetAllPremierAddOnData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.PremierAddOnData>> GetAllPremierAddOnDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData> GetAllRelayServiceConnectionData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebAppBackupData> GetAllSiteBackupData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebAppBackupData> GetAllSiteBackupDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetApplicationSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetApplicationSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> GetAuthSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> GetAuthSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> GetAuthSettingsV2(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> GetAuthSettingsV2Async(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary> GetAzureStorageAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary>> GetAzureStorageAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo> GetBackupConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo>> GetBackupConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetContainerLogsZip(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetContainerLogsZipAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetFunctionsAdminToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetFunctionsAdminTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForWebAppRecommendations(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForWebAppRecommendationsAsync(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionAppHostKeys> GetHostKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionAppHostKeys>> GetHostKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.LogsSiteConfigResource GetLogsSiteConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetMetadata(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetMetadataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource> GetMigrateMySqlStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource>> GetMigrateMySqlStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource> GetNetworkFeatures(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource>> GetNetworkFeaturesAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraces(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.PerfMonResponseInfo> GetPerfMonCounters(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PerfMonResponseInfo> GetPerfMonCountersAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource> GetPublishingCredentials(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource>> GetPublishingCredentialsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetPublishingProfileXmlWithSecrets(Azure.ResourceManager.AppService.Models.CsmPublishingProfile publishingProfileOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetPublishingProfileXmlWithSecretsAsync(Azure.ResourceManager.AppService.Models.CsmPublishingProfile publishingProfileOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForWebAppRecommendations(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForWebAppRecommendationsAsync(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource GetScmSiteBasicPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackup(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetSiteBackupAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteBackupCollection GetSiteBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> GetSiteConfigAppsetting(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>> GetSiteConfigAppsettingAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteConfigAppsettingCollection GetSiteConfigAppsettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> GetSiteDeployment(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetSiteDeploymentAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDeploymentCollection GetSiteDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource> GetSiteDetector(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDetectorResource>> GetSiteDetectorAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDetectorCollection GetSiteDetectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource> GetSiteDiagnostic(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDiagnosticResource>> GetSiteDiagnosticAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDiagnosticCollection GetSiteDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> GetSiteDomainOwnershipIdentifier(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> GetSiteDomainOwnershipIdentifierAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierCollection GetSiteDomainOwnershipIdentifiers() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteExtensionResource GetSiteExtension() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource> GetSiteFunction(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource>> GetSiteFunctionAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteFunctionCollection GetSiteFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource> GetSiteHostNameBinding(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHostNameBindingResource>> GetSiteHostNameBindingAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteHostNameBindingCollection GetSiteHostNameBindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> GetSiteHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> GetSiteHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayCollection GetSiteHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource> GetSiteInstance(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource>> GetSiteInstanceAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteInstanceCollection GetSiteInstances() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteNetworkConfigResource GetSiteNetworkConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag> GetSitePhpErrorLogFlag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag>> GetSitePhpErrorLogFlagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> GetSitePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> GetSitePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePrivateEndpointConnectionCollection GetSitePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource> GetSiteProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource>> GetSiteProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteProcessCollection GetSiteProcesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource> GetSitePublicCertificate(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource>> GetSitePublicCertificateAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePublicCertificateCollection GetSitePublicCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings> GetSitePushSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings>> GetSitePushSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource> GetSiteRecommendation(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource>> GetSiteRecommendationAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteRecommendationCollection GetSiteRecommendations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> GetSiteVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> GetSiteVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionCollection GetSiteVirtualNetworkConnections() { throw null; }
        public virtual Azure.ResourceManager.AppService.SlotConfigNamesResource GetSlotConfigNamesResource() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesFromProduction(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesFromProductionAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSnapshotsFromDRSecondary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSnapshotsFromDRSecondaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetSyncFunctionTriggers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetSyncFunctionTriggersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSyncStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSyncStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteConfigResource GetWebSiteConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource> GetWebSiteConfigConnectionString(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteConfigConnectionStringResource>> GetWebSiteConfigConnectionStringAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteConfigConnectionStringCollection GetWebSiteConfigConnectionStrings() { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetWebSiteContainerLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetWebSiteContainerLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource> GetWebSiteContinuousWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteContinuousWebJobResource>> GetWebSiteContinuousWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteContinuousWebJobCollection GetWebSiteContinuousWebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource> GetWebSiteExtension(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteExtensionResource>> GetWebSiteExtensionAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteExtensionCollection GetWebSiteExtensions() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteFtpPublishingCredentialsPolicyResource GetWebSiteFtpPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource> GetWebSiteHybridConnection(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteHybridConnectionResource>> GetWebSiteHybridConnectionAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteHybridConnectionCollection GetWebSiteHybridConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource> GetWebSitePremierAddon(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSitePremierAddonResource>> GetWebSitePremierAddonAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSitePremierAddonCollection GetWebSitePremierAddons() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSitePrivateAccessResource GetWebSitePrivateAccess() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteResourceHealthMetadataResource GetWebSiteResourceHealthMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource> GetWebSiteSlot(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource>> GetWebSiteSlotAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotCollection GetWebSiteSlots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> GetWebSiteSlotTriggeredWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>> GetWebSiteSlotTriggeredWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobCollection GetWebSiteSlotTriggeredWebJobs() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSourceControlResource GetWebSiteSourceControl() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource> GetWebSiteWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource>> GetWebSiteWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteWebJobCollection GetWebSiteWebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability> IsCloneable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability>> IsCloneableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.AppServiceOperation> MigrateMySql(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MigrateMySqlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.AppServiceOperation>> MigrateMySqlAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MigrateMySqlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.StorageMigrationResult> MigrateStorage(Azure.WaitUntil waitUntil, string subscriptionName, Azure.ResourceManager.AppService.Models.StorageMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.StorageMigrationResult>> MigrateStorageAsync(Azure.WaitUntil waitUntil, string subscriptionName, Azure.ResourceManager.AppService.Models.StorageMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetAllFiltersForWebAppRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAllFiltersForWebAppRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetProductionSlotConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetProductionSlotConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromBackupBlob(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromBackupBlobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromDeletedApp(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromDeletedAppAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSnapshot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSnapshotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>> StartNetworkTrace(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>>> StartNetworkTraceAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> StartWebSiteNetworkTrace(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> StartWebSiteNetworkTraceAsync(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>> StartWebSiteNetworkTraceOperation(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>>> StartWebSiteNetworkTraceOperationAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopNetworkTrace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopNetworkTraceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopWebSiteNetworkTrace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopWebSiteNetworkTraceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SwapSlotWithProduction(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SwapSlotWithProductionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncFunctionTriggers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncFunctionTriggersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncRepository(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncRepositoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> Update(Azure.ResourceManager.AppService.Models.SitePatchInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> UpdateApplicationSettings(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> UpdateApplicationSettingsAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.SitePatchInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> UpdateAuthSettings(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> UpdateAuthSettingsAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> UpdateAuthSettingsV2(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> UpdateAuthSettingsV2Async(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary> UpdateAzureStorageAccounts(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary>> UpdateAzureStorageAccountsAsync(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo> UpdateBackupConfiguration(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo>> UpdateBackupConfigurationAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> UpdateConnectionStrings(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> UpdateConnectionStringsAsync(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> UpdateMetadata(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> UpdateMetadataAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings> UpdateSitePushSettings(Azure.ResourceManager.AppService.Models.WebAppPushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings>> UpdateSitePushSettingsAsync(Azure.ResourceManager.AppService.Models.WebAppPushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteResourceHealthMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteResourceHealthMetadataResource() { }
        public virtual Azure.ResourceManager.AppService.ResourceHealthMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResourceHealthMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResourceHealthMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string slot, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string slot, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource> Get(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource>> GetAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotConfigAppSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotConfigAppSettingCollection() { }
        public virtual Azure.Response<bool> Exists(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> Get(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>> GetAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotConfigAppSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotConfigAppSettingResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string appSettingKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotConfigConnectionStringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotConfigConnectionStringCollection() { }
        public virtual Azure.Response<bool> Exists(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> Get(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>> GetAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotConfigConnectionStringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotConfigConnectionStringResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string connectionStringKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotConfigResource() { }
        public virtual Azure.ResourceManager.AppService.SiteConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfoSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfoSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource> GetSiteSlotConfigSnapshot(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource>> GetSiteSlotConfigSnapshotAsync(string snapshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotConfigSnapshotCollection GetSiteSlotConfigSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigResource> Update(Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotContinuousWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotContinuousWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotContinuousWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotContinuousWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.ContinuousWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartContinuousWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartContinuousWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopContinuousWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopContinuousWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> Get(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>> GetAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.SiteExtensionInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string siteExtensionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotFtpPublishingCredentialsPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotFtpPublishingCredentialsPolicyResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotHybridConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected WebSiteSlotHybridConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotHybridConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotHybridConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RelayServiceConnectionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource> Update(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotPremierAddOnCollection : Azure.ResourceManager.ArmCollection
    {
        protected WebSiteSlotPremierAddOnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource> Get(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource>> GetAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotPremierAddOnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotPremierAddOnResource() { }
        public virtual Azure.ResourceManager.AppService.PremierAddOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string premierAddOnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource> Update(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotPrivateAccessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotPrivateAccessResource() { }
        public virtual Azure.ResourceManager.AppService.PrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotPublicCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotPublicCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> Get(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>> GetAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotPublicCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotPublicCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.PublicCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string publicCertificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult> AnalyzeCustomHostnameSlot(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult>> AnalyzeCustomHostnameSlotAsync(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ApplySlotConfigurationSlot(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplySlotConfigurationSlotAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebAppBackupData> BackupSlot(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebAppBackupData>> BackupSlotAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo> CreateOrUpdateHostSecretSlot(string keyType, string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppKeyInfo>> CreateOrUpdateHostSecretSlotAsync(string keyType, string keyName, Azure.ResourceManager.AppService.Models.WebAppKeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteBackupConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBackupConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteHostSecretSlot(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteHostSecretSlotAsync(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequestInfo> DiscoverBackupSlot(Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequestInfo>> DiscoverBackupSlotAsync(Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateNewSitePublishingPasswordSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateNewSitePublishingPasswordSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteConfigData> GetAllConfigurationSlotData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteConfigData> GetAllConfigurationSlotDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HybridConnectionData> GetAllHybridConnectionSlotData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HybridConnectionData>> GetAllHybridConnectionSlotDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.PremierAddOnData> GetAllPremierAddOnSlotData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.PremierAddOnData>> GetAllPremierAddOnSlotDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData> GetAllRelayServiceConnectionSlotData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionSlotDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebAppBackupData> GetAllSiteBackupSlotData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebAppBackupData> GetAllSiteBackupSlotDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetApplicationSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetApplicationSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> GetAuthSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> GetAuthSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> GetAuthSettingsV2Slot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> GetAuthSettingsV2SlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary> GetAzureStorageAccountsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary>> GetAzureStorageAccountsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo> GetBackupConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo>> GetBackupConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> GetConnectionStringsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> GetConnectionStringsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetContainerLogsZipSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetContainerLogsZipSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetFunctionsAdminTokenSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetFunctionsAdminTokenSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionAppHostKeys> GetHostKeysSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionAppHostKeys>> GetHostKeysSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.LogsSiteSlotConfigResource GetLogsSiteSlotConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> GetMetadataSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> GetMetadataSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.MigrateMySqlStatusResource GetMigrateMySqlStatus() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource> GetNetworkFeature(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeatureResource>> GetNetworkFeatureAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.NetworkFeatureCollection GetNetworkFeatures() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationSlot(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationSlotAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationSlotV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTraceOperationSlotV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesSlot(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesSlotAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesSlotV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace> GetNetworkTracesSlotV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.PerfMonResponseInfo> GetPerfMonCountersSlot(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PerfMonResponseInfo> GetPerfMonCountersSlotAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResourcesSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceData> GetPrivateLinkResourcesSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource> GetPublishingCredentialsSlot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.PublishingUserResource>> GetPublishingCredentialsSlotAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetPublishingProfileXmlWithSecretsSlot(Azure.ResourceManager.AppService.Models.CsmPublishingProfile publishingProfileOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetPublishingProfileXmlWithSecretsSlotAsync(Azure.ResourceManager.AppService.Models.CsmPublishingProfile publishingProfileOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource GetScmSiteSlotBasicPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag> GetSitePhpErrorLogFlagSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag>> GetSitePhpErrorLogFlagSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings> GetSitePushSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings>> GetSitePushSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetSiteSlotBackup(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetSiteSlotBackupAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotBackupCollection GetSiteSlotBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> GetSiteSlotDeployment(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetSiteSlotDeploymentAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDeploymentCollection GetSiteSlotDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource> GetSiteSlotDetector(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDetectorResource>> GetSiteSlotDetectorAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDetectorCollection GetSiteSlotDetectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource> GetSiteSlotDiagnostic(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDiagnosticResource>> GetSiteSlotDiagnosticAsync(string diagnosticCategory, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDiagnosticCollection GetSiteSlotDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> GetSiteSlotDomainOwnershipIdentifier(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> GetSiteSlotDomainOwnershipIdentifierAsync(string domainOwnershipIdentifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierCollection GetSiteSlotDomainOwnershipIdentifiers() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotExtensionResource GetSiteSlotExtension() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource> GetSiteSlotFunction(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> GetSiteSlotFunctionAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotFunctionCollection GetSiteSlotFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource> GetSiteSlotHostNameBinding(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHostNameBindingResource>> GetSiteSlotHostNameBindingAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotHostNameBindingCollection GetSiteSlotHostNameBindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> GetSiteSlotHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> GetSiteSlotHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayCollection GetSiteSlotHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource> GetSiteSlotInstance(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource>> GetSiteSlotInstanceAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotInstanceCollection GetSiteSlotInstances() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource GetSiteSlotNetworkConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> GetSiteSlotPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> GetSiteSlotPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionCollection GetSiteSlotPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource> GetSiteSlotProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource>> GetSiteSlotProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotProcessCollection GetSiteSlotProcesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> GetSiteSlotVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> GetSiteSlotVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionCollection GetSiteSlotVirtualNetworkConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesSlot(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesSlotAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSlotSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSlotSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSlotSnapshotsFromDRSecondary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppSnapshot> GetSlotSnapshotsFromDRSecondaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetSyncFunctionTriggersSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetSyncFunctionTriggersSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSyncStatusSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSyncStatusSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesSlot(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesSlotAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetWebSiteContainerLogsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetWebSiteContainerLogsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotConfigResource GetWebSiteSlotConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource> GetWebSiteSlotConfigAppSetting(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingResource>> GetWebSiteSlotConfigAppSettingAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotConfigAppSettingCollection GetWebSiteSlotConfigAppSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource> GetWebSiteSlotConfigConnectionString(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringResource>> GetWebSiteSlotConfigConnectionStringAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotConfigConnectionStringCollection GetWebSiteSlotConfigConnectionStrings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource> GetWebSiteSlotContinuousWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobResource>> GetWebSiteSlotContinuousWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotContinuousWebJobCollection GetWebSiteSlotContinuousWebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource> GetWebSiteSlotExtension(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotExtensionResource>> GetWebSiteSlotExtensionAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotExtensionCollection GetWebSiteSlotExtensions() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotFtpPublishingCredentialsPolicyResource GetWebSiteSlotFtpPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource> GetWebSiteSlotHybridConnection(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionResource>> GetWebSiteSlotHybridConnectionAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotHybridConnectionCollection GetWebSiteSlotHybridConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource> GetWebSiteSlotPremierAddOn(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnResource>> GetWebSiteSlotPremierAddOnAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotPremierAddOnCollection GetWebSiteSlotPremierAddOns() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotPrivateAccessResource GetWebSiteSlotPrivateAccess() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource> GetWebSiteSlotPublicCertificate(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateResource>> GetWebSiteSlotPublicCertificateAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotPublicCertificateCollection GetWebSiteSlotPublicCertificates() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotResourceHealthMetadataResource GetWebSiteSlotResourceHealthMetadata() { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource GetWebSiteSlotSourceControl() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> GetWebSiteSlotWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>> GetWebSiteSlotWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotWebJobCollection GetWebSiteSlotWebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> GetWebSiteTriggeredwebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>> GetWebSiteTriggeredwebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteTriggeredwebJobCollection GetWebSiteTriggeredwebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability> IsCloneableSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability>> IsCloneableSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetSlotConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetSlotConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RestartSlot(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartSlotAsync(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromBackupBlobSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromBackupBlobSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequestInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromDeletedAppSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromDeletedAppSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSnapshotSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSnapshotSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>> StartNetworkTraceSlot(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>>> StartNetworkTraceSlotAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>> StartWebSiteNetworkTraceOperationSlot(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.WebAppNetworkTrace>>> StartWebSiteNetworkTraceOperationSlotAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> StartWebSiteNetworkTraceSlot(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> StartWebSiteNetworkTraceSlotAsync(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopNetworkTraceSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopNetworkTraceSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopWebSiteNetworkTraceSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopWebSiteNetworkTraceSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SwapSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SwapSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncFunctionsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncFunctionsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncFunctionTriggersSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncFunctionTriggersSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncRepositorySlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncRepositorySlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource> Update(Azure.ResourceManager.AppService.Models.SitePatchInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> UpdateApplicationSettingsSlot(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> UpdateApplicationSettingsSlotAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.SitePatchInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> UpdateAuthSettingsSlot(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> UpdateAuthSettingsSlotAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> UpdateAuthSettingsV2Slot(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> UpdateAuthSettingsV2SlotAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary> UpdateAzureStorageAccountsSlot(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary>> UpdateAzureStorageAccountsSlotAsync(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionary azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo> UpdateBackupConfigurationSlot(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppBackupInfo>> UpdateBackupConfigurationSlotAsync(Azure.ResourceManager.AppService.Models.WebAppBackupInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> UpdateConnectionStringsSlot(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> UpdateConnectionStringsSlotAsync(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary> UpdateMetadataSlot(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary>> UpdateMetadataSlotAsync(Azure.ResourceManager.AppService.Models.AppServiceConfigurationDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings> UpdateSitePushSettingsSlot(Azure.ResourceManager.AppService.Models.WebAppPushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.WebAppPushSettings>> UpdateSitePushSettingsSlotAsync(Azure.ResourceManager.AppService.Models.WebAppPushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotResourceHealthMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotResourceHealthMetadataResource() { }
        public virtual Azure.ResourceManager.AppService.ResourceHealthMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResourceHealthMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotResourceHealthMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotSourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotSourceControlResource() { }
        public virtual Azure.ResourceManager.AppService.SiteSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource> Update(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotSourceControlResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotTriggeredWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotTriggeredWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotTriggeredWebJobHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotTriggeredWebJobHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotTriggeredWebJobHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotTriggeredWebJobHistoryResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredJobHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotTriggeredWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotTriggeredWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryCollection GetWebSiteSlotTriggeredWebJobHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource> GetWebSiteSlotTriggeredWebJobHistory(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotTriggeredWebJobHistoryResource>> GetWebSiteSlotTriggeredWebJobHistoryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSlotWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteSlotWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteSlotWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSlotWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.WebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSlotWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteSourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteSourceControlResource() { }
        public virtual Azure.ResourceManager.AppService.SiteSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.WebSiteSourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteSourceControlResource> Update(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteSourceControlResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteTriggeredwebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteTriggeredwebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteTriggeredWebJobHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>, System.Collections.IEnumerable
    {
        protected WebSiteTriggeredWebJobHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteTriggeredWebJobHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteTriggeredWebJobHistoryResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredJobHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteTriggeredwebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteTriggeredwebJobResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredwebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryCollection GetWebSiteTriggeredWebJobHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource> GetWebSiteTriggeredWebJobHistory(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteTriggeredWebJobHistoryResource>> GetWebSiteTriggeredWebJobHistoryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunTriggeredWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunTriggeredWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebSiteWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteWebJobResource>, System.Collections.IEnumerable
    {
        protected WebSiteWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.WebSiteWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.WebSiteWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.WebSiteWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.WebSiteWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebSiteWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.WebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppService.Models
{
    public partial class AbnormalTimePeriod
    {
        public AbnormalTimePeriod() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorAbnormalTimePeriod> Events { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticSolution> Solutions { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class AnalysisDetectorEvidences
    {
        public AnalysisDetectorEvidences() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair>> Data { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DetectorDataSource DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorDefinition DetectorDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticMetricSet> Metrics { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class AppCertificatePatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppCertificatePatch() { }
        public string CanonicalName { get { throw null; } set { } }
        public byte[] CerBlob { get { throw null; } }
        public string DomainValidationMethod { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> HostNames { get { throw null; } }
        public System.DateTimeOffset? IssueOn { get { throw null; } }
        public string Issuer { get { throw null; } }
        public bool? IsValid { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? KeyVaultSecretStatus { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public byte[] PfxBlob { get { throw null; } set { } }
        public string PublicKeyHash { get { throw null; } }
        public string SelfLink { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServerFarmId { get { throw null; } set { } }
        public string SiteName { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
    }
    public partial class AppInsightsWebAppStackSettings
    {
        internal AppInsightsWebAppStackSettings() { }
        public bool? IsDefaultOff { get { throw null; } }
        public bool? IsSupported { get { throw null; } }
    }
    public partial class ApplicationLogsConfig
    {
        public ApplicationLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.AppServiceBlobStorageApplicationLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceTableStorageApplicationLogsConfig AzureTableStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebAppLogLevel? FileSystemLevel { get { throw null; } set { } }
    }
    public partial class ApplicationStack
    {
        public ApplicationStack() { }
        public string Dependency { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> Frameworks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> IsDeprecated { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StackMajorVersion> MajorVersions { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ApplicationStackResource : Azure.ResourceManager.Models.ResourceData
    {
        public ApplicationStackResource() { }
        public string Dependency { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> Frameworks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> IsDeprecated { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StackMajorVersion> MajorVersions { get { throw null; } }
        public string StackName { get { throw null; } set { } }
    }
    public partial class AppLogsConfiguration
    {
        public AppLogsConfiguration() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LogAnalyticsConfiguration LogAnalyticsConfiguration { get { throw null; } set { } }
    }
    public partial class AppRegistration
    {
        public AppRegistration() { }
        public string AppId { get { throw null; } set { } }
        public string AppSecretSettingName { get { throw null; } set { } }
    }
    public partial class AppServiceAadAllowedPrincipals
    {
        public AppServiceAadAllowedPrincipals() { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public System.Collections.Generic.IList<string> Identities { get { throw null; } }
    }
    public partial class AppServiceAadLoginFlow
    {
        public AppServiceAadLoginFlow() { }
        public bool? IsWwwAuthenticateDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginParameters { get { throw null; } }
    }
    public partial class AppServiceAadProvider
    {
        public AppServiceAadProvider() { }
        public bool? IsAutoProvisioned { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceAadLoginFlow Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceAadRegistration Registration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceAadValidation Validation { get { throw null; } set { } }
    }
    public partial class AppServiceAadRegistration
    {
        public AppServiceAadRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretCertificateIssuer { get { throw null; } set { } }
        public string ClientSecretCertificateSubjectAlternativeName { get { throw null; } set { } }
        public System.BinaryData ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string OpenIdIssuer { get { throw null; } set { } }
    }
    public partial class AppServiceAadValidation
    {
        public AppServiceAadValidation() { }
        public System.Collections.Generic.IList<string> AllowedAudiences { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DefaultAuthorizationPolicy DefaultAuthorizationPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.JwtClaimChecks JwtClaimChecks { get { throw null; } set { } }
    }
    public partial class AppServiceAppleProvider
    {
        public AppServiceAppleProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceAppleRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppServiceAppleRegistration
    {
        public AppServiceAppleRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
    }
    public partial class AppServiceArmPlan
    {
        internal AppServiceArmPlan() { }
        public string Name { get { throw null; } }
        public string Product { get { throw null; } }
        public string PromotionCode { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class AppServiceBillingMeter : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceBillingMeter() { }
        public Azure.Core.AzureLocation? BillingLocation { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Guid? MeterId { get { throw null; } set { } }
        public double? Multiplier { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string ShortName { get { throw null; } set { } }
    }
    public partial class AppServiceBlobStorageApplicationLogsConfig
    {
        public AppServiceBlobStorageApplicationLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.WebAppLogLevel? Level { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class AppServiceBlobStorageHttpLogsConfig
    {
        public AppServiceBlobStorageHttpLogsConfig() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class AppServiceCertificateDetails
    {
        internal AppServiceCertificateDetails() { }
        public string Issuer { get { throw null; } }
        public System.DateTimeOffset? NotAfter { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public string RawData { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class AppServiceCertificateEmail : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceCertificateEmail() { }
        public string EmailId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceCertificateNotRenewableReason : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceCertificateNotRenewableReason(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason left, Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason left, Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceCertificateOrderPatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceCertificateOrderPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceCertificateProperties> Certificates { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuanceOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewalTimeStamp { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateProductType? ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
    }
    public partial class AppServiceCertificatePatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceCertificatePatch() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
    }
    public partial class AppServiceCertificateProperties
    {
        public AppServiceCertificateProperties() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
    }
    public partial class AppServiceConfigurationDictionary : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceConfigurationDictionary() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class AppServiceCorsSettings
    {
        public AppServiceCorsSettings() { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public bool? IsCredentialsSupported { get { throw null; } set { } }
    }
    public partial class AppServiceDatabaseBackupSetting
    {
        public AppServiceDatabaseBackupSetting(Azure.ResourceManager.AppService.Models.AppServiceDatabaseType databaseType) { }
        public string ConnectionString { get { throw null; } set { } }
        public string ConnectionStringName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceDatabaseType DatabaseType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceDatabaseType : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceDatabaseType LocalMySql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceDatabaseType MySql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceDatabaseType PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceDatabaseType SqlAzure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceDatabaseType left, Azure.ResourceManager.AppService.Models.AppServiceDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceDatabaseType left, Azure.ResourceManager.AppService.Models.AppServiceDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceDeploymentLocations
    {
        internal AppServiceDeploymentLocations() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.HostingEnvironmentDeploymentInfo> HostingEnvironmentDeploymentInfos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceEnvironmentProperties> HostingEnvironments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceGeoRegion> Locations { get { throw null; } }
    }
    public enum AppServiceDnsType
    {
        AzureDns = 0,
        DefaultDomainRegistrarDns = 1,
    }
    public partial class AppServiceDomainNameIdentifier
    {
        public AppServiceDomainNameIdentifier() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class AppServiceDomainPatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceDomainPatch() { }
        public string AuthCode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactBilling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactRegistrant { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RegistrationContactInfo ContactTech { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsDomainPrivacyEnabled { get { throw null; } set { } }
        public bool? IsReadyForDnsRecordManagement { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDomainStatus? RegistrationStatus { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceDnsType? TargetDnsType { get { throw null; } set { } }
    }
    public enum AppServiceDomainStatus
    {
        Unknown = 0,
        Active = 1,
        Awaiting = 2,
        Cancelled = 3,
        Confiscated = 4,
        Disabled = 5,
        Excluded = 6,
        Expired = 7,
        Failed = 8,
        Held = 9,
        Locked = 10,
        Parked = 11,
        Pending = 12,
        Reserved = 13,
        Reverted = 14,
        Suspended = 15,
        Transferred = 16,
        Unlocked = 17,
        Unparked = 18,
        Updated = 19,
        JsonConverterFailed = 20,
    }
    public enum AppServiceDomainType
    {
        Regular = 0,
        SoftDeleted = 1,
    }
    public partial class AppServiceEndpointDependency
    {
        internal AppServiceEndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class AppServiceEndpointDetail
    {
        internal AppServiceEndpointDetail() { }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? Latency { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    public partial class AppServiceEnvironmentAddressResult : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceEnvironmentAddressResult() { }
        public System.Net.IPAddress InternalIPAddress { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> OutboundIPAddresses { get { throw null; } }
        public System.Net.IPAddress ServiceIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualIPMapping> VirtualIPMappings { get { throw null; } }
    }
    public partial class AppServiceEnvironmentPatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceEnvironmentPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IPSslAddressCount { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
    }
    public partial class AppServiceEnvironmentProperties
    {
        public AppServiceEnvironmentProperties(Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkProfile virtualNetwork) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IPSslAddressCount { get { throw null; } set { } }
        public bool? IsSuspended { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
    }
    public partial class AppServiceFacebookProvider
    {
        public AppServiceFacebookProvider() { }
        public string GraphApiVersion { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppServiceForwardProxy
    {
        public AppServiceForwardProxy() { }
        public Azure.ResourceManager.AppService.Models.ForwardProxyConvention? Convention { get { throw null; } set { } }
        public string CustomHostHeaderName { get { throw null; } set { } }
        public string CustomProtoHeaderName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceFtpsState : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceFtpsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceFtpsState(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceFtpsState AllAllowed { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceFtpsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceFtpsState FtpsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceFtpsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceFtpsState left, Azure.ResourceManager.AppService.Models.AppServiceFtpsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceFtpsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceFtpsState left, Azure.ResourceManager.AppService.Models.AppServiceFtpsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceGeoRegion : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceGeoRegion() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string OrgDomain { get { throw null; } }
    }
    public partial class AppServiceGitHubProvider
    {
        public AppServiceGitHubProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ClientRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppServiceGoogleProvider
    {
        public AppServiceGoogleProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ClientRegistration Registration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationAllowedAudiences { get { throw null; } }
    }
    public partial class AppServiceHostName
    {
        internal AppServiceHostName() { }
        public string AzureResourceName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceResourceType? AzureResourceType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceHostNameType? HostNameType { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SiteNames { get { throw null; } }
    }
    public enum AppServiceHostNameType
    {
        Verified = 0,
        Managed = 1,
    }
    public enum AppServiceHostType
    {
        Standard = 0,
        Repository = 1,
    }
    public partial class AppServiceHttpLogsConfig
    {
        public AppServiceHttpLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.AppServiceBlobStorageHttpLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FileSystemHttpLogsConfig FileSystem { get { throw null; } set { } }
    }
    public partial class AppServiceHttpSettings
    {
        public AppServiceHttpSettings() { }
        public Azure.ResourceManager.AppService.Models.AppServiceForwardProxy ForwardProxy { get { throw null; } set { } }
        public bool? IsHttpsRequired { get { throw null; } set { } }
        public string RoutesApiPrefix { get { throw null; } set { } }
    }
    public partial class AppServiceIdentityProviders
    {
        public AppServiceIdentityProviders() { }
        public Azure.ResourceManager.AppService.Models.AppServiceAppleProvider Apple { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceAadProvider AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceStaticWebAppsProvider AzureStaticWebApps { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceFacebookProvider Facebook { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceGitHubProvider GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceGoogleProvider Google { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LegacyMicrosoftAccount LegacyMicrosoftAccount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceTwitterProvider Twitter { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceIPFilterTag : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceIPFilterTag(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag Default { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag ServiceTag { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag XffProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag left, Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag left, Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceIPSecurityRestriction
    {
        public AppServiceIPSecurityRestriction() { }
        public string Action { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Headers { get { throw null; } }
        public string IPAddressOrCidr { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        public int? SubnetTrafficTag { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceIPFilterTag? Tag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetSubnetResourceId { get { throw null; } set { } }
        public int? VnetTrafficTag { get { throw null; } set { } }
    }
    public partial class AppServiceNameValuePair
    {
        public AppServiceNameValuePair() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AppServiceOperation
    {
        internal AppServiceOperation() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Guid? GeoMasterOperationId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceOperationStatus? Status { get { throw null; } }
    }
    public enum AppServiceOperationStatus
    {
        InProgress = 0,
        Failed = 1,
        Succeeded = 2,
        TimedOut = 3,
        Created = 4,
    }
    public partial class AppServicePlanPatch : Azure.ResourceManager.Models.ResourceData
    {
        public AppServicePlanPatch() { }
        public System.DateTimeOffset? FreeOfferExpirationOn { get { throw null; } set { } }
        public string GeoRegion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public bool? IsElasticScaleEnabled { get { throw null; } set { } }
        public bool? IsHyperV { get { throw null; } set { } }
        public bool? IsPerSiteScaling { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } set { } }
        public bool? IsSpot { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProfile KubeEnvironmentProfile { get { throw null; } set { } }
        public int? MaximumElasticWorkerCount { get { throw null; } set { } }
        public int? MaximumNumberOfWorkers { get { throw null; } }
        public int? NumberOfSites { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public System.DateTimeOffset? SpotExpirationOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServicePlanStatus? Status { get { throw null; } }
        public string Subscription { get { throw null; } }
        public int? TargetWorkerCount { get { throw null; } set { } }
        public int? TargetWorkerSizeId { get { throw null; } set { } }
        public string WorkerTierName { get { throw null; } set { } }
    }
    public enum AppServicePlanRestriction
    {
        None = 0,
        Free = 1,
        Shared = 2,
        Basic = 3,
        Standard = 4,
        Premium = 5,
    }
    public enum AppServicePlanStatus
    {
        Ready = 0,
        Pending = 1,
        Creating = 2,
    }
    public partial class AppServicePoolSkuInfo
    {
        internal AppServicePoolSkuInfo() { }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuDescription Sku { get { throw null; } }
    }
    public partial class AppServicePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal AppServicePrivateLinkResourceData() { }
        public Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class AppServicePrivateLinkResourceProperties
    {
        internal AppServicePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class AppServiceRecommendation : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceRecommendation() { }
        public string ActionName { get { throw null; } set { } }
        public string BladeName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryTags { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RecommendationChannel? Channels { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        public string ForwardLink { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.NotificationLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? NextNotificationOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotificationExpirationOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotifiedOn { get { throw null; } set { } }
        public System.Guid? RecommendationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ResourceScopeType? ResourceScope { get { throw null; } set { } }
        public string RuleName { get { throw null; } set { } }
        public double? Score { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> States { get { throw null; } }
    }
    public enum AppServiceResourceType
    {
        Website = 0,
        TrafficManager = 1,
    }
    public partial class AppServiceSkuCapability
    {
        public AppServiceSkuCapability() { }
        public string Name { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AppServiceSkuCapacity
    {
        public AppServiceSkuCapacity() { }
        public int? Default { get { throw null; } set { } }
        public int? ElasticMaximum { get { throw null; } set { } }
        public int? Maximum { get { throw null; } set { } }
        public int? Minimum { get { throw null; } set { } }
        public string ScaleType { get { throw null; } set { } }
    }
    public partial class AppServiceSkuDescription
    {
        public AppServiceSkuDescription() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceSkuCapability> Capabilities { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuCapacity SkuCapacity { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceSkuName : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Dynamic { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName ElasticIsolated { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName ElasticPremium { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Isolated { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName IsolatedV2 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName PremiumContainer { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName PremiumV3 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Shared { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceSkuName left, Azure.ResourceManager.AppService.Models.AppServiceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceSkuName left, Azure.ResourceManager.AppService.Models.AppServiceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceSkuResult
    {
        internal AppServiceSkuResult() { }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.GlobalCsmSkuDescription> Skus { get { throw null; } }
    }
    public partial class AppServiceStaticWebAppsProvider
    {
        public AppServiceStaticWebAppsProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string RegistrationClientId { get { throw null; } set { } }
    }
    public partial class AppServiceStatusInfo
    {
        public AppServiceStatusInfo() { }
        public string Message { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorInsightStatus? StatusId { get { throw null; } set { } }
    }
    public partial class AppServiceStorageAccessInfo
    {
        public AppServiceStorageAccessInfo() { }
        public string AccessKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string MountPath { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceStorageAccountState? State { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceStorageType? StorageType { get { throw null; } set { } }
    }
    public enum AppServiceStorageAccountState
    {
        Ok = 0,
        InvalidCredentials = 1,
        InvalidShare = 2,
        NotValidated = 3,
    }
    public enum AppServiceStorageType
    {
        AzureFiles = 0,
        AzureBlob = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceSupportedTlsVersion : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceSupportedTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion left, Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion left, Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceTableStorageApplicationLogsConfig
    {
        public AppServiceTableStorageApplicationLogsConfig(System.Uri sasUri) { }
        public Azure.ResourceManager.AppService.Models.WebAppLogLevel? Level { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class AppServiceTokenStore
    {
        public AppServiceTokenStore() { }
        public string AzureBlobStorageSasUrlSettingName { get { throw null; } set { } }
        public string FileSystemDirectory { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public double? TokenRefreshExtensionHours { get { throw null; } set { } }
    }
    public partial class AppServiceTwitterProvider
    {
        public AppServiceTwitterProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TwitterRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppServiceUsage : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceUsage() { }
        public Azure.ResourceManager.AppService.Models.ComputeModeOption? ComputeMode { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public long? Limit { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string SiteMode { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public enum AppServiceUsageState
    {
        Normal = 0,
        Exceeded = 1,
    }
    public partial class AppServiceValidateContent
    {
        public AppServiceValidateContent(string name, Azure.ResourceManager.AppService.Models.ValidateResourceType validateResourceType, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AppService.Models.AppServiceEnvironmentProperties AppServiceEnvironment { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public string ContainerImagePlatform { get { throw null; } set { } }
        public string ContainerImageRepository { get { throw null; } set { } }
        public string ContainerImageTag { get { throw null; } set { } }
        public System.Uri ContainerRegistryBaseUri { get { throw null; } set { } }
        public string ContainerRegistryPassword { get { throw null; } set { } }
        public string ContainerRegistryUsername { get { throw null; } set { } }
        public string HostingEnvironment { get { throw null; } set { } }
        public bool? IsSpot { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NeedLinuxWorkers { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServerFarmId { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ValidateResourceType ValidateResourceType { get { throw null; } }
    }
    public partial class AppServiceValidateResult
    {
        internal AppServiceValidateResult() { }
        public Azure.ResourceManager.AppService.Models.ValidateResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class AppServiceVirtualNetworkProfile
    {
        public AppServiceVirtualNetworkProfile(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
    }
    public partial class AppServiceVirtualNetworkProperties
    {
        internal AppServiceVirtualNetworkProperties() { }
        public string CertBlob { get { throw null; } }
        public System.BinaryData CertThumbprint { get { throw null; } }
        public string DnsServers { get { throw null; } }
        public bool? IsResyncRequired { get { throw null; } }
        public bool? IsSwift { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRoute> Routes { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetResourceId { get { throw null; } }
    }
    public partial class AppServiceVirtualNetworkRoute : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceVirtualNetworkRoute() { }
        public string EndAddress { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType? RouteType { get { throw null; } set { } }
        public string StartAddress { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceVirtualNetworkRouteType : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceVirtualNetworkRouteType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType Default { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType Inherited { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType left, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType left, Azure.ResourceManager.AppService.Models.AppServiceVirtualNetworkRouteType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceVirtualNetworkValidationContent : Azure.ResourceManager.Models.ResourceData
    {
        public AppServiceVirtualNetworkValidationContent() { }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public string VnetResourceGroup { get { throw null; } set { } }
        public string VnetSubnetName { get { throw null; } set { } }
    }
    public partial class AppSnapshot : Azure.ResourceManager.Models.ResourceData
    {
        public AppSnapshot() { }
        public string Kind { get { throw null; } set { } }
        public string Time { get { throw null; } }
    }
    public partial class ArcConfiguration
    {
        public ArcConfiguration() { }
        public Azure.ResourceManager.AppService.Models.ArtifactStorageType? ArtifactsStorageType { get { throw null; } set { } }
        public string ArtifactStorageAccessMode { get { throw null; } set { } }
        public string ArtifactStorageClassName { get { throw null; } set { } }
        public string ArtifactStorageMountPath { get { throw null; } set { } }
        public string ArtifactStorageNodeName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FrontEndServiceType? FrontEndServiceKind { get { throw null; } set { } }
        public string KubeConfig { get { throw null; } set { } }
    }
    public enum ArtifactStorageType
    {
        LocalNode = 0,
        NetworkFileSystem = 1,
    }
    public partial class AuthPlatform
    {
        public AuthPlatform() { }
        public string ConfigFilePath { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class AutoHealActions
    {
        public AutoHealActions() { }
        public Azure.ResourceManager.AppService.Models.AutoHealActionType? ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealCustomAction CustomAction { get { throw null; } set { } }
        public string MinProcessExecutionTime { get { throw null; } set { } }
    }
    public enum AutoHealActionType
    {
        Recycle = 0,
        LogEvent = 1,
        CustomAction = 2,
    }
    public partial class AutoHealCustomAction
    {
        public AutoHealCustomAction() { }
        public string Exe { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
    }
    public partial class AutoHealRules
    {
        public AutoHealRules() { }
        public Azure.ResourceManager.AppService.Models.AutoHealActions Actions { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealTriggers Triggers { get { throw null; } set { } }
    }
    public partial class AutoHealTriggers
    {
        public AutoHealTriggers() { }
        public int? PrivateBytesInKB { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RequestsBasedTrigger Requests { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SlowRequestsBasedTrigger SlowRequests { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.SlowRequestsBasedTrigger> SlowRequestsWithPath { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StatusCodesBasedTrigger> StatusCodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StatusCodesRangeBasedTrigger> StatusCodesRange { get { throw null; } }
    }
    public partial class AzureStoragePropertyDictionary : Azure.ResourceManager.Models.ResourceData
    {
        public AzureStoragePropertyDictionary() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceStorageAccessInfo> Properties { get { throw null; } }
    }
    public enum BackupFrequencyUnit
    {
        Day = 0,
        Hour = 1,
    }
    public enum BackupRestoreOperationType
    {
        Default = 0,
        Clone = 1,
        Relocation = 2,
        Snapshot = 3,
        CloudFS = 4,
    }
    public enum BuiltInAuthenticationProvider
    {
        AzureActiveDirectory = 0,
        Facebook = 1,
        Google = 2,
        MicrosoftAccount = 3,
        Twitter = 4,
        Github = 5,
    }
    public partial class CertificateOrderAction : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateOrderAction() { }
        public Azure.ResourceManager.AppService.Models.CertificateOrderActionType? ActionType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public enum CertificateOrderActionType
    {
        Unknown = 0,
        CertificateIssued = 1,
        CertificateOrderCanceled = 2,
        CertificateOrderCreated = 3,
        CertificateRevoked = 4,
        DomainValidationComplete = 5,
        FraudDetected = 6,
        OrgNameChange = 7,
        OrgValidationComplete = 8,
        SanDrop = 9,
        FraudCleared = 10,
        CertificateExpired = 11,
        CertificateExpirationWarning = 12,
        FraudDocumentationRequired = 13,
    }
    public partial class CertificateOrderContact
    {
        internal CertificateOrderContact() { }
        public string Email { get { throw null; } }
        public string NameFirst { get { throw null; } }
        public string NameLast { get { throw null; } }
        public string Phone { get { throw null; } }
    }
    public enum CertificateOrderStatus
    {
        Pendingissuance = 0,
        Issued = 1,
        Revoked = 2,
        Canceled = 3,
        Denied = 4,
        Pendingrevocation = 5,
        PendingRekey = 6,
        Unused = 7,
        Expired = 8,
        NotSubmitted = 9,
    }
    public enum CertificateProductType
    {
        StandardDomainValidatedSsl = 0,
        StandardDomainValidatedWildCardSsl = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameResourceType : System.IEquatable<Azure.ResourceManager.AppService.Models.CheckNameResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameResourceType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType HostingEnvironment { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType MicrosoftWebHostingEnvironments { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType MicrosoftWebPublishingUsers { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType MicrosoftWebSites { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType MicrosoftWebSitesSlots { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType PublishingUser { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType Slot { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceType WebSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.CheckNameResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.CheckNameResourceType left, Azure.ResourceManager.AppService.Models.CheckNameResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.CheckNameResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.CheckNameResourceType left, Azure.ResourceManager.AppService.Models.CheckNameResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ClientCertMode
    {
        Required = 0,
        Optional = 1,
        OptionalInteractiveUser = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientCredentialMethod : System.IEquatable<Azure.ResourceManager.AppService.Models.ClientCredentialMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientCredentialMethod(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ClientCredentialMethod ClientSecretPost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ClientCredentialMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ClientCredentialMethod left, Azure.ResourceManager.AppService.Models.ClientCredentialMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ClientCredentialMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ClientCredentialMethod left, Azure.ResourceManager.AppService.Models.ClientCredentialMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientRegistration
    {
        public ClientRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
    }
    public enum CloneAbilityResult
    {
        Cloneable = 0,
        PartiallyCloneable = 1,
        NotCloneable = 2,
    }
    public partial class CloningInfo
    {
        public CloningInfo(Azure.Core.ResourceIdentifier sourceWebAppId) { }
        public System.Collections.Generic.IDictionary<string, string> AppSettingsOverrides { get { throw null; } }
        public bool? CanOverwrite { get { throw null; } set { } }
        public bool? CloneCustomHostNames { get { throw null; } set { } }
        public bool? CloneSourceControl { get { throw null; } set { } }
        public bool? ConfigureLoadBalancing { get { throw null; } set { } }
        public System.Guid? CorrelationId { get { throw null; } set { } }
        public string HostingEnvironment { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceWebAppId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? SourceWebAppLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TrafficManagerProfileId { get { throw null; } set { } }
        public string TrafficManagerProfileName { get { throw null; } set { } }
    }
    public enum ComputeModeOption
    {
        Shared = 0,
        Dedicated = 1,
        Dynamic = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigReferenceSource : System.IEquatable<Azure.ResourceManager.AppService.Models.ConfigReferenceSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigReferenceSource(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ConfigReferenceSource KeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ConfigReferenceSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ConfigReferenceSource left, Azure.ResourceManager.AppService.Models.ConfigReferenceSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ConfigReferenceSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ConfigReferenceSource left, Azure.ResourceManager.AppService.Models.ConfigReferenceSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectionStringDictionary : Azure.ResourceManager.Models.ResourceData
    {
        public ConnectionStringDictionary() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.ConnStringValueTypePair> Properties { get { throw null; } }
    }
    public enum ConnectionStringType
    {
        MySql = 0,
        SqlServer = 1,
        SqlAzure = 2,
        Custom = 3,
        NotificationHub = 4,
        ServiceBus = 5,
        EventHub = 6,
        ApiHub = 7,
        DocDB = 8,
        RedisCache = 9,
        PostgreSql = 10,
    }
    public partial class ConnStringInfo
    {
        public ConnStringInfo() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ConnectionStringType? ConnectionStringType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ConnStringValueTypePair
    {
        public ConnStringValueTypePair(string value, Azure.ResourceManager.AppService.Models.ConnectionStringType connectionStringType) { }
        public Azure.ResourceManager.AppService.Models.ConnectionStringType ConnectionStringType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ContainerCpuStatistics
    {
        public ContainerCpuStatistics() { }
        public Azure.ResourceManager.AppService.Models.ContainerCpuUsage CpuUsage { get { throw null; } set { } }
        public int? OnlineCpuCount { get { throw null; } set { } }
        public long? SystemCpuUsage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContainerThrottlingInfo ThrottlingData { get { throw null; } set { } }
    }
    public partial class ContainerCpuUsage
    {
        public ContainerCpuUsage() { }
        public long? KernelModeUsage { get { throw null; } set { } }
        public System.Collections.Generic.IList<long> PerCpuUsage { get { throw null; } }
        public long? TotalUsage { get { throw null; } set { } }
        public long? UserModeUsage { get { throw null; } set { } }
    }
    public partial class ContainerInfo
    {
        public ContainerInfo() { }
        public Azure.ResourceManager.AppService.Models.ContainerCpuStatistics CurrentCpuStats { get { throw null; } set { } }
        public System.DateTimeOffset? CurrentTimeStamp { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContainerNetworkInterfaceStatistics Eth0 { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContainerMemoryStatistics MemoryStats { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContainerCpuStatistics PreviousCpuStats { get { throw null; } set { } }
        public System.DateTimeOffset? PreviousTimeStamp { get { throw null; } set { } }
    }
    public partial class ContainerMemoryStatistics
    {
        public ContainerMemoryStatistics() { }
        public long? Limit { get { throw null; } set { } }
        public long? MaxUsage { get { throw null; } set { } }
        public long? Usage { get { throw null; } set { } }
    }
    public partial class ContainerNetworkInterfaceStatistics
    {
        public ContainerNetworkInterfaceStatistics() { }
        public long? RxBytes { get { throw null; } set { } }
        public long? RxDropped { get { throw null; } set { } }
        public long? RxErrors { get { throw null; } set { } }
        public long? RxPackets { get { throw null; } set { } }
        public long? TxBytes { get { throw null; } set { } }
        public long? TxDropped { get { throw null; } set { } }
        public long? TxErrors { get { throw null; } set { } }
        public long? TxPackets { get { throw null; } set { } }
    }
    public partial class ContainerThrottlingInfo
    {
        public ContainerThrottlingInfo() { }
        public int? Periods { get { throw null; } set { } }
        public int? ThrottledPeriods { get { throw null; } set { } }
        public int? ThrottledTime { get { throw null; } set { } }
    }
    public enum ContinuousWebJobStatus
    {
        Initializing = 0,
        Starting = 1,
        Running = 2,
        PendingRestart = 3,
        Stopped = 4,
    }
    public enum CookieExpirationConvention
    {
        FixedTime = 0,
        IdentityProviderDerived = 1,
    }
    public partial class CsmOperationDescription
    {
        internal CsmOperationDescription() { }
        public Azure.ResourceManager.AppService.Models.ServiceSpecification CsmOperationDescriptionServiceSpecification { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CsmOperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
    }
    public partial class CsmOperationDisplay
    {
        internal CsmOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class CsmPublishingProfile
    {
        public CsmPublishingProfile() { }
        public Azure.ResourceManager.AppService.Models.PublishingProfileFormat? Format { get { throw null; } set { } }
        public bool? IsIncludeDisasterRecoveryEndpoints { get { throw null; } set { } }
    }
    public partial class CsmSlotEntity
    {
        public CsmSlotEntity(string targetSlot, bool preserveVnet) { }
        public bool PreserveVnet { get { throw null; } }
        public string TargetSlot { get { throw null; } }
    }
    public partial class CsmUsageQuota
    {
        internal CsmUsageQuota() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LocalizableString Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomDomainStatus : System.IEquatable<Azure.ResourceManager.AppService.Models.CustomDomainStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomDomainStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus Adding { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus RetrievingValidationToken { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CustomDomainStatus Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.CustomDomainStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.CustomDomainStatus left, Azure.ResourceManager.AppService.Models.CustomDomainStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.CustomDomainStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.CustomDomainStatus left, Azure.ResourceManager.AppService.Models.CustomDomainStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomHostnameAnalysisResult : Azure.ResourceManager.Models.ResourceData
    {
        public CustomHostnameAnalysisResult() { }
        public System.Collections.Generic.IList<string> AlternateCNameRecords { get { throw null; } }
        public System.Collections.Generic.IList<string> AlternateTxtRecords { get { throw null; } }
        public System.Collections.Generic.IList<string> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<string> CNameRecords { get { throw null; } }
        public string ConflictingAppResourceId { get { throw null; } }
        public Azure.ResponseError CustomDomainVerificationFailureInfo { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DnsVerificationTestResult? CustomDomainVerificationTest { get { throw null; } }
        public bool? HasConflictAcrossSubscription { get { throw null; } }
        public bool? HasConflictOnScaleUnit { get { throw null; } }
        public bool? IsHostnameAlreadyVerified { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TxtRecords { get { throw null; } }
    }
    public enum CustomHostNameDnsRecordType
    {
        CName = 0,
        A = 1,
    }
    public partial class CustomOpenIdConnectProvider
    {
        public CustomOpenIdConnectProvider() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectRegistration Registration { get { throw null; } set { } }
    }
    public partial class DataProviderKeyValuePair
    {
        internal DataProviderKeyValuePair() { }
        public string Key { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
    }
    public partial class DataProviderMetadata
    {
        public DataProviderMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DataProviderKeyValuePair> PropertyBag { get { throw null; } }
        public string ProviderName { get { throw null; } set { } }
    }
    public partial class DataTableResponseColumn
    {
        public DataTableResponseColumn() { }
        public string ColumnName { get { throw null; } set { } }
        public string ColumnType { get { throw null; } set { } }
        public string DataType { get { throw null; } set { } }
    }
    public partial class DataTableResponseObject
    {
        public DataTableResponseObject() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DataTableResponseColumn> Columns { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Rows { get { throw null; } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class DefaultAuthorizationPolicy
    {
        public DefaultAuthorizationPolicy() { }
        public System.Collections.Generic.IList<string> AllowedApplications { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceAadAllowedPrincipals AllowedPrincipals { get { throw null; } set { } }
    }
    public partial class DeletedAppRestoreContent : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedAppRestoreContent() { }
        public Azure.Core.ResourceIdentifier DeletedSiteId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public bool? RecoverConfiguration { get { throw null; } set { } }
        public string SnapshotTime { get { throw null; } set { } }
        public bool? UseDRSecondary { get { throw null; } set { } }
    }
    public partial class DetectorAbnormalTimePeriod
    {
        public DetectorAbnormalTimePeriod() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorIssueType? IssueType { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair>> MetaData { get { throw null; } }
        public double? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticSolution> Solutions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class DetectorDataSource
    {
        public DetectorDataSource() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> DataSourceUri { get { throw null; } }
        public System.Collections.Generic.IList<string> Instructions { get { throw null; } }
    }
    public partial class DetectorDefinition
    {
        public DetectorDefinition() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public double? Rank { get { throw null; } }
    }
    public partial class DetectorInfo
    {
        public DetectorInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AnalysisType { get { throw null; } }
        public string Author { get { throw null; } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DetectorType? DetectorType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public float? Score { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DetectorSupportTopic> SupportTopicList { get { throw null; } }
    }
    public enum DetectorInsightStatus
    {
        None = 0,
        Critical = 1,
        Warning = 2,
        Info = 3,
        Success = 4,
    }
    public enum DetectorIssueType
    {
        ServiceIncident = 0,
        AppDeployment = 1,
        AppCrash = 2,
        RuntimeIssueDetected = 3,
        AseDeployment = 4,
        UserIssue = 5,
        PlatformIssue = 6,
        Other = 7,
    }
    public partial class DetectorSupportTopic
    {
        internal DetectorSupportTopic() { }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PesId { get { throw null; } }
    }
    public enum DetectorType
    {
        Detector = 0,
        Analysis = 1,
        CategoryOverview = 2,
    }
    public partial class DiagnosticAnalysis : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticAnalysis() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AbnormalTimePeriod> AbnormalTimePeriods { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorDefinition> NonCorrelatedDetectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AnalysisDetectorEvidences> Payload { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class DiagnosticDataRendering
    {
        public DiagnosticDataRendering() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DiagnosticDataRenderingType? RenderingType { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public enum DiagnosticDataRenderingType
    {
        NoGraph = 0,
        Table = 1,
        TimeSeries = 2,
        TimeSeriesPerInstance = 3,
        PieChart = 4,
        DataSummary = 5,
        Email = 6,
        Insights = 7,
        DynamicInsight = 8,
        Markdown = 9,
        Detector = 10,
        DropDown = 11,
        Card = 12,
        Solution = 13,
        Guage = 14,
        Form = 15,
        ChangeSets = 16,
        ChangeAnalysisOnboarding = 17,
        ChangesView = 18,
        AppInsight = 19,
        DependencyGraph = 20,
        DownTime = 21,
        SummaryCard = 22,
        SearchComponent = 23,
        AppInsightEnablement = 24,
    }
    public partial class DiagnosticDataset
    {
        public DiagnosticDataset() { }
        public Azure.ResourceManager.AppService.Models.DiagnosticDataRendering RenderingProperties { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DataTableResponseObject Table { get { throw null; } set { } }
    }
    public partial class DiagnosticDetectorResponse : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticDetectorResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorAbnormalTimePeriod> AbnormalTimePeriods { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair>> Data { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DetectorDataSource DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorDefinition DetectorDefinition { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public bool? IssueDetected { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticMetricSet> Metrics { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class DiagnosticMetricSample
    {
        public DiagnosticMetricSample() { }
        public bool? IsAggregated { get { throw null; } set { } }
        public double? Maximum { get { throw null; } set { } }
        public double? Minimum { get { throw null; } set { } }
        public string RoleInstance { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public double? Total { get { throw null; } set { } }
    }
    public partial class DiagnosticMetricSet
    {
        public DiagnosticMetricSet() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticMetricSample> Values { get { throw null; } }
    }
    public partial class DiagnosticSolution
    {
        public DiagnosticSolution() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair>> Data { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public double? Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair>> Metadata { get { throw null; } }
        public double? Order { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DiagnosticSolutionType? SolutionType { get { throw null; } set { } }
    }
    public enum DiagnosticSolutionType
    {
        QuickSolution = 0,
        DeepInvestigation = 1,
        BestPractices = 2,
    }
    public enum DnsVerificationTestResult
    {
        Passed = 0,
        Failed = 1,
        Skipped = 2,
    }
    public partial class DomainAvailabilityCheckResult
    {
        internal DomainAvailabilityCheckResult() { }
        public Azure.ResourceManager.AppService.Models.AppServiceDomainType? DomainType { get { throw null; } }
        public bool? IsAvailable { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DomainControlCenterSsoRequestInfo
    {
        internal DomainControlCenterSsoRequestInfo() { }
        public string PostParameterKey { get { throw null; } }
        public string PostParameterValue { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNotRenewableReason : System.IEquatable<Azure.ResourceManager.AppService.Models.DomainNotRenewableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNotRenewableReason(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReason ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReason RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReason SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.DomainNotRenewableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.DomainNotRenewableReason left, Azure.ResourceManager.AppService.Models.DomainNotRenewableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.DomainNotRenewableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.DomainNotRenewableReason left, Azure.ResourceManager.AppService.Models.DomainNotRenewableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainPurchaseConsent
    {
        public DomainPurchaseConsent() { }
        public string AgreedBy { get { throw null; } set { } }
        public System.DateTimeOffset? AgreedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AgreementKeys { get { throw null; } }
    }
    public partial class DomainRecommendationSearchContent
    {
        public DomainRecommendationSearchContent() { }
        public string Keywords { get { throw null; } set { } }
        public int? MaxDomainRecommendations { get { throw null; } set { } }
    }
    public partial class FileSystemHttpLogsConfig
    {
        public FileSystemHttpLogsConfig() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public int? RetentionInMb { get { throw null; } set { } }
    }
    public enum ForwardProxyConvention
    {
        NoProxy = 0,
        Standard = 1,
        Custom = 2,
    }
    public enum FrontEndServiceType
    {
        NodePort = 0,
        LoadBalancer = 1,
    }
    public partial class FunctionAppHostKeys
    {
        internal FunctionAppHostKeys() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FunctionKeys { get { throw null; } }
        public string MasterKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemKeys { get { throw null; } }
    }
    public partial class FunctionAppMajorVersion
    {
        internal FunctionAppMajorVersion() { }
        public string DisplayText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.FunctionAppMinorVersion> MinorVersions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class FunctionAppMinorVersion
    {
        internal FunctionAppMinorVersion() { }
        public string DisplayText { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.FunctionAppRuntimes StackSettings { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class FunctionAppRuntimes
    {
        internal FunctionAppRuntimes() { }
        public Azure.ResourceManager.AppService.Models.FunctionAppRuntimeSettings LinuxRuntimeSettings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.FunctionAppRuntimeSettings WindowsRuntimeSettings { get { throw null; } }
    }
    public partial class FunctionAppRuntimeSettings
    {
        internal FunctionAppRuntimeSettings() { }
        public Azure.ResourceManager.AppService.Models.AppInsightsWebAppStackSettings AppInsightsSettings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AppSettingsDictionary { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.GitHubActionWebAppStackSettings GitHubActionSettings { get { throw null; } }
        public bool? IsAutoUpdate { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public bool? IsDeprecated { get { throw null; } }
        public bool? IsEarlyAccess { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public bool? IsRemoteDebuggingSupported { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SiteConfigPropertiesDictionary SiteConfigPropertiesDictionary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedFunctionsExtensionVersions { get { throw null; } }
    }
    public partial class FunctionAppStack : Azure.ResourceManager.Models.ResourceData
    {
        public FunctionAppStack() { }
        public string DisplayText { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.FunctionAppMajorVersion> MajorVersions { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.StackPreferredOS? PreferredOS { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class FunctionSecrets
    {
        internal FunctionSecrets() { }
        public string Key { get { throw null; } }
        public System.Uri TriggerUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FunctionTriggerType : System.IEquatable<Azure.ResourceManager.AppService.Models.FunctionTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FunctionTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.FunctionTriggerType HttpTrigger { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.FunctionTriggerType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.FunctionTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.FunctionTriggerType left, Azure.ResourceManager.AppService.Models.FunctionTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.FunctionTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.FunctionTriggerType left, Azure.ResourceManager.AppService.Models.FunctionTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitHubActionCodeConfiguration
    {
        public GitHubActionCodeConfiguration() { }
        public string RuntimeStack { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class GitHubActionConfiguration
    {
        public GitHubActionConfiguration() { }
        public Azure.ResourceManager.AppService.Models.GitHubActionCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.GitHubActionContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public bool? GenerateWorkflowFile { get { throw null; } set { } }
        public bool? IsLinux { get { throw null; } set { } }
    }
    public partial class GitHubActionContainerConfiguration
    {
        public GitHubActionContainerConfiguration() { }
        public string ImageName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class GitHubActionWebAppStackSettings
    {
        internal GitHubActionWebAppStackSettings() { }
        public bool? IsSupported { get { throw null; } }
        public string SupportedVersion { get { throw null; } }
    }
    public partial class GlobalCsmSkuDescription
    {
        internal GlobalCsmSkuDescription() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuCapacity Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class GlobalValidation
    {
        public GlobalValidation() { }
        public System.Collections.Generic.IList<string> ExcludedPaths { get { throw null; } }
        public bool? IsAuthenticationRequired { get { throw null; } set { } }
        public string RedirectToProvider { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.UnauthenticatedClientActionV2? UnauthenticatedClientAction { get { throw null; } set { } }
    }
    public partial class HostingEnvironmentDeploymentInfo
    {
        internal HostingEnvironmentDeploymentInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class HostingEnvironmentDiagnostics
    {
        internal HostingEnvironmentDiagnostics() { }
        public string DiagnosticsOutput { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class HostingEnvironmentProfile
    {
        public HostingEnvironmentProfile() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public enum HostingEnvironmentStatus
    {
        Preparing = 0,
        Ready = 1,
        Scaling = 2,
        Deleting = 3,
    }
    public enum HostNameBindingSslState
    {
        Disabled = 0,
        SniEnabled = 1,
        IPBasedEnabled = 2,
    }
    public partial class HostNameSslState
    {
        public HostNameSslState() { }
        public Azure.ResourceManager.AppService.Models.AppServiceHostType? HostType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HostNameBindingSslState? SslState { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public bool? ToUpdate { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } set { } }
    }
    public partial class HttpRequestHandlerMapping
    {
        public HttpRequestHandlerMapping() { }
        public string Arguments { get { throw null; } set { } }
        public string Extension { get { throw null; } set { } }
        public string ScriptProcessor { get { throw null; } set { } }
    }
    public partial class HybridConnectionKey : Azure.ResourceManager.Models.ResourceData
    {
        public HybridConnectionKey() { }
        public string Kind { get { throw null; } set { } }
        public string SendKeyName { get { throw null; } }
        public string SendKeyValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InAvailabilityReasonType : System.IEquatable<Azure.ResourceManager.AppService.Models.InAvailabilityReasonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InAvailabilityReasonType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.InAvailabilityReasonType AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.InAvailabilityReasonType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.InAvailabilityReasonType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.InAvailabilityReasonType left, Azure.ResourceManager.AppService.Models.InAvailabilityReasonType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.InAvailabilityReasonType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.InAvailabilityReasonType left, Azure.ResourceManager.AppService.Models.InAvailabilityReasonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundEnvironmentEndpoint
    {
        internal InboundEnvironmentEndpoint() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Ports { get { throw null; } }
    }
    public partial class JwtClaimChecks
    {
        public JwtClaimChecks() { }
        public System.Collections.Generic.IList<string> AllowedClientApplications { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedGroups { get { throw null; } }
    }
    public enum KeyVaultSecretStatus
    {
        Unknown = 0,
        Initialized = 1,
        WaitingOnCertificateOrder = 2,
        Succeeded = 3,
        CertificateOrderFailed = 4,
        OperationNotPermittedOnKeyVault = 5,
        AzureServiceUnauthorizedToAccessKeyVault = 6,
        KeyVaultDoesNotExist = 7,
        KeyVaultSecretDoesNotExist = 8,
        UnknownError = 9,
        ExternalPrivateKey = 10,
    }
    public partial class KubeEnvironmentPatch : Azure.ResourceManager.Models.ResourceData
    {
        public KubeEnvironmentPatch() { }
        public Azure.Core.ResourceIdentifier AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ArcConfiguration ArcConfiguration { get { throw null; } set { } }
        public string DefaultDomain { get { throw null; } }
        public string DeploymentErrors { get { throw null; } }
        public bool? IsInternalLoadBalancerEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
    }
    public partial class KubeEnvironmentProfile
    {
        public KubeEnvironmentProfile() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public enum KubeEnvironmentProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Waiting = 3,
        InitializationInProgress = 4,
        InfrastructureSetupInProgress = 5,
        InfrastructureSetupComplete = 6,
        ScheduledForDelete = 7,
        UpgradeRequested = 8,
        UpgradeFailed = 9,
    }
    public partial class LegacyMicrosoftAccount
    {
        public LegacyMicrosoftAccount() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ClientRegistration Registration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationAllowedAudiences { get { throw null; } }
    }
    public partial class LinuxJavaContainerSettings
    {
        internal LinuxJavaContainerSettings() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public bool? IsAutoUpdate { get { throw null; } }
        public bool? IsDeprecated { get { throw null; } }
        public bool? IsEarlyAccess { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public string Java11Runtime { get { throw null; } }
        public string Java8Runtime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancingMode : System.IEquatable<Azure.ResourceManager.AppService.Models.LoadBalancingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancingMode(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.LoadBalancingMode None { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.LoadBalancingMode Publishing { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.LoadBalancingMode Web { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.LoadBalancingMode WebPublishing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.LoadBalancingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.LoadBalancingMode left, Azure.ResourceManager.AppService.Models.LoadBalancingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.LoadBalancingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.LoadBalancingMode left, Azure.ResourceManager.AppService.Models.LoadBalancingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocalizableString
    {
        internal LocalizableString() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class LogAnalyticsConfiguration
    {
        public LogAnalyticsConfiguration() { }
        public string CustomerId { get { throw null; } set { } }
        public string SharedKey { get { throw null; } set { } }
    }
    public partial class LoginFlowNonceSettings
    {
        public LoginFlowNonceSettings() { }
        public string NonceExpirationInterval { get { throw null; } set { } }
        public bool? ValidateNonce { get { throw null; } set { } }
    }
    public partial class LogSpecification
    {
        internal LogSpecification() { }
        public System.TimeSpan? BlobDuration { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string LogFilterPattern { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public enum ManagedPipelineMode
    {
        Integrated = 0,
        Classic = 1,
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public System.TimeSpan? BlobDuration { get { throw null; } }
        public string TimeGrain { get { throw null; } }
    }
    public partial class MetricDimension
    {
        internal MetricDimension() { }
        public string DisplayName { get { throw null; } }
        public string InternalName { get { throw null; } }
        public bool? IsToBeExportedForShoebox { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class MetricSpecification
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.MetricAvailability> Availabilities { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.MetricDimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public bool? IsInstanceLevelAggregationSupported { get { throw null; } }
        public bool? IsInternal { get { throw null; } }
        public bool? IsRegionalMdmAccountEnabled { get { throw null; } }
        public string MetricFilterPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public string SourceMdmAccount { get { throw null; } }
        public string SourceMdmNamespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedAggregationTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTimeGrainTypes { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class MigrateMySqlContent : Azure.ResourceManager.Models.ResourceData
    {
        public MigrateMySqlContent() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.MySqlMigrationType? MigrationType { get { throw null; } set { } }
    }
    public enum MSDeployProvisioningState
    {
        Accepted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
    }
    public enum MySqlMigrationType
    {
        LocalToRemote = 0,
        RemoteToLocal = 1,
    }
    public enum NotificationLevel
    {
        Critical = 0,
        Warning = 1,
        Information = 2,
        NonUrgentSuggestion = 3,
    }
    public partial class OpenIdConnectClientCredential
    {
        public OpenIdConnectClientCredential() { }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ClientCredentialMethod? Method { get { throw null; } set { } }
    }
    public partial class OpenIdConnectConfig
    {
        public OpenIdConnectConfig() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Uri CertificationUri { get { throw null; } set { } }
        public string Issuer { get { throw null; } set { } }
        public string TokenEndpoint { get { throw null; } set { } }
        public string WellKnownOpenIdConfiguration { get { throw null; } set { } }
    }
    public partial class OpenIdConnectLogin
    {
        public OpenIdConnectLogin() { }
        public string NameClaimType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class OpenIdConnectRegistration
    {
        public OpenIdConnectRegistration() { }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectClientCredential ClientCredential { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectConfig OpenIdConnectConfiguration { get { throw null; } set { } }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceEndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class PerfMonResponseInfo
    {
        internal PerfMonResponseInfo() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.PerfMonSet Data { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class PerfMonSample
    {
        internal PerfMonSample() { }
        public string InstanceName { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    public partial class PerfMonSet
    {
        internal PerfMonSet() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.PerfMonSample> Values { get { throw null; } }
    }
    public partial class PremierAddOnOffer : Azure.ResourceManager.Models.ResourceData
    {
        public PremierAddOnOffer() { }
        public bool? IsPromoCodeRequired { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri LegalTermsUri { get { throw null; } set { } }
        public string MarketplaceOffer { get { throw null; } set { } }
        public string MarketplacePublisher { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public int? Quota { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServicePlanRestriction? WebHostingPlanRestrictions { get { throw null; } set { } }
    }
    public partial class PremierAddOnPatchResource : Azure.ResourceManager.Models.ResourceData
    {
        public PremierAddOnPatchResource() { }
        public string Kind { get { throw null; } set { } }
        public string MarketplaceOffer { get { throw null; } set { } }
        public string MarketplacePublisher { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
    }
    public partial class PrivateAccessSubnet
    {
        public PrivateAccessSubnet() { }
        public int? Key { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class PrivateAccessVirtualNetwork
    {
        public PrivateAccessVirtualNetwork() { }
        public int? Key { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.PrivateAccessSubnet> Subnets { get { throw null; } }
    }
    public partial class PrivateLinkConnectionApprovalRequestInfo : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkConnectionApprovalRequestInfo() { }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionState
    {
        public PrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class ProcessThreadInfo : Azure.ResourceManager.Models.ResourceData
    {
        public ProcessThreadInfo() { }
        public int? BasePriority { get { throw null; } set { } }
        public int? CurrentPriority { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public int? Identifier { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string PriorityLevel { get { throw null; } set { } }
        public string Process { get { throw null; } set { } }
        public string StartAddress { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        public string TotalProcessorTime { get { throw null; } set { } }
        public string UserProcessorTime { get { throw null; } set { } }
        public string WaitReason { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderOSTypeSelected : System.IEquatable<Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderOSTypeSelected(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected All { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected Linux { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected LinuxFunctions { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected Windows { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected WindowsFunctions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected left, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected left, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderStackOSType : System.IEquatable<Azure.ResourceManager.AppService.Models.ProviderStackOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderStackOSType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ProviderStackOSType All { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderStackOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ProviderStackOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ProviderStackOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ProviderStackOSType left, Azure.ResourceManager.AppService.Models.ProviderStackOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ProviderStackOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ProviderStackOSType left, Azure.ResourceManager.AppService.Models.ProviderStackOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public enum PublicCertificateLocation
    {
        Unknown = 0,
        CurrentUserMy = 1,
        LocalMachineMy = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublishingProfileFormat : System.IEquatable<Azure.ResourceManager.AppService.Models.PublishingProfileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublishingProfileFormat(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.PublishingProfileFormat FileZilla3 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.PublishingProfileFormat Ftp { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.PublishingProfileFormat WebDeploy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.PublishingProfileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.PublishingProfileFormat left, Azure.ResourceManager.AppService.Models.PublishingProfileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.PublishingProfileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.PublishingProfileFormat left, Azure.ResourceManager.AppService.Models.PublishingProfileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryUtterancesResult
    {
        public QueryUtterancesResult() { }
        public Azure.ResourceManager.AppService.Models.SampleUtterance SampleUtterance { get { throw null; } set { } }
        public float? Score { get { throw null; } set { } }
    }
    public partial class QueryUtterancesResults
    {
        public QueryUtterancesResults() { }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.QueryUtterancesResult> Results { get { throw null; } }
    }
    public partial class RampUpRule
    {
        public RampUpRule() { }
        public string ActionHostName { get { throw null; } set { } }
        public System.Uri ChangeDecisionCallbackUri { get { throw null; } set { } }
        public int? ChangeIntervalInMinutes { get { throw null; } set { } }
        public double? ChangeStep { get { throw null; } set { } }
        public double? MaxReroutePercentage { get { throw null; } set { } }
        public double? MinReroutePercentage { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public double? ReroutePercentage { get { throw null; } set { } }
    }
    public enum RecommendationChannel
    {
        Notification = 0,
        Api = 1,
        Email = 2,
        Webhook = 3,
        All = 4,
    }
    public enum RedundancyMode
    {
        None = 0,
        Manual = 1,
        Failover = 2,
        ActiveActive = 3,
        GeoRedundant = 4,
    }
    public partial class RegistrationAddressInfo
    {
        public RegistrationAddressInfo(string address1, string city, string country, string postalCode, string state) { }
        public string Address1 { get { throw null; } set { } }
        public string Address2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class RegistrationContactInfo
    {
        public RegistrationContactInfo(string email, string nameFirst, string nameLast, string phone) { }
        public Azure.ResourceManager.AppService.Models.RegistrationAddressInfo AddressMailing { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Fax { get { throw null; } set { } }
        public string JobTitle { get { throw null; } set { } }
        public string NameFirst { get { throw null; } set { } }
        public string NameLast { get { throw null; } set { } }
        public string NameMiddle { get { throw null; } set { } }
        public string Organization { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class ReissueCertificateOrderContent : Azure.ResourceManager.Models.ResourceData
    {
        public ReissueCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public int? DelayExistingRevokeInHours { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData
    {
        public RemotePrivateEndpointConnection() { }
        public System.Collections.Generic.IList<System.Net.IPAddress> IPAddresses { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class RenewCertificateOrderContent : Azure.ResourceManager.Models.ResourceData
    {
        public RenewCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class RequestsBasedTrigger
    {
        public RequestsBasedTrigger() { }
        public int? Count { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
    }
    public enum ResolveStatus
    {
        Initialized = 0,
        Resolved = 1,
        InvalidSyntax = 2,
        MSINotEnabled = 3,
        VaultNotFound = 4,
        SecretNotFound = 5,
        SecretVersionNotFound = 6,
        AccessToKeyVaultDenied = 7,
        OtherReasons = 8,
        FetchTimedOut = 9,
        UnauthorizedClient = 10,
    }
    public partial class ResourceMetricAvailability
    {
        internal ResourceMetricAvailability() { }
        public string Retention { get { throw null; } }
        public string TimeGrain { get { throw null; } }
    }
    public partial class ResourceMetricDefinition : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceMetricDefinition() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResourceMetricAvailability> MetricAvailabilities { get { throw null; } }
        public string PrimaryAggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Uri ResourceUri { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ResourceNameAvailability
    {
        internal ResourceNameAvailability() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.InAvailabilityReasonType? Reason { get { throw null; } }
    }
    public partial class ResourceNameAvailabilityContent
    {
        public ResourceNameAvailabilityContent(string name, Azure.ResourceManager.AppService.Models.CheckNameResourceType resourceType) { }
        public bool? IsFqdn { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CheckNameResourceType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceScopeType : System.IEquatable<Azure.ResourceManager.AppService.Models.ResourceScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceScopeType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ResourceScopeType ServerFarm { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ResourceScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ResourceScopeType WebSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ResourceScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ResourceScopeType left, Azure.ResourceManager.AppService.Models.ResourceScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ResourceScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ResourceScopeType left, Azure.ResourceManager.AppService.Models.ResourceScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseMessageEnvelopeRemotePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData
    {
        internal ResponseMessageEnvelopeRemotePrivateEndpointConnection() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceArmPlan Plan { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RemotePrivateEndpointConnection Properties { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceSkuDescription Sku { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class RestoreRequestInfo : Azure.ResourceManager.Models.ResourceData
    {
        public RestoreRequestInfo() { }
        public bool? AdjustConnectionStrings { get { throw null; } set { } }
        public string AppServicePlan { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public bool? CanOverwrite { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceDatabaseBackupSetting> Databases { get { throw null; } }
        public string HostingEnvironment { get { throw null; } set { } }
        public bool? IgnoreConflictingHostNames { get { throw null; } set { } }
        public bool? IgnoreDatabases { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BackupRestoreOperationType? OperationType { get { throw null; } set { } }
        public string SiteName { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
    }
    public partial class SampleUtterance
    {
        public SampleUtterance() { }
        public System.Collections.Generic.IList<string> Links { get { throw null; } }
        public string Qid { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScmType : System.IEquatable<Azure.ResourceManager.AppService.Models.ScmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScmType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ScmType BitbucketGit { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType BitbucketHg { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType CodePlexGit { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType CodePlexHg { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType Dropbox { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType ExternalGit { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType ExternalHg { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType GitHub { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType LocalGit { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType None { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType OneDrive { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType Tfs { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType VSO { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ScmType Vstsrm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ScmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ScmType left, Azure.ResourceManager.AppService.Models.ScmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ScmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ScmType left, Azure.ResourceManager.AppService.Models.ScmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSpecification
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.LogSpecification> LogSpecifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
    }
    public partial class SiteAuthSettings : Azure.ResourceManager.Models.ResourceData
    {
        public SiteAuthSettings() { }
        public string AadClaimsAuthorization { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AdditionalLoginParams { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public string AuthFilePath { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.BinaryData ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string ConfigVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BuiltInAuthenticationProvider? DefaultProvider { get { throw null; } set { } }
        public string FacebookAppId { get { throw null; } set { } }
        public string FacebookAppSecret { get { throw null; } set { } }
        public string FacebookAppSecretSettingName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FacebookOAuthScopes { get { throw null; } }
        public string GitHubClientId { get { throw null; } set { } }
        public string GitHubClientSecret { get { throw null; } set { } }
        public string GitHubClientSecretSettingName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GitHubOAuthScopes { get { throw null; } }
        public string GoogleClientId { get { throw null; } set { } }
        public string GoogleClientSecret { get { throw null; } set { } }
        public string GoogleClientSecretSettingName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GoogleOAuthScopes { get { throw null; } }
        public string IsAuthFromFile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Issuer { get { throw null; } set { } }
        public bool? IsTokenStoreEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MicrosoftAccountClientId { get { throw null; } set { } }
        public string MicrosoftAccountClientSecret { get { throw null; } set { } }
        public string MicrosoftAccountClientSecretSettingName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MicrosoftAccountOAuthScopes { get { throw null; } }
        public string RuntimeVersion { get { throw null; } set { } }
        public double? TokenRefreshExtensionHours { get { throw null; } set { } }
        public string TwitterConsumerKey { get { throw null; } set { } }
        public string TwitterConsumerSecret { get { throw null; } set { } }
        public string TwitterConsumerSecretSettingName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.UnauthenticatedClientAction? UnauthenticatedClientAction { get { throw null; } set { } }
        public bool? ValidateIssuer { get { throw null; } set { } }
    }
    public partial class SiteAuthSettingsV2 : Azure.ResourceManager.Models.ResourceData
    {
        public SiteAuthSettingsV2() { }
        public Azure.ResourceManager.AppService.Models.GlobalValidation GlobalValidation { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceHttpSettings HttpSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceIdentityProviders IdentityProviders { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebAppLoginInfo Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AuthPlatform Platform { get { throw null; } set { } }
    }
    public partial class SiteCloneability
    {
        internal SiteCloneability() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.SiteCloneabilityCriterion> BlockingCharacteristics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.SiteCloneabilityCriterion> BlockingFeatures { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CloneAbilityResult? Result { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.SiteCloneabilityCriterion> UnsupportedFeatures { get { throw null; } }
    }
    public partial class SiteCloneabilityCriterion
    {
        internal SiteCloneabilityCriterion() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SiteConfigProperties
    {
        public SiteConfigProperties() { }
        public string AcrUserManagedIdentityId { get { throw null; } set { } }
        public bool? AllowIPSecurityRestrictionsForScmToUseMain { get { throw null; } set { } }
        public System.Uri ApiDefinitionUri { get { throw null; } set { } }
        public string ApiManagementConfigId { get { throw null; } set { } }
        public string AppCommandLine { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceNameValuePair> AppSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public string AutoSwapSlotName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceStorageAccessInfo> AzureStorageAccounts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceCorsSettings Cors { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultDocuments { get { throw null; } set { } }
        public string DocumentRoot { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.RampUpRule> ExperimentsRampUpRules { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceFtpsState? FtpsState { get { throw null; } set { } }
        public int? FunctionAppScaleLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HttpRequestHandlerMapping> HandlerMappings { get { throw null; } set { } }
        public string HealthCheckPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceIPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public bool? IsAlwaysOn { get { throw null; } set { } }
        public bool? IsAutoHealEnabled { get { throw null; } set { } }
        public bool? IsDetailedErrorLoggingEnabled { get { throw null; } set { } }
        public bool? IsFunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public bool? IsHttp20Enabled { get { throw null; } set { } }
        public bool? IsHttpLoggingEnabled { get { throw null; } set { } }
        public bool? IsLocalMySqlEnabled { get { throw null; } set { } }
        public bool? IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public bool? IsRequestTracingEnabled { get { throw null; } set { } }
        public bool? IsVnetRouteAllEnabled { get { throw null; } set { } }
        public bool? IsWebSocketsEnabled { get { throw null; } set { } }
        public string JavaContainer { get { throw null; } set { } }
        public string JavaContainerVersion { get { throw null; } set { } }
        public string JavaVersion { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLimits Limits { get { throw null; } set { } }
        public string LinuxFxVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLoadBalancing? LoadBalancing { get { throw null; } set { } }
        public int? LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ManagedPipelineMode? ManagedPipelineMode { get { throw null; } set { } }
        public int? ManagedServiceIdentityId { get { throw null; } set { } }
        public int? MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion? MinTlsVersion { get { throw null; } set { } }
        public string NetFrameworkVersion { get { throw null; } set { } }
        public string NodeVersion { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public string PhpVersion { get { throw null; } set { } }
        public string PowerShellVersion { get { throw null; } set { } }
        public int? PreWarmedInstanceCount { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingUsername { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebAppPushSettings Push { get { throw null; } set { } }
        public string PythonVersion { get { throw null; } set { } }
        public string RemoteDebuggingVersion { get { throw null; } set { } }
        public System.DateTimeOffset? RequestTracingExpirationOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceSupportedTlsVersion? ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ScmType? ScmType { get { throw null; } set { } }
        public string TracingOptions { get { throw null; } set { } }
        public bool? Use32BitWorkerProcess { get { throw null; } set { } }
        public bool? UseManagedIdentityCreds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public int? VnetPrivatePortsCount { get { throw null; } set { } }
        public string WebsiteTimeZone { get { throw null; } set { } }
        public string WindowsFxVersion { get { throw null; } set { } }
        public int? XManagedServiceIdentityId { get { throw null; } set { } }
    }
    public partial class SiteConfigPropertiesDictionary
    {
        internal SiteConfigPropertiesDictionary() { }
        public string JavaVersion { get { throw null; } }
        public string LinuxFxVersion { get { throw null; } }
        public string PowerShellVersion { get { throw null; } }
        public bool? Use32BitWorkerProcess { get { throw null; } }
    }
    public partial class SiteConfigurationSnapshotInfo : Azure.ResourceManager.Models.ResourceData
    {
        public SiteConfigurationSnapshotInfo() { }
        public string Kind { get { throw null; } set { } }
        public int? SnapshotId { get { throw null; } }
        public System.DateTimeOffset? SnapshotTakenOn { get { throw null; } }
    }
    public enum SiteExtensionType
    {
        Gallery = 0,
        WebRoot = 1,
    }
    public partial class SiteLimits
    {
        public SiteLimits() { }
        public long? MaxDiskSizeInMb { get { throw null; } set { } }
        public long? MaxMemoryInMb { get { throw null; } set { } }
        public double? MaxPercentageCpu { get { throw null; } set { } }
    }
    public enum SiteLoadBalancing
    {
        WeightedRoundRobin = 0,
        LeastRequests = 1,
        LeastResponseTime = 2,
        WeightedTotalTraffic = 3,
        RequestHash = 4,
        PerSiteRoundRobin = 5,
    }
    public partial class SiteMachineKey
    {
        internal SiteMachineKey() { }
        public string Decryption { get { throw null; } }
        public string DecryptionKey { get { throw null; } }
        public string Validation { get { throw null; } }
        public string ValidationKey { get { throw null; } }
    }
    public partial class SitePatchInfo : Azure.ResourceManager.Models.ResourceData
    {
        public SitePatchInfo() { }
        public Azure.ResourceManager.AppService.Models.WebSiteAvailabilityState? AvailabilityState { get { throw null; } }
        public string ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ClientCertMode? ClientCertMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CloningInfo CloningInfo { get { throw null; } set { } }
        public int? ContainerSize { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } set { } }
        public int? DailyMemoryTimeQuota { get { throw null; } set { } }
        public string DefaultHostName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HostNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HostNameSslState> HostNameSslStates { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InProgressOperationId { get { throw null; } }
        public bool? IsClientAffinityEnabled { get { throw null; } set { } }
        public bool? IsClientCertEnabled { get { throw null; } set { } }
        public bool? IsDefaultContainer { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsHostNameDisabled { get { throw null; } set { } }
        public bool? IsHttpsOnly { get { throw null; } set { } }
        public bool? IsHyperV { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } set { } }
        public bool? IsScmSiteAlsoStopped { get { throw null; } set { } }
        public bool? IsStorageAccountRequired { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public int? MaxNumberOfWorkers { get { throw null; } }
        public string OutboundIPAddresses { get { throw null; } }
        public string PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RedundancyMode? RedundancyMode { get { throw null; } set { } }
        public string RepositorySiteName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServerFarmId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset? SuspendOn { get { throw null; } }
        public string TargetSwapSlot { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppServiceUsageState? UsageState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class SitePhpErrorLogFlag : Azure.ResourceManager.Models.ResourceData
    {
        public SitePhpErrorLogFlag() { }
        public string Kind { get { throw null; } set { } }
        public string LocalLogErrors { get { throw null; } set { } }
        public string LocalLogErrorsMaxLength { get { throw null; } set { } }
        public string MasterLogErrors { get { throw null; } set { } }
        public string MasterLogErrorsMaxLength { get { throw null; } set { } }
    }
    public enum SiteRuntimeState
    {
        Unknown = 0,
        Ready = 1,
        Stopped = 2,
    }
    public partial class SiteSeal
    {
        internal SiteSeal() { }
        public string Html { get { throw null; } }
    }
    public partial class SiteSealContent
    {
        public SiteSealContent() { }
        public bool? IsLightTheme { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
    }
    public partial class SlotDifference : Azure.ResourceManager.Models.ResourceData
    {
        public SlotDifference() { }
        public string Description { get { throw null; } }
        public string DiffRule { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Level { get { throw null; } }
        public string SettingName { get { throw null; } }
        public string SettingType { get { throw null; } }
        public string ValueInCurrentSlot { get { throw null; } }
        public string ValueInTargetSlot { get { throw null; } }
    }
    public partial class SlotSwapStatus
    {
        internal SlotSwapStatus() { }
        public string DestinationSlotName { get { throw null; } }
        public string SourceSlotName { get { throw null; } }
        public System.DateTimeOffset? TimestampUtc { get { throw null; } }
    }
    public partial class SlowRequestsBasedTrigger
    {
        public SlowRequestsBasedTrigger() { }
        public int? Count { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
        public string TimeTaken { get { throw null; } set { } }
    }
    public partial class SnapshotRecoverySource
    {
        public SnapshotRecoverySource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class SnapshotRestoreRequest : Azure.ResourceManager.Models.ResourceData
    {
        public SnapshotRestoreRequest() { }
        public bool? CanOverwrite { get { throw null; } set { } }
        public bool? IgnoreConflictingHostNames { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public bool? RecoverConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SnapshotRecoverySource RecoverySource { get { throw null; } set { } }
        public string SnapshotTime { get { throw null; } set { } }
        public bool? UseDRSecondary { get { throw null; } set { } }
    }
    public partial class StackMajorVersion
    {
        public StackMajorVersion() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AppSettingsDictionary { get { throw null; } }
        public string DisplayVersion { get { throw null; } set { } }
        public bool? IsApplicationInsights { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public bool? IsDeprecated { get { throw null; } set { } }
        public bool? IsHidden { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StackMinorVersion> MinorVersions { get { throw null; } }
        public string RuntimeVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SiteConfigPropertiesDictionary { get { throw null; } }
    }
    public partial class StackMinorVersion
    {
        public StackMinorVersion() { }
        public string DisplayVersion { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } set { } }
        public bool? IsRemoteDebuggingEnabled { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public enum StackPreferredOS
    {
        Windows = 0,
        Linux = 1,
    }
    public enum StagingEnvironmentPolicy
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class StampCapacity
    {
        internal StampCapacity() { }
        public long? AvailableCapacity { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ComputeModeOption? ComputeMode { get { throw null; } }
        public bool? ExcludeFromCapacityAllocation { get { throw null; } }
        public bool? IsApplicableForAllComputeModes { get { throw null; } }
        public bool? IsLinux { get { throw null; } }
        public string Name { get { throw null; } }
        public string SiteMode { get { throw null; } }
        public long? TotalCapacity { get { throw null; } }
        public string Unit { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WorkerSizeOption? WorkerSize { get { throw null; } }
        public int? WorkerSizeId { get { throw null; } }
    }
    public partial class StaticSiteBuildProperties
    {
        public StaticSiteBuildProperties() { }
        public string ApiBuildCommand { get { throw null; } set { } }
        public string ApiLocation { get { throw null; } set { } }
        public string AppArtifactLocation { get { throw null; } set { } }
        public string AppBuildCommand { get { throw null; } set { } }
        public string AppLocation { get { throw null; } set { } }
        public string GithubActionSecretNameOverride { get { throw null; } set { } }
        public string OutputLocation { get { throw null; } set { } }
        public bool? SkipGithubActionWorkflowGeneration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StaticSiteBuildStatus : System.IEquatable<Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StaticSiteBuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Deploying { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Detached { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus Uploading { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus WaitingForDeployment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus left, Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus left, Azure.ResourceManager.AppService.Models.StaticSiteBuildStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StaticSiteCustomDomainContent : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteCustomDomainContent() { }
        public string Kind { get { throw null; } set { } }
        public string ValidationMethod { get { throw null; } set { } }
    }
    public partial class StaticSiteFunctionOverview : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteFunctionOverview() { }
        public string FunctionName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FunctionTriggerType? TriggerType { get { throw null; } }
    }
    public partial class StaticSitePatch : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSitePatch() { }
        public bool? AllowConfigFileUpdates { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public string ContentDistributionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CustomDomains { get { throw null; } }
        public string DefaultHostname { get { throw null; } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResponseMessageEnvelopeRemotePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string Provider { get { throw null; } }
        public string RepositoryToken { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteTemplate TemplateProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps { get { throw null; } }
    }
    public partial class StaticSiteResetContent : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteResetContent() { }
        public string Kind { get { throw null; } set { } }
        public string RepositoryToken { get { throw null; } set { } }
        public bool? ShouldUpdateRepository { get { throw null; } set { } }
    }
    public partial class StaticSiteStringList : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteStringList() { }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Properties { get { throw null; } }
    }
    public partial class StaticSitesWorkflowPreview : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSitesWorkflowPreview() { }
        public string Contents { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Path { get { throw null; } }
    }
    public partial class StaticSitesWorkflowPreviewContent : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSitesWorkflowPreviewContent() { }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
    }
    public partial class StaticSiteTemplate
    {
        public StaticSiteTemplate() { }
        public string Description { get { throw null; } set { } }
        public bool? IsPrivate { get { throw null; } set { } }
        public string Owner { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public System.Uri TemplateRepositoryUri { get { throw null; } set { } }
    }
    public partial class StaticSiteUser : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteUser() { }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string Provider { get { throw null; } }
        public string Roles { get { throw null; } set { } }
        public string UserId { get { throw null; } }
    }
    public partial class StaticSiteUserInvitationContent : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteUserInvitationContent() { }
        public string Domain { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? NumHoursToExpiration { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string Roles { get { throw null; } set { } }
        public string UserDetails { get { throw null; } set { } }
    }
    public partial class StaticSiteUserInvitationResult : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteUserInvitationResult() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri InvitationUri { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class StaticSiteZipDeployment : Azure.ResourceManager.Models.ResourceData
    {
        public StaticSiteZipDeployment() { }
        public System.Uri ApiZipUri { get { throw null; } set { } }
        public System.Uri AppZipUri { get { throw null; } set { } }
        public string DeploymentTitle { get { throw null; } set { } }
        public string FunctionLanguage { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
    }
    public partial class StatusCodesBasedTrigger
    {
        public StatusCodesBasedTrigger() { }
        public int? Count { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public int? Status { get { throw null; } set { } }
        public int? SubStatus { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
        public int? Win32Status { get { throw null; } set { } }
    }
    public partial class StatusCodesRangeBasedTrigger
    {
        public StatusCodesRangeBasedTrigger() { }
        public int? Count { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string StatusCodes { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
    }
    public partial class StorageMigrationContent : Azure.ResourceManager.Models.ResourceData
    {
        public StorageMigrationContent() { }
        public string AzurefilesConnectionString { get { throw null; } set { } }
        public string AzurefilesShare { get { throw null; } set { } }
        public bool? BlockWriteAccessToSite { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public bool? SwitchSiteAfterMigration { get { throw null; } set { } }
    }
    public partial class StorageMigrationResult : Azure.ResourceManager.Models.ResourceData
    {
        public StorageMigrationResult() { }
        public string Kind { get { throw null; } set { } }
        public string OperationId { get { throw null; } }
    }
    public partial class TldLegalAgreement
    {
        internal TldLegalAgreement() { }
        public string AgreementKey { get { throw null; } }
        public string Content { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class TopLevelDomainAgreementOption
    {
        public TopLevelDomainAgreementOption() { }
        public bool? IncludePrivacy { get { throw null; } set { } }
        public bool? IsForTransfer { get { throw null; } set { } }
    }
    public partial class TriggeredJobRun
    {
        public TriggeredJobRun() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Uri ErrorUri { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public System.Uri OutputUri { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TriggeredWebJobStatus? Status { get { throw null; } set { } }
        public string Trigger { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string WebJobId { get { throw null; } set { } }
        public string WebJobName { get { throw null; } set { } }
    }
    public enum TriggeredWebJobStatus
    {
        Success = 0,
        Failed = 1,
        Error = 2,
    }
    public partial class TwitterRegistration
    {
        public TwitterRegistration() { }
        public string ConsumerKey { get { throw null; } set { } }
        public string ConsumerSecretSettingName { get { throw null; } set { } }
    }
    public enum UnauthenticatedClientAction
    {
        RedirectToLoginPage = 0,
        AllowAnonymous = 1,
    }
    public enum UnauthenticatedClientActionV2
    {
        RedirectToLoginPage = 0,
        AllowAnonymous = 1,
        Return401 = 2,
        Return403 = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidateResourceType : System.IEquatable<Azure.ResourceManager.AppService.Models.ValidateResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidateResourceType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceType MicrosoftWebHostingEnvironments { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceType ServerFarm { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceType WebSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ValidateResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ValidateResourceType left, Azure.ResourceManager.AppService.Models.ValidateResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ValidateResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ValidateResourceType left, Azure.ResourceManager.AppService.Models.ValidateResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateResponseError
    {
        internal ValidateResponseError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class VirtualApplication
    {
        public VirtualApplication() { }
        public bool? IsPreloadEnabled { get { throw null; } set { } }
        public string PhysicalPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualDirectory> VirtualDirectories { get { throw null; } }
        public string VirtualPath { get { throw null; } set { } }
    }
    public partial class VirtualDirectory
    {
        public VirtualDirectory() { }
        public string PhysicalPath { get { throw null; } set { } }
        public string VirtualPath { get { throw null; } set { } }
    }
    public partial class VirtualIPMapping
    {
        public VirtualIPMapping() { }
        public int? InternalHttpPort { get { throw null; } set { } }
        public int? InternalHttpsPort { get { throw null; } set { } }
        public bool? IsInUse { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } set { } }
    }
    public partial class VirtualNetworkValidationFailureDetails : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkValidationFailureDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualNetworkValidationTestFailure> FailedTests { get { throw null; } }
        public bool? IsFailed { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualNetworkValidationTestFailure> Warnings { get { throw null; } }
    }
    public partial class VirtualNetworkValidationTestFailure : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkValidationTestFailure() { }
        public string Details { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string TestName { get { throw null; } set { } }
    }
    public partial class WebAppBackupInfo : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppBackupInfo() { }
        public string BackupName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebAppBackupSchedule BackupSchedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AppServiceDatabaseBackupSetting> Databases { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
    }
    public partial class WebAppBackupSchedule
    {
        public WebAppBackupSchedule(int frequencyInterval, Azure.ResourceManager.AppService.Models.BackupFrequencyUnit frequencyUnit, bool shouldKeepAtLeastOneBackup, int retentionPeriodInDays) { }
        public int FrequencyInterval { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BackupFrequencyUnit FrequencyUnit { get { throw null; } set { } }
        public System.DateTimeOffset? LastExecutedOn { get { throw null; } }
        public int RetentionPeriodInDays { get { throw null; } set { } }
        public bool ShouldKeepAtLeastOneBackup { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public enum WebAppBackupStatus
    {
        InProgress = 0,
        Failed = 1,
        Succeeded = 2,
        TimedOut = 3,
        Created = 4,
        Skipped = 5,
        PartiallySucceeded = 6,
        DeleteInProgress = 7,
        DeleteFailed = 8,
        Deleted = 9,
    }
    public partial class WebAppCookieExpiration
    {
        public WebAppCookieExpiration() { }
        public Azure.ResourceManager.AppService.Models.CookieExpirationConvention? Convention { get { throw null; } set { } }
        public string TimeToExpiration { get { throw null; } set { } }
    }
    public partial class WebAppKeyInfo
    {
        public WebAppKeyInfo() { }
        public WebAppKeyInfo(string name, string value = null) { }
        public Azure.ResourceManager.AppService.Models.WebAppKeyProperties Properties { get { throw null; } set { } }
    }
    public partial class WebAppKeyProperties
    {
        public WebAppKeyProperties() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class WebAppLoginInfo
    {
        public WebAppLoginInfo() { }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WebAppCookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LoginFlowNonceSettings Nonce { get { throw null; } set { } }
        public bool? PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public string RoutesLogoutEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServiceTokenStore TokenStore { get { throw null; } set { } }
    }
    public enum WebAppLogLevel
    {
        Off = 0,
        Verbose = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
    }
    public partial class WebAppMajorVersion
    {
        internal WebAppMajorVersion() { }
        public string DisplayText { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.WebAppMinorVersion> MinorVersions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class WebAppMinorVersion
    {
        internal WebAppMinorVersion() { }
        public string DisplayText { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WebAppRuntimes StackSettings { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class WebAppMSDeploy : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppMSDeploy() { }
        public string ConnectionString { get { throw null; } set { } }
        public string DBType { get { throw null; } set { } }
        public bool? IsAppOffline { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Uri PackageUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SetParameters { get { throw null; } }
        public System.Uri SetParametersXmlFileUri { get { throw null; } set { } }
        public bool? SkipAppData { get { throw null; } set { } }
    }
    public partial class WebAppMSDeployLog : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppMSDeployLog() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.WebAppMSDeployLogEntry> Entries { get { throw null; } }
        public string Kind { get { throw null; } set { } }
    }
    public partial class WebAppMSDeployLogEntry
    {
        internal WebAppMSDeployLogEntry() { }
        public Azure.ResourceManager.AppService.Models.WebAppMSDeployLogEntryType? EntryType { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public enum WebAppMSDeployLogEntryType
    {
        Message = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class WebAppNetworkTrace
    {
        internal WebAppNetworkTrace() { }
        public string Message { get { throw null; } }
        public string Path { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class WebAppPushSettings : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppPushSettings() { }
        public string DynamicTagsJson { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string TagsRequiringAuth { get { throw null; } set { } }
        public string TagWhitelistJson { get { throw null; } set { } }
    }
    public partial class WebAppRuntimes
    {
        internal WebAppRuntimes() { }
        public Azure.ResourceManager.AppService.Models.LinuxJavaContainerSettings LinuxContainerSettings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WebAppRuntimeSettings LinuxRuntimeSettings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WindowsJavaContainerSettings WindowsContainerSettings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WebAppRuntimeSettings WindowsRuntimeSettings { get { throw null; } }
    }
    public partial class WebAppRuntimeSettings
    {
        internal WebAppRuntimeSettings() { }
        public Azure.ResourceManager.AppService.Models.AppInsightsWebAppStackSettings AppInsightsSettings { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.GitHubActionWebAppStackSettings GitHubActionSettings { get { throw null; } }
        public bool? IsAutoUpdate { get { throw null; } }
        public bool? IsDeprecated { get { throw null; } }
        public bool? IsEarlyAccess { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public bool? IsRemoteDebuggingSupported { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
    }
    public partial class WebAppStack : Azure.ResourceManager.Models.ResourceData
    {
        public WebAppStack() { }
        public string DisplayText { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.WebAppMajorVersion> MajorVersions { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.StackPreferredOS? PreferredOS { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum WebJobType
    {
        Continuous = 0,
        Triggered = 1,
    }
    public enum WebSiteAvailabilityState
    {
        Normal = 0,
        Limited = 1,
        DisasterRecoveryMode = 2,
    }
    public partial class WindowsJavaContainerSettings
    {
        internal WindowsJavaContainerSettings() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public bool? IsAutoUpdate { get { throw null; } }
        public bool? IsDeprecated { get { throw null; } }
        public bool? IsEarlyAccess { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public string JavaContainer { get { throw null; } }
        public string JavaContainerVersion { get { throw null; } }
    }
    public enum WorkerSizeOption
    {
        Small = 0,
        Medium = 1,
        Large = 2,
        D1 = 3,
        D2 = 4,
        D3 = 5,
        SmallV3 = 6,
        MediumV3 = 7,
        LargeV3 = 8,
        NestedSmall = 9,
        NestedSmallLinux = 10,
        Default = 11,
    }
}
