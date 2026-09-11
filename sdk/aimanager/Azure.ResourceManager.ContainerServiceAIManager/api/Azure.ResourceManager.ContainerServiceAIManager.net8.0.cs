namespace Azure.ResourceManager.ContainerServiceAIManager
{
    public partial class AIManagerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>, System.Collections.IEnumerable
    {
        protected AIManagerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aiManagerName, Azure.ResourceManager.ContainerServiceAIManager.AIManagerData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aiManagerName, Azure.ResourceManager.ContainerServiceAIManager.AIManagerData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> Get(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> GetAsync(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetIfExists(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> GetIfExistsAsync(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AIManagerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>
    {
        public AIManagerData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIManagerNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>, System.Collections.IEnumerable
    {
        protected AIManagerNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AIManagerNamespaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>
    {
        public AIManagerNamespaceData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIManagerNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AIManagerNamespaceResource() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string aiManagerName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo> GetAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>> GetAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults> GetCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>> GetCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> GetModelDeployment(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> GetModelDeploymentAsync(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentCollection GetModelDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo> RotateKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>> RotateKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AIManagerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AIManagerResource() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string aiManagerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource> GetAIManagerNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource>> GetAIManagerNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceCollection GetAIManagerNamespaces() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults> GetCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>> GetCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> GetModelSource(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> GetModelSourceAsync(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelSourceCollection GetModelSources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIManagerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIManagerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> Update(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> UpdateAsync(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AIModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>, System.Collections.IEnumerable
    {
        protected AIModelCollection() { }
        public virtual Azure.Response<bool> Exists(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> Get(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>> GetAsync(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> GetIfExists(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>> GetIfExistsAsync(string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AIModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>
    {
        internal AIModelData() { }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AIModelResource() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult> CalculateCost(Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>> CalculateCostAsync(Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string aiModelName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.AIModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.AIModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.AIModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerContainerServiceAIManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServiceAIManagerContext() { }
        public static Azure.ResourceManager.ContainerServiceAIManager.AzureResourceManagerContainerServiceAIManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerServiceAIManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManager(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> GetAIManagerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource GetAIManagerNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource GetAIManagerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIManagerCollection GetAIManagers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> GetAIModel(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>> GetAIModelAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIModelResource GetAIModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIModelCollection GetAIModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource GetModelDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource GetModelSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ModelDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>, System.Collections.IEnumerable
    {
        protected ModelDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string modelDeploymentName, Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string modelDeploymentName, Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> Get(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> GetAsync(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> GetIfExists(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> GetIfExistsAsync(string modelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>
    {
        public ModelDeploymentData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelDeploymentResource() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string aiManagerName, string namespaceName, string modelDeploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>, System.Collections.IEnumerable
    {
        protected ModelSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string modelSourceName, Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string modelSourceName, Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> Get(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> GetAsync(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> GetIfExists(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> GetIfExistsAsync(string modelSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ModelSourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>
    {
        public ModelSourceData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelSourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ModelSourceResource() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string aiManagerName, string modelSourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceAIManager.Mocking
{
    public partial class MockableContainerServiceAIManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceAIManagerArmClient() { }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceResource GetAIManagerNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource GetAIManagerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIModelResource GetAIModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentResource GetModelDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.ModelSourceResource GetModelSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerServiceAIManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceAIManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManager(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource>> GetAIManagerAsync(string aiManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIManagerCollection GetAIManagers() { throw null; }
    }
    public partial class MockableContainerServiceAIManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceAIManagerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManagers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceAIManager.AIManagerResource> GetAIManagersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource> GetAIModel(Azure.Core.AzureLocation location, string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceAIManager.AIModelResource>> GetAIModelAsync(Azure.Core.AzureLocation location, string aiModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceAIManager.AIModelCollection GetAIModels(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceAIManager.Models
{
    public partial class AIManagerCredentialResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>
    {
        internal AIManagerCredentialResult() { }
        public string Name { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIManagerCredentialResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>
    {
        internal AIManagerCredentialResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult> Kubeconfigs { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIManagerDeletePolicy : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIManagerDeletePolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy Keep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIManagerNamespaceAccessInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>
    {
        internal AIManagerNamespaceAccessInfo() { }
        public System.Uri Endpoint { get { throw null; } }
        public System.DateTimeOffset? LastRotatedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIManagerNamespaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>
    {
        public AIManagerNamespaceProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Annotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIManagerNamespaceProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIManagerNamespaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIManagerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>
    {
        public AIManagerPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIManagerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>
    {
        public AIManagerProperties() { }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy? DeletePolicy { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIManagerProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIManagerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIModelInfeasibilityReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>
    {
        internal AIModelInfeasibilityReason() { }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIModelInfeasibleCode : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIModelInfeasibleCode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode InefficientDeployment { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode InsufficientQuota { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode RegionUnavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode left, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AIModelProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>
    {
        internal AIModelProperties() { }
        public string Description { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec Spec { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIModelServingPerformanceEstimation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>
    {
        internal AIModelServingPerformanceEstimation() { }
        public float RelativeLatencyScore { get { throw null; } }
        public float RelativeThroughputScore { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIModelSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>
    {
        internal AIModelSpec() { }
        public bool IsRestricted { get { throw null; } }
        public string License { get { throw null; } }
        public int MaxContextLength { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmContainerServiceAIManagerModelFactory
    {
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult AIManagerCredentialResult(string name = null, System.BinaryData value = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResults AIManagerCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIManagerData AIManagerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceAccessInfo AIManagerNamespaceAccessInfo(System.Uri endpoint = null, string primaryKey = null, string secondaryKey = null, System.DateTimeOffset? lastRotatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIManagerNamespaceData AIManagerNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProperties AIManagerNamespaceProperties(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerNamespaceProvisioningState?), System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IDictionary<string, string> annotations = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerPatch AIManagerPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProperties AIManagerProperties(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerProvisioningState?), Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy? deletePolicy = default(Azure.ResourceManager.ContainerServiceAIManager.Models.AIManagerDeletePolicy?), string managedResourceGroupName = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.AIModelData AIModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason AIModelInfeasibilityReason(Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode code = default(Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibleCode), string message = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelProperties AIModelProperties(string modelId = null, string description = null, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec spec = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation AIModelServingPerformanceEstimation(float relativeLatencyScore = 0f, float relativeThroughputScore = 0f) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelSpec AIModelSpec(string license = null, bool isRestricted = false, int maxContextLength = 0) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent CalculateCostContent() { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan CalculateCostPlan(string vmSize = null, string quantization = null, int vmsPerReplica = 0, int maxAvailableReplicas = 0, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation servingPerformanceEstimation = null, double vmHourlyPrice = 0, double? totalHourlyPrice = default(double?), System.DateTimeOffset? priceAsOf = default(System.DateTimeOffset?), bool feasible = false, Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason infeasibilityReason = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult CalculateCostResult(string currency = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan> plans = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile ModelDeploymentAutoscaleProfile(int minReplicas = 0, int? maxReplicas = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.ModelDeploymentData ModelDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties ModelDeploymentProperties(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState?), Azure.Core.ResourceIdentifier modelResourceId = null, Azure.Core.ResourceIdentifier modelSourceResourceId = null, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode? performanceMode = default(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode?), string vmSize = null, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile scale = null, System.Collections.Generic.IDictionary<string, string> overridesValues = null, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus status = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile ModelDeploymentScalingProfile(int? manualReplicas = default(int?), Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile autoscale = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus ModelDeploymentStatus(System.Uri endpoint = null, string engine = null, string engineVersion = null, int? maxModelLen = default(int?), string quantization = null, int? desiredReplicas = default(int?), int? currentReplicas = default(int?), int? peakTokensPerMinute = default(int?), int? estimatedProvisionTimeSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.ModelSourceData ModelSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties ModelSourceProperties(Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState?), Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType sourceType = default(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType), string description = null, string credentialInlineValue = null) { throw null; }
    }
    public partial class CalculateCostContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>
    {
        public CalculateCostContent() { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculateCostPlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>
    {
        internal CalculateCostPlan() { }
        public bool Feasible { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelInfeasibilityReason InfeasibilityReason { get { throw null; } }
        public int MaxAvailableReplicas { get { throw null; } }
        public System.DateTimeOffset? PriceAsOf { get { throw null; } }
        public string Quantization { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.AIModelServingPerformanceEstimation ServingPerformanceEstimation { get { throw null; } }
        public double? TotalHourlyPrice { get { throw null; } }
        public double VmHourlyPrice { get { throw null; } }
        public string VmSize { get { throw null; } }
        public int VmsPerReplica { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculateCostResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>
    {
        internal CalculateCostResult() { }
        public string Currency { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostPlan> Plans { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.CalculateCostResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceAIManagerProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceAIManagerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelDeploymentAutoscaleProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>
    {
        public ModelDeploymentAutoscaleProfile(int minReplicas) { }
        public int? MaxReplicas { get { throw null; } set { } }
        public int MinReplicas { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelDeploymentPerformanceMode : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelDeploymentPerformanceMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode Balanced { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode Latency { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode Throughput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>
    {
        public ModelDeploymentProperties(Azure.Core.ResourceIdentifier modelResourceId, string vmSize) { }
        public Azure.Core.ResourceIdentifier ModelResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ModelSourceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> OverridesValues { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentPerformanceMode? PerformanceMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile Scale { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus Status { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelDeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelDeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelDeploymentScalingProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>
    {
        public ModelDeploymentScalingProfile() { }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentAutoscaleProfile Autoscale { get { throw null; } set { } }
        public int? ManualReplicas { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentScalingProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeploymentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>
    {
        internal ModelDeploymentStatus() { }
        public int? CurrentReplicas { get { throw null; } }
        public int? DesiredReplicas { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        public string Engine { get { throw null; } }
        public string EngineVersion { get { throw null; } }
        public int? EstimatedProvisionTimeSeconds { get { throw null; } }
        public int? MaxModelLen { get { throw null; } }
        public int? PeakTokensPerMinute { get { throw null; } }
        public string Quantization { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelDeploymentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>
    {
        public ModelSourceProperties(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType sourceType) { }
        public string CredentialInlineValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ContainerServiceAIManagerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType SourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelSourceType : System.IEquatable<Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType HuggingFace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType left, Azure.ResourceManager.ContainerServiceAIManager.Models.ModelSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
