namespace Azure.ResourceManager.FileShares
{
    public partial class AzureResourceManagerFileSharesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerFileSharesContext() { }
        public static Azure.ResourceManager.FileShares.AzureResourceManagerFileSharesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class FileShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FileShares.FileShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.FileShareResource>, System.Collections.IEnumerable
    {
        protected FileShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.FileShares.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.FileShares.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FileShares.FileShareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FileShares.FileShareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FileShares.FileShareResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FileShares.FileShareResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FileShares.FileShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FileShares.FileShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FileShares.FileShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.FileShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileShareData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>
    {
        public FileShareData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.FileShares.Models.FileShareProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.FileShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.FileShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileShareResource() { }
        public virtual Azure.ResourceManager.FileShares.FileShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource> GetFileShareSnapshot(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> GetFileShareSnapshotAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FileShares.FileShareSnapshotCollection GetFileShareSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.FileShares.FileShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.FileShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FileShares.Models.FileSharePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FileShares.Models.FileSharePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FileSharesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult> CheckFileShareNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>> CheckFileShareNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> GetFileShare(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> GetFileShareAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FileShares.FileShareResource GetFileShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FileShares.FileShareCollection GetFileShares(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FileShares.FileShareResource> GetFileShares(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FileShares.FileShareResource> GetFileSharesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FileShares.FileShareSnapshotResource GetFileShareSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult> GetLimits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>> GetLimitsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult> GetProvisioningRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>> GetProvisioningRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult> GetUsageData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>> GetUsageDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileShareSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FileShares.FileShareSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.FileShareSnapshotResource>, System.Collections.IEnumerable
    {
        protected FileShareSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.FileShares.FileShareSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.FileShares.FileShareSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FileShares.FileShareSnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FileShares.FileShareSnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FileShares.FileShareSnapshotResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FileShares.FileShareSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FileShares.FileShareSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FileShares.FileShareSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.FileShareSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileShareSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>
    {
        public FileShareSnapshotData() { }
        public Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.FileShareSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.FileShareSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileShareSnapshotResource() { }
        public virtual Azure.ResourceManager.FileShares.FileShareSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.FileShares.FileShareSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.FileShareSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.FileShareSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareSnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FileShares.FileShareSnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FileShares.Mocking
{
    public partial class MockableFileSharesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFileSharesArmClient() { }
        public virtual Azure.ResourceManager.FileShares.FileShareResource GetFileShareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FileShares.FileShareSnapshotResource GetFileShareSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableFileSharesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFileSharesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.FileShareResource> GetFileShare(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.FileShareResource>> GetFileShareAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FileShares.FileShareCollection GetFileShares() { throw null; }
    }
    public partial class MockableFileSharesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFileSharesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult> CheckFileShareNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>> CheckFileShareNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FileShares.FileShareResource> GetFileShares(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FileShares.FileShareResource> GetFileSharesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult> GetLimits(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>> GetLimitsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult> GetProvisioningRecommendation(Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>> GetProvisioningRecommendationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult> GetUsageData(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>> GetUsageDataAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FileShares.Models
{
    public static partial class ArmFileSharesModelFactory
    {
        public static Azure.ResourceManager.FileShares.FileShareData FileShareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.FileShares.Models.FileShareProperties properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareLimits FileShareLimits(int maxFileShares = 0, int maxFileShareSnapshots = 0, int maxFileShareSubnets = 0, int maxFileSharePrivateEndpointConnections = 0, int minProvisionedStorageGiB = 0, int maxProvisionedStorageGiB = 0, int minProvisionedIOPerSec = 0, int maxProvisionedIOPerSec = 0, int minProvisionedThroughputMiBPerSec = 0, int maxProvisionedThroughputMiBPerSec = 0) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput FileShareLimitsOutput(Azure.ResourceManager.FileShares.Models.FileShareLimits limits = null, Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants provisioningConstants = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareLimitsResult FileShareLimitsResult(Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult FileShareNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason? reason = default(Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePatch FileSharePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.FileShares.Models.FileSharePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection FileSharePrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties FileSharePrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState FileSharePrivateLinkServiceConnectionState(Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProperties FileShareProperties(string mountName = null, string hostName = null, Azure.ResourceManager.FileShares.Models.FileShareMediaTier? mediaTier = default(Azure.ResourceManager.FileShares.Models.FileShareMediaTier?), Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel? redundancy = default(Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel?), Azure.ResourceManager.FileShares.Models.FileShareProtocol? protocol = default(Azure.ResourceManager.FileShares.Models.FileShareProtocol?), int? provisionedStorageInGiB = default(int?), System.DateTimeOffset? provisionedStorageNextAllowedDowngradeOn = default(System.DateTimeOffset?), int? provisionedIOPerSec = default(int?), System.DateTimeOffset? provisionedIOPerSecNextAllowedDowngradeOn = default(System.DateTimeOffset?), int? provisionedThroughputMiBPerSec = default(int?), System.DateTimeOffset? provisionedThroughputNextAllowedDowngradeOn = default(System.DateTimeOffset?), int? includedBurstIOPerSec = default(int?), long? maxBurstIOPerSecCredits = default(long?), Azure.ResourceManager.FileShares.Models.ShareRootSquash? nfsProtocolRootSquash = default(Azure.ResourceManager.FileShares.Models.ShareRootSquash?), System.Collections.Generic.IEnumerable<string> publicAccessAllowedSubnets = null, Azure.ResourceManager.FileShares.Models.FileShareProvisioningState? provisioningState = default(Azure.ResourceManager.FileShares.Models.FileShareProvisioningState?), Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants FileShareProvisioningConstants(int baseIOPerSec = 0, double scalarIOPerSec = 0, int baseThroughputMiBPerSec = 0, double scalarThroughputMiBPerSec = 0) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent FileShareProvisioningRecommendationContent(int? fileShareProvisioningRecommendationInputProvisionedStorageInGiB = default(int?)) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties FileShareProvisioningRecommendationOutputProperties(int provisionedIOPerSec = 0, int provisionedThroughputMiBPerSec = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel> availableRedundancyOptions = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult FileShareProvisioningRecommendationResult(Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.FileShareSnapshotData FileShareSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties properties = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties FileShareSnapshotProperties(string snapshotTime = null, string initiatorId = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult FileShareUsageDataResult(int? liveSharesFileShareCount = default(int?)) { throw null; }
    }
    public partial class FileShareLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>
    {
        internal FileShareLimits() { }
        public int MaxFileSharePrivateEndpointConnections { get { throw null; } }
        public int MaxFileShares { get { throw null; } }
        public int MaxFileShareSnapshots { get { throw null; } }
        public int MaxFileShareSubnets { get { throw null; } }
        public int MaxProvisionedIOPerSec { get { throw null; } }
        public int MaxProvisionedStorageGiB { get { throw null; } }
        public int MaxProvisionedThroughputMiBPerSec { get { throw null; } }
        public int MinProvisionedIOPerSec { get { throw null; } }
        public int MinProvisionedStorageGiB { get { throw null; } }
        public int MinProvisionedThroughputMiBPerSec { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareLimitsOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>
    {
        internal FileShareLimitsOutput() { }
        public Azure.ResourceManager.FileShares.Models.FileShareLimits Limits { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants ProvisioningConstants { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareLimitsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>
    {
        internal FileShareLimitsResult() { }
        public Azure.ResourceManager.FileShares.Models.FileShareLimitsOutput Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimitsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareLimitsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareLimitsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareLimitsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareLimitsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareMediaTier : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileShareMediaTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareMediaTier(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareMediaTier Ssd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileShareMediaTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileShareMediaTier left, Azure.ResourceManager.FileShares.Models.FileShareMediaTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareMediaTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareMediaTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileShareMediaTier left, Azure.ResourceManager.FileShares.Models.FileShareMediaTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>
    {
        public FileShareNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>
    {
        internal FileShareNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareNameUnavailableReason : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason left, Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason left, Azure.ResourceManager.FileShares.Models.FileShareNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSharePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>
    {
        public FileSharePatch() { }
        public Azure.ResourceManager.FileShares.Models.FileSharePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileSharePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileSharePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSharePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>
    {
        public FileSharePatchProperties() { }
        public Azure.ResourceManager.FileShares.Models.ShareRootSquash? NfsProtocolRootSquash { get { throw null; } set { } }
        public int? ProvisionedIOPerSec { get { throw null; } set { } }
        public int? ProvisionedStorageInGiB { get { throw null; } set { } }
        public int? ProvisionedThroughputMiBPerSec { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PublicAccessAllowedSubnets { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileSharePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileSharePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSharePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>
    {
        internal FileSharePrivateEndpointConnection() { }
        public Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSharePrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>
    {
        internal FileSharePrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSharePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSharePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSharePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>
    {
        internal FileSharePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileSharePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>
    {
        public FileShareProperties() { }
        public string HostName { get { throw null; } }
        public int? IncludedBurstIOPerSec { get { throw null; } }
        public long? MaxBurstIOPerSecCredits { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileShareMediaTier? MediaTier { get { throw null; } set { } }
        public string MountName { get { throw null; } set { } }
        public Azure.ResourceManager.FileShares.Models.ShareRootSquash? NfsProtocolRootSquash { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FileShares.Models.FileSharePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileShareProtocol? Protocol { get { throw null; } set { } }
        public int? ProvisionedIOPerSec { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisionedIOPerSecNextAllowedDowngradeOn { get { throw null; } }
        public int? ProvisionedStorageInGiB { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisionedStorageNextAllowedDowngradeOn { get { throw null; } }
        public int? ProvisionedThroughputMiBPerSec { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisionedThroughputNextAllowedDowngradeOn { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileShareProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicAccessAllowedSubnets { get { throw null; } }
        public Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel? Redundancy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareProtocol : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileShareProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareProtocol(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProtocol Nfs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileShareProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileShareProtocol left, Azure.ResourceManager.FileShares.Models.FileShareProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileShareProtocol left, Azure.ResourceManager.FileShares.Models.FileShareProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareProvisioningConstants : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>
    {
        internal FileShareProvisioningConstants() { }
        public int BaseIOPerSec { get { throw null; } }
        public int BaseThroughputMiBPerSec { get { throw null; } }
        public double ScalarIOPerSec { get { throw null; } }
        public double ScalarThroughputMiBPerSec { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningConstants>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProvisioningRecommendationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>
    {
        public FileShareProvisioningRecommendationContent(int? fileShareProvisioningRecommendationInputProvisionedStorageInGiB) { }
        public int? FileShareProvisioningRecommendationInputProvisionedStorageInGiB { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProvisioningRecommendationOutputProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>
    {
        internal FileShareProvisioningRecommendationOutputProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel> AvailableRedundancyOptions { get { throw null; } }
        public int ProvisionedIOPerSec { get { throw null; } }
        public int ProvisionedThroughputMiBPerSec { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProvisioningRecommendationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>
    {
        internal FileShareProvisioningRecommendationResult() { }
        public Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationOutputProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareProvisioningRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareProvisioningState : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileShareProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Patching { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Posting { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState TransientFailure { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileShareProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileShareProvisioningState left, Azure.ResourceManager.FileShares.Models.FileShareProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileShareProvisioningState left, Azure.ResourceManager.FileShares.Models.FileShareProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSharePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSharePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess left, Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess left, Azure.ResourceManager.FileShares.Models.FileSharePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareRedundancyLevel : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareRedundancyLevel(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel Local { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel left, Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel left, Azure.ResourceManager.FileShares.Models.FileShareRedundancyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareSnapshotPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>
    {
        public FileShareSnapshotPatch() { }
        public System.Collections.Generic.IDictionary<string, string> FileShareSnapshotUpdateMetadata { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareSnapshotProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>
    {
        public FileShareSnapshotProperties() { }
        public string InitiatorId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string SnapshotTime { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareSnapshotProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSharesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSharesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.FileShares.Models.FileSharesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareUsageDataResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>
    {
        internal FileShareUsageDataResult() { }
        public int? LiveSharesFileShareCount { get { throw null; } }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FileShares.Models.FileShareUsageDataResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareRootSquash : System.IEquatable<Azure.ResourceManager.FileShares.Models.ShareRootSquash>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareRootSquash(string value) { throw null; }
        public static Azure.ResourceManager.FileShares.Models.ShareRootSquash AllSquash { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.ShareRootSquash NoRootSquash { get { throw null; } }
        public static Azure.ResourceManager.FileShares.Models.ShareRootSquash RootSquash { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FileShares.Models.ShareRootSquash other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FileShares.Models.ShareRootSquash left, Azure.ResourceManager.FileShares.Models.ShareRootSquash right) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.ShareRootSquash (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.FileShares.Models.ShareRootSquash? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FileShares.Models.ShareRootSquash left, Azure.ResourceManager.FileShares.Models.ShareRootSquash right) { throw null; }
        public override string ToString() { throw null; }
    }
}
