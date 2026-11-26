namespace Azure.ResourceManager.Saas
{
    public partial class AzureResourceManagerSaasContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSaasContext() { }
        public static Azure.ResourceManager.Saas.AzureResourceManagerSaasContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SaasCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasResource>, System.Collections.IEnumerable
    {
        protected SaasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Saas.SaasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Saas.SaasData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> Get(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Saas.SaasResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Saas.SaasResource> GetIfExists(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Saas.SaasResource>> GetIfExistsAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Saas.SaasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Saas.SaasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SaasData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>
    {
        public SaasData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Saas.Models.SaasResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.SaasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SaasExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult> CheckSaasNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>> CheckSaasNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasCollection GetAllSaas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.SaasResource> GetSaas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Saas.SaasResource> GetSaas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetSaasAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasResource> GetSaasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasResource GetSaasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> GetSaasTenant(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetSaasTenantAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantResource GetSaasTenantResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantCollection GetSaasTenants(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetSubscriptionOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetSubscriptionOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetTenantOperationStatus(this Azure.ResourceManager.Resources.TenantResource tenantResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetTenantOperationStatusAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult> ValidatePurchase(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>> ValidatePurchaseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult> ValidatePurchaseBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>> ValidatePurchaseBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SaasResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SaasResource() { }
        public virtual Azure.ResourceManager.Saas.SaasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> Get(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult> GetAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>> GetAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetAsync(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Saas.SaasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> Unsubscribe(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> UnsubscribeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult> ValidateUpdate(Azure.ResourceManager.Saas.Models.SaasPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>> ValidateUpdateAsync(Azure.ResourceManager.Saas.Models.SaasPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SaasTenantCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>, System.Collections.IEnumerable
    {
        protected SaasTenantCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> Get(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Saas.SaasTenantResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasTenantResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetAsync(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Saas.SaasTenantResource> GetIfExists(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Saas.SaasTenantResource>> GetIfExistsAsync(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Saas.SaasTenantResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Saas.SaasTenantResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SaasTenantData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>
    {
        internal SaasTenantData() { }
        public Azure.ResourceManager.Saas.Models.SaasResourceProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.SaasTenantData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasTenantData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasTenantResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SaasTenantResource() { }
        public virtual Azure.ResourceManager.Saas.SaasTenantData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> Get(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult> GetAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>> GetAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetAsync(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Saas.SaasTenantData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasTenantData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasTenantResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasTenantPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasTenantResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasTenantPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Saas.Mocking
{
    public partial class MockableSaasArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasArmClient() { }
        public virtual Azure.ResourceManager.Saas.SaasResource GetSaasResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Saas.SaasTenantResource GetSaasTenantResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSaasResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasResourceGroupResource() { }
        public virtual Azure.ResourceManager.Saas.SaasCollection GetAllSaas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> GetSaas(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetSaasAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult> ValidatePurchase(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>> ValidatePurchaseAsync(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSaasSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult> CheckSaasNameAvailability(Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>> CheckSaasNameAvailabilityAsync(Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Saas.SaasResource> GetSaas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasResource> GetSaasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetSubscriptionOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetSubscriptionOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult> ValidatePurchaseBySubscription(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>> ValidatePurchaseBySubscriptionAsync(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSaasTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> GetSaasTenant(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetSaasTenantAsync(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Saas.SaasTenantCollection GetSaasTenants() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetTenantOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetTenantOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Saas.Models
{
    public static partial class ArmSaasModelFactory
    {
        public static Azure.ResourceManager.Saas.Models.SaasAccessTokenResult SaasAccessTokenResult(System.Uri publisherOfferBaseUri = null, string token = null, System.Uri offerUriWithToken = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasData SaasData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Saas.Models.SaasResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent SaasNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult SaasNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason? reason = default(Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPatch SaasPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent SaasPurchaseValidationContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties SaasPurchaseValidationProperties(Azure.ResourceManager.Saas.Models.SaasProvisioningState? provisioningState = default(Azure.ResourceManager.Saas.Models.SaasProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.Saas.Models.SaasResourceStatus? status = default(Azure.ResourceManager.Saas.Models.SaasResourceStatus?), Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason? statusReason = default(Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.SaasPatchIntent? intent = default(Azure.ResourceManager.Saas.Models.SaasPatchIntent?), string name = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceProperties SaasResourceProperties(Azure.ResourceManager.Saas.Models.SaasProvisioningState? provisioningState = default(Azure.ResourceManager.Saas.Models.SaasProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.Saas.Models.SaasResourceStatus? status = default(Azure.ResourceManager.Saas.Models.SaasResourceStatus?), Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason? statusReason = default(Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.SaasPatchIntent? intent = default(Azure.ResourceManager.Saas.Models.SaasPatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties SaasResourceUpdateProperties(string description = null, long? quantity = default(long?), string riskPropertyBagHeader = null, bool? isAutoRenew = default(bool?), string storefront = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.SaasPatchIntent? intent = default(Azure.ResourceManager.Saas.Models.SaasPatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceValidationError SaasResourceValidationError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceValidationResult SaasResourceValidationResult(bool isValid = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.Models.SaasResourceValidationError> details = null) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantData SaasTenantData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Saas.Models.SaasResourceProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasTenantPatch SaasTenantPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties SaasTenantResourceUpdateProperties(string description = null, long? quantity = default(long?), string riskPropertyBagHeader = null, bool? isAutoRenew = default(bool?), string storefront = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.SaasPatchIntent? intent = default(Azure.ResourceManager.Saas.Models.SaasPatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig SaasUnsubscribeConfig(bool? isUnsubscribeOnly = default(bool?), int? reasonCode = default(int?), string feedback = null, Azure.ResourceManager.Saas.Models.SaasDeletionSource? deletionSource = default(Azure.ResourceManager.Saas.Models.SaasDeletionSource?)) { throw null; }
    }
    public partial class SaasAccessTokenResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>
    {
        internal SaasAccessTokenResult() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.Uri OfferUriWithToken { get { throw null; } }
        public System.Uri PublisherOfferBaseUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasAccessTokenResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasAccessTokenResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasAccessTokenResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasAccessTokenResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasAccessTokenResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasDeletionSource : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasDeletionSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasDeletionSource(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasDeletionSource AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasDeletionSource CustomerCancellation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasDeletionSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasDeletionSource left, Azure.ResourceManager.Saas.Models.SaasDeletionSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasDeletionSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasDeletionSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasDeletionSource left, Azure.ResourceManager.Saas.Models.SaasDeletionSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>
    {
        public SaasNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>
    {
        internal SaasNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason left, Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason left, Azure.ResourceManager.Saas.Models.SaasNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPatch>
    {
        public SaasPatch() { }
        public Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasPatchIntent : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasPatchIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasPatchIntent(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPatchIntent Reset { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasPatchIntent Retain { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasPatchIntent ScheduleChange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasPatchIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasPatchIntent left, Azure.ResourceManager.Saas.Models.SaasPatchIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasPatchIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasPatchIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasPatchIntent left, Azure.ResourceManager.Saas.Models.SaasPatchIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasProvisioningState : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasProvisioningState left, Azure.ResourceManager.Saas.Models.SaasProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasProvisioningState left, Azure.ResourceManager.Saas.Models.SaasProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasPurchaseValidationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>
    {
        public SaasPurchaseValidationContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasPurchaseValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>
    {
        public SaasPurchaseValidationProperties(string name) { }
        public string AssetId { get { throw null; } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasPatchIntent? Intent { get { throw null; } set { } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsFreeTrial { get { throw null; } }
        public string Name { get { throw null; } }
        public string OfferName { get { throw null; } }
        public string PlanName { get { throw null; } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PurchaserEmail { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasResourceStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason? StatusReason { get { throw null; } }
        public string Storefront { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndsOn { get { throw null; } }
        public System.DateTimeOffset? TermStartsOn { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>
    {
        public SaasResourceProperties() { }
        public string AssetId { get { throw null; } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasPatchIntent? Intent { get { throw null; } set { } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public bool? IsFreeTrial { get { throw null; } }
        public string OfferName { get { throw null; } }
        public string PlanName { get { throw null; } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PurchaserEmail { get { throw null; } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasResourceStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason? StatusReason { get { throw null; } }
        public string Storefront { get { throw null; } set { } }
        public System.DateTimeOffset? TermEndsOn { get { throw null; } }
        public System.DateTimeOffset? TermStartsOn { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasResourceStatus : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasResourceStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasResourceStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasResourceStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasResourceStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasResourceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasResourceStatus left, Azure.ResourceManager.Saas.Models.SaasResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasResourceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasResourceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasResourceStatus left, Azure.ResourceManager.Saas.Models.SaasResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>
    {
        public SaasResourceUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasPatchIntent? Intent { get { throw null; } set { } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public string Storefront { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasResourceValidationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>
    {
        internal SaasResourceValidationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceValidationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceValidationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasResourceValidationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasResourceValidationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasResourceValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>
    {
        internal SaasResourceValidationResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Saas.Models.SaasResourceValidationError> Details { get { throw null; } }
        public bool IsValid { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceValidationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourceValidationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasResourceValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasResourceValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaasSubscriptionStatusReason : System.IEquatable<Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaasSubscriptionStatusReason(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason None { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason SuspendedInternal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason left, Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason left, Azure.ResourceManager.Saas.Models.SaasSubscriptionStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasTenantPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>
    {
        public SaasTenantPatch() { }
        public Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasTenantPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasTenantPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasTenantResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>
    {
        public SaasTenantResourceUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.SaasPatchIntent? Intent { get { throw null; } set { } }
        public bool? IsAutoRenew { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public long? Quantity { get { throw null; } set { } }
        public string QuoteId { get { throw null; } set { } }
        public string RiskPropertyBagHeader { get { throw null; } set { } }
        public string Storefront { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasUnsubscribeConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>
    {
        public SaasUnsubscribeConfig() { }
        public Azure.ResourceManager.Saas.Models.SaasDeletionSource? DeletionSource { get { throw null; } set { } }
        public string Feedback { get { throw null; } set { } }
        public bool? IsUnsubscribeOnly { get { throw null; } set { } }
        public int? ReasonCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasUnsubscribeConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
