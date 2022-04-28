namespace Azure.ResourceManager.AppService
{
    public partial class AnalysisDefinitionData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AnalysisDefinitionData() { }
        public string Description { get { throw null; } }
    }
    public partial class ApiKeyVaultReferenceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ApiKeyVaultReferenceData() { }
        public string ActiveVersion { get { throw null; } set { } }
        public string Details { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity IdentityType { get { throw null; } set { } }
        public string Reference { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ResolveStatus? Status { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
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
    public partial class AppServiceCertificateOrderData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public AppServiceCertificateOrderData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public bool? AutoRenew { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceCertificate> Certificates { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails Intermediate { get { throw null; } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuanceOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewalTimeStamp { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateProductType? ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
    }
    public partial class AppServiceCertificateOrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateOrderResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> GetAppServiceCertificateResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> GetAppServiceCertificateResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateResourceCollection GetAppServiceCertificateResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource> GetCertificateOrderDetector(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateOrderDetectorResource>> GetCertificateOrderDetectorAsync(string detectorName, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.CertificateOrderDetectorCollection GetCertificateOrderDetectors() { throw null; }
        public virtual Azure.Response Reissue(Azure.ResourceManager.AppService.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReissueAsync(Azure.ResourceManager.AppService.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Renew(Azure.ResourceManager.AppService.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(Azure.ResourceManager.AppService.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendEmail(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendEmailAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendRequestEmails(Azure.ResourceManager.AppService.Models.NameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendRequestEmailsAsync(Azure.ResourceManager.AppService.Models.NameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CertificateOrderAction> RetrieveCertificateActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CertificateOrderAction> RetrieveCertificateActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CertificateEmail> RetrieveCertificateEmailHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CertificateEmail> RetrieveCertificateEmailHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteSeal> RetrieveSiteSeal(Azure.ResourceManager.AppService.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteSeal>> RetrieveSiteSealAsync(Azure.ResourceManager.AppService.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> Update(Azure.ResourceManager.AppService.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyDomainOwnership(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyDomainOwnershipAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceCertificateResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource> Update(Azure.ResourceManager.AppService.Models.AppServiceCertificateResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceCertificateResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceCertificateResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.AppServiceCertificateResource>, System.Collections.IEnumerable
    {
        protected AppServiceCertificateResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceCertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.AppServiceCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.AppServiceCertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AppServiceCertificateResourceData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public AppServiceCertificateResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
    }
    public partial class AppServiceDetectorData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceDetectorData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DataProviderMetadata> DataProvidersMetadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticData> Dataset { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DetectorInfo Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OperationStatusAutoGenerated Status { get { throw null; } set { } }
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
    public partial class AppServiceDomainData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public AppServiceDomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AuthCode { get { throw null; } set { } }
        public bool? AutoRenew { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactBilling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactRegistrant { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactTech { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.HostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public bool? Privacy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? ReadyForDnsRecordManagement { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DomainStatus? RegistrationStatus { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DnsType? TargetDnsType { get { throw null; } set { } }
    }
    public partial class AppServiceDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceDomainResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource> GetDomainOwnershipIdentifier(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource>> GetDomainOwnershipIdentifierAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.DomainOwnershipIdentifierCollection GetDomainOwnershipIdentifiers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Renew(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AppServiceEnvironmentData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public AppServiceEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IpsslAddressCount { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public bool? Suspended { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.VirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class AppServiceEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceEnvironmentResource() { }
        public virtual Azure.ResourceManager.AppService.AppServiceEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableAllForHostingEnvironmentRecommendation(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAllForHostingEnvironmentRecommendationAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.OperationInformation> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.OperationInformation> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForHostingEnvironmentRecommendations(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForHostingEnvironmentRecommendationsAsync(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AddressResponse> GetVipInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AddressResponse>> GetVipInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebApps(string propertiesToInclude = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebAppsAsync(string propertiesToInclude = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reboot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetAllFiltersForHostingEnvironmentRecommendation(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAllFiltersForHostingEnvironmentRecommendationAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource> Update(Azure.ResourceManager.AppService.Models.AppServiceEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceEnvironmentResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServiceEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AppServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppService.Models.ResourceNameAvailability> CheckAppServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, Azure.ResourceManager.AppService.Models.CheckNameResourceTypes type, bool? isFqdn = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ResourceNameAvailability>> CheckAppServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, Azure.ResourceManager.AppService.Models.CheckNameResourceTypes type, bool? isFqdn = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.DomainAvailabilityCheckResult> CheckAvailabilityDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.NameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DomainAvailabilityCheckResult>> CheckAvailabilityDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.NameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DisableRecommendationForSubscriptionRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DisableRecommendationForSubscriptionRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource> GetAllResourceHealthMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource> GetAllResourceHealthMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource> GetAllResourceHealthMetadataByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource> GetAllResourceHealthMetadataByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrder(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource>> GetAppServiceCertificateOrderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateOrderCollection GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServiceCertificateOrderResource> GetAppServiceCertificateOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AppServiceCertificateResource GetAppServiceCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource> GetAppServiceDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServiceDomainResource>> GetAppServiceDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.AppService.AppServicePlanResource GetAppServicePlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.AppServicePlanCollection GetAppServicePlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.AppServicePlanResource> GetAppServicePlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.AseV3NetworkingConfigurationResource GetAseV3NetworkingConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksOnPremProviders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksOnPremProvidersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ApplicationStackResource> GetAvailableStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected? osTypeSelected = default(Azure.ResourceManager.AppService.Models.ProviderOSTypeSelected?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource GetBasicPublishingCredentialsPolicyFtpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.BillingMeter> GetBillingMeters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingLocation = null, string osType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.BillingMeter> GetBillingMetersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingLocation = null, string osType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.CertificateResource> GetCertificate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> GetCertificateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.CertificateOrderDetectorResource GetCertificateOrderDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.CertificateCollection GetCertificates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.CertificateResource> GetCertificates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.CertificateResource> GetCertificatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.DomainControlCenterSsoRequest> GetControlCenterSsoRequestDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DomainControlCenterSsoRequest>> GetControlCenterSsoRequestDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSite(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetDeletedSiteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.DeletedSiteResource GetDeletedSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.DeletedSiteCollection GetDeletedSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSitesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedSitesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource> GetDeletedWebAppByLocationDeletedWebApp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.DeletedSiteResource>> GetDeletedWebAppByLocationDeletedWebAppAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string deletedSiteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource GetFtpSiteSlotBasicPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksForLocationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.FunctionAppStack> GetFunctionAppStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.GeoRegion> GetGeoRegions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceSkuName? sku = default(Azure.ResourceManager.AppService.Models.AppServiceSkuName?), bool? linuxWorkersEnabled = default(bool?), bool? xenonWorkersEnabled = default(bool?), bool? linuxDynamicWorkersEnabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.GeoRegion> GetGeoRegionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.AppServiceSkuName? sku = default(Azure.ResourceManager.AppService.Models.AppServiceSkuName?), bool? linuxWorkersEnabled = default(bool?), bool? xenonWorkersEnabled = default(bool?), bool? linuxDynamicWorkersEnabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentDetectorResource GetHostingEnvironmentDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource GetHostingEnvironmentMultiRolePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource GetHostingEnvironmentPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentRecommendationResource GetHostingEnvironmentRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource GetHostingEnvironmentWorkerPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.HybridConnectionLimitsResource GetHybridConnectionLimitsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> GetKubeEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.KubeEnvironmentResource GetKubeEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.KubeEnvironmentCollection GetKubeEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.KubeEnvironmentResource> GetKubeEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.LogsSiteConfigResource GetLogsSiteConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.LogsSiteSlotConfigResource GetLogsSiteSlotConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.MigrateMySqlStatusResource GetMigrateMySqlStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.NetworkFeaturesResource GetNetworkFeaturesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsCertificateRegistrationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsCertificateRegistrationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsDomainRegistrationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsDomainRegistrationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmOperationDescription> GetOperationsProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.PremierAddOnOffer> GetPremierAddOnOffers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PremierAddOnOffer> GetPremierAddOnOffersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.NameIdentifier> GetRecommendationsDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NameIdentifier> GetRecommendationsDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource GetScmSiteBasicPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource GetScmSiteSlotBasicPublishingCredentialsPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource GetServerfarmHybridConnectionNamespaceRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource GetServerfarmVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource GetServerfarmVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteBackupResource GetSiteBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteConfigAppsettingResource GetSiteConfigAppsettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteConfigConnectionStringResource GetSiteConfigConnectionStringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteConfigSnapshotResource GetSiteConfigSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteContinuousWebJobResource GetSiteContinuousWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.AppService.SiteHybridConnectionResource GetSiteHybridConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> GetSiteIdentifiersAssignedToHostName(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.NameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> GetSiteIdentifiersAssignedToHostNameAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.NameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceExtensionResource GetSiteInstanceExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceProcessModuleResource GetSiteInstanceProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceProcessResource GetSiteInstanceProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteInstanceResource GetSiteInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteNetworkConfigResource GetSiteNetworkConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePremierAddonResource GetSitePremierAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePrivateAccessResource GetSitePrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource GetSitePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteProcessModuleResource GetSiteProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteProcessResource GetSiteProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SitePublicCertificateResource GetSitePublicCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteRecommendationResource GetSiteRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource GetSiteResourceHealthMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSiteextensionResource GetSiteSiteextensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotBackupResource GetSiteSlotBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource GetSiteSlotConfigAppSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource GetSiteSlotConfigConnectionStringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotConfigSnapshotResource GetSiteSlotConfigSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource GetSiteSlotContinuousWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource GetSiteSlotHybridconnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource GetSiteSlotInstanceExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceProcessModuleResource GetSiteSlotInstanceProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceProcessResource GetSiteSlotInstanceProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotInstanceResource GetSiteSlotInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource GetSiteSlotNetworkConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource GetSiteSlotPremierAddOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource GetSiteSlotPrivateAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource GetSiteSlotPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotProcessModuleResource GetSiteSlotProcessModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotProcessResource GetSiteSlotProcessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource GetSiteSlotPublicCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotResource GetSiteSlotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotResourceHealthMetadataResource GetSiteSlotResourceHealthMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotSiteextensionResource GetSiteSlotSiteextensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource GetSiteSlotSourcecontrolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource GetSiteSlotTriggeredWebJobHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource GetSiteSlotTriggeredWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource GetSiteSlotVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource GetSiteSlotVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSlotWebJobResource GetSiteSlotWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteSourceControlResource GetSiteSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource GetSiteTriggeredWebJobHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteTriggeredwebJobResource GetSiteTriggeredwebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource GetSiteVirtualNetworkConnectionGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource GetSiteVirtualNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SiteWebJobResource GetSiteWebJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.SkuInfos> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SkuInfos>> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.SlotConfigNamesResource GetSlotConfigNamesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.SourceControlResource> GetSourceControl(this Azure.ResourceManager.Resources.TenantResource tenantResource, string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SourceControlResource>> GetSourceControlAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.SourceControlResource GetSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.SourceControlCollection GetSourceControls(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteARMResource GetStaticSiteARMResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> GetStaticSiteARMResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> GetStaticSiteARMResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteARMResourceCollection GetStaticSiteARMResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteARMResource> GetStaticSiteARMResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteARMResource> GetStaticSiteARMResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteBuildARMResource GetStaticSiteBuildARMResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource GetStaticSiteBuildUserProvidedFunctionAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource GetStaticSiteCustomDomainOverviewARMResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource GetStaticSitePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource GetStaticSiteUserProvidedFunctionAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.DeploymentLocations> GetSubscriptionDeploymentLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.DeploymentLocations>> GetSubscriptionDeploymentLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetSubscriptionOperationWithAsyncResponseGlobal(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetSubscriptionOperationWithAsyncResponseGlobalAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource> GetTopLevelDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.TopLevelDomainResource>> GetTopLevelDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.TopLevelDomainResource GetTopLevelDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.TopLevelDomainCollection GetTopLevelDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.AppService.UserResource GetUser(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppService.UserResource GetUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksForLocationProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksForLocationProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksProviders(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.WebAppStack> GetWebAppStacksProvidersAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppService.Models.ProviderStackOSType? stackOSType = default(Azure.ResourceManager.AppService.Models.ProviderStackOSType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> GetWebSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> GetWebSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteConfigResource GetWebSiteConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteResource GetWebSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteCollection GetWebSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppService.WebSiteSlotConfigResource GetWebSiteSlotConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response Move(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.CsmMoveResourceEnvelope moveResourceEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> MoveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.CsmMoveResourceEnvelope moveResourceEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreview> PreviewWorkflowStaticSite(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreviewContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreview>> PreviewWorkflowStaticSiteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.AppService.Models.StaticSitesWorkflowPreviewContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response ResetAllFiltersRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ResetAllFiltersRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.ValidateResponse> Validate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.ValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ValidateResponse>> ValidateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.ValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response ValidateMove(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.CsmMoveResourceEnvelope moveResourceEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidateMoveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.AppService.Models.CsmMoveResourceEnvelope moveResourceEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response ValidatePurchaseInformationAppServiceCertificateOrder(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidatePurchaseInformationAppServiceCertificateOrderAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppService.Models.VnetValidationFailureDetails> VerifyHostingEnvironmentVnet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.VnetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.VnetValidationFailureDetails>> VerifyHostingEnvironmentVnetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppService.Models.VnetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AppServicePlanData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public AppServicePlanData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? ElasticScaleEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.DateTimeOffset? FreeOfferExpirationOn { get { throw null; } set { } }
        public string GeoRegion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public bool? HyperV { get { throw null; } set { } }
        public bool? IsSpot { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProfile KubeEnvironmentProfile { get { throw null; } set { } }
        public int? MaximumElasticWorkerCount { get { throw null; } set { } }
        public int? MaximumNumberOfWorkers { get { throw null; } }
        public int? NumberOfSites { get { throw null; } }
        public bool? PerSiteScaling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Reserved { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SkuDescription Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SpotExpirationOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StatusOptions? Status { get { throw null; } }
        public string Subscription { get { throw null; } }
        public int? TargetWorkerCount { get { throw null; } set { } }
        public int? TargetWorkerSizeId { get { throw null; } set { } }
        public string WorkerTierName { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class AppServicePlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServicePlanResource() { }
        public virtual Azure.ResourceManager.AppService.AppServicePlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Capability> GetCapabilities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Capability> GetCapabilitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.HybridConnectionLimitsResource GetHybridConnectionLimits() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> GetHybridConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> GetHybridConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> GetServerfarmHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource>> GetServerfarmHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayCollection GetServerfarmHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.Response<System.BinaryData> GetServerFarmSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetServerFarmSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> GetServerfarmVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>> GetServerfarmVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionCollection GetServerfarmVirtualNetworkConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebApps(string skipToken = null, string filter = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteResource> GetWebAppsAsync(string skipToken = null, string filter = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RebootWorker(string workerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RebootWorkerAsync(string workerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RestartWebApps(bool? softRestart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartWebAppsAsync(bool? softRestart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource> Update(Azure.ResourceManager.AppService.Models.AppServicePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.AppServicePlanResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.AppServicePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AseV3NetworkingConfigurationData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AseV3NetworkingConfigurationData() { }
        public bool? AllowNewPrivateEndpointConnections { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ExternalInboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InternalInboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinuxOutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> WindowsOutboundIPAddresses { get { throw null; } }
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
    public partial class BackupItemData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public BackupItemData() { }
        public int? BackupId { get { throw null; } }
        public string BlobName { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DatabaseBackupSetting> Databases { get { throw null; } }
        public System.DateTimeOffset? FinishedTimeStamp { get { throw null; } }
        public System.DateTimeOffset? LastRestoreTimeStamp { get { throw null; } }
        public string Log { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public bool? Scheduled { get { throw null; } }
        public long? SizeInBytes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.BackupItemStatus? Status { get { throw null; } }
        public System.Uri StorageAccountUri { get { throw null; } }
        public long? WebsiteSizeInBytes { get { throw null; } }
    }
    public partial class BasicPublishingCredentialsPolicyFtpResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BasicPublishingCredentialsPolicyFtpResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.CertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.CertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.CertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.CertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.CertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.CertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public CertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CanonicalName { get { throw null; } set { } }
        public byte[] CerBlob { get { throw null; } }
        public string DomainValidationMethod { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> HostNames { get { throw null; } }
        public System.DateTimeOffset? IssueOn { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? KeyVaultSecretStatus { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public byte[] PfxBlob { get { throw null; } set { } }
        public string PublicKeyHash { get { throw null; } }
        public string SelfLink { get { throw null; } }
        public string ServerFarmId { get { throw null; } set { } }
        public string SiteName { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public bool? Valid { get { throw null; } }
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
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.AppService.CertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.CertificateResource> Update(Azure.ResourceManager.AppService.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.CertificateResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContinuousWebJobData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ContinuousWebJobData() { }
        public string DetailedStatus { get { throw null; } set { } }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public System.Uri LogUri { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ContinuousWebJobStatus? Status { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UsingSdk { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
    }
    public partial class CsmPublishingCredentialsPoliciesEntityData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public CsmPublishingCredentialsPoliciesEntityData() { }
        public bool? Allow { get { throw null; } set { } }
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
    public partial class DeletedSiteData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DeletedSiteData() { }
        public int? DeletedSiteId { get { throw null; } }
        public string DeletedSiteName { get { throw null; } }
        public string DeletedTimestamp { get { throw null; } }
        public string GeoRegionName { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Snapshot> GetDeletedWebAppSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Snapshot> GetDeletedWebAppSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DeploymentData() { }
        public bool? Active { get { throw null; } set { } }
        public string Author { get { throw null; } set { } }
        public string AuthorEmail { get { throw null; } set { } }
        public string Deployer { get { throw null; } set { } }
        public string Details { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? Status { get { throw null; } set { } }
    }
    public partial class DetectorDefinitionAutoGeneratedData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DetectorDefinitionAutoGeneratedData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public double? Rank { get { throw null; } }
    }
    public partial class DiagnosticCategoryData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DiagnosticCategoryData() { }
        public string Description { get { throw null; } }
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
    public partial class DomainOwnershipIdentifierData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DomainOwnershipIdentifierData() { }
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
    public partial class FtpSiteSlotBasicPublishingCredentialsPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FtpSiteSlotBasicPublishingCredentialsPolicyResource() { }
        public virtual Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.CsmPublishingCredentialsPoliciesEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FunctionEnvelopeData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public FunctionEnvelopeData() { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string ConfigHref { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Files { get { throw null; } }
        public string FunctionAppId { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public string InvokeUrlTemplate { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.AppService.WorkerPoolResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRoleMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRoleMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRolePoolInstanceMetricDefinitions(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.ResourceMetricDefinition> GetMultiRolePoolInstanceMetricDefinitionsAsync(string instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SkuInfo> GetMultiRolePoolSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SkuInfo> GetMultiRolePoolSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetMultiRoleUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceUsage> GetMultiRoleUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource> Update(Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentMultiRolePoolResource>> UpdateAsync(Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostingEnvironmentPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HostingEnvironmentPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workerPoolName, Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workerPoolName, Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.WorkerPoolResourceData Data { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SkuInfo> GetWorkerPoolSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SkuInfo> GetWorkerPoolSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource> Update(Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HostingEnvironmentWorkerPoolResource>> UpdateAsync(Azure.ResourceManager.AppService.WorkerPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostNameBindingData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public HostNameBindingData() { }
        public string AzureResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureResourceType? AzureResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get { throw null; } set { } }
        public string DomainId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HostNameType? HostNameType { get { throw null; } set { } }
        public string SiteName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SslState? SslState { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } }
    }
    public partial class HybridConnectionData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public HybridConnectionData() { }
        public string Hostname { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public System.Uri RelayArmUri { get { throw null; } set { } }
        public string RelayName { get { throw null; } set { } }
        public string SendKeyName { get { throw null; } set { } }
        public string SendKeyValue { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string ServiceBusSuffix { get { throw null; } set { } }
    }
    public partial class HybridConnectionLimitsData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public HybridConnectionLimitsData() { }
        public int? Current { get { throw null; } }
        public int? Maximum { get { throw null; } }
    }
    public partial class HybridConnectionLimitsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectionLimitsResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionLimitsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.HybridConnectionLimitsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.HybridConnectionLimitsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdentifierData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public IdentifierData() { }
        public string Value { get { throw null; } set { } }
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
    public partial class KubeEnvironmentData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public KubeEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ArcConfiguration ArcConfiguration { get { throw null; } set { } }
        public string DefaultDomain { get { throw null; } }
        public string DeploymentErrors { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public bool? InternalLoadBalancerEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
    }
    public partial class KubeEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubeEnvironmentResource() { }
        public virtual Azure.ResourceManager.AppService.KubeEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.KubeEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MigrateMySqlStatusData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public MigrateMySqlStatusData() { }
        public bool? LocalMySqlEnabled { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.OperationStatus? MigrationOperationStatus { get { throw null; } }
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
    public partial class MSDeployStatusData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public MSDeployStatusData() { }
        public bool? Complete { get { throw null; } }
        public string Deployer { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.MSDeployProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class NetworkFeaturesCollection : Azure.ResourceManager.ArmCollection
    {
        protected NetworkFeaturesCollection() { }
        public virtual Azure.Response<bool> Exists(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource> Get(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource>> GetAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFeaturesData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public NetworkFeaturesData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.RelayServiceConnectionEntityData> HybridConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.HybridConnectionData> HybridConnectionsV2 { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.VnetInfo VirtualNetworkConnection { get { throw null; } }
        public string VirtualNetworkName { get { throw null; } }
    }
    public partial class NetworkFeaturesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFeaturesResource() { }
        public virtual Azure.ResourceManager.AppService.NetworkFeaturesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string view) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PremierAddOnData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public PremierAddOnData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string MarketplaceOffer { get { throw null; } set { } }
        public string MarketplacePublisher { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
    }
    public partial class PrivateAccessData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PrivateAccessData() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.PrivateAccessVirtualNetwork> VirtualNetworks { get { throw null; } }
    }
    public partial class ProcessInfoData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
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
    public partial class ProcessModuleInfoData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ProcessModuleInfoData() { }
        public string BaseAddress { get { throw null; } set { } }
        public string FileDescription { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FileVersion { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public bool? IsDebug { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public int? ModuleMemorySize { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string ProductVersion { get { throw null; } set { } }
    }
    public partial class PublicCertificateData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PublicCertificateData() { }
        public byte[] Blob { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.PublicCertificateLocation? PublicCertificateLocation { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
    }
    public partial class RecommendationRuleData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RecommendationRuleData() { }
        public string ActionName { get { throw null; } set { } }
        public string BladeName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryTags { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.Channels? Channels { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        public string ForwardLink { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.NotificationLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Guid? RecommendationId { get { throw null; } set { } }
        public string RecommendationName { get { throw null; } set { } }
    }
    public partial class RelayServiceConnectionEntityData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RelayServiceConnectionEntityData() { }
        public System.Uri BiztalkUri { get { throw null; } set { } }
        public string EntityConnectionString { get { throw null; } set { } }
        public string EntityName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ResourceConnectionString { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnectionARMResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RemotePrivateEndpointConnectionARMResourceData() { }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ResourceHealthMetadataData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ResourceHealthMetadataData() { }
        public string Category { get { throw null; } set { } }
        public bool? SignalAvailability { get { throw null; } set { } }
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
    public partial class ServerfarmHybridConnectionNamespaceRelayCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerfarmHybridConnectionNamespaceRelayCollection() { }
        public virtual Azure.Response<bool> Exists(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> Get(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource>> GetAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerfarmHybridConnectionNamespaceRelayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerfarmHybridConnectionNamespaceRelayResource() { }
        public virtual Azure.ResourceManager.AppService.HybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string namespaceName, string relayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.HybridConnectionKey> GetHybridConnectionKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.HybridConnectionKey>> GetHybridConnectionKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetWebAppsByHybridConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetWebAppsByHybridConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerfarmVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected ServerfarmVirtualNetworkConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> Get(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>> GetAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerfarmVirtualNetworkConnectionGatewayCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerfarmVirtualNetworkConnectionGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerfarmVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerfarmVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.VnetGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerfarmVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerfarmVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.VnetInfoResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.VnetRoute> CreateOrUpdateVnetRoute(string routeName, Azure.ResourceManager.AppService.Models.VnetRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.VnetRoute>> CreateOrUpdateVnetRouteAsync(string routeName, Azure.ResourceManager.AppService.Models.VnetRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName) { throw null; }
        public virtual Azure.Response DeleteVnetRoute(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVnetRouteAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.VnetRoute> GetRoutesForVnet(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.VnetRoute> GetRoutesForVnetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource> GetServerfarmVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayResource>> GetServerfarmVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ServerfarmVirtualNetworkConnectionGatewayCollection GetServerfarmVirtualNetworkConnectionGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.VnetRoute> UpdateVnetRoute(string routeName, Azure.ResourceManager.AppService.Models.VnetRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.VnetRoute>> UpdateVnetRouteAsync(string routeName, Azure.ResourceManager.AppService.Models.VnetRoute route, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.BackupItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string backupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> GetBackupStatusSecrets(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetBackupStatusSecretsAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteConfigConnectionStringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>, System.Collections.IEnumerable
    {
        protected SiteConfigConnectionStringCollection() { }
        public virtual Azure.Response<bool> Exists(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> Get(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>> GetAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteConfigConnectionStringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteConfigConnectionStringResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string connectionStringKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteConfigData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteConfigData() { }
        public bool? AcrUseManagedIdentityCreds { get { throw null; } set { } }
        public string AcrUserManagedIdentityId { get { throw null; } set { } }
        public bool? AlwaysOn { get { throw null; } set { } }
        public System.Uri ApiDefinitionUri { get { throw null; } set { } }
        public string ApiManagementConfigId { get { throw null; } set { } }
        public string AppCommandLine { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> AppSettings { get { throw null; } set { } }
        public bool? AutoHealEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public string AutoSwapSlotName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AzureStorageInfoValue> AzureStorageAccounts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CorsSettings Cors { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultDocuments { get { throw null; } set { } }
        public bool? DetailedErrorLoggingEnabled { get { throw null; } set { } }
        public string DocumentRoot { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.RampUpRule> ExperimentsRampUpRules { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.FtpsState? FtpsState { get { throw null; } set { } }
        public int? FunctionAppScaleLimit { get { throw null; } set { } }
        public bool? FunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HandlerMapping> HandlerMappings { get { throw null; } set { } }
        public string HealthCheckPath { get { throw null; } set { } }
        public bool? Http20Enabled { get { throw null; } set { } }
        public bool? HttpLoggingEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.IPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public string JavaContainer { get { throw null; } set { } }
        public string JavaContainerVersion { get { throw null; } set { } }
        public string JavaVersion { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLimits Limits { get { throw null; } set { } }
        public string LinuxFxVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLoadBalancing? LoadBalancing { get { throw null; } set { } }
        public bool? LocalMySqlEnabled { get { throw null; } set { } }
        public int? LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ManagedPipelineMode? ManagedPipelineMode { get { throw null; } set { } }
        public int? ManagedServiceIdentityId { get { throw null; } set { } }
        public int? MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SupportedTlsVersions? MinTlsVersion { get { throw null; } set { } }
        public string NetFrameworkVersion { get { throw null; } set { } }
        public string NodeVersion { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public string PhpVersion { get { throw null; } set { } }
        public string PowerShellVersion { get { throw null; } set { } }
        public int? PreWarmedInstanceCount { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingUsername { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.PushSettings Push { get { throw null; } set { } }
        public string PythonVersion { get { throw null; } set { } }
        public bool? RemoteDebuggingEnabled { get { throw null; } set { } }
        public string RemoteDebuggingVersion { get { throw null; } set { } }
        public bool? RequestTracingEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RequestTracingExpirationOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.IPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public bool? ScmIPSecurityRestrictionsUseMain { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SupportedTlsVersions? ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ScmType? ScmType { get { throw null; } set { } }
        public string TracingOptions { get { throw null; } set { } }
        public bool? Use32BitWorkerProcess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public int? VnetPrivatePortsCount { get { throw null; } set { } }
        public bool? VnetRouteAllEnabled { get { throw null; } set { } }
        public string WebsiteTimeZone { get { throw null; } set { } }
        public bool? WebSocketsEnabled { get { throw null; } set { } }
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
    public partial class SiteContinuousWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>, System.Collections.IEnumerable
    {
        protected SiteContinuousWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteContinuousWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteContinuousWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.ContinuousWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartContinuousWebJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartContinuousWebJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopContinuousWebJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopContinuousWebJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteDeploymentResource>, System.Collections.IEnumerable
    {
        protected SiteDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource> GetDeploymentLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDeploymentResource>> GetDeploymentLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.AnalysisDefinitionData Data { get { throw null; } }
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
        public virtual Azure.ResourceManager.AppService.DetectorDefinitionAutoGeneratedData Data { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.IdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string domainOwnershipIdentifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource> Update(Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteDomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteExtensionInfoData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog> GetMSDeployLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog>> GetMSDeployLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo> CreateOrUpdateFunctionSecret(string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo>> CreateOrUpdateFunctionSecretAsync(string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFunctionSecret(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFunctionSecretAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetFunctionKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetFunctionKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteHybridConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteHybridConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHybridConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteHybridConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteHybridConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RelayServiceConnectionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> Update(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteInstanceExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteInstanceExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog> GetInstanceMSDeployLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog>> GetInstanceMSDeployLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteLogsConfigData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteLogsConfigData() { }
        public Azure.ResourceManager.AppService.Models.ApplicationLogsConfig ApplicationLogs { get { throw null; } set { } }
        public bool? DetailedErrorMessagesEnabled { get { throw null; } set { } }
        public bool? FailedRequestsTracingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HttpLogsConfig HttpLogs { get { throw null; } set { } }
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
    public partial class SitePremierAddonCollection : Azure.ResourceManager.ArmCollection
    {
        protected SitePremierAddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePremierAddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePremierAddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> Get(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> GetAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SitePremierAddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SitePremierAddonResource() { }
        public virtual Azure.ResourceManager.AppService.PremierAddOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string premierAddOnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> Update(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SitePrivateAccessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SitePrivateAccessResource() { }
        public virtual Azure.ResourceManager.AppService.PrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SitePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SitePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteResourceHealthMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteResourceHealthMetadataResource() { }
        public virtual Azure.ResourceManager.AppService.ResourceHealthMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSiteextensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSiteextensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSiteextensionResource>, System.Collections.IEnumerable
    {
        protected SiteSiteextensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSiteextensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSiteextensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource> Get(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSiteextensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSiteextensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource>> GetAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSiteextensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSiteextensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSiteextensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSiteextensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSiteextensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSiteextensionResource() { }
        public virtual Azure.ResourceManager.AppService.SiteExtensionInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string siteExtensionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSiteextensionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSiteextensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.BackupItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string backupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetBackupStatusSecretsSlot(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetBackupStatusSecretsSlotAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotResource>, System.Collections.IEnumerable
    {
        protected SiteSlotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string slot, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string slot, Azure.ResourceManager.AppService.WebSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> Get(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> GetAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotConfigAppSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>, System.Collections.IEnumerable
    {
        protected SiteSlotConfigAppSettingCollection() { }
        public virtual Azure.Response<bool> Exists(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> Get(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>> GetAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotConfigAppSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotConfigAppSettingResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string appSettingKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotConfigConnectionStringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>, System.Collections.IEnumerable
    {
        protected SiteSlotConfigConnectionStringCollection() { }
        public virtual Azure.Response<bool> Exists(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> Get(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>> GetAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotConfigConnectionStringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotConfigConnectionStringResource() { }
        public virtual Azure.ResourceManager.AppService.ApiKeyVaultReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string connectionStringKey) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteSlotContinuousWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>, System.Collections.IEnumerable
    {
        protected SiteSlotContinuousWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotContinuousWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotContinuousWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.ContinuousWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartContinuousWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartContinuousWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopContinuousWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopContinuousWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>, System.Collections.IEnumerable
    {
        protected SiteSlotDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> GetDeploymentLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> GetDeploymentLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.AnalysisDefinitionData Data { get { throw null; } }
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
        public virtual Azure.ResourceManager.AppService.DetectorDefinitionAutoGeneratedData Data { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainOwnershipIdentifierName, Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.IdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string domainOwnershipIdentifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource> Update(Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotDomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.AppService.IdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotExtensionResource() { }
        public virtual Azure.ResourceManager.AppService.MSDeployStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog> GetMSDeployLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog>> GetMSDeployLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo> CreateOrUpdateFunctionSecretSlot(string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo>> CreateOrUpdateFunctionSecretSlotAsync(string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFunctionSecretSlot(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFunctionSecretSlotAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetFunctionKeysSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetFunctionKeysSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteSlotHybridconnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteSlotHybridconnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteSlotHybridconnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotHybridconnectionResource() { }
        public virtual Azure.ResourceManager.AppService.RelayServiceConnectionEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource> Update(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.RelayServiceConnectionEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MsDeploy msDeploy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog> GetInstanceMSDeployLogSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.MsDeployLog>> GetInstanceMSDeployLogSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteSlotPremierAddOnCollection : Azure.ResourceManager.ArmCollection
    {
        protected SiteSlotPremierAddOnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string premierAddOnName, Azure.ResourceManager.AppService.PremierAddOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> Get(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> GetAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotPremierAddOnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotPremierAddOnResource() { }
        public virtual Azure.ResourceManager.AppService.PremierAddOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string premierAddOnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> Update(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.PremierAddOnPatchResource premierAddOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotPrivateAccessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotPrivateAccessResource() { }
        public virtual Azure.ResourceManager.AppService.PrivateAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PrivateAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SiteSlotPublicCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>, System.Collections.IEnumerable
    {
        protected SiteSlotPublicCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicCertificateName, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> Get(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>> GetAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotPublicCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotPublicCertificateResource() { }
        public virtual Azure.ResourceManager.AppService.PublicCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string publicCertificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.PublicCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult> AnalyzeCustomHostnameSlot(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult>> AnalyzeCustomHostnameSlotAsync(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ApplySlotConfigurationSlot(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplySlotConfigurationSlotAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> BackupSlot(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> BackupSlotAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo> CreateOrUpdateHostSecretSlot(string keyType, string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo>> CreateOrUpdateHostSecretSlotAsync(string keyType, string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteBackupConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBackupConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteHostSecretSlot(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteHostSecretSlotAsync(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequest> DiscoverBackupSlot(Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequest>> DiscoverBackupSlotAsync(Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateNewSitePublishingPasswordSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateNewSitePublishingPasswordSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetApplicationSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetApplicationSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> GetAuthSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> GetAuthSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> GetAuthSettingsV2Slot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> GetAuthSettingsV2SlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource> GetAzureStorageAccountsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource>> GetAzureStorageAccountsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest> GetBackupConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest>> GetBackupConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteConfigResource> GetConfigurationsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteConfigResource> GetConfigurationsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> GetConnectionStringsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> GetConnectionStringsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetContainerLogsZipSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetContainerLogsZipSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.FtpSiteSlotBasicPublishingCredentialsPolicyResource GetFtpSiteSlotBasicPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<string> GetFunctionsAdminTokenSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetFunctionsAdminTokenSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.HostKeys> GetHostKeysSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.HostKeys>> GetHostKeysSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> GetHybridConnectionsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource>> GetHybridConnectionsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.LogsSiteSlotConfigResource GetLogsSiteSlotConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetMetadataSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetMetadataSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.MigrateMySqlStatusResource GetMigrateMySqlStatus() { throw null; }
        public virtual Azure.ResourceManager.AppService.NetworkFeaturesCollection GetNetworkFeatures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource> GetNetworkFeatures(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource>> GetNetworkFeaturesAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationSlot(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationSlotAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationSlotV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationSlotV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesSlot(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesSlotAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesSlotV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesSlotV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.PerfMonResponse> GetPerfMonCountersSlot(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PerfMonResponse> GetPerfMonCountersSlotAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> GetPremierAddOnsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> GetPremierAddOnsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResourcesSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResourcesSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource> GetPublishingCredentialsSlot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource>> GetPublishingCredentialsSlotAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetPublishingProfileXmlWithSecretsSlot(Azure.ResourceManager.AppService.Models.CsmPublishingProfileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetPublishingProfileXmlWithSecretsSlotAsync(Azure.ResourceManager.AppService.Models.CsmPublishingProfileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> GetRelayServiceConnectionsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> GetRelayServiceConnectionsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ScmSiteSlotBasicPublishingCredentialsPolicyResource GetScmSiteSlotBasicPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackupsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackupsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag> GetSitePhpErrorLogFlagSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag>> GetSitePhpErrorLogFlagSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings> GetSitePushSettingsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings>> GetSitePushSettingsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource> GetSiteSlotBackup(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotBackupResource>> GetSiteSlotBackupAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotBackupCollection GetSiteSlotBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource> GetSiteSlotConfigAppSetting(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigAppSettingResource>> GetSiteSlotConfigAppSettingAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotConfigAppSettingCollection GetSiteSlotConfigAppSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource> GetSiteSlotConfigConnectionString(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringResource>> GetSiteSlotConfigConnectionStringAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotConfigConnectionStringCollection GetSiteSlotConfigConnectionStrings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource> GetSiteSlotContinuousWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotContinuousWebJobResource>> GetSiteSlotContinuousWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotContinuousWebJobCollection GetSiteSlotContinuousWebJobs() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource> GetSiteSlotHybridconnection(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridconnectionResource>> GetSiteSlotHybridconnectionAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource> GetSiteSlotHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayResource>> GetSiteSlotHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotHybridConnectionNamespaceRelayCollection GetSiteSlotHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotHybridconnectionCollection GetSiteSlotHybridconnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource> GetSiteSlotInstance(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotInstanceResource>> GetSiteSlotInstanceAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotInstanceCollection GetSiteSlotInstances() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotNetworkConfigResource GetSiteSlotNetworkConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource> GetSiteSlotPremierAddOn(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPremierAddOnResource>> GetSiteSlotPremierAddOnAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotPremierAddOnCollection GetSiteSlotPremierAddOns() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotPrivateAccessResource GetSiteSlotPrivateAccess() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource> GetSiteSlotPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionResource>> GetSiteSlotPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotPrivateEndpointConnectionCollection GetSiteSlotPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource> GetSiteSlotProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotProcessResource>> GetSiteSlotProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotProcessCollection GetSiteSlotProcesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource> GetSiteSlotPublicCertificate(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotPublicCertificateResource>> GetSiteSlotPublicCertificateAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotPublicCertificateCollection GetSiteSlotPublicCertificates() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotResourceHealthMetadataResource GetSiteSlotResourceHealthMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> GetSiteSlotSiteextension(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>> GetSiteSlotSiteextensionAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotSiteextensionCollection GetSiteSlotSiteextensions() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource GetSiteSlotSourcecontrol() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> GetSiteSlotVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> GetSiteSlotVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionCollection GetSiteSlotVirtualNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource> GetSiteSlotWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource>> GetSiteSlotWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotWebJobCollection GetSiteSlotWebJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> GetSiteTriggeredwebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>> GetSiteTriggeredwebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteTriggeredwebJobCollection GetSiteTriggeredwebJobs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesSlot(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesSlotAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsFromDRSecondarySlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsFromDRSecondarySlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetSyncFunctionTriggersSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetSyncFunctionTriggersSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSyncStatusSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSyncStatusSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesSlot(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesSlotAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetWebSiteContainerLogsSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetWebSiteContainerLogsSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteSlotConfigResource GetWebSiteSlotConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability> IsCloneableSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability>> IsCloneableSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetSlotConfigurationSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetSlotConfigurationSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RestartSlot(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartSlotAsync(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromBackupBlobSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromBackupBlobSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromDeletedAppSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromDeletedAppSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSnapshotSlot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSnapshotSlotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>> StartNetworkTraceSlot(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>>> StartNetworkTraceSlotAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>> StartWebSiteNetworkTraceOperationSlot(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>>> StartWebSiteNetworkTraceOperationSlotAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> Update(Azure.ResourceManager.AppService.Models.SitePatchResource siteEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> UpdateApplicationSettingsSlot(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> UpdateApplicationSettingsSlotAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.SitePatchResource siteEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> UpdateAuthSettingsSlot(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> UpdateAuthSettingsSlotAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> UpdateAuthSettingsV2Slot(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> UpdateAuthSettingsV2SlotAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource> UpdateAzureStorageAccountsSlot(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource>> UpdateAzureStorageAccountsSlotAsync(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest> UpdateBackupConfigurationSlot(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest>> UpdateBackupConfigurationSlotAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> UpdateConnectionStringsSlot(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> UpdateConnectionStringsSlotAsync(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> UpdateMetadataSlot(Azure.ResourceManager.AppService.Models.StringDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> UpdateMetadataSlotAsync(Azure.ResourceManager.AppService.Models.StringDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings> UpdateSitePushSettingsSlot(Azure.ResourceManager.AppService.Models.PushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings>> UpdateSitePushSettingsSlotAsync(Azure.ResourceManager.AppService.Models.PushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotResourceHealthMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotResourceHealthMetadataResource() { }
        public virtual Azure.ResourceManager.AppService.ResourceHealthMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResourceHealthMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResourceHealthMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotSiteextensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotSiteextensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> Get(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>> GetAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotSiteextensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotSiteextensionResource() { }
        public virtual Azure.ResourceManager.AppService.SiteExtensionInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string siteExtensionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSiteextensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotSourcecontrolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotSourcecontrolResource() { }
        public virtual Azure.ResourceManager.AppService.SiteSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource> Update(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotSourcecontrolResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotTriggeredWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>, System.Collections.IEnumerable
    {
        protected SiteSlotTriggeredWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotTriggeredWebJobHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>, System.Collections.IEnumerable
    {
        protected SiteSlotTriggeredWebJobHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotTriggeredWebJobHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotTriggeredWebJobHistoryResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredJobHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotTriggeredWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotTriggeredWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryCollection GetSiteSlotTriggeredWebJobHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource> GetSiteSlotTriggeredWebJobHistory(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobHistoryResource>> GetSiteSlotTriggeredWebJobHistoryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteSlotVirtualNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.VnetGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> Update(Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.VnetInfoResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string vnetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource> GetSiteSlotVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayResource>> GetSiteSlotVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionGatewayCollection GetSiteSlotVirtualNetworkConnectionGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource> Update(Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotVirtualNetworkConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSlotWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotWebJobResource>, System.Collections.IEnumerable
    {
        protected SiteSlotWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteSlotWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteSlotWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteSlotWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteSlotWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteSlotWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteSlotWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteSlotWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSlotWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.WebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteSourceControlData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteSourceControlData() { }
        public string Branch { get { throw null; } set { } }
        public bool? DeploymentRollbackEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.GitHubActionConfiguration GitHubActionConfiguration { get { throw null; } set { } }
        public bool? IsGitHubAction { get { throw null; } set { } }
        public bool? IsManualIntegration { get { throw null; } set { } }
        public bool? IsMercurial { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
    }
    public partial class SiteSourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteSourceControlResource() { }
        public virtual Azure.ResourceManager.AppService.SiteSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteSourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string additionalFlags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSourceControlResource> Update(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSourceControlResource>> UpdateAsync(Azure.ResourceManager.AppService.SiteSourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteTriggeredwebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>, System.Collections.IEnumerable
    {
        protected SiteTriggeredwebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteTriggeredWebJobHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>, System.Collections.IEnumerable
    {
        protected SiteTriggeredWebJobHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteTriggeredWebJobHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteTriggeredWebJobHistoryResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredJobHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteTriggeredwebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteTriggeredwebJobResource() { }
        public virtual Azure.ResourceManager.AppService.TriggeredWebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredwebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryCollection GetSiteTriggeredWebJobHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource> GetSiteTriggeredWebJobHistory(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteTriggeredWebJobHistoryResource>> GetSiteTriggeredWebJobHistoryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunTriggeredWebJobSlot(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunTriggeredWebJobSlotAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected SiteVirtualNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vnetName, Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteVirtualNetworkConnectionGatewayResource() { }
        public virtual Azure.ResourceManager.AppService.VnetGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName, string gatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> Update(Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> UpdateAsync(Azure.ResourceManager.AppService.VnetGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteVirtualNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteVirtualNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.AppService.VnetInfoResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string vnetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource> GetSiteVirtualNetworkConnectionGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayResource>> GetSiteVirtualNetworkConnectionGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionGatewayCollection GetSiteVirtualNetworkConnectionGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> Update(Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> UpdateAsync(Azure.ResourceManager.AppService.VnetInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteWebJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteWebJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteWebJobResource>, System.Collections.IEnumerable
    {
        protected SiteWebJobCollection() { }
        public virtual Azure.Response<bool> Exists(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource> Get(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteWebJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteWebJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource>> GetAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SiteWebJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SiteWebJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SiteWebJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SiteWebJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteWebJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteWebJobResource() { }
        public virtual Azure.ResourceManager.AppService.WebJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SlotConfigNamesResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SlotConfigNamesResourceData() { }
        public System.Collections.Generic.IList<string> AppSettingNames { get { throw null; } }
        public System.Collections.Generic.IList<string> AzureStorageConfigNames { get { throw null; } }
        public System.Collections.Generic.IList<string> ConnectionStringNames { get { throw null; } }
    }
    public partial class SourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SourceControlResource>, System.Collections.IEnumerable
    {
        protected SourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlType, Azure.ResourceManager.AppService.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlType, Azure.ResourceManager.AppService.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SourceControlResource> Get(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SourceControlResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SourceControlResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SourceControlResource>> GetAsync(string sourceControlType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.SourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.SourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.SourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.SourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SourceControlData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SourceControlData() { }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public string TokenSecret { get { throw null; } set { } }
    }
    public partial class SourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SourceControlResource() { }
        public virtual Azure.ResourceManager.AppService.SourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string sourceControlType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SourceControlResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.SourceControlResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteARMResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteARMResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> CreateOrUpdateAppSettings(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> CreateOrUpdateAppSettingsAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> CreateOrUpdateFunctionAppSettings(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> CreateOrUpdateFunctionAppSettingsAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationResponseResource> CreateUserRolesInvitationLink(Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationRequestResource staticSiteUserRolesInvitationEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationResponseResource>> CreateUserRolesInvitationLinkAsync(Azure.ResourceManager.AppService.Models.StaticSiteUserInvitationRequestResource staticSiteUserRolesInvitationEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateZipDeploymentForStaticSite(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeploymentARMResource staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateZipDeploymentForStaticSiteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeploymentARMResource staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(string authprovider, string userid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string authprovider, string userid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Detach(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringList> GetConfiguredRoles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringList>> GetConfiguredRolesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetFunctionAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetFunctionAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> GetStaticSiteBuildARMResource(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>> GetStaticSiteBuildARMResourceAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildARMResourceCollection GetStaticSiteBuildARMResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> GetStaticSiteCustomDomainOverviewARMResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>> GetStaticSiteCustomDomainOverviewARMResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResourceCollection GetStaticSiteCustomDomainOverviewARMResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverviewARMResource> GetStaticSiteFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverviewARMResource> GetStaticSiteFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> GetStaticSitePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> GetStaticSitePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionCollection GetStaticSitePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetStaticSiteSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetStaticSiteSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> GetStaticSiteUserProvidedFunctionApp(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> GetStaticSiteUserProvidedFunctionAppAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppCollection GetStaticSiteUserProvidedFunctionApps() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource> GetUsers(string authprovider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource> GetUsersAsync(string authprovider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetApiKey(Azure.ResourceManager.AppService.Models.StaticSiteResetPropertiesARMResource resetPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetApiKeyAsync(Azure.ResourceManager.AppService.Models.StaticSiteResetPropertiesARMResource resetPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> Update(Azure.ResourceManager.AppService.Models.StaticSiteARMResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.StaticSiteARMResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource> UpdateUser(string authprovider, string userid, Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource staticSiteUserEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource>> UpdateUserAsync(string authprovider, string userid, Azure.ResourceManager.AppService.Models.StaticSiteUserARMResource staticSiteUserEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteARMResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteARMResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteARMResource>, System.Collections.IEnumerable
    {
        protected StaticSiteARMResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteARMResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.StaticSiteARMResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteARMResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.AppService.StaticSiteARMResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteARMResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteARMResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteARMResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteARMResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteARMResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteARMResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteARMResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteARMResourceData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public StaticSiteARMResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AllowConfigFileUpdates { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public string ContentDistributionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CustomDomains { get { throw null; } }
        public string DefaultHostname { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResponseMessageEnvelopeRemotePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string Provider { get { throw null; } }
        public string RepositoryToken { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SkuDescription Sku { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteTemplateOptions TemplateProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.StaticSiteUserProvidedFunctionApp> UserProvidedFunctionApps { get { throw null; } }
    }
    public partial class StaticSiteBuildARMResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteBuildARMResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> CreateOrUpdateStaticSiteBuildAppSettings(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> CreateOrUpdateStaticSiteBuildAppSettingsAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> CreateOrUpdateStaticSiteBuildFunctionAppSettings(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> CreateOrUpdateStaticSiteBuildFunctionAppSettingsAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateZipDeploymentForStaticSiteBuild(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeploymentARMResource staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateZipDeploymentForStaticSiteBuildAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteZipDeploymentARMResource staticSiteZipDeploymentEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetStaticSiteBuildAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetStaticSiteBuildAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetStaticSiteBuildFunctionAppSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetStaticSiteBuildFunctionAppSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverviewARMResource> GetStaticSiteBuildFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.StaticSiteFunctionOverviewARMResource> GetStaticSiteBuildFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> GetStaticSiteBuildUserProvidedFunctionApp(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> GetStaticSiteBuildUserProvidedFunctionAppAsync(string functionAppName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppCollection GetStaticSiteBuildUserProvidedFunctionApps() { throw null; }
    }
    public partial class StaticSiteBuildARMResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>, System.Collections.IEnumerable
    {
        protected StaticSiteBuildARMResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteBuildARMResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildARMResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteBuildARMResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteBuildARMResourceData() { }
        public string BuildId { get { throw null; } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public string Hostname { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string PullRequestTitle { get { throw null; } }
        public string SourceBranch { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.BuildStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.StaticSiteUserProvidedFunctionApp> UserProvidedFunctionApps { get { throw null; } }
    }
    public partial class StaticSiteBuildUserProvidedFunctionAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>, System.Collections.IEnumerable
    {
        protected StaticSiteBuildUserProvidedFunctionAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string environmentName, string functionAppName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteBuildUserProvidedFunctionAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteCustomDomainOverviewARMResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteCustomDomainOverviewARMResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateCustomDomainCanBeAddedToStaticSite(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateCustomDomainCanBeAddedToStaticSiteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteCustomDomainOverviewARMResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>, System.Collections.IEnumerable
    {
        protected StaticSiteCustomDomainOverviewARMResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppService.Models.StaticSiteCustomDomainRequestPropertiesARMResource staticSiteCustomDomainRequestPropertiesEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteCustomDomainOverviewARMResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StaticSiteCustomDomainOverviewARMResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteCustomDomainOverviewARMResourceData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CustomDomainStatus? Status { get { throw null; } }
        public string ValidationToken { get { throw null; } }
    }
    public partial class StaticSitePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected StaticSitePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSitePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StaticSiteUserProvidedFunctionAppARMResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteUserProvidedFunctionAppARMResourceData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FunctionAppRegion { get { throw null; } set { } }
        public string FunctionAppResourceId { get { throw null; } set { } }
    }
    public partial class StaticSiteUserProvidedFunctionAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>, System.Collections.IEnumerable
    {
        protected StaticSiteUserProvidedFunctionAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionAppName, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class StaticSiteUserProvidedFunctionAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StaticSiteUserProvidedFunctionAppResource() { }
        public virtual Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string functionAppName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.StaticSiteUserProvidedFunctionAppARMResourceData data, bool? isForced = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SwiftVirtualNetworkData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SwiftVirtualNetworkData() { }
        public string SubnetResourceId { get { throw null; } set { } }
        public bool? SwiftSupported { get { throw null; } set { } }
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
    public partial class TopLevelDomainData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public TopLevelDomainData() { }
        public bool? Privacy { get { throw null; } set { } }
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
    public partial class TriggeredJobHistoryData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public TriggeredJobHistoryData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.TriggeredJobRun> Runs { get { throw null; } }
    }
    public partial class TriggeredWebJobData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public TriggeredWebJobData() { }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public System.Uri HistoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TriggeredJobRun LatestRun { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Uri SchedulerLogsUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UsingSdk { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
    }
    public partial class UserData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public UserData() { }
        public string PublishingPassword { get { throw null; } set { } }
        public string PublishingPasswordHash { get { throw null; } set { } }
        public string PublishingPasswordHashSalt { get { throw null; } set { } }
        public string PublishingUserName { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } set { } }
    }
    public partial class UserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserResource() { }
        public virtual Azure.ResourceManager.AppService.UserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.UserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.UserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VnetGatewayData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetGatewayData() { }
        public string VnetName { get { throw null; } set { } }
        public System.Uri VpnPackageUri { get { throw null; } set { } }
    }
    public partial class VnetInfoResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetInfoResourceData() { }
        public string CertBlob { get { throw null; } set { } }
        public string CertThumbprint { get { throw null; } }
        public string DnsServers { get { throw null; } set { } }
        public bool? IsSwift { get { throw null; } set { } }
        public bool? ResyncRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.VnetRoute> Routes { get { throw null; } }
        public string VnetResourceId { get { throw null; } set { } }
    }
    public partial class WebJobData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public WebJobData() { }
        public string Error { get { throw null; } set { } }
        public System.Uri ExtraInfoUri { get { throw null; } set { } }
        public string RunCommand { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UsingSdk { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.WebJobType? WebJobType { get { throw null; } set { } }
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
    public partial class WebSiteData : Azure.ResourceManager.AppService.Models.AppServiceResource
    {
        public WebSiteData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.AppService.Models.SiteAvailabilityState? AvailabilityState { get { throw null; } }
        public bool? ClientAffinityEnabled { get { throw null; } set { } }
        public bool? ClientCertEnabled { get { throw null; } set { } }
        public string ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ClientCertMode? ClientCertMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CloningInfo CloningInfo { get { throw null; } set { } }
        public int? ContainerSize { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } set { } }
        public int? DailyMemoryTimeQuota { get { throw null; } set { } }
        public string DefaultHostName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HostNames { get { throw null; } }
        public bool? HostNamesDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HostNameSslState> HostNameSslStates { get { throw null; } }
        public bool? HttpsOnly { get { throw null; } set { } }
        public bool? HyperV { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InProgressOperationId { get { throw null; } }
        public bool? IsDefaultContainer { get { throw null; } }
        public bool? IsXenon { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public int? MaxNumberOfWorkers { get { throw null; } }
        public string OutboundIPAddresses { get { throw null; } }
        public string PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RedundancyMode? RedundancyMode { get { throw null; } set { } }
        public string RepositorySiteName { get { throw null; } }
        public bool? Reserved { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public bool? ScmSiteAlsoStopped { get { throw null; } set { } }
        public string ServerFarmId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public string State { get { throw null; } }
        public bool? StorageAccountRequired { get { throw null; } set { } }
        public System.DateTimeOffset? SuspendedTill { get { throw null; } }
        public string TargetSwapSlot { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.UsageState? UsageState { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class WebSiteInstanceStatusData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public WebSiteInstanceStatusData() { }
        public System.Uri ConsoleUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.ContainerInfo> Containers { get { throw null; } }
        public System.Uri DetectorUri { get { throw null; } set { } }
        public System.Uri HealthCheckUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteRuntimeState? State { get { throw null; } set { } }
        public System.Uri StatusUri { get { throw null; } set { } }
    }
    public partial class WebSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebSiteResource() { }
        public virtual Azure.ResourceManager.AppService.WebSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult> AnalyzeCustomHostname(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.CustomHostnameAnalysisResult>> AnalyzeCustomHostnameAsync(string hostName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ApplySlotConfigToProduction(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplySlotConfigToProductionAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> Backup(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> BackupAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo> CreateOrUpdateHostSecret(string keyType, string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.KeyInfo>> CreateOrUpdateHostSecretAsync(string keyType, string keyName, Azure.ResourceManager.AppService.Models.KeyInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteBackupConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBackupConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteHostSecret(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteHostSecretAsync(string keyType, string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableAllForWebAppRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAllForWebAppRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequest> DiscoverBackup(Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.RestoreRequest>> DiscoverBackupAsync(Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateNewSitePublishingPassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateNewSitePublishingPasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetApplicationSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetApplicationSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> GetAuthSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> GetAuthSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> GetAuthSettingsV2(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> GetAuthSettingsV2Async(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource> GetAzureStorageAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource>> GetAzureStorageAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest> GetBackupConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest>> GetBackupConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.BasicPublishingCredentialsPolicyFtpResource GetBasicPublishingCredentialsPolicyFtp() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.WebSiteConfigResource> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.WebSiteConfigResource> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetContainerLogsZip(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetContainerLogsZipAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetFunctionsAdminToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetFunctionsAdminTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForWebAppRecommendations(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetHistoryForWebAppRecommendationsAsync(bool? expiredOnly = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.HostKeys> GetHostKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.HostKeys>> GetHostKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource> GetHybridConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.ServerfarmHybridConnectionNamespaceRelayResource>> GetHybridConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.LogsSiteConfigResource GetLogsSiteConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> GetMetadata(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> GetMetadataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource> GetMigrateMySqlStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.MigrateMySqlStatusResource>> GetMigrateMySqlStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource> GetNetworkFeatures(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.NetworkFeaturesResource>> GetNetworkFeaturesAsync(string view, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraceOperationV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTraces(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesV2(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.NetworkTrace> GetNetworkTracesV2Async(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.PerfMonResponse> GetPerfMonCounters(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.PerfMonResponse> GetPerfMonCountersAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> GetPremierAddOns(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> GetPremierAddOnsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource> GetPublishingCredentials(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.UserResource>> GetPublishingCredentialsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetPublishingProfileXmlWithSecrets(Azure.ResourceManager.AppService.Models.CsmPublishingProfileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetPublishingProfileXmlWithSecretsAsync(Azure.ResourceManager.AppService.Models.CsmPublishingProfileOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForWebAppRecommendations(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.AppServiceRecommendation> GetRecommendedRulesForWebAppRecommendationsAsync(bool? featured = default(bool?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> GetRelayServiceConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> GetRelayServiceConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.ScmSiteBasicPublishingCredentialsPolicyResource GetScmSiteBasicPublishingCredentialsPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackup(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteBackupResource>> GetSiteBackupAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteBackupCollection GetSiteBackups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.SiteBackupResource> GetSiteBackupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource> GetSiteConfigAppsetting(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigAppsettingResource>> GetSiteConfigAppsettingAsync(string appSettingKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteConfigAppsettingCollection GetSiteConfigAppsettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource> GetSiteConfigConnectionString(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteConfigConnectionStringResource>> GetSiteConfigConnectionStringAsync(string connectionStringKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteConfigConnectionStringCollection GetSiteConfigConnectionStrings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource> GetSiteContinuousWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteContinuousWebJobResource>> GetSiteContinuousWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteContinuousWebJobCollection GetSiteContinuousWebJobs() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource> GetSiteHybridConnection(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionResource>> GetSiteHybridConnectionAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource> GetSiteHybridConnectionNamespaceRelay(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayResource>> GetSiteHybridConnectionNamespaceRelayAsync(string namespaceName, string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteHybridConnectionNamespaceRelayCollection GetSiteHybridConnectionNamespaceRelays() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteHybridConnectionCollection GetSiteHybridConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource> GetSiteInstance(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteInstanceResource>> GetSiteInstanceAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteInstanceCollection GetSiteInstances() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteNetworkConfigResource GetSiteNetworkConfig() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag> GetSitePhpErrorLogFlag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SitePhpErrorLogFlag>> GetSitePhpErrorLogFlagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource> GetSitePremierAddon(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePremierAddonResource>> GetSitePremierAddonAsync(string premierAddOnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePremierAddonCollection GetSitePremierAddons() { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePrivateAccessResource GetSitePrivateAccess() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource> GetSitePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePrivateEndpointConnectionResource>> GetSitePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePrivateEndpointConnectionCollection GetSitePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource> GetSiteProcess(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteProcessResource>> GetSiteProcessAsync(string processId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteProcessCollection GetSiteProcesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource> GetSitePublicCertificate(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SitePublicCertificateResource>> GetSitePublicCertificateAsync(string publicCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SitePublicCertificateCollection GetSitePublicCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings> GetSitePushSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings>> GetSitePushSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource> GetSiteRecommendation(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteRecommendationResource>> GetSiteRecommendationAsync(string name, bool? updateSeen = default(bool?), string recommendationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteRecommendationCollection GetSiteRecommendations() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteResourceHealthMetadataResource GetSiteResourceHealthMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource> GetSiteSiteextension(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSiteextensionResource>> GetSiteSiteextensionAsync(string siteExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSiteextensionCollection GetSiteSiteextensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource> GetSiteSlot(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotResource>> GetSiteSlotAsync(string slot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotCollection GetSiteSlots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource> GetSiteSlotTriggeredWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobResource>> GetSiteSlotTriggeredWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSlotTriggeredWebJobCollection GetSiteSlotTriggeredWebJobs() { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteSourceControlResource GetSiteSourceControl() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource> GetSiteVirtualNetworkConnection(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionResource>> GetSiteVirtualNetworkConnectionAsync(string vnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteVirtualNetworkConnectionCollection GetSiteVirtualNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource> GetSiteWebJob(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.SiteWebJobResource>> GetSiteWebJobAsync(string webJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.SiteWebJobCollection GetSiteWebJobs() { throw null; }
        public virtual Azure.ResourceManager.AppService.SlotConfigNamesResource GetSlotConfigNamesResource() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesFromProduction(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.SlotDifference> GetSlotDifferencesFromProductionAsync(Azure.ResourceManager.AppService.Models.CsmSlotEntity slotSwapEntity, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsFromDRSecondary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.Snapshot> GetSnapshotsFromDRSecondaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets> GetSyncFunctionTriggers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.FunctionSecrets>> GetSyncFunctionTriggersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSyncStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSyncStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppService.Models.CsmUsageQuota> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppService.WebSiteConfigResource GetWebSiteConfig() { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetWebSiteContainerLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetWebSiteContainerLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability> IsCloneable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteCloneability>> IsCloneableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.OperationInformation> MigrateMySql(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MigrateMySqlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.OperationInformation>> MigrateMySqlAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.MigrateMySqlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.StorageMigrationResponse> MigrateStorage(Azure.WaitUntil waitUntil, string subscriptionName, Azure.ResourceManager.AppService.Models.StorageMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppService.Models.StorageMigrationResponse>> MigrateStorageAsync(Azure.WaitUntil waitUntil, string subscriptionName, Azure.ResourceManager.AppService.Models.StorageMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetAllFiltersForWebAppRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAllFiltersForWebAppRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetProductionSlotConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetProductionSlotConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(bool? softRestart = default(bool?), bool? synchronous = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromBackupBlob(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromBackupBlobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.RestoreRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFromDeletedApp(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFromDeletedAppAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.DeletedAppRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreSnapshot(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreSnapshotAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppService.Models.SnapshotRestoreRequest restoreRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>> StartNetworkTrace(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>>> StartNetworkTraceAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> StartWebSiteNetworkTrace(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> StartWebSiteNetworkTraceAsync(int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>> StartWebSiteNetworkTraceOperation(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NetworkTrace>>> StartWebSiteNetworkTraceOperationAsync(Azure.WaitUntil waitUntil, int? durationInSeconds = default(int?), int? maxFrameLength = default(int?), string sasUrl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.AppService.WebSiteResource> Update(Azure.ResourceManager.AppService.Models.SitePatchResource siteEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> UpdateApplicationSettings(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> UpdateApplicationSettingsAsync(Azure.ResourceManager.AppService.Models.StringDictionary appSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.WebSiteResource>> UpdateAsync(Azure.ResourceManager.AppService.Models.SitePatchResource siteEnvelope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings> UpdateAuthSettings(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettings>> UpdateAuthSettingsAsync(Azure.ResourceManager.AppService.Models.SiteAuthSettings siteAuthSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2> UpdateAuthSettingsV2(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2>> UpdateAuthSettingsV2Async(Azure.ResourceManager.AppService.Models.SiteAuthSettingsV2 siteAuthSettingsV2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource> UpdateAzureStorageAccounts(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource>> UpdateAzureStorageAccountsAsync(Azure.ResourceManager.AppService.Models.AzureStoragePropertyDictionaryResource azureStorageAccounts, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest> UpdateBackupConfiguration(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.BackupRequest>> UpdateBackupConfigurationAsync(Azure.ResourceManager.AppService.Models.BackupRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary> UpdateConnectionStrings(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.ConnectionStringDictionary>> UpdateConnectionStringsAsync(Azure.ResourceManager.AppService.Models.ConnectionStringDictionary connectionStrings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary> UpdateMetadata(Azure.ResourceManager.AppService.Models.StringDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.StringDictionary>> UpdateMetadataAsync(Azure.ResourceManager.AppService.Models.StringDictionary metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings> UpdateSitePushSettings(Azure.ResourceManager.AppService.Models.PushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppService.Models.PushSettings>> UpdateSitePushSettingsAsync(Azure.ResourceManager.AppService.Models.PushSettings pushSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WorkerPoolResourceData : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public WorkerPoolResourceData() { }
        public Azure.ResourceManager.AppService.Models.ComputeModeOptions? ComputeMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> InstanceNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SkuDescription Sku { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
        public string WorkerSize { get { throw null; } set { } }
        public int? WorkerSizeId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.AppService.Models
{
    public partial class AbnormalTimePeriod
    {
        public AbnormalTimePeriod() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorAbnormalTimePeriod> Events { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.Solution> Solutions { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class Address
    {
        public Address(string address1, string city, string country, string postalCode, string state) { }
        public string Address1 { get { throw null; } set { } }
        public string Address2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class AddressResponse : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AddressResponse() { }
        public string InternalIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutboundIPAddresses { get { throw null; } }
        public string ServiceIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualIPMapping> VipMappings { get { throw null; } }
    }
    public partial class AllowedPrincipals
    {
        public AllowedPrincipals() { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public System.Collections.Generic.IList<string> Identities { get { throw null; } }
    }
    public partial class AnalysisData
    {
        public AnalysisData() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair>> Data { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DataSource DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorDefinition DetectorDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DiagnosticMetricSet> Metrics { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class AppInsightsWebAppStackSettings
    {
        internal AppInsightsWebAppStackSettings() { }
        public bool? IsDefaultOff { get { throw null; } }
        public bool? IsSupported { get { throw null; } }
    }
    public partial class Apple
    {
        public Apple() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppleRegistration Registration { get { throw null; } set { } }
    }
    public partial class AppleRegistration
    {
        public AppleRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
    }
    public partial class ApplicationLogsConfig
    {
        public ApplicationLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.AzureBlobStorageApplicationLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureTableStorageApplicationLogsConfig AzureTableStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LogLevel? FileSystemLevel { get { throw null; } set { } }
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
    public partial class ApplicationStackResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ApplicationStackResource() { }
        public string Dependency { get { throw null; } set { } }
        public string Display { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> Frameworks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ApplicationStack> IsDeprecated { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.StackMajorVersion> MajorVersions { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
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
    public partial class AppServiceCertificate
    {
        public AppServiceCertificate() { }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
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
    public partial class AppServiceCertificateOrderPatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceCertificateOrderPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public bool? AutoRenew { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AppServiceCertificate> Certificates { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails Intermediate { get { throw null; } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuanceOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewalTimeStamp { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateProductType? ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
    }
    public partial class AppServiceCertificateResourcePatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceCertificateResourcePatch() { }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? ProvisioningState { get { throw null; } }
    }
    public partial class AppServiceDomainPatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceDomainPatch() { }
        public string AuthCode { get { throw null; } set { } }
        public bool? AutoRenew { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactBilling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactRegistrant { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContactInformation ContactTech { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.HostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public bool? Privacy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? ReadyForDnsRecordManagement { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DomainStatus? RegistrationStatus { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DnsType? TargetDnsType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceDomainPropertiesDomainNotRenewableReasonsItem : System.IEquatable<Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceDomainPropertiesDomainNotRenewableReasonsItem(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem left, Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem left, Azure.ResourceManager.AppService.Models.AppServiceDomainPropertiesDomainNotRenewableReasonsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceEnvironmentAutoGenerated
    {
        public AppServiceEnvironmentAutoGenerated(Azure.ResourceManager.AppService.Models.VirtualNetworkProfile virtualNetwork) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IpsslAddressCount { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public bool? Suspended { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.VirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class AppServiceEnvironmentPatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceEnvironmentPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> ClusterSettings { get { throw null; } }
        public int? DedicatedHostCount { get { throw null; } set { } }
        public string DnsSuffix { get { throw null; } set { } }
        public int? FrontEndScaleFactor { get { throw null; } set { } }
        public bool? HasLinuxWorkers { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.LoadBalancingMode? InternalLoadBalancingMode { get { throw null; } set { } }
        public int? IpsslAddressCount { get { throw null; } set { } }
        public int? MaximumNumberOfMachines { get { throw null; } }
        public int? MultiRoleCount { get { throw null; } }
        public string MultiSize { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentStatus? Status { get { throw null; } }
        public bool? Suspended { get { throw null; } }
        public System.Collections.Generic.IList<string> UserWhitelistedIPRanges { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.VirtualNetworkProfile VirtualNetwork { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class AppServicePlanPatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServicePlanPatch() { }
        public bool? ElasticScaleEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? FreeOfferExpirationOn { get { throw null; } set { } }
        public string GeoRegion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public bool? HyperV { get { throw null; } set { } }
        public bool? IsSpot { get { throw null; } set { } }
        public bool? IsXenon { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProfile KubeEnvironmentProfile { get { throw null; } set { } }
        public int? MaximumElasticWorkerCount { get { throw null; } set { } }
        public int? MaximumNumberOfWorkers { get { throw null; } }
        public int? NumberOfSites { get { throw null; } }
        public bool? PerSiteScaling { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Reserved { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public System.DateTimeOffset? SpotExpirationOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StatusOptions? Status { get { throw null; } }
        public string Subscription { get { throw null; } }
        public int? TargetWorkerCount { get { throw null; } set { } }
        public int? TargetWorkerSizeId { get { throw null; } set { } }
        public string WorkerTierName { get { throw null; } set { } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public enum AppServicePlanRestrictions
    {
        None = 0,
        Free = 1,
        Shared = 2,
        Basic = 3,
        Standard = 4,
        Premium = 5,
    }
    public partial class AppServicePrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        internal AppServicePrivateLinkResource() { }
        public Azure.ResourceManager.AppService.Models.AppServicePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class AppServicePrivateLinkResourceProperties
    {
        internal AppServicePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class AppServiceRecommendation : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceRecommendation() { }
        public string ActionName { get { throw null; } set { } }
        public string BladeName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryTags { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.Channels? Channels { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        public string ForwardLink { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.NotificationLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? NextNotificationOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotificationExpirationOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotifiedOn { get { throw null; } set { } }
        public System.Guid? RecommendationId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ResourceScopeType? ResourceScope { get { throw null; } set { } }
        public string RuleName { get { throw null; } set { } }
        public double? Score { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> States { get { throw null; } }
    }
    public partial class AppServiceResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppServiceResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Kind { get { throw null; } set { } }
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
    public partial class AppServiceUsage : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AppServiceUsage() { }
        public Azure.ResourceManager.AppService.Models.ComputeModeOptions? ComputeMode { get { throw null; } }
        public long? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public long? Limit { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string SiteMode { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ArcConfiguration
    {
        public ArcConfiguration() { }
        public Azure.ResourceManager.AppService.Models.StorageType? ArtifactsStorageType { get { throw null; } set { } }
        public string ArtifactStorageAccessMode { get { throw null; } set { } }
        public string ArtifactStorageClassName { get { throw null; } set { } }
        public string ArtifactStorageMountPath { get { throw null; } set { } }
        public string ArtifactStorageNodeName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FrontEndServiceType? FrontEndServiceKind { get { throw null; } set { } }
        public string KubeConfig { get { throw null; } set { } }
    }
    public partial class ArmPlan
    {
        internal ArmPlan() { }
        public string Name { get { throw null; } }
        public string Product { get { throw null; } }
        public string PromotionCode { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class AuthPlatform
    {
        public AuthPlatform() { }
        public string ConfigFilePath { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
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
    public partial class AzureActiveDirectory
    {
        public AzureActiveDirectory() { }
        public bool? Enabled { get { throw null; } set { } }
        public bool? IsAutoProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureActiveDirectoryLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureActiveDirectoryRegistration Registration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureActiveDirectoryValidation Validation { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectoryLogin
    {
        public AzureActiveDirectoryLogin() { }
        public bool? DisableWWWAuthenticate { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginParameters { get { throw null; } }
    }
    public partial class AzureActiveDirectoryRegistration
    {
        public AzureActiveDirectoryRegistration() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecretCertificateIssuer { get { throw null; } set { } }
        public string ClientSecretCertificateSubjectAlternativeName { get { throw null; } set { } }
        public string ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string OpenIdIssuer { get { throw null; } set { } }
    }
    public partial class AzureActiveDirectoryValidation
    {
        public AzureActiveDirectoryValidation() { }
        public System.Collections.Generic.IList<string> AllowedAudiences { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DefaultAuthorizationPolicy DefaultAuthorizationPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.JwtClaimChecks JwtClaimChecks { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageApplicationLogsConfig
    {
        public AzureBlobStorageApplicationLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.LogLevel? Level { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class AzureBlobStorageHttpLogsConfig
    {
        public AzureBlobStorageHttpLogsConfig() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public enum AzureResourceType
    {
        Website = 0,
        TrafficManager = 1,
    }
    public partial class AzureStaticWebApps
    {
        public AzureStaticWebApps() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RegistrationClientId { get { throw null; } set { } }
    }
    public partial class AzureStorageInfoValue
    {
        public AzureStorageInfoValue() { }
        public string AccessKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string MountPath { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureStorageState? State { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AzureStorageType? StorageType { get { throw null; } set { } }
    }
    public partial class AzureStoragePropertyDictionaryResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public AzureStoragePropertyDictionaryResource() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AzureStorageInfoValue> Properties { get { throw null; } }
    }
    public enum AzureStorageState
    {
        Ok = 0,
        InvalidCredentials = 1,
        InvalidShare = 2,
        NotValidated = 3,
    }
    public enum AzureStorageType
    {
        AzureFiles = 0,
        AzureBlob = 1,
    }
    public partial class AzureTableStorageApplicationLogsConfig
    {
        public AzureTableStorageApplicationLogsConfig(System.Uri sasUri) { }
        public Azure.ResourceManager.AppService.Models.LogLevel? Level { get { throw null; } set { } }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public enum BackupItemStatus
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
    public partial class BackupRequest : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public BackupRequest() { }
        public string BackupName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BackupSchedule BackupSchedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DatabaseBackupSetting> Databases { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
    }
    public enum BackupRestoreOperationType
    {
        Default = 0,
        Clone = 1,
        Relocation = 2,
        Snapshot = 3,
        CloudFS = 4,
    }
    public partial class BackupSchedule
    {
        public BackupSchedule(int frequencyInterval, Azure.ResourceManager.AppService.Models.FrequencyUnit frequencyUnit, bool keepAtLeastOneBackup, int retentionPeriodInDays) { }
        public int FrequencyInterval { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FrequencyUnit FrequencyUnit { get { throw null; } set { } }
        public bool KeepAtLeastOneBackup { get { throw null; } set { } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public int RetentionPeriodInDays { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class BillingMeter : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public BillingMeter() { }
        public string BillingLocation { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string MeterId { get { throw null; } set { } }
        public double? Multiplier { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string ShortName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BuildStatus : System.IEquatable<Azure.ResourceManager.AppService.Models.BuildStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BuildStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Deploying { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Detached { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus Uploading { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.BuildStatus WaitingForDeployment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.BuildStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.BuildStatus left, Azure.ResourceManager.AppService.Models.BuildStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.BuildStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.BuildStatus left, Azure.ResourceManager.AppService.Models.BuildStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class Capability
    {
        public Capability() { }
        public string Name { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class CertificateDetails
    {
        internal CertificateDetails() { }
        public string Issuer { get { throw null; } }
        public System.DateTimeOffset? NotAfter { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public string RawData { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class CertificateEmail : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public CertificateEmail() { }
        public string EmailId { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    public partial class CertificateOrderAction : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public CertificateOrderAction() { }
        public Azure.ResourceManager.AppService.Models.CertificateOrderActionType? ActionType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
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
    public partial class CertificatePatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public CertificatePatch() { }
        public string CanonicalName { get { throw null; } set { } }
        public byte[] CerBlob { get { throw null; } }
        public string DomainValidationMethod { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> HostNames { get { throw null; } }
        public System.DateTimeOffset? IssueOn { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KeyVaultSecretStatus? KeyVaultSecretStatus { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public byte[] PfxBlob { get { throw null; } set { } }
        public string PublicKeyHash { get { throw null; } }
        public string SelfLink { get { throw null; } }
        public string ServerFarmId { get { throw null; } set { } }
        public string SiteName { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public bool? Valid { get { throw null; } }
    }
    public enum CertificateProductType
    {
        StandardDomainValidatedSsl = 0,
        StandardDomainValidatedWildCardSsl = 1,
    }
    public enum Channels
    {
        Notification = 0,
        Api = 1,
        Email = 2,
        Webhook = 3,
        All = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameResourceTypes : System.IEquatable<Azure.ResourceManager.AppService.Models.CheckNameResourceTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameResourceTypes(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes HostingEnvironment { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes MicrosoftWebHostingEnvironments { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes MicrosoftWebPublishingUsers { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes MicrosoftWebSites { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes MicrosoftWebSitesSlots { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes PublishingUser { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes Slot { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.CheckNameResourceTypes WebSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.CheckNameResourceTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.CheckNameResourceTypes left, Azure.ResourceManager.AppService.Models.CheckNameResourceTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.CheckNameResourceTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.CheckNameResourceTypes left, Azure.ResourceManager.AppService.Models.CheckNameResourceTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ClientCertMode
    {
        Required = 0,
        Optional = 1,
        OptionalInteractiveUser = 2,
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
        public CloningInfo(string sourceWebAppId) { }
        public System.Collections.Generic.IDictionary<string, string> AppSettingsOverrides { get { throw null; } }
        public bool? CloneCustomHostNames { get { throw null; } set { } }
        public bool? CloneSourceControl { get { throw null; } set { } }
        public bool? ConfigureLoadBalancing { get { throw null; } set { } }
        public System.Guid? CorrelationId { get { throw null; } set { } }
        public string HostingEnvironment { get { throw null; } set { } }
        public bool? Overwrite { get { throw null; } set { } }
        public string SourceWebAppId { get { throw null; } set { } }
        public string SourceWebAppLocation { get { throw null; } set { } }
        public string TrafficManagerProfileId { get { throw null; } set { } }
        public string TrafficManagerProfileName { get { throw null; } set { } }
    }
    public enum ComputeModeOptions
    {
        Shared = 0,
        Dedicated = 1,
        Dynamic = 2,
    }
    public partial class ConnectionStringDictionary : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ConnectionStringDictionary() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.ConnStringValueTypePair> Properties { get { throw null; } }
    }
    public enum ConnectionStringType
    {
        MySql = 0,
        SQLServer = 1,
        SQLAzure = 2,
        Custom = 3,
        NotificationHub = 4,
        ServiceBus = 5,
        EventHub = 6,
        ApiHub = 7,
        DocDb = 8,
        RedisCache = 9,
        PostgreSQL = 10,
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
    public partial class ContactInformation
    {
        public ContactInformation(string email, string nameFirst, string nameLast, string phone) { }
        public Azure.ResourceManager.AppService.Models.Address AddressMailing { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Fax { get { throw null; } set { } }
        public string JobTitle { get { throw null; } set { } }
        public string NameFirst { get { throw null; } set { } }
        public string NameLast { get { throw null; } set { } }
        public string NameMiddle { get { throw null; } set { } }
        public string Organization { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class ContainerCpuStatistics
    {
        public ContainerCpuStatistics() { }
        public Azure.ResourceManager.AppService.Models.ContainerCpuUsage CpuUsage { get { throw null; } set { } }
        public int? OnlineCpuCount { get { throw null; } set { } }
        public long? SystemCpuUsage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ContainerThrottlingData ThrottlingData { get { throw null; } set { } }
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
    public partial class ContainerThrottlingData
    {
        public ContainerThrottlingData() { }
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
    public partial class CookieExpiration
    {
        public CookieExpiration() { }
        public Azure.ResourceManager.AppService.Models.CookieExpirationConvention? Convention { get { throw null; } set { } }
        public string TimeToExpiration { get { throw null; } set { } }
    }
    public enum CookieExpirationConvention
    {
        FixedTime = 0,
        IdentityProviderDerived = 1,
    }
    public partial class CorsSettings
    {
        public CorsSettings() { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public bool? SupportCredentials { get { throw null; } set { } }
    }
    public partial class CsmMoveResourceEnvelope
    {
        public CsmMoveResourceEnvelope() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } set { } }
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
    public partial class CsmPublishingProfileOptions
    {
        public CsmPublishingProfileOptions() { }
        public Azure.ResourceManager.AppService.Models.PublishingProfileFormat? Format { get { throw null; } set { } }
        public bool? IncludeDisasterRecoveryEndpoints { get { throw null; } set { } }
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
    public partial class CustomHostnameAnalysisResult : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
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
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectLogin Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.OpenIdConnectRegistration Registration { get { throw null; } set { } }
    }
    public partial class DatabaseBackupSetting
    {
        public DatabaseBackupSetting(Azure.ResourceManager.AppService.Models.DatabaseType databaseType) { }
        public string ConnectionString { get { throw null; } set { } }
        public string ConnectionStringName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DatabaseType DatabaseType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseType : System.IEquatable<Azure.ResourceManager.AppService.Models.DatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.DatabaseType LocalMySql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DatabaseType MySql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DatabaseType PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DatabaseType SqlAzure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.DatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.DatabaseType left, Azure.ResourceManager.AppService.Models.DatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.DatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.DatabaseType left, Azure.ResourceManager.AppService.Models.DatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProviderMetadata
    {
        public DataProviderMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.KeyValuePairStringObject> PropertyBag { get { throw null; } }
        public string ProviderName { get { throw null; } set { } }
    }
    public partial class DataSource
    {
        public DataSource() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> DataSourceUri { get { throw null; } }
        public System.Collections.Generic.IList<string> Instructions { get { throw null; } }
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
        public Azure.ResourceManager.AppService.Models.AllowedPrincipals AllowedPrincipals { get { throw null; } set { } }
    }
    public partial class DeletedAppRestoreRequest : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DeletedAppRestoreRequest() { }
        public string DeletedSiteId { get { throw null; } set { } }
        public bool? RecoverConfiguration { get { throw null; } set { } }
        public string SnapshotTime { get { throw null; } set { } }
        public bool? UseDRSecondary { get { throw null; } set { } }
    }
    public partial class DeploymentLocations
    {
        internal DeploymentLocations() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.HostingEnvironmentDeploymentInfo> HostingEnvironmentDeploymentInfos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.AppServiceEnvironmentAutoGenerated> HostingEnvironments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.GeoRegion> Locations { get { throw null; } }
    }
    public partial class DetectorAbnormalTimePeriod
    {
        public DetectorAbnormalTimePeriod() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.IssueType? IssueType { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair>> MetaData { get { throw null; } }
        public double? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.Solution> Solutions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.SupportTopic> SupportTopicList { get { throw null; } }
    }
    public enum DetectorType
    {
        Detector = 0,
        Analysis = 1,
        CategoryOverview = 2,
    }
    public partial class DiagnosticAnalysis : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DiagnosticAnalysis() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AbnormalTimePeriod> AbnormalTimePeriods { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorDefinition> NonCorrelatedDetectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.AnalysisData> Payload { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class DiagnosticData
    {
        public DiagnosticData() { }
        public Azure.ResourceManager.AppService.Models.Rendering RenderingProperties { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DataTableResponseObject Table { get { throw null; } set { } }
    }
    public partial class DiagnosticDetectorResponse : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public DiagnosticDetectorResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DetectorAbnormalTimePeriod> AbnormalTimePeriods { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair>> Data { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DataSource DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.DetectorDefinition DetectorDefinition { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public bool? IssueDetected { get { throw null; } set { } }
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
    public partial class Dimension
    {
        internal Dimension() { }
        public string DisplayName { get { throw null; } }
        public string InternalName { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ToBeExportedForShoebox { get { throw null; } }
    }
    public enum DnsType
    {
        AzureDns = 0,
        DefaultDomainRegistrarDns = 1,
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
        public bool? Available { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.DomainType? DomainType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DomainControlCenterSsoRequest
    {
        internal DomainControlCenterSsoRequest() { }
        public string PostParameterKey { get { throw null; } }
        public string PostParameterValue { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNotRenewableReasons : System.IEquatable<Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNotRenewableReasons(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons left, Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons left, Azure.ResourceManager.AppService.Models.DomainNotRenewableReasons right) { throw null; }
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
    public enum DomainStatus
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
    public enum DomainType
    {
        Regular = 0,
        SoftDeleted = 1,
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public string IPAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? Latency { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public string ExtendedLocationType { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class Facebook
    {
        public Facebook() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GraphApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AppRegistration Registration { get { throw null; } set { } }
    }
    public partial class FileSystemHttpLogsConfig
    {
        public FileSystemHttpLogsConfig() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public int? RetentionInMb { get { throw null; } set { } }
    }
    public partial class ForwardProxy
    {
        public ForwardProxy() { }
        public Azure.ResourceManager.AppService.Models.ForwardProxyConvention? Convention { get { throw null; } set { } }
        public string CustomHostHeaderName { get { throw null; } set { } }
        public string CustomProtoHeaderName { get { throw null; } set { } }
    }
    public enum ForwardProxyConvention
    {
        NoProxy = 0,
        Standard = 1,
        Custom = 2,
    }
    public enum FrequencyUnit
    {
        Day = 0,
        Hour = 1,
    }
    public enum FrontEndServiceType
    {
        NodePort = 0,
        LoadBalancer = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FtpsState : System.IEquatable<Azure.ResourceManager.AppService.Models.FtpsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FtpsState(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.FtpsState AllAllowed { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.FtpsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.FtpsState FtpsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.FtpsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.FtpsState left, Azure.ResourceManager.AppService.Models.FtpsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.FtpsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.FtpsState left, Azure.ResourceManager.AppService.Models.FtpsState right) { throw null; }
        public override string ToString() { throw null; }
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
        public bool? RemoteDebuggingSupported { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SiteConfigPropertiesDictionary SiteConfigPropertiesDictionary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedFunctionsExtensionVersions { get { throw null; } }
    }
    public partial class FunctionAppStack : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public FunctionAppStack() { }
        public string DisplayText { get { throw null; } }
        public string Location { get { throw null; } }
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
    public partial class GeoRegion : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public GeoRegion() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string OrgDomain { get { throw null; } }
    }
    public partial class GitHub
    {
        public GitHub() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ClientRegistration Registration { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.Capability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SkuCapacity Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class GlobalValidation
    {
        public GlobalValidation() { }
        public System.Collections.Generic.IList<string> ExcludedPaths { get { throw null; } }
        public string RedirectToProvider { get { throw null; } set { } }
        public bool? RequireAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.UnauthenticatedClientActionV2? UnauthenticatedClientAction { get { throw null; } set { } }
    }
    public partial class Google
    {
        public Google() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoginScopes { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ClientRegistration Registration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationAllowedAudiences { get { throw null; } }
    }
    public partial class HandlerMapping
    {
        public HandlerMapping() { }
        public string Arguments { get { throw null; } set { } }
        public string Extension { get { throw null; } set { } }
        public string ScriptProcessor { get { throw null; } set { } }
    }
    public partial class HostingEnvironmentDeploymentInfo
    {
        internal HostingEnvironmentDeploymentInfo() { }
        public string Location { get { throw null; } }
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
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum HostingEnvironmentStatus
    {
        Preparing = 0,
        Ready = 1,
        Scaling = 2,
        Deleting = 3,
    }
    public partial class HostKeys
    {
        internal HostKeys() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FunctionKeys { get { throw null; } }
        public string MasterKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemKeys { get { throw null; } }
    }
    public partial class HostName
    {
        internal HostName() { }
        public string AzureResourceName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.AzureResourceType? AzureResourceType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostNameType? HostNameType { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SiteNames { get { throw null; } }
    }
    public partial class HostNameSslState
    {
        public HostNameSslState() { }
        public Azure.ResourceManager.AppService.Models.HostType? HostType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SslState? SslState { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public bool? ToUpdate { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } set { } }
    }
    public enum HostNameType
    {
        Verified = 0,
        Managed = 1,
    }
    public enum HostType
    {
        Standard = 0,
        Repository = 1,
    }
    public partial class HttpLogsConfig
    {
        public HttpLogsConfig() { }
        public Azure.ResourceManager.AppService.Models.AzureBlobStorageHttpLogsConfig AzureBlobStorage { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.FileSystemHttpLogsConfig FileSystem { get { throw null; } set { } }
    }
    public partial class HttpSettings
    {
        public HttpSettings() { }
        public Azure.ResourceManager.AppService.Models.ForwardProxy ForwardProxy { get { throw null; } set { } }
        public bool? RequireHttps { get { throw null; } set { } }
        public string RoutesApiPrefix { get { throw null; } set { } }
    }
    public partial class HybridConnectionKey : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public HybridConnectionKey() { }
        public string SendKeyName { get { throw null; } }
        public string SendKeyValue { get { throw null; } }
    }
    public partial class IdentityProviders
    {
        public IdentityProviders() { }
        public Azure.ResourceManager.AppService.Models.Apple Apple { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AzureStaticWebApps AzureStaticWebApps { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.CustomOpenIdConnectProvider> CustomOpenIdConnectProviders { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.Facebook Facebook { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.GitHub GitHub { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.Google Google { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LegacyMicrosoftAccount LegacyMicrosoftAccount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.Twitter Twitter { get { throw null; } set { } }
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
    public enum InsightStatus
    {
        None = 0,
        Critical = 1,
        Warning = 2,
        Info = 3,
        Success = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPFilterTag : System.IEquatable<Azure.ResourceManager.AppService.Models.IPFilterTag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPFilterTag(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.IPFilterTag Default { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.IPFilterTag ServiceTag { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.IPFilterTag XffProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.IPFilterTag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.IPFilterTag left, Azure.ResourceManager.AppService.Models.IPFilterTag right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.IPFilterTag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.IPFilterTag left, Azure.ResourceManager.AppService.Models.IPFilterTag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPSecurityRestriction
    {
        public IPSecurityRestriction() { }
        public string Action { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Headers { get { throw null; } }
        public string IPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string SubnetMask { get { throw null; } set { } }
        public int? SubnetTrafficTag { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.IPFilterTag? Tag { get { throw null; } set { } }
        public string VnetSubnetResourceId { get { throw null; } set { } }
        public int? VnetTrafficTag { get { throw null; } set { } }
    }
    public enum IssueType
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
    public partial class JwtClaimChecks
    {
        public JwtClaimChecks() { }
        public System.Collections.Generic.IList<string> AllowedClientApplications { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedGroups { get { throw null; } }
    }
    public partial class KeyInfo
    {
        public KeyInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class KeyValuePairStringObject
    {
        internal KeyValuePairStringObject() { }
        public string Key { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
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
    public partial class KubeEnvironmentPatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public KubeEnvironmentPatch() { }
        public string AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppLogsConfiguration AppLogsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ArcConfiguration ArcConfiguration { get { throw null; } set { } }
        public string DefaultDomain { get { throw null; } }
        public string DeploymentErrors { get { throw null; } }
        public bool? InternalLoadBalancerEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.KubeEnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
    }
    public partial class KubeEnvironmentProfile
    {
        public KubeEnvironmentProfile() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
        public bool? Enabled { get { throw null; } set { } }
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
    public partial class LoginInformation
    {
        public LoginInformation() { }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.CookieExpiration CookieExpiration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.Nonce Nonce { get { throw null; } set { } }
        public bool? PreserveUrlFragmentsForLogins { get { throw null; } set { } }
        public string RoutesLogoutEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TokenStore TokenStore { get { throw null; } set { } }
    }
    public enum LogLevel
    {
        Off = 0,
        Verbose = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
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
    public partial class MetricSpecification
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.MetricAvailability> Availabilities { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.Dimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? EnableRegionalMdmAccount { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public bool? IsInternal { get { throw null; } }
        public string MetricFilterPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public string SourceMdmAccount { get { throw null; } }
        public string SourceMdmNamespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedAggregationTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTimeGrainTypes { get { throw null; } }
        public bool? SupportsInstanceLevelAggregation { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class MigrateMySqlContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public MigrateMySqlContent() { }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.MySqlMigrationType? MigrationType { get { throw null; } set { } }
    }
    public partial class MsDeploy : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public MsDeploy() { }
        public bool? AppOffline { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string DbType { get { throw null; } set { } }
        public System.Uri PackageUri { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SetParameters { get { throw null; } }
        public System.Uri SetParametersXmlFileUri { get { throw null; } set { } }
        public bool? SkipAppData { get { throw null; } set { } }
    }
    public partial class MsDeployLog : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public MsDeployLog() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.MsDeployLogEntry> Entries { get { throw null; } }
    }
    public partial class MsDeployLogEntry
    {
        internal MsDeployLogEntry() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.MSDeployLogEntryType? MSDeployLogEntryType { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public enum MSDeployLogEntryType
    {
        Message = 0,
        Warning = 1,
        Error = 2,
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
    public partial class NameIdentifier
    {
        public NameIdentifier() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class NameValuePair
    {
        public NameValuePair() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NetworkTrace
    {
        internal NetworkTrace() { }
        public string Message { get { throw null; } }
        public string Path { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class Nonce
    {
        public Nonce() { }
        public string NonceExpirationInterval { get { throw null; } set { } }
        public bool? ValidateNonce { get { throw null; } set { } }
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
        public string Method { get { throw null; } set { } }
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
    public partial class OperationInformation
    {
        internal OperationInformation() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public System.Guid? GeoMasterOperationId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.OperationStatus? Status { get { throw null; } }
    }
    public enum OperationStatus
    {
        InProgress = 0,
        Failed = 1,
        Succeeded = 2,
        TimedOut = 3,
        Created = 4,
    }
    public partial class OperationStatusAutoGenerated
    {
        public OperationStatusAutoGenerated() { }
        public string Message { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.InsightStatus? StatusId { get { throw null; } set { } }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class PerfMonResponse
    {
        internal PerfMonResponse() { }
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
    public partial class PremierAddOnOffer : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PremierAddOnOffer() { }
        public System.Uri LegalTermsUri { get { throw null; } set { } }
        public string MarketplaceOffer { get { throw null; } set { } }
        public string MarketplacePublisher { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public bool? PromoCodeRequired { get { throw null; } set { } }
        public int? Quota { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AppServicePlanRestrictions? WebHostingPlanRestrictions { get { throw null; } set { } }
    }
    public partial class PremierAddOnPatchResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PremierAddOnPatchResource() { }
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
        public string ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.PrivateAccessSubnet> Subnets { get { throw null; } }
    }
    public partial class PrivateLinkConnectionApprovalRequestResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PrivateLinkConnectionApprovalRequestResource() { }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    public partial class PrivateLinkConnectionState
    {
        public PrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class ProcessThreadInfo : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ProcessThreadInfo() { }
        public int? BasePriority { get { throw null; } set { } }
        public int? CurrentPriority { get { throw null; } set { } }
        public string Href { get { throw null; } set { } }
        public int? Identifier { get { throw null; } }
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
    public partial class ProxyOnlyResource : Azure.ResourceManager.Models.ResourceData
    {
        public ProxyOnlyResource() { }
        public string Kind { get { throw null; } set { } }
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
    public partial class PushSettings : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public PushSettings() { }
        public string DynamicTagsJson { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string TagsRequiringAuth { get { throw null; } set { } }
        public string TagWhitelistJson { get { throw null; } set { } }
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
    public enum RedundancyMode
    {
        None = 0,
        Manual = 1,
        Failover = 2,
        ActiveActive = 3,
        GeoRedundant = 4,
    }
    public partial class ReissueCertificateOrderContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ReissueCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public int? DelayExistingRevokeInHours { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnection : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RemotePrivateEndpointConnection() { }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class Rendering
    {
        public Rendering() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RenderingType? RenderingType { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public enum RenderingType
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
    public partial class RenewCertificateOrderContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RenewCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
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
    public partial class ResourceMetricDefinition : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public ResourceMetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResourceMetricAvailability> MetricAvailabilities { get { throw null; } }
        public string PrimaryAggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Uri ResourceUri { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ResourceNameAvailability
    {
        internal ResourceNameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.InAvailabilityReasonType? Reason { get { throw null; } }
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
        public string Location { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ArmPlan Plan { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RemotePrivateEndpointConnection Properties { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SkuDescription Sku { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class RestoreRequest : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public RestoreRequest() { }
        public bool? AdjustConnectionStrings { get { throw null; } set { } }
        public string AppServicePlan { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.DatabaseBackupSetting> Databases { get { throw null; } }
        public string HostingEnvironment { get { throw null; } set { } }
        public bool? IgnoreConflictingHostNames { get { throw null; } set { } }
        public bool? IgnoreDatabases { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BackupRestoreOperationType? OperationType { get { throw null; } set { } }
        public bool? Overwrite { get { throw null; } set { } }
        public string SiteName { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteType : System.IEquatable<Azure.ResourceManager.AppService.Models.RouteType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteType(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.RouteType Default { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.RouteType Inherited { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.RouteType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.RouteType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.RouteType left, Azure.ResourceManager.AppService.Models.RouteType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.RouteType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.RouteType left, Azure.ResourceManager.AppService.Models.RouteType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class SiteAuthSettings : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteAuthSettings() { }
        public string AadClaimsAuthorization { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AdditionalLoginParams { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedExternalRedirectUrls { get { throw null; } }
        public string AuthFilePath { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string ClientSecretCertificateThumbprint { get { throw null; } set { } }
        public string ClientSecretSettingName { get { throw null; } set { } }
        public string ConfigVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.BuiltInAuthenticationProvider? DefaultProvider { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
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
        public string Issuer { get { throw null; } set { } }
        public string MicrosoftAccountClientId { get { throw null; } set { } }
        public string MicrosoftAccountClientSecret { get { throw null; } set { } }
        public string MicrosoftAccountClientSecretSettingName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MicrosoftAccountOAuthScopes { get { throw null; } }
        public string RuntimeVersion { get { throw null; } set { } }
        public double? TokenRefreshExtensionHours { get { throw null; } set { } }
        public bool? TokenStoreEnabled { get { throw null; } set { } }
        public string TwitterConsumerKey { get { throw null; } set { } }
        public string TwitterConsumerSecret { get { throw null; } set { } }
        public string TwitterConsumerSecretSettingName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.UnauthenticatedClientAction? UnauthenticatedClientAction { get { throw null; } set { } }
        public bool? ValidateIssuer { get { throw null; } set { } }
    }
    public partial class SiteAuthSettingsV2 : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteAuthSettingsV2() { }
        public Azure.ResourceManager.AppService.Models.GlobalValidation GlobalValidation { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.HttpSettings HttpSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.IdentityProviders IdentityProviders { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.LoginInformation Login { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AuthPlatform Platform { get { throw null; } set { } }
    }
    public enum SiteAvailabilityState
    {
        Normal = 0,
        Limited = 1,
        DisasterRecoveryMode = 2,
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
        public bool? AcrUseManagedIdentityCreds { get { throw null; } set { } }
        public string AcrUserManagedIdentityId { get { throw null; } set { } }
        public bool? AlwaysOn { get { throw null; } set { } }
        public System.Uri ApiDefinitionUri { get { throw null; } set { } }
        public string ApiManagementConfigId { get { throw null; } set { } }
        public string AppCommandLine { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair> AppSettings { get { throw null; } set { } }
        public bool? AutoHealEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.AutoHealRules AutoHealRules { get { throw null; } set { } }
        public string AutoSwapSlotName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.AppService.Models.AzureStorageInfoValue> AzureStorageAccounts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.ConnStringInfo> ConnectionStrings { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CorsSettings Cors { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultDocuments { get { throw null; } set { } }
        public bool? DetailedErrorLoggingEnabled { get { throw null; } set { } }
        public string DocumentRoot { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.RampUpRule> ExperimentsRampUpRules { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.FtpsState? FtpsState { get { throw null; } set { } }
        public int? FunctionAppScaleLimit { get { throw null; } set { } }
        public bool? FunctionsRuntimeScaleMonitoringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HandlerMapping> HandlerMappings { get { throw null; } set { } }
        public string HealthCheckPath { get { throw null; } set { } }
        public bool? Http20Enabled { get { throw null; } set { } }
        public bool? HttpLoggingEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.IPSecurityRestriction> IPSecurityRestrictions { get { throw null; } set { } }
        public string JavaContainer { get { throw null; } set { } }
        public string JavaContainerVersion { get { throw null; } set { } }
        public string JavaVersion { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLimits Limits { get { throw null; } set { } }
        public string LinuxFxVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteLoadBalancing? LoadBalancing { get { throw null; } set { } }
        public bool? LocalMySqlEnabled { get { throw null; } set { } }
        public int? LogsDirectorySizeLimit { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteMachineKey MachineKey { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.ManagedPipelineMode? ManagedPipelineMode { get { throw null; } set { } }
        public int? ManagedServiceIdentityId { get { throw null; } set { } }
        public int? MinimumElasticInstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SupportedTlsVersions? MinTlsVersion { get { throw null; } set { } }
        public string NetFrameworkVersion { get { throw null; } set { } }
        public string NodeVersion { get { throw null; } set { } }
        public int? NumberOfWorkers { get { throw null; } set { } }
        public string PhpVersion { get { throw null; } set { } }
        public string PowerShellVersion { get { throw null; } set { } }
        public int? PreWarmedInstanceCount { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingUsername { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.PushSettings Push { get { throw null; } set { } }
        public string PythonVersion { get { throw null; } set { } }
        public bool? RemoteDebuggingEnabled { get { throw null; } set { } }
        public string RemoteDebuggingVersion { get { throw null; } set { } }
        public bool? RequestTracingEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? RequestTracingExpirationOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.IPSecurityRestriction> ScmIPSecurityRestrictions { get { throw null; } set { } }
        public bool? ScmIPSecurityRestrictionsUseMain { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SupportedTlsVersions? ScmMinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ScmType? ScmType { get { throw null; } set { } }
        public string TracingOptions { get { throw null; } set { } }
        public bool? Use32BitWorkerProcess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VirtualApplication> VirtualApplications { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public int? VnetPrivatePortsCount { get { throw null; } set { } }
        public bool? VnetRouteAllEnabled { get { throw null; } set { } }
        public string WebsiteTimeZone { get { throw null; } set { } }
        public bool? WebSocketsEnabled { get { throw null; } set { } }
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
    public partial class SiteConfigurationSnapshotInfo : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SiteConfigurationSnapshotInfo() { }
        public int? SnapshotId { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
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
    public partial class SitePatchResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SitePatchResource() { }
        public Azure.ResourceManager.AppService.Models.SiteAvailabilityState? AvailabilityState { get { throw null; } }
        public bool? ClientAffinityEnabled { get { throw null; } set { } }
        public bool? ClientCertEnabled { get { throw null; } set { } }
        public string ClientCertExclusionPaths { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ClientCertMode? ClientCertMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.CloningInfo CloningInfo { get { throw null; } set { } }
        public int? ContainerSize { get { throw null; } set { } }
        public string CustomDomainVerificationId { get { throw null; } set { } }
        public int? DailyMemoryTimeQuota { get { throw null; } set { } }
        public string DefaultHostName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.HostingEnvironmentProfile HostingEnvironmentProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HostNames { get { throw null; } }
        public bool? HostNamesDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.HostNameSslState> HostNameSslStates { get { throw null; } }
        public bool? HttpsOnly { get { throw null; } set { } }
        public bool? HyperV { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InProgressOperationId { get { throw null; } }
        public bool? IsDefaultContainer { get { throw null; } }
        public bool? IsXenon { get { throw null; } set { } }
        public string KeyVaultReferenceIdentity { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public int? MaxNumberOfWorkers { get { throw null; } }
        public string OutboundIPAddresses { get { throw null; } }
        public string PossibleOutboundIPAddresses { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.RedundancyMode? RedundancyMode { get { throw null; } set { } }
        public string RepositorySiteName { get { throw null; } }
        public bool? Reserved { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public bool? ScmSiteAlsoStopped { get { throw null; } set { } }
        public string ServerFarmId { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SiteConfigProperties SiteConfig { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SlotSwapStatus SlotSwapStatus { get { throw null; } }
        public string State { get { throw null; } }
        public bool? StorageAccountRequired { get { throw null; } set { } }
        public System.DateTimeOffset? SuspendedTill { get { throw null; } }
        public string TargetSwapSlot { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TrafficManagerHostNames { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.UsageState? UsageState { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class SitePhpErrorLogFlag : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SitePhpErrorLogFlag() { }
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
        public bool? LightTheme { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
    }
    public partial class SkuCapacity
    {
        public SkuCapacity() { }
        public int? Default { get { throw null; } set { } }
        public int? ElasticMaximum { get { throw null; } set { } }
        public int? Maximum { get { throw null; } set { } }
        public int? Minimum { get { throw null; } set { } }
        public string ScaleType { get { throw null; } set { } }
    }
    public partial class SkuDescription
    {
        public SkuDescription() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.Capability> Capabilities { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SkuCapacity SkuCapacity { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SkuInfo
    {
        internal SkuInfo() { }
        public Azure.ResourceManager.AppService.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.SkuDescription Sku { get { throw null; } }
    }
    public partial class SkuInfos
    {
        internal SkuInfos() { }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.GlobalCsmSkuDescription> Skus { get { throw null; } }
    }
    public partial class SlotDifference : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SlotDifference() { }
        public string Description { get { throw null; } }
        public string DiffRule { get { throw null; } }
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
    public partial class Snapshot : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public Snapshot() { }
        public string Time { get { throw null; } }
    }
    public partial class SnapshotRecoverySource
    {
        public SnapshotRecoverySource() { }
        public string Id { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
    }
    public partial class SnapshotRestoreRequest : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public SnapshotRestoreRequest() { }
        public bool? IgnoreConflictingHostNames { get { throw null; } set { } }
        public bool? Overwrite { get { throw null; } set { } }
        public bool? RecoverConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SnapshotRecoverySource RecoverySource { get { throw null; } set { } }
        public string SnapshotTime { get { throw null; } set { } }
        public bool? UseDRSecondary { get { throw null; } set { } }
    }
    public partial class Solution
    {
        public Solution() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair>> Data { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public double? Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.NameValuePair>> Metadata { get { throw null; } }
        public double? Order { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.SolutionType? SolutionType { get { throw null; } set { } }
    }
    public enum SolutionType
    {
        QuickSolution = 0,
        DeepInvestigation = 1,
        BestPractices = 2,
    }
    public enum SslState
    {
        Disabled = 0,
        SniEnabled = 1,
        IPBasedEnabled = 2,
    }
    public partial class StackMajorVersion
    {
        public StackMajorVersion() { }
        public bool? ApplicationInsights { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AppSettingsDictionary { get { throw null; } }
        public string DisplayVersion { get { throw null; } set { } }
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
        public Azure.ResourceManager.AppService.Models.ComputeModeOptions? ComputeMode { get { throw null; } }
        public bool? ExcludeFromCapacityAllocation { get { throw null; } }
        public bool? IsApplicableForAllComputeModes { get { throw null; } }
        public bool? IsLinux { get { throw null; } }
        public string Name { get { throw null; } }
        public string SiteMode { get { throw null; } }
        public long? TotalCapacity { get { throw null; } }
        public string Unit { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.WorkerSizeOptions? WorkerSize { get { throw null; } }
        public int? WorkerSizeId { get { throw null; } }
    }
    public partial class StaticSiteARMResourcePatch : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteARMResourcePatch() { }
        public bool? AllowConfigFileUpdates { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public string ContentDistributionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CustomDomains { get { throw null; } }
        public string DefaultHostname { get { throw null; } }
        public string KeyVaultReferenceIdentity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.ResponseMessageEnvelopeRemotePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string Provider { get { throw null; } }
        public string RepositoryToken { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteTemplateOptions TemplateProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.StaticSiteUserProvidedFunctionApp> UserProvidedFunctionApps { get { throw null; } }
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
    public partial class StaticSiteCustomDomainRequestPropertiesARMResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteCustomDomainRequestPropertiesARMResource() { }
        public string ValidationMethod { get { throw null; } set { } }
    }
    public partial class StaticSiteFunctionOverviewARMResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteFunctionOverviewARMResource() { }
        public string FunctionName { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.TriggerTypes? TriggerType { get { throw null; } }
    }
    public partial class StaticSiteResetPropertiesARMResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteResetPropertiesARMResource() { }
        public string RepositoryToken { get { throw null; } set { } }
        public bool? ShouldUpdateRepository { get { throw null; } set { } }
    }
    public partial class StaticSitesWorkflowPreview : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSitesWorkflowPreview() { }
        public string Contents { get { throw null; } }
        public string Path { get { throw null; } }
    }
    public partial class StaticSitesWorkflowPreviewContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSitesWorkflowPreviewContent() { }
        public string Branch { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.StaticSiteBuildProperties BuildProperties { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
    }
    public partial class StaticSiteTemplateOptions
    {
        public StaticSiteTemplateOptions() { }
        public string Description { get { throw null; } set { } }
        public bool? IsPrivate { get { throw null; } set { } }
        public string Owner { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public System.Uri TemplateRepositoryUri { get { throw null; } set { } }
    }
    public partial class StaticSiteUserARMResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteUserARMResource() { }
        public string DisplayName { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Roles { get { throw null; } set { } }
        public string UserId { get { throw null; } }
    }
    public partial class StaticSiteUserInvitationRequestResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteUserInvitationRequestResource() { }
        public string Domain { get { throw null; } set { } }
        public int? NumHoursToExpiration { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string Roles { get { throw null; } set { } }
        public string UserDetails { get { throw null; } set { } }
    }
    public partial class StaticSiteUserInvitationResponseResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteUserInvitationResponseResource() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Uri InvitationUri { get { throw null; } }
    }
    public partial class StaticSiteUserProvidedFunctionApp : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteUserProvidedFunctionApp() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FunctionAppRegion { get { throw null; } set { } }
        public string FunctionAppResourceId { get { throw null; } set { } }
    }
    public partial class StaticSiteZipDeploymentARMResource : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StaticSiteZipDeploymentARMResource() { }
        public System.Uri ApiZipUri { get { throw null; } set { } }
        public System.Uri AppZipUri { get { throw null; } set { } }
        public string DeploymentTitle { get { throw null; } set { } }
        public string FunctionLanguage { get { throw null; } set { } }
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
    public enum StatusOptions
    {
        Ready = 0,
        Pending = 1,
        Creating = 2,
    }
    public partial class StorageMigrationContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StorageMigrationContent() { }
        public string AzurefilesConnectionString { get { throw null; } set { } }
        public string AzurefilesShare { get { throw null; } set { } }
        public bool? BlockWriteAccessToSite { get { throw null; } set { } }
        public bool? SwitchSiteAfterMigration { get { throw null; } set { } }
    }
    public partial class StorageMigrationResponse : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StorageMigrationResponse() { }
        public string OperationId { get { throw null; } }
    }
    public enum StorageType
    {
        LocalNode = 0,
        NetworkFileSystem = 1,
    }
    public partial class StringDictionary : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StringDictionary() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
    }
    public partial class StringList : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public StringList() { }
        public System.Collections.Generic.IList<string> Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedTlsVersions : System.IEquatable<Azure.ResourceManager.AppService.Models.SupportedTlsVersions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedTlsVersions(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.SupportedTlsVersions One0 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.SupportedTlsVersions One1 { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.SupportedTlsVersions One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.SupportedTlsVersions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.SupportedTlsVersions left, Azure.ResourceManager.AppService.Models.SupportedTlsVersions right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.SupportedTlsVersions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.SupportedTlsVersions left, Azure.ResourceManager.AppService.Models.SupportedTlsVersions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportTopic
    {
        internal SupportTopic() { }
        public string Id { get { throw null; } }
        public string PesId { get { throw null; } }
    }
    public partial class TldLegalAgreement
    {
        internal TldLegalAgreement() { }
        public string AgreementKey { get { throw null; } }
        public string Content { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class TokenStore
    {
        public TokenStore() { }
        public string AzureBlobStorageSasUrlSettingName { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string FileSystemDirectory { get { throw null; } set { } }
        public double? TokenRefreshExtensionHours { get { throw null; } set { } }
    }
    public partial class TopLevelDomainAgreementOption
    {
        public TopLevelDomainAgreementOption() { }
        public bool? ForTransfer { get { throw null; } set { } }
        public bool? IncludePrivacy { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerTypes : System.IEquatable<Azure.ResourceManager.AppService.Models.TriggerTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerTypes(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.TriggerTypes HttpTrigger { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.TriggerTypes Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.TriggerTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.TriggerTypes left, Azure.ResourceManager.AppService.Models.TriggerTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.TriggerTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.TriggerTypes left, Azure.ResourceManager.AppService.Models.TriggerTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Twitter
    {
        public Twitter() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.TwitterRegistration Registration { get { throw null; } set { } }
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
    public enum UsageState
    {
        Normal = 0,
        Exceeded = 1,
    }
    public partial class ValidateContent
    {
        public ValidateContent(string name, Azure.ResourceManager.AppService.Models.ValidateResourceTypes validateResourceType, string location) { }
        public Azure.ResourceManager.AppService.Models.AppServiceEnvironmentAutoGenerated AppServiceEnvironment { get { throw null; } set { } }
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
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NeedLinuxWorkers { get { throw null; } set { } }
        public string ServerFarmId { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.ValidateResourceTypes ValidateResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidateResourceTypes : System.IEquatable<Azure.ResourceManager.AppService.Models.ValidateResourceTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidateResourceTypes(string value) { throw null; }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceTypes MicrosoftWebHostingEnvironments { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceTypes ServerFarm { get { throw null; } }
        public static Azure.ResourceManager.AppService.Models.ValidateResourceTypes WebSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppService.Models.ValidateResourceTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppService.Models.ValidateResourceTypes left, Azure.ResourceManager.AppService.Models.ValidateResourceTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppService.Models.ValidateResourceTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppService.Models.ValidateResourceTypes left, Azure.ResourceManager.AppService.Models.ValidateResourceTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateResponse
    {
        internal ValidateResponse() { }
        public Azure.ResourceManager.AppService.Models.ValidateResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
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
        public string PhysicalPath { get { throw null; } set { } }
        public bool? PreloadEnabled { get { throw null; } set { } }
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
        public bool? InUse { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        public string VirtualIP { get { throw null; } set { } }
    }
    public partial class VirtualNetworkProfile
    {
        public VirtualNetworkProfile(string id) { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
    }
    public partial class VnetContent : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetContent() { }
        public string SubnetResourceId { get { throw null; } set { } }
        public string VnetName { get { throw null; } set { } }
        public string VnetResourceGroup { get { throw null; } set { } }
        public string VnetSubnetName { get { throw null; } set { } }
    }
    public partial class VnetInfo
    {
        internal VnetInfo() { }
        public string CertBlob { get { throw null; } }
        public string CertThumbprint { get { throw null; } }
        public string DnsServers { get { throw null; } }
        public bool? IsSwift { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.VnetRoute> Routes { get { throw null; } }
        public string VnetResourceId { get { throw null; } }
    }
    public partial class VnetRoute : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetRoute() { }
        public string EndAddress { get { throw null; } set { } }
        public Azure.ResourceManager.AppService.Models.RouteType? RouteType { get { throw null; } set { } }
        public string StartAddress { get { throw null; } set { } }
    }
    public partial class VnetValidationFailureDetails : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetValidationFailureDetails() { }
        public bool? Failed { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VnetValidationTestFailure> FailedTests { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppService.Models.VnetValidationTestFailure> Warnings { get { throw null; } }
    }
    public partial class VnetValidationTestFailure : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public VnetValidationTestFailure() { }
        public string Details { get { throw null; } set { } }
        public string TestName { get { throw null; } set { } }
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
        public bool? RemoteDebuggingSupported { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
    }
    public partial class WebAppStack : Azure.ResourceManager.AppService.Models.ProxyOnlyResource
    {
        public WebAppStack() { }
        public string DisplayText { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppService.Models.WebAppMajorVersion> MajorVersions { get { throw null; } }
        public Azure.ResourceManager.AppService.Models.StackPreferredOS? PreferredOS { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum WebJobType
    {
        Continuous = 0,
        Triggered = 1,
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
    public enum WorkerSizeOptions
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
