namespace Azure.ResourceManager.VirtualEnclaves
{
    public partial class AzureResourceManagerVirtualEnclavesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerVirtualEnclavesContext() { }
        public static Azure.ResourceManager.VirtualEnclaves.AzureResourceManagerVirtualEnclavesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class VirtualEnclaveApprovalCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveApprovalCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> Get(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> GetAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> GetIfExists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> GetIfExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveApprovalData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>
    {
        public VirtualEnclaveApprovalData() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveApprovalResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string approvalName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> NotifyInitiator(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> NotifyInitiatorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> Get(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> GetAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetIfExists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> GetIfExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> Get(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> GetAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetIfExists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> GetIfExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>
    {
        public VirtualEnclaveCommunityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveCommunityEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> Get(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> GetAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetIfExists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> GetIfExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>
    {
        public VirtualEnclaveCommunityEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveCommunityEndpointResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string communityEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveCommunityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveCommunityResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult> CheckAddressSpaceAvailability(Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>> CheckAddressSpaceAvailabilityAsync(Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoint(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource>> GetVirtualEnclaveCommunityEndpointAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointCollection GetVirtualEnclaveCommunityEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHub(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> GetVirtualEnclaveTransitHubAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubCollection GetVirtualEnclaveTransitHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> Get(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> GetAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetIfExists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> GetIfExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>
    {
        public VirtualEnclaveConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveConnectionResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enclaveConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>
    {
        public VirtualEnclaveData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> Get(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> GetAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetIfExists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> GetIfExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>
    {
        public VirtualEnclaveEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveEndpointResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string enclaveEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoint(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource>> GetVirtualEnclaveEndpointAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointCollection GetVirtualEnclaveEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkload(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> GetVirtualEnclaveWorkloadAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadCollection GetVirtualEnclaveWorkloads() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class VirtualEnclavesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclave(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> GetVirtualEnclaveApproval(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> GetVirtualEnclaveApprovalAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource GetVirtualEnclaveApprovalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalCollection GetVirtualEnclaveApprovals(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> GetVirtualEnclaveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityCollection GetVirtualEnclaveCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> GetVirtualEnclaveCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource GetVirtualEnclaveCommunityEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource GetVirtualEnclaveCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> GetVirtualEnclaveConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource GetVirtualEnclaveConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionCollection GetVirtualEnclaveConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource GetVirtualEnclaveEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource GetVirtualEnclaveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCollection GetVirtualEnclaves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclaves(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclavesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource GetVirtualEnclaveTransitHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource GetVirtualEnclaveWorkloadResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloads(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloadsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveTransitHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> Get(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> GetAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetIfExists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> GetIfExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveTransitHubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>
    {
        public VirtualEnclaveTransitHubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveTransitHubResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string transitHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>, System.Collections.IEnumerable
    {
        protected VirtualEnclaveWorkloadCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> Get(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> GetAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetIfExists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> GetIfExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEnclaveWorkloadData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>
    {
        public VirtualEnclaveWorkloadData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEnclaveWorkloadResource() { }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string workloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.VirtualEnclaves.Mocking
{
    public partial class MockableVirtualEnclavesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableVirtualEnclavesArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource> GetVirtualEnclaveApproval(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource>> GetVirtualEnclaveApprovalAsync(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalResource GetVirtualEnclaveApprovalResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalCollection GetVirtualEnclaveApprovals(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource GetVirtualEnclaveCommunityEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource GetVirtualEnclaveCommunityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource GetVirtualEnclaveConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource GetVirtualEnclaveEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource GetVirtualEnclaveResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource GetVirtualEnclaveTransitHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource GetVirtualEnclaveWorkloadResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableVirtualEnclavesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVirtualEnclavesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclave(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource>> GetVirtualEnclaveAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityCollection GetVirtualEnclaveCommunities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunity(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource>> GetVirtualEnclaveCommunityAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnection(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource>> GetVirtualEnclaveConnectionAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionCollection GetVirtualEnclaveConnections() { throw null; }
        public virtual Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCollection GetVirtualEnclaves() { throw null; }
    }
    public partial class MockableVirtualEnclavesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVirtualEnclavesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityResource> GetVirtualEnclaveCommunitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpoints(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointResource> GetVirtualEnclaveCommunityEndpointsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionResource> GetVirtualEnclaveConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpoints(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointResource> GetVirtualEnclaveEndpointsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclaves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveResource> GetVirtualEnclavesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubs(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubResource> GetVirtualEnclaveTransitHubsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloads(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadResource> GetVirtualEnclaveWorkloadsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.VirtualEnclaves.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionPerformed : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionPerformed(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed left, Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed left, Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApprovalActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>
    {
        public ApprovalActionContent(Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus approvalStatus) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus ApprovalStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>
    {
        internal ApprovalActionResult() { }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalCallbackContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>
    {
        public ApprovalCallbackContent(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction resourceRequestAction, Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus approvalStatus) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus ApprovalStatus { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction ResourceRequestAction { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalDeletionCallbackContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>
    {
        public ApprovalDeletionCallbackContent(Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction resourceRequestAction) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction ResourceRequestAction { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalDeletionCallbackContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>
    {
        public ApprovalRequestMetadata(string resourceAction) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public string ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
        public string ResourceAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApprovalRequestMetadataPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>
    {
        public ApprovalRequestMetadataPatch(string resourceAction) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public string ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
        public string ResourceAction { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmVirtualEnclavesModelFactory
    {
        public static Azure.ResourceManager.VirtualEnclaves.Models.ApprovalActionResult ApprovalActionResult(string message = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ApprovalCallbackContent ApprovalCallbackContent(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction resourceRequestAction = default(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction), Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus approvalStatus = default(Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus), string approvalCallbackPayload = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch ApprovalRequestMetadataPatch(string resourceAction = null, string approvalCallbackRoute = null, string approvalCallbackPayload = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus? approvalStatus = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus?)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult CheckAddressSpaceAvailabilityResult(bool isAvailable = false) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces EnclaveAddressSpaces(string enclaveAddressSpace = null, string managedAddressSpace = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings EnclaveDefaultSettings(Azure.Core.ResourceIdentifier keyVaultResourceId = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> logAnalyticsResourceIdCollection = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination? diagnosticDestination = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination?)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveApprovalData VirtualEnclaveApprovalData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties VirtualEnclaveApprovalPatchProperties(Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties VirtualEnclaveApprovalProperties(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityData VirtualEnclaveCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveCommunityEndpointData VirtualEnclaveCommunityEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties VirtualEnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties VirtualEnclaveCommunityProperties(string addressSpace = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride? policyOverride = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> communityRoleAssignments = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku? firewallSku = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku?), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings approvalSettings = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveConnectionData VirtualEnclaveConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties VirtualEnclaveConnectionProperties(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState? state = default(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState?), Azure.Core.ResourceIdentifier communityResourceId = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string sourceCidr = null, Azure.Core.ResourceIdentifier destinationEndpointId = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveData VirtualEnclaveData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveEndpointData VirtualEnclaveEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties VirtualEnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService VirtualEnclaveGovernedService(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier serviceId = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier), string serviceName = null, Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType? option = default(Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType?), Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement? enforcement = default(Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement?), Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction? policyAction = default(Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction?), System.Collections.Generic.IEnumerable<string> initiatives = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch VirtualEnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode mode = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal> principals = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification? justification = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification?)) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties VirtualEnclavePatchProperties(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, bool? isBastionEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination? enclaveDefaultDiagnosticDestination = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination?), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch maintenanceModeConfiguration = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties VirtualEnclaveProperties(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces enclaveAddressSpaces = null, Azure.Core.ResourceIdentifier communityResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, bool? isBastionEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings enclaveDefaultSettings = null, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration VirtualEnclaveSubnetConfiguration(string subnetName = null, Azure.Core.ResourceIdentifier subnetResourceId = null, int networkPrefixSize = 0, string subnetDelegation = null, string addressPrefix = null, Azure.Core.ResourceIdentifier networkSecurityGroupResourceId = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveTransitHubData VirtualEnclaveTransitHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties VirtualEnclaveTransitHubProperties(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState? state = default(Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState?), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties transitOption = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.VirtualEnclaveWorkloadData VirtualEnclaveWorkloadData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties properties = null) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties VirtualEnclaveWorkloadProperties(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState?), System.Collections.Generic.IEnumerable<string> resourceGroupCollection = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
    }
    public partial class CheckAddressSpaceAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>
    {
        public CheckAddressSpaceAvailabilityContent(Azure.Core.ResourceIdentifier communityResourceId, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork enclaveVirtualNetwork) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckAddressSpaceAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>
    {
        internal CheckAddressSpaceAvailabilityResult() { }
        public bool IsAvailable { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CheckAddressSpaceAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunityEndpointDestinationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>
    {
        public CommunityEndpointDestinationRule() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType? DestinationType { get { throw null; } set { } }
        public string EndpointRuleName { get { throw null; } set { } }
        public string Ports { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol> Protocols { get { throw null; } }
        public Azure.Core.ResourceIdentifier TransitHubResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityEndpointDestinationType : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityEndpointDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType Fqdn { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType FqdnTag { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType IPAddress { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType PrivateNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType left, Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType left, Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityEndpointProtocol : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Any { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol left, Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol left, Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveAddressSpaces : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>
    {
        internal EnclaveAddressSpaces() { }
        public string EnclaveAddressSpace { get { throw null; } }
        public string ManagedAddressSpace { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveConnectionState : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState Active { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState Connected { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState Failed { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState left, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState left, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveDefaultSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>
    {
        public EnclaveDefaultSettings() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination? DiagnosticDestination { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> LogAnalyticsResourceIdCollection { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveEndpointDestinationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>
    {
        public EnclaveEndpointDestinationRule() { }
        public string Destination { get { throw null; } set { } }
        public string EndpointRuleName { get { throw null; } set { } }
        public string Ports { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol> Protocols { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveEndpointProtocol : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol Any { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol left, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol left, Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveVirtualNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>
    {
        public EnclaveVirtualNetwork() { }
        public bool? AllowSubnetCommunication { get { throw null; } set { } }
        public string CustomCidrRange { get { throw null; } set { } }
        public string NetworkName { get { throw null; } set { } }
        public string NetworkSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration> SubnetConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostActionApprovalStatus : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostActionApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostActionCallbackApprovalStatus : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostActionCallbackApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionCallbackApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostActionDeletionResourceRequestAction : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostActionDeletionResourceRequestAction(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction Create { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction Delete { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionDeletionResourceRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostActionResourceRequestAction : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostActionResourceRequestAction(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction Create { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction Delete { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction Reset { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction left, Azure.ResourceManager.VirtualEnclaves.Models.PostActionResourceRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceEnforcementPolicyAction : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceEnforcementPolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction AuditOnly { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction Enforce { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceGovernanceOptionType : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceGovernanceOptionType(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType Allow { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType Deny { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType ExceptionOnly { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceInitiativeEnforcement : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceInitiativeEnforcement(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement Disabled { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement left, Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransitHubState : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransitHubState(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState Active { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState Failed { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState left, Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState left, Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransitOptionParams : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>
    {
        public TransitOptionParams() { }
        public Azure.Core.ResourceIdentifier RemoteVirtualNetworkId { get { throw null; } set { } }
        public long? ScaleUnits { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransitOptionType : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransitOptionType(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType ExpressRoute { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType Gateway { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType Peering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType left, Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType left, Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprovalPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>
    {
        public VirtualEnclaveApprovalPatch() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>
    {
        public VirtualEnclaveApprovalPatchProperties(Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch requestMetadata) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover> Approvers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadataPatch RequestMetadata { get { throw null; } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveApprovalPolicy : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveApprovalPolicy(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy NotRequired { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprovalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>
    {
        public VirtualEnclaveApprovalProperties(Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata requestMetadata) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover> Approvers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.ApprovalRequestMetadata RequestMetadata { get { throw null; } set { } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>
    {
        public VirtualEnclaveApprovalSettings() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? ConnectionDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? EnclaveCreation { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? EnclaveDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? EndpointCreation { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? EndpointDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? EndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? MaintenanceMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
        public long? MinimumApproversRequired { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? NotificationOnApprovalAction { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? NotificationOnApprovalCreation { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? NotificationOnApprovalDeletion { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalPolicy? ServiceCatalogDeployment { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveApprovalStatus : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>
    {
        public VirtualEnclaveApprover(string approverEntraId, System.DateTimeOffset lastUpdatedOn) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.ActionPerformed? ActionPerformed { get { throw null; } set { } }
        public string ApproverEntraId { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>
    {
        public VirtualEnclaveCommunityEndpointPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule> CommunityEndpointPatchRuleCollection { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>
    {
        public VirtualEnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.CommunityEndpointDestinationRule> RuleCollection { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>
    {
        public VirtualEnclaveCommunityPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveCommunityPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>
    {
        public VirtualEnclaveCommunityPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover> ApprovalMandatoryApprovers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride? PolicyOverride { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveCommunityPolicyOverride : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveCommunityPolicyOverride(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride Enclave { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveCommunityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>
    {
        public VirtualEnclaveCommunityProperties() { }
        public string AddressSpace { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveApprovalSettings ApprovalSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityPolicyOverride? PolicyOverride { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveCommunityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>
    {
        public VirtualEnclaveConnectionPatch() { }
        public string EnclaveConnectionPatchSourceCidr { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>
    {
        public VirtualEnclaveConnectionProperties(Azure.Core.ResourceIdentifier communityResourceId, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier destinationEndpointId) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public string SourceCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveConnectionState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveDiagnosticDestination : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveDiagnosticDestination(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination Both { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination CommunityOnly { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination EnclaveOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>
    {
        public VirtualEnclaveEndpointPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule> EnclaveEndpointPatchRuleCollection { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>
    {
        public VirtualEnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveFirewallSku : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveFirewallSku(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku Basic { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku Premium { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveFirewallSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveGovernedService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>
    {
        public VirtualEnclaveGovernedService(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier serviceId) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.ServiceInitiativeEnforcement? Enforcement { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Initiatives { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.ServiceGovernanceOptionType? Option { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.ServiceEnforcementPolicyAction? PolicyAction { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier ServiceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveGovernedServiceIdentifier : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveGovernedServiceIdentifier(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier Aks { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier AppService { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier AzureFirewalls { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier ContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier DataConnectors { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier Insights { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier KeyVault { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier Logic { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier MicrosoftSql { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier Monitoring { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier PrivateDnsZones { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier ServiceBus { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier Storage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedServiceIdentifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveMaintenanceJustification : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveMaintenanceJustification(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification Governance { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification Networking { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveMaintenanceMode : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveMaintenanceMode(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode Advanced { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode General { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode Off { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveMaintenanceModeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>
    {
        public VirtualEnclaveMaintenanceModeConfiguration(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode mode) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveMaintenanceModeConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>
    {
        public VirtualEnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode mode) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceMode Mode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveMandatoryApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>
    {
        public VirtualEnclaveMandatoryApprover(string approverEntraId) { }
        public string ApproverEntraId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMandatoryApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>
    {
        public VirtualEnclavePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>
    {
        public VirtualEnclavePatchProperties(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork enclaveVirtualNetwork) { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveDiagnosticDestination? EnclaveDefaultDiagnosticDestination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclavePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>
    {
        public VirtualEnclavePrincipal(string id, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType type) { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclavePrincipalType : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclavePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>
    {
        public VirtualEnclaveProperties(Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork enclaveVirtualNetwork, Azure.Core.ResourceIdentifier communityResourceId) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveAddressSpaces EnclaveAddressSpaces { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveDefaultSettings EnclaveDefaultSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEnclaveProvisioningState : System.IEquatable<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEnclaveProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState left, Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualEnclaveRoleAssignmentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>
    {
        public VirtualEnclaveRoleAssignmentItem(string roleDefinitionId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclavePrincipal> Principals { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveRoleAssignmentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveSubnetConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>
    {
        public VirtualEnclaveSubnetConfiguration(string subnetName, int networkPrefixSize) { }
        public string AddressPrefix { get { throw null; } }
        public int NetworkPrefixSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupResourceId { get { throw null; } }
        public string SubnetDelegation { get { throw null; } set { } }
        public string SubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveSubnetConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>
    {
        public VirtualEnclaveTransitHubPatch() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>
    {
        public VirtualEnclaveTransitHubPatchProperties() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>
    {
        public VirtualEnclaveTransitHubProperties() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.TransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveTransitOptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>
    {
        public VirtualEnclaveTransitOptionProperties() { }
        public Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionParams Params { get { throw null; } set { } }
        public Azure.ResourceManager.VirtualEnclaves.Models.TransitOptionType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveTransitOptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>
    {
        public VirtualEnclaveWorkloadPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> WorkloadPatchResourceGroupCollection { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEnclaveWorkloadProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>
    {
        public VirtualEnclaveWorkloadProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroupCollection { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VirtualEnclaves.Models.VirtualEnclaveWorkloadProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
