namespace Azure.ResourceManager.CommvaultContentStore
{
    public partial class AzureResourceManagerCommvaultContentStoreContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCommvaultContentStoreContext() { }
        public static Azure.ResourceManager.CommvaultContentStore.AzureResourceManagerCommvaultContentStoreContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CloudAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>, System.Collections.IEnumerable
    {
        protected CloudAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudAccountName, Azure.ResourceManager.CommvaultContentStore.CloudAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudAccountName, Azure.ResourceManager.CommvaultContentStore.CloudAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> Get(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetAsync(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetIfExists(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetIfExistsAsync(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>
    {
        public CloudAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CloudAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CloudAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudAccountResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.CloudAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> GetCommvaultPlan(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> GetCommvaultPlanAsync(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultPlanCollection GetCommvaultPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> GetCommvaultStorage(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> GetCommvaultStorageAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultStorageCollection GetCommvaultStorages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult> GetLatestLinkedSaas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>> GetLatestLinkedSaasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> GetProtectionGroup(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> GetProtectionGroupAsync(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectionGroupCollection GetProtectionGroups() { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMapping() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> LinkSaas(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> LinkSaasAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CloudAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CloudAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CloudAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CommvaultContentStoreExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData> ActivateSaasResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>> ActivateSaasResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult> CountProtectedItems(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>> CountProtectedItemsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetCloudAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountResource GetCloudAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountCollection GetCloudAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource GetCommvaultPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource GetCommvaultStorageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource GetProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource GetProtectionGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CommvaultPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>, System.Collections.IEnumerable
    {
        protected CommvaultPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string planName, Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string planName, Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> Get(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> GetAsync(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> GetIfExists(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> GetIfExistsAsync(string planName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommvaultPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>
    {
        public CommvaultPlanData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommvaultPlanResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName, string planName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommvaultStorageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>, System.Collections.IEnumerable
    {
        protected CommvaultStorageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> Get(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> GetAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> GetIfExists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> GetIfExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommvaultStorageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>
    {
        public CommvaultStorageData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultStorageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommvaultStorageResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName, string storageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> DisableComplianceLock(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> DisableComplianceLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> EnableComplianceLock(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> EnableComplianceLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> Refresh(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> RefreshAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectedItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>, System.Collections.IEnumerable
    {
        protected ProtectedItemCollection() { }
        public virtual Azure.Response<bool> Exists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> Get(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>> GetAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> GetIfExists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>> GetIfExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectedItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>
    {
        internal ProtectedItemData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.ProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.ProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectedItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectedItemResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectedItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName, string protectionGroupName, string protectedItemName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints> GetRestorePoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>> GetRestorePointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult> Restore(Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>> RestoreAsync(Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.ProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.ProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>, System.Collections.IEnumerable
    {
        protected ProtectionGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectionGroupName, Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectionGroupName, Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> Get(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> GetAsync(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> GetIfExists(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> GetIfExistsAsync(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectionGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>
    {
        public ProtectionGroupData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionGroupResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult> Backup(Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>> BackupAsync(Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName, string protectionGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource> GetProtectedItem(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource>> GetProtectedItemAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectedItemCollection GetProtectedItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult> Restore(Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>> RestoreAsync(Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleMappingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>
    {
        public RoleMappingData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.RoleMappingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.RoleMappingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleMappingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleMappingResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.RoleMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.RoleMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.RoleMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.RoleMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.RoleMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.RoleMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.RoleMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.RoleMappingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.RoleMappingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.RoleMappingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.CommvaultContentStore.Mocking
{
    public partial class MockableCommvaultContentStoreArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreArmClient() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.CloudAccountResource GetCloudAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource GetCommvaultPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultStorageResource GetCommvaultStorageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource GetProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource GetProtectionGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCommvaultContentStoreResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccount(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetCloudAccountAsync(string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CloudAccountCollection GetCloudAccounts() { throw null; }
    }
    public partial class MockableCommvaultContentStoreSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData> ActivateSaasResource(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>> ActivateSaasResourceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCommvaultContentStoreTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult> CountProtectedItems(Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>> CountProtectedItemsAsync(Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CommvaultContentStore.Models
{
    public static partial class ArmCommvaultContentStoreModelFactory
    {
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent BackupProtectionGroupContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference> vmList = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration backupConfiguration = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult BackupProtectionGroupResult(int taskId = 0, System.Collections.Generic.IEnumerable<string> jobIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountData CloudAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch CloudAccountIdentityPatch(Azure.ResourceManager.Models.ManagedServiceIdentityType? type = default(Azure.ResourceManager.Models.ManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch CloudAccountMarketplacePatch(Azure.Core.ResourceIdentifier saasResourceId = null, string subscriptionId = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch offerDetails = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch CloudAccountOfferDetailsPatch(string publisherId = null, string offerId = null, string planName = null, string termUnit = null, string termId = null, string planId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch CloudAccountPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties properties = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch identity = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties CloudAccountPatchProperties(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile company = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch marketplace = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch user = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties CloudAccountProperties(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails marketplace = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails user = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?), string ssoUri = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile company = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment> roleAssignmentsOnCreate = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch CloudAccountUserPatch(string userPrincipalName = null, string phoneNumber = null, string firstName = null, string lastName = null, string emailAddress = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration CommvaultBackupConfiguration(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel? backupLevel = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel?), string jobDescription = null, bool shouldCopyImmediately = false, bool shouldRunSnapshotBackup = false, bool shouldNotifyUserOnJobCompletion = false) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule CommvaultBackupSchedule(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType backupType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency? frequency = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency?), int? interval = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth? weekOfMonth = default(Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth?), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek? dayOfWeek = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek?), Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear? monthOfYear = default(Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear?), int? dayOfMonth = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek> daysOfWeek = null, string time = null, string timeZone = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile CommvaultCompanyProfile(string jobTitle = null, string companyName = null, string website = null, string street = null, string city = null, string country = null, string postalCode = null, string state = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy CommvaultExtendedRetentionPolicy(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval? retentionInterval = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval?), int? retentionPeriod = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType? backupRuleType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails CommvaultMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus?), Azure.Core.ResourceIdentifier saasResourceId = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails CommvaultOfferDetails(string publisherId = null, string offerId = null, string planId = null, string planName = null, string termUnit = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData CommvaultPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties CommvaultPlanProperties(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan> storagePlans = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule> schedules = null, int? retentionSnapshotCount = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment CommvaultRoleAssignment(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName roleName = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal> principals = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal CommvaultRolePrincipal(string id = null, string displayName = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType? principalType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent CommvaultSaasActivationContent(System.Guid saasGuid = default(System.Guid), string publisherId = null, Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails activationDetails = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails CommvaultSaasDetails(Azure.Core.ResourceIdentifier saasResourceId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultStorageData CommvaultStorageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan CommvaultStoragePlan(string name = null, string storagePoolId = null, string copyName = null, int? copyPrecedence = default(int?), int? retentionPeriod = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval? retentionInterval = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval?), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType? backupRuleType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy> extendedRetentionPolicies = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties CommvaultStorageProperties(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType storageType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor vendor = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType storageClass = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType), Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?), Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus? complianceLockStatus = default(Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails CommvaultUserDetails(string firstName = null, string lastName = null, string emailAddress = null, string userPrincipalName = null, string phoneNumber = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference CommvaultVmReference(string vmGuid = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings CommvaultVmRestoreSettings(string sourceVmGuid = null, string storageAccountId = null, bool? shouldPowerOnVmAfterRestore = default(bool?), string name = null, string resourceGroupName = null, string region = null, string virtualNetworkId = null, string subnetId = null, bool? shouldAttachAndSwapOSDisk = default(bool?), string targetVmGuid = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag> tags = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag CommvaultVmTag(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent CountProtectedItemsContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult CountProtectedItemsResult(string count = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult LatestLinkedSaasResult(Azure.Core.ResourceIdentifier saasResourceId = null, bool? isHiddenSaas = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectedItemData ProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties ProtectedItemProperties(string resourceName = null, long lastBackupTime = (long)0, string resourceGroupName = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string vmGuid = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints ProtectedItemRestorePoints(System.Collections.Generic.IEnumerable<long> restoreTimes = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData ProtectionGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties ProtectionGroupProperties(string plan = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection resourceSelection = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus protectionStatus = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus), int protectedItemCount = 0, long lastBackupTime = (long)0, string backupActivityStatus = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection ProtectionGroupResourceSelection(System.Collections.Generic.IEnumerable<string> manuallySelectedItems = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules matchRules = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules ProtectionGroupResourcesMatchRules(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule> rules = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType matchType = default(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule ProtectionGroupRule(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty property = default(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator @operator = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator), string value = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent RestoreProtectionItemContent(bool isInPlaceRestore = false, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType? restoreType = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType?), string restorePointTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings> vmInfoList = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult RestoreProtectionItemResult(int taskId = 0, System.Collections.Generic.IEnumerable<string> jobIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.RoleMappingData RoleMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties RoleMappingProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment> roleAssignments = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails SaasActivationDetails(Azure.Core.ResourceIdentifier saasResourceId = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails user = null, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile company = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData SaasResourceDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier saasResourceId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent StopBackupProtectionGroupContent(string reason = null, string comment = null) { throw null; }
    }
    public partial class BackupProtectionGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>
    {
        public BackupProtectionGroupContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference> vmList, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration backupConfiguration) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration BackupConfiguration { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference> VmList { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProtectionGroupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>
    {
        internal BackupProtectionGroupResult() { }
        public System.Collections.Generic.IReadOnlyList<string> JobIds { get { throw null; } }
        public int TaskId { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountIdentityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>
    {
        public CloudAccountIdentityPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountMarketplacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>
    {
        public CloudAccountMarketplacePatch() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch OfferDetails { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountOfferDetailsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>
    {
        public CloudAccountOfferDetailsPatch() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountOfferDetailsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>
    {
        public CloudAccountPatch() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountIdentityPatch Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>
    {
        public CloudAccountPatchProperties() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile Company { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountMarketplacePatch Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>
    {
        public CloudAccountProperties(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails marketplace, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails user) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile Company { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment> RoleAssignmentsOnCreate { get { throw null; } }
        public string SsoUri { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountUserPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>
    {
        public CloudAccountUserPatch() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUserPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultBackupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>
    {
        public CommvaultBackupConfiguration(string jobDescription, bool shouldCopyImmediately, bool shouldRunSnapshotBackup, bool shouldNotifyUserOnJobCompletion) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel? BackupLevel { get { throw null; } set { } }
        public string JobDescription { get { throw null; } }
        public bool ShouldCopyImmediately { get { throw null; } }
        public bool ShouldNotifyUserOnJobCompletion { get { throw null; } }
        public bool ShouldRunSnapshotBackup { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultBackupFrequency : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultBackupFrequency(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency Daily { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency Minutes { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency Monthly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency Weekly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultBackupLevel : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultBackupLevel(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel Differential { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel Full { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel Incremental { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel SyntheticFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultBackupRuleType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultBackupRuleType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType AllFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType AllJobs { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType DailyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType HalfYearlyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType HourlyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType MonthlyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType QuarterlyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType WeeklyFullBackups { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType YearlyFullBackups { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultBackupSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>
    {
        public CommvaultBackupSchedule(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType backupType) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType BackupType { get { throw null; } set { } }
        public int? DayOfMonth { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear? MonthOfYear { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth? WeekOfMonth { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultBackupType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultBackupType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType Both { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType Full { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType Incremental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultCompanyProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>
    {
        public CommvaultCompanyProfile() { }
        public string City { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string JobTitle { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        public string Street { get { throw null; } set { } }
        public string Website { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultDayOfWeek : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Day { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Wednesday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek Weekday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek WeekendDays { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultExtendedRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>
    {
        public CommvaultExtendedRetentionPolicy() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType? BackupRuleType { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval? RetentionInterval { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>
    {
        public CommvaultMarketplaceDetails(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails offerDetails) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails OfferDetails { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultMatchOperator : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultMatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator DoesNotContain { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator DoesNotEqual { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>
    {
        public CommvaultOfferDetails(string publisherId, string offerId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>
    {
        public CommvaultPlanProperties(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan> storagePlans) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int? RetentionSnapshotCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupSchedule> Schedules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan> StoragePlans { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultProtectionStatus : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus All { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus BackedUpWithError { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus Discovered { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus Protected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultRestoreType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultRestoreType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType DiskAttach { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType None { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultRetentionInterval : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultRetentionInterval(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval Monthly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultRoleAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>
    {
        public CommvaultRoleAssignment(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName roleName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal> principals) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal> Principals { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName RoleName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultRoleName : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultRoleName(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName BackupAdministrator { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName BackupOperator { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName BackupUser { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName MultiPersonAuthorization { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName SecurityAdministrator { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultRolePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>
    {
        public CommvaultRolePrincipal() { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType? PrincipalType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultRolePrincipalType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultRolePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRolePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultSaasActivationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>
    {
        public CommvaultSaasActivationContent(System.Guid saasGuid) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails ActivationDetails { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public System.Guid SaasGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasActivationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultSaasDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>
    {
        public CommvaultSaasDetails() { }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaasDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultScheduleDayOfWeek : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultScheduleDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultScheduleDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultStorageClassType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultStorageClassType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType Cold { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType Cool { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType Hot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultStoragePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>
    {
        public CommvaultStoragePlan(string name) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultBackupRuleType? BackupRuleType { get { throw null; } set { } }
        public string CopyName { get { throw null; } set { } }
        public int? CopyPrecedence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultExtendedRetentionPolicy> ExtendedRetentionPolicies { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRetentionInterval? RetentionInterval { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        public string StoragePoolId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStoragePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>
    {
        public CommvaultStorageProperties(Azure.Core.AzureLocation location, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType storageType, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor vendor, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType storageClass) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus? ComplianceLockStatus { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageClassType StorageClass { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor Vendor { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultStorageType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultStorageType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType AirGapProtect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>
    {
        public CommvaultUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultVendor : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultVendor(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor AzureBlobStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor left, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVendor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommvaultVmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>
    {
        public CommvaultVmReference(string vmGuid) { }
        public string VmGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultVmRestoreSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>
    {
        public CommvaultVmRestoreSettings(string sourceVmGuid, string storageAccountId) { }
        public string Name { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public bool? ShouldAttachAndSwapOSDisk { get { throw null; } set { } }
        public bool? ShouldPowerOnVmAfterRestore { get { throw null; } set { } }
        public string SourceVmGuid { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag> Tags { get { throw null; } }
        public string TargetVmGuid { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommvaultVmTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>
    {
        public CommvaultVmTag(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComplianceLockStatus : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComplianceLockStatus(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus DisablementPending { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus left, Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus left, Azure.ResourceManager.CommvaultContentStore.Models.ComplianceLockStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CountProtectedItemsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>
    {
        public CountProtectedItemsContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CountProtectedItemsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>
    {
        internal CountProtectedItemsResult() { }
        public string Count { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LatestLinkedSaasResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>
    {
        internal LatestLinkedSaasResult() { }
        public bool? IsHiddenSaas { get { throw null; } }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaasResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonthOfYear : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonthOfYear(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear April { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear August { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear December { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear February { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear January { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear July { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear June { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear March { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear May { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear November { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear October { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear left, Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear left, Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectedItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>
    {
        internal ProtectedItemProperties() { }
        public long LastBackupTime { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string VmGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectedItemRestorePoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>
    {
        internal ProtectedItemRestorePoints() { }
        public System.Collections.Generic.IReadOnlyList<long> RestoreTimes { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemRestorePoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionGroupMatchType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionGroupMatchType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType All { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType Any { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectionGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>
    {
        public ProtectionGroupProperties(string plan, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection resourceSelection) { }
        public string BackupActivityStatus { get { throw null; } }
        public string DataSourceType { get { throw null; } }
        public long LastBackupTime { get { throw null; } }
        public string Plan { get { throw null; } set { } }
        public int ProtectedItemCount { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultProtectionStatus ProtectionStatus { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection ResourceSelection { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupResourceSelection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>
    {
        public ProtectionGroupResourceSelection() { }
        public System.Collections.Generic.IList<string> ManuallySelectedItems { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules MatchRules { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourceSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupResourcesMatchRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>
    {
        public ProtectionGroupResourcesMatchRules(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule> rules, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType matchType) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupMatchType MatchType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule> Rules { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>
    {
        public ProtectionGroupRule(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty property, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator @operator, string value) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator Operator { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionGroupRuleProperty : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionGroupRuleProperty(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty Name { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty Region { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty Status { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty TagName { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty TagValue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupRuleProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState left, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState left, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreProtectionItemContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>
    {
        public RestoreProtectionItemContent(bool isInPlaceRestore, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings> vmInfoList) { }
        public bool IsInPlaceRestore { get { throw null; } }
        public string RestorePointTime { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRestoreType? RestoreType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultVmRestoreSettings> VmInfoList { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreProtectionItemResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>
    {
        internal RestoreProtectionItemResult() { }
        public System.Collections.Generic.IReadOnlyList<string> JobIds { get { throw null; } }
        public int TaskId { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>
    {
        public RoleMappingProperties() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultRoleAssignment> RoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasActivationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>
    {
        public SaasActivationDetails() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultCompanyProfile Company { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasActivationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasResourceDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>
    {
        internal SaasResourceDetailsData() { }
        public Azure.Core.ResourceIdentifier SaasResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaasResourceDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopBackupProtectionGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>
    {
        public StopBackupProtectionGroupContent(string reason) { }
        public string Comment { get { throw null; } set { } }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekOfMonth : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekOfMonth(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth First { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth Fourth { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth Last { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth Second { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth left, Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth left, Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth right) { throw null; }
        public override string ToString() { throw null; }
    }
}
