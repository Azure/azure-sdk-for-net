namespace Azure.ResourceManager.TrafficManager
{
    public partial class AzureEndpointTrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection
    {
        protected AzureEndpointTrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> GetIfExists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> GetIfExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureEndpointTrafficManagerEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureEndpointTrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerTrafficManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTrafficManagerContext() { }
        public static Azure.ResourceManager.TrafficManager.AzureResourceManagerTrafficManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ExternalEndpointTrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection
    {
        protected ExternalEndpointTrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> GetIfExists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> GetIfExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExternalEndpointTrafficManagerEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExternalEndpointTrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedEndpointTrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection
    {
        protected NestedEndpointTrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> GetIfExists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> GetIfExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedEndpointTrafficManagerEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedEndpointTrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.Collections.IEnumerable
    {
        protected TrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Get(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> GetAll() { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> GetAllAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> GetIfExists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> GetIfExists(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetIfExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetIfExistsAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficManagerEndpointData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>
    {
        public TrafficManagerEndpointData() { }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus? AlwaysServe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo> CustomHeaders { get { throw null; } }
        public string EndpointLocation { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus? EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus? EndpointStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GeoMapping { get { throw null; } }
        public long? MinChildEndpoints { get { throw null; } set { } }
        public long? MinChildEndpointsIPv4 { get { throw null; } set { } }
        public long? MinChildEndpointsIPv6 { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo> Subnets { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointType, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TrafficManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult> CheckTrafficManagerNameAvailabilityV2(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>> CheckTrafficManagerNameAvailabilityV2Async(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult> CheckTrafficManagerRelativeDnsNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>> CheckTrafficManagerRelativeDnsNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource GetAzureEndpointTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource GetExternalEndpointTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource GetNestedEndpointTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource GetTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyCollection GetTrafficManagerGeographicHierarchies(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> GetTrafficManagerGeographicHierarchy(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetTrafficManagerGeographicHierarchyAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource GetTrafficManagerHeatMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetTrafficManagerProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource GetTrafficManagerProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerProfileCollection GetTrafficManagerProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> GetTrafficManagerUserMetric(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetTrafficManagerUserMetricAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetricsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class TrafficManagerGeographicHierarchyCollection : Azure.ResourceManager.ArmCollection
    {
        protected TrafficManagerGeographicHierarchyCollection() { }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerGeographicHierarchyData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>
    {
        public TrafficManagerGeographicHierarchyData() { }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion GeographicHierarchy { get { throw null; } set { } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerGeographicHierarchyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerGeographicHierarchyResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerHeatMapCollection : Azure.ResourceManager.ArmCollection
    {
        protected TrafficManagerHeatMapCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> GetIfExists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetIfExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerHeatMapData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>
    {
        public TrafficManagerHeatMapData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint> Endpoints { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow> TrafficFlows { get { throw null; } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerHeatMapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerHeatMapResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> Get(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetAsync(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>, System.Collections.IEnumerable
    {
        protected TrafficManagerProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficManagerProfileData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>
    {
        public TrafficManagerProfileData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType> AllowedEndpointRecordTypes { get { throw null; } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> Endpoints { get { throw null; } }
        public long? MaxReturn { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig MonitorConfig { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus? TrafficViewEnrollmentStatus { get { throw null; } set { } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerProfileResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource> GetAzureEndpointTrafficManagerEndpoint(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource>> GetAzureEndpointTrafficManagerEndpointAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointCollection GetAzureEndpointTrafficManagerEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource> GetExternalEndpointTrafficManagerEndpoint(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource>> GetExternalEndpointTrafficManagerEndpointAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointCollection GetExternalEndpointTrafficManagerEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource> GetNestedEndpointTrafficManagerEndpoint(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource>> GetNestedEndpointTrafficManagerEndpointAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointCollection GetNestedEndpointTrafficManagerEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> GetTrafficManagerEndpoint(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> GetTrafficManagerEndpoint(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetTrafficManagerEndpointAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointType endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetTrafficManagerEndpointAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointCollection GetTrafficManagerEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> GetTrafficManagerHeatMap(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetTrafficManagerHeatMapAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapCollection GetTrafficManagerHeatMaps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerUserMetricCollection : Azure.ResourceManager.ArmCollection
    {
        protected TrafficManagerUserMetricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerUserMetricData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>
    {
        public TrafficManagerUserMetricData() { }
        public string Key { get { throw null; } set { } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerUserMetricsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerUserMetricsResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrafficManager.Mocking
{
    public partial class MockableTrafficManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableTrafficManagerArmClient() { }
        public virtual Azure.ResourceManager.TrafficManager.AzureEndpointTrafficManagerEndpointResource GetAzureEndpointTrafficManagerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.ExternalEndpointTrafficManagerEndpointResource GetExternalEndpointTrafficManagerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.NestedEndpointTrafficManagerEndpointResource GetNestedEndpointTrafficManagerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource GetTrafficManagerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource GetTrafficManagerHeatMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource GetTrafficManagerProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetricsResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableTrafficManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrafficManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetTrafficManagerProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerProfileCollection GetTrafficManagerProfiles() { throw null; }
    }
    public partial class MockableTrafficManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrafficManagerSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult> CheckTrafficManagerNameAvailabilityV2(Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>> CheckTrafficManagerNameAvailabilityV2Async(Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> GetTrafficManagerUserMetric(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetTrafficManagerUserMetricAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetrics() { throw null; }
    }
    public partial class MockableTrafficManagerTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrafficManagerTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult> CheckTrafficManagerRelativeDnsNameAvailability(Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>> CheckTrafficManagerRelativeDnsNameAvailabilityAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyCollection GetTrafficManagerGeographicHierarchies() { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> GetTrafficManagerGeographicHierarchy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetTrafficManagerGeographicHierarchyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrafficManager.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedEndpointRecordType : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedEndpointRecordType(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType Any { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType DomainName { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType IPv4Address { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType IPv6Address { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType left, Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType left, Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmTrafficManagerModelFactory
    {
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult TrafficManagerDeleteOperationResult(bool? operationResult = default(bool?)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig TrafficManagerDnsConfig(string relativeName = null, string fqdn = null, long? ttl = default(long?)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow TrafficManagerHeatMapTrafficFlow(System.Net.IPAddress sourceIP = null, double? latitude = default(double?), double? longitude = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience> queryExperiences = null) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig TrafficManagerMonitorConfig(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus? profileMonitorStatus = default(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus?), Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol? protocol = default(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol?), long? port = default(long?), string path = null, long? intervalInSeconds = default(long?), long? timeoutInSeconds = default(long?), long? toleratedNumberOfFailures = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo> customHeaders = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo> expectedStatusCodeRanges = null) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult TrafficManagerNameAvailabilityResult(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), bool? isNameAvailable = default(bool?), string unavailableReason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerProfileData TrafficManagerProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus? profileStatus = default(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus?), Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod? trafficRoutingMethod = default(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod?), Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig dnsConfig = null, Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig monitorConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> endpoints = null, Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus? trafficViewEnrollmentStatus = default(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType> allowedEndpointRecordTypes = null, long? maxReturn = default(long?)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion TrafficManagerRegion(string code = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion> regions = null) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData TrafficManagerTrackedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
    }
    public partial class ExpectedStatusCodeRangeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>
    {
        public ExpectedStatusCodeRangeInfo() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerDeleteOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>
    {
        internal TrafficManagerDeleteOperationResult() { }
        public bool? OperationResult { get { throw null; } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDeleteOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerDnsConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>
    {
        public TrafficManagerDnsConfig() { }
        public string Fqdn { get { throw null; } }
        public string RelativeName { get { throw null; } set { } }
        public long? Ttl { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointAlwaysServeStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointAlwaysServeStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerEndpointCustomHeaderInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>
    {
        public TrafficManagerEndpointCustomHeaderInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus CheckingEndpoint { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Online { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Unmonitored { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerEndpointSubnetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>
    {
        public TrafficManagerEndpointSubnetInfo() { }
        public System.Net.IPAddress First { get { throw null; } set { } }
        public System.Net.IPAddress Last { get { throw null; } set { } }
        public int? Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TrafficManagerEndpointType
    {
        AzureEndpoints = 0,
        ExternalEndpoints = 1,
        NestedEndpoints = 2,
    }
    public partial class TrafficManagerHeatMapEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>
    {
        public TrafficManagerHeatMapEndpoint() { }
        public int? EndpointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerHeatMapQueryExperience : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>
    {
        public TrafficManagerHeatMapQueryExperience(int endpointId, int queryCount) { }
        public int EndpointId { get { throw null; } set { } }
        public double? Latency { get { throw null; } set { } }
        public int QueryCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerHeatMapTrafficFlow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>
    {
        public TrafficManagerHeatMapTrafficFlow() { }
        public double? Latitude { get { throw null; } set { } }
        public double? Longitude { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience> QueryExperiences { get { throw null; } }
        public System.Net.IPAddress SourceIP { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerHeatMapType : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerHeatMapType(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerMonitorConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>
    {
        public TrafficManagerMonitorConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo> CustomHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo> ExpectedStatusCodeRanges { get { throw null; } }
        public long? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus? ProfileMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol? Protocol { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public long? ToleratedNumberOfFailures { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerMonitorConfigCustomHeaderInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>
    {
        public TrafficManagerMonitorConfigCustomHeaderInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerMonitorProtocol : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerMonitorProtocol(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>
    {
        internal TrafficManagerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string UnavailableReason { get { throw null; } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerProfileMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerProfileMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus CheckingEndpoints { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerProfileStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerProxyResourceData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>
    {
        public TrafficManagerProxyResourceData() { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>
    {
        public TrafficManagerRegion() { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion> Regions { get { throw null; } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerRelativeDnsNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>
    {
        public TrafficManagerRelativeDnsNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>
    {
        public TrafficManagerResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficManagerTrackedResourceData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>
    {
        public TrafficManagerTrackedResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficRoutingMethod : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficRoutingMethod(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Geographic { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod MultiValue { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Performance { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Priority { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Subnet { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Weighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficViewEnrollmentStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficViewEnrollmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
