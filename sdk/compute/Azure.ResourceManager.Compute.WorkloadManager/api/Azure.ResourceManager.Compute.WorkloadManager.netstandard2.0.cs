namespace Azure.ResourceManager.Compute.WorkloadManager
{
    public partial class AzureResourceManagerComputeWorkloadManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeWorkloadManagerContext() { }
        public static Azure.ResourceManager.Compute.WorkloadManager.AzureResourceManagerComputeWorkloadManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CapabilityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>, System.Collections.IEnumerable
    {
        protected CapabilityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Compute.WorkloadManager.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Compute.WorkloadManager.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> Get(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> GetAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> GetIfExists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> GetIfExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapabilityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>
    {
        public CapabilityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.CapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.CapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapabilityResource() { }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.CapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spaceName, string capabilityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.CapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.CapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.CapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ComputeWorkloadManagerExtensions
    {
        public static Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource GetCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource GetRuntimeBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource GetRuntimeLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> GetWorkloadSpaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource GetWorkloadSpaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceCollection GetWorkloadSpaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RuntimeBindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>, System.Collections.IEnumerable
    {
        protected RuntimeBindingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bindingName, Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bindingName, Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> Get(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> GetAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> GetIfExists(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> GetIfExistsAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RuntimeBindingData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>
    {
        public RuntimeBindingData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeBindingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RuntimeBindingResource() { }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spaceName, string bindingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RuntimeLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>, System.Collections.IEnumerable
    {
        protected RuntimeLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkName, Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkName, Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> Get(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> GetAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> GetIfExists(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> GetIfExistsAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RuntimeLinkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>
    {
        public RuntimeLinkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RuntimeLinkResource() { }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spaceName, string linkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadSpaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>, System.Collections.IEnumerable
    {
        protected WorkloadSpaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string spaceName, Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string spaceName, Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> Get(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> GetAsync(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetIfExists(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> GetIfExistsAsync(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadSpaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>
    {
        public WorkloadSpaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? WorkloadSpaceProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSpaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadSpaceResource() { }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.CapabilityCollection GetCapabilities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource> GetCapability(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource>> GetCapabilityAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource> GetRuntimeBinding(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource>> GetRuntimeBindingAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingCollection GetRuntimeBindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource> GetRuntimeLink(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource>> GetRuntimeLinkAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkCollection GetRuntimeLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.WorkloadManager.Mocking
{
    public partial class MockableComputeWorkloadManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeWorkloadManagerArmClient() { }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.CapabilityResource GetCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingResource GetRuntimeBindingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkResource GetRuntimeLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource GetWorkloadSpaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeWorkloadManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeWorkloadManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpace(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource>> GetWorkloadSpaceAsync(string spaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceCollection GetWorkloadSpaces() { throw null; }
    }
    public partial class MockableComputeWorkloadManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeWorkloadManagerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceResource> GetWorkloadSpacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.WorkloadManager.Models
{
    public static partial class ArmComputeWorkloadManagerModelFactory
    {
        public static Azure.ResourceManager.Compute.WorkloadManager.CapabilityData CapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties properties = null, Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind? kind = default(Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch CapabilityPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy? capabilityUpdateVersionPolicy = default(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties CapabilityProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy versionPolicy = default(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy), string effectiveVersion = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile CapacityProfile(int minimumNodes = 0, int maximumNodes = 0) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate CapacityProfileUpdate(int? minimumNodes = default(int?), int? maximumNodes = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity ExecutionIdentity(string provisioningMode = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope scope = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties ManagedRuntimeBindingProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?), Azure.Core.ResourceIdentifier providerResourceId = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity executionIdentity = null, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile networkProfile = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile managedProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile ManagedRuntimeProfile(string offering = null, string provider = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity ReferencedExecutionIdentity(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope scope = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope), Azure.Core.ResourceIdentifier userAssignedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties ReferencedRuntimeBindingProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?), Azure.Core.ResourceIdentifier providerResourceId = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity executionIdentity = null, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile networkProfile = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.RuntimeBindingData RuntimeBindingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties properties = null, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind? kind = default(Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch RuntimeBindingPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties RuntimeBindingProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?), Azure.Core.ResourceIdentifier providerResourceId = null, string provisioningMode = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity executionIdentity = null, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile networkProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties RuntimeBindingUpdateProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope? executionIdentityScope = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope?), Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile networkProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.RuntimeLinkData RuntimeLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch RuntimeLinkPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate runtimeLinkUpdateCapacityProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties RuntimeLinkProperties(Azure.Core.ResourceIdentifier orchestratorBindingResourceId = null, Azure.Core.ResourceIdentifier executionBindingResourceId = null, Azure.Core.ResourceIdentifier integrationManagedIdentityResourceId = null, Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile capacityProfile = null, Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?), Azure.Core.ResourceIdentifier providerResourceId = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile RuntimeNetworkProfile(Azure.Core.ResourceIdentifier subnetResourceId = null, Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode? egressMode = default(Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity ServiceManagedExecutionIdentity(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope scope = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope), Azure.Core.ResourceIdentifier userAssignedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.WorkloadSpaceData WorkloadSpaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? workloadSpaceProvisioningState = default(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch WorkloadSpacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityKind : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityKind(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind AgentSandbox { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind left, Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind left, Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapabilityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>
    {
        public CapabilityPatch() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy? CapabilityUpdateVersionPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>
    {
        public CapabilityProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy versionPolicy) { }
        public string EffectiveVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy VersionPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>
    {
        public CapacityProfile(int minimumNodes, int maximumNodes) { }
        public int MaximumNodes { get { throw null; } set { } }
        public int MinimumNodes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>
    {
        public CapacityProfileUpdate() { }
        public int? MaximumNodes { get { throw null; } set { } }
        public int? MinimumNodes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressMode : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode CustomerManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode left, Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode left, Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ExecutionIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>
    {
        internal ExecutionIdentity() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionIdentityScope : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionIdentityScope(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope SandboxGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope left, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope left, Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedRuntimeBindingProperties : Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>
    {
        public ManagedRuntimeBindingProperties(Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile managedProfile) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile ManagedProfile { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeBindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuntimeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>
    {
        public ManagedRuntimeProfile() { }
        public string Offering { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ManagedRuntimeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState left, Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState left, Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReferencedExecutionIdentity : Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>
    {
        public ReferencedExecutionIdentity(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope scope, Azure.Core.ResourceIdentifier userAssignedIdentityResourceId) { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedExecutionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReferencedRuntimeBindingProperties : Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>
    {
        public ReferencedRuntimeBindingProperties(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ReferencedRuntimeBindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuntimeBindingKind : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuntimeBindingKind(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind ServerlessContainers { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind left, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind left, Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeBindingPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>
    {
        public RuntimeBindingPatch() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RuntimeBindingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>
    {
        internal RuntimeBindingProperties() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity ExecutionIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProviderResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeBindingUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>
    {
        public RuntimeBindingUpdateProperties() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope? ExecutionIdentityScope { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile NetworkProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeBindingUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeLinkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>
    {
        public RuntimeLinkPatch() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfileUpdate RuntimeLinkUpdateCapacityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeLinkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>
    {
        public RuntimeLinkProperties(Azure.Core.ResourceIdentifier orchestratorBindingResourceId) { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.CapacityProfile CapacityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExecutionBindingResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IntegrationManagedIdentityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OrchestratorBindingResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProviderResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeLinkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>
    {
        public RuntimeNetworkProfile() { }
        public Azure.ResourceManager.Compute.WorkloadManager.Models.EgressMode? EgressMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.RuntimeNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedExecutionIdentity : Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>
    {
        public ServiceManagedExecutionIdentity(Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentityScope scope) { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Compute.WorkloadManager.Models.ExecutionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.ServiceManagedExecutionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VersionPolicy : System.IEquatable<Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VersionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy ServiceManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy left, Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy left, Azure.ResourceManager.Compute.WorkloadManager.Models.VersionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadSpacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>
    {
        public WorkloadSpacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.WorkloadManager.Models.WorkloadSpacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
