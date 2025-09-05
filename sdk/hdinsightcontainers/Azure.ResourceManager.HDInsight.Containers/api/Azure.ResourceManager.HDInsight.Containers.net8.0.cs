namespace Azure.ResourceManager.HDInsight.Containers
{
    public partial class AzureResourceManagerHDInsightContainersContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHDInsightContainersContext() { }
        public static Azure.ResourceManager.HDInsight.Containers.AzureResourceManagerHDInsightContainersContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HDInsightClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>
    {
        public HDInsightClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Get(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetIfExists(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetIfExistsAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>
    {
        public HDInsightClusterPoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterPoolResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade> GetClusterPoolAvailableUpgrades(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade> GetClusterPoolAvailableUpgradesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory> GetClusterPoolUpgradeHistories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory> GetClusterPoolUpgradeHistoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetHDInsightCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetHDInsightClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterCollection GetHDInsightClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade clusterPoolUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade clusterPoolUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade> GetClusterAvailableUpgrades(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade> GetClusterAvailableUpgradesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary> GetClusterLibraries(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory category, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary> GetClusterLibrariesAsync(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory category, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory> GetClusterUpgradeHistories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory> GetClusterUpgradeHistoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViews(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViewsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult> GetServiceConfigs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult> GetServiceConfigsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ManageLibrariesClusterLibrary(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ManageLibrariesClusterLibraryAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> RunJobClusterJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>> RunJobClusterJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade clusterUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade clusterUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> UpgradeManualRollback(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback clusterRollbackUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> UpgradeManualRollbackAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback clusterRollbackUpgradeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HDInsightContainersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetHDInsightClusterPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource GetHDInsightClusterPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolCollection GetHDInsightClusterPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource GetHDInsightClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Containers.Mocking
{
    public partial class MockableHDInsightContainersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersArmClient() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource GetHDInsightClusterPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource GetHDInsightClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHDInsightContainersResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPool(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetHDInsightClusterPoolAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolCollection GetHDInsightClusterPools() { throw null; }
    }
    public partial class MockableHDInsightContainersSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Containers.Models
{
    public partial class AksClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>
    {
        internal AksClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile AksClusterAgentPoolIdentityProfile { get { throw null; } }
        public Azure.Core.ResourceIdentifier AksClusterResourceId { get { throw null; } }
        public string AksVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmHDInsightContainersModelFactory
    {
        public static Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile AksClusterProfile(Azure.Core.ResourceIdentifier aksClusterResourceId = null, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile aksClusterAgentPoolIdentityProfile = null, string aksVersion = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile ClusterAccessProfile(bool enableInternalIngress = false, Azure.Core.ResourceIdentifier privateLinkServiceId = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade ClusterAvailableUpgrade(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem ClusterComponentItem(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile ClusterConnectivityProfile(Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint web = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> ssh = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties ClusterInstanceViewProperties(Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus> serviceStatuses = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult ClusterInstanceViewResult(string name = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus ClusterInstanceViewStatus(string ready = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob ClusterJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary ClusterLibrary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent ClusterLibraryManagementOperationContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties ClusterLibraryProperties(string libraryType = null, string remarks = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.ResourceManager.HDInsight.Containers.Models.Status? status = default(Azure.ResourceManager.HDInsight.Containers.Models.Status?), string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties ClusterMavenLibraryProperties(string remarks = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.ResourceManager.HDInsight.Containers.Models.Status? status = default(Azure.ResourceManager.HDInsight.Containers.Models.Status?), string message = null, string groupId = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade ClusterPoolAvailableUpgrade(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile ClusterPoolComputeProfile(string vmSize = null, int? count = default(int?), System.Collections.Generic.IEnumerable<string> availabilityZones = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory ClusterPoolUpgradeHistory(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion ClusterPoolVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile(string clusterVersion = null, string ossVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> components = null, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile identityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec> identityList = null, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile secretsProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> serviceConfigsProfiles = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile connectivityProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile clusterAccessProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile logAnalyticsProfile = null, bool? isEnabled = default(bool?), Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile sshProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile autoscaleProfile = null, bool? isRangerForClusterEnabled = default(bool?), Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile kafkaProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile trinoProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> llapProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile flinkProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile sparkProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile rangerProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> stubProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> scriptActionProfiles = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties ClusterPyPILibraryProperties(string remarks = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.ResourceManager.HDInsight.Containers.Models.Status? status = default(Azure.ResourceManager.HDInsight.Containers.Models.Status?), string message = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent ClusterResizeContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? clusterResizeTargetWorkerNodeCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties ClusterServiceConfigProperties(string serviceName = null, string fileName = null, string content = null, string componentName = null, string serviceConfigListResultPropertiesType = null, string path = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customKeys = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity> defaultKeys = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult ClusterServiceConfigResult(Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity ClusterServiceConfigValueEntity(string value = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile ClusterSshProfile(int count = 0, string podPrefix = null, string vmSize = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory ClusterUpgradeHistory(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties ClusterVersionProperties(string clusterType = null, string clusterVersion = null, string ossVersion = null, string clusterPoolVersion = null, bool? isPreview = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> components = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties FlinkJobProperties(string runId = null, string jobName = null, string jobJarDirectory = null, string jarName = null, string entryClass = null, string args = null, string savePointName = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction? action = default(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction?), System.Collections.Generic.IDictionary<string, string> flinkConfiguration = null, string jobId = null, string status = null, string jobOutput = null, string actionResult = null, string lastSavePoint = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData HDInsightClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData HDInsightClusterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties HDInsightClusterPoolProperties(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus?), string deploymentId = null, string managedResourceGroupName = null, string aksManagedResourceGroupName = null, string clusterPoolVersion = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile computeProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile aksClusterProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile networkProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile logAnalyticsProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties HDInsightClusterProperties(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus?), string clusterType = null, string deploymentId = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile computeProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile clusterProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion HDInsightClusterVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult HDInsightNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus HDInsightServiceStatus(string kind = null, string ready = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints KafkaConnectivityEndpoints(string bootstrapServerEndpoint = null, System.Collections.Generic.IEnumerable<string> brokerEndpoints = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile KafkaProfile(bool? isKRaftEnabled = default(bool?), bool? isPublicEndpointsEnabled = default(bool?), string remoteStorageUriString = null, Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile diskStorage = null, Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints connectivityEndpoints = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint SshConnectivityEndpoint(string endpoint = null, string privateSshEndpoint = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint WebConnectivityEndpoint(string fqdn = null, string privateFqdn = null) { throw null; }
    }
    public partial class AuthorizationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>
    {
        public AuthorizationProfile() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public System.Collections.Generic.IList<string> UserIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoscaleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>
    {
        public AutoscaleSchedule(string startOn, string endOn, int count, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> days) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> Days { get { throw null; } }
        public string EndOn { get { throw null; } set { } }
        public string StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoscaleScheduleDay : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoscaleScheduleDay(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Friday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Monday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAccessProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>
    {
        public ClusterAccessProfile(bool enableInternalIngress) { }
        public bool EnableInternalIngress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAksPatchUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>
    {
        public ClusterAksPatchUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        public string NewVersion { get { throw null; } set { } }
        public string OriginalVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAksPatchUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAKSPatchVersionUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>
    {
        public ClusterAKSPatchVersionUpgradeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAKSPatchVersionUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAutoscaleProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>
    {
        public ClusterAutoscaleProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType? AutoscaleType { get { throw null; } set { } }
        public int? GracefulDecommissionTimeout { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig LoadBasedConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig ScheduleBasedConfig { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterAutoscaleType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterAutoscaleType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType LoadBased { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType ScheduleBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAvailableInPlaceUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>
    {
        public ClusterAvailableInPlaceUpgradeProperties() { }
        public string ComponentName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExtendedProperties { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType? Severity { get { throw null; } set { } }
        public string SourceBuildNumber { get { throw null; } set { } }
        public string SourceClusterVersion { get { throw null; } set { } }
        public string SourceOssVersion { get { throw null; } set { } }
        public string TargetBuildNumber { get { throw null; } set { } }
        public string TargetClusterVersion { get { throw null; } set { } }
        public string TargetOssVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAvailableUpgrade : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>
    {
        public ClusterAvailableUpgrade() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAvailableUpgradeAksPatchUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>
    {
        public ClusterAvailableUpgradeAksPatchUpgradeProperties() { }
        public string CurrentVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus? CurrentVersionStatus { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeAksPatchUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAvailableUpgradeHotfixUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>
    {
        public ClusterAvailableUpgradeHotfixUpgradeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeHotfixUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAvailableUpgradePatchVersionUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableInPlaceUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>
    {
        public ClusterAvailableUpgradePatchVersionUpgradeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradePatchVersionUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterAvailableUpgradeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>
    {
        protected ClusterAvailableUpgradeProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAvailableUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterComponentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>
    {
        internal ClusterComponentItem() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterComputeNodeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>
    {
        public ClusterComputeNodeProfile(string nodeProfileType, string vmSize, int count) { }
        public int Count { get { throw null; } set { } }
        public string NodeProfileType { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>
    {
        public ClusterComputeProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile> nodes) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile> Nodes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterConfigFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>
    {
        public ClusterConfigFile(string fileName) { }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding? Encoding { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterConnectivityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>
    {
        internal ClusterConnectivityProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> Ssh { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint Web { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterHotfixUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>
    {
        public ClusterHotfixUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterHotfixUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>
    {
        public ClusterHotfixUpgradeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterHotfixUpgradeRollbackHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>
    {
        public ClusterHotfixUpgradeRollbackHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterHotfixUpgradeRollbackHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInPlaceUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>
    {
        public ClusterInPlaceUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType? Severity { get { throw null; } set { } }
        public string SourceBuildNumber { get { throw null; } set { } }
        public string SourceClusterVersion { get { throw null; } set { } }
        public string SourceOssVersion { get { throw null; } set { } }
        public string TargetBuildNumber { get { throw null; } set { } }
        public string TargetClusterVersion { get { throw null; } set { } }
        public string TargetOssVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInPlaceUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>
    {
        public ClusterInPlaceUpgradeProperties() { }
        public string ComponentName { get { throw null; } set { } }
        public string TargetBuildNumber { get { throw null; } set { } }
        public string TargetClusterVersion { get { throw null; } set { } }
        public string TargetOssVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInstanceViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>
    {
        internal ClusterInstanceViewProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus> ServiceStatuses { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInstanceViewResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>
    {
        internal ClusterInstanceViewResult() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>
    {
        internal ClusterInstanceViewStatus() { }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterJob : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>
    {
        public ClusterJob(Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>
    {
        protected ClusterJobProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLibrary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>
    {
        public ClusterLibrary(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterLibraryCategory : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterLibraryCategory(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory Custom { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory Predefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterLibraryManagementOperationContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>
    {
        public ClusterLibraryManagementOperationContent(Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLibraryManagementOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>
    {
        public ClusterLibraryManagementOperationProperties(Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction action, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary> libraries) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibrary> Libraries { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryManagementOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterLibraryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>
    {
        protected ClusterLibraryProperties() { }
        public string Message { get { throw null; } }
        public string Remarks { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.Status? Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLogAnalyticsApplicationLogs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>
    {
        public ClusterLogAnalyticsApplicationLogs() { }
        public bool? IsStdErrorEnabled { get { throw null; } set { } }
        public bool? IsStdOutEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLogAnalyticsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>
    {
        public ClusterLogAnalyticsProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs ApplicationLogs { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsMetricsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterMavenLibraryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>
    {
        public ClusterMavenLibraryProperties(string groupId, string name) { }
        public string GroupId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterMavenLibraryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPatchVersionUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>
    {
        public ClusterPatchVersionUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPatchVersionUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>
    {
        public ClusterPatchVersionUpgradeProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPatchVersionUpgradeRollbackHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInPlaceUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>
    {
        public ClusterPatchVersionUpgradeRollbackHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatchVersionUpgradeRollbackHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolAksPatchUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>
    {
        public ClusterPoolAksPatchUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType)) { }
        public string NewVersion { get { throw null; } set { } }
        public string OriginalVersion { get { throw null; } set { } }
        public bool? UpgradeAllClusterNodes { get { throw null; } set { } }
        public bool? UpgradeClusterPool { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAksPatchUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolAKSPatchVersionUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>
    {
        public ClusterPoolAKSPatchVersionUpgradeProperties() { }
        public string TargetAksVersion { get { throw null; } set { } }
        public bool? UpgradeAllClusterNodes { get { throw null; } set { } }
        public bool? UpgradeClusterPool { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAKSPatchVersionUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolAvailableUpgrade : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>
    {
        public ClusterPoolAvailableUpgrade() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolAvailableUpgradeAksPatchUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>
    {
        public ClusterPoolAvailableUpgradeAksPatchUpgradeProperties() { }
        public string CurrentVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus? CurrentVersionStatus { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeAksPatchUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolAvailableUpgradeNodeOSUpgradeProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>
    {
        public ClusterPoolAvailableUpgradeNodeOSUpgradeProperties() { }
        public string LatestVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeNodeOSUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterPoolAvailableUpgradeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>
    {
        protected ClusterPoolAvailableUpgradeProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolAvailableUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>
    {
        public ClusterPoolComputeProfile(string vmSize) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public int? Count { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolLogAnalyticsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>
    {
        public ClusterPoolLogAnalyticsProfile(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>
    {
        public ClusterPoolNetworkProfile(Azure.Core.ResourceIdentifier subnetId) { }
        public System.Collections.Generic.IList<string> ApiServerAuthorizedIPRanges { get { throw null; } }
        public bool? IsPrivateApiServerEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.OutboundType? OutboundType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolNodeOSImageUpdateProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>
    {
        public ClusterPoolNodeOSImageUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSImageUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolNodeOSUpgradeHistoryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>
    {
        public ClusterPoolNodeOSUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType upgradeResult) : base (default(string), default(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType)) { }
        public string NewNodeOS { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNodeOSUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>
    {
        public ClusterPoolUpgrade(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolUpgradeHistory : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>
    {
        public ClusterPoolUpgradeHistory(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterPoolUpgradeHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>
    {
        protected ClusterPoolUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType upgradeResult) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType UpgradeResult { get { throw null; } set { } }
        public string UtcTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPoolUpgradeHistoryUpgradeResultType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPoolUpgradeHistoryUpgradeResultType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeHistoryUpgradeResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ClusterPoolUpgradeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>
    {
        protected ClusterPoolUpgradeProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>
    {
        public ClusterPoolVersion() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>
    {
        public ClusterPoolVersionProperties() { }
        public string AksVersion { get { throw null; } set { } }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>
    {
        public ClusterProfile(string clusterVersion, string ossVersion, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAccessProfile ClusterAccessProfile { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> Components { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile ConnectivityProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile FlinkProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec> IdentityList { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile IdentityProfile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsRangerForClusterEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile KafkaProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> LlapProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile RangerProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile SecretsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile SparkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile SshProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StubProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile TrinoProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPyPILibraryProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterLibraryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>
    {
        public ClusterPyPILibraryProperties(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPyPILibraryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterResizeContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>
    {
        public ClusterResizeContent(Azure.Core.AzureLocation location) { }
        public int? ClusterResizeTargetWorkerNodeCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>
    {
        public ClusterSecretReference(string referenceName, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType keyVaultObjectType, string keyVaultObjectName) { }
        public string KeyVaultObjectName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType KeyVaultObjectType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSecretsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>
    {
        public ClusterSecretsProfile(Azure.Core.ResourceIdentifier keyVaultResourceId) { }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference> Secrets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>
    {
        public ClusterServiceConfig(string component, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> files) { }
        public string Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> Files { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>
    {
        internal ClusterServiceConfigProperties() { }
        public string ComponentName { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomKeys { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity> DefaultKeys { get { throw null; } }
        public string FileName { get { throw null; } }
        public string Path { get { throw null; } }
        public string ServiceConfigListResultPropertiesType { get { throw null; } }
        public string ServiceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>
    {
        internal ClusterServiceConfigResult() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>
    {
        public ClusterServiceConfigsProfile(string serviceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> configs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> Configs { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigValueEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>
    {
        internal ClusterServiceConfigValueEntity() { }
        public string Description { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSshProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>
    {
        public ClusterSshProfile(int count) { }
        public int Count { get { throw null; } set { } }
        public string PodPrefix { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>
    {
        public ClusterUpgrade(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUpgradeHistory : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>
    {
        public ClusterUpgradeHistory(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterUpgradeHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>
    {
        protected ClusterUpgradeHistoryProperties(string utcTime, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType upgradeResult) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType UpgradeResult { get { throw null; } set { } }
        public string UtcTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeHistorySeverityType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeHistorySeverityType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType Critical { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType High { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType Low { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistorySeverityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeHistoryUpgradeResultType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeHistoryUpgradeResultType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeHistoryUpgradeResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ClusterUpgradeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>
    {
        protected ClusterUpgradeProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUpgradeRollback : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>
    {
        public ClusterUpgradeRollback(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties properties) { }
        public string ClusterUpgradeHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollback>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUpgradeRollbackProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>
    {
        public ClusterUpgradeRollbackProperties(string upgradeHistory) { }
        public string UpgradeHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeRollbackProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpgradeSeverityType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpgradeSeverityType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType Critical { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType High { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType Low { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterUpgradeSeverityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>
    {
        public ClusterVersionProperties() { }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> Components { get { throw null; } }
        public bool? IsPreview { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceRequirement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>
    {
        public ComputeResourceRequirement(float cpu, long memory) { }
        public float Cpu { get { throw null; } set { } }
        public long Memory { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrentClusterAksVersionStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrentClusterAksVersionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus Deprecated { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus Supported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus left, Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus left, Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterAksVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrentClusterPoolAksVersionStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrentClusterPoolAksVersionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus Deprecated { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus Supported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus left, Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus left, Azure.ResourceManager.HDInsight.Containers.Models.CurrentClusterPoolAksVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataDiskType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataDiskType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType PremiumSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType PremiumSsdV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType PremiumSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType StandardHddLrs { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType StandardSsdZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType left, Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType left, Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBConnectionAuthenticationMode : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBConnectionAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode IdentityAuth { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode SqlAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode left, Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode left, Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentMode : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode Application { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode Session { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode left, Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode left, Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>
    {
        public DiskStorageProfile(int dataDiskSize, Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType dataDiskType) { }
        public int DataDiskSize { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.DataDiskType DataDiskType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkHiveCatalogOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>
    {
        public FlinkHiveCatalogOption(string metastoreDBConnectionUriString) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode? MetastoreDBConnectionAuthenticationMode { get { throw null; } set { } }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlinkJobAction : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlinkJobAction(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Cancel { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Delete { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction LastStateUpdate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction ListSavepoint { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction New { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction RELaunch { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Savepoint { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Start { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction StatelessUpdate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Stop { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction left, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction left, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlinkJobProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>
    {
        public FlinkJobProfile(string jobJarDirectory, string jarName, Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode upgradeMode) { }
        public string Args { get { throw null; } set { } }
        public string EntryClass { get { throw null; } set { } }
        public string JarName { get { throw null; } set { } }
        public string JobJarDirectory { get { throw null; } set { } }
        public string SavePointName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode UpgradeMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkJobProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>
    {
        public FlinkJobProperties() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction? Action { get { throw null; } set { } }
        public string ActionResult { get { throw null; } }
        public string Args { get { throw null; } set { } }
        public string EntryClass { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FlinkConfiguration { get { throw null; } }
        public string JarName { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string JobJarDirectory { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public string JobOutput { get { throw null; } }
        public string LastSavePoint { get { throw null; } }
        public string RunId { get { throw null; } set { } }
        public string SavePointName { get { throw null; } set { } }
        public string Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>
    {
        public FlinkProfile(Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile storage, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement jobManager, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement taskManager) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption CatalogOptionsHive { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.DeploymentMode? DeploymentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement HistoryServer { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement JobManager { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProfile JobSpec { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile Storage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement TaskManager { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>
    {
        public FlinkStorageProfile(string storageUriString) { }
        public string Storagekey { get { throw null; } set { } }
        public string StorageUriString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>
    {
        public HDInsightClusterPatch() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile ClusterProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>
    {
        public HDInsightClusterPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>
    {
        public HDInsightClusterPoolProperties(Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile computeProfile) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile AksClusterProfile { get { throw null; } }
        public string AksManagedResourceGroupName { get { throw null; } }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile ComputeProfile { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>
    {
        public HDInsightClusterProperties(string clusterType, Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile computeProfile, Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile clusterProfile) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeProfile ComputeProfile { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>
    {
        public HDInsightClusterVersion() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightComparisonOperator : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightComparisonOperator(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightComparisonRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>
    {
        public HDInsightComparisonRule(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator @operator, float threshold) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator Operator { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightContentEncoding : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightContentEncoding(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding Base64 { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightIdentityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>
    {
        public HDInsightIdentityProfile(Azure.Core.ResourceIdentifier msiResourceId, string msiClientId, string msiObjectId) { }
        public string MsiClientId { get { throw null; } set { } }
        public string MsiObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightManagedIdentitySpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>
    {
        public HDInsightManagedIdentitySpec(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType identityType, Azure.Core.ResourceIdentifier resourceId, string clientId, string objectId) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType IdentityType { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentitySpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightManagedIdentityType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType Cluster { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType Internal { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>
    {
        internal HDInsightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightProvisioningStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightServiceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>
    {
        internal HDInsightServiceStatus() { }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HiveCatalogOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>
    {
        public HiveCatalogOption(string catalogName, string metastoreDBConnectionUriString, string metastoreWarehouseDir) { }
        public string CatalogName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode? MetastoreDBConnectionAuthenticationMode { get { throw null; } set { } }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
        public string MetastoreWarehouseDir { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaConnectivityEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>
    {
        internal KafkaConnectivityEndpoints() { }
        public string BootstrapServerEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> BrokerEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>
    {
        public KafkaProfile(Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile diskStorage) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.KafkaConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.DiskStorageProfile DiskStorage { get { throw null; } set { } }
        public bool? IsKRaftEnabled { get { throw null; } set { } }
        public bool? IsPublicEndpointsEnabled { get { throw null; } set { } }
        public string RemoteStorageUriString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.KafkaProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultObjectType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultObjectType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Certificate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Key { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Secret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType left, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType left, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LibraryManagementAction : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LibraryManagementAction(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction Install { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction left, Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction left, Azure.ResourceManager.HDInsight.Containers.Models.LibraryManagementAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBasedConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>
    {
        public LoadBasedConfig(int minNodes, int maxNodes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> scalingRules) { }
        public int? CooldownPeriod { get { throw null; } set { } }
        public int MaxNodes { get { throw null; } set { } }
        public int MinNodes { get { throw null; } set { } }
        public int? PollIntervalInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> ScalingRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetastoreDBConnectionAuthenticationMode : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetastoreDBConnectionAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode IdentityAuth { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode SqlAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode left, Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode left, Azure.ResourceManager.HDInsight.Containers.Models.MetastoreDBConnectionAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutboundType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.OutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutboundType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.OutboundType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.OutboundType UserDefinedRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.OutboundType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.OutboundType left, Azure.ResourceManager.HDInsight.Containers.Models.OutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.OutboundType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.OutboundType left, Azure.ResourceManager.HDInsight.Containers.Models.OutboundType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangerAdminSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>
    {
        public RangerAdminSpec(System.Collections.Generic.IEnumerable<string> admins, Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase database) { }
        public System.Collections.Generic.IList<string> Admins { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase Database { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RangerAdminSpecDatabase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>
    {
        public RangerAdminSpecDatabase(string host, string name) { }
        public string Host { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PasswordSecretRef { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpecDatabase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RangerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>
    {
        public RangerProfile(Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec rangerAdmin, Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec rangerUsersync) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerAdminSpec RangerAdmin { get { throw null; } set { } }
        public string RangerAuditStorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec RangerUsersync { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangerUsersyncMode : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangerUsersyncMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode left, Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode left, Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangerUsersyncSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>
    {
        public RangerUsersyncSpec() { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncMode? Mode { get { throw null; } set { } }
        public string UserMappingLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.RangerUsersyncSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleActionType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleActionType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ScaleDown { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType left, Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType left, Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScalingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>
    {
        public ScalingRule(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType actionType, int evaluationCount, string scalingMetric, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule comparisonRule) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule ComparisonRule { get { throw null; } set { } }
        public int EvaluationCount { get { throw null; } set { } }
        public string ScalingMetric { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleBasedConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>
    {
        public ScheduleBasedConfig(string timeZone, int defaultCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> schedules) { }
        public int DefaultCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> Schedules { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptActionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>
    {
        public ScriptActionProfile(string scriptActionProfileType, string name, string uriString, System.Collections.Generic.IEnumerable<string> services) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string ScriptActionProfileType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Services { get { throw null; } }
        public bool? ShouldPersist { get { throw null; } set { } }
        public int? TimeoutInMinutes { get { throw null; } set { } }
        public string UriString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkMetastoreSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>
    {
        public SparkMetastoreSpec(string dbServerHost, string dbName) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.DBConnectionAuthenticationMode? DBConnectionAuthenticationMode { get { throw null; } set { } }
        public string DBName { get { throw null; } set { } }
        public string DBPasswordSecretName { get { throw null; } set { } }
        public string DBServerHost { get { throw null; } set { } }
        public string DBUserName { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public string ThriftUriString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>
    {
        public SparkProfile() { }
        public string DefaultStorageUriString { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec MetastoreSpec { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin> Plugins { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkUserPlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>
    {
        public SparkUserPlugin(string path) { }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshConnectivityEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>
    {
        internal SshConnectivityEndpoint() { }
        public string Endpoint { get { throw null; } }
        public string PrivateSshEndpoint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.Status Installed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.Status InstallFailed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.Status Installing { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.Status UninstallFailed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.Status Uninstalling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.Status left, Azure.ResourceManager.HDInsight.Containers.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.Status left, Azure.ResourceManager.HDInsight.Containers.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrinoCoordinator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>
    {
        public TrinoCoordinator() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig Debug { get { throw null; } set { } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoDebugConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>
    {
        public TrinoDebugConfig() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsSuspendEnabled { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>
    {
        public TrinoProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption> CatalogOptionsHive { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator Coordinator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin> Plugins { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig UserTelemetrySpecStorage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoDebugConfig WorkerDebug { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoTelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>
    {
        public TrinoTelemetryConfig() { }
        public string HivecatalogName { get { throw null; } set { } }
        public string HivecatalogSchema { get { throw null; } set { } }
        public int? PartitionRetentionInDays { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoUserPlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>
    {
        public TrinoUserPlugin() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatableClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>
    {
        public UpdatableClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsRangerForClusterEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.RangerProfile RangerProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile SecretsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile SshProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile TrinoProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpgradeMode : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode LastStateUpdate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode StatelessUpdate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode left, Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode left, Azure.ResourceManager.HDInsight.Containers.Models.UpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebConnectivityEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>
    {
        internal WebConnectivityEndpoint() { }
        public string Fqdn { get { throw null; } }
        public string PrivateFqdn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.WebConnectivityEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
