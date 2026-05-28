namespace Azure.ResourceManager.ScVmm
{
    public partial class AzureResourceManagerScVmmContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerScVmmContext() { }
        public static Azure.ResourceManager.ScVmm.AzureResourceManagerScVmmContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ScVmmAvailabilitySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>, System.Collections.IEnumerable
    {
        protected ScVmmAvailabilitySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilitySetResourceName, Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilitySetResourceName, Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> Get(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> GetAsync(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetIfExists(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> GetIfExistsAsync(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmAvailabilitySetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>
    {
        public ScVmmAvailabilitySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation) { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmmServerId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmAvailabilitySetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmAvailabilitySetResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmCloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmCloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmCloudResource>, System.Collections.IEnumerable
    {
        protected ScVmmCloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmCloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudResourceName, Azure.ResourceManager.ScVmm.ScVmmCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudResourceName, Azure.ResourceManager.ScVmm.ScVmmCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> Get(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> GetAsync(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetIfExists(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> GetIfExistsAsync(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmCloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmCloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmCloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmCloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmCloudData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>
    {
        public ScVmmCloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity CloudCapacity { get { throw null; } }
        public string CloudName { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy> StorageQosPolicies { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmmServerId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmCloudResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmCloudResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmCloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmCloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ScVmmExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> GetScVmmAvailabilitySetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource GetScVmmAvailabilitySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetCollection GetScVmmAvailabilitySets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> GetScVmmCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmCloudResource GetScVmmCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmCloudCollection GetScVmmClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource GetScVmmGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataResource GetScVmmHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource GetScVmmInventoryItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> GetScVmmServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmServerResource GetScVmmServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmServerCollection GetScVmmServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource GetScVmmVirtualMachineInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource GetScVmmVirtualMachineInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> GetScVmmVirtualMachineTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource GetScVmmVirtualMachineTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateCollection GetScVmmVirtualMachineTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> GetScVmmVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource GetScVmmVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkCollection GetScVmmVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmGuestAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>
    {
        public ScVmmGuestAgentData() { }
        public Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential Credentials { get { throw null; } set { } }
        public string CustomResourceName { get { throw null; } }
        public string HttpsProxy { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmGuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmGuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmGuestAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmGuestAgentResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmGuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmGuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmGuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmGuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmHybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>
    {
        public ScVmmHybridIdentityMetadataData() { }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmHybridIdentityMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmHybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmInventoryItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>, System.Collections.IEnumerable
    {
        protected ScVmmInventoryItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inventoryItemResourceName, Azure.ResourceManager.ScVmm.ScVmmInventoryItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inventoryItemResourceName, Azure.ResourceManager.ScVmm.ScVmmInventoryItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> Get(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> GetAsync(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> GetIfExists(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> GetIfExistsAsync(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmInventoryItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>
    {
        public ScVmmInventoryItemData(Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties properties) { }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmInventoryItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmInventoryItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmInventoryItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmInventoryItemResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmInventoryItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmmServerName, string inventoryItemResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmInventoryItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmInventoryItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmInventoryItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmInventoryItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmInventoryItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmServerResource>, System.Collections.IEnumerable
    {
        protected ScVmmServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmmServerName, Azure.ResourceManager.ScVmm.ScVmmServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmmServerName, Azure.ResourceManager.ScVmm.ScVmmServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> Get(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> GetAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetIfExists(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmServerResource>> GetIfExistsAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>
    {
        public ScVmmServerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, string fqdn) { }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.VmmCredential Credentials { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmServerResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmmServerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource> GetScVmmInventoryItem(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource>> GetScVmmInventoryItemAsync(string inventoryItemResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmInventoryItemCollection GetScVmmInventoryItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmVirtualMachineInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>
    {
        public ScVmmVirtualMachineInstanceData(Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile InfrastructureProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance OSProfile { get { throw null; } set { } }
        public string PowerState { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk> StorageDisks { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualMachineInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmVirtualMachineInstanceResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), Azure.ResourceManager.ScVmm.Models.DeleteFromHost? deleteFromHost = default(Azure.ResourceManager.ScVmm.Models.DeleteFromHost?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), Azure.ResourceManager.ScVmm.Models.DeleteFromHost? deleteFromHost = default(Azure.ResourceManager.ScVmm.Models.DeleteFromHost?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource GetScVmmGuestAgent() { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataResource GetScVmmHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmVirtualMachineTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>, System.Collections.IEnumerable
    {
        protected ScVmmVirtualMachineTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineTemplateName, Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineTemplateName, Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> Get(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> GetAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetIfExists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> GetIfExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmVirtualMachineTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>
    {
        public ScVmmVirtualMachineTemplateData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation) { }
        public string ComputerName { get { throw null; } }
        public int? CpuCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk> Disks { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } }
        public int? DynamicMemoryMaxMB { get { throw null; } }
        public int? DynamicMemoryMinMB { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public int? Generation { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.IsCustomizable? IsCustomizable { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable? IsHighlyAvailable { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } }
        public int? MemoryMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface> NetworkInterfaces { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmOSType? OSType { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmmServerId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualMachineTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmVirtualMachineTemplateResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScVmmVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected ScVmmVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScVmmVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>
    {
        public ScVmmVirtualNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmmServerId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScVmmVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion? force = default(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ScVmm.Mocking
{
    public partial class MockableScVmmArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableScVmmArmClient() { }
        public virtual Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource GetScVmmAvailabilitySetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmCloudResource GetScVmmCloudResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmGuestAgentResource GetScVmmGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataResource GetScVmmHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmInventoryItemResource GetScVmmInventoryItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmServerResource GetScVmmServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource GetScVmmVirtualMachineInstance(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceResource GetScVmmVirtualMachineInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource GetScVmmVirtualMachineTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource GetScVmmVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableScVmmResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableScVmmResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySet(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource>> GetScVmmAvailabilitySetAsync(string availabilitySetResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetCollection GetScVmmAvailabilitySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmCloud(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmCloudResource>> GetScVmmCloudAsync(string cloudResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmCloudCollection GetScVmmClouds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServer(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmServerResource>> GetScVmmServerAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmServerCollection GetScVmmServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplate(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource>> GetScVmmVirtualMachineTemplateAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateCollection GetScVmmVirtualMachineTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetwork(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource>> GetScVmmVirtualNetworkAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkCollection GetScVmmVirtualNetworks() { throw null; }
    }
    public partial class MockableScVmmSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableScVmmSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetResource> GetScVmmAvailabilitySetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmClouds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmCloudResource> GetScVmmCloudsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmServerResource> GetScVmmServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateResource> GetScVmmVirtualMachineTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkResource> GetScVmmVirtualNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ScVmm.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationMethod : System.IEquatable<Azure.ResourceManager.ScVmm.Models.AllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.AllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.AllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.AllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.AllocationMethod left, Azure.ResourceManager.ScVmm.Models.AllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.AllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.AllocationMethod left, Azure.ResourceManager.ScVmm.Models.AllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmScVmmModelFactory
    {
        public static Azure.ResourceManager.ScVmm.Models.CloudInventoryItem CloudInventoryItem(string managedResourceId = null, string uuid = null, string inventoryItemName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance OSProfileForVmInstance(string adminPassword = null, string computerName = null, Azure.ResourceManager.ScVmm.Models.ScVmmOSType? osType = default(Azure.ResourceManager.ScVmm.Models.ScVmmOSType?), string osSku = null, string osVersion = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmAvailabilitySetData ScVmmAvailabilitySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string availabilitySetName = null, Azure.Core.ResourceIdentifier vmmServerId = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity ScVmmCloudCapacity(long? cpuCount = default(long?), long? memoryMB = default(long?), long? vmCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmCloudData ScVmmCloudData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string inventoryItemId = null, string uuid = null, Azure.Core.ResourceIdentifier vmmServerId = null, string cloudName = null, Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity cloudCapacity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy> storageQosPolicies = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmGuestAgentData ScVmmGuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string uuid = null, Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential credentials = null, string httpsProxy = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction? provisioningAction = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction?), string status = null, string customResourceName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile ScVmmHardwareProfile(int? memoryMB = default(int?), int? cpuCount = default(int?), Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration? limitCpuForMigration = default(Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration?), Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled? dynamicMemoryEnabled = default(Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled?), int? dynamicMemoryMaxMB = default(int?), int? dynamicMemoryMinMB = default(int?), Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable? isHighlyAvailable = default(Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmHybridIdentityMetadataData ScVmmHybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile ScVmmInfrastructureProfile(string inventoryItemId = null, Azure.Core.ResourceIdentifier vmmServerId = null, Azure.Core.ResourceIdentifier cloudId = null, Azure.Core.ResourceIdentifier templateId = null, string vmName = null, string uuid = null, Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint lastRestoredVmCheckpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint> checkpoints = null, string checkpointType = null, int? generation = default(int?), string biosGuid = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmInventoryItemData ScVmmInventoryItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties properties = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties ScVmmInventoryItemProperties(string inventoryType = null, string managedResourceId = null, string uuid = null, string inventoryItemName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface ScVmmNetworkInterface(string name = null, string displayName = null, System.Collections.Generic.IEnumerable<string> ipv4Addresses = null, System.Collections.Generic.IEnumerable<string> ipv6Addresses = null, string macAddress = null, Azure.Core.ResourceIdentifier virtualNetworkId = null, string networkName = null, Azure.ResourceManager.ScVmm.Models.AllocationMethod? ipv4AddressType = default(Azure.ResourceManager.ScVmm.Models.AllocationMethod?), Azure.ResourceManager.ScVmm.Models.AllocationMethod? ipv6AddressType = default(Azure.ResourceManager.ScVmm.Models.AllocationMethod?), Azure.ResourceManager.ScVmm.Models.AllocationMethod? macAddressType = default(Azure.ResourceManager.ScVmm.Models.AllocationMethod?), string nicId = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmServerData ScVmmServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.ScVmm.Models.VmmCredential credentials = null, string fqdn = null, int? port = default(int?), string connectionStatus = null, string errorMessage = null, string uuid = null, string version = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy ScVmmStorageQosPolicy(string name = null, string id = null, long? iopsMaximum = default(long?), long? iopsMinimum = default(long?), long? bandwidthLimit = default(long?), string policyId = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk ScVmmVirtualDisk(string name = null, string displayName = null, string diskId = null, int? diskSizeGB = default(int?), int? maxDiskSizeGB = default(int?), int? bus = default(int?), int? lun = default(int?), string busType = null, string vhdType = null, string volumeType = null, string vhdFormatType = null, string templateDiskId = null, Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails storageQosPolicy = null, Azure.ResourceManager.ScVmm.Models.CreateDiffDisk? createDiffDisk = default(Azure.ResourceManager.ScVmm.Models.CreateDiffDisk?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineInstanceData ScVmmVirtualMachineInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem> availabilitySets = null, Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance osProfile = null, Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile hardwareProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface> networkInterfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk> storageDisks = null, Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile infrastructureProfile = null, string powerState = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualMachineTemplateData ScVmmVirtualMachineTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string inventoryItemId = null, string uuid = null, Azure.Core.ResourceIdentifier vmmServerId = null, Azure.ResourceManager.ScVmm.Models.ScVmmOSType? osType = default(Azure.ResourceManager.ScVmm.Models.ScVmmOSType?), string osName = null, string computerName = null, int? memoryMB = default(int?), int? cpuCount = default(int?), Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration? limitCpuForMigration = default(Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration?), Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled? dynamicMemoryEnabled = default(Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled?), Azure.ResourceManager.ScVmm.Models.IsCustomizable? isCustomizable = default(Azure.ResourceManager.ScVmm.Models.IsCustomizable?), int? dynamicMemoryMaxMB = default(int?), int? dynamicMemoryMinMB = default(int?), Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable? isHighlyAvailable = default(Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable?), int? generation = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface> networkInterfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk> disks = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.ScVmmVirtualNetworkData ScVmmVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string inventoryItemId = null, string uuid = null, Azure.Core.ResourceIdentifier vmmServerId = null, string networkName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem VirtualMachineInventoryItem(string managedResourceId = null, string uuid = null, string inventoryItemName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?), Azure.ResourceManager.ScVmm.Models.ScVmmOSType? osType = default(Azure.ResourceManager.ScVmm.Models.ScVmmOSType?), string osName = null, string osVersion = null, string powerState = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails cloud = null, string biosGuid = null, Azure.Core.ResourceIdentifier managedMachineResourceId = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem VirtualMachineTemplateInventoryItem(string managedResourceId = null, string uuid = null, string inventoryItemName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?), int? cpuCount = default(int?), int? memoryMB = default(int?), Azure.ResourceManager.ScVmm.Models.ScVmmOSType? osType = default(Azure.ResourceManager.ScVmm.Models.ScVmmOSType?), string osName = null) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem VirtualNetworkInventoryItem(string managedResourceId = null, string uuid = null, string inventoryItemName = null, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? provisioningState = default(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState?)) { throw null; }
    }
    public partial class CloudInventoryItem : Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>
    {
        public CloudInventoryItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.CloudInventoryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.CloudInventoryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.CloudInventoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateDiffDisk : System.IEquatable<Azure.ResourceManager.ScVmm.Models.CreateDiffDisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateDiffDisk(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.CreateDiffDisk False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.CreateDiffDisk True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.CreateDiffDisk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.CreateDiffDisk left, Azure.ResourceManager.ScVmm.Models.CreateDiffDisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.CreateDiffDisk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.CreateDiffDisk left, Azure.ResourceManager.ScVmm.Models.CreateDiffDisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteFromHost : System.IEquatable<Azure.ResourceManager.ScVmm.Models.DeleteFromHost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteFromHost(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.DeleteFromHost False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.DeleteFromHost True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.DeleteFromHost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.DeleteFromHost left, Azure.ResourceManager.ScVmm.Models.DeleteFromHost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.DeleteFromHost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.DeleteFromHost left, Azure.ResourceManager.ScVmm.Models.DeleteFromHost right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicMemoryEnabled : System.IEquatable<Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicMemoryEnabled(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled left, Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled left, Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsCustomizable : System.IEquatable<Azure.ResourceManager.ScVmm.Models.IsCustomizable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsCustomizable(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.IsCustomizable False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.IsCustomizable True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.IsCustomizable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.IsCustomizable left, Azure.ResourceManager.ScVmm.Models.IsCustomizable right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.IsCustomizable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.IsCustomizable left, Azure.ResourceManager.ScVmm.Models.IsCustomizable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsHighlyAvailable : System.IEquatable<Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsHighlyAvailable(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable left, Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable left, Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LimitCpuForMigration : System.IEquatable<Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LimitCpuForMigration(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration left, Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration left, Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSProfileForVmInstance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>
    {
        public OSProfileForVmInstance() { }
        public string AdminPassword { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string OSSku { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmOSType? OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.OSProfileForVmInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmAvailabilitySetItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>
    {
        public ScVmmAvailabilitySetItem() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmCheckpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>
    {
        public ScVmmCheckpoint() { }
        public string CheckpointId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ParentCheckpointId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmCloudCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>
    {
        internal ScVmmCloudCapacity() { }
        public long? CpuCount { get { throw null; } }
        public long? MemoryMB { get { throw null; } }
        public long? VmCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmCloudCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScVmmForceDeletion : System.IEquatable<Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScVmmForceDeletion(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion left, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion left, Azure.ResourceManager.ScVmm.Models.ScVmmForceDeletion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScVmmGuestCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>
    {
        public ScVmmGuestCredential(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmGuestCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>
    {
        public ScVmmHardwareProfile() { }
        public int? CpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } set { } }
        public int? DynamicMemoryMaxMB { get { throw null; } set { } }
        public int? DynamicMemoryMinMB { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.IsHighlyAvailable? IsHighlyAvailable { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } set { } }
        public int? MemoryMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmHardwareProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>
    {
        public ScVmmHardwareProfileUpdate() { }
        public int? CpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } set { } }
        public int? DynamicMemoryMaxMB { get { throw null; } set { } }
        public int? DynamicMemoryMinMB { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } set { } }
        public int? MemoryMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmInfrastructureProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>
    {
        public ScVmmInfrastructureProfile() { }
        public string BiosGuid { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint> Checkpoints { get { throw null; } }
        public string CheckpointType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudId { get { throw null; } set { } }
        public int? Generation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmCheckpoint LastRestoredVmCheckpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier TemplateId { get { throw null; } set { } }
        public string Uuid { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmmServerId { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInfrastructureProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmInventoryItemDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>
    {
        public ScVmmInventoryItemDetails() { }
        public string InventoryItemId { get { throw null; } set { } }
        public string InventoryItemName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ScVmmInventoryItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>
    {
        protected ScVmmInventoryItemProperties() { }
        public string InventoryItemName { get { throw null; } }
        public string ManagedResourceId { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState? ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>
    {
        public ScVmmNetworkInterface() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv4Addresses { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? IPv4AddressType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6Addresses { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? IPv6AddressType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? MacAddressType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmNetworkInterfaceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>
    {
        public ScVmmNetworkInterfaceUpdate() { }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? IPv4AddressType { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? IPv6AddressType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.AllocationMethod? MacAddressType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NicId { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScVmmOSType : System.IEquatable<Azure.ResourceManager.ScVmm.Models.ScVmmOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScVmmOSType(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmOSType Other { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.ScVmmOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.ScVmmOSType left, Azure.ResourceManager.ScVmm.Models.ScVmmOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.ScVmmOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.ScVmmOSType left, Azure.ResourceManager.ScVmm.Models.ScVmmOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScVmmProvisioningAction : System.IEquatable<Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScVmmProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction left, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction left, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScVmmProvisioningState : System.IEquatable<Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScVmmProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState left, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState left, Azure.ResourceManager.ScVmm.Models.ScVmmProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScVmmResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>
    {
        public ScVmmResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmStorageQosPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>
    {
        internal ScVmmStorageQosPolicy() { }
        public long? BandwidthLimit { get { throw null; } }
        public string Id { get { throw null; } }
        public long? IopsMaximum { get { throw null; } }
        public long? IopsMinimum { get { throw null; } }
        public string Name { get { throw null; } }
        public string PolicyId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmStorageQosPolicyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>
    {
        public ScVmmStorageQosPolicyDetails() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>
    {
        public ScVmmVirtualDisk() { }
        public int? Bus { get { throw null; } set { } }
        public string BusType { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.CreateDiffDisk? CreateDiffDisk { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public int? Lun { get { throw null; } set { } }
        public int? MaxDiskSizeGB { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails StorageQosPolicy { get { throw null; } set { } }
        public string TemplateDiskId { get { throw null; } set { } }
        public string VhdFormatType { get { throw null; } }
        public string VhdType { get { throw null; } set { } }
        public string VolumeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualDiskUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>
    {
        public ScVmmVirtualDiskUpdate() { }
        public int? Bus { get { throw null; } set { } }
        public string BusType { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmStorageQosPolicyDetails StorageQosPolicy { get { throw null; } set { } }
        public string VhdType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScVmmVirtualMachineInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>
    {
        public ScVmmVirtualMachineInstancePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmAvailabilitySetItem> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmHardwareProfileUpdate HardwareProfile { get { throw null; } set { } }
        public string InfrastructureCheckpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmNetworkInterfaceUpdate> NetworkInterfaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualDiskUpdate> StorageDisks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.ScVmmVirtualMachineInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkipShutdown : System.IEquatable<Azure.ResourceManager.ScVmm.Models.SkipShutdown>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkipShutdown(string value) { throw null; }
        public static Azure.ResourceManager.ScVmm.Models.SkipShutdown False { get { throw null; } }
        public static Azure.ResourceManager.ScVmm.Models.SkipShutdown True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScVmm.Models.SkipShutdown other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScVmm.Models.SkipShutdown left, Azure.ResourceManager.ScVmm.Models.SkipShutdown right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScVmm.Models.SkipShutdown (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScVmm.Models.SkipShutdown left, Azure.ResourceManager.ScVmm.Models.SkipShutdown right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopVirtualMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>
    {
        public StopVirtualMachineContent() { }
        public Azure.ResourceManager.ScVmm.Models.SkipShutdown? SkipShutdown { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.StopVirtualMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCreateCheckpointContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>
    {
        public VirtualMachineCreateCheckpointContent() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineCreateCheckpointContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineDeleteCheckpointContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>
    {
        public VirtualMachineDeleteCheckpointContent() { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineDeleteCheckpointContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInventoryItem : Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>
    {
        public VirtualMachineInventoryItem() { }
        public string BiosGuid { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemDetails Cloud { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedMachineResourceId { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmOSType? OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string PowerState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineInventoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRestoreCheckpointContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>
    {
        public VirtualMachineRestoreCheckpointContent() { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineRestoreCheckpointContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineTemplateInventoryItem : Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>
    {
        public VirtualMachineTemplateInventoryItem() { }
        public int? CpuCount { get { throw null; } }
        public int? MemoryMB { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.ScVmm.Models.ScVmmOSType? OSType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualMachineTemplateInventoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkInventoryItem : Azure.ResourceManager.ScVmm.Models.ScVmmInventoryItemProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>
    {
        public VirtualNetworkInventoryItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VirtualNetworkInventoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>
    {
        public VmmCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VmmCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ScVmm.Models.VmmCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ScVmm.Models.VmmCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
