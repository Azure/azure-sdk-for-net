namespace Azure.ResourceManager.RedHatOpenShiftHcp
{
    public partial class AzureResourceManagerRedHatOpenShiftHcpContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRedHatOpenShiftHcpContext() { }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.AzureResourceManagerRedHatOpenShiftHcpContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ExternalAuthCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>, System.Collections.IEnumerable
    {
        protected ExternalAuthCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string externalAuthName, Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string externalAuthName, Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> Get(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> GetAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> GetIfExists(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> GetIfExistsAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExternalAuthData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>
    {
        public ExternalAuthData() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalAuthResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExternalAuthResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hcpOpenShiftClusterName, string externalAuthName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource> GetExternalAuth(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource>> GetExternalAuthAsync(string externalAuthName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthCollection GetExternalAuths() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> GetNodePool(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> GetNodePoolAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolCollection GetNodePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential> RequestAdminCredential(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential>> RequestAdminCredentialAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NodePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>, System.Collections.IEnumerable
    {
        protected NodePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> Get(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> GetAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> GetIfExists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> GetIfExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>
    {
        public NodePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodePoolResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hcpOpenShiftClusterName, string nodePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RedHatOpenShiftHcpExtensions
    {
        public static Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource GetExternalAuthResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource> GetHcpOpenShiftCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource>> GetHcpOpenShiftClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hcpOpenShiftClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource GetNodePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShiftHcp.Mocking
{
    public partial class MockableRedHatOpenShiftHcpArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftHcpArmClient() { }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthResource GetExternalAuthResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterResource GetHcpOpenShiftClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionResource GetHcpOpenShiftVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetResource GetHcpOperatorIdentityRoleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolResource GetNodePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile ClusterAutoscalingProfile(int? maxNodesTotal = default(int?), int? maxPodGracePeriodSeconds = default(int?), int? maxNodeProvisionTimeSeconds = default(int?), int? podPriorityThreshold = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile CustomerManagedEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType? encryptionType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile kms = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile DnsProfile(string baseDomain = null, string baseDomainPrefix = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile EtcdDataEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType keyManagementMode = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType), Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile customerManaged = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile ExternalAuthClaimProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile mappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule> validationRules = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile ExternalAuthClientComponentProfile(string name = null, string authClientNamespace = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile ExternalAuthClientProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile component = null, string clientId = null, System.Collections.Generic.IEnumerable<string> extraScopes = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.ExternalAuthData ExternalAuthData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties ExternalAuthProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile issuer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile> clients = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile claim = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile GroupClaimProfile(string claim = null, string prefix = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAdminCredential HcpOpenShiftClusterAdminCredential(string kubeconfig = null, System.DateTimeOffset expirationTimestampOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile HcpOpenShiftClusterAPIProfile(System.Uri uri = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility? visibility = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility?), System.Collections.Generic.IEnumerable<string> authorizedCIDRs = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition HcpOpenShiftClusterCondition(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionType), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType status = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterConditionStatusType), System.DateTimeOffset lastTransitionOn = default(System.DateTimeOffset), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftClusterData HcpOpenShiftClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel HcpOpenShiftClusterNodePoolLabel(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile HcpOpenShiftClusterPlatformProfile(string managedResourceGroup = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetIntegrationSubnetId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType? outboundType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType?), Azure.Core.ResourceIdentifier networkSecurityGroupId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile operatorsAuthenticationUserAssignedIdentities = null, System.Uri issuerUri = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterProperties HcpOpenShiftClusterProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile version = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile dns = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile network = null, System.Uri consoleUri = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile api = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType? ingressType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile platform = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile autoscaling = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile etcdDataEncryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror> imageDigestMirrors = null, int? nodeDrainTimeoutMinutes = default(int?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState? clusterImageRegistryState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions? cryptoRestrictions = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterVersionProfile HcpOpenShiftClusterVersionProfile(string id = null, string channelGroup = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOpenShiftVersionData HcpOpenShiftVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftVersionProperties HcpOpenShiftVersionProperties(string channelGroup = null, bool enabled = false, System.DateTimeOffset endOfLifeTimestampOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.HcpOperatorIdentityRoleSetData HcpOperatorIdentityRoleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOperatorIdentityRoleSetProperties HcpOperatorIdentityRoleSetProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> controlPlaneOperators = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles> dataPlaneOperators = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror ImageDigestMirror(string source = null, System.Collections.Generic.IEnumerable<string> mirrors = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile KmsEncryptionProfile(string vaultName = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility visibility = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility), Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey activeKey = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey KmsKey(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile NetworkProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType? networkType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType?), string podCIDR = null, string serviceCIDR = null, string machineCIDR = null, int? hostPrefix = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling NodePoolAutoScaling(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.NodePoolData NodePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile NodePoolPlatformProfile(Azure.Core.ResourceIdentifier subnetId = null, string vmSize = null, bool? enableEncryptionAtHost = default(bool?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile osDisk = null, string availabilityZone = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties NodePoolProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile version = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile platform = null, int? replicas = default(int?), bool? canAutoRepair = default(bool?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling autoScaling = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel> labels = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint> taints = null, int? nodeDrainTimeoutMinutes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> statusConditions = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile NodePoolVersionProfile(string id = null, string channelGroup = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRoles OperatorIdentityRoles(string name = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired required = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OperatorIdentityRequired), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo> roleDefinitions = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile OSDiskProfile(int? sizeGiB = default(int?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType? diskStorageAccountType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType?), Azure.Core.ResourceIdentifier encryptionSetId = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType? diskType = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType?)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.RoleDefinitionInfo RoleDefinitionInfo(string name = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint Taint(string key = null, string value = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect effect = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile TokenClaimMappingsProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile username = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile groups = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule TokenClaimValidationRule(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType? type = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType?), Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim requiredClaim = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile TokenIssuerProfile(System.Uri uri = null, System.Collections.Generic.IEnumerable<string> audiences = null, string ca = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim TokenRequiredClaim(string claim = null, string requiredValue = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile UserAssignedIdentitiesProfile(System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> controlPlaneOperators = null, System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> dataPlaneOperators = null, Azure.Core.ResourceIdentifier serviceManagedIdentity = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile UsernameClaimProfile(string claim = null, string prefix = null, Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy? prefixPolicy = default(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy?)) { throw null; }
    }
    public partial class ClusterAutoscalingProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>
    {
        public ClusterAutoscalingProfile() { }
        public int? MaxNodeProvisionTimeSeconds { get { throw null; } set { } }
        public int? MaxNodesTotal { get { throw null; } set { } }
        public int? MaxPodGracePeriodSeconds { get { throw null; } set { } }
        public int? PodPriorityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterImageRegistryState : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterImageRegistryState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CustomerManagedEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>
    {
        public CustomerManagedEncryptionProfile() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType? EncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile Kms { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomerManagedEncryptionType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomerManagedEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType Kms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskStorageAccountType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType StandardSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>
    {
        public DnsProfile() { }
        public string BaseDomain { get { throw null; } }
        public string BaseDomainPrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EtcdDataEncryptionKeyManagementModeType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EtcdDataEncryptionKeyManagementModeType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType CustomerManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EtcdDataEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>
    {
        public EtcdDataEncryptionProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType keyManagementMode) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.CustomerManagedEncryptionProfile CustomerManaged { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionKeyManagementModeType KeyManagementMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalAuthClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>
    {
        public ExternalAuthClaimProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile mappings) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile Mappings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule> ValidationRules { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalAuthClientComponentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>
    {
        public ExternalAuthClientComponentProfile(string name, string authClientNamespace) { }
        public string AuthClientNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalAuthClientProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>
    {
        public ExternalAuthClientProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile component, string clientId, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType type) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientComponentProfile Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExtraScopes { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalAuthClientType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalAuthClientType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType Confidential { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalAuthProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>
    {
        public ExternalAuthProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile issuer, Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile claim) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClaimProfile Claim { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthClientProfile> Clients { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile Issuer { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> StatusConditions { get { throw null; } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ExternalAuthProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class GroupClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>
    {
        public GroupClaimProfile(string claim) { }
        public string Claim { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HcpOpenShiftClusterAPIProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>
    {
        public HcpOpenShiftClusterAPIProfile() { }
        public System.Collections.Generic.IList<string> AuthorizedCIDRs { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility? Visibility { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcpOpenShiftClusterAPIVisibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcpOpenShiftClusterAPIVisibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIVisibility right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class HcpOpenShiftClusterPlatformProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterPlatformProfile>
    {
        public HcpOpenShiftClusterPlatformProfile(Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetIntegrationSubnetId, Azure.Core.ResourceIdentifier networkSecurityGroupId, Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile operatorsAuthenticationUserAssignedIdentities) { }
        public System.Uri IssuerUri { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile OperatorsAuthenticationUserAssignedIdentities { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType? OutboundType { get { throw null; } set { } }
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
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterAPIProfile Api { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterAutoscalingProfile Autoscaling { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ClusterImageRegistryState? ClusterImageRegistryState { get { throw null; } set { } }
        public System.Uri ConsoleUri { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.CryptoRestrictions? CryptoRestrictions { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.DnsProfile Dns { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.EtcdDataEncryptionProfile EtcdDataEncryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror> ImageDigestMirrors { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType? IngressType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile Network { get { throw null; } set { } }
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
    public partial class ImageDigestMirror : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>
    {
        public ImageDigestMirror(string source, System.Collections.Generic.IEnumerable<string> mirrors) { }
        public System.Collections.Generic.IList<string> Mirrors { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.ImageDigestMirror>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngressType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngressType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.IngressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultVisibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultVisibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KmsEncryptionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>
    {
        public KmsEncryptionProfile(string vaultName, Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility visibility, Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey activeKey) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey ActiveKey { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.KeyVaultVisibility Visibility { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsEncryptionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KmsKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>
    {
        public KmsKey(string name, string version) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.KmsKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>
    {
        public NetworkProfile() { }
        public int? HostPrefix { get { throw null; } set { } }
        public string MachineCIDR { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType? NetworkType { get { throw null; } set { } }
        public string PodCIDR { get { throw null; } set { } }
        public string ServiceCIDR { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType Other { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType OVNKubernetes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.NetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodePoolAutoScaling : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>
    {
        public NodePoolAutoScaling() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolPlatformProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>
    {
        public NodePoolPlatformProfile(string vmSize) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public bool? EnableEncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>
    {
        public NodePoolProperties(Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile platform) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolAutoScaling AutoScaling { get { throw null; } set { } }
        public bool? CanAutoRepair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolLabel> Labels { get { throw null; } }
        public int? NodeDrainTimeoutMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolPlatformProfile Platform { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterCondition> StatusConditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint> Taints { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolVersionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>
    {
        public NodePoolVersionProfile(string id) { }
        public string ChannelGroup { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.NodePoolVersionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OSDiskProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>
    {
        public OSDiskProfile() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.DiskStorageAccountType? DiskStorageAccountType { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType? DiskType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EncryptionSetId { get { throw null; } set { } }
        public int? SizeGiB { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType Ephemeral { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OSDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutboundType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutboundType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType LoadBalancer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.OutboundType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class Taint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>
    {
        public Taint(string key, Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect effect) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.HcpOpenShiftClusterNodePoolTaintEffect Effect { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.Taint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenClaimMappingsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>
    {
        public TokenClaimMappingsProfile(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile username) { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.GroupClaimProfile Groups { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimMappingsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenClaimValidationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>
    {
        public TokenClaimValidationRule() { }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim RequiredClaim { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenClaimValidationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenIssuerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>
    {
        public TokenIssuerProfile(System.Uri uri, System.Collections.Generic.IEnumerable<string> audiences) { }
        public System.Collections.Generic.IList<string> Audiences { get { throw null; } }
        public string CA { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenIssuerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenRequiredClaim : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>
    {
        public TokenRequiredClaim(string claim, string requiredValue) { }
        public string Claim { get { throw null; } set { } }
        public string RequiredValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenRequiredClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenValidationRuleType : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenValidationRuleType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType RequiredClaim { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.TokenValidationRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAssignedIdentitiesProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>
    {
        public UserAssignedIdentitiesProfile(System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> controlPlaneOperators, System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> dataPlaneOperators, Azure.Core.ResourceIdentifier serviceManagedIdentity) { }
        public System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> ControlPlaneOperators { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Core.ResourceIdentifier> DataPlaneOperators { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceManagedIdentity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UserAssignedIdentitiesProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsernameClaimPrefixPolicy : System.IEquatable<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsernameClaimPrefixPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy None { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy NoPrefix { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy Prefix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy left, Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UsernameClaimProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>
    {
        public UsernameClaimProfile(string claim) { }
        public string Claim { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimPrefixPolicy? PrefixPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShiftHcp.Models.UsernameClaimProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
