namespace Azure.ResourceManager.DomainRegistration
{
    public partial class AppServiceDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>, System.Collections.IEnumerable
    {
        protected AppServiceDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.DomainRegistration.AppServiceDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.DomainRegistration.AppServiceDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetIfExists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> GetIfExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppServiceDomainData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>
    {
        public AppServiceDomainData(Azure.Core.AzureLocation location) { }
        public string AuthCode { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent Consent { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactAdmin { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactBilling { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactRegistrant { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactTech { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsDnsRecordManagementReady { get { throw null; } }
        public bool? IsDomainPrivacyEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus? RegistrationStatus { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? TargetDnsType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.AppServiceDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.AppServiceDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppServiceDomainResource() { }
        public virtual Azure.ResourceManager.DomainRegistration.AppServiceDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceHardDeleteDomain = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> GetDomainOwnershipIdentifier(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> GetDomainOwnershipIdentifierAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierCollection GetDomainOwnershipIdentifiers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Renew(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DomainRegistration.AppServiceDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.AppServiceDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.AppServiceDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> TransferOut(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> TransferOutAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> Update(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> UpdateAsync(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerDomainRegistrationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDomainRegistrationContext() { }
        public static Azure.ResourceManager.DomainRegistration.AzureResourceManagerDomainRegistrationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DomainOwnershipIdentifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>, System.Collections.IEnumerable
    {
        protected DomainOwnershipIdentifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainOwnershipIdentifierData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>
    {
        public DomainOwnershipIdentifierData() { }
        public string Kind { get { throw null; } set { } }
        public string OwnershipId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainOwnershipIdentifierResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainOwnershipIdentifierResource() { }
        public virtual Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource> Update(Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource>> UpdateAsync(Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DomainRegistrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> GetAppServiceDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.AppServiceDomainResource GetAppServiceDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.AppServiceDomainCollection GetAppServiceDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequest(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier> GetRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier> GetRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> GetTopLevelDomain(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>> GetTopLevelDomainAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.TopLevelDomainResource GetTopLevelDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.TopLevelDomainCollection GetTopLevelDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class TopLevelDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>, System.Collections.IEnumerable
    {
        protected TopLevelDomainCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopLevelDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>
    {
        internal TopLevelDomainData() { }
        public bool? IsDomainPrivacySupported { get { throw null; } }
        public string Kind { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.TopLevelDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.TopLevelDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopLevelDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopLevelDomainResource() { }
        public virtual Azure.ResourceManager.DomainRegistration.TopLevelDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement> GetAgreements(Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement> GetAgreementsAsync(Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DomainRegistration.TopLevelDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.TopLevelDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.TopLevelDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DomainRegistration.Mocking
{
    public partial class MockableDomainRegistrationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainRegistrationArmClient() { }
        public virtual Azure.ResourceManager.DomainRegistration.AppServiceDomainResource GetAppServiceDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierResource GetDomainOwnershipIdentifierResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DomainRegistration.TopLevelDomainResource GetTopLevelDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDomainRegistrationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainRegistrationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomain(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource>> GetAppServiceDomainAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DomainRegistration.AppServiceDomainCollection GetAppServiceDomains() { throw null; }
    }
    public partial class MockableDomainRegistrationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainRegistrationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult> CheckAppServiceDomainRegistrationAvailability(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>> CheckAppServiceDomainRegistrationAvailabilityAsync(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomains(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.AppServiceDomainResource> GetAppServiceDomainsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo> GetControlCenterSsoRequest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>> GetControlCenterSsoRequestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier> GetRecommendations(Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier> GetRecommendationsAsync(Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource> GetTopLevelDomain(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainRegistration.TopLevelDomainResource>> GetTopLevelDomainAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DomainRegistration.TopLevelDomainCollection GetTopLevelDomains() { throw null; }
    }
}
namespace Azure.ResourceManager.DomainRegistration.Models
{
    public enum AppServiceDnsType
    {
        AzureDns = 0,
        DefaultDomainRegistrarDns = 1,
    }
    public partial class AppServiceDomainNameIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>
    {
        public AppServiceDomainNameIdentifier() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainNameIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppServiceDomainPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>
    {
        public AppServiceDomainPatch() { }
        public string AuthCode { get { throw null; } set { } }
        public Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent Consent { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactAdmin { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactBilling { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactRegistrant { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo ContactTech { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? DnsType { get { throw null; } set { } }
        public string DnsZoneId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason> DomainNotRenewableReasons { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsDnsRecordManagementReady { get { throw null; } }
        public bool? IsDomainPrivacyEnabled { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRenewedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName> ManagedHostNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus? RegistrationStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? TargetDnsType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AppServiceDomainProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public enum AppServiceDomainStatus
    {
        Active = 0,
        Awaiting = 1,
        Cancelled = 2,
        Confiscated = 3,
        Disabled = 4,
        Excluded = 5,
        Expired = 6,
        Failed = 7,
        Held = 8,
        Locked = 9,
        Parked = 10,
        Pending = 11,
        Reserved = 12,
        Reverted = 13,
        Suspended = 14,
        Transferred = 15,
        Unknown = 16,
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
    public partial class AppServiceHostName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>
    {
        internal AppServiceHostName() { }
        public string AzureResourceName { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceResourceType? AzureResourceType { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get { throw null; } }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceHostNameType? HostNameType { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> SiteNames { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AppServiceHostNameType
    {
        Verified = 0,
        Managed = 1,
    }
    public enum AppServiceResourceType
    {
        Website = 0,
        TrafficManager = 1,
    }
    public static partial class ArmDomainRegistrationModelFactory
    {
        public static Azure.ResourceManager.DomainRegistration.AppServiceDomainData AppServiceDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactAdmin = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactBilling = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactRegistrant = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactTech = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus? registrationStatus = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus?), Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState? provisioningState = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState?), System.Collections.Generic.IEnumerable<string> nameServers = null, bool? isDomainPrivacyEnabled = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRenewedOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isDnsRecordManagementReady = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName> managedHostNames = null, Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent consent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason> domainNotRenewableReasons = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? dnsType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType?), string dnsZoneId = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? targetDnsType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType?), string authCode = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainPatch AppServiceDomainPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactAdmin = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactBilling = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactRegistrant = null, Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo contactTech = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus? registrationStatus = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainStatus?), Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState? provisioningState = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainProvisioningState?), System.Collections.Generic.IEnumerable<string> nameServers = null, bool? isDomainPrivacyEnabled = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRenewedOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isDnsRecordManagementReady = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName> managedHostNames = null, Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent consent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason> domainNotRenewableReasons = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? dnsType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType?), string dnsZoneId = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType? targetDnsType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDnsType?), string authCode = null, string kind = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.AppServiceHostName AppServiceHostName(string name = null, System.Collections.Generic.IEnumerable<string> siteNames = null, string azureResourceName = null, Azure.ResourceManager.DomainRegistration.Models.AppServiceResourceType? azureResourceType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceResourceType?), Azure.ResourceManager.DomainRegistration.Models.CustomHostNameDnsRecordType? customHostNameDnsRecordType = default(Azure.ResourceManager.DomainRegistration.Models.CustomHostNameDnsRecordType?), Azure.ResourceManager.DomainRegistration.Models.AppServiceHostNameType? hostNameType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceHostNameType?)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult DomainAvailabilityCheckResult(string name = null, bool? isAvailable = default(bool?), Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainType? domainType = default(Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainType?)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo DomainControlCenterSsoRequestInfo(string uri = null, string postParameterKey = null, string postParameterValue = null) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.DomainOwnershipIdentifierData DomainOwnershipIdentifierData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ownershipId = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent DomainPurchaseConsent(System.Collections.Generic.IEnumerable<string> agreementKeys = null, string agreedBy = null, System.DateTimeOffset? agreedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.TopLevelDomainData TopLevelDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isDomainPrivacySupported = default(bool?), string kind = null) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement TopLevelDomainLegalAgreement(string agreementKey = null, string title = null, string content = null, System.Uri uri = null) { throw null; }
    }
    public enum CustomHostNameDnsRecordType
    {
        CName = 0,
        A = 1,
    }
    public partial class DomainAvailabilityCheckResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>
    {
        internal DomainAvailabilityCheckResult() { }
        public Azure.ResourceManager.DomainRegistration.Models.AppServiceDomainType? DomainType { get { throw null; } }
        public bool? IsAvailable { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainAvailabilityCheckResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainControlCenterSsoRequestInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>
    {
        internal DomainControlCenterSsoRequestInfo() { }
        public string PostParameterKey { get { throw null; } }
        public string PostParameterValue { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainControlCenterSsoRequestInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNotRenewableReason : System.IEquatable<Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNotRenewableReason(string value) { throw null; }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason ExpirationNotInRenewalTimeRange { get { throw null; } }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason RegistrationStatusNotSupportedForRenewal { get { throw null; } }
        public static Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason SubscriptionNotActive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason left, Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason left, Azure.ResourceManager.DomainRegistration.Models.DomainNotRenewableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainPurchaseConsent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>
    {
        public DomainPurchaseConsent() { }
        public string AgreedBy { get { throw null; } set { } }
        public System.DateTimeOffset? AgreedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AgreementKeys { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainPurchaseConsent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainRecommendationSearchContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>
    {
        public DomainRecommendationSearchContent() { }
        public string Keywords { get { throw null; } set { } }
        public int? MaxDomainRecommendations { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.DomainRecommendationSearchContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistrationAddressInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>
    {
        public RegistrationAddressInfo(string address1, string city, string country, string postalCode, string state) { }
        public string Address1 { get { throw null; } set { } }
        public string Address2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistrationContactInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>
    {
        public RegistrationContactInfo(string email, string nameFirst, string nameLast, string phone) { }
        public Azure.ResourceManager.DomainRegistration.Models.RegistrationAddressInfo AddressMailing { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Fax { get { throw null; } set { } }
        public string JobTitle { get { throw null; } set { } }
        public string NameFirst { get { throw null; } set { } }
        public string NameLast { get { throw null; } set { } }
        public string NameMiddle { get { throw null; } set { } }
        public string Organization { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.RegistrationContactInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopLevelDomainAgreementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>
    {
        public TopLevelDomainAgreementContent() { }
        public bool? IsForTransfer { get { throw null; } set { } }
        public bool? IsPrivacyIncluded { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainAgreementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopLevelDomainLegalAgreement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>
    {
        internal TopLevelDomainLegalAgreement() { }
        public string AgreementKey { get { throw null; } }
        public string Content { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainRegistration.Models.TopLevelDomainLegalAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
