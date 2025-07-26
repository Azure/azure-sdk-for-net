namespace Azure.ResourceManager.ContainerOrchestratorRuntime
{
    public partial class AzureResourceManagerContainerOrchestratorRuntimeContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerOrchestratorRuntimeContext() { }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.AzureResourceManagerContainerOrchestratorRuntimeContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectedClusterBgpPeerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>, System.Collections.IEnumerable
    {
        protected ConnectedClusterBgpPeerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bgpPeerName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bgpPeerName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> Get(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> GetAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> GetIfExists(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> GetIfExistsAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedClusterBgpPeerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>
    {
        public ConnectedClusterBgpPeerData() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterBgpPeerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedClusterBgpPeerResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string bgpPeerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectedClusterLoadBalancerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>, System.Collections.IEnumerable
    {
        protected ConnectedClusterLoadBalancerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> Get(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> GetAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> GetIfExists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedClusterLoadBalancerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>
    {
        public ConnectedClusterLoadBalancerData() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterLoadBalancerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedClusterLoadBalancerResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string loadBalancerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectedClusterServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>, System.Collections.IEnumerable
    {
        protected ConnectedClusterServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedClusterServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>
    {
        public ConnectedClusterServiceData() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedClusterServiceResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectedClusterStorageClassCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>, System.Collections.IEnumerable
    {
        protected ConnectedClusterStorageClassCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageClassName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageClassName, Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> Get(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> GetAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> GetIfExists(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> GetIfExistsAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedClusterStorageClassData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>
    {
        public ConnectedClusterStorageClassData() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterStorageClassResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedClusterStorageClassResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string storageClassName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerOrchestratorRuntimeExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> GetConnectedClusterBgpPeer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> GetConnectedClusterBgpPeerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource GetConnectedClusterBgpPeerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerCollection GetConnectedClusterBgpPeers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> GetConnectedClusterLoadBalancer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> GetConnectedClusterLoadBalancerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource GetConnectedClusterLoadBalancerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerCollection GetConnectedClusterLoadBalancers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> GetConnectedClusterService(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> GetConnectedClusterServiceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource GetConnectedClusterServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceCollection GetConnectedClusterServices(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> GetConnectedClusterStorageClass(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> GetConnectedClusterStorageClassAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassCollection GetConnectedClusterStorageClasses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource GetConnectedClusterStorageClassResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Mocking
{
    public partial class MockableContainerOrchestratorRuntimeArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerOrchestratorRuntimeArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource> GetConnectedClusterBgpPeer(Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource>> GetConnectedClusterBgpPeerAsync(Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerResource GetConnectedClusterBgpPeerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerCollection GetConnectedClusterBgpPeers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource> GetConnectedClusterLoadBalancer(Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource>> GetConnectedClusterLoadBalancerAsync(Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerResource GetConnectedClusterLoadBalancerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerCollection GetConnectedClusterLoadBalancers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource> GetConnectedClusterService(Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource>> GetConnectedClusterServiceAsync(Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceResource GetConnectedClusterServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceCollection GetConnectedClusterServices(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource> GetConnectedClusterStorageClass(Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource>> GetConnectedClusterStorageClassAsync(Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassCollection GetConnectedClusterStorageClasses(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassResource GetConnectedClusterStorageClassResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvertiseMode : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvertiseMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode Arp { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode Bgp { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode Both { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmContainerOrchestratorRuntimeModelFactory
    {
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterBgpPeerData ConnectedClusterBgpPeerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties ConnectedClusterBgpPeerProperties(int myAsn = 0, int peerAsn = 0, string peerAddress = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterLoadBalancerData ConnectedClusterLoadBalancerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties ConnectedClusterLoadBalancerProperties(System.Collections.Generic.IEnumerable<string> addresses = null, System.Collections.Generic.IDictionary<string, string> serviceSelector = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode advertiseMode = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode), System.Collections.Generic.IEnumerable<string> bgpPeers = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterServiceData ConnectedClusterServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties ConnectedClusterServiceProperties(System.Guid? rpObjectId = default(System.Guid?), Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ConnectedClusterStorageClassData ConnectedClusterStorageClassData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties ConnectedClusterStorageClassProperties(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? allowVolumeExpansion = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion?), System.Collections.Generic.IEnumerable<string> mountOptions = null, string provisioner = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode? volumeBindingMode = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode> accessModes = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? dataResilience = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier?), Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? failoverSpeed = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier?), System.Collections.Generic.IEnumerable<string> limitations = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? performance = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier?), long? priority = default(long?), Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties typeProperties = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState?)) { throw null; }
    }
    public partial class BlobStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>
    {
        public BlobStorageClassTypeProperties(string azureStorageAccountName, string azureStorageAccountKey) { }
        public string AzureStorageAccountKey { get { throw null; } set { } }
        public string AzureStorageAccountName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterBgpPeerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>
    {
        public ConnectedClusterBgpPeerProperties(int myAsn, int peerAsn, string peerAddress) { }
        public int MyAsn { get { throw null; } set { } }
        public string PeerAddress { get { throw null; } set { } }
        public int PeerAsn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterBgpPeerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterLoadBalancerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>
    {
        public ConnectedClusterLoadBalancerProperties(System.Collections.Generic.IEnumerable<string> addresses, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode advertiseMode) { }
        public System.Collections.Generic.IList<string> Addresses { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode AdvertiseMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BgpPeers { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ServiceSelector { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterLoadBalancerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>
    {
        public ConnectedClusterServiceProperties() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? RpObjectId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterStorageClassPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>
    {
        public ConnectedClusterStorageClassPatch() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterStorageClassProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>
    {
        public ConnectedClusterStorageClassProperties(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties typeProperties) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode> AccessModes { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? AllowVolumeExpansion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? DataResilience { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? FailoverSpeed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Limitations { get { throw null; } }
        public System.Collections.Generic.IList<string> MountOptions { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? Performance { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public string Provisioner { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties TypeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode? VolumeBindingMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ConnectedClusterStorageClassProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerOrchestratorProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerOrchestratorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ContainerOrchestratorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataResilienceTier : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataResilienceTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier DataResilient { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier NotDataResilient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverTier : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier Fast { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier Slow { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier Super { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NativeStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>
    {
        public NativeStorageClassTypeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NativeStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsDirectoryActionOnVolumeDeletion : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsDirectoryActionOnVolumeDeletion(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion Retain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>
    {
        public NfsStorageClassTypeProperties(string server, string share) { }
        public string MountPermissions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion? OnDelete { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Share { get { throw null; } set { } }
        public string SubDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PerformanceTier : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PerformanceTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier Standard { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier Ultra { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RwxStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>
    {
        public RwxStorageClassTypeProperties(string backingStorageClassName) { }
        public string BackingStorageClassName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmbStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>
    {
        public SmbStorageClassTypeProperties(string source) { }
        public string Domain { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SubDir { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageClassAccessMode : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageClassAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode ReadWriteMany { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode ReadWriteOnce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageClassPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>
    {
        public StorageClassPropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassAccessMode> AccessModes { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? AllowVolumeExpansion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? DataResilience { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? FailoverSpeed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Limitations { get { throw null; } }
        public System.Collections.Generic.IList<string> MountOptions { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? Performance { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate TypeProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StorageClassTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>
    {
        protected StorageClassTypeProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageClassTypePropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>
    {
        public StorageClassTypePropertiesUpdate() { }
        public string AzureStorageAccountKey { get { throw null; } set { } }
        public string AzureStorageAccountName { get { throw null; } set { } }
        public string BackingStorageClassName { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string MountPermissions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.NfsDirectoryActionOnVolumeDeletion? OnDelete { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Share { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string SubDir { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeBindingMode : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeBindingMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode Immediate { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode WaitForFirstConsumer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeExpansion : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeExpansion(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion Allow { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion Disallow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion right) { throw null; }
        public override string ToString() { throw null; }
    }
}
