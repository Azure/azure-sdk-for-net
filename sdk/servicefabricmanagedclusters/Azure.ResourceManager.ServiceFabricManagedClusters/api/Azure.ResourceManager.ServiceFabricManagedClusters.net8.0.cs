namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class AzureResourceManagerServiceFabricManagedClustersContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerServiceFabricManagedClustersContext() { }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.AzureResourceManagerServiceFabricManagedClustersContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedApplicationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>
    {
        public ServiceFabricManagedApplicationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo> ManagedIdentities { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedApplicationResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> GetServiceFabricManagedService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> GetServiceFabricManagedServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceCollection GetServiceFabricManagedServices() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReadUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReadUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeUpgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeUpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartRollback(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartRollbackAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedApplicationTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> Get(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> GetAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> GetIfExists(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> GetIfExistsAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>
    {
        public ServiceFabricManagedApplicationTypeData(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedApplicationTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> GetServiceFabricManagedApplicationTypeVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> GetServiceFabricManagedApplicationTypeVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionCollection GetServiceFabricManagedApplicationTypeVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedApplicationTypeVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>
    {
        public ServiceFabricManagedApplicationTypeVersionData(Azure.Core.AzureLocation location) { }
        public System.Uri AppPackageUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedApplicationTypeVersionResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationTypeName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>
    {
        public ServiceFabricManagedClusterData(Azure.Core.AzureLocation location) { }
        public ServiceFabricManagedClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature> AddOnFeatures { get { throw null; } }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } set { } }
        public int? AllocatedOutboundPorts { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet> AuxiliarySubnets { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory AzureActiveDirectory { get { throw null; } set { } }
        public int? ClientConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate> Clients { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> ClusterCertificateThumbprints { get { throw null; } }
        public string ClusterCodeVersion { get { throw null; } set { } }
        public System.Guid? ClusterId { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState? ClusterState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence? ClusterUpgradeCadence { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode? ClusterUpgradeMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DdosProtectionPlanId { get { throw null; } set { } }
        public string DnsName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection> FabricSettings { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public bool? HasZoneResiliency { get { throw null; } set { } }
        public int? HttpGatewayConnectionPort { get { throw null; } set { } }
        public int? HttpGatewayTokenAuthConnectionPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag> IPTags { get { throw null; } }
        public System.Net.IPAddress IPv4Address { get { throw null; } }
        public System.Net.IPAddress IPv6Address { get { throw null; } }
        public bool? IsAutoOSUpgradeEnabled { get { throw null; } set { } }
        public bool? IsHttpGatewayExclusiveAuthModeEnabled { get { throw null; } set { } }
        public bool? IsIPv6Enabled { get { throw null; } set { } }
        public bool? IsRdpAccessAllowed { get { throw null; } set { } }
        public bool? IsServicePublicIPEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule> LoadBalancingRules { get { throw null; } }
        public int? MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPv6PrefixId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint> ServiceEndpoints { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName? SkuName { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public bool? UseCustomVnet { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode? ZonalUpdateMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedClusterResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus> GetManagedAzResiliencyStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>> GetManagedAzResiliencyStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus> GetManagedMaintenanceWindowStatu(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>> GetManagedMaintenanceWindowStatuAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus> GetManagedMaintenanceWindowStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>> GetManagedMaintenanceWindowStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource> GetServiceFabricManagedApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource>> GetServiceFabricManagedApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationCollection GetServiceFabricManagedApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource> GetServiceFabricManagedApplicationType(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource>> GetServiceFabricManagedApplicationTypeAsync(string applicationTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeCollection GetServiceFabricManagedApplicationTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> GetServiceFabricManagedNodeType(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> GetServiceFabricManagedNodeTypeAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeCollection GetServiceFabricManagedNodeTypes() { throw null; }
        public virtual Azure.Response PostManagedApplyMaintenanceWindow(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostManagedApplyMaintenanceWindowAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceFabricManagedClustersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSize(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>> GetManagedUnsupportedVmSizeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource GetServiceFabricManagedApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource GetServiceFabricManagedApplicationTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource GetServiceFabricManagedApplicationTypeVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetServiceFabricManagedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource GetServiceFabricManagedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterCollection GetServiceFabricManagedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource GetServiceFabricManagedNodeTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource GetServiceFabricManagedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ServiceFabricManagedNodeTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedNodeTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodeTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> Get(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> GetAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> GetIfExists(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> GetIfExistsAsync(string nodeTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedNodeTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>
    {
        public ServiceFabricManagedNodeTypeData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk> AdditionalDataDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration> AdditionalNetworkInterfaceConfigurations { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capacities { get { throw null; } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string DataDiskLetter { get { throw null; } set { } }
        public int? DataDiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType? DataDiskType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration> FrontendConfigurations { get { throw null; } }
        public bool? HasMultiplePlacementGroups { get { throw null; } set { } }
        public string HostGroupId { get { throw null; } set { } }
        public bool? IsAcceleratedNetworkingEnabled { get { throw null; } set { } }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public bool? IsNodePublicIPEnabled { get { throw null; } set { } }
        public bool? IsNodePublicIPv6Enabled { get { throw null; } set { } }
        public bool? IsOverProvisioningEnabled { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsSpotVm { get { throw null; } set { } }
        public bool? IsStateless { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig> NatConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NatGatewayId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> NetworkSecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> PlacementProperties { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType? SecurityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public string SpotRestoreTimeout { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseDefaultPublicLoadBalancer { get { throw null; } set { } }
        public bool? UseEphemeralOSDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> UserAssignedIdentities { get { throw null; } }
        public bool? UseTempDataDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication> VmApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension> VmExtensions { get { throw null; } }
        public string VmImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan VmImagePlan { get { throw null; } set { } }
        public string VmImagePublisher { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmImageResourceId { get { throw null; } set { } }
        public string VmImageSku { get { throw null; } set { } }
        public string VmImageVersion { get { throw null; } set { } }
        public int? VmInstanceCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup> VmSecrets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction> VmSetupActions { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmSharedGalleryImageId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedNodeTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedNodeTypeResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string nodeTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetAvailableSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku> GetAvailableSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricManagedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricManagedServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricManagedServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>
    {
        public ServiceFabricManagedServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricManagedServiceResource() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource> Update(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource>> UpdateAsync(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Mocking
{
    public partial class MockableServiceFabricManagedClustersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceFabricManagedClustersArmClient() { }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationResource GetServiceFabricManagedApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeResource GetServiceFabricManagedApplicationTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionResource GetServiceFabricManagedApplicationTypeVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource GetServiceFabricManagedClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeResource GetServiceFabricManagedNodeTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceResource GetServiceFabricManagedServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableServiceFabricManagedClustersResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceFabricManagedClustersResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource>> GetServiceFabricManagedClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterCollection GetServiceFabricManagedClusters() { throw null; }
    }
    public partial class MockableServiceFabricManagedClustersSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceFabricManagedClustersSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersion(Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionAsync(Azure.Core.AzureLocation location, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionByEnvironment(Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>> GetManagedClusterVersionByEnvironmentAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, string clusterVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersions(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironment(Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironmentAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSize(Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>> GetManagedUnsupportedVmSizeAsync(Azure.Core.AzureLocation location, string vmSize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSizes(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize> GetManagedUnsupportedVmSizesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterResource> GetServiceFabricManagedClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class AdditionalNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>
    {
        public AdditionalNetworkInterfaceConfiguration(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration> ipConfigurations) { }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationHealthPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>
    {
        public ApplicationHealthPolicy(bool considerWarningAsError, int maxPercentUnhealthyDeployedApplications) { }
        public bool ConsiderWarningAsError { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy DefaultServiceTypeHealthPolicy { get { throw null; } set { } }
        public int MaxPercentUnhealthyDeployedApplications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy> ServiceTypeHealthPolicyMap { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>
    {
        public ApplicationUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public long? InstanceCloseDelayDurationInSeconds { get { throw null; } set { } }
        public bool? RecreateApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode? UpgradeMode { get { throw null; } set { } }
        public long? UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationUserAssignedIdentityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>
    {
        public ApplicationUserAssignedIdentityInfo(string name, string principalId) { }
        public string Name { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmServiceFabricManagedClustersModelFactory
    {
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus ManagedAzResiliencyStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus> baseResourceStatus = null, bool? isClusterZoneResilient = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus ManagedMaintenanceWindowStatus(bool? isWindowEnabled = default(bool?), bool? isRegionReady = default(bool?), bool? isWindowActive = default(bool?), bool? canApplyUpdates = default(bool?), System.DateTimeOffset? lastWindowStatusUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastWindowEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties ManagedServiceProperties(string placementConstraints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation> correlationScheme = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric> serviceLoadMetrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy> servicePlacementPolicies = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost? defaultMoveCost = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy> scalingPolicies = null, string provisioningState = null, string serviceKind = null, string serviceTypeName = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode? servicePackageActivationMode = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode?), string serviceDnsName = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku NodeTypeAvailableSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku sku = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity NodeTypeSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType? scaleType = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType?)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku NodeTypeSupportedSku(string name = null, string tier = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension NodeTypeVmssExtension(string name = null, string publisher = null, string vmssExtensionPropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string forceUpdateTag = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, string provisioningState = null, bool? isAutomaticUpgradeEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder> setupOrder = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus ResourceAzStatus(string resourceName = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), bool? isZoneResilient = default(bool?), string details = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationData ServiceFabricManagedApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, string version = null, System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUpgradePolicy upgradePolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ApplicationUserAssignedIdentityInfo> managedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeData ServiceFabricManagedApplicationTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedApplicationTypeVersionData ServiceFabricManagedApplicationTypeVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, System.Uri appPackageUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData ServiceFabricManagedClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName? skuName, string dnsName, string fqdn, System.Net.IPAddress ipv4Address, System.Guid? clusterId, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState? clusterState, System.Collections.Generic.IEnumerable<System.BinaryData> clusterCertificateThumbprints, int? clientConnectionPort, int? httpGatewayConnectionPort, string adminUserName, string adminPassword, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule> loadBalancingRules, bool? isRdpAccessAllowed, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> networkSecurityRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate> clients, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory azureActiveDirectory, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection> fabricSettings, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? provisioningState, string clusterCodeVersion, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode? clusterUpgradeMode, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence? clusterUpgradeCadence, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature> addOnFeatures, bool? isAutoOSUpgradeEnabled, bool? hasZoneResiliency, int? maxUnusedVersionsToKeep, bool? isIPv6Enabled, string subnetId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag> ipTags, System.Net.IPAddress ipv6Address, bool? isServicePublicIPEnabled, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet> auxiliarySubnets, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint> serviceEndpoints, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode? zonalUpdateMode, bool? useCustomVnet, Azure.Core.ResourceIdentifier publicIPPrefixId, Azure.Core.ResourceIdentifier publicIPv6PrefixId, Azure.Core.ResourceIdentifier ddosProtectionPlanId, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy upgradeDescription, int? httpGatewayTokenAuthConnectionPort, bool? isHttpGatewayExclusiveAuthModeEnabled, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedClusterData ServiceFabricManagedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName? skuName = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName?), string dnsName = null, string fqdn = null, System.Net.IPAddress ipv4Address = null, System.Guid? clusterId = default(System.Guid?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState? clusterState = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState?), System.Collections.Generic.IEnumerable<System.BinaryData> clusterCertificateThumbprints = null, int? clientConnectionPort = default(int?), int? httpGatewayConnectionPort = default(int?), string adminUserName = null, string adminPassword = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule> loadBalancingRules = null, bool? isRdpAccessAllowed = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> networkSecurityRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate> clients = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory azureActiveDirectory = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection> fabricSettings = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState?), string clusterCodeVersion = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode? clusterUpgradeMode = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence? clusterUpgradeCadence = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature> addOnFeatures = null, bool? isAutoOSUpgradeEnabled = default(bool?), bool? hasZoneResiliency = default(bool?), int? maxUnusedVersionsToKeep = default(int?), bool? isIPv6Enabled = default(bool?), string subnetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag> ipTags = null, System.Net.IPAddress ipv6Address = null, bool? isServicePublicIPEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet> auxiliarySubnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint> serviceEndpoints = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode? zonalUpdateMode = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode?), bool? useCustomVnet = default(bool?), Azure.Core.ResourceIdentifier publicIPPrefixId = null, Azure.Core.ResourceIdentifier publicIPv6PrefixId = null, Azure.Core.ResourceIdentifier ddosProtectionPlanId = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy upgradeDescription = null, int? httpGatewayTokenAuthConnectionPort = default(int?), bool? isHttpGatewayExclusiveAuthModeEnabled = default(bool?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope?), int? allocatedOutboundPorts = default(int?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion ServiceFabricManagedClusterVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterCodeVersion = null, System.DateTimeOffset? versionSupportExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType? osType = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData ServiceFabricManagedNodeTypeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku sku, bool? isPrimary, int? vmInstanceCount, int? dataDiskSizeInGB, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType? dataDiskType, string dataDiskLetter, System.Collections.Generic.IDictionary<string, string> placementProperties, System.Collections.Generic.IDictionary<string, string> capacities, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription applicationPorts, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription ephemeralPorts, string vmSize, string vmImagePublisher, string vmImageOffer, string vmImageSku, string vmImageVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup> vmSecrets, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension> vmExtensions, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> userAssignedIdentities, bool? isStateless, bool? hasMultiplePlacementGroups, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration> frontendConfigurations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> networkSecurityRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk> additionalDataDisks, bool? isEncryptionAtHostEnabled, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? provisioningState, bool? isAcceleratedNetworkingEnabled, bool? useDefaultPublicLoadBalancer, bool? useTempDataDisk, bool? isOverProvisioningEnabled, System.Collections.Generic.IEnumerable<string> zones, bool? isSpotVm, string hostGroupId, bool? useEphemeralOSDisk, string spotRestoreTimeout, Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType? evictionPolicy, Azure.Core.ResourceIdentifier vmImageResourceId, Azure.Core.ResourceIdentifier subnetId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction> vmSetupActions, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType? securityType, bool? isSecureBootEnabled, bool? isNodePublicIPEnabled, bool? isNodePublicIPv6Enabled, Azure.Core.ResourceIdentifier vmSharedGalleryImageId, Azure.Core.ResourceIdentifier natGatewayId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig> natConfigurations, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan vmImagePlan, Azure.Core.ResourceIdentifier serviceArtifactReferenceId, Azure.Core.ResourceIdentifier dscpConfigurationId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration> additionalNetworkInterfaceConfigurations, string computerNamePrefix, System.Collections.Generic.IDictionary<string, string> tags) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedNodeTypeData ServiceFabricManagedNodeTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku sku = null, bool? isPrimary = default(bool?), int? vmInstanceCount = default(int?), int? dataDiskSizeInGB = default(int?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType? dataDiskType = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType?), string dataDiskLetter = null, System.Collections.Generic.IDictionary<string, string> placementProperties = null, System.Collections.Generic.IDictionary<string, string> capacities = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription applicationPorts = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription ephemeralPorts = null, string vmSize = null, string vmImagePublisher = null, string vmImageOffer = null, string vmImageSku = null, string vmImageVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup> vmSecrets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension> vmExtensions = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> userAssignedIdentities = null, bool? isStateless = default(bool?), bool? hasMultiplePlacementGroups = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration> frontendConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule> networkSecurityRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk> additionalDataDisks = null, bool? isEncryptionAtHostEnabled = default(bool?), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState?), bool? isAcceleratedNetworkingEnabled = default(bool?), bool? useDefaultPublicLoadBalancer = default(bool?), bool? useTempDataDisk = default(bool?), bool? isOverProvisioningEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> zones = null, bool? isSpotVm = default(bool?), string hostGroupId = null, bool? useEphemeralOSDisk = default(bool?), string spotRestoreTimeout = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType?), Azure.Core.ResourceIdentifier vmImageResourceId = null, Azure.Core.ResourceIdentifier subnetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction> vmSetupActions = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType? securityType = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType?), bool? isSecureBootEnabled = default(bool?), bool? isNodePublicIPEnabled = default(bool?), bool? isNodePublicIPv6Enabled = default(bool?), Azure.Core.ResourceIdentifier vmSharedGalleryImageId = null, Azure.Core.ResourceIdentifier natGatewayId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig> natConfigurations = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan vmImagePlan = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.Core.ResourceIdentifier dscpConfigurationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AdditionalNetworkInterfaceConfiguration> additionalNetworkInterfaceConfigurations = null, string computerNamePrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication> vmApplications = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.ServiceFabricManagedServiceData ServiceFabricManagedServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize ServiceFabricManagedUnsupportedVmSize(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string vmSize = null) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties StatefulServiceProperties(string placementConstraints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation> correlationScheme = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric> serviceLoadMetrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy> servicePlacementPolicies = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost? defaultMoveCost = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy> scalingPolicies = null, string provisioningState = null, string serviceTypeName = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode? servicePackageActivationMode = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode?), string serviceDnsName = null, bool? hasPersistedState = default(bool?), int? targetReplicaSetSize = default(int?), int? minReplicaSetSize = default(int?), System.TimeSpan? replicaRestartWaitDuration = default(System.TimeSpan?), System.TimeSpan? quorumLossWaitDuration = default(System.TimeSpan?), System.TimeSpan? standByReplicaKeepDuration = default(System.TimeSpan?), System.TimeSpan? servicePlacementTimeLimit = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties StatelessServiceProperties(string placementConstraints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation> correlationScheme = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric> serviceLoadMetrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy> servicePlacementPolicies = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost? defaultMoveCost = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy> scalingPolicies = null, string provisioningState = null, string serviceTypeName = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription = null, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode? servicePackageActivationMode = default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode?), string serviceDnsName = null, int instanceCount = 0, int? minInstanceCount = default(int?), int? minInstancePercentage = default(int?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AveragePartitionLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>
    {
        public AveragePartitionLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AveragePartitionLoadScalingTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AverageServiceLoadScalingTrigger : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>
    {
        public AverageServiceLoadScalingTrigger(string metricName, double lowerLoadThreshold, double upperLoadThreshold, string scaleInterval, bool useOnlyPrimaryLoad) { }
        public double LowerLoadThreshold { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string ScaleInterval { get { throw null; } set { } }
        public double UpperLoadThreshold { get { throw null; } set { } }
        public bool UseOnlyPrimaryLoad { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.AverageServiceLoadScalingTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterFabricSettingsParameterDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>
    {
        public ClusterFabricSettingsParameterDescription(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterFabricSettingsSection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>
    {
        public ClusterFabricSettingsSection(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription> parameters) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsParameterDescription> Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ClusterFabricSettingsSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointRangeDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>
    {
        public EndpointRangeDescription(int startPort, int endPort) { }
        public int EndPort { get { throw null; } set { } }
        public int StartPort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.EndpointRangeDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedAzResiliencyStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>
    {
        internal ManagedAzResiliencyStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus> BaseResourceStatus { get { throw null; } }
        public bool? IsClusterZoneResilient { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedAzResiliencyStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterAddOnFeature : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterAddOnFeature(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature BackupRestoreService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature DnsService { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature ResourceMonitorService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAddOnFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterAzureActiveDirectory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>
    {
        public ManagedClusterAzureActiveDirectory() { }
        public string ClientApplication { get { throw null; } set { } }
        public string ClusterApplication { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterAzureActiveDirectory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedClusterClientCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>
    {
        public ManagedClusterClientCertificate(bool isAdmin) { }
        public string CommonName { get { throw null; } set { } }
        public bool IsAdmin { get { throw null; } set { } }
        public System.BinaryData IssuerThumbprint { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterClientCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedClusterHealthPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>
    {
        public ManagedClusterHealthPolicy(int maxPercentUnhealthyNodes, int maxPercentUnhealthyApplications) { }
        public int MaxPercentUnhealthyApplications { get { throw null; } set { } }
        public int MaxPercentUnhealthyNodes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedClusterIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>
    {
        public ManagedClusterIPTag(string ipTagType, string tag) { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterLoadBalanceProbeProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterLoadBalanceProbeProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterLoadBalancingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>
    {
        public ManagedClusterLoadBalancingRule(int frontendPort, int backendPort, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol probeProtocol) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPort { get { throw null; } set { } }
        public string LoadDistribution { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalanceProbeProtocol ProbeProtocol { get { throw null; } set { } }
        public string ProbeRequestPath { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterLoadBalancingRuleTransportProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterLoadBalancingRuleTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterLoadBalancingRuleTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterMonitoringPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>
    {
        public ManagedClusterMonitoringPolicy(System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, string healthCheckRetryTimeout, string upgradeTimeout, string upgradeDomainTimeout) { }
        public string HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public string UpgradeDomainTimeout { get { throw null; } set { } }
        public string UpgradeTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedClusterServiceEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>
    {
        public ManagedClusterServiceEndpoint(string service) { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Service { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterServiceEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedClusterSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>
    {
        public ManagedClusterSubnet(string name) { }
        public bool? IsIPv6Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState? PrivateEndpointNetworkPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState? PrivateLinkServiceNetworkPolicies { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterSubnetPrivateEndpointNetworkPoliciesState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterSubnetPrivateEndpointNetworkPoliciesState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateEndpointNetworkPoliciesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeCadence : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeCadence(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave0 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave1 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence Wave2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeCadence right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterUpgradeDeltaHealthPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>
    {
        public ManagedClusterUpgradeDeltaHealthPolicy(int maxPercentDeltaUnhealthyNodes) { }
        public int? MaxPercentDeltaUnhealthyApplications { get { throw null; } set { } }
        public int MaxPercentDeltaUnhealthyNodes { get { throw null; } set { } }
        public int? MaxPercentUpgradeDomainDeltaUnhealthyNodes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>
    {
        public ManagedClusterUpgradePolicy() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradeDeltaHealthPolicy DeltaHealthPolicy { get { throw null; } set { } }
        public bool? ForceRestart { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterHealthPolicy HealthPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterMonitoringPolicy MonitoringPolicy { get { throw null; } set { } }
        public string UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterVersionEnvironment : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterVersionEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterVersionEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedMaintenanceWindowStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>
    {
        internal ManagedMaintenanceWindowStatus() { }
        public bool? CanApplyUpdates { get { throw null; } }
        public bool? IsRegionReady { get { throw null; } }
        public bool? IsWindowActive { get { throw null; } }
        public bool? IsWindowEnabled { get { throw null; } }
        public System.DateTimeOffset? LastWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? LastWindowStartOn { get { throw null; } }
        public System.DateTimeOffset? LastWindowStatusUpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedMaintenanceWindowStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>
    {
        public ManagedServiceBaseProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation> CorrelationScheme { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost? DefaultMoveCost { get { throw null; } set { } }
        public string PlacementConstraints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy> ScalingPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric> ServiceLoadMetrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy> ServicePlacementPolicies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceCorrelation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>
    {
        public ManagedServiceCorrelation(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme scheme, string serviceName) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme Scheme { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceCorrelationScheme : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceCorrelationScheme(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme AlignedAffinity { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme NonAlignedAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceCorrelationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceLoadMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>
    {
        public ManagedServiceLoadMetric(string name) { }
        public int? DefaultLoad { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? PrimaryDefaultLoad { get { throw null; } set { } }
        public int? SecondaryDefaultLoad { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight? Weight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceLoadMetricWeight : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceLoadMetricWeight(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceLoadMetricWeight right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServicePackageActivationMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServicePackageActivationMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode ExclusiveProcess { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode SharedProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ManagedServicePartitionScheme : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>
    {
        protected ManagedServicePartitionScheme() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ManagedServicePlacementPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>
    {
        protected ManagedServicePlacementPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>
    {
        public ManagedServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme PartitionDescription { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceDnsName { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePackageActivationMode? ServicePackageActivationMode { get { throw null; } set { } }
        public string ServiceTypeName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ManagedServiceScalingMechanism : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>
    {
        protected ManagedServiceScalingMechanism() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceScalingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>
    {
        public ManagedServiceScalingPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism scalingMechanism, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger scalingTrigger) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism ScalingMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger ScalingTrigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ManagedServiceScalingTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>
    {
        protected ManagedServiceScalingTrigger() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedPartitionAddOrRemoveScalingMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>
    {
        public NamedPartitionAddOrRemoveScalingMechanism(int minPartitionCount, int maxPartitionCount, int scaleIncrement) { }
        public int MaxPartitionCount { get { throw null; } set { } }
        public int MinPartitionCount { get { throw null; } set { } }
        public int ScaleIncrement { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionAddOrRemoveScalingMechanism>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>
    {
        public NamedPartitionScheme(System.Collections.Generic.IEnumerable<string> names) { }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NamedPartitionScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>
    {
        public NodeTypeActionContent() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This constructor is obsolete and will be removed in a future release", false)]
        public NodeTypeActionContent(System.Collections.Generic.IEnumerable<string> nodes) { }
        public bool? IsForced { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Nodes { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType? UpdateType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeAvailableSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>
    {
        internal NodeTypeAvailableSku() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeAvailableSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeFrontendConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>
    {
        public NodeTypeFrontendConfiguration() { }
        public Azure.Core.ResourceIdentifier ApplicationGatewayBackendAddressPoolId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType? IPAddressType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancerBackendAddressPoolId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancerInboundNatPoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeTypeFrontendConfigurationIPAddressType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeTypeFrontendConfigurationIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeFrontendConfigurationIPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeTypeNatConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>
    {
        public NodeTypeNatConfig() { }
        public int? BackendPort { get { throw null; } set { } }
        public int? FrontendPortRangeEnd { get { throw null; } set { } }
        public int? FrontendPortRangeStart { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeNatConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>
    {
        public NodeTypeSku(int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>
    {
        internal NodeTypeSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeTypeSkuScaleType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeTypeSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeTypeSupportedSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>
    {
        internal NodeTypeSupportedSku() { }
        public string Name { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSupportedSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeVaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>
    {
        public NodeTypeVaultCertificate(System.Uri certificateUri, string certificateStore) { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeVaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>
    {
        public NodeTypeVaultSecretGroup(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate> vaultCertificates) { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultCertificate> VaultCertificates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeVmssDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>
    {
        public NodeTypeVmssDataDisk(int lun, int diskSizeInGB, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType diskType, string diskLetter) { }
        public string DiskLetter { get { throw null; } set { } }
        public int DiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType DiskType { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeVmssExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>
    {
        public NodeTypeVmssExtension(string name, string publisher, string vmssExtensionPropertiesType, string typeHandlerVersion) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder> SetupOrder { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VmssExtensionPropertiesType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeVmssExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartitionInstanceCountScalingMechanism : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceScalingMechanism, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>
    {
        public PartitionInstanceCountScalingMechanism(int minInstanceCount, int maxInstanceCount, int scaleIncrement) { }
        public int MaxInstanceCount { get { throw null; } set { } }
        public int MinInstanceCount { get { throw null; } set { } }
        public int ScaleIncrement { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PartitionInstanceCountScalingMechanism>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyViolationCompensationAction : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyViolationCompensationAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction Manual { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction Rollback { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceAzStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>
    {
        internal ResourceAzStatus() { }
        public string Details { get { throw null; } }
        public bool? IsZoneResilient { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ResourceAzStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RollingUpgradeMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RollingUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode Monitored { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode UnmonitoredAuto { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RollingUpgradeMonitoringPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>
    {
        public RollingUpgradeMonitoringPolicy(Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction failureAction, System.TimeSpan healthCheckWaitDuration, System.TimeSpan healthCheckStableDuration, System.TimeSpan healthCheckRetryTimeout, System.TimeSpan upgradeTimeout, System.TimeSpan upgradeDomainTimeout) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.PolicyViolationCompensationAction FailureAction { get { throw null; } set { } }
        public System.TimeSpan HealthCheckRetryTimeout { get { throw null; } set { } }
        public System.TimeSpan HealthCheckStableDuration { get { throw null; } set { } }
        public System.TimeSpan HealthCheckWaitDuration { get { throw null; } set { } }
        public System.TimeSpan UpgradeDomainTimeout { get { throw null; } set { } }
        public System.TimeSpan UpgradeTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RollingUpgradeMonitoringPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuntimeResumeApplicationUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>
    {
        public RuntimeResumeApplicationUpgradeContent() { }
        public string UpgradeDomainName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.RuntimeResumeApplicationUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>
    {
        public ServiceFabricManagedApplicationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>
    {
        public ServiceFabricManagedApplicationTypePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedApplicationTypeVersionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>
    {
        public ServiceFabricManagedApplicationTypeVersionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedApplicationTypeVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedClusterIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>
    {
        public ServiceFabricManagedClusterIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterOSType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterOSType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>
    {
        public ServiceFabricManagedClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterPrivateIPAddressVersion : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterPrivateIPAddressVersion(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPrivateIPAddressVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClusterPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>
    {
        public ServiceFabricManagedClusterPublicIPAddressConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedClusterIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion? PublicIPAddressVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterPublicIPAddressVersion : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterPublicIPAddressVersion(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterPublicIPAddressVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterSecurityType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType Standard { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClustersSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>
    {
        public ServiceFabricManagedClustersSku(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName name) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClustersSkuName : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClustersSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClustersSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState BaselineUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Deploying { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState Upgrading { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState WaitingForNodes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedClusterUpdateType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedClusterUpdateType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType ByUpgradeDomain { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedClusterVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>
    {
        internal ServiceFabricManagedClusterVersion() { }
        public string ClusterCodeVersion { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterOSType? OSType { get { throw null; } }
        public System.DateTimeOffset? VersionSupportExpireOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedClusterVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedDataDiskType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedDataDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType StandardSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedDataDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedNetworkSecurityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>
    {
        public ServiceFabricManagedNetworkSecurityRule(string name, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol protocol, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess access, int priority, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection direction) { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DestinationAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationAddressPrefixes { get { throw null; } }
        public string DestinationPortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationPortRanges { get { throw null; } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Protocol { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        public string SourcePortRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedNetworkSecurityRuleDirection : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedNetworkSecurityRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkSecurityRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedNetworkTrafficAccess : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedNetworkTrafficAccess(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess Allow { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNetworkTrafficAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedNodeTypePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>
    {
        public ServiceFabricManagedNodeTypePatch() { }
        public Azure.ResourceManager.ServiceFabricManagedClusters.Models.NodeTypeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNodeTypePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedNsgProtocol : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedNsgProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol AH { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Esp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedNsgProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState None { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Other { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFabricManagedServiceMoveCost : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFabricManagedServiceMoveCost(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost High { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost Low { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost Medium { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServiceMoveCost right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceFabricManagedServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>
    {
        public ServiceFabricManagedServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedUnsupportedVmSize : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>
    {
        internal ServiceFabricManagedUnsupportedVmSize() { }
        public string VmSize { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedUnsupportedVmSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceFabricManagedVmApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>
    {
        public ServiceFabricManagedVmApplication(Azure.Core.ResourceIdentifier packageReferenceId) { }
        public System.Uri ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PackageReferenceId { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        public string VmGalleryTags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceFabricManagedVmApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePlacementInvalidDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>
    {
        public ServicePlacementInvalidDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementInvalidDomainPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePlacementNonPartiallyPlaceServicePolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>
    {
        public ServicePlacementNonPartiallyPlaceServicePolicy() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementNonPartiallyPlaceServicePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePlacementPreferPrimaryDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>
    {
        public ServicePlacementPreferPrimaryDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementPreferPrimaryDomainPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePlacementRequiredDomainPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>
    {
        public ServicePlacementRequiredDomainPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequiredDomainPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePlacementRequireDomainDistributionPolicy : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePlacementPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>
    {
        public ServicePlacementRequireDomainDistributionPolicy(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServicePlacementRequireDomainDistributionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceTypeHealthPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>
    {
        public ServiceTypeHealthPolicy(int maxPercentUnhealthyServices, int maxPercentUnhealthyPartitionsPerService, int maxPercentUnhealthyReplicasPerPartition) { }
        public int MaxPercentUnhealthyPartitionsPerService { get { throw null; } set { } }
        public int MaxPercentUnhealthyReplicasPerPartition { get { throw null; } set { } }
        public int MaxPercentUnhealthyServices { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ServiceTypeHealthPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingletonPartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>
    {
        public SingletonPartitionScheme() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SingletonPartitionScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpotNodeVmEvictionPolicyType : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpotNodeVmEvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.SpotNodeVmEvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatefulServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>
    {
        public StatefulServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme)) { }
        public bool? HasPersistedState { get { throw null; } set { } }
        public int? MinReplicaSetSize { get { throw null; } set { } }
        public System.TimeSpan? QuorumLossWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ReplicaRestartWaitDuration { get { throw null; } set { } }
        public System.TimeSpan? ServicePlacementTimeLimit { get { throw null; } set { } }
        public System.TimeSpan? StandByReplicaKeepDuration { get { throw null; } set { } }
        public int? TargetReplicaSetSize { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatefulServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatelessServiceProperties : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServiceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>
    {
        public StatelessServiceProperties(string serviceTypeName, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme partitionDescription, int instanceCount) : base (default(string), default(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme)) { }
        public int InstanceCount { get { throw null; } set { } }
        public int? MinInstanceCount { get { throw null; } set { } }
        public int? MinInstancePercentage { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.StatelessServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UniformInt64RangePartitionScheme : Azure.ResourceManager.ServiceFabricManagedClusters.Models.ManagedServicePartitionScheme, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>
    {
        public UniformInt64RangePartitionScheme(int count, long lowKey, long highKey) { }
        public int Count { get { throw null; } set { } }
        public long HighKey { get { throw null; } set { } }
        public long LowKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.UniformInt64RangePartitionScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmImagePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>
    {
        public VmImagePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmImagePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmSetupAction : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmSetupAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction EnableContainers { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction EnableHyperV { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmSetupAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmssExtensionSetupOrder : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmssExtensionSetupOrder(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder BeforeSFRuntime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.VmssExtensionSetupOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonalUpdateMode : System.IEquatable<Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonalUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode Fast { get { throw null; } }
        public static Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode left, Azure.ResourceManager.ServiceFabricManagedClusters.Models.ZonalUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
