namespace Azure.ResourceManager.HybridNetwork
{
    public partial class ArtifactManifestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>, System.Collections.IEnumerable
    {
        protected ArtifactManifestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string artifactManifestName, Azure.ResourceManager.HybridNetwork.ArtifactManifestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string artifactManifestName, Azure.ResourceManager.HybridNetwork.ArtifactManifestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> Get(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> GetAsync(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> GetIfExists(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> GetIfExistsAsync(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactManifestData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArtifactManifestData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class ArtifactManifestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactManifestResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactManifestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string artifactStoreName, string artifactManifestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.Models.ArtifactAccessCredential> GetCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.Models.ArtifactAccessCredential>> GetCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestUpdateState> UpdateState(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestUpdateState artifactManifestUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestUpdateState>> UpdateStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestUpdateState artifactManifestUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArtifactStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>, System.Collections.IEnumerable
    {
        protected ArtifactStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string artifactStoreName, Azure.ResourceManager.HybridNetwork.ArtifactStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string artifactStoreName, Azure.ResourceManager.HybridNetwork.ArtifactStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> Get(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> GetAsync(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> GetIfExists(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> GetIfExistsAsync(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactStoreData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArtifactStoreData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactStorePropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class ArtifactStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactStoreResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string artifactStoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource> GetArtifactManifest(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactManifestResource>> GetArtifactManifestAsync(string artifactManifestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactManifestCollection GetArtifactManifests() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactVersionsListOverview> GetProxyArtifacts(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactListOverview> GetProxyArtifacts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactVersionsListOverview> GetProxyArtifactsAsync(string artifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactListOverview> GetProxyArtifactsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactVersionsListOverview> UpdateStateProxyArtifact(Azure.WaitUntil waitUntil, string artifactVersionName, string artifactName, Azure.ResourceManager.HybridNetwork.Models.ArtifactChangeState artifactChangeState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactVersionsListOverview>> UpdateStateProxyArtifactAsync(Azure.WaitUntil waitUntil, string artifactVersionName, string artifactName, Azure.ResourceManager.HybridNetwork.Models.ArtifactChangeState artifactChangeState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ComponentResource>, System.Collections.IEnumerable
    {
        protected ComponentCollection() { }
        public virtual Azure.Response<bool> Exists(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource> Get(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ComponentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ComponentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource>> GetAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ComponentResource> GetIfExists(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ComponentResource>> GetIfExistsAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.ComponentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ComponentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.ComponentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ComponentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComponentData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentData() { }
        public Azure.ResourceManager.HybridNetwork.Models.ComponentProperties Properties { get { throw null; } set { } }
    }
    public partial class ComponentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.ComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFunctionName, string componentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationGroupSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>, System.Collections.IEnumerable
    {
        protected ConfigurationGroupSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationGroupSchemaName, Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationGroupSchemaName, Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> Get(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> GetAsync(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> GetIfExists(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> GetIfExistsAsync(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationGroupSchemaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConfigurationGroupSchemaData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class ConfigurationGroupSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationGroupSchemaResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string configurationGroupSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaVersionUpdateState> UpdateState(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaVersionUpdateState configurationGroupSchemaVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaVersionUpdateState>> UpdateStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaVersionUpdateState configurationGroupSchemaVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationGroupValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>, System.Collections.IEnumerable
    {
        protected ConfigurationGroupValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationGroupValueName, Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationGroupValueName, Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> Get(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> GetAsync(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetIfExists(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> GetIfExistsAsync(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationGroupValueData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConfigurationGroupValueData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupValuePropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class ConfigurationGroupValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationGroupValueResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationGroupValueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HybridNetworkExtensions
    {
        public static Azure.ResourceManager.HybridNetwork.ArtifactManifestResource GetArtifactManifestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ArtifactStoreResource GetArtifactStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ComponentResource GetComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource GetConfigurationGroupSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValue(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> GetConfigurationGroupValueAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource GetConfigurationGroupValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueCollection GetConfigurationGroupValues(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValues(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValuesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> GetNetworkFunctionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource GetNetworkFunctionDefinitionGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource GetNetworkFunctionDefinitionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionResource GetNetworkFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionCollection GetNetworkFunctions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunctions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunctionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource GetNetworkServiceDesignGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource GetNetworkServiceDesignVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublisher(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> GetPublisherAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.PublisherCollection GetPublishers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublishers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublishersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> GetSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> GetSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> GetSiteNetworkServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource GetSiteNetworkServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteNetworkServiceCollection GetSiteNetworkServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteResource GetSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteCollection GetSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFunctionName, Azure.ResourceManager.HybridNetwork.NetworkFunctionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFunctionName, Azure.ResourceManager.HybridNetwork.NetworkFunctionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> Get(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> GetAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetIfExists(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> GetIfExistsAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFunctionData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class NetworkFunctionDefinitionGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionDefinitionGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFunctionDefinitionGroupName, Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFunctionDefinitionGroupName, Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> Get(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> GetAsync(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> GetIfExists(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> GetIfExistsAsync(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionDefinitionGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFunctionDefinitionGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionGroupPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class NetworkFunctionDefinitionGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionDefinitionGroupResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string networkFunctionDefinitionGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> GetNetworkFunctionDefinitionVersion(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> GetNetworkFunctionDefinitionVersionAsync(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionCollection GetNetworkFunctionDefinitionVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionDefinitionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionDefinitionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFunctionDefinitionVersionName, Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFunctionDefinitionVersionName, Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> Get(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> GetAsync(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> GetIfExists(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> GetIfExistsAsync(string networkFunctionDefinitionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionDefinitionVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFunctionDefinitionVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class NetworkFunctionDefinitionVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionDefinitionVersionResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string networkFunctionDefinitionGroupName, string networkFunctionDefinitionVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionUpdateState> UpdateState(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionUpdateState networkFunctionDefinitionVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionUpdateState>> UpdateStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionUpdateState networkFunctionDefinitionVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFunctionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExecuteRequest(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ExecuteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRequestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.ExecuteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource> GetComponent(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ComponentResource>> GetComponentAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ComponentCollection GetComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkServiceDesignGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>, System.Collections.IEnumerable
    {
        protected NetworkServiceDesignGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkServiceDesignGroupName, Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkServiceDesignGroupName, Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> Get(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> GetAsync(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> GetIfExists(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> GetIfExistsAsync(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkServiceDesignGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkServiceDesignGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignGroupPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class NetworkServiceDesignGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkServiceDesignGroupResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string networkServiceDesignGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> GetNetworkServiceDesignVersion(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> GetNetworkServiceDesignVersionAsync(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionCollection GetNetworkServiceDesignVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkServiceDesignVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>, System.Collections.IEnumerable
    {
        protected NetworkServiceDesignVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkServiceDesignVersionName, Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkServiceDesignVersionName, Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> Get(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> GetAsync(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> GetIfExists(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> GetIfExistsAsync(string networkServiceDesignVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkServiceDesignVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkServiceDesignVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class NetworkServiceDesignVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkServiceDesignVersionResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName, string networkServiceDesignGroupName, string networkServiceDesignVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionUpdateState> UpdateState(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionUpdateState networkServiceDesignVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionUpdateState>> UpdateStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionUpdateState networkServiceDesignVersionUpdateState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.PublisherResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publisherName, Azure.ResourceManager.HybridNetwork.PublisherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.PublisherResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publisherName, Azure.ResourceManager.HybridNetwork.PublisherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.PublisherResource> GetIfExists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.PublisherResource>> GetIfExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.PublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublisherData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PublisherData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.PublisherPropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class PublisherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.PublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publisherName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource> GetArtifactStore(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ArtifactStoreResource>> GetArtifactStoreAsync(string artifactStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactStoreCollection GetArtifactStores() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource> GetConfigurationGroupSchema(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource>> GetConfigurationGroupSchemaAsync(string configurationGroupSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaCollection GetConfigurationGroupSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource> GetNetworkFunctionDefinitionGroup(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource>> GetNetworkFunctionDefinitionGroupAsync(string networkFunctionDefinitionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupCollection GetNetworkFunctionDefinitionGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource> GetNetworkServiceDesignGroup(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource>> GetNetworkServiceDesignGroupAsync(string networkServiceDesignGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupCollection GetNetworkServiceDesignGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.SiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.SiteResource>, System.Collections.IEnumerable
    {
        protected SiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.SiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.HybridNetwork.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.SiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.HybridNetwork.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.SiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.SiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.SiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.SiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.SiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.SiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SiteData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridNetwork.Models.SitePropertiesFormat Properties { get { throw null; } set { } }
    }
    public partial class SiteNetworkServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>, System.Collections.IEnumerable
    {
        protected SiteNetworkServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteNetworkServiceName, Azure.ResourceManager.HybridNetwork.SiteNetworkServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteNetworkServiceName, Azure.ResourceManager.HybridNetwork.SiteNetworkServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> Get(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> GetAsync(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetIfExists(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> GetIfExistsAsync(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteNetworkServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SiteNetworkServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.SiteNetworkServicePropertiesFormat Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSku Sku { get { throw null; } set { } }
    }
    public partial class SiteNetworkServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteNetworkServiceResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.SiteNetworkServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteNetworkServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteResource() { }
        public virtual Azure.ResourceManager.HybridNetwork.SiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> Update(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> UpdateAsync(Azure.ResourceManager.HybridNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridNetwork.Mocking
{
    public partial class MockableHybridNetworkArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridNetworkArmClient() { }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactManifestResource GetArtifactManifestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ArtifactStoreResource GetArtifactStoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ComponentResource GetComponentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaResource GetConfigurationGroupSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource GetConfigurationGroupValueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupResource GetNetworkFunctionDefinitionGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionResource GetNetworkFunctionDefinitionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionResource GetNetworkFunctionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupResource GetNetworkServiceDesignGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionResource GetNetworkServiceDesignVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.PublisherResource GetPublisherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource GetSiteNetworkServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.SiteResource GetSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridNetworkResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridNetworkResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValue(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource>> GetConfigurationGroupValueAsync(string configurationGroupValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueCollection GetConfigurationGroupValues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunction(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource>> GetNetworkFunctionAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.NetworkFunctionCollection GetNetworkFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.PublisherCollection GetPublishers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource> GetSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteResource>> GetSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkService(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource>> GetSiteNetworkServiceAsync(string siteNetworkServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.SiteNetworkServiceCollection GetSiteNetworkServices() { throw null; }
        public virtual Azure.ResourceManager.HybridNetwork.SiteCollection GetSites() { throw null; }
    }
    public partial class MockableHybridNetworkSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridNetworkSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueResource> GetConfigurationGroupValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.NetworkFunctionResource> GetNetworkFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublishers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.PublisherResource> GetPublishersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteNetworkServiceResource> GetSiteNetworkServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetSites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridNetwork.SiteResource> GetSitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridNetwork.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationEnablement : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationEnablement(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement Enabled { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement left, Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement left, Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHybridNetworkModelFactory
    {
        public static Azure.ResourceManager.HybridNetwork.ArtifactManifestData ArtifactManifestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestPropertiesFormat ArtifactManifestPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState? artifactManifestState = default(Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.ManifestArtifactFormat> artifacts = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ArtifactStoreData ArtifactStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.ArtifactStorePropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactStorePropertiesFormat ArtifactStorePropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType? storeType = default(Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType?), Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy? replicationStrategy = default(Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy?), Azure.ResourceManager.HybridNetwork.Models.ArtifactStorePropertiesFormatManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.Core.ResourceIdentifier storageResourceId = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.AzureContainerRegistryScopedTokenCredential AzureContainerRegistryScopedTokenCredential(string username = null, string acrToken = null, System.Uri acrServerUri = null, System.Collections.Generic.IEnumerable<string> repositories = null, System.DateTimeOffset? expiry = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.AzureStorageAccountContainerCredential AzureStorageAccountContainerCredential(string containerName = null, System.Uri containerSasUri = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.AzureStorageAccountCredential AzureStorageAccountCredential(Azure.Core.ResourceIdentifier storageAccountId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.AzureStorageAccountContainerCredential> containerCredentials = null, System.DateTimeOffset? expiry = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ComponentData ComponentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridNetwork.Models.ComponentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentKubernetesResources ComponentKubernetesResources(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.KubernetesDeployment> deployments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.KubernetesPod> pods = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.KubernetesReplicaSet> replicaSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.KubernetesStatefulSet> statefulSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.KubernetesDaemonSet> daemonSets = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentProperties ComponentProperties(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string deploymentProfile = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentStatusProperties deploymentStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ConfigurationGroupSchemaData ConfigurationGroupSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupSchemaPropertiesFormat ConfigurationGroupSchemaPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.VersionState? versionState = default(Azure.ResourceManager.HybridNetwork.Models.VersionState?), string description = null, string schemaDefinition = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.ConfigurationGroupValueData ConfigurationGroupValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupValuePropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupValuePropertiesFormat ConfigurationGroupValuePropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string configurationGroupSchemaName = null, string configurationGroupSchemaOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference configurationGroupSchemaResourceReference = null, string configurationType = "Unknown") { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ConfigurationValueWithoutSecrets ConfigurationValueWithoutSecrets(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string configurationGroupSchemaName = null, string configurationGroupSchemaOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference configurationGroupSchemaResourceReference = null, string configurationValue = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ConfigurationValueWithSecrets ConfigurationValueWithSecrets(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string configurationGroupSchemaName = null, string configurationGroupSchemaOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference configurationGroupSchemaResourceReference = null, string secretConfigurationValue = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ContainerizedNetworkFunctionDefinitionVersion ContainerizedNetworkFunctionDefinitionVersion(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.VersionState? versionState = default(Azure.ResourceManager.HybridNetwork.Models.VersionState?), string description = null, string deployParameters = null, Azure.ResourceManager.HybridNetwork.Models.ContainerizedNetworkFunctionTemplate networkFunctionTemplate = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.DeploymentStatusProperties DeploymentStatusProperties(Azure.ResourceManager.HybridNetwork.Models.ComponentStatus? status = default(Azure.ResourceManager.HybridNetwork.Models.ComponentStatus?), Azure.ResourceManager.HybridNetwork.Models.ComponentKubernetesResources resources = null, System.DateTimeOffset? nextExpectedUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSku HybridNetworkSku(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName name = default(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName), Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier? tier = default(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.KubernetesDaemonSet KubernetesDaemonSet(string name = null, string @namespace = null, int? desiredNumberOfPods = default(int?), int? currentNumberOfPods = default(int?), int? readyNumberOfPods = default(int?), int? upToDateNumberOfPods = default(int?), int? availableNumberOfPods = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.KubernetesDeployment KubernetesDeployment(string name = null, string @namespace = null, int? desiredNumberOfPods = default(int?), int? readyNumberOfPods = default(int?), int? upToDateNumberOfPods = default(int?), int? availableNumberOfPods = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.KubernetesPod KubernetesPod(string name = null, string @namespace = null, int? desiredNumberOfContainers = default(int?), int? readyNumberOfContainers = default(int?), Azure.ResourceManager.HybridNetwork.Models.PodStatus? status = default(Azure.ResourceManager.HybridNetwork.Models.PodStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.PodEvent> events = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.KubernetesReplicaSet KubernetesReplicaSet(string name = null, string @namespace = null, int? desiredNumberOfPods = default(int?), int? readyNumberOfPods = default(int?), int? currentNumberOfPods = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.KubernetesStatefulSet KubernetesStatefulSet(string name = null, string @namespace = null, int? desiredNumberOfPods = default(int?), int? readyNumberOfPods = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionData NetworkFunctionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionPropertiesFormat properties = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionGroupData NetworkFunctionDefinitionGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionGroupPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionGroupPropertiesFormat NetworkFunctionDefinitionGroupPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string description = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkFunctionDefinitionVersionData NetworkFunctionDefinitionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionPropertiesFormat NetworkFunctionDefinitionVersionPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.VersionState? versionState = default(Azure.ResourceManager.HybridNetwork.Models.VersionState?), string description = null, string deployParameters = null, string networkFunctionType = "Unknown") { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionPropertiesFormat NetworkFunctionPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string networkFunctionDefinitionGroupName = null, string networkFunctionDefinitionVersion = null, string networkFunctionDefinitionOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference networkFunctionDefinitionVersionResourceReference = null, Azure.ResourceManager.HybridNetwork.Models.NfviType? nfviType = default(Azure.ResourceManager.HybridNetwork.Models.NfviType?), Azure.Core.ResourceIdentifier nfviId = null, bool? allowSoftwareUpdate = default(bool?), string configurationType = "Unknown", System.Collections.Generic.IEnumerable<string> roleOverrideValues = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionValueWithoutSecrets NetworkFunctionValueWithoutSecrets(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string networkFunctionDefinitionGroupName = null, string networkFunctionDefinitionVersion = null, string networkFunctionDefinitionOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference networkFunctionDefinitionVersionResourceReference = null, Azure.ResourceManager.HybridNetwork.Models.NfviType? nfviType = default(Azure.ResourceManager.HybridNetwork.Models.NfviType?), Azure.Core.ResourceIdentifier nfviId = null, bool? allowSoftwareUpdate = default(bool?), System.Collections.Generic.IEnumerable<string> roleOverrideValues = null, string deploymentValues = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionValueWithSecrets NetworkFunctionValueWithSecrets(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string networkFunctionDefinitionGroupName = null, string networkFunctionDefinitionVersion = null, string networkFunctionDefinitionOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference networkFunctionDefinitionVersionResourceReference = null, Azure.ResourceManager.HybridNetwork.Models.NfviType? nfviType = default(Azure.ResourceManager.HybridNetwork.Models.NfviType?), Azure.Core.ResourceIdentifier nfviId = null, bool? allowSoftwareUpdate = default(bool?), System.Collections.Generic.IEnumerable<string> roleOverrideValues = null, string secretDeploymentValues = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkServiceDesignGroupData NetworkServiceDesignGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignGroupPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignGroupPropertiesFormat NetworkServiceDesignGroupPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), string description = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.NetworkServiceDesignVersionData NetworkServiceDesignVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionPropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NetworkServiceDesignVersionPropertiesFormat NetworkServiceDesignVersionPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.VersionState? versionState = default(Azure.ResourceManager.HybridNetwork.Models.VersionState?), string description = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> configurationGroupSchemaReferences = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridNetwork.Models.NfviDetails> nfvisFromSite = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.ResourceElementTemplate> resourceElementTemplates = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.PodEvent PodEvent(Azure.ResourceManager.HybridNetwork.Models.PodEventType? eventType = default(Azure.ResourceManager.HybridNetwork.Models.PodEventType?), string reason = null, string message = null, System.DateTimeOffset? lastSeenOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactListOverview ProxyArtifactListOverview(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactOverviewPropertiesValue ProxyArtifactOverviewPropertiesValue(Azure.ResourceManager.HybridNetwork.Models.ArtifactType? artifactType = default(Azure.ResourceManager.HybridNetwork.Models.ArtifactType?), string artifactVersion = null, Azure.ResourceManager.HybridNetwork.Models.ArtifactState? artifactState = default(Azure.ResourceManager.HybridNetwork.Models.ArtifactState?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactVersionsListOverview ProxyArtifactVersionsListOverview(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactOverviewPropertiesValue properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.PublisherPropertiesFormat properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.PublisherPropertiesFormat PublisherPropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.PublisherScope? scope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?)) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteData SiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.SitePropertiesFormat properties = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.SiteNetworkServiceData SiteNetworkServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridNetwork.Models.SiteNetworkServicePropertiesFormat properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSku sku = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.SiteNetworkServicePropertiesFormat SiteNetworkServicePropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.Core.ResourceIdentifier siteReferenceId = null, string publisherName = null, Azure.ResourceManager.HybridNetwork.Models.PublisherScope? publisherScope = default(Azure.ResourceManager.HybridNetwork.Models.PublisherScope?), string networkServiceDesignGroupName = null, string networkServiceDesignVersionName = null, string networkServiceDesignVersionOfferingLocation = null, Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference networkServiceDesignVersionResourceReference = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> desiredStateConfigurationGroupValueReferences = null, string lastStateNetworkServiceDesignVersionName = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> lastStateConfigurationGroupValueReferences = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.SitePropertiesFormat SitePropertiesFormat(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridNetwork.Models.NFVIs> nfvis = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> siteNetworkServiceReferences = null) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.VirtualNetworkFunctionDefinitionVersion VirtualNetworkFunctionDefinitionVersion(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState?), Azure.ResourceManager.HybridNetwork.Models.VersionState? versionState = default(Azure.ResourceManager.HybridNetwork.Models.VersionState?), string description = null, string deployParameters = null, Azure.ResourceManager.HybridNetwork.Models.VirtualNetworkFunctionTemplate networkFunctionTemplate = null) { throw null; }
    }
    public partial class ArmResourceDefinitionResourceElementTemplate
    {
        public ArmResourceDefinitionResourceElementTemplate() { }
        public Azure.ResourceManager.HybridNetwork.Models.NSDArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public string ParameterValues { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.TemplateType? TemplateType { get { throw null; } set { } }
    }
    public partial class ArmResourceDefinitionResourceElementTemplateDetails : Azure.ResourceManager.HybridNetwork.Models.ResourceElementTemplate
    {
        public ArmResourceDefinitionResourceElementTemplateDetails() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArmResourceDefinitionResourceElementTemplate Configuration { get { throw null; } set { } }
    }
    public partial class ArmTemplateArtifactProfile
    {
        public ArmTemplateArtifactProfile() { }
        public string TemplateName { get { throw null; } set { } }
        public string TemplateVersion { get { throw null; } set { } }
    }
    public abstract partial class ArtifactAccessCredential
    {
        protected ArtifactAccessCredential() { }
    }
    public partial class ArtifactChangeState
    {
        public ArtifactChangeState() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactState? ArtifactState { get { throw null; } set { } }
    }
    public partial class ArtifactManifestPropertiesFormat
    {
        public ArtifactManifestPropertiesFormat() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState? ArtifactManifestState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.ManifestArtifactFormat> Artifacts { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactManifestState : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactManifestState(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState Uploaded { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState Uploading { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState Validating { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState left, Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState left, Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactManifestUpdateState
    {
        public ArtifactManifestUpdateState() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactManifestState? ArtifactManifestState { get { throw null; } set { } }
    }
    public partial class ArtifactProfile
    {
        public ArtifactProfile() { }
        public Azure.Core.ResourceIdentifier ArtifactStoreId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactReplicationStrategy : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactReplicationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy SingleReplication { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy left, Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy left, Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactState : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ArtifactState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactState(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactState Active { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactState Preview { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ArtifactState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ArtifactState left, Azure.ResourceManager.HybridNetwork.Models.ArtifactState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ArtifactState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ArtifactState left, Azure.ResourceManager.HybridNetwork.Models.ArtifactState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactStorePropertiesFormat
    {
        public ArtifactStorePropertiesFormat() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactStorePropertiesFormatManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactReplicationStrategy? ReplicationStrategy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageResourceId { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType? StoreType { get { throw null; } set { } }
    }
    public partial class ArtifactStorePropertiesFormatManagedResourceGroupConfiguration
    {
        public ArtifactStorePropertiesFormatManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactStoreType : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactStoreType(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType AzureContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType AzureStorageAccount { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType left, Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType left, Azure.ResourceManager.HybridNetwork.Models.ArtifactStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactType : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ArtifactType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactType(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactType ArmTemplate { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactType ImageFile { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactType OCIArtifact { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactType Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ArtifactType VhdImageFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ArtifactType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ArtifactType left, Azure.ResourceManager.HybridNetwork.Models.ArtifactType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ArtifactType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ArtifactType left, Azure.ResourceManager.HybridNetwork.Models.ArtifactType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureArcK8SClusterNfviDetails : Azure.ResourceManager.HybridNetwork.Models.NFVIs
    {
        public AzureArcK8SClusterNfviDetails() { }
        public Azure.Core.ResourceIdentifier CustomLocationReferenceId { get { throw null; } set { } }
    }
    public partial class AzureArcKubernetesArtifactProfile : Azure.ResourceManager.HybridNetwork.Models.ArtifactProfile
    {
        public AzureArcKubernetesArtifactProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.HelmArtifactProfile HelmArtifactProfile { get { throw null; } set { } }
    }
    public partial class AzureArcKubernetesDeployMappingRuleProfile : Azure.ResourceManager.HybridNetwork.Models.MappingRuleProfile
    {
        public AzureArcKubernetesDeployMappingRuleProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.HelmMappingRuleProfile HelmMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureArcKubernetesHelmApplication : Azure.ResourceManager.HybridNetwork.Models.AzureArcKubernetesNetworkFunctionApplication
    {
        public AzureArcKubernetesHelmApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.AzureArcKubernetesArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.AzureArcKubernetesDeployMappingRuleProfile DeployParametersMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureArcKubernetesNetworkFunctionApplication : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionApplication
    {
        public AzureArcKubernetesNetworkFunctionApplication() { }
    }
    public partial class AzureArcKubernetesNetworkFunctionTemplate : Azure.ResourceManager.HybridNetwork.Models.ContainerizedNetworkFunctionTemplate
    {
        public AzureArcKubernetesNetworkFunctionTemplate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.AzureArcKubernetesNetworkFunctionApplication> NetworkFunctionApplications { get { throw null; } }
    }
    public partial class AzureContainerRegistryScopedTokenCredential : Azure.ResourceManager.HybridNetwork.Models.ArtifactAccessCredential
    {
        internal AzureContainerRegistryScopedTokenCredential() { }
        public System.Uri AcrServerUri { get { throw null; } }
        public string AcrToken { get { throw null; } }
        public System.DateTimeOffset? Expiry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Repositories { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class AzureCoreArmTemplateArtifactProfile : Azure.ResourceManager.HybridNetwork.Models.ArtifactProfile
    {
        public AzureCoreArmTemplateArtifactProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArmTemplateArtifactProfile TemplateArtifactProfile { get { throw null; } set { } }
    }
    public partial class AzureCoreArmTemplateDeployMappingRuleProfile : Azure.ResourceManager.HybridNetwork.Models.MappingRuleProfile
    {
        public AzureCoreArmTemplateDeployMappingRuleProfile() { }
        public string TemplateParameters { get { throw null; } set { } }
    }
    public partial class AzureCoreNetworkFunctionApplication : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionApplication
    {
        public AzureCoreNetworkFunctionApplication() { }
    }
    public partial class AzureCoreNetworkFunctionArmTemplateApplication : Azure.ResourceManager.HybridNetwork.Models.AzureCoreNetworkFunctionApplication
    {
        public AzureCoreNetworkFunctionArmTemplateApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.AzureCoreArmTemplateArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.AzureCoreArmTemplateDeployMappingRuleProfile DeployParametersMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureCoreNetworkFunctionTemplate : Azure.ResourceManager.HybridNetwork.Models.VirtualNetworkFunctionTemplate
    {
        public AzureCoreNetworkFunctionTemplate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.AzureCoreNetworkFunctionApplication> NetworkFunctionApplications { get { throw null; } }
    }
    public partial class AzureCoreNetworkFunctionVhdApplication : Azure.ResourceManager.HybridNetwork.Models.AzureCoreNetworkFunctionApplication
    {
        public AzureCoreNetworkFunctionVhdApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.AzureCoreVhdImageArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.AzureCoreVhdImageDeployMappingRuleProfile DeployParametersMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureCoreNfviDetails : Azure.ResourceManager.HybridNetwork.Models.NFVIs
    {
        public AzureCoreNfviDetails() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class AzureCoreVhdImageArtifactProfile : Azure.ResourceManager.HybridNetwork.Models.ArtifactProfile
    {
        public AzureCoreVhdImageArtifactProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.VhdImageArtifactProfile VhdArtifactProfile { get { throw null; } set { } }
    }
    public partial class AzureCoreVhdImageDeployMappingRuleProfile : Azure.ResourceManager.HybridNetwork.Models.MappingRuleProfile
    {
        public AzureCoreVhdImageDeployMappingRuleProfile() { }
        public string VhdImageMappingRuleUserConfiguration { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusArmTemplateArtifactProfile : Azure.ResourceManager.HybridNetwork.Models.ArtifactProfile
    {
        public AzureOperatorNexusArmTemplateArtifactProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArmTemplateArtifactProfile TemplateArtifactProfile { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusArmTemplateDeployMappingRuleProfile : Azure.ResourceManager.HybridNetwork.Models.MappingRuleProfile
    {
        public AzureOperatorNexusArmTemplateDeployMappingRuleProfile() { }
        public string TemplateParameters { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusClusterNfviDetails : Azure.ResourceManager.HybridNetwork.Models.NFVIs
    {
        public AzureOperatorNexusClusterNfviDetails() { }
        public Azure.Core.ResourceIdentifier CustomLocationReferenceId { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusImageArtifactProfile : Azure.ResourceManager.HybridNetwork.Models.ArtifactProfile
    {
        public AzureOperatorNexusImageArtifactProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.ImageArtifactProfile ImageArtifactProfile { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusImageDeployMappingRuleProfile : Azure.ResourceManager.HybridNetwork.Models.MappingRuleProfile
    {
        public AzureOperatorNexusImageDeployMappingRuleProfile() { }
        public string ImageMappingRuleUserConfiguration { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusNetworkFunctionApplication : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionApplication
    {
        public AzureOperatorNexusNetworkFunctionApplication() { }
    }
    public partial class AzureOperatorNexusNetworkFunctionArmTemplateApplication : Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusNetworkFunctionApplication
    {
        public AzureOperatorNexusNetworkFunctionArmTemplateApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusArmTemplateArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusArmTemplateDeployMappingRuleProfile DeployParametersMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusNetworkFunctionImageApplication : Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusNetworkFunctionApplication
    {
        public AzureOperatorNexusNetworkFunctionImageApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusImageArtifactProfile ArtifactProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusImageDeployMappingRuleProfile DeployParametersMappingRuleProfile { get { throw null; } set { } }
    }
    public partial class AzureOperatorNexusNetworkFunctionTemplate : Azure.ResourceManager.HybridNetwork.Models.VirtualNetworkFunctionTemplate
    {
        public AzureOperatorNexusNetworkFunctionTemplate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.AzureOperatorNexusNetworkFunctionApplication> NetworkFunctionApplications { get { throw null; } }
    }
    public partial class AzureStorageAccountContainerCredential
    {
        internal AzureStorageAccountContainerCredential() { }
        public string ContainerName { get { throw null; } }
        public System.Uri ContainerSasUri { get { throw null; } }
    }
    public partial class AzureStorageAccountCredential : Azure.ResourceManager.HybridNetwork.Models.ArtifactAccessCredential
    {
        internal AzureStorageAccountCredential() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.AzureStorageAccountContainerCredential> ContainerCredentials { get { throw null; } }
        public System.DateTimeOffset? Expiry { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
    }
    public partial class ComponentKubernetesResources
    {
        internal ComponentKubernetesResources() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.KubernetesDaemonSet> DaemonSets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.KubernetesDeployment> Deployments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.KubernetesPod> Pods { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.KubernetesReplicaSet> ReplicaSets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.KubernetesStatefulSet> StatefulSets { get { throw null; } }
    }
    public partial class ComponentProperties
    {
        public ComponentProperties() { }
        public string DeploymentProfile { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.DeploymentStatusProperties DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentStatus : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ComponentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Deployed { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Downloading { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Installing { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus PendingInstall { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus PendingRollback { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus PendingUpgrade { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Reinstalling { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Rollingback { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Superseded { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Uninstalled { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Uninstalling { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ComponentStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ComponentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ComponentStatus left, Azure.ResourceManager.HybridNetwork.Models.ComponentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ComponentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ComponentStatus left, Azure.ResourceManager.HybridNetwork.Models.ComponentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationGroupSchemaPropertiesFormat
    {
        public ConfigurationGroupSchemaPropertiesFormat() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } }
    }
    public partial class ConfigurationGroupSchemaVersionUpdateState
    {
        public ConfigurationGroupSchemaVersionUpdateState() { }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } set { } }
    }
    public abstract partial class ConfigurationGroupValuePropertiesFormat
    {
        protected ConfigurationGroupValuePropertiesFormat() { }
        public string ConfigurationGroupSchemaName { get { throw null; } }
        public string ConfigurationGroupSchemaOfferingLocation { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference ConfigurationGroupSchemaResourceReference { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.PublisherScope? PublisherScope { get { throw null; } }
    }
    public partial class ConfigurationValueWithoutSecrets : Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupValuePropertiesFormat
    {
        public ConfigurationValueWithoutSecrets() { }
        public string ConfigurationValue { get { throw null; } set { } }
    }
    public partial class ConfigurationValueWithSecrets : Azure.ResourceManager.HybridNetwork.Models.ConfigurationGroupValuePropertiesFormat
    {
        public ConfigurationValueWithSecrets() { }
        public string SecretConfigurationValue { get { throw null; } set { } }
    }
    public partial class ContainerizedNetworkFunctionDefinitionVersion : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionPropertiesFormat
    {
        public ContainerizedNetworkFunctionDefinitionVersion() { }
        public Azure.ResourceManager.HybridNetwork.Models.ContainerizedNetworkFunctionTemplate NetworkFunctionTemplate { get { throw null; } set { } }
    }
    public abstract partial class ContainerizedNetworkFunctionTemplate
    {
        protected ContainerizedNetworkFunctionTemplate() { }
    }
    public partial class DependsOnProfile
    {
        public DependsOnProfile() { }
        public System.Collections.Generic.IList<string> InstallDependsOn { get { throw null; } }
        public System.Collections.Generic.IList<string> UninstallDependsOn { get { throw null; } }
        public System.Collections.Generic.IList<string> UpdateDependsOn { get { throw null; } }
    }
    public abstract partial class DeploymentResourceIdReference
    {
        protected DeploymentResourceIdReference() { }
    }
    public partial class DeploymentStatusProperties
    {
        internal DeploymentStatusProperties() { }
        public System.DateTimeOffset? NextExpectedUpdateOn { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ComponentKubernetesResources Resources { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ComponentStatus? Status { get { throw null; } }
    }
    public partial class ExecuteRequestContent
    {
        public ExecuteRequestContent(string serviceEndpoint, Azure.ResourceManager.HybridNetwork.Models.RequestMetadata requestMetadata) { }
        public Azure.ResourceManager.HybridNetwork.Models.RequestMetadata RequestMetadata { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
    }
    public partial class HelmArtifactProfile
    {
        public HelmArtifactProfile() { }
        public string HelmPackageName { get { throw null; } set { } }
        public string HelmPackageVersionRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImagePullSecretsValuesPaths { get { throw null; } }
        public System.Collections.Generic.IList<string> RegistryValuesPaths { get { throw null; } }
    }
    public partial class HelmInstallConfig
    {
        public HelmInstallConfig() { }
        public string Atomic { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public string Wait { get { throw null; } set { } }
    }
    public partial class HelmMappingRuleProfile
    {
        public HelmMappingRuleProfile() { }
        public string HelmPackageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.HelmMappingRuleProfileConfig Options { get { throw null; } set { } }
        public string ReleaseName { get { throw null; } set { } }
        public string ReleaseNamespace { get { throw null; } set { } }
        public string Values { get { throw null; } set { } }
    }
    public partial class HelmMappingRuleProfileConfig
    {
        public HelmMappingRuleProfileConfig() { }
        public Azure.ResourceManager.HybridNetwork.Models.HelmInstallConfig InstallOptions { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.HelmUpgradeConfig UpgradeOptions { get { throw null; } set { } }
    }
    public partial class HelmUpgradeConfig
    {
        public HelmUpgradeConfig() { }
        public string Atomic { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        public string Wait { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpMethod : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.HttpMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpMethod(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Get { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Patch { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Post { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Put { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HttpMethod Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.HttpMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.HttpMethod left, Azure.ResourceManager.HybridNetwork.Models.HttpMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.HttpMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.HttpMethod left, Azure.ResourceManager.HybridNetwork.Models.HttpMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridNetworkSku
    {
        public HybridNetworkSku(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName name) { }
        public Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridNetworkSkuName : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridNetworkSkuName(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName left, Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName left, Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridNetworkSkuTier : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridNetworkSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier left, Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier left, Azure.ResourceManager.HybridNetwork.Models.HybridNetworkSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageArtifactProfile
    {
        public ImageArtifactProfile() { }
        public string ImageName { get { throw null; } set { } }
        public string ImageVersion { get { throw null; } set { } }
    }
    public partial class KubernetesDaemonSet
    {
        internal KubernetesDaemonSet() { }
        public int? AvailableNumberOfPods { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? CurrentNumberOfPods { get { throw null; } }
        public int? DesiredNumberOfPods { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public int? ReadyNumberOfPods { get { throw null; } }
        public int? UpToDateNumberOfPods { get { throw null; } }
    }
    public partial class KubernetesDeployment
    {
        internal KubernetesDeployment() { }
        public int? AvailableNumberOfPods { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? DesiredNumberOfPods { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public int? ReadyNumberOfPods { get { throw null; } }
        public int? UpToDateNumberOfPods { get { throw null; } }
    }
    public partial class KubernetesPod
    {
        internal KubernetesPod() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? DesiredNumberOfContainers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridNetwork.Models.PodEvent> Events { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public int? ReadyNumberOfContainers { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.PodStatus? Status { get { throw null; } }
    }
    public partial class KubernetesReplicaSet
    {
        internal KubernetesReplicaSet() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? CurrentNumberOfPods { get { throw null; } }
        public int? DesiredNumberOfPods { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public int? ReadyNumberOfPods { get { throw null; } }
    }
    public partial class KubernetesStatefulSet
    {
        internal KubernetesStatefulSet() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? DesiredNumberOfPods { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public int? ReadyNumberOfPods { get { throw null; } }
    }
    public partial class ManagedResourceGroupConfiguration
    {
        public ManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ManifestArtifactFormat
    {
        public ManifestArtifactFormat() { }
        public string ArtifactName { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactType? ArtifactType { get { throw null; } set { } }
        public string ArtifactVersion { get { throw null; } set { } }
    }
    public partial class MappingRuleProfile
    {
        public MappingRuleProfile() { }
        public Azure.ResourceManager.HybridNetwork.Models.ApplicationEnablement? ApplicationEnablement { get { throw null; } set { } }
    }
    public partial class NetworkFunctionApplication
    {
        public NetworkFunctionApplication() { }
        public Azure.ResourceManager.HybridNetwork.Models.DependsOnProfile DependsOnProfile { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NetworkFunctionDefinitionGroupPropertiesFormat
    {
        public NetworkFunctionDefinitionGroupPropertiesFormat() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkFunctionDefinitionResourceElementTemplateDetails : Azure.ResourceManager.HybridNetwork.Models.ResourceElementTemplate
    {
        public NetworkFunctionDefinitionResourceElementTemplateDetails() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArmResourceDefinitionResourceElementTemplate Configuration { get { throw null; } set { } }
    }
    public abstract partial class NetworkFunctionDefinitionVersionPropertiesFormat
    {
        protected NetworkFunctionDefinitionVersionPropertiesFormat() { }
        public string DeployParameters { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } }
    }
    public partial class NetworkFunctionDefinitionVersionUpdateState
    {
        public NetworkFunctionDefinitionVersionUpdateState() { }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } set { } }
    }
    public abstract partial class NetworkFunctionPropertiesFormat
    {
        protected NetworkFunctionPropertiesFormat() { }
        public bool? AllowSoftwareUpdate { get { throw null; } set { } }
        public string NetworkFunctionDefinitionGroupName { get { throw null; } }
        public string NetworkFunctionDefinitionOfferingLocation { get { throw null; } }
        public string NetworkFunctionDefinitionVersion { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference NetworkFunctionDefinitionVersionResourceReference { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NfviId { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.NfviType? NfviType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.PublisherScope? PublisherScope { get { throw null; } }
        public System.Collections.Generic.IList<string> RoleOverrideValues { get { throw null; } }
    }
    public partial class NetworkFunctionValueWithoutSecrets : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionPropertiesFormat
    {
        public NetworkFunctionValueWithoutSecrets() { }
        public string DeploymentValues { get { throw null; } set { } }
    }
    public partial class NetworkFunctionValueWithSecrets : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionPropertiesFormat
    {
        public NetworkFunctionValueWithSecrets() { }
        public string SecretDeploymentValues { get { throw null; } set { } }
    }
    public partial class NetworkServiceDesignGroupPropertiesFormat
    {
        public NetworkServiceDesignGroupPropertiesFormat() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkServiceDesignVersionPropertiesFormat
    {
        public NetworkServiceDesignVersionPropertiesFormat() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> ConfigurationGroupSchemaReferences { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridNetwork.Models.NfviDetails> NfvisFromSite { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.ResourceElementTemplate> ResourceElementTemplates { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } }
    }
    public partial class NetworkServiceDesignVersionUpdateState
    {
        public NetworkServiceDesignVersionUpdateState() { }
        public Azure.ResourceManager.HybridNetwork.Models.VersionState? VersionState { get { throw null; } set { } }
    }
    public partial class NfviDetails
    {
        public NfviDetails() { }
        public string Name { get { throw null; } set { } }
        public string NfviDetailsType { get { throw null; } set { } }
    }
    public abstract partial class NFVIs
    {
        protected NFVIs() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfviType : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.NfviType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfviType(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.NfviType AzureArcKubernetes { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.NfviType AzureCore { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.NfviType AzureOperatorNexus { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.NfviType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.NfviType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.NfviType left, Azure.ResourceManager.HybridNetwork.Models.NfviType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.NfviType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.NfviType left, Azure.ResourceManager.HybridNetwork.Models.NfviType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NSDArtifactProfile
    {
        public NSDArtifactProfile() { }
        public string ArtifactName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ArtifactStoreReferenceId { get { throw null; } set { } }
        public string ArtifactVersion { get { throw null; } set { } }
    }
    public partial class OpenDeploymentResourceReference : Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference
    {
        public OpenDeploymentResourceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
    }
    public partial class PodEvent
    {
        internal PodEvent() { }
        public Azure.ResourceManager.HybridNetwork.Models.PodEventType? EventType { get { throw null; } }
        public System.DateTimeOffset? LastSeenOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PodEventType : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.PodEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PodEventType(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.PodEventType Normal { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodEventType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.PodEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.PodEventType left, Azure.ResourceManager.HybridNetwork.Models.PodEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.PodEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.PodEventType left, Azure.ResourceManager.HybridNetwork.Models.PodEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PodStatus : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.PodStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PodStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Running { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Terminating { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PodStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.PodStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.PodStatus left, Azure.ResourceManager.HybridNetwork.Models.PodStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.PodStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.PodStatus left, Azure.ResourceManager.HybridNetwork.Models.PodStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Converging { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.ProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState left, Azure.ResourceManager.HybridNetwork.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.ProvisioningState left, Azure.ResourceManager.HybridNetwork.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyArtifactListOverview : Azure.ResourceManager.Models.ResourceData
    {
        public ProxyArtifactListOverview() { }
    }
    public partial class ProxyArtifactOverviewPropertiesValue
    {
        internal ProxyArtifactOverviewPropertiesValue() { }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactState? ArtifactState { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ArtifactType? ArtifactType { get { throw null; } }
        public string ArtifactVersion { get { throw null; } }
    }
    public partial class ProxyArtifactVersionsListOverview : Azure.ResourceManager.Models.ResourceData
    {
        public ProxyArtifactVersionsListOverview() { }
        public Azure.ResourceManager.HybridNetwork.Models.ProxyArtifactOverviewPropertiesValue Properties { get { throw null; } }
    }
    public partial class PublisherPropertiesFormat
    {
        public PublisherPropertiesFormat() { }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.PublisherScope? Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublisherScope : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.PublisherScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublisherScope(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.PublisherScope Private { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.PublisherScope Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.PublisherScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.PublisherScope left, Azure.ResourceManager.HybridNetwork.Models.PublisherScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.PublisherScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.PublisherScope left, Azure.ResourceManager.HybridNetwork.Models.PublisherScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestMetadata
    {
        public RequestMetadata(string relativePath, Azure.ResourceManager.HybridNetwork.Models.HttpMethod httpMethod, string serializedBody) { }
        public string ApiVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.HttpMethod HttpMethod { get { throw null; } }
        public string RelativePath { get { throw null; } }
        public string SerializedBody { get { throw null; } }
    }
    public abstract partial class ResourceElementTemplate
    {
        protected ResourceElementTemplate() { }
        public Azure.ResourceManager.HybridNetwork.Models.DependsOnProfile DependsOnProfile { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SecretDeploymentResourceReference : Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference
    {
        public SecretDeploymentResourceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
    }
    public partial class SiteNetworkServicePropertiesFormat
    {
        public SiteNetworkServicePropertiesFormat() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> DesiredStateConfigurationGroupValueReferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.WritableSubResource> LastStateConfigurationGroupValueReferences { get { throw null; } }
        public string LastStateNetworkServiceDesignVersionName { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public string NetworkServiceDesignGroupName { get { throw null; } }
        public string NetworkServiceDesignVersionName { get { throw null; } }
        public string NetworkServiceDesignVersionOfferingLocation { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.DeploymentResourceIdReference NetworkServiceDesignVersionResourceReference { get { throw null; } set { } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.PublisherScope? PublisherScope { get { throw null; } }
        public Azure.Core.ResourceIdentifier SiteReferenceId { get { throw null; } set { } }
    }
    public partial class SitePropertiesFormat
    {
        public SitePropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridNetwork.Models.NFVIs> Nfvis { get { throw null; } }
        public Azure.ResourceManager.HybridNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> SiteNetworkServiceReferences { get { throw null; } }
    }
    public partial class TagsObject
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateType : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.TemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateType(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.TemplateType ArmTemplate { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.TemplateType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.TemplateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.TemplateType left, Azure.ResourceManager.HybridNetwork.Models.TemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.TemplateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.TemplateType left, Azure.ResourceManager.HybridNetwork.Models.TemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VersionState : System.IEquatable<Azure.ResourceManager.HybridNetwork.Models.VersionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VersionState(string value) { throw null; }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState Active { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState Preview { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState Validating { get { throw null; } }
        public static Azure.ResourceManager.HybridNetwork.Models.VersionState ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridNetwork.Models.VersionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridNetwork.Models.VersionState left, Azure.ResourceManager.HybridNetwork.Models.VersionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridNetwork.Models.VersionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridNetwork.Models.VersionState left, Azure.ResourceManager.HybridNetwork.Models.VersionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VhdImageArtifactProfile
    {
        public VhdImageArtifactProfile() { }
        public string VhdName { get { throw null; } set { } }
        public string VhdVersion { get { throw null; } set { } }
    }
    public partial class VirtualNetworkFunctionDefinitionVersion : Azure.ResourceManager.HybridNetwork.Models.NetworkFunctionDefinitionVersionPropertiesFormat
    {
        public VirtualNetworkFunctionDefinitionVersion() { }
        public Azure.ResourceManager.HybridNetwork.Models.VirtualNetworkFunctionTemplate NetworkFunctionTemplate { get { throw null; } set { } }
    }
    public abstract partial class VirtualNetworkFunctionTemplate
    {
        protected VirtualNetworkFunctionTemplate() { }
    }
}
