namespace Azure.ResourceManager.StandbyPool
{
    public partial class AzureResourceManagerStandbyPoolContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStandbyPoolContext() { }
        public static Azure.ResourceManager.StandbyPool.AzureResourceManagerStandbyPoolContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> GetStandbyContainerGroupPoolRuntimeView(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetStandbyContainerGroupPoolRuntimeViewAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewCollection GetStandbyContainerGroupPoolRuntimeViews() { throw null; }
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
    public partial class StandbyContainerGroupPoolRuntimeViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>, System.Collections.IEnumerable
    {
        protected StandbyContainerGroupPoolRuntimeViewCollection() { }
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
    public partial class StandbyContainerGroupPoolRuntimeViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>
    {
        internal StandbyContainerGroupPoolRuntimeViewData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyContainerGroupPoolRuntimeViewResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyContainerGroupPoolName, string runtimeView) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal StandbyVirtualMachineData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> GetStandbyVirtualMachinePoolRuntimeView(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetStandbyVirtualMachinePoolRuntimeViewAsync(string runtimeView, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewCollection GetStandbyVirtualMachinePoolRuntimeViews() { throw null; }
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
    public partial class StandbyVirtualMachinePoolRuntimeViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>, System.Collections.IEnumerable
    {
        protected StandbyVirtualMachinePoolRuntimeViewCollection() { }
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
    public partial class StandbyVirtualMachinePoolRuntimeViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>
    {
        internal StandbyVirtualMachinePoolRuntimeViewData() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StandbyVirtualMachinePoolRuntimeViewResource() { }
        public virtual Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string standbyVirtualMachinePoolName, string runtimeView) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary ContainerGroupInstanceCountSummary(long? zone = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount> standbyContainerGroupInstanceCountsByState = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount PoolContainerGroupStateCount(Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState state = default(Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState), long count = (long)0) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount PoolResourceStateCount(string state = null, long count = (long)0) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount PoolVirtualMachineStateCount(Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState state = default(Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState), long count = (long)0) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolData StandbyContainerGroupPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction StandbyContainerGroupPoolPrediction(System.Collections.Generic.IEnumerable<long> forecastValuesInstancesRequestedCount = null, System.DateTimeOffset forecastStartOn = default(System.DateTimeOffset), string forecastInfo = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties StandbyContainerGroupPoolProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile = null, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties containerGroupProperties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties StandbyContainerGroupPoolProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties containerGroupProperties, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyContainerGroupPoolRuntimeViewData StandbyContainerGroupPoolRuntimeViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties StandbyContainerGroupPoolRuntimeViewProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> instanceCountSummary = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus status = null, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState?), Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction prediction = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties StandbyContainerGroupPoolRuntimeViewProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> instanceCountSummary, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus StandbyPoolStatus(Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode code = default(Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode), string message = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachineData StandbyVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary StandbyVirtualMachineInstanceCountSummary(long? zone = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> instanceCountsByState = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary StandbyVirtualMachineInstanceCountSummary(long? zone = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount> standbyVirtualMachineInstanceCountsByState = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolData StandbyVirtualMachinePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction StandbyVirtualMachinePoolPrediction(System.Collections.Generic.IEnumerable<long> forecastValuesInstancesRequestedCount = null, System.DateTimeOffset forecastStartOn = default(System.DateTimeOffset), string forecastInfo = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties StandbyVirtualMachinePoolProperties(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile elasticityProfile = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState virtualMachineState = default(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState), Azure.Core.ResourceIdentifier attachedVirtualMachineScaleSetId = null, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StandbyPool.StandbyVirtualMachinePoolRuntimeViewData StandbyVirtualMachinePoolRuntimeViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties StandbyVirtualMachinePoolRuntimeViewProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary> instanceCountSummary = null, Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus status = null, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState?), Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction prediction = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties StandbyVirtualMachinePoolRuntimeViewProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary> instanceCountSummary, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties StandbyVirtualMachineProperties(Azure.Core.ResourceIdentifier virtualMachineResourceId = null, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? provisioningState = default(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState?)) { throw null; }
    }
    public partial class ContainerGroupInstanceCountSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>
    {
        internal ContainerGroupInstanceCountSummary() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> InstanceCountsByState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount> StandbyContainerGroupInstanceCountsByState { get { throw null; } }
        public long? Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolContainerGroupState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolContainerGroupState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState Creating { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState left, Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState left, Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolContainerGroupStateCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>
    {
        internal PoolContainerGroupStateCount() { }
        public long Count { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolContainerGroupStateCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PoolResourceStateCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>
    {
        internal PoolResourceStateCount() { }
        public long Count { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolVirtualMachineState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolVirtualMachineState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Creating { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Deallocating { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Hibernated { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Hibernating { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Running { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState Starting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState left, Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolVirtualMachineStateCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>
    {
        internal PoolVirtualMachineStateCount() { }
        public long Count { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolElasticityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>
    {
        public StandbyContainerGroupPoolElasticityProfile(long maxReadyCapacity) { }
        public long MaxReadyCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy? RefillPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>
    {
        public StandbyContainerGroupPoolPatch() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolPrediction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>
    {
        internal StandbyContainerGroupPoolPrediction() { }
        public string ForecastInfo { get { throw null; } }
        public System.DateTimeOffset ForecastStartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<long> ForecastValuesInstancesRequestedCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>
    {
        public StandbyContainerGroupPoolProperties(Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile elasticityProfile, Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties containerGroupProperties) { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>
    {
        internal StandbyContainerGroupPoolRuntimeViewProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.ContainerGroupInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolPrediction Prediction { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolRuntimeViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupPoolUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>
    {
        public StandbyContainerGroupPoolUpdateProperties() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupPoolUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyContainerGroupProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProfile>
    {
        public StandbyContainerGroupProfile(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public long? Revision { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyContainerGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyPoolHealthStateCode : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyPoolHealthStateCode(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode Degraded { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode Healthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode left, Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StandbyPoolStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>
    {
        internal StandbyPoolStatus() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolHealthStateCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyProvisioningState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState left, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState left, Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyRefillPolicy : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyRefillPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy Always { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy left, Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy left, Azure.ResourceManager.StandbyPool.Models.StandbyRefillPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StandbyVirtualMachineInstanceCountSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>
    {
        internal StandbyVirtualMachineInstanceCountSummary() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolResourceStateCount> InstanceCountsByState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.PoolVirtualMachineStateCount> StandbyVirtualMachineInstanceCountsByState { get { throw null; } }
        public long? Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolElasticityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>
    {
        public StandbyVirtualMachinePoolElasticityProfile(long maxReadyCapacity) { }
        public long MaxReadyCapacity { get { throw null; } set { } }
        public long? MinReadyCapacity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>
    {
        public StandbyVirtualMachinePoolPatch() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolPrediction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>
    {
        internal StandbyVirtualMachinePoolPrediction() { }
        public string ForecastInfo { get { throw null; } }
        public System.DateTimeOffset ForecastStartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<long> ForecastValuesInstancesRequestedCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>
    {
        public StandbyVirtualMachinePoolProperties(Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState virtualMachineState) { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState VirtualMachineState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>
    {
        internal StandbyVirtualMachinePoolRuntimeViewProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolPrediction Prediction { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyPoolStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolRuntimeViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachinePoolUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>
    {
        public StandbyVirtualMachinePoolUpdateProperties() { }
        public Azure.Core.ResourceIdentifier AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState? VirtualMachineState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachinePoolUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StandbyVirtualMachineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>
    {
        internal StandbyVirtualMachineProperties() { }
        public Azure.ResourceManager.StandbyPool.Models.StandbyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandbyVirtualMachineState : System.IEquatable<Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandbyVirtualMachineState(string value) { throw null; }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.StandbyPool.Models.StandbyVirtualMachineState Hibernated { get { throw null; } }
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
}
