namespace Azure.ResourceManager.CertificateRegistration
{
    public partial class AppServiceCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>, System.Collections.IEnumerable
    {
        protected AppServiceCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceCertificateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>
    {
        public AppServiceCertificateData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceCertificateOrderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>, System.Collections.IEnumerable
    {
        protected AppServiceCertificateOrderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateOrderName, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateOrderName, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> Get(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> GetAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetIfExists(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> GetIfExistsAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceCertificateOrderData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>
    {
        public AppServiceCertificateOrderData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties> Certificates { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuedOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewOn { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceCertificateOrderResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateOrderResource() { }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> GetAppServiceCertificate(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> GetAppServiceCertificateAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateCollection GetAppServiceCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> GetAppServiceDetector(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>> GetAppServiceDetectorAsync(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceDetectorCollection GetAppServiceDetectors() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reissue(Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReissueAsync(Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Renew(Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendEmail(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendEmailAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResendRequestEmails(Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResendRequestEmailsAsync(Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier nameIdentifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction> RetrieveCertificateActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction> RetrieveCertificateActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail> RetrieveCertificateEmailHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail> RetrieveCertificateEmailHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal> RetrieveSiteSeal(Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>> RetrieveSiteSealAsync(Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> Update(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> UpdateAsync(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyDomainOwnership(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyDomainOwnershipAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceCertificateResource() { }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource> Update(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource>> UpdateAsync(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppServiceDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>, System.Collections.IEnumerable
    {
        protected AppServiceDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> Get(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>> GetAsync(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> GetIfExists(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>> GetIfExistsAsync(string detectorName, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceDetectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>
    {
        internal AppServiceDetectorData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata> DataProvidersMetadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset> Dataset { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo Metadata { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo Status { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults SuggestedUtterances { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceDetectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceDetectorResource() { }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string certificateOrderName, string detectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource> Get(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource>> GetAsync(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerCertificateRegistrationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCertificateRegistrationContext() { }
        public static Azure.ResourceManager.CertificateRegistration.AzureResourceManagerCertificateRegistrationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CertificateRegistrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrder(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> GetAppServiceCertificateOrderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderCollection GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource GetAppServiceCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource GetAppServiceDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response ValidatePurchaseInformation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidatePurchaseInformationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CertificateRegistration.Mocking
{
    public partial class MockableCertificateRegistrationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCertificateRegistrationArmClient() { }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource GetAppServiceCertificateOrderResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateResource GetAppServiceCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceDetectorResource GetAppServiceDetectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCertificateRegistrationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCertificateRegistrationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrder(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource>> GetAppServiceCertificateOrderAsync(string certificateOrderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderCollection GetAppServiceCertificateOrders() { throw null; }
    }
    public partial class MockableCertificateRegistrationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCertificateRegistrationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderResource> GetAppServiceCertificateOrdersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidatePurchaseInformation(Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidatePurchaseInformationAsync(Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CertificateRegistration.Models
{
    public partial class AppServiceCertificateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>
    {
        internal AppServiceCertificateDetails() { }
        public string Issuer { get { throw null; } }
        public System.DateTimeOffset? NotAfter { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public string RawData { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceCertificateEmail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>
    {
        internal AppServiceCertificateEmail() { }
        public string EmailId { get { throw null; } }
        public System.DateTimeOffset? SentOn { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServiceCertificateNotRenewableReason : System.IEquatable<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServiceCertificateNotRenewableReason(string value) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason left, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason left, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServiceCertificateOrderPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>
    {
        public AppServiceCertificateOrderPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties> Certificates { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact Contact { get { throw null; } }
        public string Csr { get { throw null; } set { } }
        public string DistinguishedName { get { throw null; } set { } }
        public string DomainVerificationToken { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public System.DateTimeOffset? LastCertificateIssuedOn { get { throw null; } }
        public System.DateTimeOffset? NextAutoRenewOn { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType ProductType { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails Root { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus? Status { get { throw null; } }
        public int? ValidityInYears { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceCertificatePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>
    {
        public AppServiceCertificatePatch() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>
    {
        public AppServiceCertificateProperties() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceDetectorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>
    {
        internal AppServiceDetectorInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AnalysisType { get { throw null; } }
        public string Author { get { throw null; } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public float? Score { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic> SupportTopicList { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AppServiceDetectorType
    {
        Detector = 0,
        Analysis = 1,
        CategoryOverview = 2,
    }
    public partial class AppServiceDomainNameIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>
    {
        public AppServiceDomainNameIdentifier() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.AppServiceDomainNameIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AppServiceVaultSecretStatus
    {
        Initialized = 0,
        WaitingOnCertificateOrder = 1,
        Succeeded = 2,
        CertificateOrderFailed = 3,
        OperationNotPermittedOnKeyVault = 4,
        AzureServiceUnauthorizedToAccessKeyVault = 5,
        KeyVaultDoesNotExist = 6,
        KeyVaultSecretDoesNotExist = 7,
        UnknownError = 8,
        ExternalPrivateKey = 9,
        Unknown = 10,
    }
    public static partial class ArmCertificateRegistrationModelFactory
    {
        public static Azure.ResourceManager.CertificateRegistration.AppServiceCertificateData AppServiceCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? provisioningState = default(Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus?), string kind = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails AppServiceCertificateDetails(int? version = default(int?), string serialNumber = null, string thumbprint = null, string subject = null, System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), System.DateTimeOffset? notAfter = default(System.DateTimeOffset?), string signatureAlgorithm = null, string issuer = null, string rawData = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateEmail AppServiceCertificateEmail(string emailId = null, System.DateTimeOffset? sentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceCertificateOrderData AppServiceCertificateOrderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties> certificates = null, string distinguishedName = null, string domainVerificationToken = null, int? validityInYears = default(int?), int? keySize = default(int?), Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType? productType = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType?), bool? isAutoRenew = default(bool?), Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState? provisioningState = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState?), Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus? status = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus?), Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails signedCertificate = null, string csr = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails intermediate = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails root = null, string serialNumber = null, System.DateTimeOffset? lastCertificateIssuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), bool? isPrivateKeyExternal = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = null, System.DateTimeOffset? nextAutoRenewOn = default(System.DateTimeOffset?), Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact contact = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateOrderPatch AppServiceCertificateOrderPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties> certificates = null, string distinguishedName = null, string domainVerificationToken = null, int? validityInYears = default(int?), int? keySize = default(int?), Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType? productType = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateProductType?), bool? isAutoRenew = default(bool?), Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState? provisioningState = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateRegistrationProvisioningState?), Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus? status = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderStatus?), Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails signedCertificate = null, string csr = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails intermediate = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateDetails root = null, string serialNumber = null, System.DateTimeOffset? lastCertificateIssuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), bool? isPrivateKeyExternal = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateNotRenewableReason> appServiceCertificateNotRenewableReasons = null, System.DateTimeOffset? nextAutoRenewOn = default(System.DateTimeOffset?), Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact contact = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificatePatch AppServiceCertificatePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? provisioningState = default(Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceCertificateProperties AppServiceCertificateProperties(Azure.Core.ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus? provisioningState = default(Azure.ResourceManager.CertificateRegistration.Models.AppServiceVaultSecretStatus?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.AppServiceDetectorData AppServiceDetectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset> dataset = null, Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata> dataProvidersMetadata = null, Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults suggestedUtterances = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorInfo AppServiceDetectorInfo(string id = null, string name = null, string description = null, string author = null, string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic> supportTopicList = null, System.Collections.Generic.IEnumerable<string> analysisType = null, Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorType? type = default(Azure.ResourceManager.CertificateRegistration.Models.AppServiceDetectorType?), float? score = default(float?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction CertificateOrderAction(Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderActionType? actionType = default(Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderActionType?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact CertificateOrderContact(string email = null, string nameFirst = null, string nameLast = null, string phone = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair DataProviderKeyValuePair(string key = null, System.Collections.Generic.IReadOnlyDictionary<string, string> value = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata DataProviderMetadata(string providerName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair> propertyBag = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo DetectorStatusInfo(string message = null, Azure.ResourceManager.CertificateRegistration.Models.DetectorInsightStatus? statusId = default(Azure.ResourceManager.CertificateRegistration.Models.DetectorInsightStatus?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic DetectorSupportTopic(string id = null, Azure.Core.ResourceIdentifier pesId = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering DiagnosticDataRendering(Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRenderingType? type = default(Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRenderingType?), string title = null, string description = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset DiagnosticDataset(Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject table = null, Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering renderingProperties = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn DiagnosticDataTableColumn(string columnName = null, string dataType = null, string columnType = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject DiagnosticDataTableObject(string tableName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn> columns = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> rows = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult QueryUtterancesResult(Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance sampleUtterance = null, float? score = default(float?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults QueryUtterancesResults(string query = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult> results = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent ReissueCertificateOrderContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? keySize = default(int?), int? delayExistingRevokeInHours = default(int?), string csr = null, bool? isPrivateKeyExternal = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent RenewCertificateOrderContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? keySize = default(int?), string csr = null, bool? isPrivateKeyExternal = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance SampleUtterance(string text = null, System.Collections.Generic.IEnumerable<string> links = null, string qid = null) { throw null; }
        public static Azure.ResourceManager.CertificateRegistration.Models.SiteSeal SiteSeal(string html = null) { throw null; }
    }
    public partial class CertificateOrderAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>
    {
        internal CertificateOrderAction() { }
        public Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderActionType? ActionType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CertificateOrderActionType
    {
        CertificateIssued = 0,
        CertificateOrderCanceled = 1,
        CertificateOrderCreated = 2,
        CertificateRevoked = 3,
        DomainValidationComplete = 4,
        FraudDetected = 5,
        OrgNameChange = 6,
        OrgValidationComplete = 7,
        SanDrop = 8,
        FraudCleared = 9,
        CertificateExpired = 10,
        CertificateExpirationWarning = 11,
        FraudDocumentationRequired = 12,
        Unknown = 13,
    }
    public partial class CertificateOrderContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>
    {
        internal CertificateOrderContact() { }
        public string Email { get { throw null; } }
        public string NameFirst { get { throw null; } }
        public string NameLast { get { throw null; } }
        public string Phone { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.CertificateOrderContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CertificateOrderStatus
    {
        PendingIssuance = 0,
        Issued = 1,
        Revoked = 2,
        Canceled = 3,
        Denied = 4,
        PendingRevocation = 5,
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
    public enum CertificateRegistrationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public partial class DataProviderKeyValuePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>
    {
        internal DataProviderKeyValuePair() { }
        public string Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProviderMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>
    {
        internal DataProviderMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CertificateRegistration.Models.DataProviderKeyValuePair> PropertyBag { get { throw null; } }
        public string ProviderName { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DataProviderMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DetectorInsightStatus
    {
        Critical = 0,
        Warning = 1,
        Info = 2,
        Success = 3,
        None = 4,
    }
    public partial class DetectorStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>
    {
        internal DetectorStatusInfo() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.DetectorInsightStatus? StatusId { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectorSupportTopic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>
    {
        internal DetectorSupportTopic() { }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier PesId { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DetectorSupportTopic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticDataRendering : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>
    {
        internal DiagnosticDataRendering() { }
        public string Description { get { throw null; } }
        public string Title { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRenderingType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DiagnosticDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>
    {
        internal DiagnosticDataset() { }
        public Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataRendering RenderingProperties { get { throw null; } }
        public Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject Table { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticDataTableColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>
    {
        internal DiagnosticDataTableColumn() { }
        public string ColumnName { get { throw null; } }
        public string ColumnType { get { throw null; } }
        public string DataType { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticDataTableObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>
    {
        internal DiagnosticDataTableObject() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableColumn> Columns { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> Rows { get { throw null; } }
        public string TableName { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.DiagnosticDataTableObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryUtterancesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>
    {
        internal QueryUtterancesResult() { }
        public Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance SampleUtterance { get { throw null; } }
        public float? Score { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryUtterancesResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>
    {
        internal QueryUtterancesResults() { }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResult> Results { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.QueryUtterancesResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReissueCertificateOrderContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>
    {
        public ReissueCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public int? DelayExistingRevokeInHours { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.ReissueCertificateOrderContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenewCertificateOrderContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>
    {
        public RenewCertificateOrderContent() { }
        public string Csr { get { throw null; } set { } }
        public bool? IsPrivateKeyExternal { get { throw null; } set { } }
        public int? KeySize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.RenewCertificateOrderContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SampleUtterance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>
    {
        internal SampleUtterance() { }
        public System.Collections.Generic.IList<string> Links { get { throw null; } }
        public string Qid { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SampleUtterance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteSeal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>
    {
        internal SiteSeal() { }
        public string Html { get { throw null; } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SiteSeal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SiteSeal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.SiteSeal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.SiteSeal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSeal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteSealContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>
    {
        public SiteSealContent() { }
        public bool? IsLightTheme { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CertificateRegistration.Models.SiteSealContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
