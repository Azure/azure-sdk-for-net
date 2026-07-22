namespace Azure.ResourceManager.Enclave
{
    public partial class AzureResourceManagerEnclaveContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEnclaveContext() { }
        public static Azure.ResourceManager.Enclave.AzureResourceManagerEnclaveContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EnclaveApprovalCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveApprovalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveApprovalResource>, System.Collections.IEnumerable
    {
        protected EnclaveApprovalCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveApprovalResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.Enclave.EnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string approvalName, Azure.ResourceManager.Enclave.EnclaveApprovalData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource> Get(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveApprovalResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveApprovalResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> GetAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveApprovalResource> GetIfExists(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> GetIfExistsAsync(string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveApprovalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveApprovalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveApprovalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveApprovalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveApprovalData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>
    {
        public EnclaveApprovalData() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveApprovalResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveApprovalResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveApprovalData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string approvalName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> NotifyInitiator(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> NotifyInitiatorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveApprovalData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveApprovalData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveApprovalData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveApprovalResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveResource>, System.Collections.IEnumerable
    {
        protected EnclaveCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.Enclave.EnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualEnclaveName, Azure.ResourceManager.Enclave.EnclaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> Get(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> GetAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveResource> GetIfExists(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveResource>> GetIfExistsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityResource>, System.Collections.IEnumerable
    {
        protected EnclaveCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.Enclave.EnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityName, Azure.ResourceManager.Enclave.EnclaveCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> Get(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> GetAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetIfExists(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> GetIfExistsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveCommunityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>
    {
        public EnclaveCommunityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>, System.Collections.IEnumerable
    {
        protected EnclaveCommunityEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communityEndpointName, Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> Get(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> GetAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetIfExists(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> GetIfExistsAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveCommunityEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>
    {
        public EnclaveCommunityEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveCommunityEndpointResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string communityEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveCommunityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveCommunityResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult> CheckAddressSpaceAvailability(Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult>> CheckAddressSpaceAvailabilityAsync(Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetEnclaveCommunityEndpoint(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource>> GetEnclaveCommunityEndpointAsync(string communityEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityEndpointCollection GetEnclaveCommunityEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetEnclaveDedicatedHub(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> GetEnclaveDedicatedHubAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveDedicatedHubCollection GetEnclaveDedicatedHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetEnclaveTransitHub(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> GetEnclaveTransitHubAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveTransitHubCollection GetEnclaveTransitHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveConnectionResource>, System.Collections.IEnumerable
    {
        protected EnclaveConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.Enclave.EnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveConnectionName, Azure.ResourceManager.Enclave.EnclaveConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> Get(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> GetAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetIfExists(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> GetIfExistsAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>
    {
        public EnclaveConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveConnectionResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enclaveConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>
    {
        public EnclaveData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveDedicatedHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>, System.Collections.IEnumerable
    {
        protected EnclaveDedicatedHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dedicatedHubName, Azure.ResourceManager.Enclave.EnclaveDedicatedHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dedicatedHubName, Azure.ResourceManager.Enclave.EnclaveDedicatedHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> Get(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> GetAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetIfExists(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> GetIfExistsAsync(string dedicatedHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveDedicatedHubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>
    {
        public EnclaveDedicatedHubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveDedicatedHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveDedicatedHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveDedicatedHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveDedicatedHubResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveDedicatedHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string dedicatedHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveDedicatedHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveDedicatedHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveEndpointResource>, System.Collections.IEnumerable
    {
        protected EnclaveEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.Enclave.EnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enclaveEndpointName, Azure.ResourceManager.Enclave.EnclaveEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> Get(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> GetAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetIfExists(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> GetIfExistsAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>
    {
        public EnclaveEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveEndpointResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string enclaveEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EnclaveExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclave(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource> GetEnclaveApproval(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> GetEnclaveApprovalAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveApprovalResource GetEnclaveApprovalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveApprovalCollection GetEnclaveApprovals(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> GetEnclaveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCommunityCollection GetEnclaveCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> GetEnclaveCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource GetEnclaveCommunityEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetEnclaveCommunityEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetEnclaveCommunityEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCommunityResource GetEnclaveCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> GetEnclaveConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveConnectionResource GetEnclaveConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveConnectionCollection GetEnclaveConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource GetEnclaveDedicatedHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetEnclaveDedicatedHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetEnclaveDedicatedHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveEndpointResource GetEnclaveEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetEnclaveEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetEnclaveEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveResource GetEnclaveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCollection GetEnclaves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclaves(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclavesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveTransitHubResource GetEnclaveTransitHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetEnclaveTransitHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetEnclaveTransitHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveWorkloadResource GetEnclaveWorkloadResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetEnclaveWorkloads(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetEnclaveWorkloadsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetEnclaveEndpoint(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveEndpointResource>> GetEnclaveEndpointAsync(string enclaveEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveEndpointCollection GetEnclaveEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetEnclaveWorkload(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> GetEnclaveWorkloadAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveWorkloadCollection GetEnclaveWorkloads() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalCreation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalCreationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult> HandleApprovalDeletion(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.Models.ApprovalActionResult>> HandleApprovalDeletionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclavePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveTransitHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>, System.Collections.IEnumerable
    {
        protected EnclaveTransitHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.Enclave.EnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transitHubName, Azure.ResourceManager.Enclave.EnclaveTransitHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> Get(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> GetAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetIfExists(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> GetIfExistsAsync(string transitHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveTransitHubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>
    {
        public EnclaveTransitHubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveTransitHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveTransitHubResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveTransitHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communityName, string transitHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveTransitHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveTransitHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveTransitHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveTransitHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnclaveWorkloadCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>, System.Collections.IEnumerable
    {
        protected EnclaveWorkloadCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.Enclave.EnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadName, Azure.ResourceManager.Enclave.EnclaveWorkloadData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> Get(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> GetAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetIfExists(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> GetIfExistsAsync(string workloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnclaveWorkloadData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>
    {
        public EnclaveWorkloadData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveWorkloadResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnclaveWorkloadResource() { }
        public virtual Azure.ResourceManager.Enclave.EnclaveWorkloadData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualEnclaveName, string workloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Enclave.EnclaveWorkloadData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.EnclaveWorkloadData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.EnclaveWorkloadData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Enclave.EnclaveWorkloadResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Enclave.Mocking
{
    public partial class MockableEnclaveArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource> GetEnclaveApproval(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveApprovalResource>> GetEnclaveApprovalAsync(Azure.Core.ResourceIdentifier scope, string approvalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveApprovalResource GetEnclaveApprovalResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveApprovalCollection GetEnclaveApprovals(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource GetEnclaveCommunityEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityResource GetEnclaveCommunityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveConnectionResource GetEnclaveConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource GetEnclaveDedicatedHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveEndpointResource GetEnclaveEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveResource GetEnclaveResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveTransitHubResource GetEnclaveTransitHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveWorkloadResource GetEnclaveWorkloadResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEnclaveResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclave(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveResource>> GetEnclaveAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveCommunityCollection GetEnclaveCommunities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunity(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveCommunityResource>> GetEnclaveCommunityAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnection(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Enclave.EnclaveConnectionResource>> GetEnclaveConnectionAsync(string enclaveConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveConnectionCollection GetEnclaveConnections() { throw null; }
        public virtual Azure.ResourceManager.Enclave.EnclaveCollection GetEnclaves() { throw null; }
    }
    public partial class MockableEnclaveSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnclaveSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityResource> GetEnclaveCommunitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetEnclaveCommunityEndpoints(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveCommunityEndpointResource> GetEnclaveCommunityEndpointsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveConnectionResource> GetEnclaveConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetEnclaveDedicatedHubs(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubResource> GetEnclaveDedicatedHubsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetEnclaveEndpoints(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveEndpointResource> GetEnclaveEndpointsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclaves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveResource> GetEnclavesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetEnclaveTransitHubs(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveTransitHubResource> GetEnclaveTransitHubsAsync(string communityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetEnclaveWorkloads(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Enclave.EnclaveWorkloadResource> GetEnclaveWorkloadsAsync(string virtualEnclaveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ApprovalCallbackContent(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction resourceRequestAction, Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus approvalStatus) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus ApprovalStatus { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction ResourceRequestAction { get { throw null; } }
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
    public partial class ApprovalDeletionCallbackContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent>
    {
        public ApprovalDeletionCallbackContent(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction resourceRequestAction) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction ResourceRequestAction { get { throw null; } }
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
    public partial class ApprovalRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata>
    {
        public ApprovalRequestMetadata(string resourceAction) { }
        public string ApprovalCallbackPayload { get { throw null; } set { } }
        public string ApprovalCallbackRoute { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
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
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus? ApprovalStatus { get { throw null; } set { } }
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
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy? ApprovalPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
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
        public static Azure.ResourceManager.Enclave.Models.ApprovalCallbackContent ApprovalCallbackContent(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction resourceRequestAction = default(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction), Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus approvalStatus = default(Azure.ResourceManager.Enclave.Models.ApprovalCallbackRequestApprovalStatus), string approvalCallbackPayload = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalDeletionCallbackContent ApprovalDeletionCallbackContent(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction resourceRequestAction = default(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata ApprovalRequestMetadata(string resourceAction = null, string approvalCallbackRoute = null, string approvalCallbackPayload = null, Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus? approvalStatus = default(Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch ApprovalRequestMetadataPatch(string resourceAction = null, string approvalCallbackRoute = null, string approvalCallbackPayload = null, Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus? approvalStatus = default(Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ApprovalSettingConfiguration(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy? approvalPolicy = default(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy?), int? minimumApproversRequired = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover> mandatoryApprovers = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties ApprovalSettingsPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityMaintenanceMode = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityContent CheckAddressSpaceAvailabilityContent(Azure.Core.ResourceIdentifier communityResourceId = null, Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.CheckAddressSpaceAvailabilityResult CheckAddressSpaceAvailabilityResult(bool isAvailable = false) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces EnclaveAddressSpaces(string enclaveAddressSpace = null, string managedAddressSpace = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveApprovalData EnclaveApprovalData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch EnclaveApprovalPatch(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties EnclaveApprovalPatchProperties(Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties EnclaveApprovalProperties(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), Azure.Core.ResourceIdentifier parentResourceId = null, Azure.Core.ResourceIdentifier grandparentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveApprover> approvers = null, string ticketId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? stateChangedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover> mandatoryApprovers = null, long? minimumApproversRequired = default(long?), long? approversApprovedCount = default(long?), long? mandatoryApproversApprovedCount = default(long?), System.Collections.Generic.IEnumerable<string> approvedByEntraIds = null, Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata requestMetadata = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings EnclaveApprovalSettings(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties EnclaveApprovalSettingsPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprover EnclaveApprover(string approverEntraId = null, Azure.ResourceManager.Enclave.Models.ApproverActionPerformed? actionPerformed = default(Azure.ResourceManager.Enclave.Models.ApproverActionPerformed?), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<string> mandatoryApprovalGroupMembershipIds = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings EnclaveBaseApprovalSettings(Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveEndpointUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionCreation = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration connectionUpdate = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration communityMaintenanceMode = null, Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration enclaveMaintenanceMode = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCommunityData EnclaveCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveCommunityEndpointData EnclaveCommunityEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule EnclaveCommunityEndpointDestinationRule(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType? destinationType = default(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol> protocols = null, Azure.Core.ResourceIdentifier transitHubResourceId = null, string endpointRuleName = null, string destination = null, string ports = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch EnclaveCommunityEndpointPatch(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties EnclaveCommunityEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> ruleCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties EnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch EnclaveCommunityPatch(Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties EnclaveCommunityPatchProperties(System.Collections.Generic.IEnumerable<string> dnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? policyOverride = default(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> communityRoleAssignments = null, Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku? firewallSku = default(Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku?), Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties granularApprovalSettings = null, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch maintenanceModeConfiguration = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch monitoringSettings = null, System.Collections.Generic.IEnumerable<string> addressSpaces = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties EnclaveCommunityProperties(string addressSpace = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? policyOverride = default(Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> communityRoleAssignments = null, Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku? firewallSku = default(Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku?), Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings granularApprovalSettings = null, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData> dedicatedHubList = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings monitoringSettings = null, System.Collections.Generic.IEnumerable<string> addressSpaces = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveConnectionData EnclaveConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch EnclaveConnectionPatch(string enclaveConnectionPatchSourceCidr = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties EnclaveConnectionProperties(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState? state = default(Azure.ResourceManager.Enclave.Models.EnclaveConnectionState?), Azure.Core.ResourceIdentifier communityResourceId = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string sourceCidr = null, Azure.Core.ResourceIdentifier destinationEndpointId = null, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveData EnclaveData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveDedicatedHubData EnclaveDedicatedHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch EnclaveDedicatedHubPatch(Azure.ResourceManager.Enclave.Models.EnclaveDesignation? enclaveDedicatedHubPatchDesignation = default(Azure.ResourceManager.Enclave.Models.EnclaveDesignation?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties EnclaveDedicatedHubProperties(Azure.Core.ResourceIdentifier vHubResourceId = null, Azure.Core.ResourceIdentifier firewallResourceId = null, Azure.Core.ResourceIdentifier firewallPolicyResourceId = null, Azure.ResourceManager.Enclave.Models.EnclaveDesignation? designation = default(Azure.ResourceManager.Enclave.Models.EnclaveDesignation?), Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings EnclaveDefaultSettings(Azure.Core.ResourceIdentifier keyVaultResourceId = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> logAnalyticsResourceIdCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination? diagnosticDestination = default(Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination?)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveEndpointData EnclaveEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule EnclaveEndpointDestinationRule(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProtocol> protocols = null, string endpointRuleName = null, string destination = null, string ports = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch EnclaveEndpointPatch(Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties EnclaveEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties EnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? updateMode = default(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedService EnclaveGovernedService(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier serviceId = default(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier), string serviceName = null, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption? option = default(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption?), Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement? enforcement = default(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement?), Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction? policyAction = default(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction?), System.Collections.Generic.IEnumerable<string> initiatives = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration EnclaveMaintenanceModeConfiguration(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode mode = default(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> principals = null, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification? justification = default(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch EnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode mode = default(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> principals = null, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification? justification = default(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker EnclaveManagedOnBehalfOfBroker(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover EnclaveMandatoryApprover(string approverEntraId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination EnclaveMonitoringDestination(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType destinationType = default(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType), Azure.Core.ResourceIdentifier customWorkspaceResourceId = null, string diagnosticSettingsName = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch EnclaveMonitoringDestinationPatch(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType destinationType = default(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType), Azure.Core.ResourceIdentifier customWorkspaceResourceId = null, string diagnosticSettingsName = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings EnclaveMonitoringSettings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination> diagnosticDestinations = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination flowLogDestination = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch EnclaveMonitoringSettingsPatch(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch> diagnosticDestinations = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch flowLogDestination = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclavePatch EnclavePatch(Azure.ResourceManager.Enclave.Models.EnclavePatchProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclavePatchProperties EnclavePatchProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, bool? isBastionEnabled = default(bool?), Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode? workloadResourceVisibility = default(Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode?), Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode? rbacInheritance = default(Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination? enclaveDefaultDiagnosticDestination = default(Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination?), Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch maintenanceModeConfiguration = null, Azure.Core.ResourceIdentifier dedicatedHubResourceId = null, Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties approvalSettings = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch monitoringSettings = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclavePrincipal EnclavePrincipal(string id = null, Azure.ResourceManager.Enclave.Models.EnclavePrincipalType type = default(Azure.ResourceManager.Enclave.Models.EnclavePrincipalType)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProperties EnclaveProperties(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork = null, Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces enclaveAddressSpaces = null, Azure.Core.ResourceIdentifier communityResourceId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, string managedResourceGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> managedOnBehalfOfMoboBrokerResources = null, bool? isBastionEnabled = default(bool?), Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode? workloadResourceVisibility = default(Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode?), Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode? rbacInheritance = default(Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> enclaveRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> workloadRoleAssignments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> governedServiceList = null, Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings enclaveDefaultSettings = null, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration maintenanceModeConfiguration = null, Azure.Core.ResourceIdentifier dedicatedHubResourceId = null, Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings approvalSettings = null, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings monitoringSettings = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem EnclaveRoleAssignmentItem(string roleDefinitionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> principals = null, string condition = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration EnclaveSubnetConfiguration(string subnetName = null, Azure.Core.ResourceIdentifier subnetResourceId = null, int networkPrefixSize = 0, string subnetDelegation = null, string addressPrefix = null, Azure.Core.ResourceIdentifier networkSecurityGroupResourceId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveTransitHubData EnclaveTransitHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch EnclaveTransitHubPatch(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties EnclaveTransitHubPatchProperties(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState? state = default(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState?), Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties transitOption = null, Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider? securityProvider = default(Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties EnclaveTransitHubProperties(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState? state = default(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState?), Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties transitOption = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceCollection = null, Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider? securityProvider = default(Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider?)) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent EnclaveTransitOptionContent(long? scaleUnits = default(long?), Azure.Core.ResourceIdentifier remoteVirtualNetworkId = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties EnclaveTransitOptionProperties(Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType? type = default(Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType?), Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent @params = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork(string networkName = null, string networkSize = null, string customCidrRange = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration> subnetConfigurations = null, bool? allowSubnetCommunication = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Enclave.EnclaveWorkloadData EnclaveWorkloadData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch EnclaveWorkloadPatch(System.Collections.Generic.IEnumerable<string> workloadPatchResourceGroupCollection = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties EnclaveWorkloadProperties(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? provisioningState = default(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState?), System.Collections.Generic.IEnumerable<string> resourceGroupCollection = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
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
    public readonly partial struct EnclaveApprovalCallbackResourceAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveApprovalCallbackResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction Create { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction Reset { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalCallbackResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveApprovalDeletionCallbackResourceAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveApprovalDeletionCallbackResourceAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction Create { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalDeletionCallbackResourceAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveApprovalPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>
    {
        public EnclaveApprovalPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveApprovalPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>
    {
        public EnclaveApprovalPatchProperties(Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch requestMetadata) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveApprover> Approvers { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadataPatch RequestMetadata { get { throw null; } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveApprovalPolicy : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveApprovalPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy NotRequired { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveApprovalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>
    {
        public EnclaveApprovalProperties(Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata requestMetadata) { }
        public System.Collections.Generic.IReadOnlyList<string> ApprovedByEntraIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveApprover> Approvers { get { throw null; } }
        public long? ApproversApprovedCount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GrandparentResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover> MandatoryApprovers { get { throw null; } }
        public long? MandatoryApproversApprovedCount { get { throw null; } }
        public long? MinimumApproversRequired { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ApprovalRequestMetadata RequestMetadata { get { throw null; } set { } }
        public System.DateTimeOffset? StateChangedOn { get { throw null; } set { } }
        public string TicketId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>
    {
        public EnclaveApprovalSettings() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveApprovalSettingsPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>
    {
        public EnclaveApprovalSettingsPatchProperties() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveApprovalStatus : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveApprovalStatus(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus left, Azure.ResourceManager.Enclave.Models.EnclaveApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>
    {
        public EnclaveApprover(string approverEntraId, System.DateTimeOffset lastUpdatedOn) { }
        public Azure.ResourceManager.Enclave.Models.ApproverActionPerformed? ActionPerformed { get { throw null; } set { } }
        public string ApproverEntraId { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> MandatoryApprovalGroupMembershipIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprover JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveApprover PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveBaseApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>
    {
        public EnclaveBaseApprovalSettings() { }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration CommunityMaintenanceMode { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration ConnectionUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveCreation { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveEndpointUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingConfiguration EnclaveMaintenanceMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityEndpointDestinationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>
    {
        public EnclaveCommunityEndpointDestinationRule() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType? DestinationType { get { throw null; } set { } }
        public string EndpointRuleName { get { throw null; } set { } }
        public string Ports { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol> Protocols { get { throw null; } }
        public Azure.Core.ResourceIdentifier TransitHubResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveCommunityEndpointDestinationType : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveCommunityEndpointDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType Fqdn { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType FqdnTag { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType IPAddress { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType PrivateNetwork { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType ServiceTag { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType left, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType left, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveCommunityEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>
    {
        public EnclaveCommunityEndpointPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityEndpointPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>
    {
        public EnclaveCommunityEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> ruleCollection) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>
    {
        public EnclaveCommunityEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveCommunityEndpointProtocol : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveCommunityEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Any { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol left, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol left, Azure.ResourceManager.Enclave.Models.EnclaveCommunityEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveCommunityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>
    {
        public EnclaveCommunityPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>
    {
        public EnclaveCommunityPatchProperties() { }
        public System.Collections.Generic.IList<string> AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.ApprovalSettingsPatchProperties GranularApprovalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? PolicyOverride { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveCommunityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>
    {
        public EnclaveCommunityProperties() { }
        public string AddressSpace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> CommunityRoleAssignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.EnclaveDedicatedHubData> DedicatedHubList { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku? FirewallSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveBaseApprovalSettings GranularApprovalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.CommunityPropertiesPolicyOverride? PolicyOverride { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveCommunityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>
    {
        public EnclaveConnectionPatch() { }
        public string EnclaveConnectionPatchSourceCidr { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>
    {
        public EnclaveConnectionProperties(Azure.Core.ResourceIdentifier communityResourceId, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier destinationEndpointId) { }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public string SourceCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveConnectionState? State { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? UpdateMode { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EnclaveDedicatedHubPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>
    {
        public EnclaveDedicatedHubPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveDesignation? EnclaveDedicatedHubPatchDesignation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveDedicatedHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>
    {
        public EnclaveDedicatedHubProperties() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveDesignation? Designation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FirewallPolicyResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FirewallResourceId { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VHubResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDedicatedHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveDefaultSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings>
    {
        public EnclaveDefaultSettings() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination? DiagnosticDestination { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveDesignation : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveDesignation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveDesignation(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDesignation Pooled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDesignation Reserved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveDesignation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveDesignation left, Azure.ResourceManager.Enclave.Models.EnclaveDesignation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveDesignation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveDesignation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveDesignation left, Azure.ResourceManager.Enclave.Models.EnclaveDesignation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveDiagnosticDestination : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveDiagnosticDestination(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination Both { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination CommunityOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination EnclaveOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination left, Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination left, Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class EnclaveEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>
    {
        public EnclaveEndpointPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveEndpointPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointPatchProperties>
    {
        public EnclaveEndpointPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? UpdateMode { get { throw null; } set { } }
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
    public partial class EnclaveEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>
    {
        public EnclaveEndpointProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> ruleCollection) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveEndpointDestinationRule> RuleCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? UpdateMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveFirewallSku : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveFirewallSku(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku Basic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku Premium { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku left, Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku left, Azure.ResourceManager.Enclave.Models.EnclaveFirewallSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveGovernedService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>
    {
        public EnclaveGovernedService(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier serviceId) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement? Enforcement { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Initiatives { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction? PolicyAction { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier ServiceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveGovernedService JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveGovernedService PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveGovernedService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveGovernedService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveGovernedServiceIdentifier : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveGovernedServiceIdentifier(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier Aks { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier AppService { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier AzureFirewalls { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier ContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier DataConnectors { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier Insights { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier Logic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier MicrosoftSql { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier Monitoring { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier PrivateDnsZones { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier ServiceBus { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier Storage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceIdentifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveGovernedServiceItemEnforcement : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveGovernedServiceItemEnforcement(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemEnforcement right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveGovernedServiceItemOption : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveGovernedServiceItemOption(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption Allow { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption Deny { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption ExceptionOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveGovernedServiceItemPolicyAction : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveGovernedServiceItemPolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction AuditOnly { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction Enforce { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction left, Azure.ResourceManager.Enclave.Models.EnclaveGovernedServiceItemPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveMaintenanceModeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>
    {
        public EnclaveMaintenanceModeConfiguration(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode mode) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> Principals { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveMaintenanceModeConfigurationMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveMaintenanceModeConfigurationMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode Advanced { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode General { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode Off { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode left, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode left, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveMaintenanceModeConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>
    {
        public EnclaveMaintenanceModeConfigurationPatch(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode mode) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification? Justification { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationMode Mode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> Principals { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveMaintenanceModeJustification : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveMaintenanceModeJustification(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification Governance { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification Networking { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification left, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification left, Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeJustification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveManagedOnBehalfOfBroker : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>
    {
        internal EnclaveManagedOnBehalfOfBroker() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveMandatoryApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>
    {
        public EnclaveMandatoryApprover(string approverEntraId) { }
        public string ApproverEntraId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMandatoryApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveMonitoringDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>
    {
        public EnclaveMonitoringDestination(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType destinationType) { }
        public Azure.Core.ResourceIdentifier CustomWorkspaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType DestinationType { get { throw null; } set { } }
        public string DiagnosticSettingsName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveMonitoringDestinationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>
    {
        public EnclaveMonitoringDestinationPatch(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType destinationType) { }
        public Azure.Core.ResourceIdentifier CustomWorkspaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType DestinationType { get { throw null; } }
        public string DiagnosticSettingsName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveMonitoringDestinationType : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveMonitoringDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType CommunityWorkspace { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType CustomWorkspace { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType EnclaveWorkspace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType left, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType left, Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveMonitoringSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>
    {
        public EnclaveMonitoringSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination> DiagnosticDestinations { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestination FlowLogDestination { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveMonitoringSettingsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>
    {
        public EnclaveMonitoringSettingsPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch> DiagnosticDestinations { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringDestinationPatch FlowLogDestination { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclavePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>
    {
        public EnclavePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclavePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclavePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclavePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclavePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>
    {
        public EnclavePatchProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettingsPatchProperties ApprovalSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DedicatedHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveDiagnosticDestination? EnclaveDefaultDiagnosticDestination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfigurationPatch MaintenanceModeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettingsPatch MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode? RbacInheritance { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode? WorkloadResourceVisibility { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclavePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclavePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclavePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>
    {
        public EnclavePrincipal(string id, Azure.ResourceManager.Enclave.Models.EnclavePrincipalType type) { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclavePrincipalType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclavePrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclavePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclavePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclavePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclavePrincipalType : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclavePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclavePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclavePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclavePrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclavePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclavePrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclavePrincipalType left, Azure.ResourceManager.Enclave.Models.EnclavePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclavePrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclavePrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclavePrincipalType left, Azure.ResourceManager.Enclave.Models.EnclavePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>
    {
        public EnclaveProperties(Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork enclaveVirtualNetwork, Azure.Core.ResourceIdentifier communityResourceId) { }
        public Azure.ResourceManager.Enclave.Models.EnclaveApprovalSettings ApprovalSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CommunityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DedicatedHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveAddressSpaces EnclaveAddressSpaces { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveDefaultSettings EnclaveDefaultSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> EnclaveRoleAssignments { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork EnclaveVirtualNetwork { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveGovernedService> GovernedServiceList { get { throw null; } }
        public bool? IsBastionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMaintenanceModeConfiguration MaintenanceModeConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode? RbacInheritance { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode? WorkloadResourceVisibility { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem> WorkloadRoleAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveProvisioningState : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState left, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState left, Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveRbacInheritanceMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveRbacInheritanceMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode left, Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode left, Azure.ResourceManager.Enclave.Models.EnclaveRbacInheritanceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveResourceVisibilityMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveResourceVisibilityMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode left, Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode left, Azure.ResourceManager.Enclave.Models.EnclaveResourceVisibilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveRoleAssignmentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>
    {
        public EnclaveRoleAssignmentItem(string roleDefinitionId) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclavePrincipal> Principals { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveRoleAssignmentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveSecurityProvider : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveSecurityProvider(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider AzureFirewall { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider left, Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider left, Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveSubnetConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>
    {
        public EnclaveSubnetConfiguration(string subnetName, int networkPrefixSize) { }
        public string AddressPrefix { get { throw null; } }
        public int NetworkPrefixSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupResourceId { get { throw null; } }
        public string SubnetDelegation { get { throw null; } set { } }
        public string SubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveTransitHubPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>
    {
        public EnclaveTransitHubPatch() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveTransitHubPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>
    {
        public EnclaveTransitHubPatchProperties() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider? SecurityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveTransitHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>
    {
        public EnclaveTransitHubProperties() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ResourceCollection { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveSecurityProvider? SecurityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState? State { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties TransitOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveTransitHubState : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveTransitHubState(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState Active { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState Approved { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState Failed { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState left, Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState left, Azure.ResourceManager.Enclave.Models.EnclaveTransitHubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveTransitOptionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>
    {
        public EnclaveTransitOptionContent() { }
        public Azure.Core.ResourceIdentifier RemoteVirtualNetworkId { get { throw null; } set { } }
        public long? ScaleUnits { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveTransitOptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>
    {
        public EnclaveTransitOptionProperties() { }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionContent Params { get { throw null; } set { } }
        public Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveTransitOptionType : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveTransitOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType ExpressRoute { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType Gateway { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType Peering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType left, Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType left, Azure.ResourceManager.Enclave.Models.EnclaveTransitOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnclaveUpdateMode : System.IEquatable<Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnclaveUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode left, Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode left, Azure.ResourceManager.Enclave.Models.EnclaveUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnclaveVirtualNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveVirtualNetwork>
    {
        public EnclaveVirtualNetwork() { }
        public bool? AllowSubnetCommunication { get { throw null; } set { } }
        public string CustomCidrRange { get { throw null; } set { } }
        public string NetworkName { get { throw null; } set { } }
        public string NetworkSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Enclave.Models.EnclaveSubnetConfiguration> SubnetConfigurations { get { throw null; } }
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
    public partial class EnclaveWorkloadPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>
    {
        public EnclaveWorkloadPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> WorkloadPatchResourceGroupCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveWorkloadProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>
    {
        public EnclaveWorkloadProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Enclave.Models.EnclaveManagedOnBehalfOfBroker> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.Enclave.Models.EnclaveProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroupCollection { get { throw null; } }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Enclave.Models.EnclaveWorkloadProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
