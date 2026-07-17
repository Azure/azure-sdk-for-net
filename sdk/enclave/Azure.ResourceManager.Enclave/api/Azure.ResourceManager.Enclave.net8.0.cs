namespace Azure.ResourceManager.Enclave
{
    public partial class AzureResourceManagerEnclaveContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEnclaveContext() { }
        public static Azure.ResourceManager.Enclave.AzureResourceManagerEnclaveContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DedicatedHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHubResource() { }
        public virtual Azure.ResourceManager.Enclave.DedicatedHubResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string dedicatedHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.DedicatedHubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.DedicatedHubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.DedicatedHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.DedicatedHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHubResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.DedicatedHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.DedicatedHubResource>, System.Collections.IEnumerable
    {
        protected DedicatedHubResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.DedicatedHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dedicatedHubName, Azure.ResourceManager.Enclave.DedicatedHubResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.DedicatedHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dedicatedHubName, Azure.ResourceManager.Enclave.DedicatedHubResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> Get(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> GetAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.DedicatedHubResource> GetIfExists(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.DedicatedHubResource>> GetIfExistsAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.DedicatedHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.DedicatedHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.DedicatedHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.DedicatedHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHubResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>
    {
        public DedicatedHubResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.DedicatedHubProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.DedicatedHubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.DedicatedHubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.DedicatedHubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class EnclaveExtensions
    {
        public static Azure.ResourceManager.Enclave.DedicatedHubResource GetDedicatedHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetDedicatedHubResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetDedicatedHubResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclave(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> GetVirtualEnclaveApproval(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> GetVirtualEnclaveApprovalAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource GetVirtualEnclaveApprovalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveApprovalCollection GetVirtualEnclaveApprovals(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> GetVirtualEnclaveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCommunityCollection GetVirtualEnclaveCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> GetVirtualEnclaveCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource GetVirtualEnclaveCommunityEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource GetVirtualEnclaveCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> GetVirtualEnclaveConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource GetVirtualEnclaveConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveConnectionCollection GetVirtualEnclaveConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource GetVirtualEnclaveEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveResource GetVirtualEnclaveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCollection GetVirtualEnclaves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclaves(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclavesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource GetVirtualEnclaveTransitHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource GetVirtualEnclaveWorkloadResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloads(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloadsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveApprovalCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveApprovalCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> Get(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> GetAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> GetIfExists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> GetIfExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveApprovalData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>
    {
        public VirtualEnclaveApprovalData() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveApprovalResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string approvalName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> NotifyInitiator(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> NotifyInitiatorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.Enclave.VirtualEnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.Enclave.VirtualEnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> Get(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> GetAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetIfExists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> GetIfExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> Get(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> GetAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetIfExists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> GetIfExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>
    {
        public VirtualEnclaveCommunityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCommunityEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> Get(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> GetAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetIfExists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> GetIfExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>
    {
        public VirtualEnclaveCommunityEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveCommunityEndpointResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string communityEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveCommunityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveCommunityResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult> CheckAddressSpaceAvailability(Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>> CheckAddressSpaceAvailabilityAsync(Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource> GetDedicatedHubResource(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.DedicatedHubResource>> GetDedicatedHubResourceAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.DedicatedHubResourceCollection GetDedicatedHubResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoint(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource>> GetVirtualEnclaveCommunityEndpointAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointCollection GetVirtualEnclaveCommunityEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHub(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> GetVirtualEnclaveTransitHubAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubCollection GetVirtualEnclaveTransitHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> Get(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> GetAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetIfExists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> GetIfExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>
    {
        public VirtualEnclaveConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveConnectionResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enclaveConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>
    {
        public VirtualEnclaveData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> Get(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> GetAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetIfExists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> GetIfExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>
    {
        public VirtualEnclaveEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveEndpointResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string enclaveEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoint(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource>> GetVirtualEnclaveEndpointAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveEndpointCollection GetVirtualEnclaveEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkload(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> GetVirtualEnclaveWorkloadAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadCollection GetVirtualEnclaveWorkloads() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveTransitHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> Get(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> GetAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetIfExists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> GetIfExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveTransitHubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>
    {
        public VirtualEnclaveTransitHubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveTransitHubResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string transitHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveWorkloadCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> Get(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> GetAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetIfExists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> GetIfExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveWorkloadData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>
    {
        public VirtualEnclaveWorkloadData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveWorkloadResource() { }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string workloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Enclave.Mocking
{
    public partial class MockableEnclaveArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveArmClient() { }
        public virtual Azure.ResourceManager.Enclave.DedicatedHubResource GetDedicatedHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource> GetVirtualEnclaveApproval(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource>> GetVirtualEnclaveApprovalAsync(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveApprovalResource GetVirtualEnclaveApprovalResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveApprovalCollection GetVirtualEnclaveApprovals(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource GetVirtualEnclaveCommunityEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource GetVirtualEnclaveCommunityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource GetVirtualEnclaveConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource GetVirtualEnclaveEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveResource GetVirtualEnclaveResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource GetVirtualEnclaveTransitHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource GetVirtualEnclaveWorkloadResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEnclaveResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclave(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveResource>> GetVirtualEnclaveAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCommunityCollection GetVirtualEnclaveCommunities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunity(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource>> GetVirtualEnclaveCommunityAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnection(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource>> GetVirtualEnclaveConnectionAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveConnectionCollection GetVirtualEnclaveConnections() { throw null; }
        public virtual Azure.ResourceManager.Enclave.VirtualEnclaveCollection GetVirtualEnclaves() { throw null; }
    }
    public partial class MockableEnclaveSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetDedicatedHubResources(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.DedicatedHubResource> GetDedicatedHubResourcesAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoints(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpointsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoints(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpointsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclaves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveResource> GetVirtualEnclavesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubs(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloads(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloadsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Enclave.Models
{
    public partial class ApprovalActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>
    {
        public ApprovalActionContent(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus approvalStatus) { }
        public Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus ApprovalStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalActionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalActionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApprovalActionRequestApprovalStatus : System.IEquatable<Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApprovalActionRequestApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus left, Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus left, Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApprovalActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>
    {
        internal ApprovalActionResult() { }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalActionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalActionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalCallbackContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>
    {
        public ApprovalCallbackContent(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction resourceRequestAction, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus approvalStatus) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus ApprovalStatus { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction ResourceRequestAction { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApprovalCallbackRequestApprovalStatus : System.IEquatable<Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApprovalCallbackRequestApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus left, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus left, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApprovalCallbackRequestResourceRequestAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApprovalCallbackRequestResourceRequestAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction Create { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction Reset { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction left, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction left, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApprovalDeletionCallbackContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>
    {
        public ApprovalDeletionCallbackContent(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction resourceRequestAction) { }
        public Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction ResourceRequestAction { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApprovalDeletionCallbackRequestResourceRequestAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApprovalDeletionCallbackRequestResourceRequestAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction Create { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction left, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction left, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApprovalRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>
    {
        public ApprovalRequestMetadata(string resourceAction) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public string ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
        public string ResourceAction { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalRequestMetadataPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>
    {
        public ApprovalRequestMetadataPatch(string resourceAction) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public string ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
        public string ResourceAction { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalSettingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>
    {
        public ApprovalSettingConfiguration() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy? ApprovalPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
        public int? MinimumApproversRequired { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalSettingsPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>
    {
        public ApprovalSettingsPatchProperties() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityMaintenanceMode { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApproverActionPerformed : System.IEquatable<Azure.ResourceManager.Enclave.Models.ApproverActionPerformed>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApproverActionPerformed(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApproverActionPerformed Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ApproverActionPerformed Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ApproverActionPerformed other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ApproverActionPerformed left, Azure.ResourceManager.Enclave.Models.ApproverActionPerformed right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApproverActionPerformed (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ApproverActionPerformed? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ApproverActionPerformed left, Azure.ResourceManager.Enclave.Models.ApproverActionPerformed right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmEnclaveModelFactory
    {
        public static Azure.ResourceManager.Enclave.Models.ApprovalActionContent ApprovalActionContent(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus approvalStatus = default(Azure.ResourceManager.Enclave.Models.ApprovalActionRequestApprovalStatus)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalActionResult ApprovalActionResult(string message = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent ApprovalCallbackContent(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction resourceRequestAction = default(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestResourceRequestAction), Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus approvalStatus = default(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus), string approvalCallbackPayload = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent ApprovalDeletionCallbackContent(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction resourceRequestAction = default(Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackRequestResourceRequestAction)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata ApprovalRequestMetadata(string resourceAction = null, string approvalCallbackRoute = null, string approvalCallbackPayload = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus? approvalStatus = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch ApprovalRequestMetadataPatch(string resourceAction = null, string approvalCallbackRoute = null, string approvalCallbackPayload = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus? approvalStatus = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ApprovalSettingConfiguration(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy? approvalPolicy = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy?), int? minimumApproversRequired = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover> mandatoryApprovers = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties ApprovalSettingsPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityMaintenanceMode = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent CheckAddressSpaceAvailabilityContent(Azure.Core.ResourceIdentifier communityResourceId = null, Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult CheckAddressSpaceAvailabilityResult(bool isAvailable = false) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule CommunityEndpointDestinationRule(Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType? destinationType = default(Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol> protocols = null, Azure.Core.ResourceIdentifier transitHubResourceId = null, string endpointRuleName = null, string destination = null, string ports = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties CommunityEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> ruleCollection = null, Azure.ResourceManager.Enclave.Models.UpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.UpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.DedicatedHubProperties DedicatedHubProperties(Azure.Core.ResourceIdentifier vHubResourceId = null, Azure.Core.ResourceIdentifier firewallResourceId = null, Azure.Core.ResourceIdentifier firewallPolicyResourceId = null, Azure.ResourceManager.Enclave.Models.Designation? designation = default(Azure.ResourceManager.Enclave.Models.Designation?), Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Enclave.DedicatedHubResourceData DedicatedHubResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.DedicatedHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch DedicatedHubResourcePatch(Azure.ResourceManager.Enclave.Models.Designation? dedicatedHubPatchDesignation = default(Azure.ResourceManager.Enclave.Models.Designation?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces EnclaveAddressSpaces(string enclaveAddressSpace = null, string managedAddressSpace = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings EnclaveDefaultSettings(Azure.Core.ResourceIdentifier keyVaultResourceId = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> logAnalyticsResourceIdCollection = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination? diagnosticDestination = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule EnclaveEndpointDestinationRule(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol> protocols = null, string endpointRuleName = null, string destination = null, string ports = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties EnclaveEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection = null, Azure.ResourceManager.Enclave.Models.UpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.UpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork(string networkName = null, string networkSize = null, string customCidrRange = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration> subnetConfigurations = null, bool? allowSubnetCommunication = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MoboBrokerResource MoboBrokerResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MonitoringDestination MonitoringDestination(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType destinationType = default(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType), Azure.Core.ResourceIdentifier customWorkspaceResourceId = null, string diagnosticSettingsName = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel MonitoringDestinationPatchModel(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType destinationType = default(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType), Azure.Core.ResourceIdentifier customWorkspaceResourceId = null, string diagnosticSettingsName = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel MonitoringSettingsModel(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.MonitoringDestination> diagnosticDestinations = null, Azure.ResourceManager.Enclave.Models.MonitoringDestination flowLogDestination = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel MonitoringSettingsPatchModel(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel> diagnosticDestinations = null, Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel flowLogDestination = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.TransitOptionParams TransitOptionParams(long? scaleUnits = default(long?), Azure.Core.ResourceIdentifier remoteVirtualNetworkId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveApprovalData VirtualEnclaveApprovalData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch VirtualEnclaveApprovalPatch(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties VirtualEnclaveApprovalPatchProperties(Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties VirtualEnclaveApprovalProperties(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover> mandatoryApprovers = null, long? minimumApproversRequired = default(long?), long? approversApprovedCount = default(long?), long? mandatoryApproversApprovedCount = default(long?), System.Collections.Generic.IEnumerable<string> approvedByEntraIds = null, Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings VirtualEnclaveApprovalSettings(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties VirtualEnclaveApprovalSettingsPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover VirtualEnclaveApprover(string approverEntraId = null, Azure.ResourceManager.Enclave.Models.ApproverActionPerformed? actionPerformed = default(Azure.ResourceManager.Enclave.Models.ApproverActionPerformed?), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<string> mandatoryApprovalGroupMembershipIds = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings VirtualEnclaveBaseApprovalSettings(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityMaintenanceMode = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCommunityData VirtualEnclaveCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveCommunityEndpointData VirtualEnclaveCommunityEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch VirtualEnclaveCommunityEndpointPatch(Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties VirtualEnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.UpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.UpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch VirtualEnclaveCommunityPatch(Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties VirtualEnclaveCommunityPatchProperties(System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? policyOverride = default(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> communityRoleAssignments = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku? firewallSku = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku?), Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties granularApprovalSettings = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch maintenanceModeConfiguration = null, Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel monitoringSettings = null, System.Collections.Generic.IEnumerable<string> addressSpaces = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties VirtualEnclaveCommunityProperties(string addressSpace = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? policyOverride = default(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> communityRoleAssignments = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku? firewallSku = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku?), Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings granularApprovalSettings = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.DedicatedHubResourceData> dedicatedHubList = null, Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel monitoringSettings = null, System.Collections.Generic.IEnumerable<string> addressSpaces = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveConnectionData VirtualEnclaveConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch VirtualEnclaveConnectionPatch(string enclaveConnectionPatchSourceCidr = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties VirtualEnclaveConnectionProperties(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState? state = default(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState?), Azure.Core.ResourceIdentifier communityResourceId = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string sourceCidr = null, Azure.Core.ResourceIdentifier destinationEndpointId = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.UpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.UpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveData VirtualEnclaveData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveEndpointData VirtualEnclaveEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch VirtualEnclaveEndpointPatch(Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties VirtualEnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.UpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.UpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService VirtualEnclaveGovernedService(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier serviceId = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier), string serviceName = null, Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption? option = default(Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption?), Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement? enforcement = default(Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement?), Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction? policyAction = default(Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction?), System.Collections.Generic.IEnumerable<string> initiatives = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration VirtualEnclaveMaintenanceModeConfiguration(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode mode = default(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> principals = null, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification? justification = default(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch VirtualEnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode mode = default(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> principals = null, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification? justification = default(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover VirtualEnclaveMandatoryApprover(string approverEntraId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch VirtualEnclavePatch(Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties VirtualEnclavePatchProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, bool? isBastionEnabled = default(bool?), Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode? workloadResourceVisibility = default(Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode?), Azure.ResourceManager.Enclave.Models.RbacInheritanceMode? rbacInheritance = default(Azure.ResourceManager.Enclave.Models.RbacInheritanceMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination? enclaveDefaultDiagnosticDestination = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination?), Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch maintenanceModeConfiguration = null, Azure.Core.ResourceIdentifier dedicatedHubResourceId = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties approvalSettings = null, Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel monitoringSettings = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal VirtualEnclavePrincipal(string id = null, Azure.ResourceManager.Enclave.Models.PrincipalType type = default(Azure.ResourceManager.Enclave.Models.PrincipalType)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties VirtualEnclaveProperties(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces enclaveAddressSpaces = null, Azure.Core.ResourceIdentifier communityResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, bool? isBastionEnabled = default(bool?), Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode? workloadResourceVisibility = default(Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode?), Azure.ResourceManager.Enclave.Models.RbacInheritanceMode? rbacInheritance = default(Azure.ResourceManager.Enclave.Models.RbacInheritanceMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings enclaveDefaultSettings = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null, Azure.Core.ResourceIdentifier dedicatedHubResourceId = null, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings approvalSettings = null, Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel monitoringSettings = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem VirtualEnclaveRoleAssignmentItem(string roleDefinitionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> principals = null, string condition = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration VirtualEnclaveSubnetConfiguration(string subnetName = null, Azure.Core.ResourceIdentifier subnetResourceId = null, int networkPrefixSize = 0, string subnetDelegation = null, string addressPrefix = null, Azure.Core.ResourceIdentifier networkSecurityGroupResourceId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveTransitHubData VirtualEnclaveTransitHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch VirtualEnclaveTransitHubPatch(Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties VirtualEnclaveTransitHubPatchProperties(Azure.ResourceManager.Enclave.Models.TransitHubState? state = default(Azure.ResourceManager.Enclave.Models.TransitHubState?), Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties transitOption = null, Azure.ResourceManager.Enclave.Models.SecurityProvider? securityProvider = default(Azure.ResourceManager.Enclave.Models.SecurityProvider?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties VirtualEnclaveTransitHubProperties(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.TransitHubState? state = default(Azure.ResourceManager.Enclave.Models.TransitHubState?), Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties transitOption = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.SecurityProvider? securityProvider = default(Azure.ResourceManager.Enclave.Models.SecurityProvider?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties VirtualEnclaveTransitOptionProperties(Azure.ResourceManager.Enclave.Models.TransitOptionType? type = default(Azure.ResourceManager.Enclave.Models.TransitOptionType?), Azure.ResourceManager.Enclave.Models.TransitOptionParams @params = null) { throw null; }
        public static Azure.ResourceManager.Enclave.VirtualEnclaveWorkloadData VirtualEnclaveWorkloadData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch VirtualEnclaveWorkloadPatch(System.Collections.Generic.IEnumerable<string> workloadPatchResourceGroupCollection = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties VirtualEnclaveWorkloadProperties(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<string> resourceGroupCollection = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
    }
    public partial class CheckAddressSpaceAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>
    {
        public CheckAddressSpaceAvailabilityContent(Azure.Core.ResourceIdentifier communityResourceId, Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckAddressSpaceAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>
    {
        internal CheckAddressSpaceAvailabilityResult() { }
        public bool IsAvailable { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityEndpointDestinationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>
    {
        public CommunityEndpointDestinationRule() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType? DestinationType { get { throw null; } set { } }
        public string EndpointRuleName { get { throw null; } set { } }
        public string Ports { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol> Protocols { get { throw null; } }
        public Azure.Core.ResourceIdentifier TransitHubResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityEndpointDestinationType : System.IEquatable<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityEndpointDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType Fqdn { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType FqdnTag { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType IPAddress { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType PrivateNetwork { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType ServiceTag { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType left, Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType left, Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunityEndpointPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>
    {
        public CommunityEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> ruleCollection) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.UpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityEndpointProtocol : System.IEquatable<Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Any { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol left, Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol left, Azure.ResourceManager.Enclave.Models.CommunityEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityPropertiesPolicyOverride : System.IEquatable<Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityPropertiesPolicyOverride(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride Enclave { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride left, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride left, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DedicatedHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>
    {
        public DedicatedHubProperties() { }
        public Azure.ResourceManager.Enclave.Models.Designation? Designation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FirewallPolicyResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FirewallResourceId { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VHubResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.DedicatedHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.DedicatedHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.DedicatedHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.DedicatedHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHubResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>
    {
        public DedicatedHubResourcePatch() { }
        public Azure.ResourceManager.Enclave.Models.Designation? DedicatedHubPatchDesignation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.DedicatedHubResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Designation : System.IEquatable<Azure.ResourceManager.Enclave.Models.Designation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Designation(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.Designation Pooled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.Designation Reserved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.Designation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.Designation left, Azure.ResourceManager.Enclave.Models.Designation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.Designation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.Designation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.Designation left, Azure.ResourceManager.Enclave.Models.Designation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveAddressSpaces : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>
    {
        internal EnclaveAddressSpaces() { }
        public string EnclaveAddressSpace { get { throw null; } }
        public string ManagedAddressSpace { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveConnectionState : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState Active { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState Connected { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionState PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState left, Azure.ResourceManager.Enclave.Models.EnclaveConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveConnectionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState left, Azure.ResourceManager.Enclave.Models.EnclaveConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveDefaultSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>
    {
        public EnclaveDefaultSettings() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination? DiagnosticDestination { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> LogAnalyticsResourceIdCollection { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveEndpointDestinationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>
    {
        public EnclaveEndpointDestinationRule() { }
        public string Destination { get { throw null; } set { } }
        public string EndpointRuleName { get { throw null; } set { } }
        public string Ports { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol> Protocols { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveEndpointPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>
    {
        public EnclaveEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.UpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveEndpointProtocol : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol Any { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol left, Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol left, Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveVirtualNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>
    {
        public EnclaveVirtualNetwork() { }
        public bool? AllowSubnetCommunication { get { throw null; } set { } }
        public string CustomCidrRange { get { throw null; } set { } }
        public string NetworkName { get { throw null; } set { } }
        public string NetworkSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration> SubnetConfigurations { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernedServiceItemEnforcement : System.IEquatable<Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernedServiceItemEnforcement(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernedServiceItemOption : System.IEquatable<Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernedServiceItemOption(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption Allow { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption Deny { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption ExceptionOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernedServiceItemPolicyAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernedServiceItemPolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction AuditOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction Enforce { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction left, Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceModeConfigurationModelJustification : System.IEquatable<Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceModeConfigurationModelJustification(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification Governance { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification Networking { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification left, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification left, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceModeConfigurationModelMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceModeConfigurationModelMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode Advanced { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode General { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode Off { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode left, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode left, Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoboBrokerResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>
    {
        internal MoboBrokerResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.MoboBrokerResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.MoboBrokerResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.MoboBrokerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.MoboBrokerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MoboBrokerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>
    {
        public MonitoringDestination(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType destinationType) { }
        public Azure.Core.ResourceIdentifier CustomWorkspaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MonitoringDestinationType DestinationType { get { throw null; } set { } }
        public string DiagnosticSettingsName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.MonitoringDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.MonitoringDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringDestinationPatchModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>
    {
        public MonitoringDestinationPatchModel(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType destinationType) { }
        public Azure.Core.ResourceIdentifier CustomWorkspaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MonitoringDestinationType DestinationType { get { throw null; } }
        public string DiagnosticSettingsName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringDestinationType : System.IEquatable<Azure.ResourceManager.Enclave.Models.MonitoringDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.MonitoringDestinationType CommunityWorkspace { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MonitoringDestinationType CustomWorkspace { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.MonitoringDestinationType EnclaveWorkspace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType left, Azure.ResourceManager.Enclave.Models.MonitoringDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MonitoringDestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.MonitoringDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.MonitoringDestinationType left, Azure.ResourceManager.Enclave.Models.MonitoringDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringSettingsModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>
    {
        public MonitoringSettingsModel() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.MonitoringDestination> DiagnosticDestinations { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.MonitoringDestination FlowLogDestination { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringSettingsPatchModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>
    {
        public MonitoringSettingsPatchModel() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel> DiagnosticDestinations { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.MonitoringDestinationPatchModel FlowLogDestination { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.Enclave.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.PrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.PrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.PrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.PrincipalType left, Azure.ResourceManager.Enclave.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.PrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.PrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.PrincipalType left, Azure.ResourceManager.Enclave.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RbacInheritanceMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.RbacInheritanceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RbacInheritanceMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.RbacInheritanceMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.RbacInheritanceMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.RbacInheritanceMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.RbacInheritanceMode left, Azure.ResourceManager.Enclave.Models.RbacInheritanceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.RbacInheritanceMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.RbacInheritanceMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.RbacInheritanceMode left, Azure.ResourceManager.Enclave.Models.RbacInheritanceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceVisibilityMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceVisibilityMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode left, Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode left, Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityProvider : System.IEquatable<Azure.ResourceManager.Enclave.Models.SecurityProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityProvider(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.SecurityProvider AzureFirewall { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.SecurityProvider None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.SecurityProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.SecurityProvider left, Azure.ResourceManager.Enclave.Models.SecurityProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.SecurityProvider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.SecurityProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.SecurityProvider left, Azure.ResourceManager.Enclave.Models.SecurityProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransitHubState : System.IEquatable<Azure.ResourceManager.Enclave.Models.TransitHubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransitHubState(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.TransitHubState Active { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitHubState Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitHubState Failed { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitHubState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitHubState PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.TransitHubState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.TransitHubState left, Azure.ResourceManager.Enclave.Models.TransitHubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.TransitHubState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.TransitHubState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.TransitHubState left, Azure.ResourceManager.Enclave.Models.TransitHubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransitOptionParams : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>
    {
        public TransitOptionParams() { }
        public Azure.Core.ResourceIdentifier RemoteVirtualNetworkId { get { throw null; } set { } }
        public long? ScaleUnits { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.TransitOptionParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.TransitOptionParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.TransitOptionParams System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.TransitOptionParams System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.TransitOptionParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransitOptionType : System.IEquatable<Azure.ResourceManager.Enclave.Models.TransitOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransitOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.TransitOptionType ExpressRoute { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitOptionType Gateway { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.TransitOptionType Peering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.TransitOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.TransitOptionType left, Azure.ResourceManager.Enclave.Models.TransitOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.TransitOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.TransitOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.TransitOptionType left, Azure.ResourceManager.Enclave.Models.TransitOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.UpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.UpdateMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.UpdateMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.UpdateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.UpdateMode left, Azure.ResourceManager.Enclave.Models.UpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.UpdateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.UpdateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.UpdateMode left, Azure.ResourceManager.Enclave.Models.UpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprovalPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>
    {
        public VirtualEnclaveApprovalPatch() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>
    {
        public VirtualEnclaveApprovalPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch requestMetadata) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover> Approvers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch RequestMetadata { get { throw null; } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveApprovalPolicy : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveApprovalPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy NotRequired { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprovalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>
    {
        public VirtualEnclaveApprovalProperties(Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata requestMetadata) { }
        public System.Collections.Generic.IReadOnlyList<string> ApprovedByEntraIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover> Approvers { get { throw null; } }
        public long? ApproversApprovedCount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
        public long? MandatoryApproversApprovedCount { get { throw null; } }
        public long? MinimumApproversRequired { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata RequestMetadata { get { throw null; } set { } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>
    {
        public VirtualEnclaveApprovalSettings() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalSettingsPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>
    {
        public VirtualEnclaveApprovalSettingsPatchProperties() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveApprovalStatus : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>
    {
        public VirtualEnclaveApprover(string approverEntraId, System.DateTimeOffset lastUpdatedOn) { }
        public Azure.ResourceManager.Enclave.Models.ApproverActionPerformed? ActionPerformed { get { throw null; } set { } }
        public string ApproverEntraId { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> MandatoryApprovalGroupMembershipIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveBaseApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>
    {
        public VirtualEnclaveBaseApprovalSettings() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityMaintenanceMode { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>
    {
        public VirtualEnclaveCommunityEndpointPatch() { }
        public Azure.ResourceManager.Enclave.Models.CommunityEndpointPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>
    {
        public VirtualEnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.CommunityEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.UpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>
    {
        public VirtualEnclaveCommunityPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>
    {
        public VirtualEnclaveCommunityPatchProperties() { }
        public System.Collections.Generic.IList<string> AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties GranularApprovalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? PolicyOverride { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>
    {
        public VirtualEnclaveCommunityProperties() { }
        public string AddressSpace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.DedicatedHubResourceData> DedicatedHubList { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveBaseApprovalSettings GranularApprovalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? PolicyOverride { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveCommunityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>
    {
        public VirtualEnclaveConnectionPatch() { }
        public string EnclaveConnectionPatchSourceCidr { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>
    {
        public VirtualEnclaveConnectionProperties(Azure.Core.ResourceIdentifier communityResourceId, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier destinationEndpointId) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public string SourceCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveConnectionState? State { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.UpdateMode? UpdateMode { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveDiagnosticDestination : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveDiagnosticDestination(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination Both { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination CommunityOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination EnclaveOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>
    {
        public VirtualEnclaveEndpointPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>
    {
        public VirtualEnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.UpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveFirewallSku : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveFirewallSku(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku Basic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku Premium { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveFirewallSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveGovernedService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>
    {
        public VirtualEnclaveGovernedService(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier serviceId) { }
        public Azure.ResourceManager.Enclave.Models.GovernedServiceItemEnforcement? Enforcement { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Initiatives { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.GovernedServiceItemOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.GovernedServiceItemPolicyAction? PolicyAction { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier ServiceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveGovernedServiceIdentifier : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveGovernedServiceIdentifier(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier Aks { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier AppService { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier AzureFirewalls { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier ContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier DataConnectors { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier Insights { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier Logic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier MicrosoftSql { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier Monitoring { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier PrivateDnsZones { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier ServiceBus { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier Storage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedServiceIdentifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveMaintenanceModeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>
    {
        public VirtualEnclaveMaintenanceModeConfiguration(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode mode) { }
        public Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveMaintenanceModeConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>
    {
        public VirtualEnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode mode) { }
        public Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MaintenanceModeConfigurationModelMode Mode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveMandatoryApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>
    {
        public VirtualEnclaveMandatoryApprover(string approverEntraId) { }
        public string ApproverEntraId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveMandatoryApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>
    {
        public VirtualEnclavePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>
    {
        public VirtualEnclavePatchProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettingsPatchProperties ApprovalSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DedicatedHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveDiagnosticDestination? EnclaveDefaultDiagnosticDestination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.MonitoringSettingsPatchModel MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.RbacInheritanceMode? RbacInheritance { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode? WorkloadResourceVisibility { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>
    {
        public VirtualEnclavePrincipal(string id, Azure.ResourceManager.Enclave.Models.PrincipalType type) { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.PrincipalType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>
    {
        public VirtualEnclaveProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork, Azure.Core.ResourceIdentifier communityResourceId) { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveApprovalSettings ApprovalSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DedicatedHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces EnclaveAddressSpaces { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings EnclaveDefaultSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.MonitoringSettingsModel MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.RbacInheritanceMode? RbacInheritance { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ResourceVisibilityMode? WorkloadResourceVisibility { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveProvisioningState : System.IEquatable<Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState left, Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveRoleAssignmentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>
    {
        public VirtualEnclaveRoleAssignmentItem(string roleDefinitionId) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveRoleAssignmentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveSubnetConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>
    {
        public VirtualEnclaveSubnetConfiguration(string subnetName, int networkPrefixSize) { }
        public string AddressPrefix { get { throw null; } }
        public int NetworkPrefixSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupResourceId { get { throw null; } }
        public string SubnetDelegation { get { throw null; } set { } }
        public string SubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveSubnetConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>
    {
        public VirtualEnclaveTransitHubPatch() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>
    {
        public VirtualEnclaveTransitHubPatchProperties() { }
        public Azure.ResourceManager.Enclave.Models.SecurityProvider? SecurityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.TransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>
    {
        public VirtualEnclaveTransitHubProperties() { }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.SecurityProvider? SecurityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.TransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitOptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>
    {
        public VirtualEnclaveTransitOptionProperties() { }
        public Azure.ResourceManager.Enclave.Models.TransitOptionParams Params { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.TransitOptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveTransitOptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>
    {
        public VirtualEnclaveWorkloadPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> WorkloadPatchResourceGroupCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>
    {
        public VirtualEnclaveWorkloadProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroupCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.VirtualEnclaveWorkloadProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
