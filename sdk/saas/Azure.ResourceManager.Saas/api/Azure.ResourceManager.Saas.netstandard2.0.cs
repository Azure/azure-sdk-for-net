namespace Azure.ResourceManager.Saas
{
    public partial class AzureResourceManagerSaasContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSaasContext() { }
        public static Azure.ResourceManager.Saas.AzureResourceManagerSaasContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class SaasExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasResource GetSaasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.SaasResource> GetSaasResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetSaasResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasResourceCollection GetSaasResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Saas.SaasResource> GetSaasResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasResource> GetSaasResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantResource GetSaasTenantResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> GetSaasTenantResource(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetSaasTenantResourceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantResourceCollection GetSaasTenantResources(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetSubscriptionOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetSubscriptionOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetTenantOperationStatus(this Azure.ResourceManager.Resources.TenantResource tenantResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetTenantOperationStatusAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult> ValidatePurchase(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult>> ValidatePurchaseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult> ValidatePurchaseBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult>> ValidatePurchaseBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SaasResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SaasResource() { }
        public virtual Azure.ResourceManager.Saas.SaasResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> Get(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.AccessTokenResult> GetAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.AccessTokenResult>> GetAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetAsync(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Saas.SaasResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> Unsubscribe(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.UnsubscribeConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> UnsubscribeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.UnsubscribeConfig body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult> ValidateUpdate(Azure.ResourceManager.Saas.Models.SaasResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult>> ValidateUpdateAsync(Azure.ResourceManager.Saas.Models.SaasResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SaasResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasResource>, System.Collections.IEnumerable
    {
        protected SaasResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Saas.SaasResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Saas.SaasResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SaasResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>
    {
        public SaasResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Saas.Models.SaasResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.SaasResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasTenantResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SaasTenantResource() { }
        public virtual Azure.ResourceManager.Saas.SaasTenantResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> Get(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.AccessTokenResult> GetAccessToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.AccessTokenResult>> GetAccessTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetAsync(bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Saas.SaasTenantResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasTenantResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasTenantResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Saas.SaasTenantResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SaasTenantResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.SaasTenantResource>, System.Collections.IEnumerable
    {
        protected SaasTenantResourceCollection() { }
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
    public partial class SaasTenantResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>
    {
        internal SaasTenantResourceData() { }
        public Azure.ResourceManager.Saas.Models.SaasResourceProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.SaasTenantResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.SaasTenantResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.SaasTenantResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasResource> GetSaasResource(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasResource>> GetSaasResourceAsync(string resourceName, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Saas.SaasResourceCollection GetSaasResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult> ValidatePurchase(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult>> ValidatePurchaseAsync(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSaasSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Saas.SaasResource> GetSaasResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Saas.SaasResource> GetSaasResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetSubscriptionOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetSubscriptionOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult> ValidatePurchaseBySubscription(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.Models.ResourceValidationResult>> ValidatePurchaseBySubscriptionAsync(Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSaasTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSaasTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource> GetSaasTenantResource(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Saas.SaasTenantResource>> GetSaasTenantResourceAsync(string resourceId, bool? expandCustomerData = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Saas.SaasTenantResourceCollection GetSaasTenantResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetTenantOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetTenantOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Saas.Models
{
    public partial class AccessTokenResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>
    {
        internal AccessTokenResult() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public string OfferUriWithToken { get { throw null; } }
        public string PublisherOfferBaseUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.AccessTokenResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.AccessTokenResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.AccessTokenResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.AccessTokenResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.AccessTokenResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmSaasModelFactory
    {
        public static Azure.ResourceManager.Saas.Models.AccessTokenResult AccessTokenResult(string publisherOfferBaseUri = null, string token = null, string offerUriWithToken = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent CheckNameAvailabilityContent(string name = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.ResourceValidationError ResourceValidationError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.ResourceValidationResult ResourceValidationResult(bool isValid = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Saas.Models.ResourceValidationError> details = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPurchaseValidationContent SaasPurchaseValidationContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasPurchaseValidationProperties SaasPurchaseValidationProperties(Azure.ResourceManager.Saas.Models.SaasProvisioningState? provisioningState = default(Azure.ResourceManager.Saas.Models.SaasProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.Saas.Models.SaasResourceStatus? status = default(Azure.ResourceManager.Saas.Models.SaasResourceStatus?), Azure.ResourceManager.Saas.Models.SubscriptionStatusReason? statusReason = default(Azure.ResourceManager.Saas.Models.SubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? autoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.PatchIntent? intent = default(Azure.ResourceManager.Saas.Models.PatchIntent?), string name = null) { throw null; }
        public static Azure.ResourceManager.Saas.SaasResourceData SaasResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Saas.Models.SaasResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourcePatch SaasResourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceProperties SaasResourceProperties(Azure.ResourceManager.Saas.Models.SaasProvisioningState? provisioningState = default(Azure.ResourceManager.Saas.Models.SaasProvisioningState?), string assetId = null, string description = null, Azure.ResourceManager.Saas.Models.SaasResourceStatus? status = default(Azure.ResourceManager.Saas.Models.SaasResourceStatus?), Azure.ResourceManager.Saas.Models.SubscriptionStatusReason? statusReason = default(Azure.ResourceManager.Saas.Models.SubscriptionStatusReason?), long? quantity = default(long?), string publisherName = null, string planName = null, string offerName = null, string termUnit = null, string billingPeriod = null, string riskPropertyBagHeader = null, System.DateTimeOffset? termStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? termEndsOn = default(System.DateTimeOffset?), System.DateTimeOffset? futureStartsOn = default(System.DateTimeOffset?), bool? autoRenew = default(bool?), bool? isFreeTrial = default(bool?), string storefront = null, string purchaserEmail = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.PatchIntent? intent = default(Azure.ResourceManager.Saas.Models.PatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties SaasResourceUpdateProperties(string description = null, long? quantity = default(long?), string riskPropertyBagHeader = null, bool? autoRenew = default(bool?), string storefront = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.PatchIntent? intent = default(Azure.ResourceManager.Saas.Models.PatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.SaasTenantResourceData SaasTenantResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Saas.Models.SaasResourceProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch SaasTenantResourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties SaasTenantResourceUpdateProperties(string description = null, long? quantity = default(long?), string riskPropertyBagHeader = null, bool? autoRenew = default(bool?), string storefront = null, string quoteId = null, string privateOfferId = null, string productCode = null, Azure.ResourceManager.Saas.Models.PatchIntent? intent = default(Azure.ResourceManager.Saas.Models.PatchIntent?)) { throw null; }
        public static Azure.ResourceManager.Saas.Models.UnsubscribeConfig UnsubscribeConfig(bool? unsubscribeOnly = default(bool?), int? reasonCode = default(int?), string feedback = null, Azure.ResourceManager.Saas.Models.DeletionSource? deletionSource = default(Azure.ResourceManager.Saas.Models.DeletionSource?)) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeletionSource : System.IEquatable<Azure.ResourceManager.Saas.Models.DeletionSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeletionSource(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.DeletionSource AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.DeletionSource CustomerCancellation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.DeletionSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.DeletionSource left, Azure.ResourceManager.Saas.Models.DeletionSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.DeletionSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.DeletionSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.DeletionSource left, Azure.ResourceManager.Saas.Models.DeletionSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchIntent : System.IEquatable<Azure.ResourceManager.Saas.Models.PatchIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchIntent(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.PatchIntent Reset { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.PatchIntent Retain { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.PatchIntent ScheduleChange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.PatchIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.PatchIntent left, Azure.ResourceManager.Saas.Models.PatchIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.PatchIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.PatchIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.PatchIntent left, Azure.ResourceManager.Saas.Models.PatchIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceValidationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>
    {
        internal ResourceValidationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.ResourceValidationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.ResourceValidationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.ResourceValidationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.ResourceValidationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>
    {
        internal ResourceValidationResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Saas.Models.ResourceValidationError> Details { get { throw null; } }
        public bool IsValid { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.ResourceValidationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.ResourceValidationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.ResourceValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.ResourceValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.ResourceValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? AutoRenew { get { throw null; } set { } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.PatchIntent? Intent { get { throw null; } set { } }
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
        public Azure.ResourceManager.Saas.Models.SubscriptionStatusReason? StatusReason { get { throw null; } }
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
    public partial class SaasResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>
    {
        public SaasResourcePatch() { }
        public Azure.ResourceManager.Saas.Models.SaasResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasResourceProperties>
    {
        public SaasResourceProperties() { }
        public string AssetId { get { throw null; } }
        public bool? AutoRenew { get { throw null; } set { } }
        public string BillingPeriod { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FutureStartsOn { get { throw null; } }
        public Azure.ResourceManager.Saas.Models.PatchIntent? Intent { get { throw null; } set { } }
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
        public Azure.ResourceManager.Saas.Models.SubscriptionStatusReason? StatusReason { get { throw null; } }
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
        public bool? AutoRenew { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.PatchIntent? Intent { get { throw null; } set { } }
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
    public partial class SaasTenantResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>
    {
        public SaasTenantResourcePatch() { }
        public Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasTenantResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.SaasTenantResourceUpdateProperties>
    {
        public SaasTenantResourceUpdateProperties() { }
        public bool? AutoRenew { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Saas.Models.PatchIntent? Intent { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionStatusReason : System.IEquatable<Azure.ResourceManager.Saas.Models.SubscriptionStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionStatusReason(string value) { throw null; }
        public static Azure.ResourceManager.Saas.Models.SubscriptionStatusReason AzureSubscriptionDeletion { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SubscriptionStatusReason None { get { throw null; } }
        public static Azure.ResourceManager.Saas.Models.SubscriptionStatusReason SuspendedInternal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Saas.Models.SubscriptionStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Saas.Models.SubscriptionStatusReason left, Azure.ResourceManager.Saas.Models.SubscriptionStatusReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SubscriptionStatusReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Saas.Models.SubscriptionStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Saas.Models.SubscriptionStatusReason left, Azure.ResourceManager.Saas.Models.SubscriptionStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnsubscribeConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>
    {
        public UnsubscribeConfig() { }
        public Azure.ResourceManager.Saas.Models.DeletionSource? DeletionSource { get { throw null; } set { } }
        public string Feedback { get { throw null; } set { } }
        public int? ReasonCode { get { throw null; } set { } }
        public bool? UnsubscribeOnly { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Saas.Models.UnsubscribeConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Saas.Models.UnsubscribeConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Saas.Models.UnsubscribeConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Saas.Models.UnsubscribeConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Saas.Models.UnsubscribeConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
