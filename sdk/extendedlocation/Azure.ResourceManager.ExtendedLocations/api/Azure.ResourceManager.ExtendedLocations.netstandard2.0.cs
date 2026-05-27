namespace Azure.ResourceManager.ExtendedLocations
{
    public partial class AzureResourceManagerExtendedLocationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerExtendedLocationsContext() { }
        public static Azure.ResourceManager.ExtendedLocations.AzureResourceManagerExtendedLocationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CustomLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>, System.Collections.IEnumerable
    {
        protected CustomLocationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ExtendedLocations.CustomLocationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ExtendedLocations.CustomLocationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomLocationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>
    {
        public CustomLocationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ClusterExtensionIds { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType? HostType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.CustomLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.CustomLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomLocationResource() { }
        public virtual Azure.ResourceManager.ExtendedLocations.CustomLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult> FindTargetResourceGroup(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties customLocationFindTargetResourceGroupProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>> FindTargetResourceGroupAsync(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties customLocationFindTargetResourceGroupProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType> GetEnabledResourceTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType> GetEnabledResourceTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> GetResourceSyncRule(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> GetResourceSyncRuleAsync(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleCollection GetResourceSyncRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ExtendedLocations.CustomLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.CustomLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.CustomLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> Update(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> UpdateAsync(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ExtendedLocationsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> GetCustomLocationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.CustomLocationResource GetCustomLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.CustomLocationCollection GetCustomLocations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource GetResourceSyncRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ResourceSyncRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>, System.Collections.IEnumerable
    {
        protected ResourceSyncRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string childResourceName, Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string childResourceName, Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> Get(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> GetAsync(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> GetIfExists(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> GetIfExistsAsync(string childResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceSyncRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>
    {
        public ResourceSyncRuleData(Azure.Core.AzureLocation location) { }
        public int? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector Selector { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSyncRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceSyncRuleResource() { }
        public virtual Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string childResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ExtendedLocations.Mocking
{
    public partial class MockableExtendedLocationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableExtendedLocationsArmClient() { }
        public virtual Azure.ResourceManager.ExtendedLocations.CustomLocationResource GetCustomLocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleResource GetResourceSyncRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableExtendedLocationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableExtendedLocationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocation(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocations.CustomLocationResource>> GetCustomLocationAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ExtendedLocations.CustomLocationCollection GetCustomLocations() { throw null; }
    }
    public partial class MockableExtendedLocationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableExtendedLocationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.CustomLocationResource> GetCustomLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableExtendedLocationsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableExtendedLocationsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ExtendedLocations.Models
{
    public static partial class ArmExtendedLocationsModelFactory
    {
        public static Azure.ResourceManager.ExtendedLocations.CustomLocationData CustomLocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication authentication = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> clusterExtensionIds = null, string displayName = null, Azure.Core.ResourceIdentifier hostResourceId = null, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType? hostType = default(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType?), string @namespace = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType CustomLocationEnabledResourceType(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier clusterExtensionId = null, string extensionType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata> typesMetadata = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties CustomLocationFindTargetResourceGroupProperties(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult CustomLocationFindTargetResourceGroupResult(string matchedResourceSyncRule = null, string targetResourceGroup = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo CustomLocationOperationInfo(string description = null, string operation = null, string provider = null, string resource = null, bool? isDataAction = default(bool?), string name = null, string origin = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch CustomLocationPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication authentication = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> clusterExtensionIds = null, string displayName = null, Azure.Core.ResourceIdentifier hostResourceId = null, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType? hostType = default(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType?), string @namespace = null, string provisioningState = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.ResourceSyncRuleData ResourceSyncRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? priority = default(int?), string provisioningState = null, Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector selector = null, string targetResourceGroup = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression ResourceSyncRuleMatchExpression(string key = null, string @operator = null, System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch ResourceSyncRulePatch(int? priority = default(int?), string provisioningState = null, Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector selector = null, string targetResourceGroup = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector ResourceSyncRulePropertiesSelector(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression> matchExpressions = null, System.Collections.Generic.IDictionary<string, string> matchLabels = null) { throw null; }
    }
    public partial class CustomLocationAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>
    {
        public CustomLocationAuthentication() { }
        public string CustomLocationPropertiesAuthenticationType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationEnabledResourceType : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>
    {
        public CustomLocationEnabledResourceType() { }
        public Azure.Core.ResourceIdentifier ClusterExtensionId { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata> TypesMetadata { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationEnabledResourceTypeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>
    {
        public CustomLocationEnabledResourceTypeMetadata() { }
        public string ApiVersion { get { throw null; } set { } }
        public string ResourceProviderNamespace { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationEnabledResourceTypeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationFindTargetResourceGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>
    {
        public CustomLocationFindTargetResourceGroupProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationFindTargetResourceGroupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>
    {
        internal CustomLocationFindTargetResourceGroupResult() { }
        public string MatchedResourceSyncRule { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationFindTargetResourceGroupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomLocationHostType : System.IEquatable<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomLocationHostType(string value) { throw null; }
        public static Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType Kubernetes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType left, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType left, Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomLocationOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>
    {
        internal CustomLocationOperationInfo() { }
        public string Description { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLocationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>
    {
        public CustomLocationPatch() { }
        public Azure.ResourceManager.ExtendedLocations.Models.CustomLocationAuthentication Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ClusterExtensionIds { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ExtendedLocations.Models.CustomLocationHostType? HostType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.CustomLocationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSyncRuleMatchExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>
    {
        public ResourceSyncRuleMatchExpression() { }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSyncRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>
    {
        public ResourceSyncRulePatch() { }
        public int? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector Selector { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSyncRulePropertiesSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>
    {
        public ResourceSyncRulePropertiesSelector() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRuleMatchExpression> MatchExpressions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> MatchLabels { get { throw null; } }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ExtendedLocations.Models.ResourceSyncRulePropertiesSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
