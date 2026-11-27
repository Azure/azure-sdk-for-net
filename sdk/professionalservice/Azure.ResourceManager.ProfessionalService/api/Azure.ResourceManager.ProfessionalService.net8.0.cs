namespace Azure.ResourceManager.ProfessionalService
{
    public partial class AzureResourceManagerProfessionalServiceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerProfessionalServiceContext() { }
        public static Azure.ResourceManager.ProfessionalService.AzureResourceManagerProfessionalServiceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ProfessionalServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>, System.Collections.IEnumerable
    {
        protected ProfessionalServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ProfessionalService.ProfessionalServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ProfessionalService.ProfessionalServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> Get(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> GetAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetIfExists(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> GetIfExistsAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfessionalServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>
    {
        public ProfessionalServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.ProfessionalServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.ProfessionalServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ProfessionalServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult> CheckProfessionalServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>> CheckProfessionalServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> GetProfessionalServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource GetProfessionalServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.ProfessionalServiceCollection GetProfessionalServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult> ValidatePurchase(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>> ValidatePurchaseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult> ValidatePurchaseBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>> ValidatePurchaseBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfessionalServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfessionalServiceResource() { }
        public virtual Azure.ResourceManager.ProfessionalService.ProfessionalServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> Get(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> GetAsync(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProfessionalService.ProfessionalServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.ProfessionalServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.ProfessionalServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> Unsubscribe(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> UnsubscribeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult> ValidateUpdate(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>> ValidateUpdateAsync(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProfessionalService.Mocking
{
    public partial class MockableProfessionalServiceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableProfessionalServiceArmClient() { }
        public virtual Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource GetProfessionalServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProfessionalServiceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProfessionalServiceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalService(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource>> GetProfessionalServiceAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProfessionalService.ProfessionalServiceCollection GetProfessionalServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult> ValidatePurchase(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>> ValidatePurchaseAsync(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableProfessionalServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProfessionalServiceSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult> CheckProfessionalServiceNameAvailability(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>> CheckProfessionalServiceNameAvailabilityAsync(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProfessionalService.ProfessionalServiceResource> GetProfessionalServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult> ValidatePurchaseBySubscription(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>> ValidatePurchaseBySubscriptionAsync(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProfessionalService.Models
{
    public static partial class ArmProfessionalServiceModelFactory
    {
        public static Azure.ResourceManager.ProfessionalService.ProfessionalServiceData ProfessionalServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent ProfessionalServiceNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult ProfessionalServiceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason? reason = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch ProfessionalServicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent ProfessionalServicePurchaseValidationContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties ProfessionalServicePurchaseValidationProperties(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState? provisioningState = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus? status = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus?), Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason? statusReason = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties ProfessionalServiceResourceProperties(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState? provisioningState = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus? status = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus?), Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason? statusReason = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties ProfessionalServiceResourceUpdateProperties(string description = null, long? quantity = default(long?), string riskPropertyBagHeader = null, bool? isAutoRenew = default(bool?), string storefront = null, string quoteId = null, string privateOfferId = null, string productCode = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent ProfessionalServiceUnsubscribeContent(bool? isUnsubscribeOnly = default(bool?), int? reasonCode = default(int?), string feedback = null, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource? deletionSource = default(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource?)) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError ProfessionalServiceValidationError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult ProfessionalServiceValidationResult(bool isValid = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError> details = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfessionalServiceDeletionSource : System.IEquatable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfessionalServiceDeletionSource(string value) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource CustomerCancellation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfessionalServiceNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>
    {
        public ProfessionalServiceNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServiceNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>
    {
        internal ProfessionalServiceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfessionalServiceNameUnavailableReason : System.IEquatable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfessionalServiceNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfessionalServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>
    {
        public ProfessionalServicePatch() { }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfessionalServiceProvisioningState : System.IEquatable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfessionalServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfessionalServicePurchaseValidationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>
    {
        public ProfessionalServicePurchaseValidationContent(Azure.Core.AzureLocation location, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServicePurchaseValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>
    {
        public ProfessionalServicePurchaseValidationProperties(string productCode, string name) { }
        public string AssetId { get { throw null; } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsFreeTrial { get { throw null; } }
        public string Name { get { throw null; } }
        public string OfferName { get { throw null; } }
        public string PlanName { get { throw null; } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PurchaserEmail { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason? StatusReason { get { throw null; } }
        public string Storefront { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndsOn { get { throw null; } }
        public System.DateTimeOffset? TermStartsOn { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServicePurchaseValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServiceResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>
    {
        public ProfessionalServiceResourceProperties(string productCode) { }
        public string AssetId { get { throw null; } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsFreeTrial { get { throw null; } }
        public string OfferName { get { throw null; } }
        public string PlanName { get { throw null; } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PurchaserEmail { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus? Status { get { throw null; } }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason? StatusReason { get { throw null; } }
        public string Storefront { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndsOn { get { throw null; } }
        public System.DateTimeOffset? TermStartsOn { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServiceResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>
    {
        public ProfessionalServiceResourceUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public string Storefront { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfessionalServiceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfessionalServiceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfessionalServiceSubscriptionStatusReason : System.IEquatable<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfessionalServiceSubscriptionStatusReason(string value) { throw null; }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason None { get { throw null; } }
        public static Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason SuspendedInternal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason left, Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceSubscriptionStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfessionalServiceUnsubscribeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>
    {
        public ProfessionalServiceUnsubscribeContent() { }
        public Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceDeletionSource? DeletionSource { get { throw null; } set { } }
        public string Feedback { get { throw null; } set { } }
        public bool? IsUnsubscribeOnly { get { throw null; } set { } }
        public int? ReasonCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceUnsubscribeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServiceValidationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>
    {
        internal ProfessionalServiceValidationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfessionalServiceValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>
    {
        internal ProfessionalServiceValidationResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationError> Details { get { throw null; } }
        public bool IsValid { get { throw null; } }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProfessionalService.Models.ProfessionalServiceValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
