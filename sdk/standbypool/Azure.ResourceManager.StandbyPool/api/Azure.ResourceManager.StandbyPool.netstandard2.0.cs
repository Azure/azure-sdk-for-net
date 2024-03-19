namespace Azure.ResourceManager.StandbyPool
{
    public partial class StandbyContainerGroupPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyContainerGroupPoolResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyContainerGroupPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> Update(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> UpdateAsync(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StandbyContainerGroupPoolResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>, System.Collections.IEnumerable
    {
        protected StandbyContainerGroupPoolResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string standbyContainerGroupPoolName, Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string standbyContainerGroupPoolName, Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> Get(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetAsync(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetIfExists(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetIfExistsAsync(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StandbyContainerGroupPoolResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>
    {
        public StandbyContainerGroupPoolResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class StandbyPoolExtensions
    {
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource GetStandbyContainerGroupPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetStandbyContainerGroupPoolResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceCollection GetStandbyContainerGroupPoolResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource GetStandbyVirtualMachinePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetStandbyVirtualMachinePoolResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceCollection GetStandbyVirtualMachinePoolResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource GetStandbyVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachinePoolResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> GetStandbyVirtualMachineResource(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetStandbyVirtualMachineResourceAsync(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceCollection GetStandbyVirtualMachineResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> Update(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> UpdateAsync(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachinePoolResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string standbyVirtualMachinePoolName, Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string standbyVirtualMachinePoolName, Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> Get(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetAsync(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetIfExists(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetIfExistsAsync(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>
    {
        public StandbyVirtualMachinePoolResourceData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public long? ElasticityMaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.VirtualMachineState? VirtualMachineState { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachineResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName, string standbyVirtualMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StandbyVirtualMachineResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachineResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> Get(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetAsync(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> GetIfExists(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetIfExistsAsync(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StandbyVirtualMachineResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>
    {
        public StandbyVirtualMachineResourceData() { }
        public Azure.ResourceManager.StandbyPool.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string VirtualMachineResourceId { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.StandbyPool.Mocking
{
    public partial class MockableStandbyPoolArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolArmClient() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource GetStandbyContainerGroupPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource GetStandbyVirtualMachinePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource GetStandbyVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStandbyPoolResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResource(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetStandbyContainerGroupPoolResourceAsync(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceCollection GetStandbyContainerGroupPoolResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResource(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetStandbyVirtualMachinePoolResourceAsync(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceCollection GetStandbyVirtualMachinePoolResources() { throw null; }
    }
    public partial class MockableStandbyPoolSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StandbyPool.Models
{
    public static partial class ArmStandbyPoolModelFactory
    {
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResourceData StandbyContainerGroupPoolResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile = null, Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties containerGroupProperties = null, Azure.ResourceManager.StandbyPool.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResourceData StandbyVirtualMachinePoolResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), long? elasticityMaxReadyCapacity = default(long?), Azure.ResourceManager.StandbyPool.Models.VirtualMachineState? virtualMachineState = default(Azure.ResourceManager.StandbyPool.Models.VirtualMachineState?), Azure.Core.ResourceIdentifier attachedVirtualMachineScaleSetId = null, Azure.ResourceManager.StandbyPool.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResourceData StandbyVirtualMachineResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string virtualMachineResourceId = null, Azure.ResourceManager.StandbyPool.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.ProvisioningState?)) { throw null; }
    }
    public partial class ContainerGroupProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>
    {
        public ContainerGroupProfile(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>
    {
        public ContainerGroupProfileUpdate() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>
    {
        public ContainerGroupProperties(Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile containerGroupProfile) { }
        public Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfile ContainerGroupProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SubnetIds { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerGroupPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>
    {
        public ContainerGroupPropertiesUpdate() { }
        public Azure.ResourceManager.StandbyPool.Models.ContainerGroupProfileUpdate ContainerGroupProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SubnetIds { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.ProvisioningState left, Azure.ResourceManager.StandbyPool.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.ProvisioningState left, Azure.ResourceManager.StandbyPool.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefillPolicy : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.RefillPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefillPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.RefillPolicy Always { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.RefillPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.RefillPolicy left, Azure.ResourceManager.StandbyPool.Models.RefillPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.RefillPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.RefillPolicy left, Azure.ResourceManager.StandbyPool.Models.RefillPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StandbyContainerGroupPoolElasticityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>
    {
        public StandbyContainerGroupPoolElasticityProfile(long maxReadyCapacity) { }
        public long MaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.RefillPolicy? RefillPolicy { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolElasticityProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>
    {
        public StandbyContainerGroupPoolElasticityProfileUpdate() { }
        public long? MaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.RefillPolicy? RefillPolicy { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>
    {
        public StandbyContainerGroupPoolResourcePatch() { }
        public Azure.ResourceManager.StandbyPool.Models.ContainerGroupPropertiesUpdate ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfileUpdate ElasticityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>
    {
        public StandbyVirtualMachinePoolResourcePatch() { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public long? ElasticityMaxReadyCapacity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.VirtualMachineState? VirtualMachineState { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.VirtualMachineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.VirtualMachineState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.VirtualMachineState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.VirtualMachineState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.VirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.VirtualMachineState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.VirtualMachineState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.VirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.VirtualMachineState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
