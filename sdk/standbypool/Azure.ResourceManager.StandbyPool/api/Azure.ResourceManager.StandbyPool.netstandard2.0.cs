namespace Azure.ResourceManager.StandbyPool
{
    public partial class StandbyContainerGroupPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>, System.Collections.IEnumerable
    {
        protected StandbyContainerGroupPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string standbyContainerGroupPoolName, Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string standbyContainerGroupPoolName, Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class StandbyContainerGroupPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>
    {
        public StandbyContainerGroupPoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyContainerGroupPoolResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyContainerGroupPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> GetStandbyContainerGroupPoolRuntimeViewResource(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetStandbyContainerGroupPoolRuntimeViewResourceAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceCollection GetStandbyContainerGroupPoolRuntimeViewResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> Update(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> UpdateAsync(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyContainerGroupPoolRuntimeViewResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyContainerGroupPoolName, string runtimeView) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>, System.Collections.IEnumerable
    {
        protected StandbyContainerGroupPoolRuntimeViewResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> Get(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> GetIfExists(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetIfExistsAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>
    {
        public StandbyContainerGroupPoolRuntimeViewResourceData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class StandbyPoolExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetStandbyContainerGroupPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource GetStandbyContainerGroupPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource GetStandbyContainerGroupPoolRuntimeViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolCollection GetStandbyContainerGroupPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetStandbyVirtualMachinePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource GetStandbyVirtualMachinePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource GetStandbyVirtualMachinePoolRuntimeViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolCollection GetStandbyVirtualMachinePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource GetStandbyVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class StandbyVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachineCollection() { }
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
    public partial class StandbyVirtualMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>
    {
        public StandbyVirtualMachineData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachinePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string standbyVirtualMachinePoolName, Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string standbyVirtualMachinePoolName, Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class StandbyVirtualMachinePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>
    {
        public StandbyVirtualMachinePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachinePoolResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> GetStandbyVirtualMachine(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetStandbyVirtualMachineAsync(string standbyVirtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> GetStandbyVirtualMachinePoolRuntimeViewResource(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetStandbyVirtualMachinePoolRuntimeViewResourceAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceCollection GetStandbyVirtualMachinePoolRuntimeViewResources() { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineCollection GetStandbyVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> Update(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> UpdateAsync(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachinePoolRuntimeViewResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName, string runtimeView) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachinePoolRuntimeViewResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> Get(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> GetIfExists(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetIfExistsAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>
    {
        public StandbyVirtualMachinePoolRuntimeViewResourceData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachineResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName, string standbyVirtualMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.StandbyPool.Mocking
{
    public partial class MockableStandbyPoolArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolArmClient() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource GetStandbyContainerGroupPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource GetStandbyContainerGroupPoolRuntimeViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource GetStandbyVirtualMachinePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource GetStandbyVirtualMachinePoolRuntimeViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachineResource GetStandbyVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStandbyPoolResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPool(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource>> GetStandbyContainerGroupPoolAsync(string standbyContainerGroupPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolCollection GetStandbyContainerGroupPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePool(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource>> GetStandbyVirtualMachinePoolAsync(string standbyVirtualMachinePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolCollection GetStandbyVirtualMachinePools() { throw null; }
    }
    public partial class MockableStandbyPoolSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStandbyPoolSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolResource> GetStandbyContainerGroupPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolResource> GetStandbyVirtualMachinePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StandbyPool.Models
{
    public static partial class ArmStandbyPoolModelFactory
    {
        public static Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary ContainerGroupInstanceCountSummary(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> instanceCountsByState = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount PoolResourceStateCount(string state = null, long count = (long)0) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData StandbyContainerGroupPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties StandbyContainerGroupPoolResourceProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile = null, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties containerGroupProperties = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResourceData StandbyContainerGroupPoolRuntimeViewResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties StandbyContainerGroupPoolRuntimeViewResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> instanceCountSummary = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData StandbyVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData StandbyVirtualMachinePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties StandbyVirtualMachinePoolResourceProperties(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile elasticityProfile = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState virtualMachineState = default(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState), Azure.Core.ResourceIdentifier attachedVirtualMachineScaleSetId = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResourceData StandbyVirtualMachinePoolRuntimeViewResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties StandbyVirtualMachinePoolRuntimeViewResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary> instanceCountSummary = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties StandbyVirtualMachineResourceProperties(string virtualMachineResourceId = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary VirtualMachineInstanceCountSummary(long? zone = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> instanceCountsByState = null) { throw null; }
    }
    public partial class ContainerGroupInstanceCountSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>
    {
        internal ContainerGroupInstanceCountSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> InstanceCountsByState { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolResourceStateCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>
    {
        internal PoolResourceStateCount() { }
        public long Count { get { throw null; } }
        public string State { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPatchProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>
    {
        public StandbyContainerGroupPatchProfile() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>
    {
        public StandbyContainerGroupPatchProperties() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProfile ContainerGroupProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SubnetIds { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolElasticityPatchProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>
    {
        public StandbyContainerGroupPoolElasticityPatchProfile() { }
        public long? MaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy? RefillPolicy { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolElasticityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>
    {
        public StandbyContainerGroupPoolElasticityProfile(long maxReadyCapacity) { }
        public long MaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy? RefillPolicy { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>
    {
        public StandbyContainerGroupPoolPatch() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>
    {
        public StandbyContainerGroupPoolResourceProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties containerGroupProperties) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>
    {
        public StandbyContainerGroupPoolResourceUpdateProperties() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPatchProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityPatchProfile ElasticityProfile { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>
    {
        public StandbyContainerGroupPoolRuntimeViewResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> instanceCountSummary) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>
    {
        public StandbyContainerGroupProfile(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>
    {
        public StandbyContainerGroupProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile containerGroupProfile) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile ContainerGroupProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SubnetIds { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyPoolProvisioningState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyPoolProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyPoolRefillPolicy : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyPoolRefillPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy Always { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolRefillPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StandbyVirtualMachinePoolElasticityPatchProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>
    {
        public StandbyVirtualMachinePoolElasticityPatchProfile() { }
        public long? MaxReadyCapacity { get { throw null; } set { } }
        public long? MinReadyCapacity { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolElasticityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>
    {
        public StandbyVirtualMachinePoolElasticityProfile(long maxReadyCapacity) { }
        public long MaxReadyCapacity { get { throw null; } set { } }
        public long? MinReadyCapacity { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>
    {
        public StandbyVirtualMachinePoolPatch() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>
    {
        public StandbyVirtualMachinePoolResourceProperties(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState virtualMachineState) { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState VirtualMachineState { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>
    {
        public StandbyVirtualMachinePoolResourceUpdateProperties() { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityPatchProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState? VirtualMachineState { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>
    {
        public StandbyVirtualMachinePoolRuntimeViewResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary> instanceCountSummary) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachineResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>
    {
        public StandbyVirtualMachineResourceProperties(string virtualMachineResourceId) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolProvisioningState? ProvisioningState { get { throw null; } }
        public string VirtualMachineResourceId { get { throw null; } set { } }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyVirtualMachineState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyVirtualMachineState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineInstanceCountSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>
    {
        internal VirtualMachineInstanceCountSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> InstanceCountsByState { get { throw null; } }
        public long? Zone { get { throw null; } }
        Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.VirtualMachineInstanceCountSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
