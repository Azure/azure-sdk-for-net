namespace Azure.ResourceManager.ContainerOrchestratorRuntime
{
    public partial class BgpPeerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>, System.Collections.IEnumerable
    {
        protected BgpPeerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bgpPeerName, Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bgpPeerName, Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> Get(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> GetAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> GetIfExists(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> GetIfExistsAsync(string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BgpPeerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>
    {
        public BgpPeerData() { }
        public int? MyAsn { get { throw null; } set { } }
        public string PeerAddress { get { throw null; } set { } }
        public int? PeerAsn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BgpPeerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BgpPeerResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string bgpPeerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerOrchestratorRuntimeExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> GetBgpPeer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> GetBgpPeerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource GetBgpPeerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerCollection GetBgpPeers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> GetLoadBalancer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> GetLoadBalancerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource GetLoadBalancerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerCollection GetLoadBalancers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> GetServiceResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceCollection GetServiceResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource GetStorageClassResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> GetStorageClassResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> GetStorageClassResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceCollection GetStorageClassResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class LoadBalancerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>, System.Collections.IEnumerable
    {
        protected LoadBalancerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> Get(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> GetAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> GetIfExists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadBalancerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>
    {
        public LoadBalancerData() { }
        public System.Collections.Generic.IList<string> Addresses { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode? AdvertiseMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BgpPeers { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ServiceSelector { get { throw null; } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadBalancerResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string loadBalancerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>
    {
        public ServiceResourceData() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RpObjectId { get { throw null; } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageClassResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageClassResource() { }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string storageClassName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageClassResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>, System.Collections.IEnumerable
    {
        protected StorageClassResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageClassName, Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageClassName, Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> Get(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> GetAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> GetIfExists(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> GetIfExistsAsync(string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageClassResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>
    {
        public StorageClassResourceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode> AccessModes { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? AllowVolumeExpansion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? DataResilience { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? FailoverSpeed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Limitations { get { throw null; } }
        public System.Collections.Generic.IList<string> MountOptions { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? Performance { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public string Provisioner { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties TypeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode? VolumeBindingMode { get { throw null; } set { } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Mocking
{
    public partial class MockableContainerOrchestratorRuntimeArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerOrchestratorRuntimeArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource> GetBgpPeer(Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource>> GetBgpPeerAsync(Azure.Core.ResourceIdentifier scope, string bgpPeerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerResource GetBgpPeerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerCollection GetBgpPeers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource> GetLoadBalancer(Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource>> GetLoadBalancerAsync(Azure.Core.ResourceIdentifier scope, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerResource GetLoadBalancerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerCollection GetLoadBalancers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource GetServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource> GetServiceResource(Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResource>> GetServiceResourceAsync(Azure.Core.ResourceIdentifier scope, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceCollection GetServiceResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource GetStorageClassResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource> GetStorageClassResource(Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResource>> GetStorageClassResourceAsync(Azure.Core.ResourceIdentifier scope, string storageClassName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceCollection GetStorageClassResources(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessMode : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode ReadWriteMany { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode ReadWriteOnce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvertiseMode : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvertiseMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode ARP { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode BGP { get { throw null; } }
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
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.BgpPeerData BgpPeerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? myAsn = default(int?), int? peerAsn = default(int?), string peerAddress = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.LoadBalancerData LoadBalancerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> addresses = null, System.Collections.Generic.IDictionary<string, string> serviceSelector = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode? advertiseMode = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AdvertiseMode?), System.Collections.Generic.IEnumerable<string> bgpPeers = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.ServiceResourceData ServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string rpObjectId = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.StorageClassResourceData StorageClassResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? allowVolumeExpansion = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion?), System.Collections.Generic.IEnumerable<string> mountOptions = null, string provisioner = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode? volumeBindingMode = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeBindingMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode> accessModes = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? dataResilience = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier?), Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? failoverSpeed = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier?), System.Collections.Generic.IEnumerable<string> limitations = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? performance = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier?), long? priority = default(long?), Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties typeProperties = null, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState?)) { throw null; }
    }
    public partial class BlobStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>
    {
        public BlobStorageClassTypeProperties(string azureStorageAccountName, string azureStorageAccountKey) { }
        public string AzureStorageAccountKey { get { throw null; } set { } }
        public string AzureStorageAccountName { get { throw null; } set { } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.BlobStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState left, Azure.ResourceManager.ContainerOrchestratorRuntime.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RwxStorageClassTypeProperties : Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.RwxStorageClassTypeProperties>
    {
        public RwxStorageClassTypeProperties(string backingStorageClassName) { }
        public string BackingStorageClassName { get { throw null; } set { } }
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
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.SmbStorageClassTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageClassPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>
    {
        public StorageClassPropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.AccessMode> AccessModes { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.VolumeExpansion? AllowVolumeExpansion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.DataResilienceTier? DataResilience { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.FailoverTier? FailoverSpeed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Limitations { get { throw null; } }
        public System.Collections.Generic.IList<string> MountOptions { get { throw null; } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.PerformanceTier? Performance { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypePropertiesUpdate TypeProperties { get { throw null; } set { } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageClassResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>
    {
        public StorageClassResourcePatch() { }
        public Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassPropertiesUpdate Properties { get { throw null; } set { } }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StorageClassTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerOrchestratorRuntime.Models.StorageClassTypeProperties>
    {
        protected StorageClassTypeProperties() { }
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
