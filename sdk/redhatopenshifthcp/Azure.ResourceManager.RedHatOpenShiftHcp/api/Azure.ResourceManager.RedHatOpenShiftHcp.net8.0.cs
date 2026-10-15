namespace Azure.ResourceManager.RedHatOpenShiftHcp
{
    public partial class AzureResourceManagerRedHatOpenShiftHcpContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRedHatOpenShiftHcpContext() { }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.AzureResourceManagerRedHatOpenShiftHcpContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HcpOpenShiftClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>, System.Collections.IEnumerable
    {
        protected HcpOpenShiftClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hcpOpenShiftClusterName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hcpOpenShiftClusterName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> Get(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetAsync(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetIfExists(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetIfExistsAsync(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcpOpenShiftClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>
    {
        public HcpOpenShiftClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>, System.Collections.IEnumerable
    {
        protected HcpOpenShiftClusterExternalAuthCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string externalAuthName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string externalAuthName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> Get(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> GetAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> GetIfExists(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> GetIfExistsAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>
    {
        public HcpOpenShiftClusterExternalAuthData() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcpOpenShiftClusterExternalAuthResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hcpOpenShiftClusterName, string externalAuthName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>, System.Collections.IEnumerable
    {
        protected HcpOpenShiftClusterNodePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> Get(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> GetAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> GetIfExists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> GetIfExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>
    {
        public HcpOpenShiftClusterNodePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcpOpenShiftClusterNodePoolResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hcpOpenShiftClusterName, string nodePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HcpOpenShiftClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcpOpenShiftClusterResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hcpOpenShiftClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource> GetHcpOpenShiftClusterExternalAuth(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource>> GetHcpOpenShiftClusterExternalAuthAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthCollection GetHcpOpenShiftClusterExternalAuths() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource> GetHcpOpenShiftClusterNodePool(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource>> GetHcpOpenShiftClusterNodePoolAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolCollection GetHcpOpenShiftClusterNodePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential> RequestAdminCredential(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>> RequestAdminCredentialAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeCredentials(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeCredentialsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HcpOpenShiftVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>, System.Collections.IEnumerable
    {
        protected HcpOpenShiftVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> Get(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>> GetAsync(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> GetIfExists(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>> GetIfExistsAsync(string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcpOpenShiftVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>
    {
        internal HcpOpenShiftVersionData() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcpOpenShiftVersionResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string hcpOpenShiftVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOperatorIdentityRoleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>, System.Collections.IEnumerable
    {
        protected HcpOperatorIdentityRoleSetCollection() { }
        public virtual Azure.Response<bool> Exists(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> Get(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>> GetAsync(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> GetIfExists(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>> GetIfExistsAsync(string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcpOperatorIdentityRoleSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>
    {
        internal HcpOperatorIdentityRoleSetData() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOperatorIdentityRoleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcpOperatorIdentityRoleSetResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string hcpOperatorIdentityRoleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class RedHatOpenShiftHcpExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetHcpOpenShiftClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource GetHcpOpenShiftClusterExternalAuthResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource GetHcpOpenShiftClusterNodePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource GetHcpOpenShiftClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterCollection GetHcpOpenShiftClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> GetHcpOpenShiftVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>> GetHcpOpenShiftVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource GetHcpOpenShiftVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionCollection GetHcpOpenShiftVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> GetHcpOperatorIdentityRoleSet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>> GetHcpOperatorIdentityRoleSetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource GetHcpOperatorIdentityRoleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetCollection GetHcpOperatorIdentityRoleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShiftHcp.Mocking
{
    public partial class MockableRedHatOpenShiftHcpArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftHcpArmClient() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthResource GetHcpOpenShiftClusterExternalAuthResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolResource GetHcpOpenShiftClusterNodePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource GetHcpOpenShiftClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource GetHcpOpenShiftVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource GetHcpOperatorIdentityRoleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRedHatOpenShiftHcpResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftHcpResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftCluster(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetHcpOpenShiftClusterAsync(string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterCollection GetHcpOpenShiftClusters() { throw null; }
    }
    public partial class MockableRedHatOpenShiftHcpSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftHcpSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource> GetHcpOpenShiftVersion(Azure.Core.AzureLocation location, string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource>> GetHcpOpenShiftVersionAsync(Azure.Core.AzureLocation location, string hcpOpenShiftVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionCollection GetHcpOpenShiftVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource> GetHcpOperatorIdentityRoleSet(Azure.Core.AzureLocation location, string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource>> GetHcpOperatorIdentityRoleSetAsync(Azure.Core.AzureLocation location, string hcpOperatorIdentityRoleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetCollection GetHcpOperatorIdentityRoleSets(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShiftHcp.Models
{
    public static partial class ArmRedHatOpenShiftHcpModelFactory
    {
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential HcpOpenShiftClusterAdminCredential(string kubeconfig = null, System.DateTimeOffset expirationTimestampOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent HcpOpenShiftClusterAdminCredentialRequestContent(string certificateSigningRequest = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile HcpOpenShiftClusterApiProfile(System.Uri uri = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility? visibility = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility?), System.Collections.Generic.IEnumerable<string> authorizedCIDRs = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile HcpOpenShiftClusterAutoscalingProfile(int? maxNodesTotal = default(int?), int? maxPodGracePeriodSeconds = default(int?), int? maxNodeProvisionTimeSeconds = default(int?), int? podPriorityThreshold = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition HcpOpenShiftClusterCondition(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType status = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType), System.DateTimeOffset lastTransitionOn = default(System.DateTimeOffset), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile HcpOpenShiftClusterCustomerManagedEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType? encryptionType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile kms = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData HcpOpenShiftClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile HcpOpenShiftClusterDnsProfile(string baseDomain = null, string baseDomainPrefix = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile HcpOpenShiftClusterEtcdDataEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType keyManagementMode = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile customerManaged = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile HcpOpenShiftClusterExternalAuthClaimProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile mappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule> validationRules = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile HcpOpenShiftClusterExternalAuthClientComponentProfile(string name = null, string authClientNamespace = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile HcpOpenShiftClusterExternalAuthClientProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile component = null, string clientId = null, System.Collections.Generic.IEnumerable<string> extraScopes = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterExternalAuthData HcpOpenShiftClusterExternalAuthData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile HcpOpenShiftClusterExternalAuthGroupClaimProfile(string claim = null, string prefix = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties HcpOpenShiftClusterExternalAuthProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile issuer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile> clients = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile claim = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile username = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile groups = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule HcpOpenShiftClusterExternalAuthTokenClaimValidationRule(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType? type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim requiredClaim = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile HcpOpenShiftClusterExternalAuthTokenIssuerProfile(System.Uri uri = null, System.Collections.Generic.IEnumerable<string> audiences = null, string ca = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim HcpOpenShiftClusterExternalAuthTokenRequiredClaim(string claim = null, string requiredValue = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile HcpOpenShiftClusterExternalAuthUsernameClaimProfile(string claim = null, string prefix = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy? prefixPolicy = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror HcpOpenShiftClusterImageDigestMirror(string source = null, System.Collections.Generic.IEnumerable<string> mirrors = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile HcpOpenShiftClusterKmsEncryptionProfile(string vaultName = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility visibility = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey activeKey = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey HcpOpenShiftClusterKmsKey(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile HcpOpenShiftClusterNetworkProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType? networkType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType?), string podCIDR = null, string serviceCIDR = null, string machineCIDR = null, int? hostPrefix = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling HcpOpenShiftClusterNodePoolAutoScaling(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterNodePoolData HcpOpenShiftClusterNodePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel HcpOpenShiftClusterNodePoolLabel(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile HcpOpenShiftClusterNodePoolOSDiskProfile(int? sizeGiB = default(int?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType? diskStorageAccountType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType?), Azure.Core.ResourceIdentifier encryptionSetId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType? diskType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile HcpOpenShiftClusterNodePoolPlatformProfile(Azure.Core.ResourceIdentifier subnetId = null, string vmSize = null, bool? enableEncryptionAtHost = default(bool?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile osDisk = null, string availabilityZone = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties HcpOpenShiftClusterNodePoolProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile version = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile platform = null, int? replicas = default(int?), bool? canAutoRepair = default(bool?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling autoScaling = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel> labels = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint> taints = null, int? nodeDrainTimeoutMinutes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint HcpOpenShiftClusterNodePoolTaint(string key = null, string value = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect effect = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile HcpOpenShiftClusterNodePoolVersionProfile(string id = null, string channelGroup = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile HcpOpenShiftClusterPlatformProfile(string managedResourceGroup = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetIntegrationSubnetId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType? outboundType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType?), Azure.Core.ResourceIdentifier networkSecurityGroupId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile operatorsAuthenticationUserAssignedIdentities = null, System.Uri issuerUri = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties HcpOpenShiftClusterProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile version = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile dns = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile network = null, System.Uri consoleUri = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile api = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType? ingressType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile platform = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile autoscaling = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile etcdDataEncryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror> imageDigestMirrors = null, int? nodeDrainTimeoutMinutes = default(int?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState? clusterImageRegistryState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions? cryptoRestrictions = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile HcpOpenShiftClusterUserAssignedIdentitiesProfile(System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> controlPlaneOperators = null, System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> dataPlaneOperators = null, Azure.Core.ResourceIdentifier serviceManagedIdentity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile HcpOpenShiftClusterVersionProfile(string id = null, string channelGroup = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData HcpOpenShiftVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties HcpOpenShiftVersionProperties(string channelGroup = null, bool enabled = false, System.DateTimeOffset endOfLifeTimestampOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData HcpOperatorIdentityRoleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties HcpOperatorIdentityRoleSetProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> controlPlaneOperators = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> dataPlaneOperators = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles OperatorIdentityRoles(string name = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired required = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo> roleDefinitions = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo RoleDefinitionInfo(string name = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CryptoRestrictions : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CryptoRestrictions(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions FIPS { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalAuthProvisioningState : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalAuthProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState AwaitingSecret { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterAdminCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>
    {
        internal HcpOpenShiftClusterAdminCredential() { }
        public System.DateTimeOffset ExpirationTimestampOn { get { throw null; } }
        public string Kubeconfig { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterAdminCredentialRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>
    {
        public HcpOpenShiftClusterAdminCredentialRequestContent() { }
        public string CertificateSigningRequest { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredentialRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterApiProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>
    {
        public HcpOpenShiftClusterApiProfile() { }
        public System.Collections.Generic.IList<string> AuthorizedCIDRs { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility? Visibility { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterApiVisibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterApiVisibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterAutoscalingProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>
    {
        public HcpOpenShiftClusterAutoscalingProfile() { }
        public int? MaxNodeProvisionTimeSeconds { get { throw null; } set { } }
        public int? MaxNodesTotal { get { throw null; } set { } }
        public int? MaxPodGracePeriodSeconds { get { throw null; } set { } }
        public int? PodPriorityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>
    {
        internal HcpOpenShiftClusterCondition() { }
        public System.DateTimeOffset LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType Status { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterConditionStatusType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterConditionStatusType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType False { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType True { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterConditionType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterConditionType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType Available { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType Degraded { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType Progressing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterCustomerManagedEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>
    {
        public HcpOpenShiftClusterCustomerManagedEncryptionProfile() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType? EncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile Kms { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterCustomerManagedEncryptionType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterCustomerManagedEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType Kms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterDnsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>
    {
        public HcpOpenShiftClusterDnsProfile() { }
        public string BaseDomain { get { throw null; } }
        public string BaseDomainPrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType CustomerManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterEtcdDataEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>
    {
        public HcpOpenShiftClusterEtcdDataEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType keyManagementMode) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCustomerManagedEncryptionProfile CustomerManaged { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionKeyManagementModeType KeyManagementMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>
    {
        public HcpOpenShiftClusterExternalAuthClaimProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile mappings) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile Mappings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule> ValidationRules { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthClientComponentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>
    {
        public HcpOpenShiftClusterExternalAuthClientComponentProfile(string name, string authClientNamespace) { }
        public string AuthClientNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthClientProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>
    {
        public HcpOpenShiftClusterExternalAuthClientProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile component, string clientId, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType type) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientComponentProfile Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExtraScopes { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterExternalAuthClientType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterExternalAuthClientType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType Confidential { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthGroupClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>
    {
        public HcpOpenShiftClusterExternalAuthGroupClaimProfile(string claim) { }
        public string Claim { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>
    {
        public HcpOpenShiftClusterExternalAuthProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile issuer, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile claim) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClaimProfile Claim { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthClientProfile> Clients { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile Issuer { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> StatusConditions { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>
    {
        public HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile username) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthGroupClaimProfile Groups { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimMappingsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthTokenClaimValidationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>
    {
        public HcpOpenShiftClusterExternalAuthTokenClaimValidationRule() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim RequiredClaim { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenClaimValidationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthTokenIssuerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>
    {
        public HcpOpenShiftClusterExternalAuthTokenIssuerProfile(System.Uri uri, System.Collections.Generic.IEnumerable<string> audiences) { }
        public System.Collections.Generic.IList<string> Audiences { get { throw null; } }
        public string CA { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenIssuerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthTokenRequiredClaim : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>
    {
        public HcpOpenShiftClusterExternalAuthTokenRequiredClaim(string claim, string requiredValue) { }
        public string Claim { get { throw null; } set { } }
        public string RequiredValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenRequiredClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterExternalAuthTokenValidationRuleType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterExternalAuthTokenValidationRuleType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType RequiredClaim { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthTokenValidationRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy None { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy NoPrefix { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy Prefix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterExternalAuthUsernameClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>
    {
        public HcpOpenShiftClusterExternalAuthUsernameClaimProfile(string claim) { }
        public string Claim { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimPrefixPolicy? PrefixPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterExternalAuthUsernameClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterImageDigestMirror : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>
    {
        public HcpOpenShiftClusterImageDigestMirror(string source, System.Collections.Generic.IEnumerable<string> mirrors) { }
        public System.Collections.Generic.IList<string> Mirrors { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterImageRegistryState : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterImageRegistryState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterIngressType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterIngressType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterKeyVaultVisibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterKeyVaultVisibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterKmsEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>
    {
        public HcpOpenShiftClusterKmsEncryptionProfile(string vaultName, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility visibility, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey activeKey) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey ActiveKey { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKeyVaultVisibility Visibility { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterKmsKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>
    {
        public HcpOpenShiftClusterKmsKey(string name, string version) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterKmsKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>
    {
        public HcpOpenShiftClusterNetworkProfile() { }
        public int? HostPrefix { get { throw null; } set { } }
        public string MachineCIDR { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType? NetworkType { get { throw null; } set { } }
        public string PodCIDR { get { throw null; } set { } }
        public string ServiceCIDR { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterNetworkType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType Other { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType OVNKubernetes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolAutoScaling : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>
    {
        public HcpOpenShiftClusterNodePoolAutoScaling() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterNodePoolDiskStorageAccountType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterNodePoolDiskStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType StandardSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolLabel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>
    {
        public HcpOpenShiftClusterNodePoolLabel(string key) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolOSDiskProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>
    {
        public HcpOpenShiftClusterNodePoolOSDiskProfile() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolDiskStorageAccountType? DiskStorageAccountType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType? DiskType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EncryptionSetId { get { throw null; } set { } }
        public int? SizeGiB { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterNodePoolOSDiskType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterNodePoolOSDiskType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType Ephemeral { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolPlatformProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>
    {
        public HcpOpenShiftClusterNodePoolPlatformProfile(string vmSize) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public bool? EnableEncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolOSDiskProfile OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>
    {
        public HcpOpenShiftClusterNodePoolProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile platform) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolAutoScaling AutoScaling { get { throw null; } set { } }
        public bool? CanAutoRepair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel> Labels { get { throw null; } }
        public int? NodeDrainTimeoutMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolPlatformProfile Platform { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> StatusConditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint> Taints { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolTaint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>
    {
        public HcpOpenShiftClusterNodePoolTaint(string key, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect effect) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect Effect { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterNodePoolTaintEffect : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterNodePoolTaintEffect(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect NoExecute { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect NoSchedule { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect PreferNoSchedule { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterNodePoolVersionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>
    {
        public HcpOpenShiftClusterNodePoolVersionProfile(string id) { }
        public string ChannelGroup { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolVersionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterOutboundType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterOutboundType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType LoadBalancer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcpOpenShiftClusterPlatformProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>
    {
        public HcpOpenShiftClusterPlatformProfile(Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetIntegrationSubnetId, Azure.Core.ResourceIdentifier networkSecurityGroupId, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile operatorsAuthenticationUserAssignedIdentities) { }
        public System.Uri IssuerUri { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile OperatorsAuthenticationUserAssignedIdentities { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterOutboundType? OutboundType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetIntegrationSubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>
    {
        public HcpOpenShiftClusterProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile version, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile platform) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterApiProfile Api { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAutoscalingProfile Autoscaling { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageRegistryState? ClusterImageRegistryState { get { throw null; } set { } }
        public System.Uri ConsoleUri { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions? CryptoRestrictions { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterDnsProfile Dns { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterEtcdDataEncryptionProfile EtcdDataEncryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterImageDigestMirror> ImageDigestMirrors { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterIngressType? IngressType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNetworkProfile Network { get { throw null; } set { } }
        public int? NodeDrainTimeoutMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile Platform { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> StatusConditions { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterUserAssignedIdentitiesProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>
    {
        public HcpOpenShiftClusterUserAssignedIdentitiesProfile(System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> controlPlaneOperators, System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> dataPlaneOperators, Azure.Core.ResourceIdentifier serviceManagedIdentity) { }
        public System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> ControlPlaneOperators { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> DataPlaneOperators { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceManagedIdentity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterUserAssignedIdentitiesProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftClusterVersionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>
    {
        public HcpOpenShiftClusterVersionProfile(string id) { }
        public string ChannelGroup { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOpenShiftVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>
    {
        internal HcpOpenShiftVersionProperties() { }
        public string ChannelGroup { get { throw null; } }
        public bool Enabled { get { throw null; } }
        public System.DateTimeOffset EndOfLifeTimestampOn { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcpOperatorIdentityRoleSetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>
    {
        internal HcpOperatorIdentityRoleSetProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> ControlPlaneOperators { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> DataPlaneOperators { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorIdentityRequired : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorIdentityRequired(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired Always { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired OnEnablement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperatorIdentityRoles : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>
    {
        internal OperatorIdentityRoles() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired Required { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo> RoleDefinitions { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleDefinitionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>
    {
        internal RoleDefinitionInfo() { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
