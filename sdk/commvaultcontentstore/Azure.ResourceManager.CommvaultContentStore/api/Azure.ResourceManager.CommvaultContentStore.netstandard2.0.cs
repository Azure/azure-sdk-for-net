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
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource> GetProtectionGroup(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource>> GetProtectionGroupAsync(string protectionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectionGroupCollection GetProtectionGroups() { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMapping() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource> GetStorage(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource>> GetStorageAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.StorageCollection GetStorages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult> LatestLinkedSaaS(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>> LatestLinkedSaaSAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> LinkSaaS(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> LinkSaaSAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData> ActivateResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>> ActivateResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult> CountByProtectionGroups(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>> CountByProtectionGroupsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource>> GetCloudAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountResource GetCloudAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountCollection GetCloudAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource GetCommvaultPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource GetProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource GetProtectionGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.StorageResource GetStorageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints> GetRestorePoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>> GetRestorePointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class StorageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.StorageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.StorageResource>, System.Collections.IEnumerable
    {
        protected StorageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.StorageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.CommvaultContentStore.StorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.StorageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.CommvaultContentStore.StorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource> Get(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.StorageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.StorageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource>> GetAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.StorageResource> GetIfExists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CommvaultContentStore.StorageResource>> GetIfExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CommvaultContentStore.StorageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CommvaultContentStore.StorageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CommvaultContentStore.StorageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.StorageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>
    {
        public StorageData() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.StorageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.StorageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageResource() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.StorageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudAccountName, string storageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.StorageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.StorageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.StorageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.StorageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.StorageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.StorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.StorageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.StorageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CommvaultContentStore.Mocking
{
    public partial class MockableCommvaultContentStoreArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreArmClient() { }
        public virtual Azure.ResourceManager.CommvaultContentStore.CloudAccountResource GetCloudAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.CommvaultPlanResource GetCommvaultPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectedItemResource GetProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.ProtectionGroupResource GetProtectionGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.RoleMappingResource GetRoleMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CommvaultContentStore.StorageResource GetStorageResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData> ActivateResource(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>> ActivateResourceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CommvaultContentStore.CloudAccountResource> GetCloudAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCommvaultContentStoreTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommvaultContentStoreTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult> CountByProtectionGroups(Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult>> CountByProtectionGroupsAsync(Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CommvaultContentStore.Models
{
    public partial class ActivateSaaSParameterContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>
    {
        public ActivateSaaSParameterContent(string saaSGuid) { }
        public string SaaSGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmCommvaultContentStoreModelFactory
    {
        public static Azure.ResourceManager.CommvaultContentStore.Models.ActivateSaaSParameterContent ActivateSaaSParameterContent(string saaSGuid = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig BackupConfig(Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel? backupLevel = default(Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel?), string jobDescription = null, bool shouldCopyImmediately = false, bool shouldRunSnapshotBackup = false, bool shouldNotifyUserOnJobCompletion = false) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent BackupProtectionGroupContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem> vmList = null, Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig backupOptions = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupResult BackupProtectionGroupResult(int taskId = 0, System.Collections.Generic.IEnumerable<string> jobIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CloudAccountData CloudAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch CloudAccountPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties CloudAccountProperties(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.CommvaultContentStore.Models.UserDetails user = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?), string ssoUri = null, Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo backupAdminOnCcaCreate = null, Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo multiPersonAuthorizationOnCcaCreate = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties CloudAccountUpdateProperties(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.CommvaultContentStore.Models.UserDetails user = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.CommvaultPlanData CommvaultPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails CommvaultSaaSDetails(string saaSResourceId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsContent CountProtectedItemsContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CountProtectedItemsResult CountProtectedItemsResult(string count = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo EntityInfo(string id = null, string displayName = null, Azure.ResourceManager.CommvaultContentStore.Models.EntityType? entityType = default(Azure.ResourceManager.CommvaultContentStore.Models.EntityType?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime ExtendedRetentionTime(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime? retentionTime = default(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime?), int? retentionPeriod = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType? backupRuleType = default(Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult LatestLinkedSaaSResult(string saaSResourceId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus?), string saasResourceId = null, Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails OfferDetails(string publisherId = null, string offerId = null, string planId = null, string planName = null, string termUnit = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties PlanProperties(string location = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan> storagePlans = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.Schedule> schedules = null, int? retentionNumberOfSnapshots = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectedItemData ProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties ProtectedItemProperties(string resourceName = null, long lastBackUpTime = (long)0, string resourceGroup = null, string location = null, string vmGuid = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.ProtectionGroupData ProtectionGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties ProtectionGroupProperties(string plan = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources resources = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus? protectionStatus = default(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus?), int? numberOfProtectedItems = default(int?), long? lastBackUpTime = default(long?), string backupActivityStatus = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources ProtectionGroupResources(System.Collections.Generic.IEnumerable<string> manual = null, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules matchRules = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules ProtectionGroupResourcesMatchRules(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.Rule> rules = null, Azure.ResourceManager.CommvaultContentStore.Models.MatchType matchType = default(Azure.ResourceManager.CommvaultContentStore.Models.MatchType)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints RestorePoints(System.Collections.Generic.IEnumerable<long> restoreTimes = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent RestoreProtectionItemContent(bool inPlaceRestore = false, Azure.ResourceManager.CommvaultContentStore.Models.RestoreType? restoreType = default(Azure.ResourceManager.CommvaultContentStore.Models.RestoreType?), string toTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo> vmInfoList = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemResult RestoreProtectionItemResult(int taskId = 0, System.Collections.Generic.IEnumerable<string> jobIds = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment RoleAssignment(Azure.ResourceManager.CommvaultContentStore.Models.RoleName? roleName = default(Azure.ResourceManager.CommvaultContentStore.Models.RoleName?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo> entities = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.RoleMappingData RoleMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties RoleMappingProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment> roles = null, Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Rule Rule(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty property = default(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator @operator = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator), string value = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData SaaSResourceDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string saaSResourceId = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Schedule Schedule(Azure.ResourceManager.CommvaultContentStore.Models.BackupType backupType = default(Azure.ResourceManager.CommvaultContentStore.Models.BackupType), Azure.ResourceManager.CommvaultContentStore.Models.Frequency? frequency = default(Azure.ResourceManager.CommvaultContentStore.Models.Frequency?), int? runsEvery = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth? weekOfMonth = default(Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth?), Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek? dayOfWeek = default(Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek?), Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear? monthOfYear = default(Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear?), int? dayOfMonth = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays> weeklyDays = null, string time = null, string timeZone = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StopBackupProtectionGroupContent StopBackupProtectionGroupContent(string reason = null, string comment = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.StorageData StorageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan StoragePlan(string name = null, string storagePoolId = null, string copyName = null, int? copyPrecedence = default(int?), int? retentionPeriod = default(int?), Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime? retentionTime = default(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime?), Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType? backupRuleType = default(Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime> extendedRetention = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties StorageProperties(string location = null, Azure.ResourceManager.CommvaultContentStore.Models.StorageType storageType = default(Azure.ResourceManager.CommvaultContentStore.Models.StorageType), Azure.ResourceManager.CommvaultContentStore.Models.Vendor vendor = default(Azure.ResourceManager.CommvaultContentStore.Models.Vendor), Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType @class = default(Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType), Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.UserDetails UserDetails(string firstName = null, string lastName = null, string emailAddress = null, string upn = null, string phoneNumber = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.VmInfo VmInfo(string sourceVmGuid = null, string storageAccountId = null, bool? powerOnVmAfterRestore = default(bool?), string name = null, string resourceGroup = null, string region = null, string networkId = null, string subnetId = null, bool? attachAndSwapOsDisk = default(bool?), string targetVmGuid = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.VmTag> vmtags = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.VmListItem VmListItem(string vmGuid = null) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.VmTag VmTag(string name = null, string value = null) { throw null; }
    }
    public partial class BackupConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>
    {
        public BackupConfig(string jobDescription, bool shouldCopyImmediately, bool shouldRunSnapshotBackup, bool shouldNotifyUserOnJobCompletion) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel? BackupLevel { get { throw null; } set { } }
        public string JobDescription { get { throw null; } }
        public bool ShouldCopyImmediately { get { throw null; } }
        public bool ShouldNotifyUserOnJobCompletion { get { throw null; } }
        public bool ShouldRunSnapshotBackup { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupLevel : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupLevel(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel Differential { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel Full { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel Incremental { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel SyntheticFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel left, Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel left, Azure.ResourceManager.CommvaultContentStore.Models.BackupLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupProtectionGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.BackupProtectionGroupContent>
    {
        public BackupProtectionGroupContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem> vmList, Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig backupOptions) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.BackupConfig BackupOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem> VmList { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupRuleType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupRuleType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType AllFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType AllJobs { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType DailyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType HalfYearlyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType HourlyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType MonthlyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType QuarterlyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType WeeklyFulls { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType YearlyFulls { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType left, Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType left, Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupType Both { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupType Full { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.BackupType Incremental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.BackupType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.BackupType left, Azure.ResourceManager.CommvaultContentStore.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.BackupType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.BackupType left, Azure.ResourceManager.CommvaultContentStore.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountPatch>
    {
        public CloudAccountPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties Properties { get { throw null; } set { } }
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
    public partial class CloudAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountProperties>
    {
        public CloudAccountProperties(Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails marketplace, Azure.ResourceManager.CommvaultContentStore.Models.UserDetails user) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo BackupAdminOnCcaCreate { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo MultiPersonAuthorizationOnCcaCreate { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string SsoUri { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.UserDetails User { get { throw null; } set { } }
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
    public partial class CloudAccountUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>
    {
        public CloudAccountUpdateProperties() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.UserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CloudAccountUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommvaultMatchOperator : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommvaultMatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator DoesNotContains { get { throw null; } }
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
    public partial class CommvaultSaaSDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>
    {
        public CommvaultSaaSDetails() { }
        public string SaaSResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.CommvaultSaaSDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EntityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>
    {
        public EntityInfo() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.EntityType? EntityType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.EntityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.EntityType Group { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.EntityType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.EntityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.EntityType left, Azure.ResourceManager.CommvaultContentStore.Models.EntityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.EntityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.EntityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.EntityType left, Azure.ResourceManager.CommvaultContentStore.Models.EntityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedRetentionTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>
    {
        public ExtendedRetentionTime() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType? BackupRuleType { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime? RetentionTime { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Frequency Daily { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Frequency Minutes { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Frequency Monthly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Frequency Weekly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Frequency Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.Frequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.Frequency left, Azure.ResourceManager.CommvaultContentStore.Models.Frequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.Frequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.Frequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.Frequency left, Azure.ResourceManager.CommvaultContentStore.Models.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LatestLinkedSaaSResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>
    {
        internal LatestLinkedSaaSResult() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public string SaaSResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.LatestLinkedSaaSResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SaasResourceId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct MatchType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.MatchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MatchType All { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.MatchType Any { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.MatchType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.MatchType left, Azure.ResourceManager.CommvaultContentStore.Models.MatchType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MatchType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.MatchType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.MatchType left, Azure.ResourceManager.CommvaultContentStore.Models.MatchType right) { throw null; }
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
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>
    {
        public PlanProperties(string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan> storagePlans) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int? RetentionNumberOfSnapshots { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.Schedule> Schedules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan> StoragePlans { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.PlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectedItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectedItemProperties>
    {
        internal ProtectedItemProperties() { }
        public long LastBackUpTime { get { throw null; } }
        public string Location { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
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
    public partial class ProtectionGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupProperties>
    {
        public ProtectionGroupProperties(string plan, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources resources) { }
        public string BackupActivityStatus { get { throw null; } }
        public string DataSourceType { get { throw null; } }
        public long? LastBackUpTime { get { throw null; } }
        public int? NumberOfProtectedItems { get { throw null; } }
        public string Plan { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus? ProtectionStatus { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources Resources { get { throw null; } set { } }
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
    public partial class ProtectionGroupResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>
    {
        public ProtectionGroupResources() { }
        public System.Collections.Generic.IList<string> Manual { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules MatchRules { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionGroupResourcesMatchRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionGroupResourcesMatchRules>
    {
        public ProtectionGroupResourcesMatchRules(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.Rule> rules, Azure.ResourceManager.CommvaultContentStore.Models.MatchType matchType) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.MatchType MatchType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.Rule> Rules { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionStatus : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus All { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus BackedUpWithError { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus Discovered { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus Protected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus left, Azure.ResourceManager.CommvaultContentStore.Models.ProtectionStatus right) { throw null; }
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
    public partial class RestorePoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>
    {
        internal RestorePoints() { }
        public System.Collections.Generic.IReadOnlyList<long> RestoreTimes { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestorePoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreProtectionItemContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RestoreProtectionItemContent>
    {
        public RestoreProtectionItemContent(bool inPlaceRestore, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo> vmInfoList) { }
        public bool InPlaceRestore { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.RestoreType? RestoreType { get { throw null; } set { } }
        public string ToTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo> VmInfoList { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.RestoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreType DiskAttach { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreType None { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RestoreType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.RestoreType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.RestoreType left, Azure.ResourceManager.CommvaultContentStore.Models.RestoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RestoreType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RestoreType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.RestoreType left, Azure.ResourceManager.CommvaultContentStore.Models.RestoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionTime : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionTime(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime Monthly { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime left, Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime left, Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>
    {
        public RoleAssignment() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.EntityInfo> Entities { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.RoleName? RoleName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.RoleMappingProperties>
    {
        public RoleMappingProperties() { }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.RoleAssignment> Roles { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleName : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.RoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleName(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleName BackupAdmin { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleName BackupOperator { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleName BackupUser { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleName MultiPersonAuthorization { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RoleName SecurityAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.RoleName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.RoleName left, Azure.ResourceManager.CommvaultContentStore.Models.RoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RoleName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RoleName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.RoleName left, Azure.ResourceManager.CommvaultContentStore.Models.RoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Rule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>
    {
        public Rule(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty property, Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator @operator, string value) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultMatchOperator Operator { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.Rule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.Rule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.Rule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.Rule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Rule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleProperty : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleProperty(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty Name { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty Region { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty Status { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty TagName { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty TagValue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty left, Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty left, Azure.ResourceManager.CommvaultContentStore.Models.RuleProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaaSResourceDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>
    {
        internal SaaSResourceDetailsData() { }
        public string SaaSResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.SaaSResourceDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Schedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>
    {
        public Schedule(Azure.ResourceManager.CommvaultContentStore.Models.BackupType backupType) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.BackupType BackupType { get { throw null; } set { } }
        public int? DayOfMonth { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.CommvaultDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.Frequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.MonthOfYear? MonthOfYear { get { throw null; } set { } }
        public int? RunsEvery { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays> WeeklyDays { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.WeekOfMonth? WeekOfMonth { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.Schedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.Schedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.Schedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.Schedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.Schedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct StorageClassType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageClassType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType Cool { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType Hot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType left, Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType left, Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StoragePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>
    {
        public StoragePlan(string name) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.BackupRuleType? BackupRuleType { get { throw null; } set { } }
        public string CopyName { get { throw null; } set { } }
        public int? CopyPrecedence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.ExtendedRetentionTime> ExtendedRetention { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.RetentionTime? RetentionTime { get { throw null; } set { } }
        public string StoragePoolId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StoragePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>
    {
        public StorageProperties(string location, Azure.ResourceManager.CommvaultContentStore.Models.StorageType storageType, Azure.ResourceManager.CommvaultContentStore.Models.Vendor vendor, Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType @class) { }
        public Azure.ResourceManager.CommvaultContentStore.Models.StorageClassType Class { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CommvaultContentStore.Models.StorageType StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.CommvaultContentStore.Models.Vendor Vendor { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.StorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.StorageType AirGapProtect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.StorageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.StorageType left, Azure.ResourceManager.CommvaultContentStore.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.StorageType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.StorageType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.StorageType left, Azure.ResourceManager.CommvaultContentStore.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.UserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.UserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Vendor : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.Vendor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Vendor(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.Vendor AzureBlobStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.Vendor other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.Vendor left, Azure.ResourceManager.CommvaultContentStore.Models.Vendor right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.Vendor (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.Vendor? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.Vendor left, Azure.ResourceManager.CommvaultContentStore.Models.Vendor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>
    {
        public VmInfo(string sourceVmGuid, string storageAccountId) { }
        public bool? AttachAndSwapOsDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public bool? PowerOnVmAfterRestore { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SourceVmGuid { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string TargetVmGuid { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CommvaultContentStore.Models.VmTag> Vmtags { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.VmInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.VmInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmListItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>
    {
        public VmListItem(string vmGuid) { }
        public string VmGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.VmListItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.VmListItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>
    {
        public VmTag(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CommvaultContentStore.Models.VmTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CommvaultContentStore.Models.VmTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CommvaultContentStore.Models.VmTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CommvaultContentStore.Models.VmTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeeklyDays : System.IEquatable<Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeeklyDays(string value) { throw null; }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Friday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Monday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Saturday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Sunday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Thursday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Tuesday { get { throw null; } }
        public static Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays left, Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays right) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays left, Azure.ResourceManager.CommvaultContentStore.Models.WeeklyDays right) { throw null; }
        public override string ToString() { throw null; }
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
